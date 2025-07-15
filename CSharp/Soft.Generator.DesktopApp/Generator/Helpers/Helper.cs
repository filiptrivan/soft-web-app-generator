using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator.Helpers
{
    public class Helper
    {
        public static void WriteToFileAndMakeFolders(string data, string path)
        {
            if (data != null)
            {
                string directoryPath = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(data);
                }
            }
        }

        public static void WriteToFileAndMakeFolders(StringBuilder data, string path)
        {
            if (data != null)
            {
                string directoryPath = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(data);
                }
            }
        }

        public static void WriteToFile(string data, string path)
        {
            if (data != null)
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(data);
                sw.Close();
            }
        }

        public static void WriteToFile(StringBuilder data, string path)
        {
            if (data != null)
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(data);
                sw.Close();
            }
        }

        public static string MakeFolder(string path, string name)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($"Directory not found: {path}");

            string newFolderPath = Path.Combine(path, name);

            FolderOverrideCheck(newFolderPath);

            Directory.CreateDirectory(newFolderPath);

            return newFolderPath;
        }

        public static void CopyFolder(string sourcePath, string destinationPath, string destinationFolderName)
        {
            if (destinationPath.StartsWith(sourcePath, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Destination path cannot be a subdirectory of the source path.");

            if (!Directory.Exists(sourcePath))
                throw new DirectoryNotFoundException($"Source directory not found: {sourcePath}");

            string newFolderPath = MakeFolder(destinationPath, destinationFolderName);

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string destFilePath = Path.Combine(newFolderPath, Path.GetFileName(file));

                FileOverrideCheck(destFilePath);

                File.Copy(file, destFilePath, true);
            }

            foreach (string directory in Directory.GetDirectories(sourcePath))
                CopyFolder(directory, newFolderPath, Path.GetFileName(directory));
        }

        public static void FolderOverrideCheck(string path)
        {
            if (Directory.Exists(path))
            {
                throw new Exception($"Direktorijum na putanji {path} već postoji.");
            }
        }

        public static void FileOverrideCheck(string path)
        {
            if (File.Exists(path))
            {
                throw new Exception($"Datoteka na putanji {path} već postoji.");
            }
        }

        public static string GetGenericIdTypeFromTheBaseType(Type entity)
        {
            if (entity == null)
                return null;

            Type baseType = entity.BaseType;

            if (baseType == null) 
                return null;

            while (baseType != null)
            {
                if (baseType.Name == "BusinessObject" || baseType.Name == "ReadonlyObject")
                {
                    return baseType.GenericTypeArguments.Select(x => x.Name).FirstOrDefault();
                }

                baseType = baseType.BaseType;
            }

            return null;
        }

        public static string GetPagesSubfolder(IGrouping<string, Type> entityGroup, Type type)
        {
            if (type.Name == entityGroup.Key)
                return null;

            return $"/{type.Name.FromPascalToKebabCase()}";
        }

        /// <summary>
        /// Generates a cryptographically secure JWT secret key as a Base64 string. <br/><br/>
        /// The strength depends on the byte size (default 64 bytes = 512 bits ~ 88 characters).
        /// </summary>
        /// <param name="byteSize">Number of random bytes (default: 64)</param>
        /// <returns>Base64-encoded secret key</returns>
        public static string GenerateJwtSecretKey(int byteSize = 64)
        {
            if (byteSize < 1)
                throw new ArgumentException("Byte size must be at least 1.", nameof(byteSize));

            byte[] randomBytes = new byte[byteSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        #region SQL Server

        /// <summary>
        /// Attempts to find an available SQL Server connection string by checking common data sources.
        /// </summary>
        public static string GetAvailableSqlServerConnectionString(string databaseName)
        {
            List<string> dataSources = new List<string>
            {
                "localhost",
                @"localhost\SQLEXPRESS",
                @"(localdb)\MSSQLLocalDB"
            };

            foreach (string dataSource in dataSources)
            {
                SqlConnectionStringBuilder connectionStringBuilder = BuildConnectionString(dataSource);
                if (TryConnect(connectionStringBuilder))
                {
                    connectionStringBuilder.InitialCatalog = databaseName;
                    return connectionStringBuilder.ConnectionString;
                }
            }

            return null;
        }

        /// <summary>
        /// Constructs a SQL Server connection string for either the default or SQL Express instance.
        /// </summary>
        public static SqlConnectionStringBuilder BuildConnectionString(string dataSource)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = "master",
                IntegratedSecurity = true,
                Encrypt = false,
                MultipleActiveResultSets = true,
            };

            return builder;
        }

        /// <summary>
        /// Tries to open a connection using the provided connection string.
        /// </summary>
        private static bool TryConnect(SqlConnectionStringBuilder connectionString)
        {
            try
            {
                connectionString.ConnectTimeout = 2;
                using SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
                connection.Open();
                connectionString.ConnectTimeout = 15;
                return true;
            }
            catch (Exception) { }

            connectionString.ConnectTimeout = 15;
            return false;
        }

        #endregion

        #region Assembly Load Helpers

        public static List<Type> GetTypesSafely(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes().ToList();
            }
            catch (ReflectionTypeLoadException ex)
            {
                //Console.WriteLine(ex.Message);

                return ex.Types.Where(t => t != null).ToList();
            }
        }

        public static List<Type> GetEntityTypes(List<Assembly> projectAssemblies)
        {
            HashSet<Type> result = new HashSet<Type>();

            foreach (Assembly assembly in projectAssemblies)
            {
                foreach (Type type in GetTypesSafely(assembly).Where(x => x.IsEntityType()))
                {
                    if (result.Contains(type) == false)
                        result.Add(type);
                }
            }

            return result.ToList();
        }

        public static List<Type> GetDTOTypes(List<Assembly> projectAssemblies)
        {
            HashSet<Type> result = new HashSet<Type>();

            foreach (Assembly assembly in projectAssemblies)
            {
                foreach (Type type in GetTypesSafely(assembly).Where(x => x.IsDTOType()))
                {
                    if (result.Contains(type) == false)
                        result.Add(type);
                }
            }

            return result.ToList();
        }

        public static void LoadReferencedAssemblies(Assembly assembly, HashSet<Assembly> visitedAssemblies)
        {
            if (visitedAssemblies.Contains(assembly))
                return;

            visitedAssemblies.Add(assembly);

            foreach (AssemblyName referencedAssemblyName in assembly.GetReferencedAssemblies())
            {
                try
                {
                    Assembly referencedAssembly = Assembly.Load(referencedAssemblyName);
                    LoadReferencedAssemblies(referencedAssembly, visitedAssemblies);
                }
                catch (Exception ex)
                {
                    // TODO FT: Log
                    //Console.WriteLine($"Could not load assembly: {referencedAssemblyName.FullName}. Error: {ex.Message}");
                }
            }
        }

        #endregion
    }
}
