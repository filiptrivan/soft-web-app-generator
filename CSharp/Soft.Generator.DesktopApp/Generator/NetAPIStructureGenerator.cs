using Soft.Generator.DesktopApp.Generator.Models;
using Soft.Generator.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator
{
    public class NetAndAngularStructureGenerator
    {
        public void Generate(string outputPath, string projectName)
        {
            SoftFolder projectStructure = new SoftFolder
            {
                Name = projectName,
                ChildFolders = new List<SoftFolder>
                {
                    new SoftFolder 
                    {
                        Name = "Angular",
                        ChildFolders = new List<SoftFolder>
                        {
                            new SoftFolder
                            {
                                Name = "src",
                                ChildFolders = new List<SoftFolder>
                                {
                                    new SoftFolder
                                    {
                                        Name = "app",
                                        ChildFolders = new List<SoftFolder>
                                        {
                                            new SoftFolder
                                            {
                                                Name = "business",
                                                ChildFolders = new List<SoftFolder>
                                                {

                                                },
                                                SoftFiles = new List<SoftFile>
                                                {

                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "core",
                                                ChildFolders = new List<SoftFolder>
                                                {

                                                },
                                                SoftFiles = new List<SoftFile>
                                                {

                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "layout",
                                                ChildFolders = new List<SoftFolder>
                                                {

                                                },
                                                SoftFiles = new List<SoftFile>
                                                {

                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "modules",
                                                ChildFolders = new List<SoftFolder>
                                                {

                                                },
                                                SoftFiles = new List<SoftFile>
                                                {

                                                }
                                            },
                                        },
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "app.component.html", Data = GetAppComponentHtmlData() },
                                            new SoftFile { Name = "app.component.ts", Data = GetAppComponentTsData() },
                                            new SoftFile { Name = "app.config.ts", Data = GetAppConfigTsData() },
                                            new SoftFile { Name = "app.module.ts", Data = GetAppModuleTsData() },
                                            new SoftFile { Name = "app-routing.module.ts", Data = GetAppRoutingModuleTsData() },
                                            new SoftFile { Name = "transloco-root.module.ts", Data = GetTranslocoRootModuleTsData() },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "assets",
                                        ChildFolders = ,
                                        SoftFiles = new List<SoftFile>
                                        {

                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "environments",
                                        ChildFolders = ,
                                        SoftFiles = new List<SoftFile>
                                        {

                                        }
                                    }
                                },
                                SoftFiles = new List<SoftFile>
                                {
                                    new SoftFile { Name = "index.html", Data = GetIndexHtmlData() },
                                    new SoftFile { Name = "main.ts", Data = GetMainTsData() },
                                }
                            }
                        },
                        SoftFiles = new List<SoftFile>
                        {
                            new SoftFile { Name = ".editorconfig", Data = GetEditOrConfigData() },
                            new SoftFile { Name = "angular.json", Data = GetAngularJsonData() },
                            new SoftFile { Name = "package.json", Data = GetPackageData() },
                            new SoftFile { Name = "package-lock.json", Data = GetPackageLockData() },
                            new SoftFile { Name = "README.md", Data = null },
                            new SoftFile { Name = "tsconfig.app.json", Data = GetTsConfigAppJsonData() },
                            new SoftFile { Name = ".tsconfig.json", Data = GetTsConfigJsonData() },
                            new SoftFile { Name = ".tsconfig.spec.json", Data = GetTsConfigSpecJsonData() },
                            new SoftFile { Name = "vercel.json", Data = GetVercelJsonData() },
                        }
                    }
                },
                SoftFiles = new List<SoftFile>
                {
                    new SoftFile { Name = ".gitignore", Data = null },
                    new SoftFile { Name = "License", Data = null },
                }
            };

            string projectPath = Path.Combine(outputPath, projectName);

            MakeFolder(outputPath, "Angular");
            MakeFolder(outputPath, "API");
            MakeFolder(outputPath, "Data");
            MakeFolder(outputPath, "Documentation");

            MakeGitIgnoreFile(outputPath);
            MakeMitLicenseFile(outputPath);
            MakeFile(outputPath, ".gitignore");


        }
    }
}
