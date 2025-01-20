using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                DialogResult dialogResult = MessageBox.Show($"Direktorijum na putanji {path}, već postoji, da li želite nastavite?", "Potvrda", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                    throw new Exception("Prekinuli ste operaciju.");
            }
        }

        public static void FileOverrideCheck(string path)
        {
            if (File.Exists(path))
            {
                DialogResult dialogResult = MessageBox.Show($"Datoteka na putanji {path}, već postoji, da li želite nastavite?", "Potvrda", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                    throw new Exception("Prekinuli ste operaciju.");
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
