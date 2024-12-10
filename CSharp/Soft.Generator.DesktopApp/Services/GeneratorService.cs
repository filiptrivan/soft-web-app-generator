using Soft.Generator.DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Services
{
    public class GeneratorService
    {
        public static List<string> _projectEntityNamespaces = new List<string>();
        public static List<Assembly> _projectAssemblies = new List<Assembly>();
        public static List<Type> _DTOTypes = new List<Type>();
        public static List<Type> _entityTypes = new List<Type>();

        public GeneratorService(List<DllPath> dllPaths)
        {
            foreach (DllPath dllPath in dllPaths)
            {
                Assembly assembly = Assembly.LoadFrom(dllPath.Path);
                _projectAssemblies.Add(assembly);
            }

            HashSet<Assembly> visitedAssemblies = new HashSet<Assembly>();

            //foreach (Assembly assembly in _projectAssemblies)
            //    LoadReferencedAssemblies(assembly, visitedAssemblies);

            _entityTypes = GetEntityTypes();
            _DTOTypes = GetDTOTypes();
        }

        public void Generate()
        {
            //GenerateNetControllerMethods();

            //GenerateAngularModules();

            //GenerateAngularListTs();
            //GenerateAngularListHtml();

            //GenerateAngularDetailsTs();
            //GenerateAngularDetailsHtml();
        }

        #region Assembly Load Helpers

        private List<Type> GetEntityTypes()
        {
            HashSet<Type> result = new HashSet<Type>();

            foreach (Assembly assembly in _projectAssemblies)
            {
                foreach (Type type in GetTypesSafely(assembly).Where(x => IsEntityType(x)))
                {
                    if (result.Contains(type) == false)
                        result.Add(type);
                }
            }

            return result.ToList();
        }

        private List<Type> GetDTOTypes()
        {
            HashSet<Type> result = new HashSet<Type>();

            foreach (Assembly assembly in _projectAssemblies)
            {
                foreach (Type type in GetTypesSafely(assembly).Where(x => IsDTOType(x)))
                {
                    if (result.Contains(type) == false)
                        result.Add(type);
                }
            }

            return result.ToList();
        }

        private void LoadReferencedAssemblies(Assembly assembly, HashSet<Assembly> visitedAssemblies)
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

        private List<Type> GetTypesSafely(Assembly assembly)
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

        private bool IsDTOType(Type type)
        {
            try
            {
                return type != null && type.IsClass && type.Namespace != null && type.Namespace.EndsWith($".{Settings.DTONamespaceEnding}");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool IsEntityType(Type type)
        {
            try
            {
                return type != null && type.IsClass && type.Namespace != null && type.Namespace.EndsWith($".{Settings.EntitiesNamespaceEnding}");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
