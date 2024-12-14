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
        public static void WriteToTheFile(string data, string path)
        {
            if (data != null)
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(data);
                sw.Close();
            }
        }

        public static void WriteToTheFile(StringBuilder data, string path)
        {
            if (data != null)
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(data);
                sw.Close();
            }
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
