using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Generator;
using Soft.Generator.DesktopApp.Generator.Helpers;
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
        public List<string> _projectEntityNamespaces = new List<string>();
        public List<Assembly> _projectAssemblies = new List<Assembly>();
        public List<Type> _DTOTypes = new List<Type>();
        public List<Type> _entityTypes = new List<Type>();

        public GeneratorService(List<DllPath> dllPaths)
        {
            if (dllPaths == null)
                return;

            foreach (DllPath dllPath in dllPaths)
            {
                Assembly assembly = Assembly.LoadFrom(dllPath.Path);
                _projectAssemblies.Add(assembly);
            }

            HashSet<Assembly> visitedAssemblies = new HashSet<Assembly>();

            foreach (Assembly assembly in _projectAssemblies)
                Helper.LoadReferencedAssemblies(assembly, visitedAssemblies);

            _entityTypes = Helper.GetEntityTypes(_projectAssemblies);
            _DTOTypes = Helper.GetDTOTypes(_projectAssemblies);
        }

        public void GenerateNetAndAngularStructure(string outputPath, string appName, string primaryColor)
        {
            new NetAndAngularStructureGenerator().Generate(outputPath, appName, primaryColor);
        }

        public void GenerateBusinessFiles()
        {
            new NetControllerMethodsGenerator().Generate(_entityTypes);

            new AngularModulesGenerator().Generate(_entityTypes);

            new AngularTableTsGenerator().Generate(_entityTypes);
            new AngularTableHtmlGenerator().Generate(_entityTypes);

            new AngularDetailsTsGenerator().Generate(_entityTypes);
            new AngularDetailsHtmlGenerator().Generate(_entityTypes);
        }
    }
}
