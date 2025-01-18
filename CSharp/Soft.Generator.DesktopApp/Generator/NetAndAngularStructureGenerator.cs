using Soft.Generator.DesktopApp.Generator.Helpers;
using Soft.Generator.DesktopApp.Generator.Models;
using Soft.Generator.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseExtensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Soft.Generator.DesktopApp.Services;

namespace Soft.Generator.DesktopApp.Generator
{
    public class NetAndAngularStructureGenerator
    {
        public void Generate(string outputPath, string appName, string primaryColor)
        {
            SoftFolder appStructure = new SoftFolder
            {
                Name = appName,
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
                                                    new SoftFolder
                                                    {
                                                        Name = "components",
                                                        ChildFolders = new List<SoftFolder>
                                                        {
                                                            new SoftFolder
                                                            {
                                                                Name = "base-details",
                                                            },
                                                        }
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "entities",
                                                        SoftFiles = new List<SoftFile>
                                                        {
                                                            new SoftFile 
                                                            {
                                                                Name = "security-entities.generated.ts",
                                                                Data = GetSecurityEntitiesTsData(),
                                                            }
                                                        }
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "enums",
                                                        SoftFiles = new List<SoftFile>
                                                        {
                                                            new SoftFile
                                                            {
                                                                Name = "security-enums.generated.ts",
                                                                Data = GetSecurityEnumsTsData(),
                                                            }
                                                        }
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "guards",
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "interceptors",
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "services",
                                                        ChildFolders = new List<SoftFolder>
                                                        {
                                                            new SoftFolder
                                                            {
                                                                Name = "api",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "api.service.security.ts", Data = GetAPIServiceSecurityTsCode() },
                                                                    new SoftFile { Name = "api.service.ts", Data = GetAPIServiceTsCode() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "auth",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "auth.service.ts", Data = GetAuthServiceTsCode() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "helpers",
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "translates",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "merge-class-names.ts", Data = GetMergeClassNamesTsCode() },
                                                                    new SoftFile { Name = "merge-labels.ts", Data = GetMergeLabelsCode() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "validators",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "validation-rules.ts", Data = GetValidationRulesTsCode() },
                                                                }
                                                            },
                                                        },
                                                    },
                                                },
                                                SoftFiles = new List<SoftFile>
                                                {
                                                    new SoftFile { Name = "business.module.ts", Data = GetBusinessModuleTsData() }
                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "core", // FT: Copy
                                            },
                                            new SoftFolder
                                            {
                                                Name = "layout",
                                                ChildFolders = new List<SoftFolder>
                                                {
                                                    new SoftFolder
                                                    {
                                                        Name = "components",
                                                        ChildFolders =
                                                        {
                                                            new SoftFolder
                                                            {
                                                                Name = "auth",
                                                                ChildFolders =
                                                                {
                                                                    new SoftFolder
                                                                    {
                                                                        Name = "login",
                                                                        SoftFiles = new List<SoftFile>
                                                                        {
                                                                            new SoftFile { Name = "login.component.html", Data = GetLoginComponentHtmlData() },
                                                                            new SoftFile { Name = "login.component.ts", Data = GetLoginComponentTsData() },
                                                                        }
                                                                    },
                                                                    new SoftFolder
                                                                    {
                                                                        Name = "partials",
                                                                        SoftFiles = new List<SoftFile>
                                                                        {
                                                                            new SoftFile { Name = "auth.component.html", Data = GetAuthComponentHtmlData() },
                                                                            new SoftFile { Name = "auth.component.ts", Data = GetAuthComponentTsData() },
                                                                        }
                                                                    },
                                                                    new SoftFolder
                                                                    {
                                                                        Name = "registration",
                                                                        SoftFiles = new List<SoftFile>
                                                                        {
                                                                            new SoftFile { Name = "registration.component.html", Data = GetRegistrationComponentHtmlData() },
                                                                            new SoftFile { Name = "registration.component.ts", Data = GetRegistrationComponentTsData() },
                                                                        }
                                                                    },
                                                                },
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "auth.module.ts", Data = GetAuthModuleTsData() }
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "dashboard",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "dashboard-routing.module.ts", Data = GetDashboardRoutingModuleTsData() },
                                                                    new SoftFile { Name = "dashboard.component.html", Data = GetDashboardComponentHtmlData() },
                                                                    new SoftFile { Name = "dashboard.component.ts", Data = GetDashboardComponentTsData() },
                                                                    new SoftFile { Name = "dashboard.module.ts", Data = GetDashboardModuleTsData() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "layout",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "app.layout.component.html", Data = GetAppLayoutComponentHtmlData() },
                                                                    new SoftFile { Name = "app.layout.component.ts", Data = GetAppLayoutComponentTsData() },
                                                                    new SoftFile { Name = "app.layout.module.ts", Data = GetAppLayoutModuleTsData() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "sidebar",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "app.menu.component.html", Data = GetAppMenuComponentHtmlData() },
                                                                    new SoftFile { Name = "app.menu.component.ts", Data = GetAppMenuComponentTsData() },
                                                                    new SoftFile { Name = "app.menu.service.ts", Data = GetAppMenuServiceTsData() },
                                                                    new SoftFile { Name = "app.menuitem.component.html", Data = GetAppMenuItemComponentHtmlData() },
                                                                    new SoftFile { Name = "app.menuitem.component.ts", Data = GetAppMenuItemComponentTsData() },
                                                                    new SoftFile { Name = "app.sidebar.component.html", Data = GetAppSidebarComponentHtmlData() },
                                                                    new SoftFile { Name = "app.sidebar.component.ts", Data = GetAppSidebarComponentTsData() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "topbar",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "app.topbar.component.html", Data = GetAppTopbarComponentHtmlData() },
                                                                    new SoftFile { Name = "app.topbar.component.ts", Data = GetAppTopbarComponentTsData() },
                                                                }
                                                            },
                                                        },
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "services",
                                                        SoftFiles = new List<SoftFile>
                                                        {
                                                            new SoftFile { Name = "app.layout.service.ts", Data = GetAppLayoutServiceTsData() }
                                                        }
                                                    }
                                                },
                                            },
                                            new SoftFolder
                                            {
                                                Name = "modules",
                                            },
                                        },
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "app.component.html", Data = GetAppComponentHtmlData() },
                                            new SoftFile { Name = "app.component.ts", Data = GetAppComponentTsData() },
                                            new SoftFile { Name = "app.module.ts", Data = GetAppModuleTsData() },
                                            new SoftFile { Name = "app-routing.module.ts", Data = GetAppRoutingModuleTsData() },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "assets",
                                        ChildFolders = new List<SoftFolder>
                                        {
                                            new SoftFolder
                                            {
                                                Name = "i18n",
                                                SoftFiles = new List<SoftFile>
                                                {
                                                    new SoftFile { Name = "en.json", Data = GetTranslocoEnJsonCode() },
                                                    new SoftFile { Name = "sr-Latn-RS.json", Data = GetTranslocoSrLatnRSJsonCode() },
                                                    new SoftFile { Name = "en.generated.json", Data = "" },
                                                    new SoftFile { Name = "sr-Latn-RS.generated.json", Data = "" },
                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "primeng",
                                                ChildFolders = new List<SoftFolder>
                                                {
                                                    new SoftFolder
                                                    {
                                                        Name = "styles", // FT: Copy
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "images",
                                                        SoftFiles = new List<SoftFile>
                                                        {
                                                            new SoftFile { Name = "logo-dark.svg", Data = GetLogoDarkSvgData() }
                                                        }
                                                    }
                                                }
                                            },
                                        },
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "shared.scss", Data = GetSharedScssCode() },
                                            new SoftFile { Name = "styles.scss", Data = GetStylesScssCode() },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "environments",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "environment.prod.ts", Data = "" },
                                            new SoftFile { Name = "environment.ts", Data = GetEnvironmentTsCode(appName, primaryColor) },
                                        }
                                    }
                                },
                                SoftFiles = new List<SoftFile>
                                {
                                    new SoftFile { Name = "index.html", Data = GetIndexHtmlData(appName) },
                                    new SoftFile { Name = "main.ts", Data = GetMainTsData() },
                                }
                            }
                        },
                        SoftFiles = new List<SoftFile>
                        {
                            new SoftFile { Name = ".editorconfig", Data = GetEditOrConfigData() },
                            new SoftFile { Name = "angular.json", Data = GetAngularJsonData(appName) },
                            new SoftFile { Name = "package.json", Data = GetPackageData(appName) },
                            new SoftFile { Name = "README.md", Data = "" },
                            new SoftFile { Name = "tsconfig.app.json", Data = GetTsConfigAppJsonData() },
                            new SoftFile { Name = "tsconfig.json", Data = GetTsConfigJsonData() },
                            new SoftFile { Name = "tsconfig.spec.json", Data = GetTsConfigSpecJsonData() },
                            new SoftFile { Name = "vercel.json", Data = GetVercelJsonData() },
                        }
                    },
                    new SoftFolder
                    {
                        Name = "API",
                        ChildFolders = new List<SoftFolder>
                        {
                            new SoftFolder
                            {
                                Name = $"{appName}.Business",
                                ChildFolders = new List<SoftFolder>
                                {
                                    new SoftFolder
                                    {
                                        Name = "DataMappers",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "MapsterMapper.cs", Data = GetMapsterMapperCsData(appName) },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "DTO",
                                        ChildFolders = new List<SoftFolder>
                                        {
                                            new SoftFolder
                                            {
                                                Name = "Partials",
                                                SoftFiles = new List<SoftFile>
                                                {
                                                    new SoftFile { Name = "NotificationDTO.cs", Data = GetNotificationDTOCsData(appName) },
                                                    new SoftFile { Name = "NotificationSaveBodyDTO.cs", Data = GetNotificationSaveBodyDTOCsData(appName) },
                                                    new SoftFile { Name = "UserExtendedSaveBodyDTO.cs", Data = GetUserExtendedSaveBodyDTOCsData(appName) },
                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "Helpers"
                                            },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "Entities",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "Notification.cs", Data = GetNotificationCsData(appName) },
                                            new SoftFile { Name = "UserExtended.cs", Data = GetUserExtendedCsData(appName) },
                                            new SoftFile { Name = "UserNotification.cs", Data = GetUserNotificationCsData(appName) },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "Enums",
                                    },
                                    new SoftFolder
                                    {
                                        Name = "Services",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = $"{appName}BusinessService.cs", Data = GetBusinessServiceCsData(appName) },
                                            new SoftFile { Name = $"NotificationService.cs", Data = GetNotificationServiceCsData(appName) },
                                            new SoftFile { Name = $"AuthorizationBusinessService.cs", Data = GetAuthorizationServiceCsData(appName) },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "ValidationRules",
                                    },
                                },
                                SoftFiles = new List<SoftFile>
                                {
                                    new SoftFile { Name = "GeneratorSettings.cs", Data = GetBusinessGeneratorSettingsData(appName) },
                                    new SoftFile { Name = $"{appName}.Business.csproj", Data = GetBusinessCsProjData() },
                                    new SoftFile { Name = $"Settings.cs", Data = GetBusinessSettingsCsData(appName) },
                                }
                            },
                            new SoftFolder
                            {
                                Name = $"{appName}.Infrastructure",
                                SoftFiles = new List<SoftFile>
                                {
                                    new SoftFile { Name = $"{appName}ApplicationDbContext.cs", Data = GetInfrastructureApplicationDbContextData(appName) },
                                    new SoftFile { Name = "GeneratorSettings.cs", Data = GetInfrastructureGeneratorSettingsData(appName) },
                                    new SoftFile { Name = $"{appName}.Infrastructure.csproj", Data = GetInfrastructureCsProjData(appName) },
                                }
                            },
                            new SoftFolder
                            {
                                Name = $"{appName}.Shared",
                                ChildFolders = new List<SoftFolder>
                                {
                                    new SoftFolder
                                    {
                                        Name = "Terms",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "TermsGenerated.Designer.cs", Data = GetTermsGeneratedDesignerCsData(appName) },
                                            new SoftFile { Name = "TermsGenerated.resx", Data = GetTermsGeneratedResxData() },
                                            new SoftFile { Name = "TermsGenerated.sr-Latn-RS.cs", Data = GetTermsGeneratedSrLatnRSResxData() },
                                        }
                                    }
                                },
                                SoftFiles = new List<SoftFile>
                                {
                                    new SoftFile { Name = $"{appName}.Shared.csproj", Data = GetSharedCsProjData() },
                                }
                            },
                            new SoftFolder
                            {
                                Name = $"{appName}.WebAPI",
                                ChildFolders = new List<SoftFolder>
                                {
                                    new SoftFolder
                                    {
                                        Name = "Controllers",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "NotificationController.cs", Data = GetNotificationControllerCsData(appName) },
                                            new SoftFile { Name = "SecurityController.cs", Data = GetSecurityControllerCsData(appName) },
                                            new SoftFile { Name = "UserExtendedController.cs", Data = GetUserExtendedControllerCsData(appName) },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "DI",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "CompositionRoot.cs", Data = GetCompositionRootCsData(appName) },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "Helpers",
                                    },
                                    new SoftFolder
                                    {
                                        Name = "Properties",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "launchSettings.json", Data = GetLaunchSettingsJsonData() },
                                        }
                                    },
                                },
                                SoftFiles = new List<SoftFile>
                                {
                                    new SoftFile { Name = "appsettings.json", Data = GetAppSettingsJsonData(appName, null, null, null, null, null, null) }, // TODO FT: Add this to the app
                                    new SoftFile { Name = "GeneratorSettings.cs", Data = GetWebAPIGeneratorSettingsData(appName) },
                                    new SoftFile { Name = $"{appName}.WebAPI.csproj", Data = GetWebAPICsProjData(appName) },
                                    new SoftFile { Name = "Program.cs", Data = GetProgramCsData(appName) },
                                    new SoftFile { Name = "Settings.cs", Data = GetWebAPISettingsCsData(appName) },
                                    new SoftFile { Name = "Startup.cs", Data = GetStartupCsData(appName) },
                                }
                            },
                        },
                        SoftFiles = new List<SoftFile>
                        {
                            new SoftFile { Name = $"{appName}.sln", Data = GetNetSolutionData(appName) }
                        }
                    },
                    new SoftFolder
                    {
                        Name = "Data",
                        ChildFolders = new List<SoftFolder>
                        {
                            new SoftFolder
                            {
                                Name = "test-data"
                            },
                            new SoftFolder
                            {
                                Name = "update-scripts"
                            },
                        },
                        SoftFiles = new List<SoftFile>
                        {
                            new SoftFile { Name = "initialize-data.xlsx", Data = "" },
                            new SoftFile { Name = "initialize-script.sql", Data = "" }
                        }
                    },
                    new SoftFolder
                    {
                        Name = "Documentation",
                    }
                },
                SoftFiles = new List<SoftFile>
                {
                    new SoftFile { Name = ".gitignore", Data = "" },
                    new SoftFile { Name = "License", Data = "" },
                }
            };

            GenerateProjectStructure(appStructure, outputPath);
        }

        private string GetLogoDarkSvgData()
        {
            return $$"""
<svg width="85" height="63" viewBox="0 0 85 63" fill="none" xmlns="http://www.w3.org/2000/svg">
<path fill-rule="evenodd" clip-rule="evenodd" d="M27.017 30.3135C27.0057 30.5602 27 30.8085 27 31.0581C27 39.9267 34.1894 47.1161 43.0581 47.1161C51.9267 47.1161 59.1161 39.9267 59.1161 31.0581C59.1161 30.8026 59.1102 30.5485 59.0984 30.2959C60.699 30.0511 62.2954 29.7696 63.8864 29.4515L64.0532 29.4181C64.0949 29.9593 64.1161 30.5062 64.1161 31.0581C64.1161 42.6881 54.6881 52.1161 43.0581 52.1161C31.428 52.1161 22 42.6881 22 31.0581C22 30.514 22.0206 29.9747 22.0612 29.441L22.1136 29.4515C23.7428 29.7773 25.3777 30.0646 27.017 30.3135ZM52.4613 18.0397C49.8183 16.1273 46.5698 15 43.0581 15C39.54 15 36.2862 16.1313 33.6406 18.05C31.4938 17.834 29.3526 17.5435 27.221 17.1786C31.0806 12.7781 36.7449 10 43.0581 10C49.3629 10 55.0207 12.7708 58.8799 17.1612C56.7487 17.5285 54.6078 17.8214 52.4613 18.0397ZM68.9854 28.4316C69.0719 29.2954 69.1161 30.1716 69.1161 31.0581C69.1161 45.4495 57.4495 57.1161 43.0581 57.1161C28.6666 57.1161 17 45.4495 17 31.0581C17 30.1793 17.0435 29.3108 17.1284 28.4544L12.2051 27.4697C12.0696 28.6471 12 29.8444 12 31.0581C12 48.211 25.9052 62.1161 43.0581 62.1161C60.211 62.1161 74.1161 48.211 74.1161 31.0581C74.1161 29.8366 74.0456 28.6317 73.9085 27.447L68.9854 28.4316ZM69.6705 15.0372L64.3929 16.0927C59.6785 9.38418 51.8803 5 43.0581 5C34.2269 5 26.4218 9.39306 21.7089 16.1131L16.4331 15.0579C21.867 6.03506 31.7578 0 43.0581 0C54.3497 0 64.234 6.02581 69.6705 15.0372Z" fill="black"/>
<mask id="path-2-inside-1" fill="white">
<path d="M42.5 28.9252C16.5458 30.2312 0 14 0 14C0 14 26 22.9738 42.5 22.9738C59 22.9738 85 14 85 14C85 14 68.4542 27.6193 42.5 28.9252Z"/>
</mask>
<path d="M0 14L5.87269 -3.01504L-12.6052 26.8495L0 14ZM42.5 28.9252L41.5954 10.948L42.5 28.9252ZM85 14L96.4394 27.8975L79.1273 -3.01504L85 14ZM0 14C-12.6052 26.8495 -12.5999 26.8546 -12.5946 26.8598C-12.5928 26.8617 -12.5874 26.8669 -12.5837 26.8706C-12.5762 26.8779 -12.5685 26.8854 -12.5605 26.8932C-12.5445 26.9088 -12.5274 26.9254 -12.5092 26.943C-12.4729 26.9782 -12.4321 27.0174 -12.387 27.0605C-12.2969 27.1467 -12.1892 27.2484 -12.0642 27.3646C-11.8144 27.5968 -11.4949 27.8874 -11.1073 28.2273C-10.3332 28.9063 -9.28165 29.7873 -7.96614 30.7967C-5.34553 32.8073 -1.61454 35.3754 3.11693 37.872C12.5592 42.8544 26.4009 47.7581 43.4046 46.9025L41.5954 10.948C32.6449 11.3983 25.2366 8.83942 19.9174 6.03267C17.2682 4.63475 15.2406 3.22667 13.9478 2.23478C13.3066 1.74283 12.8627 1.366 12.6306 1.16243C12.5151 1.06107 12.4538 1.00422 12.4485 0.999363C12.446 0.996981 12.4576 1.00773 12.4836 1.03256C12.4966 1.04498 12.5132 1.06094 12.5334 1.08055C12.5436 1.09035 12.5546 1.10108 12.5665 1.11273C12.5725 1.11855 12.5787 1.12461 12.5852 1.13091C12.5884 1.13405 12.5934 1.13895 12.595 1.14052C12.6 1.14548 12.6052 1.15049 0 14ZM43.4046 46.9025C59.3275 46.1013 72.3155 41.5302 81.3171 37.1785C85.8337 34.9951 89.4176 32.8333 91.9552 31.151C93.2269 30.3079 94.2446 29.5794 94.9945 29.0205C95.3698 28.7409 95.6788 28.503 95.92 28.3138C96.0406 28.2192 96.1443 28.1366 96.2309 28.067C96.2742 28.0321 96.3133 28.0005 96.348 27.9723C96.3654 27.9581 96.3817 27.9448 96.3969 27.9323C96.4045 27.9261 96.4119 27.9201 96.419 27.9143C96.4225 27.9114 96.4276 27.9072 96.4294 27.9057C96.4344 27.9016 96.4394 27.8975 85 14C73.5606 0.102497 73.5655 0.0985097 73.5703 0.0945756C73.5718 0.0933319 73.5765 0.0894438 73.5795 0.0869551C73.5856 0.0819751 73.5914 0.077195 73.597 0.0726136C73.6082 0.0634509 73.6185 0.055082 73.6278 0.0474955C73.6465 0.0323231 73.6614 0.0202757 73.6726 0.0112606C73.695 -0.00676378 73.7026 -0.0126931 73.6957 -0.00726687C73.6818 0.00363418 73.6101 0.0596753 73.4822 0.154983C73.2258 0.346025 72.7482 0.691717 72.0631 1.14588C70.6873 2.05798 68.5127 3.38259 65.6485 4.7672C59.8887 7.55166 51.6267 10.4432 41.5954 10.948L43.4046 46.9025ZM85 14C79.1273 -3.01504 79.1288 -3.01557 79.1303 -3.01606C79.1306 -3.01618 79.1319 -3.01664 79.1326 -3.01688C79.134 -3.01736 79.135 -3.0177 79.1356 -3.01791C79.1369 -3.01834 79.1366 -3.01823 79.1347 -3.01759C79.131 -3.01633 79.1212 -3.01297 79.1055 -3.00758C79.0739 -2.99681 79.0185 -2.97794 78.9404 -2.95151C78.7839 -2.89864 78.5366 -2.81564 78.207 -2.7068C77.5472 -2.48895 76.561 -2.16874 75.3165 -1.78027C72.8181 -1.00046 69.3266 0.039393 65.3753 1.07466C57.0052 3.26771 48.2826 4.97383 42.5 4.97383V40.9738C53.2174 40.9738 65.7448 38.193 74.4997 35.8992C79.1109 34.691 83.1506 33.4874 86.0429 32.5846C87.4937 32.1318 88.6676 31.7509 89.4942 31.478C89.9077 31.3414 90.2351 31.2317 90.4676 31.1531C90.5839 31.1138 90.6765 31.0823 90.7443 31.0591C90.7783 31.0475 90.806 31.038 90.8275 31.0306C90.8382 31.0269 90.8473 31.0238 90.8549 31.0212C90.8586 31.0199 90.862 31.0187 90.865 31.0177C90.8665 31.0172 90.8684 31.0165 90.8691 31.0163C90.871 31.0156 90.8727 31.015 85 14ZM42.5 4.97383C36.7174 4.97383 27.9948 3.26771 19.6247 1.07466C15.6734 0.039393 12.1819 -1.00046 9.68352 -1.78027C8.43897 -2.16874 7.4528 -2.48895 6.79299 -2.7068C6.46337 -2.81564 6.21607 -2.89864 6.05965 -2.95151C5.98146 -2.97794 5.92606 -2.99681 5.89453 -3.00758C5.87876 -3.01297 5.86897 -3.01633 5.86528 -3.01759C5.86344 -3.01823 5.86312 -3.01834 5.86435 -3.01791C5.86497 -3.0177 5.86597 -3.01736 5.86736 -3.01688C5.86805 -3.01664 5.86939 -3.01618 5.86973 -3.01606C5.87116 -3.01557 5.87269 -3.01504 0 14C-5.87269 31.015 -5.87096 31.0156 -5.86914 31.0163C-5.8684 31.0165 -5.86647 31.0172 -5.86498 31.0177C-5.86201 31.0187 -5.85864 31.0199 -5.85486 31.0212C-5.84732 31.0238 -5.83818 31.0269 -5.82747 31.0306C-5.80603 31.038 -5.77828 31.0475 -5.74435 31.0591C-5.67649 31.0823 -5.58388 31.1138 -5.46761 31.1531C-5.23512 31.2317 -4.9077 31.3414 -4.49416 31.478C-3.66764 31.7509 -2.49366 32.1318 -1.04289 32.5846C1.84938 33.4874 5.88908 34.691 10.5003 35.8992C19.2552 38.193 31.7826 40.9738 42.5 40.9738V4.97383Z" fill="black" mask="url(#path-2-inside-1)"/>
</svg>
""";
        }

        private string GetAuthServiceTsCode()
        {
            return $$"""
import { Injectable, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, firstValueFrom, Observable, of, Subject, Subscription } from 'rxjs';
import { map, tap, delay, finalize } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';
import { ApiService } from 'src/app/business/services/api/api.service';
import { SocialUser, SocialAuthService } from '@abacritt/angularx-social-login';
import { ExternalProvider, Login, VerificationTokenRequest, AuthResult, Registration, RegistrationVerificationResult, RefreshTokenRequest } from 'src/app/business/entities/security-entities.generated';
import { UserExtended } from 'src/app/business/entities/business-entities.generated';

@Injectable({
  providedIn: 'root',
})
export class AuthService implements OnDestroy {
  private readonly apiUrl = environment.apiUrl;
  private timer?: Subscription;

  private _user = new BehaviorSubject<UserExtended | null>(null);
  user$ = this._user.asObservable();

  private _currentUserPermissions = new BehaviorSubject<string[] | null>(null);
  currentUserPermissions$ = this._currentUserPermissions.asObservable();

  // Google auth
  private authChangeSub = new Subject<boolean>();
  private extAuthChangeSub = new Subject<SocialUser>();
  public authChanged = this.authChangeSub.asObservable();
  public extAuthChanged = this.extAuthChangeSub.asObservable();

  constructor(
    private router: Router,
    private http: HttpClient,
    private externalAuthService: SocialAuthService,
    private apiService: ApiService,
  ) {
    window.addEventListener('storage', this.storageEventListener.bind(this));

    // Google auth
    this.externalAuthService.authState.subscribe((user) => {
      const externalAuth: ExternalProvider = {
        // provider: user.provider,
        idToken: user.idToken
      }
      this.loginExternal(externalAuth).subscribe(() => {
        this.navigateToDashboard();
      });
      this.extAuthChangeSub.next(user);
    });
  }

  private storageEventListener(event: StorageEvent) {
    if (event.storageArea === localStorage) {
      if (event.key === 'logout-event') {
        this.stopTokenTimer();
        this._user.next(null);
        this._currentUserPermissions.next(null);
      }
      if (event.key === 'login-event') {
        this.stopTokenTimer();

        this.apiService.getCurrentUser().subscribe(async (user: UserExtended) => {
            this._user.next({
              id: user.id,
              email: user.email
            });
            await firstValueFrom(this.getCurrentUserPermissions()); // FT: Needs to be after setting local storage
          });
      }
    }
  }

  sendLoginVerificationEmail(body: Login): Observable<any> {
    const browserId = this.getBrowserId();
    body.browserId = browserId;
    return this.apiService.sendLoginVerificationEmail(body);
  }

  login(body: VerificationTokenRequest): Observable<Promise<AuthResult>> {
    const browserId = this.getBrowserId();
    body.browserId = browserId;
    const loginResultObservable = this.http.post<AuthResult>(`${this.apiUrl}/Security/Login`, body);
    return this.handleLoginResult(loginResultObservable);
  }

  loginExternal(body: ExternalProvider): Observable<Promise<AuthResult>> {
    const browserId = this.getBrowserId();
    body.browserId = browserId;
    const loginResultObservable = this.http.post<AuthResult>(`${this.apiUrl}/Security/LoginExternal`, body);
    return this.handleLoginResult(loginResultObservable);
  }

  sendRegistrationVerificationEmail(body: Registration): Observable<RegistrationVerificationResult> {
    const browserId = this.getBrowserId();
    body.browserId = browserId;
    return this.apiService.sendRegistrationVerificationEmail(body);
  }

  register(body: VerificationTokenRequest): Observable<Promise<AuthResult>> {
    const browserId = this.getBrowserId();
    body.browserId = browserId;
    const loginResultObservable = this.apiService.register(body);
    return this.handleLoginResult(loginResultObservable);
  }

  handleLoginResult(loginResultObservable: Observable<AuthResult>){
    return loginResultObservable.pipe(
      map(async (loginResult: AuthResult) => {
        this._user.next({
          id: loginResult.userId,
          email: loginResult.email,
        });
        this.setLocalStorage(loginResult);
        this.startTokenTimer();
        await firstValueFrom(this.getCurrentUserPermissions()); // FT: Needs to be after setting local storage
        return loginResult;
      })
    );
  }

  logout() {
    const browserId = this.getBrowserId();
    this.http
      .get(`${this.apiUrl}/Security/Logout?browserId=${browserId}`)
      .pipe(
        finalize(() => {
          this.clearLocalStorage();
          this._user.next(null);
          this._currentUserPermissions.next(null);
          this.stopTokenTimer();
          this.router.navigate([environment.loginSlug]);
        })
      )
      .subscribe();
  }

  refreshToken(): Observable<Promise<AuthResult> | null> {
    let refreshToken = localStorage.getItem(environment.refreshTokenKey);

    if (!refreshToken) {
      this.clearLocalStorage();
      return of(null);
    }

    const browserId = this.getBrowserId();
    let body: RefreshTokenRequest = new RefreshTokenRequest();
    body.browserId = browserId;
    body.refreshToken = refreshToken;
    return this.http
    .post<AuthResult>(`${this.apiUrl}/Security/RefreshToken`, body, environment.httpSkipSpinnerOptions)
    .pipe(
      map(async (loginResult) => {
        this._user.next({
          id: loginResult.userId,
          email: loginResult.email
        });
        this.setLocalStorage(loginResult);
        this.startTokenTimer();
        await firstValueFrom(this.getCurrentUserPermissions()); // FT: Needs to be after setting local storage
        return loginResult;
      })
    );
  }

  setLocalStorage(loginResult: AuthResult) {
    localStorage.setItem(environment.accessTokenKey, loginResult.accessToken);
    localStorage.setItem(environment.refreshTokenKey, loginResult.refreshToken);
    localStorage.setItem('login-event', 'login' + Math.random());
  }

  clearLocalStorage() {
    localStorage.removeItem(environment.accessTokenKey);
    localStorage.removeItem(environment.refreshTokenKey);
    localStorage.setItem('logout-event', 'logout' + Math.random());
  }

  getBrowserId() {
    let browserId = localStorage.getItem(environment.browserIdKey); // FT: We don't need to remove this from the local storage ever, only if the user manuely deletes it, we will handle it
    if (!browserId) {
      browserId = crypto.randomUUID();
      localStorage.setItem(environment.browserIdKey, browserId);
    }
    return browserId;
  }

  isAccessTokenExpired(): Observable<boolean> {
    const expired = this.getTokenRemainingTime() < 5000;
    return of(expired);
  }

  getTokenRemainingTime() {
    const accessToken = localStorage.getItem(environment.accessTokenKey);
    if (!accessToken) {
      return 0;
    }
    const jwtToken = JSON.parse(atob(accessToken.split('.')[1]));
    const expires = new Date(jwtToken.exp * 1000);
    return expires.getTime() - Date.now();
  }

  private startTokenTimer() {
    const timeout = this.getTokenRemainingTime();
    this.timer = of(true)
      .pipe(
        delay(timeout),
        tap({
          next: () => this.refreshToken().subscribe(),
        })
      )
      .subscribe();
  }

  private stopTokenTimer() {
    this.timer?.unsubscribe();
  }

  navigateToDashboard(){
    this.router.navigate(['/']);
  }

  logoutGoogle = () => {
    this.externalAuthService.signOut();
  }

  getCurrentUserPermissions(): Observable<string[]> {
    return this.apiService.getCurrentUserPermissionCodes().pipe(
      map(permissionCodes => {
        this._currentUserPermissions.next(permissionCodes);
        return permissionCodes;
      }
    ));
  }

  ngOnDestroy(): void {
    window.removeEventListener('storage', this.storageEventListener.bind(this));
  }
}

""";
        }

        private string GetSecurityEnumsTsData()
        {
            return $$"""
export enum LoginVerificationResultStatusCodes
{

}

export enum RegistrationVerificationResultStatusCodes
{
    UserDoesNotExistAndDoesNotHaveValidToken = 0,
	UserWithoutPasswordExists = 1,
	UserWithPasswordExists = 2,
	UnexpectedError = 3,
}
""";
        }

        private string GetSecurityEntitiesTsData()
        {
            return $$"""
import { BaseEntity } from "src/app/core/entities/base-entity";
import { TableFilter } from "src/app/core/entities/table-filter";
import { TableFilterContext } from "src/app/core/entities/table-filter-context";
import { TableFilterSortMeta } from "src/app/core/entities/table-filter-sort-meta";
import { MimeTypes } from "src/app/core/entities/mime-type";
import { RegistrationVerificationResultStatusCodes } from "../enums/security-enums.generated";


export class JwtAuthResult extends BaseEntity
{
    userId?: number;
	userEmail?: string;
	accessToken?: string;
	token?: RefreshToken;

    constructor(
    {
        userId,
		userEmail,
		accessToken,
		token
    }:{
        userId?: number;
		userEmail?: string;
		accessToken?: string;
		token?: RefreshToken;     
    } = {}
    ) {
        super('JwtAuthResult'); 

        this.userId = userId;
		this.userEmail = userEmail;
		this.accessToken = accessToken;
		this.token = token;
    }
}


export class RolePermission extends BaseEntity
{
    roleDisplayName?: string;
	roleId?: number;
	permissionDisplayName?: string;
	permissionId?: number;

    constructor(
    {
        roleDisplayName,
		roleId,
		permissionDisplayName,
		permissionId
    }:{
        roleDisplayName?: string;
		roleId?: number;
		permissionDisplayName?: string;
		permissionId?: number;     
    } = {}
    ) {
        super('RolePermission'); 

        this.roleDisplayName = roleDisplayName;
		this.roleId = roleId;
		this.permissionDisplayName = permissionDisplayName;
		this.permissionId = permissionId;
    }
}


export class RolePermissionSaveBody extends BaseEntity
{
    rolePermissionDTO?: RolePermission;

    constructor(
    {
        rolePermissionDTO
    }:{
        rolePermissionDTO?: RolePermission;     
    } = {}
    ) {
        super('RolePermissionSaveBody'); 

        this.rolePermissionDTO = rolePermissionDTO;
    }
}


export class AuthResult extends BaseEntity
{
    userId?: number;
	email?: string;
	accessToken?: string;
	refreshToken?: string;

    constructor(
    {
        userId,
		email,
		accessToken,
		refreshToken
    }:{
        userId?: number;
		email?: string;
		accessToken?: string;
		refreshToken?: string;     
    } = {}
    ) {
        super('AuthResult'); 

        this.userId = userId;
		this.email = email;
		this.accessToken = accessToken;
		this.refreshToken = refreshToken;
    }
}


export class VerificationTokenRequest extends BaseEntity
{
    verificationCode?: string;
	browserId?: string;
	email?: string;

    constructor(
    {
        verificationCode,
		browserId,
		email
    }:{
        verificationCode?: string;
		browserId?: string;
		email?: string;     
    } = {}
    ) {
        super('VerificationTokenRequest'); 

        this.verificationCode = verificationCode;
		this.browserId = browserId;
		this.email = email;
    }
}


export class RegistrationVerificationResult extends BaseEntity
{
    status?: RegistrationVerificationResultStatusCodes;
	message?: string;

    constructor(
    {
        status,
		message
    }:{
        status?: RegistrationVerificationResultStatusCodes;
		message?: string;     
    } = {}
    ) {
        super('RegistrationVerificationResult'); 

        this.status = status;
		this.message = message;
    }
}


export class RegistrationVerificationToken extends BaseEntity
{
    email?: string;
	browserId?: string;
	expireAt?: Date;

    constructor(
    {
        email,
		browserId,
		expireAt
    }:{
        email?: string;
		browserId?: string;
		expireAt?: Date;     
    } = {}
    ) {
        super('RegistrationVerificationToken'); 

        this.email = email;
		this.browserId = browserId;
		this.expireAt = expireAt;
    }
}


export class ExternalProvider extends BaseEntity
{
    idToken?: string;
	browserId?: string;

    constructor(
    {
        idToken,
		browserId
    }:{
        idToken?: string;
		browserId?: string;     
    } = {}
    ) {
        super('ExternalProvider'); 

        this.idToken = idToken;
		this.browserId = browserId;
    }
}


export class UserRole extends BaseEntity
{
    roleId?: number;
	userId?: number;

    constructor(
    {
        roleId,
		userId
    }:{
        roleId?: number;
		userId?: number;     
    } = {}
    ) {
        super('UserRole'); 

        this.roleId = roleId;
		this.userId = userId;
    }
}


export class UserRoleSaveBody extends BaseEntity
{
    userRoleDTO?: UserRole;

    constructor(
    {
        userRoleDTO
    }:{
        userRoleDTO?: UserRole;     
    } = {}
    ) {
        super('UserRoleSaveBody'); 

        this.userRoleDTO = userRoleDTO;
    }
}


export class LoginVerificationToken extends BaseEntity
{
    email?: string;
	userId?: number;
	browserId?: string;
	expireAt?: Date;

    constructor(
    {
        email,
		userId,
		browserId,
		expireAt
    }:{
        email?: string;
		userId?: number;
		browserId?: string;
		expireAt?: Date;     
    } = {}
    ) {
        super('LoginVerificationToken'); 

        this.email = email;
		this.userId = userId;
		this.browserId = browserId;
		this.expireAt = expireAt;
    }
}


export class Login extends BaseEntity
{
    email?: string;
	browserId?: string;

    constructor(
    {
        email,
		browserId
    }:{
        email?: string;
		browserId?: string;     
    } = {}
    ) {
        super('Login'); 

        this.email = email;
		this.browserId = browserId;
    }
}


export class RefreshTokenRequest extends BaseEntity
{
    refreshToken?: string;
	browserId?: string;

    constructor(
    {
        refreshToken,
		browserId
    }:{
        refreshToken?: string;
		browserId?: string;     
    } = {}
    ) {
        super('RefreshTokenRequest'); 

        this.refreshToken = refreshToken;
		this.browserId = browserId;
    }
}


export class Registration extends BaseEntity
{
    email?: string;
	browserId?: string;

    constructor(
    {
        email,
		browserId
    }:{
        email?: string;
		browserId?: string;     
    } = {}
    ) {
        super('Registration'); 

        this.email = email;
		this.browserId = browserId;
    }
}


export class Role extends BaseEntity
{
    name?: string;
	description?: string;
	version?: number;
	id?: number;
	createdAt?: Date;
	modifiedAt?: Date;

    constructor(
    {
        name,
		description,
		version,
		id,
		createdAt,
		modifiedAt
    }:{
        name?: string;
		description?: string;
		version?: number;
		id?: number;
		createdAt?: Date;
		modifiedAt?: Date;     
    } = {}
    ) {
        super('Role'); 

        this.name = name;
		this.description = description;
		this.version = version;
		this.id = id;
		this.createdAt = createdAt;
		this.modifiedAt = modifiedAt;
    }
}


export class RoleSaveBody extends BaseEntity
{
    roleDTO?: Role;
	selectedPermissionIds?: number[];
	selectedUserIds?: number[];

    constructor(
    {
        roleDTO,
		selectedPermissionIds,
		selectedUserIds
    }:{
        roleDTO?: Role;
		selectedPermissionIds?: number[];
		selectedUserIds?: number[];     
    } = {}
    ) {
        super('RoleSaveBody'); 

        this.roleDTO = roleDTO;
		this.selectedPermissionIds = selectedPermissionIds;
		this.selectedUserIds = selectedUserIds;
    }
}


export class RefreshToken extends BaseEntity
{
    email?: string;
	ipAddress?: string;
	browserId?: string;
	tokenString?: string;
	expireAt?: Date;

    constructor(
    {
        email,
		ipAddress,
		browserId,
		tokenString,
		expireAt
    }:{
        email?: string;
		ipAddress?: string;
		browserId?: string;
		tokenString?: string;
		expireAt?: Date;     
    } = {}
    ) {
        super('RefreshToken'); 

        this.email = email;
		this.ipAddress = ipAddress;
		this.browserId = browserId;
		this.tokenString = tokenString;
		this.expireAt = expireAt;
    }
}


export class Permission extends BaseEntity
{
    name?: string;
	nameLatin?: string;
	description?: string;
	descriptionLatin?: string;
	code?: string;
	id?: number;

    constructor(
    {
        name,
		nameLatin,
		description,
		descriptionLatin,
		code,
		id
    }:{
        name?: string;
		nameLatin?: string;
		description?: string;
		descriptionLatin?: string;
		code?: string;
		id?: number;     
    } = {}
    ) {
        super('Permission'); 

        this.name = name;
		this.nameLatin = nameLatin;
		this.description = description;
		this.descriptionLatin = descriptionLatin;
		this.code = code;
		this.id = id;
    }
}


export class PermissionSaveBody extends BaseEntity
{
    permissionDTO?: Permission;

    constructor(
    {
        permissionDTO
    }:{
        permissionDTO?: Permission;     
    } = {}
    ) {
        super('PermissionSaveBody'); 

        this.permissionDTO = permissionDTO;
    }
}


""";
        }

        private string GetNotificationControllerCsData(string appName)
        {
            return $$"""
using Microsoft.AspNetCore.Mvc;
using Soft.Generator.Shared.Attributes;
using Soft.Generator.Shared.Interfaces;
using Azure.Storage.Blobs;
using {{appName}}.Business.Services;

namespace {{appName}}.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class NotificationController : NotificationBaseController
    {
        private readonly IApplicationDbContext _context;
        private readonly {{Settings.BaseBusinessServiceName}}BusinessService _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;

        public NotificationController(IApplicationDbContext context, {{Settings.BaseBusinessServiceName}}BusinessService {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService, BlobContainerClient blobContainerClient)
            : base(context, {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService, blobContainerClient)
        {
            _context = context;
            _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService = {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;
        }

        [HttpGet]
        [AuthGuard]
        public async Task SendNotificationEmail(long notificationId, int notificationVersion)
        {
            await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.SendNotificationEmail(notificationId, notificationVersion);
        }

        [HttpDelete]
        [AuthGuard]
        public async Task DeleteNotificationForCurrentUser(long notificationId, int notificationVersion)
        {
            await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.DeleteNotificationForCurrentUser(notificationId, notificationVersion);
        }

        [HttpGet]
        [AuthGuard]
        public async Task MarkNotificationAsReadForCurrentUser(long notificationId, int notificationVersion)
        {
            await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.MarkNotificationAsReadForCurrentUser(notificationId, notificationVersion);
        }

        [HttpGet]
        [AuthGuard]
        public async Task MarkNotificationAsUnreadForCurrentUser(long notificationId, int notificationVersion)
        {
            await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.MarkNotificationAsUnreadForCurrentUser(notificationId, notificationVersion);
        }

        //[HttpPost]
        //[AuthGuard]
        //public async Task<TableResponseDTO<NotificationDTO>> GetNotificationListForCurrentUser(TableFilterDTO tableFilterDTO)
        //{
        //    return await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.GetNotificationListForCurrentUser(tableFilterDTO);
        //}

        // TODO FT: This should exist in other systems
        //[HttpGet]
        //[AuthGuard]
        //public async Task<int> GetUnreadNotificationCountForTheCurrentUser()
        //{
        //    return await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.GetUnreGetUnreadNotificationCountForTheCurrentUser();
        //}

    }
}

""";
        }

        private string GetSecurityControllerCsData(string appName)
        {
            return $$"""
using Microsoft.AspNetCore.Mvc;
using Soft.Generator.Security.Interface;
using Soft.Generator.Security.Services;
using Soft.Generator.Security.SecurityControllers;
using Soft.Generator.Shared.Interfaces;
using Soft.Generator.Shared.Attributes;
using Soft.Generator.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Soft.Generator.Shared.Terms;
using Soft.Generator.Security.DTO;
using Soft.Generator.Shared.Extensions;
using {{appName}}.Business.Entities;
using {{appName}}.Business.Services;
using {{appName}}.Business.DTO;

namespace {{appName}}.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class SecurityController : SecurityBaseController<UserExtended>
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly SecurityBusinessService<UserExtended> _securityBusinessService;
        private readonly IJwtAuthManager _jwtAuthManagerService;
        private readonly IApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;
        private readonly {{Settings.BaseBusinessServiceName}}BusinessService _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;


        public SecurityController(ILogger<SecurityController> logger, SecurityBusinessService<UserExtended> securityBusinessService, IJwtAuthManager jwtAuthManagerService, IApplicationDbContext context, AuthenticationService authenticationService,
            {{Settings.BaseBusinessServiceName}}BusinessService {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService)
            : base(securityBusinessService, jwtAuthManagerService, context, authenticationService)
        {
            _logger = logger;
            _securityBusinessService = securityBusinessService;
            _jwtAuthManagerService = jwtAuthManagerService;
            _context = context;
            _authenticationService = authenticationService;
            _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService = {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;
        }

        /// <summary>
        /// FT: Put the method here, if something needs to be done after the operation from the security service
        /// </summary>
        [HttpPost]
        public async Task<AuthResultDTO> Register(VerificationTokenRequestDTO request)
        {
            return await _context.WithTransactionAsync(async () =>
            {
                AuthResultDTO authResultDTO = await _securityBusinessService.Register(request);
                return authResultDTO;
            });
        }

        /// <summary>
        /// FT: Put the method here, if something needs to be done after the operation from the security service
        /// </summary
        [HttpPost]
        public async Task<AuthResultDTO> Login(VerificationTokenRequestDTO request)
        {
            AuthResultDTO authResultDTO = _securityBusinessService.Login(request);
            return authResultDTO;
        }

        /// <summary>
        /// FT: Put the method here, if something needs to be done after the operation from the security service
        /// </summary>
        [HttpPost]
        public async Task<AuthResultDTO> LoginExternal(ExternalProviderDTO externalProviderDTO) // TODO FT: Add enum for which external provider you should login user
        {
            return await _context.WithTransactionAsync(async () =>
            {
                AuthResultDTO authResultDTO = await _securityBusinessService.LoginExternal(externalProviderDTO, SettingsProvider.Current.GoogleClientId);
                return authResultDTO;
            });
        }

    }
}

""";
        }

        private string GetUserExtendedControllerCsData(string appName)
        {
            return $$"""
using Microsoft.AspNetCore.Mvc;
using Soft.Generator.Shared.Attributes;
using Soft.Generator.Shared.Interfaces;
using Azure.Storage.Blobs;
using Soft.Generator.Shared.DTO;
using Soft.Generator.Shared.Terms;
using Soft.Generator.Security.Services;
using {{appName}}.Business.Services;
using {{appName}}.Business.DTO;
using {{appName}}.Business.Entities;

namespace {{appName}}.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class UserExtendedController : UserExtendedBaseController
    {
        private readonly IApplicationDbContext _context;
        private readonly {{Settings.BaseBusinessServiceName}}BusinessService _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;
        private readonly AuthenticationService _authenticationService;

        public UserExtendedController(IApplicationDbContext context, {{Settings.BaseBusinessServiceName}}BusinessService {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService, BlobContainerClient blobContainerClient, AuthenticationService authenticationService)
            : base(context, {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService, blobContainerClient)
        {
            _context = context;
            _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService = {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [AuthGuard]
        [SkipSpinner]
        public async Task<UserExtendedDTO> GetCurrentUser()
        {
            long userId = _authenticationService.GetCurrentUserId();
            return await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.GetUserExtendedDTOAsync(userId);
        }

        [HttpGet]
        [AuthGuard]
        [SkipSpinner]
        public async Task<List<string>> GetCurrentUserPermissionCodes()
        {
            return await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.GetCurrentUserPermissionCodes(); // FT: Not authorizing because we are reading this from the jwt token
        }

    }
}

""";
        }

        private void GenerateProjectStructure(SoftFolder appStructure, string path)
        {
            string newPath = GenerateFolder(appStructure, path);

            foreach (SoftFile file in appStructure.SoftFiles)
                GenerateFile(appStructure, file, newPath);

            foreach (SoftFolder folder in appStructure.ChildFolders)
                GenerateProjectStructure(folder, newPath);
        }

        private string GenerateFolder(SoftFolder appStructure, string path)
        {
            if (appStructure.Name == "core")
            {
                string sourcePath = Settings.GeneralCoreFrontendPath;
                string destinationPath = path.Replace("core", "");

                Helper.CopyFolder(sourcePath, destinationPath, "core");
            }
            else if (appStructure.Name == "styles")
            {
                string sourcePath = Settings.GeneralStylesFrontendPath;
                string destinationPath = path.Replace("styles", "");

                Helper.CopyFolder(sourcePath, destinationPath, "styles");
            }
            else
            {
                Helper.MakeFolder(path, appStructure.Name);
            }

            return Path.Combine(path, appStructure.Name);
        }

        private void GenerateFile(SoftFolder parentFolder, SoftFile file, string path)
        {
            string filePath = Path.Combine(path, file.Name);

            Helper.FileOverrideCheck(filePath);

            Helper.WriteToTheFile(file.Data, filePath);
        }

        #region NET

        private string GetTermsGeneratedDesignerCsData(string appName)
        {
            return $$"""
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace {{appName}}.Shared.Terms {
    using System;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class TermsGenerated {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TermsGenerated() {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("{{appName}}.Shared.Terms.TermsGenerated", typeof(TermsGenerated).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

    }
}
""";
        }

        private string GetTermsGeneratedResxData()
        {
            return $$"""
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>

</root>
""";
        }

        private string GetTermsGeneratedSrLatnRSResxData()
        {
            return $$"""
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>

</root>
""";
        }

        private string GetUserNotificationCsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes.EF;

namespace {{appName}}.Business.Entities
{
    public class UserNotification 
    {
        [M2MMaintanceEntity(nameof(Notification.Recipients))]
        public virtual Notification Notification { get; set; }

        [M2MExtendEntity(nameof(User.Notifications))]
        public virtual UserExtended User { get; set; }

        public bool IsMarkedAsRead { get; set; }
    }
}
""";
        }

        private string GetUserExtendedCsData(string appName)
        {
            return $$"""
using Microsoft.EntityFrameworkCore;
using Soft.Generator.Security.Entities;
using Soft.Generator.Security.Interface;
using Soft.Generator.Shared.Attributes;
using Soft.Generator.Shared.Attributes.EF;
using Soft.Generator.Shared.Attributes.EF.Translation;
using Soft.Generator.Shared.Attributes.EF.UI;
using Soft.Generator.Shared.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace {{appName}}.Business.Entities
{
    [UIDoNotGenerate]
    [TranslateSingularSrLatnRS("Korisnik")]
    [Index(nameof(Email), IsUnique = true)]
    public class UserExtended : BusinessObject<long>, IUser
    {
        [TranslateSingularSrLatnRS("Email")]
        [SoftDisplayName]
        [CustomValidator("EmailAddress()")]
        [StringLength(70, MinimumLength = 5)]
        [Required]
        public string Email { get; set; }

        public bool? HasLoggedInWithExternalProvider { get; set; }

        public bool? IsDisabled { get; set; }

        public virtual List<Role> Roles { get; } = new(); // M2M

        public virtual List<Notification> Notifications { get; } = new(); // M2M
    }
}
""";
        }

        private string GetNotificationCsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes.EF;
using Soft.Generator.Shared.Attributes.EF.UI;
using Soft.Generator.Shared.BaseEntities;
using Soft.Generator.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using Soft.Generator.Shared.Interfaces;
using {{appName}}.Business.DTO;

namespace {{appName}}.Business.Entities
{
    public class Notification : BusinessObject<long>, INotification<UserExtended>
    {
        [UIColWidth("col-12")]
        [SoftDisplayName]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [UIControlType(nameof(UIControlTypeCodes.TextArea))]
        [StringLength(400, MinimumLength = 1)]
        [Required]
        public string Description { get; set; }

        [UIControlType(nameof(UIControlTypeCodes.Editor))]
        [StringLength(1000, MinimumLength = 1)]
        public string EmailBody { get; set; }

        #region UIColumn
        [UIColumn(nameof(UserExtendedDTO.Email))]
        [UIColumn(nameof(UserExtendedDTO.CreatedAt))]
        #endregion
        [SimpleManyToManyTableLazyLoad]
        public virtual List<UserExtended> Recipients { get; } = new(); // M2M
    }
}
""";
        }

        private string GetNotificationSaveBodyDTOCsData(string appName)
        {
            return $$"""
namespace {{appName}}.Business.DTO
{
    public partial class NotificationSaveBodyDTO
    {
        public bool IsMarkedAsRead { get; set; }
    }
}
""";
        }

        private string GetUserExtendedSaveBodyDTOCsData(string appName)
        {
            return $$"""
namespace {{appName}}.Business.DTO
{
    
    public partial class UserExtendedSaveBodyDTO
    {
        /// <summary>
        /// Needs to have it here, because in generated business service, we don't have reference to the security service
        /// </summary>
        public List<int> SelectedRolesIds { get; set; }
    }
}
""";
        }

        private string GetNotificationDTOCsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes.EF.UI;

namespace {{appName}}.Business.DTO
{
    public partial class NotificationDTO
    {
        /// <summary>
        /// This property is only for currently logged in user
        /// </summary>
        [UIDoNotGenerate]
        public bool? IsMarkedAsRead { get; set; }
    }
}
""";
        }

        private string GetInfrastructureApplicationDbContextData(string appName)
        {
            return $$"""
using Microsoft.EntityFrameworkCore;
using {{appName}}.Business.Entities;
using Soft.Generator.Infrastructure;

namespace {{appName}}.Infrastructure
{
    public partial class {{appName}}ApplicationDbContext : ApplicationDbContext<UserExtended> // https://stackoverflow.com/questions/41829229/how-do-i-implement-dbcontext-inheritance-for-multiple-databases-in-ef7-net-co
    {
        public {{appName}}ApplicationDbContext(DbContextOptions<{{appName}}ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
""";
        }

        private string GetNetSolutionData(string appName)
        {
            return $$"""
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.8.34525.116
MinimumVisualStudioVersion = 10.0.40219.1
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "Nuget", "Nuget", "{D485BCE8-A950-457D-A710-566D559BD585}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "{{appName}}.WebAPI", "{{appName}}.WebAPI\{{appName}}.WebAPI.csproj", "{1063DCDA-9291-4FAA-87B2-555E12511EE2}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.Generator.Security", "..\..\SoftGenerator\soft-generator\Soft.Generator.Security\Soft.Generator.Security.csproj", "{3B328631-AB3B-4B28-9FA5-4DA790670199}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.Generator.Shared", "..\..\SoftGenerator\soft-generator\Soft.Generator.Shared\Soft.Generator.Shared.csproj", "{53565A13-28F1-424F-B5A0-34125EF303CD}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.Generator.Infrastructure", "..\..\SoftGenerator\soft-generator\Soft.Generator.Infrastructure\Soft.Generator.Infrastructure.csproj", "{587D08A6-A975-4673-90A4-77CF61B7B526}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.SourceGenerators", "..\..\SoftGenerator\soft-generator\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj", "{A30DFD0D-9EDD-4FD2-8CAF-85492EEEE6F1}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "{{appName}}.Infrastructure", "{{appName}}.Infrastructure\{{appName}}.Infrastructure.csproj", "{8E0E2A3B-7A46-452E-9695-80E2BB1F4E9C}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "Business", "Business", "{F2AA00F3-29C7-4A82-B4C0-5BD998C67912}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "{{appName}}.Business", "{{appName}}.Business\{{appName}}.Business.csproj", "{50AD9ADA-4E90-4E69-97BB-92FA455115DE}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "{{appName}}.Shared", "{{appName}}.Shared\{{appName}}.Shared.csproj", "{2D65E133-33C4-4169-A175-D744800941D6}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{3B328631-AB3B-4B28-9FA5-4DA790670199}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{3B328631-AB3B-4B28-9FA5-4DA790670199}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{3B328631-AB3B-4B28-9FA5-4DA790670199}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{3B328631-AB3B-4B28-9FA5-4DA790670199}.Release|Any CPU.Build.0 = Release|Any CPU
		{53565A13-28F1-424F-B5A0-34125EF303CD}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{53565A13-28F1-424F-B5A0-34125EF303CD}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{53565A13-28F1-424F-B5A0-34125EF303CD}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{53565A13-28F1-424F-B5A0-34125EF303CD}.Release|Any CPU.Build.0 = Release|Any CPU
		{587D08A6-A975-4673-90A4-77CF61B7B526}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{587D08A6-A975-4673-90A4-77CF61B7B526}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{587D08A6-A975-4673-90A4-77CF61B7B526}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{587D08A6-A975-4673-90A4-77CF61B7B526}.Release|Any CPU.Build.0 = Release|Any CPU
		{A30DFD0D-9EDD-4FD2-8CAF-85492EEEE6F1}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{A30DFD0D-9EDD-4FD2-8CAF-85492EEEE6F1}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{A30DFD0D-9EDD-4FD2-8CAF-85492EEEE6F1}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{A30DFD0D-9EDD-4FD2-8CAF-85492EEEE6F1}.Release|Any CPU.Build.0 = Release|Any CPU
		{1063DCDA-9291-4FAA-87B2-555E12511EE2}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{1063DCDA-9291-4FAA-87B2-555E12511EE2}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{1063DCDA-9291-4FAA-87B2-555E12511EE2}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1063DCDA-9291-4FAA-87B2-555E12511EE2}.Release|Any CPU.Build.0 = Release|Any CPU
		{8E0E2A3B-7A46-452E-9695-80E2BB1F4E9C}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8E0E2A3B-7A46-452E-9695-80E2BB1F4E9C}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8E0E2A3B-7A46-452E-9695-80E2BB1F4E9C}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8E0E2A3B-7A46-452E-9695-80E2BB1F4E9C}.Release|Any CPU.Build.0 = Release|Any CPU
		{50AD9ADA-4E90-4E69-97BB-92FA455115DE}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{50AD9ADA-4E90-4E69-97BB-92FA455115DE}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{50AD9ADA-4E90-4E69-97BB-92FA455115DE}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{50AD9ADA-4E90-4E69-97BB-92FA455115DE}.Release|Any CPU.Build.0 = Release|Any CPU
		{2D65E133-33C4-4169-A175-D744800941D6}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{2D65E133-33C4-4169-A175-D744800941D6}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{2D65E133-33C4-4169-A175-D744800941D6}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{2D65E133-33C4-4169-A175-D744800941D6}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
		{3B328631-AB3B-4B28-9FA5-4DA790670199} = {D485BCE8-A950-457D-A710-566D559BD585}
		{53565A13-28F1-424F-B5A0-34125EF303CD} = {D485BCE8-A950-457D-A710-566D559BD585}
		{587D08A6-A975-4673-90A4-77CF61B7B526} = {D485BCE8-A950-457D-A710-566D559BD585}
		{A30DFD0D-9EDD-4FD2-8CAF-85492EEEE6F1} = {D485BCE8-A950-457D-A710-566D559BD585}
		{8E0E2A3B-7A46-452E-9695-80E2BB1F4E9C} = {F2AA00F3-29C7-4A82-B4C0-5BD998C67912}
		{50AD9ADA-4E90-4E69-97BB-92FA455115DE} = {F2AA00F3-29C7-4A82-B4C0-5BD998C67912}
		{2D65E133-33C4-4169-A175-D744800941D6} = {F2AA00F3-29C7-4A82-B4C0-5BD998C67912}
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {173A0B43-6F68-4847-ABBF-97106E9B08E6}
	EndGlobalSection
EndGlobal
""";
        }

        private string GetStartupCsData(string appName)
        {
            return $$"""
using LightInject;
using Soft.Generator.Shared.Helpers;
using Soft.Generator.Shared.Extensions;
using {{appName}}.WebAPI.DI;
using {{appName}}.Infrastructure;
using Quartz;

public class Startup
{
    public static string _jsonConfigurationFile = "appsettings.json";
    private readonly IHostEnvironment _hostEnvironment;

    public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
    {
        Configuration = configuration;
        _hostEnvironment = hostEnvironment;

        if (_hostEnvironment.IsStaging())
            _jsonConfigurationFile = "appsettings.Staging.json";
        else if (_hostEnvironment.IsProduction())
            _jsonConfigurationFile = "appsettings.Production.json";

        {{appName}}.WebAPI.SettingsProvider.Current = Helper.ReadAssemblyConfiguration<{{appName}}.WebAPI.Settings>(_jsonConfigurationFile);
        {{appName}}.Business.SettingsProvider.Current = Helper.ReadAssemblyConfiguration<{{appName}}.Business.Settings>(_jsonConfigurationFile);
        Soft.Generator.Infrastructure.SettingsProvider.Current = Helper.ReadAssemblyConfiguration<Soft.Generator.Infrastructure.Settings>(_jsonConfigurationFile);
        Soft.Generator.Security.SettingsProvider.Current = Helper.ReadAssemblyConfiguration<Soft.Generator.Security.Settings>(_jsonConfigurationFile);
        Soft.Generator.Shared.SettingsProvider.Current = Helper.ReadAssemblyConfiguration<Soft.Generator.Shared.Settings>(_jsonConfigurationFile);
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.SoftConfigureServices<{{appName}}ApplicationDbContext>();
    }

    public void ConfigureContainer(IServiceContainer container)
    {
        // Register container (AntiPattern)
        container.RegisterInstance(typeof(IServiceContainer), container);

        // Init WebAPI
        container.RegisterFrom<CompositionRoot>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.SoftConfigure(env);
    }
}
""";
        }

        private string GetWebAPISettingsCsData(string appName)
        {
            return $$"""
namespace {{appName}}.WebAPI
{
    public static class SettingsProvider
    {
        public static Settings Current { internal get; set; } = new Settings();
    }

    public class Settings
    {
        public string GoogleClientId { get; set; }

        public string ExcelContentType { get; set; }
    }
}
""";
        }

        private string GetProgramCsData(string appName)
        {
            return $$"""
namespace {{appName}}.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLightInject()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
""";
        }

        private string GetWebAPICsProjData(string appName)
        {
            return $$"""
<Project Sdk="Microsoft.NET.Sdk.Web">

	<PropertyGroup>
		<TargetFramework>net8.0</TargetFramework>
		<ImplicitUsings>enable</ImplicitUsings>
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="Azure.Storage.Blobs" Version="12.22.2" />
		<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="11.9.1" />
		<PackageReference Include="LightInject.Microsoft.Hosting" Version="1.6.1" />
		<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.2" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.2">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="8.0.2" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.2" />
		<PackageReference Include="Microsoft.Extensions.Azure" Version="1.7.6" />
		<PackageReference Include="Microsoft.IdentityModel.Tokens" Version="7.3.1" />
		<PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.19.5" />
		<PackageReference Include="NucleusFramework.Core" Version="6.1.9" />
		<PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
		<PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="7.3.1" />
	</ItemGroup>

	<ItemGroup>
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Infrastructure\Soft.Generator.Infrastructure.csproj" />
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Security\Soft.Generator.Security.csproj" />
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Shared\Soft.Generator.Shared.csproj" />
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
		<ProjectReference Include="..\{{appName}}.Business\{{appName}}.Business.csproj" />
		<ProjectReference Include="..\{{appName}}.Infrastructure\{{appName}}.Infrastructure.csproj" />
		<ProjectReference Include="..\{{appName}}.Shared\{{appName}}.Shared.csproj" />
	</ItemGroup>

	<ItemGroup>
		<PackageReference Include="System.IO.FileSystem.Primitives" Version="4.3.0" />
		<PackageReference Include="System.IO.FileSystem" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Handles" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Debug" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Extensions" Version="4.3.0" />
		<PackageReference Include="Microsoft.Win32.Primitives" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Tracing" Version="4.3.0" />
		<PackageReference Include="System.Net.Primitives" Version="4.3.0" />
	</ItemGroup>

	<ItemGroup>
	  <Folder Include="Helpers\" />
	</ItemGroup>

</Project>
""";
        }

        private string GetWebAPIGeneratorSettingsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes;

namespace {{appName}}.WebAPI.GeneratorSettings
{
    public class GeneratorSettings
    {
        [Output("true")]
        public string ControllerGenerator { get; set; }

        [Output("true")]
        public string TranslationsGenerator { get; set; }
    }
}
""";
        }

        private string GetAppSettingsJsonData(string appName, string emailSender, string smtpUser, string smtpPass, string jwtKey, string blobStorageConnectionString, string blobStorageUrl)
        {
            return $$"""
{
  "AppSettings": {
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Information"
      }
    },
    "AllowedHosts": "*",
    "{{appName}}.WebAPI": {
      "GoogleClientId": "24372003240-44eprq8dn4s0b5f30i18tqksep60uk5u.apps.googleusercontent.com",
      "ExcelContentType": "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    },
    "{{appName}}.Business": {
    },
    "Soft.Generator.Infrastructure": {
      "UseGoogleAsExternalProvider": true,
      "AppHasLatinTranslation": false
    },
    "Soft.Generator.Shared": {
      "EmailSender": "{{emailSender}}",
      "SmtpHost": "smtp.gmail.com",
      "SmtpPort": 587,
      "SmtpUser": "{{smtpUser}}",
      "SmtpPass": "{{smtpPass}}",
      "JwtKey": "{{jwtKey}}",
      "JwtIssuer": "https://localhost:7260;",
      "JwtAudience": "https://localhost:7260;",
      "ClockSkewMinutes": 1, // FT: Making it to 1 minute because of the SPA sends request exactly when it expires.
      "FrontendUrl": "http://localhost:4200",

      "BlobStorageConnectionString": "{{blobStorageConnectionString}}",
      "BlobStorageUrl": "{{blobStorageUrl}}",
      "BlobStorageContainerName": "files",

      "ConnectionString": "Data source=(localhost)\\SQLEXPRESS;Initial Catalog={{appName}};Integrated Security=True;Encrypt=false;MultipleActiveResultSets=True;"
    },
    "Soft.Generator.Security": {
      "JwtKey": "{{jwtKey}}",
      "JwtIssuer": "https://localhost:7260;",
      "JwtAudience": "https://localhost:7260;",
      "ClockSkewMinutes": 1, // FT: Making it to 1 minute because of the SPA sends request exactly when it expires. 
      "AccessTokenExpiration": 20,
      "RefreshTokenExpiration": 1440, // 24 hours
      "VerificationTokenExpiration": 5,
      "NumberOfFailedLoginAttemptsInARowToDisableUser": 40, // FT: I think we don't need this check, maybe delete in the future
      "AllowTheUseOfAppWithDifferentIpAddresses": true,
      "AllowedBrowsersForTheSingleUser": 5,
      "GoogleClientId": "24372003240-44eprq8dn4s0b5f30i18tqksep60uk5u.apps.googleusercontent.com",
      "ExcelContentType": "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    },
  }
}
""";
        }

        private string GetLaunchSettingsJsonData()
        {
            return $$"""
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:9663",
      "sslPort": 44388
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5173",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7068;http://localhost:5173",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
""";
        }

        private string GetCompositionRootCsData(string appName)
        {
            return $$"""
using LightInject;
using Soft.Generator.Security.Interface;
using Soft.Generator.Shared.Excel;
using Soft.Generator.Security.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Soft.Generator.Shared.SoftFluentValidation;
using Soft.Generator.Shared.Emailing;
using {{appName}}.Business.Services;
using {{appName}}.Business.Entities;

namespace {{appName}}.WebAPI.DI
{
    public class CompositionRoot : ICompositionRoot
    {
        public virtual void Compose(IServiceRegistry registry)
        {
            // Framework
            registry.Register<AuthenticationService>();
            registry.Register<AuthorizationService>();
            registry.Register<Soft.Generator.Security.Services.SecurityBusinessService<UserExtended>>();
            registry.Register<Soft.Generator.Security.Services.BusinessServiceGenerated<UserExtended>>();
            registry.Register<Soft.Generator.Security.Services.AuthorizationBusinessService<UserExtended>>();
            registry.Register<Soft.Generator.Security.Services.AuthorizationBusinessServiceGenerated>();
            registry.Register<ExcelService>();
            registry.Register<EmailingService>();
            registry.RegisterSingleton<IConfigureOptions<MvcOptions>, TranslatePropertiesConfiguration>();
            registry.RegisterSingleton<IJwtAuthManager, JwtAuthManagerService>();

            // Business
            registry.Register<{{appName}}.Business.Services.{{appName}}BusinessService>();
            registry.Register<{{appName}}.Business.Services.BusinessServiceGenerated>();
            registry.Register<{{appName}}.Business.Services.AuthorizationBusinessService>();
            registry.Register<{{appName}}.Business.Services.AuthorizationBusinessServiceGenerated>();
        }
    }
}
""";
        }

        private string GetSharedCsProjData()
        {
            return $$"""
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Shared\Soft.Generator.Shared.csproj" />
  </ItemGroup>

  <ItemGroup>
  </ItemGroup>

	<ItemGroup>
		<PackageReference Include="System.IO.FileSystem.Primitives" Version="4.3.0" />
		<PackageReference Include="System.IO.FileSystem" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Handles" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Debug" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Extensions" Version="4.3.0" />
		<PackageReference Include="Microsoft.Win32.Primitives" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Tracing" Version="4.3.0" />
		<PackageReference Include="System.Net.Primitives" Version="4.3.0" />
	</ItemGroup>

</Project>

""";
        }

        private string GetInfrastructureCsProjData(string appName)
        {
            return $$"""
<Project Sdk="Microsoft.NET.Sdk">

	<PropertyGroup>
		<TargetFramework>net8.0</TargetFramework>
		<ImplicitUsings>enable</ImplicitUsings>
	</PropertyGroup>

	<ItemGroup>
	</ItemGroup>

	<ItemGroup>
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Infrastructure\Soft.Generator.Infrastructure.csproj" />
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Security\Soft.Generator.Security.csproj" />
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Shared\Soft.Generator.Shared.csproj" />
		<ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
		<ProjectReference Include="..\{{appName}}.Business\{{appName}}.Business.csproj" />
		<ProjectReference Include="..\{{appName}}.Shared\{{appName}}.Shared.csproj" />
	</ItemGroup>

	<ItemGroup>
		<PackageReference Include="System.IO.FileSystem.Primitives" Version="4.3.0" />
		<PackageReference Include="System.IO.FileSystem" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Handles" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Debug" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Extensions" Version="4.3.0" />
		<PackageReference Include="Microsoft.Win32.Primitives" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Tracing" Version="4.3.0" />
		<PackageReference Include="System.Net.Primitives" Version="4.3.0" />
	</ItemGroup>

</Project>
""";
        }

        private string GetInfrastructureGeneratorSettingsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes;

namespace {{appName}}.Infrastructure.GeneratorSettings
{
    public class GeneratorSettings
    {
        [Output("true")]
        public bool DbContextGenerator { get; set; }
    }
}
""";
        }

        private string GetBusinessSettingsCsData(string appName)
        {
            return $$"""
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{appName}}.Business
{
    public static class SettingsProvider
    {
        public static Settings Current { internal get; set; } = new Settings();
    }

    public class Settings
    {

    }
}
""";
        }

        private string GetBusinessCsProjData()
        {
            return $$"""
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.Generator.Security\Soft.Generator.Security.csproj" />
    <ProjectReference Include="..\..\..\SoftGenerator\soft-generator\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
  </ItemGroup>

  <ItemGroup>
    <Folder Include="DataMappers\" />
    <Folder Include="DTO\Helpers" />
    <Folder Include="DTO\Partials" />
    <Folder Include="Entities\" />
    <Folder Include="Enums\" />
    <Folder Include="Services\" />
    <Folder Include="ValidationRules\" />
  </ItemGroup>

    <ItemGroup>
        <FrameworkReference Include="Microsoft.AspNetCore.App" />
    </ItemGroup>

	<ItemGroup>
		<PackageReference Include="Quartz.Extensions.Hosting" Version="3.13.1" />
		<PackageReference Include="System.IO.FileSystem.Primitives" Version="4.3.0" />
		<PackageReference Include="System.IO.FileSystem" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Handles" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Debug" Version="4.3.0" />
		<PackageReference Include="System.Runtime.Extensions" Version="4.3.0" />
		<PackageReference Include="Microsoft.Win32.Primitives" Version="4.3.0" />
		<PackageReference Include="System.Diagnostics.Tracing" Version="4.3.0" />
		<PackageReference Include="System.Net.Primitives" Version="4.3.0" />
	</ItemGroup>

</Project>
""";
        }

        private string GetBusinessGeneratorSettingsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes;

namespace {{appName}}.Business.GeneratorSettings
{
    public class GeneratorSettings
    {
        
    }
}
""";
        }

        private string GetNotificationServiceCsData(string appName)
        {
            return $$"""
using {{appName}}.Business.Entities;
using Soft.Generator.Security.Interface;
using Soft.Generator.Shared.Extensions;
using Soft.Generator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{appName}}.Business.Services
{
    public class NotificationService
    {
        private readonly IApplicationDbContext _context;

        public NotificationService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendNotification(UserExtended user, string notificationTitle, string notificationDescription)
        {
            await _context.WithTransactionAsync(async () =>
            {
                Notification notification = new Notification
                {
                    Title = notificationTitle,
                    Description = notificationDescription,
                };

                user.Notifications.Add(notification);

                await _context.SaveChangesAsync();
            });
        }

    }
}
""";
        }

        private string GetAuthorizationServiceCsData(string appName)
        {
            return $$"""
using Azure.Storage.Blobs;
using Soft.Generator.Security.Services;
using Soft.Generator.Shared.Interfaces;

namespace {{appName}}.Business.Services
{
    public class AuthorizationBusinessService : AuthorizationBusinessServiceGenerated
    {
        private readonly IApplicationDbContext _context;
        private readonly AuthenticationService _authenticationService;

        public AuthorizationBusinessService(IApplicationDbContext context, AuthenticationService authenticationService, BlobContainerClient blobContainerClient)
            : base(context, authenticationService, blobContainerClient)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

    }
}
""";
        }

        private string GetBusinessServiceCsData(string appName)
        {
            return $$"""
using {{appName}}.Business.Services;
using {{appName}}.Business.Entities;
using {{appName}}.Business.DTO;
using {{appName}}.Business.Enums;
using {{appName}}.Business.DataMappers;
using {{appName}}.Business.ValidationRules;
using Soft.Generator.Shared.DTO;
using Soft.Generator.Shared.Excel;
using Soft.Generator.Shared.Interfaces;
using Soft.Generator.Shared.Extensions;
using Soft.Generator.Shared.Helpers;
using Soft.Generator.Security.DTO;
using Soft.Generator.Security.Services;
using Soft.Generator.Shared.SoftExceptions;
using Microsoft.EntityFrameworkCore;
using Mapster;
using FluentValidation;
using Soft.Generator.Shared.Emailing;
using Azure.Storage.Blobs;

namespace {{appName}}.Business.Services
{
    public class {{appName}}BusinessService : {{appName}}.Business.Services.BusinessServiceGenerated
    {
        private readonly IApplicationDbContext _context;
        private readonly {{appName}}.Business.Services.AuthorizationBusinessService _authorizationService;
        private readonly AuthenticationService _authenticationService;
        private readonly SecurityBusinessService<UserExtended> _securityBusinessService;
        private readonly EmailingService _emailingService;
        private readonly BlobContainerClient _blobContainerClient;

        public {{appName}}BusinessService(IApplicationDbContext context, ExcelService excelService, {{appName}}.Business.Services.AuthorizationBusinessService authorizationService, SecurityBusinessService<UserExtended> securityBusinessService, 
            AuthenticationService authenticationService, EmailingService emailingService, BlobContainerClient blobContainerClient)
            : base(context, excelService, authorizationService, blobContainerClient)
        {
            _context = context;
            _authorizationService = authorizationService;
            _securityBusinessService = securityBusinessService;
            _authenticationService = authenticationService;
            _emailingService = emailingService;
            _blobContainerClient = blobContainerClient;
        }

        #region User

        protected override async Task OnBeforeSaveUserExtendedAndReturnSaveBodyDTO(UserExtendedSaveBodyDTO userExtendedSaveBodyDTO)
        {
            await _context.WithTransactionAsync(async () =>
            {
                if (userExtendedSaveBodyDTO.UserExtendedDTO.Id == 0)
                    throw new HackerException("You can't add new user.");

                UserExtended user = await GetInstanceAsync<UserExtended, long>(userExtendedSaveBodyDTO.UserExtendedDTO.Id, userExtendedSaveBodyDTO.UserExtendedDTO.Version);

                if (userExtendedSaveBodyDTO.UserExtendedDTO.Email != user.Email)
                    throw new HackerException("You can't change email from here.");

                await _securityBusinessService.UpdateRoleListForUser(userExtendedSaveBodyDTO.UserExtendedDTO.Id, userExtendedSaveBodyDTO.SelectedRolesIds);
            });
        }

        public async Task<List<string>> GetCurrentUserPermissionCodes()
        {
            return await _context.WithTransactionAsync(async () =>
            {
                UserExtended currentUser = await _authenticationService.GetCurrentUser<UserExtended>();

                if (currentUser == null)
                    return new List<string>();

                return currentUser.Roles
                    .SelectMany(x => x.Permissions)
                    .Select(x => x.Code)
                    .Distinct()
                    .ToList();
            });
        }

        #endregion

        #region Notification

        public async Task SendNotificationEmail(long notificationId, int notificationVersion)
        {
            await _context.WithTransactionAsync(async () =>
            {
                await _authorizationService.AuthorizeAndThrowAsync<UserExtended>(PermissionCodes.EditNotification);

                // FT: Checking version because if the user didn't save and some other user changed the version, he will send emails to wrong users
                Notification notification = await GetInstanceAsync<Notification, long>(notificationId, notificationVersion);

                List<string> recipients = notification.Recipients.Select(x => x.Email).ToList();

                await _emailingService.SendEmailAsync(recipients, notification.Title, notification.EmailBody);
            });
        }

        public async Task DeleteNotificationForCurrentUser(long notificationId, int notificationVersion)
        {
            await _context.WithTransactionAsync(async () =>
            {
                long currentUserId = _authenticationService.GetCurrentUserId();

                //await _authorizationService.AuthorizeAndThrowAsync<UserExtended>(PermissionCodes.EditNotification);

                Notification notification = await GetInstanceAsync<Notification, long>(notificationId, notificationVersion);

                await _context.DbSet<UserNotification>()
                    .Where(x => x.User.Id == currentUserId && x.Notification.Id == notification.Id)
                    .ExecuteDeleteAsync();
            });
        }

        public async Task MarkNotificationAsReadForCurrentUser(long notificationId, int notificationVersion)
        {
            await _context.WithTransactionAsync(async () =>
            {
                long currentUserId = _authenticationService.GetCurrentUserId();

                //await _authorizationService.AuthorizeAndThrowAsync<UserExtended>(PermissionCodes.EditNotification);

                Notification notification = await GetInstanceAsync<Notification, long>(notificationId, notificationVersion);

                await _context.DbSet<UserNotification>()
                    .Where(x => x.User.Id == currentUserId && x.Notification.Id == notification.Id)
                    .ExecuteUpdateAsync(setters => setters.SetProperty(x => x.IsMarkedAsRead, true));
            });
        }

        public async Task MarkNotificationAsUnreadForCurrentUser(long notificationId, int notificationVersion)
        {
            await _context.WithTransactionAsync(async () =>
            {
                long currentUserId = _authenticationService.GetCurrentUserId();

                //await _authorizationService.AuthorizeAndThrowAsync<UserExtended>(PermissionCodes.EditNotification);

                Notification notification = await GetInstanceAsync<Notification, long>(notificationId, notificationVersion);

                await _context.DbSet<UserNotification>()
                    .Where(x => x.User.Id == currentUserId && x.Notification.Id == notification.Id)
                    .ExecuteUpdateAsync(setters => setters.SetProperty(x => x.IsMarkedAsRead, false));
            });
        }

        #endregion

    }
}
""";
        }

        private string GetMapsterMapperCsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes;

namespace {{appName}}.Business.DataMappers
{
    [CustomMapper]
    public static partial class Mapper
    {

    }
}
""";
        }

        #endregion

        #region Angular

        private string GetAppLayoutServiceTsData()
        {
            return $$"""
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

export interface AppConfig {
    inputStyle: string;
    colorScheme: string; 
    theme: string;
    ripple: boolean;
    menuMode: string;
    scale: number;
    color: string;
}

interface LayoutState {
    staticMenuDesktopInactive: boolean;
    overlayMenuActive: boolean;
    profileSidebarVisible: boolean;
    profileDropdownSidebarVisible:boolean;
    configSidebarVisible: boolean;
    staticMenuMobileActive: boolean;
    menuHoverActive: boolean;
}

@Injectable({
    providedIn: 'root',
})
export class LayoutService {

    config: AppConfig = {
        ripple: false,
        inputStyle: 'outlined',
        menuMode: 'static',
        colorScheme: 'light',
        theme: 'lara-light-indigo',
        scale: 14,
        color: `var(--primary-color)`,
    };

    state: LayoutState = {
        staticMenuDesktopInactive: false,
        overlayMenuActive: false,
        profileSidebarVisible: false,
        profileDropdownSidebarVisible: false,
        configSidebarVisible: false,
        staticMenuMobileActive: false,
        menuHoverActive: false
    };

    private configUpdate = new Subject<AppConfig>();

    private overlayOpen = new Subject<any>();

    configUpdate$ = this.configUpdate.asObservable();

    overlayOpen$ = this.overlayOpen.asObservable();

    constructor() {
    }

    onMenuToggle() {
        if (this.isOverlay()) {
            this.state.overlayMenuActive = !this.state.overlayMenuActive;
            if (this.state.overlayMenuActive) {
                this.overlayOpen.next(null);
            }
        }

        if (this.isDesktop()) {
            this.state.staticMenuDesktopInactive = !this.state.staticMenuDesktopInactive;
        }
        else {
            this.state.staticMenuMobileActive = !this.state.staticMenuMobileActive;

            if (this.state.staticMenuMobileActive) {
                this.overlayOpen.next(null);
            }
        }
    }

    showProfileSidebar() {
        this.state.profileSidebarVisible = !this.state.profileSidebarVisible;
        if (this.state.profileSidebarVisible) {
            this.overlayOpen.next(null);
        }
    }

    showProfileDropdownSidebar() {
        this.state.profileDropdownSidebarVisible = !this.state.profileDropdownSidebarVisible;
        if (this.state.profileDropdownSidebarVisible) {
            this.overlayOpen.next(null);
        }
    }

    showConfigSidebar() {
        this.state.configSidebarVisible = true;
    }

    isOverlay() {
        return this.config.menuMode === 'overlay';
    }

    isDesktop() {
        return window.innerWidth > 991;
    }

    isMobile() {
        return !this.isDesktop();
    }

    onConfigUpdate() {
        this.configUpdate.next(this.config);
    }

}
""";
        }

        private string GetAppTopbarComponentTsData()
        {
            return $$"""
import { TranslocoService } from '@jsverse/transloco';
import { NavigationEnd, Router } from '@angular/router';
import { Component, ElementRef, OnDestroy, ViewChild } from '@angular/core';
import { filter, Subscription } from 'rxjs';
import { ApiService } from '../../../business/services/api/api.service';
import { LayoutService } from '../../services/app.layout.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserExtended } from 'src/app/business/entities/business-entities.generated';

interface SoftMenuItem {
  label?: string;
  icon?: string;
  showSeparator?: boolean;
  onClick?: () => void;
  showNotificationBadge?: boolean;
}

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html',
    styles: [
    ]
})
export class AppTopBarComponent implements OnDestroy {
    private userSubscription: Subscription | null = null;

    currentUser: UserExtended;
    currentUserNotificationsCount: number;
    menuItems: SoftMenuItem[] = [];
    avatarLabel: string;
    companyName: string;
    showProfileIcon: boolean = false;

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    @ViewChild('topbarprofiledropdownmenubutton') topbarProfileDropdownMenuButton!: ElementRef;

    constructor(
      public layoutService: LayoutService, 
      private authService: AuthService, 
      private apiService: ApiService,
      protected router: Router,
      private translocoService: TranslocoService,
    ) { 
    }

  async ngOnInit(){
    this.menuItems = [
      {
        label: this.translocoService.translate('YourProfile'),
        icon: 'pi-user',
        showSeparator: true,
        onClick: () => {
          this.routeToUserPage();
        }
      },
      {
        label: this.translocoService.translate('NotificationList'),
        icon: 'pi-bell',
        showNotificationBadge: true,
        onClick: () => {
          this.router.navigateByUrl(`/notifications`);
        },
      },
      // {
      //   label: this.translocoService.translate('Settings'),
      //   icon: 'pi-cog'
      // },
      {
        label: this.translocoService.translate('Logout'),
        icon: 'pi-sign-out',
        showSeparator: true,
        onClick: () => {
          this.authService.logout();
        }
      }
    ]

    this.userSubscription = this.authService.user$.subscribe(currentUser => {
        this.currentUser = currentUser;
        this.avatarLabel = currentUser?.email.charAt(0).toLocaleUpperCase();
    });

    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.layoutService.state.profileDropdownSidebarVisible = false;
      });
  }

  onDocumentClick(event: any) {
    if (
      !this.menu.nativeElement.contains(event.target) 
    ) {
      if (this.layoutService.state.profileDropdownSidebarVisible == true) {
        this.layoutService.state.profileDropdownSidebarVisible = false;
      }
    }
  }

  routeToUserPage(){
    this.router.navigateByUrl(`/administration/users/${this.currentUser.id}`);
  }

  ngOnDestroy(): void {
    if (this.userSubscription) {
      this.userSubscription.unsubscribe();
    }
  }

}
""";
        }

        private string GetAppTopbarComponentHtmlData()
        {
            return $$$"""
<div class="layout-topbar">
  <a class="layout-topbar-logo" routerLink="/">
    <span>{{companyName?.toLocaleUpperCase()}}</span>
  </a>

  <button
    #menubutton
    class="p-link layout-menu-button layout-topbar-button"
    (click)="layoutService.onMenuToggle()"
  >
    <i class="pi pi-bars"></i>
  </button>

  <div
    #topbarmenu
    class="profile-button"
    >
    <div
      #topbarprofiledropdownmenubutton
      (click)="layoutService.showProfileDropdownSidebar()"
    >
    <p-avatar
        *ngIf="showProfileIcon"
        [label]="avatarLabel"
        [style]="{ 'background-color': 'var(--primary-color)', 'color': '#fff', 'cursor': 'pointer', 'width': '34px', 'height': '34px', 'font-size': '21px' }"
        pBadge 
        [badgeStyleClass]="'p-badge-danger'"
        [badgeDisabled]="currentUserNotificationsCount == 0 || currentUserNotificationsCount == null"
        [value]="currentUserNotificationsCount"
        />
    </div>
    <div
      #topbarprofiledropdownmenu
      (document:click)="onDocumentClick($event)"
    >
    <div *ngIf="layoutService.state.profileDropdownSidebarVisible" style="width: 280px; position: absolute; right: 26px; top: 60px; padding: 15px;" class="card">
      <div style="display: flex; flex-direction: column; justify-content: center; text-align: center; gap: 10px;">
        <p-avatar
          [label]="avatarLabel"
          size="xlarge"
          [style]="{ 'background-color': 'var(--primary-color)', 'color': '#fff', 'cursor': 'pointer' }"
          (click)="routeToUserPage()"
          />
        <div>{{currentUser?.email}}</div>
      </div>
      <div style="margin-top: 15px;">
        <div *ngFor="let item of menuItems" [style]="item.showSeparator ? 'margin-top: 5px;' : ''">
          <div *ngIf="item.showSeparator" class="gray-separator"></div>
          <div (click)="item.onClick()" class="hover-card" style="display: flex; align-items: center; gap: 5px; margin-top: 5px;">
            <i 
              class="pi pi-fw {{item.icon}} primary-color" 
              style="font-size: 16px; position: relative;"
              >
              <span *ngIf="item.showNotificationBadge && currentUserNotificationsCount != 0" class="badge"></span>
            </i>
            <div> {{item.label}} </div>
          </div>
        </div>
      </div>
    </div>
    </div>
  </div>
</div>
""";
        }

        private string GetAppSidebarComponentTsData()
        {
            return $$"""
import { Component, ElementRef } from '@angular/core';
import { LayoutService } from "../../services/app.layout.service";

@Component({
    selector: 'app-sidebar',
    templateUrl: './app.sidebar.component.html'
})
export class AppSidebarComponent {
    constructor(public layoutService: LayoutService, public el: ElementRef) { }
}
""";
        }

        private string GetAppSidebarComponentHtmlData()
        {
            return $$"""
<app-menu></app-menu>
""";
        }

        private string GetAppMenuItemComponentTsData()
        {
            return $$$"""
import { ChangeDetectorRef, Component, HostBinding, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { firstValueFrom, Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { MenuService } from './app.menu.service';
import { LayoutService } from '../../services/app.layout.service';
import { AuthService } from '../../../core/services/auth.service';
import { SoftMenuItem } from './app.menu.component';
import { ApiService } from '../../../business/services/api/api.service';
import { AutoCompleteCompleteEvent } from 'primeng/autocomplete';
import { SoftFormControl } from '../../../core/components/soft-form-control/soft-form-control';
import { environment } from 'src/environments/environment';

@Component({
    // eslint-disable-next-line @angular-eslint/component-selector
    selector: '[app-menuitem]',
    templateUrl: './app.menuitem.component.html',
    animations: [
        trigger('children', [
            state('collapsed', style({
                height: '0'
            })),
            state('expanded', style({
                height: '*'
            })),
            transition('collapsed <=> expanded', animate('400ms cubic-bezier(0.86, 0, 0.07, 1)'))
        ])
    ]
})
export class AppMenuitemComponent implements OnInit, OnDestroy {

    @Input() item: SoftMenuItem;

    @Input() index!: number;

    @Input() @HostBinding('class.layout-root-menuitem') root!: boolean;

    @Input() parentKey!: string;

    active = false;

    private menuSourceSubscription: Subscription;

    private menuResetSubscription: Subscription;

    private permissionSubscription: Subscription | null = null;

    key: string = "";

    constructor(
        public layoutService: LayoutService, 
        private cd: ChangeDetectorRef, 
        public router: Router, 
        private menuService: MenuService, 
        private authService: AuthService,
        private apiService: ApiService,
    ) {
        this.menuSourceSubscription = this.menuService.menuSource$.subscribe(value => {
            Promise.resolve(null).then(() => {
                if (value.routeEvent) {
                    this.active = (value.key === this.key || value.key.startsWith(this.key + '-')) ? true : false;
                }
                else {
                    if (value.key !== this.key && !value.key.startsWith(this.key + '-')) {
                        this.active = false;
                    }
                }
            });
        });

        this.menuResetSubscription = this.menuService.resetSource$.subscribe(() => {
            this.active = false;
        });

        this.router.events.pipe(filter(event => event instanceof NavigationEnd))
            .subscribe(params => {
                if (this.item.routerLink) {
                    this.updateActiveStateFromRoute();
                }
            });
    }

    ngOnInit() {
        this.permissionSubscription = this.authService.currentUserPermissions$.subscribe((currentUserPermissionCodes: string[]) => {
            if (this.item && typeof this.item.hasPermission === 'function') {
                this.item.visible = this.item.hasPermission(currentUserPermissionCodes);
            }
        });

        this.key = this.parentKey ? this.parentKey + '-' + this.index : String(this.index);

        if (this.item.routerLink) {
            this.updateActiveStateFromRoute();
        }
    }

    updateActiveStateFromRoute() {
        let activeRoute = this.router.isActive(this.item.routerLink[0], { paths: 'exact', queryParams: 'ignored', matrixParams: 'ignored', fragment: 'ignored' });

        if (activeRoute) {
            this.menuService.onMenuStateChange({ key: this.key, routeEvent: true });
        }
    }

    itemClick(event: Event) {
        // avoid processing disabled items
        if (this.item.disabled || event === null) {
            event.preventDefault();
            return;
        }

        // execute command
        if (this.item.command) {
            this.item.command({ originalEvent: event, item: this.item });
        }

        // toggle active state
        if (this.item.items) {
            this.active = !this.active;
        }

        this.menuService.onMenuStateChange({ key: this.key });
    }

    get submenuAnimation() {
        return this.root ? 'expanded' : (this.active ? 'expanded' : 'collapsed');
    }

    @HostBinding('class.active-menuitem') 
    get activeClass() {
        return this.active && !this.root;
    }

    ngOnDestroy() {
        if (this.menuSourceSubscription) {
            this.menuSourceSubscription.unsubscribe();
        }

        if (this.menuResetSubscription) {
            this.menuResetSubscription.unsubscribe();
        }

        if (this.permissionSubscription) {
            this.permissionSubscription.unsubscribe();
        }
    }
}

""";
        }

        private string GetAppMenuItemComponentHtmlData()
        {
            return $$$"""
<ng-container *transloco="let t">
    <div *ngIf="root && item.visible === true" class="layout-menuitem-root-text">{{item.label}}</div>
    <a *ngIf="(!item.routerLink || item.items) && item.visible === true" [attr.href]="item.url" (click)="itemClick($event)"
       [ngClass]="item.styleClass" [attr.target]="item.target" tabindex="0" pRipple>
        <i [ngClass]="item.icon" class="layout-menuitem-icon"></i>
        <span class="layout-menuitem-text">{{item.label}}</span>
        <i class="pi pi-fw pi-angle-down layout-submenu-toggler" *ngIf="item.items"></i>
    </a>
    <a *ngIf="(item.routerLink && !item.items) && item.visible === true" (click)="itemClick($event)" [ngClass]="item.styleClass"
    [routerLink]="item.routerLink" routerLinkActive="active-route" [routerLinkActiveOptions]="item.routerLinkActiveOptions||{ paths: 'exact', queryParams: 'ignored', matrixParams: 'ignored', fragment: 'ignored' }"
    [fragment]="item.fragment" [queryParamsHandling]="item.queryParamsHandling" [preserveFragment]="item.preserveFragment"
    [skipLocationChange]="item.skipLocationChange" [replaceUrl]="item.replaceUrl" [state]="item.state" [queryParams]="item.queryParams"
    [attr.target]="item.target" tabindex="0" pRipple>
        <i [ngClass]="item.icon" class="layout-menuitem-icon"></i>
        <span class="layout-menuitem-text">{{item.label}}</span>
        <i class="pi pi-fw pi-angle-down layout-submenu-toggler" *ngIf="item.items"></i>
    </a>

    <ul *ngIf="item.items && item.visible === true" [@children]="submenuAnimation">
        <ng-template ngFor let-child let-i="index" [ngForOf]="item.items">
            <li app-menuitem [item]="child" [index]="i" [parentKey]="key" [class]="child.badgeStyleClass"></li>
        </ng-template>
    </ul>
</ng-container>
""";
        }

        private string GetAppMenuServiceTsData()
        {
            return $$"""
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { MenuChangeEvent } from '../../../core/entities/menuchangeevent';

@Injectable({
    providedIn: 'root'
})
export class MenuService {

    private menuSource = new Subject<MenuChangeEvent>();
    private resetSource = new Subject();

    menuSource$ = this.menuSource.asObservable();
    resetSource$ = this.resetSource.asObservable();

    onMenuStateChange(event: MenuChangeEvent) {
        this.menuSource.next(event);
    }

    reset() {
        this.resetSource.next(true);
    }
}
""";
        }

        private string GetAppMenuComponentTsData()
        {
            return $$"""
import { TranslocoService } from '@jsverse/transloco';
import { Subscription } from 'rxjs';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from '../../services/app.layout.service';
import { MenuItem } from 'primeng/api';
import { environment } from 'src/environments/environment';

export interface SoftMenuItem extends MenuItem{
    hasPermission?: (permissionCodes: string[]) => boolean;
}

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {
    model: SoftMenuItem[] = [];

    constructor(
        public layoutService: LayoutService, 
        private translocoService: TranslocoService
    ) {

    }

    ngOnInit() {
        this.model = [
            {
                items: [
                    {
                        label: `${environment.companyName}`,
                        icon: 'pi pi-fw pi-at', 
                        visible: true,
                    }
                ],
                visible: true,
            },
            {
                separator: true,
                visible: true,
            },
            {
                items: [
                    { 
                        label: this.translocoService.translate('Home'), 
                        icon: 'pi pi-fw pi-home', 
                        routerLink: [''],
                        visible: true,
                    }, 
                ],
                visible: true,
            },
        ];
    }


    ngOnDestroy(): void {
    }

}

""";
        }

        private string GetAppMenuComponentHtmlData()
        {
            return $$"""
<ul class="layout-menu">
    <ng-container *ngFor="let item of model; let i = index;">
        <li app-menuitem *ngIf="!item.separator" [item]="item" [index]="i" [root]="true"></li>
        <li *ngIf="item.separator" class="gray-separator" style="margin-top: 11px;"></li>
    </ng-container>
</ul>

""";
        }

        private string GetAppLayoutModuleTsData()
        {
            return $$"""
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AppLayoutComponent } from "./app.layout.component";
import { PrimengModule } from '../../../core/modules/primeng.module';
import { BrowserModule } from '@angular/platform-browser';
import { SoftAutocompleteComponent } from "../../../core/controls/soft-autocomplete/soft-autocomplete.component";
import { TranslocoDirective } from '@jsverse/transloco';
import { AppFooterComponent } from '../../../core/components/footer/app.footer.component';
import { AppMenuComponent } from '../sidebar/app.menu.component';
import { AppMenuitemComponent } from '../sidebar/app.menuitem.component';
import { AppSidebarComponent } from '../sidebar/app.sidebar.component';
import { AppTopBarComponent } from '../topbar/app.topbar.component';

@NgModule({
    declarations: [
        AppMenuitemComponent,
        AppTopBarComponent,
        AppFooterComponent,
        AppMenuComponent,
        AppSidebarComponent,
        AppLayoutComponent,
    ],
    imports: [
        FormsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        BrowserModule,
        RouterModule,
        PrimengModule,
        TranslocoDirective,
        SoftAutocompleteComponent,
    ],
    exports: [
        FormsModule,
        AppLayoutComponent,
        PrimengModule,
    ]
})
export class AppLayoutModule { }
""";
        }

        private string GetAppLayoutComponentTsData()
        {
            return $$"""
import { Component, OnDestroy, Renderer2, ViewChild } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter, Subscription } from 'rxjs';
import { LayoutService } from "../../services/app.layout.service";
import { AppSidebarComponent } from '../sidebar/app.sidebar.component';
import { AppTopBarComponent } from '../topbar/app.topbar.component';

@Component({
    selector: 'app-layout',
    templateUrl: './app.layout.component.html'
})
export class AppLayoutComponent implements OnDestroy {

    overlayMenuOpenSubscription: Subscription;

    menuOutsideClickListener: any;

    profileMenuOutsideClickListener: any;

    @ViewChild(AppSidebarComponent) appSidebar!: AppSidebarComponent;

    @ViewChild(AppTopBarComponent) appTopbar!: AppTopBarComponent;

    constructor(
        public layoutService: LayoutService, 
        public renderer: Renderer2, 
        public router: Router,
    ) {
        this.overlayMenuOpenSubscription = this.layoutService.overlayOpen$.subscribe(() => {
            if (!this.menuOutsideClickListener) {
                this.menuOutsideClickListener = this.renderer.listen('document', 'click', event => {
                    const isOutsideClicked = !(
                        this.appSidebar.el.nativeElement.isSameNode(event.target) || 
                        this.appSidebar.el.nativeElement.contains(event.target) ||
                        this.appTopbar.menuButton.nativeElement.isSameNode(event.target) || 
                        this.appTopbar.menuButton.nativeElement.contains(event.target) ||
                        (event.target.closest('.p-autocomplete-items')) ||
                        (event.target.closest('.p-autocomplete-clear-icon'))
                    );

                    if (isOutsideClicked) {
                        this.hideMenu();
                    }
                });
            }

            if (!this.profileMenuOutsideClickListener) {
                this.profileMenuOutsideClickListener = this.renderer.listen('document', 'click', event => {
                    const isOutsideClicked = !(this.appTopbar.menu.nativeElement.isSameNode(event.target) || this.appTopbar.menu.nativeElement.contains(event.target));

                    if (isOutsideClicked) {
                        this.hideProfileMenu();
                    }
                });
            }

            if (this.layoutService.state.staticMenuMobileActive) {
                this.blockBodyScroll();
            }
        });

        this.router.events.pipe(filter(event => event instanceof NavigationEnd))
            .subscribe(() => {
                this.hideMenu();
                this.hideProfileMenu();
            });
    }

    hideMenu() {
        this.layoutService.state.overlayMenuActive = false;
        this.layoutService.state.staticMenuMobileActive = false;
        this.layoutService.state.menuHoverActive = false;
        if (this.menuOutsideClickListener) {
            this.menuOutsideClickListener();
            this.menuOutsideClickListener = null;
        }
        this.unblockBodyScroll();
    }

    hideProfileMenu() {
        this.layoutService.state.profileSidebarVisible = false;
        if (this.profileMenuOutsideClickListener) {
            this.profileMenuOutsideClickListener();
            this.profileMenuOutsideClickListener = null;
        }
    }

    blockBodyScroll(): void {
        if (document.body.classList) {
            document.body.classList.add('blocked-scroll');
        }
        else {
            document.body.className += ' blocked-scroll';
        }
    }

    unblockBodyScroll(): void {
        if (document.body.classList) {
            document.body.classList.remove('blocked-scroll');
        }
        else {
            document.body.className = document.body.className.replace(new RegExp('(^|\\b)' +
                'blocked-scroll'.split(' ').join('|') + '(\\b|$)', 'gi'), ' ');
        }
    }

    get containerClass() {
        return {
            'layout-theme-light': this.layoutService.config.colorScheme === 'light',
            'layout-theme-dark': this.layoutService.config.colorScheme === 'dark',
            'layout-overlay': this.layoutService.config.menuMode === 'overlay',
            'layout-static': this.layoutService.config.menuMode === 'static',
            'layout-static-inactive': this.layoutService.state.staticMenuDesktopInactive && this.layoutService.config.menuMode === 'static',
            'layout-overlay-active': this.layoutService.state.overlayMenuActive,
            'layout-mobile-active': this.layoutService.state.staticMenuMobileActive,
            'p-input-filled': this.layoutService.config.inputStyle === 'filled',
            'p-ripple-disabled': !this.layoutService.config.ripple
        }
    }

    ngOnDestroy() {
        if (this.overlayMenuOpenSubscription) {
            this.overlayMenuOpenSubscription.unsubscribe();
        }

        if (this.menuOutsideClickListener) {
            this.menuOutsideClickListener();
        }
    }
}
""";
        }

        private string GetAppLayoutComponentHtmlData()
        {
            return $$"""
<div class="layout-wrapper" [ngClass]="containerClass">
    <app-topbar></app-topbar>
    <div class="layout-sidebar">
        <app-sidebar></app-sidebar>
    </div>
    <div class="layout-main-container">
        <div class="layout-main">
            <router-outlet></router-outlet>
        </div>
        <app-footer></app-footer>
    </div>
    <div class="layout-mask"></div>
</div>
""";
        }

        private string GetDashboardModuleTsData()
        {
            return $$"""
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard.component';
import { MenuModule } from 'primeng/menu';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { StyleClassModule } from 'primeng/styleclass';
import { PanelMenuModule } from 'primeng/panelmenu';
import { DashboardsRoutingModule } from './dashboard-routing.module';
import { ApiService } from '../../../business/services/api/api.service';
import { PrimengModule } from '../../../core/modules/primeng.module';
import { SoftDataTableComponent } from 'src/app/core/components/soft-data-table/soft-data-table.component';
import { SoftControlsModule } from 'src/app/core/controls/soft-controls.module';
import { CardSkeletonComponent } from 'src/app/core/components/card-skeleton/card-skeleton.component';
import { QRCodeModule } from 'angularx-qrcode';
import { TranslocoDirective } from '@jsverse/transloco';
import { InfoCardComponent } from "../../../core/components/info-card/info-card.component";

@NgModule({
    imports: [
    CommonModule,
    FormsModule,
    MenuModule,
    TableModule,
    StyleClassModule,
    PanelMenuModule,
    ButtonModule,
    DashboardsRoutingModule,
    PrimengModule,
    QRCodeModule,
    SoftDataTableComponent,
    SoftControlsModule,
    CardSkeletonComponent,
    TranslocoDirective,
    InfoCardComponent,
],
    declarations: [DashboardComponent],
    providers:[ApiService]
})
export class DashboardModule { }
""";
        }

        private string GetDashboardComponentTsData()
        {
            return $$"""
import { ApiService } from '../../../business/services/api/api.service';
import { LayoutService } from '../../services/app.layout.service';
import { Component, OnInit } from '@angular/core';
import { SoftMessageService } from 'src/app/core/services/soft-message.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { firstValueFrom, Subscription } from 'rxjs';

@Component({
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {
  private permissionsSubscription: Subscription | null = null;

  constructor(
    public layoutService: LayoutService,
    private apiService: ApiService,
    private messageService: SoftMessageService,
    private authService: AuthService,
  ) {}

  ngOnInit() {
    
  }

  ngOnDestroy(): void {
    
  }
}

""";
        }

        private string GetDashboardComponentHtmlData()
        {
            return $$"""
<ng-container *transloco="let t">
  Dashboard
</ng-container>
""";
        }

        private string GetDashboardRoutingModuleTsData()
        {
            return $$"""
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: DashboardComponent }
    ])],
    exports: [RouterModule]
})
export class DashboardsRoutingModule { }

""";
        }

        private string GetAuthModuleTsData()
        {
            return $$"""
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { PrimengModule } from '../../../core/modules/primeng.module';
import { SoftControlsModule } from 'src/app/core/controls/soft-controls.module';
import { AuthComponent } from './partials/auth.component';
import { TranslocoDirective } from '@jsverse/transloco';
import { LoginVerificationComponent } from 'src/app/core/components/email-verification/login-verification.component';
import { RegistrationVerificationComponent } from 'src/app/core/components/email-verification/registration-verification.component';

const routes: Routes = [
    { 
        path: 'registration', 
        component: RegistrationComponent
    },
    { 
        path: 'login', 
        component: LoginComponent
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
        AuthComponent,
        PrimengModule,
        SoftControlsModule,
        LoginVerificationComponent,
        RegistrationVerificationComponent,
        TranslocoDirective,
    ],
    declarations: [
        RegistrationComponent,
        LoginComponent,
    ]
})
export class AuthModule { }
""";
        }

        private string GetRegistrationComponentTsData()
        {
            return $$"""
import { ActivatedRoute, Router } from '@angular/router';
import { SoftMessageService } from '../../../../core/services/soft-message.service';
import { AuthService } from '../../../../core/services/auth.service';
import { ChangeDetectorRef, Component, KeyValueDiffers, OnInit } from '@angular/core';
import { LayoutService } from '../../../services/app.layout.service';
import { BaseForm } from '../../../../core/components/base-form/base-form';
import { HttpClient } from '@angular/common/http';
import { VerificationTypeCodes } from 'src/app/core/enums/verification-type-codes';
import { Registration } from 'src/app/business/entities/security-entities.generated';
import { TranslocoService } from '@jsverse/transloco';
import { TranslateClassNamesService } from 'src/app/business/services/translates/merge-class-names';
import { ValidatorService } from 'src/app/business/services/validators/validation-rules';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
})
export class RegistrationComponent extends BaseForm<Registration> implements OnInit {
    companyName: string;
    showEmailSentDialog: boolean = false;
    verificationType: VerificationTypeCodes = VerificationTypeCodes.Login;

    constructor(
      protected override differs: KeyValueDiffers,
      protected override http: HttpClient,
      protected override messageService: SoftMessageService, 
      protected override changeDetectorRef: ChangeDetectorRef,
      protected override router: Router,
      protected override route: ActivatedRoute,
      protected override translocoService: TranslocoService,
      protected override translateClassNamesService: TranslateClassNamesService,
      protected override validatorService: ValidatorService,
      public layoutService: LayoutService, 
      private authService: AuthService, 
    ) { 
        super(differs, http, messageService, changeDetectorRef, router, route, translocoService, translateClassNamesService, validatorService);
    }

    override ngOnInit(){
        this.init(new Registration());
    }

    init(model: Registration){
        this.initFormGroup(model);
    }

    companyNameChange(companyName: string){
        this.companyName = companyName;
    }

    sendRegistrationVerificationEmail() {
        let isFormGroupValid: boolean = this.checkFormGroupValidity();
        if (isFormGroupValid == false) return;
        // const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
        this.authService.sendRegistrationVerificationEmail(this.model).subscribe(registrationVerificationResult => {
            this.showEmailSentDialog = true;
        });
    }

}
""";
        }

        private string GetRegistrationComponentHtmlData()
        {
            return $$$"""
<ng-container *transloco="let t">
    @if (showEmailSentDialog == false) {
        <auth (onCompanyNameChange)="companyNameChange($event)">
            <form [formGroup]="formGroup" style="margin-bottom: 16px;"> <!-- FT: We are not loading anything from the server here so we don't need defer block -->
                <div class="col-12" style="padding-left: 0; padding-right: 0;">
                    <soft-textbox [control]="control('email')"></soft-textbox>
                </div>

                <div class="mb-4 gap-5">
                    <div class="text-center" style="font-size: smaller;">
                        {{t('AgreementsOnRegister')}} <b class="primary-color cursor-pointer">{{t('UserAgreement')}}</b>, <b class="primary-color cursor-pointer">{{t('PrivacyPolicy')}}</b>, {{t('and')}} <b class="primary-color cursor-pointer">{{t('CookiePolicy')}}</b>.
                    </div>
                </div>

                <div style="display: flex; flex-direction: column; gap: 16px;">
                    <p-button [label]="t('AgreeAndJoin')" (onClick)="sendRegistrationVerificationEmail()" [outlined]="true" [style]="{width: '100%'}"></p-button>
                    <p-button [label]="t('AlreadyHasProfile', {companyName: companyName})" routerLink="/auth/login" [style]="{width: '100%'}"></p-button>
                </div>
            </form>
        </auth>
    }
    @else {
        <registration-verification [email]="model.email"></registration-verification>
    }
</ng-container>
""";
        }

        private string GetAuthComponentTsData()
        {
            return $$"""
import { Component, EventEmitter, Input, Output } from "@angular/core";
import { environment } from "src/environments/environment";
import { LayoutService } from "src/app/layout/services/app.layout.service";
import { GoogleButtonComponent } from "../../../../core/components/google-button/google-button.component";
import { CommonModule } from "@angular/common";
import { getHtmlImgDisplayString64 } from "src/app/core/services/helper-functions";
import { Subscription } from "rxjs";
import { TranslocoDirective } from "@jsverse/transloco";

@Component({
  selector: 'auth',
  templateUrl: './auth.component.html',
  styles: [],
  imports: [
    CommonModule,
    GoogleButtonComponent,
    TranslocoDirective,
  ],
  standalone: true,
})
export class AuthComponent {
    @Output() onCompanyNameChange: EventEmitter<string> = new EventEmitter();
    @Input() showGoogleAuth: boolean = true;

    hasGoogleAuth: boolean = environment.googleAuth;
    companyName: string;
    image: string;

    constructor(public layoutService: LayoutService) {}

    ngOnInit(){
        this.image = `assets/primeng/images/logo-dark.svg`
        this.companyName = environment.companyName;
        this.onCompanyNameChange.next(this.companyName);
    }

    onGoogleSignIn(googleWrapper: any){
      googleWrapper.click();
    }

    ngOnDestroy(): void {

    }
}
""";
        }

        private string GetAuthComponentHtmlData()
        {
            return $$$"""
<ng-container *transloco="let t">
    <div class="flex min-h-screen overflow-hidden" style="padding: 20px;">
        <div class="flex flex-column w-full">
            <div class="w-full sm:w-30rem" style="margin: auto; border-radius:50px; padding:0.3rem; background: linear-gradient(180deg, var(--primary-color) 10%, rgba(33, 150, 243, 0) 30%);">
                <div class="surface-card py-6 px-5 sm:px-6" style="border-radius:45px;">
                    <div class="text-center" style="margin-bottom: 38px;">
                        <img [src]="image" alt="{{companyName}} Logo" height="60">
                    </div>

                    <ng-content></ng-content>

                    <div *ngIf="hasGoogleAuth && showGoogleAuth">
                        <div style="display: flex; align-items: center; gap: 7px; justify-content: center; margin-bottom: 16px;">
                            <div class="separator"></div>
                            <div>{{t('or')}}</div>
                            <div class="separator"></div>
                        </div>
                        <div>
                            <!-- https://code-maze.com/how-to-sign-in-with-google-angular-aspnet-webapi/ -->
                            <google-button (loginWithGoogle)="onGoogleSignIn($event)"></google-button> 
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</ng-container>
""";
        }

        private string GetLoginComponentTsData()
        {
            return $$"""
import { ActivatedRoute, Router } from '@angular/router';
import { SoftMessageService } from '../../../../core/services/soft-message.service';
import { AuthService } from './../../../../core/services/auth.service';
import { ChangeDetectorRef, Component, KeyValueDiffers, OnInit } from '@angular/core';
import { LayoutService } from '../../../services/app.layout.service';
import { BaseForm } from '../../../../core/components/base-form/base-form';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { VerificationTypeCodes } from 'src/app/core/enums/verification-type-codes';
import { Login } from 'src/app/business/entities/security-entities.generated';
import { TranslocoService } from '@jsverse/transloco';
import { TranslateClassNamesService } from 'src/app/business/services/translates/merge-class-names';
import { ValidatorService } from 'src/app/business/services/validators/validation-rules';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent extends BaseForm<Login> implements OnInit {
    companyName: string;
    usersCanRegister: boolean = environment.usersCanRegister;
    showEmailSentDialog: boolean = false;
    verificationType: VerificationTypeCodes = VerificationTypeCodes.Login;

    constructor(
      protected override differs: KeyValueDiffers,
      protected override http: HttpClient,
      protected override messageService: SoftMessageService, 
      protected override changeDetectorRef: ChangeDetectorRef,
      protected override router: Router, 
      protected override route: ActivatedRoute,
      protected override translocoService: TranslocoService,
      protected override translateClassNamesService: TranslateClassNamesService,
      protected override validatorService: ValidatorService,
      public layoutService: LayoutService, 
      private authService: AuthService, 
    ) { 
      super(differs, http, messageService, changeDetectorRef, router, route, translocoService, translateClassNamesService, validatorService);
    }

    override ngOnInit(){
        this.init(new Login());
    }

    init(model: Login){
        this.initFormGroup(model);
    }

    companyNameChange(companyName: string){
      this.companyName = companyName;
    }

    sendLoginVerificationEmail() {
        let isFormGroupValid: boolean = this.checkFormGroupValidity();
        if (isFormGroupValid == false) return;
        this.authService.sendLoginVerificationEmail(this.model).subscribe(()=>{
            this.showEmailSentDialog = true;
        });
    }

}
""";
        }

        private string GetLoginComponentHtmlData()
        {
            return $$$"""
<ng-container *transloco="let t">
    @if (showEmailSentDialog == false) {
        <auth (onCompanyNameChange)="companyNameChange($event)">
            <form [formGroup]="formGroup" style="margin-bottom: 16px;"> <!-- FT: We are not loading anything from the server here so we don't need defer block -->
                <div class="col-12" style="padding-left: 0; padding-right: 0; margin-bottom: 32px;">
                    <soft-textbox textbox [control]="control('email')"></soft-textbox>
                </div>

                <div style="display: flex; flex-direction: column; gap: 16px;">
                    <p-button [label]="t('Login')" (onClick)="sendLoginVerificationEmail()" [outlined]="true" [style]="{width: '100%'}"></p-button>
                    <p-button *ngIf="usersCanRegister" [label]="t('NewJoinNow', {companyName: companyName})" routerLink="/auth/registration" [style]="{width: '100%'}"></p-button>
                </div>
            </form>
        </auth>
    }
    @else {
        <login-verification [email]="model.email"></login-verification>
    }
</ng-container>
""";
        }

        private string GetVercelJsonData()
        {
            return $$"""
{
    "rewrites": [{ "source": "/(.*)", "destination": "/src/index.html" }]
}
""";
        }

        private string GetTsConfigSpecJsonData()
        {
            return $$"""
/* To learn more about this file see: https://angular.io/config/tsconfig. */
{
  "extends": "./tsconfig.json",
  "compilerOptions": {
    "outDir": "./out-tsc/spec",
    "types": [
      "jasmine",
      "@angular/localize"
    ]
  },
  "include": [
    "src/**/*.spec.ts",
    "src/**/*.d.ts"
  ]
}
""";
        }

        private string GetTsConfigJsonData()
        {
            return $$"""
/* To learn more about this file see: https://angular.io/config/tsconfig. */
{
  "compileOnSave": false,
  "compilerOptions": {
    "baseUrl": "./",
    "paths": {
      "@core/*": ["app/core/*"]
    },
    "outDir": "./dist/out-tsc",
    "forceConsistentCasingInFileNames": true,
    "strict": false,
    "noImplicitOverride": true,
    "noPropertyAccessFromIndexSignature": true,
    "noImplicitReturns": true,
    "noFallthroughCasesInSwitch": true,
    "sourceMap": true,
    "declaration": false,
    "downlevelIteration": true,
    "importHelpers": true,
    "module": "ES2022",
    // "module": "es2020",
    "moduleResolution": "node",
    "experimentalDecorators": true,
    "target": "ES2022",
    // "target": "es5",
    "resolveJsonModule": true,
    "useDefineForClassFields": false,
    "lib": [
      "ES2022",
      // "es2021",
      "dom"
    ]
  },
  "exclude": ["node_modules", "**/node_modules/*"],
  "angularCompilerOptions": {
    "enableI18nLegacyMessageIdFormat": false,
    "fullTemplateTypeCheck": true,
    "strictInjectionParameters": true,
    "strictInputAccessModifiers": true,
    "strictTemplates": true,
    "strictInputTypes": true,
  }
}

""";
        }

        private string GetTsConfigAppJsonData()
        {
            return $$"""
/* To learn more about this file see: https://angular.io/config/tsconfig. */
{
  "extends": "./tsconfig.json",
  "compilerOptions": {
    "outDir": "./out-tsc/app",
    "types": [
      "@angular/localize"
    ]
  },
  "files": [
    "src/main.ts"
  ],
  "include": [
    "src/**/*.d.ts"
  ]
}

""";
        }

        private string GetPackageData(string projectName)
        {
            return $$"""
{
  "name": "{{projectName.ToLower()}}.spa",
  "version": "0.0.0",
  "scripts": {
    "ng": "ng",
    "start": "ng serve --port=4200 --open --configuration=development",
    "build": "ng build",
    "watch": "ng build --watch --configuration development",
    "test": "ng test",
    "i18n:extract": "transloco-keys-manager extract --langs en sr-Latn-RS",
    "i18n:find": "transloco-keys-manager find"
  },
  "private": true,
  "dependencies": {
    "@abacritt/angularx-social-login": "2.2.0",
    "@angular/animations": "17.0.0",
    "@angular/cdk": "17.2.0",
    "@angular/common": "17.0.0",
    "@angular/compiler": "17.0.0",
    "@angular/core": "17.0.0",
    "@angular/forms": "17.0.0",
    "@angular/platform-browser": "17.0.0",
    "@angular/platform-browser-dynamic": "17.0.0",
    "@angular/router": "17.0.0",
    "@jsverse/transloco": "7.5.0",
    "angularx-qrcode": "17.0.1",
    "file-saver": "^2.0.5",
    "json-parser": "^3.1.2",
    "json.date-extensions": "^1.2.2",
    "ngx-spinner": "^16.0.2",
    "primeflex": "^3.3.1",
    "primeicons": "^7.0.0",
    "primeng": "^17.18.9",
    "quill": "^2.0.2",
    "rxjs": "~7.8.0",
    "tslib": "^2.3.0",
    "webpack-dev-server": "^4.15.1",
    "zone.js": "^0.14.10"
  },
  "devDependencies": {
    "@angular-devkit/build-angular": "17.0.7",
    "@angular/cli": "17.0.7",
    "@angular/compiler-cli": "17.0.0",
    "@angular/localize": "17.0.0",
    "@jsverse/transloco-keys-manager": "^5.1.0",
    "@types/jasmine": "~5.1.0",
    "jasmine-core": "~5.1.0",
    "karma": "~6.4.0",
    "karma-chrome-launcher": "~3.2.0",
    "karma-coverage": "~2.2.0",
    "karma-jasmine": "~5.1.0",
    "karma-jasmine-html-reporter": "~2.1.0",
    "typescript": "~5.2.2"
  }
}
""";
        }

        private string GetAngularJsonData(string appName)
        {
            return $$"""
{
  "$schema": "./node_modules/@angular/cli/lib/config/schema.json",
  "version": 1,
  "newProjectRoot": "projects",
  "projects": {
    "{{appName}}.SPA": {
      "projectType": "application",
      "schematics": {
        "@schematics/angular:component": {
          "style": "scss",
          "standalone": false
        },
        "@schematics/angular:directive": {
          "standalone": false
        },
        "@schematics/angular:pipe": {
          "standalone": false
        }
      },
      "root": "",
      "sourceRoot": "src",
      "prefix": "app",
      "architect": {
        "build": {
          "builder": "@angular-devkit/build-angular:application",
          "options": {
            "outputPath": "dist/{{appName}}.SPA",
            "index": "src/index.html",
            "browser": "src/main.ts",
            "polyfills": [
              "zone.js"
            ],
            "tsConfig": "tsconfig.app.json",
            "inlineStyleLanguage": "scss",
            "assets": [
              "src/favicon.ico",
              "src/assets",
              "src/robots.txt"
            ],
            "styles": [
              "src/assets/styles.scss",
              "node_modules/ngx-spinner/animations/ball-clip-rotate-multiple.css"
            ],
            "scripts": []
          },
          "configurations": {
            "production": {
              "budgets": [
                {
                  "type": "initial",
                  "maximumWarning": "1mb",
                  "maximumError": "2mb"
                },
                {
                  "type": "anyComponentStyle",
                  "maximumWarning": "2kb",
                  "maximumError": "4kb"
                }
              ],
              "outputHashing": "all",
              "fileReplacements": [
                {
                  "replace": "src/environments/environment.ts",
                  "with": "src/environments/environment.prod.ts"
                }
              ]
            },
            "development": {
              "optimization": false,
			  "extractLicenses": false,
              "sourceMap": true,
			  "outputHashing": "all",
			  "namedChunks": true,
              "aot": true
            }
          },
          "defaultConfiguration": "production"
        },
        "serve": {
          "builder": "@angular-devkit/build-angular:dev-server",
          "configurations": {
            "production": {
              "buildTarget": "{{appName}}.SPA:build:production"
            },
            "development": {
              "buildTarget": "{{appName}}.SPA:build:development"
            }
          },
          "defaultConfiguration": "development"
        },
        "extract-i18n": {
          "builder": "@angular-devkit/build-angular:extract-i18n",
          "options": {
            "buildTarget": "{{appName}}.SPA:build"
          }
        },
        "test": {
          "builder": "@angular-devkit/build-angular:karma",
          "options": {
            "polyfills": [
              "zone.js",
              "zone.js/testing"
            ],
            "tsConfig": "tsconfig.spec.json",
            "inlineStyleLanguage": "scss",
            "assets": [
              "src/assets"
            ],
            "styles": [
              "src/assets/styles.scss"
            ],
            "scripts": []
          }
        }
      }
    }
  },
  "cli": {
    "analytics": false
  }
}
""";
        }

        private string GetEditOrConfigData()
        {
            return $$"""
# Editor configuration, see https://editorconfig.org
root = true

[*]
charset = utf-8
indent_style = space
indent_size = 2
insert_final_newline = true
trim_trailing_whitespace = true

[*.ts]
quote_type = single

[*.md]
max_line_length = off
trim_trailing_whitespace = false
""";
        }

        private string GetMainTsData()
        {
            return $$"""
/// <reference types="@angular/localize" />

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
""";
        }

        private string GetIndexHtmlData(string appName)
        {
            return $$"""
<!doctype html>
<html lang="sr-Latn-RS">
<head>
  <meta charset="utf-8">
  <title>{{appName.SpaceEveryUpperChar()}}</title>
  <meta name="description" content="{{appName.SpaceEveryUpperChar()}}">
  <meta name="author" content="{{appName.SpaceEveryUpperChar()}}">
  <base href="/">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="icon" type="image/x-icon" href="./assets/demo/images/logo/favicon.ico">
</head>
<body>
  <app-root></app-root>
</body>
</html>
""";
        }

        private string GetEnvironmentTsCode(string appName, string primaryColor)
        {
            return $$"""
import { HttpHeaders, HttpParams } from "@angular/common/http";

export const environment = {
    production: false,
    apiUrl: 'https://localhost:44388/api',
    frontendUrl: 'http://localhost:4200',
    googleAuth: true,
    googleClientId: '24372003240-44eprq8dn4s0b5f30i18tqksep60uk5u.apps.googleusercontent.com',
    companyName: '{{appName.SpaceEveryUpperChar()}}',
    primaryColor: '{{primaryColor}}',
    usersCanRegister: true,
    httpOptions: {
      // headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    },
    httpSkipSpinnerOptions: {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      params: new HttpParams().set('X-Skip-Spinner', 'true')
    },

    /* URLs */
    loginSlug: 'auth/login',
    administrationSlug: 'administration',

    /* Local storage */
    accessTokenKey: 'access_token',
    refreshTokenKey: 'refresh_token',
    browserIdKey: 'browser_id',

    /* Query params */

  };
""";
        }

        private string GetStylesScssCode()
        {
            return $$"""
/* You can add global styles to this file, and also import other style files */

$gutter: 1rem; //for primeflex grid system
@import "./primeng/styles/layout/layout.scss";

/* PrimeNG */
@import "./primeng/styles/themes/saga/saga-blue/theme.scss";

@import "../../node_modules/primeng/resources/primeng.min.css";
@import "../../node_modules/primeflex/primeflex.scss";
@import "../../node_modules/primeicons/primeicons.css";
// PrimeNG editor
@import "../../node_modules/quill/dist/quill.core.css";
@import "../../node_modules/quill/dist/quill.snow.css";


@import "shared.scss";
""";
        }

        private string GetSharedScssCode()
        {
            return $$"""
@import './primeng/styles/layout/variables';

.table-header {
	display: flex;
	justify-content: space-between; 
	align-items: center;
}

@media (max-width: 640px) {
	.table-header {
		display: flex;
		flex-direction: column;
		align-items: start;
		gap: 14px;
	}
}

.c-dashboard-item {
	position: relative;
	display: flex;
	flex-direction: column;
	justify-content: flex-start;
	align-items: center;
	border: solid 1px #e0e0e0;
	border-radius: 5px;
	padding: 20px 30px;
	flex-grow:1;

	&__icon {
		margin-bottom: 10px;
		font-size: 3.2em;
	}
	&__title {
		font-size: 1.1em;
		text-align: center;
		text-decoration: none !important;
	}
	&__bullets {

	}
	&__bullet {

	}

	&__bg {
		position: absolute;
		top: 0px;
		bottom: 0px;
		left: 0px;
		right: 0px;
		background-color: #fff;
		z-index: -5;

		&-icon {
			position: absolute;
			bottom: 0px;
			right: 30px;
			font-size: 15em;
			//transform: rotate(-45deg);
			opacity: 0.04;
			text-decoration: none !important;
		}
	}

	&--eo {
		min-height: 200px;
	}
	&--codebooks {
		min-height: 100px;
		cursor: pointer;
	}
	&--home {
		min-height: 160px;
		cursor: pointer;
    z-index: 1;
		&:hover {
			text-decoration: none;

			.c-dashboard-item__bg {
				background-color: #f8f8f8;
			}
			.c-dashboard-item__bg-icon {
				opacity: 0.2;
				transform: rotate(0deg);
			}
		}

		.c-dashboard-item__icon {
			font-size: 4em;
		}
		.c-dashboard-item__title {
			font-size: 1.3em;
		}
		.c-dashboard-item__bg-icon {
			font-size: 9em;
			right: 40px;
			bottom: 20px;
			transform: rotate(-20deg);
			opacity: 0.1;
			transition: all 1s;
		}
	}
}

.error-color{
	background-color: $errorColor;
}

.error-color-font{
	color: $errorColor;
}

.success-color-font{
	color: green;
}

.error-color-light{
	background-color: $errorColorLight;
}

.soft-table {
	.p-paginator {
		padding: 1rem;
	}
	.p-paginator-left-content {
		@media (min-width: 1400px) {			
			position: absolute;
			padding: 14px;
			left: 0;
		}
	}
	.p-paginator-right-content {
		@media (min-width: 1400px) {			
			position: absolute;
			padding: 14px;
			right: 0;
		}
	}
}

.soft-panel{
	.p-panel-content{
		padding: 0;
	}

	.soft-panel-footer{
		display: flex; 
		align-items: center; 
		justify-content: space-between; 
		gap: 10px; 
		border-top: 1px solid #dee2e6;
		border-bottom-right-radius: 12px;
    	border-bottom-left-radius: 12px;
		padding: 1rem;
	}
}

.disabled{
	background-color: $disabled;
}

.primary-color{
	color: var(--primary-color);
}

.primary-color-background{
	background-color: var(--primary-color);
}

.primary-lighter-color-background{
	background-color: var(--primary-lighter-color);
}

.bold {
	font-weight: 500;
}

.separator{
	border-top: 1px solid var(--primary-color);
	width: 100%;
}

.gray-separator{
	border-top: 1px solid $shade400;
	width: 100%;
}

// FT: You need to manually adjust the height
.vertical-gray-separator{
	border-left: 1px solid $shade400;
}



.google-signin-button {
	width: 100%;
	max-width: 300px;
}

.hover-card {
	padding: 10px;
	border-radius: 12px;
	cursor: pointer;
}

.hover-card:hover {
	background-color: $disabled;
}

.dialog{
	width: 600px;
}

@media (max-width: 600px) {
	.dialog{
		width: 100%;
	}
}

.header{
	font-size: 17.5px;
}

.header-separator{
	margin-top: 7px;
	border-top: 3px solid var(--primary-color);
	width: 60px;
}

.big-header{
	font-size: 34px; 
	font-weight: 400;
	i{
		font-size: 32px; 
		font-weight: 400;
	}
}

.bold-header-separator{
	margin-top: 7px;
	border-top: 6px solid var(--primary-color);
	width: 100px;
}

@media (max-width: 600px) {
	.big-header{
		font-size: 28px;
		i{
			font-size: 26px; 
			font-weight: 400;
		}
	}
}

.link{
	color: var(--primary-color);
	cursor: pointer;
}

.link:hover {
	color: var(--primary-dark-color);
}

.blockHead {
	background-color: var(--primary-color);
	/*width: 150px; */
	height: 60px;
	line-height: 60px;
	display: inline-block;
	position: relative;
  }

.blockHead:after {
	color: var(--primary-color);
	border-left: 30px solid;
	border-top: 30px solid transparent;
	border-bottom: 30px solid transparent;
	display: inline-block;
	content: '';
	position: absolute;
	right: -30px;
	top:0
}

.blocktext{
	color:white;
	font-weight:bold;
	padding-left:10px;
	font-family:Arial;
	font-size:11;
}

.qr-component-wrapper{
	display: flex; 
	gap: 13px; 
	align-items: center;
	.text-wrapper{
		width: 60%;
	}
}

@media (max-width: 600px) {
	.qr-component-wrapper{
		display: flex; 
		flex-direction: column;
		gap: 13px;
		align-items: unset;
		.text-wrapper{
			padding-top: 20px;
			padding-bottom: 20px;
			margin-bottom: 10px;
			width: 100%;
			border-bottom: 1px solid $shade400;
			width: 100%;
		}
	}
}

@media (max-width: 600px) {
	.responsive-hidden{
		display: none;
	}
}

.qr-code{
	border: 2px solid var(--primary-dark-color);
}

.notification-border{
	border-top: 1px solid var(--primary-light-color);
	border-left: 1px solid var(--primary-light-color);
	border-right: 1px solid var(--primary-light-color);
}

.notification-border:last-child {
    border-bottom: 1px solid var(--primary-light-color);
}

.card-overflow-icon{
    text-align: center;
	transform: rotate(30deg);
	color: var(--primary-light-color);
	opacity: 0.2;
	position: absolute; 
	overflow: hidden; 
	right: -30px; 
	top: -25px; 
	z-index: 1;
	i {
		font-size: 270px;
	}
}

.badge {
	position: absolute;
	width: 10px;
	height: 10px;
	top: -5px;
	right: -1px;
	border-radius: 100%;
	background: $dangerButtonBg;
  }

.dashboard-card-wrapper {
	display: flex; 
	flex-direction: column; 
	gap: 14px; 
	padding: 30px;
	position: relative; 
	overflow: hidden;
}

@media (max-width: 600px) {
	.dashboard-card-wrapper{
		padding: 20px;
	}
}

.dashboard-card-wrapper-with-grid {
	display: flex; 
	flex-direction: column; 
	gap: 14px; 
	padding: 30px;
	padding-bottom: 16px; // -14px
	position: relative; 
	overflow: hidden;
}

@media (max-width: 600px) {
	.dashboard-card-wrapper-with-grid{
		padding: 20px;
		padding-bottom: 6px; // -14px
	}
}

.icon-hover {
	cursor: pointer;
	padding: 7px;
	border-radius: 50%;
	transition: background-color 0.3s ease;
}

.icon-hover:hover {
	background-color: $shade200;
}

.gray-color {
	color: $shade600;
}

.multiple-panel-first{
	.p-panel .p-panel-content {
		border-bottom-left-radius: 0px;
		border-bottom-right-radius: 0px;
		border-bottom: none;
	}
}

.multiple-panel-middle{
	.p-panel-header {
		border-top-left-radius: 0px;
		border-top-right-radius: 0px;
	}

	.p-panel .p-panel-content {
		border-bottom-left-radius: 0px;
		border-bottom-right-radius: 0px;
		border-bottom: none;
	}
}

.multiple-panel-last{
	.p-panel-header {
		border-top-left-radius: 0px;
		border-top-right-radius: 0px;
	}
}

.index-card-wrapper {
	.text {
		.header {
			font-size: large;
			font-weight: 500;
			color: rgb(131, 131, 131);
			margin-bottom: 5px;
		}
		.description {
			font-size: small;
			color: rgb(150, 150, 150);
		}
	}
}

.last-card-child {
	margin-bottom: 0px !important;
}

.number-circle {
	border-radius: 50%;
	width: 30px;
	height: 30px;
	padding: 5px;

	background: var(--primary-dark-color);
	border: 1px solid var(--primary-dark-color);
	color: white;
	text-align: center;
	margin-right: 16px;
	display: inline-block;
}

.non-grid-panel-bottom-padding{
	padding-bottom: 14px;
}

@media (max-width: 600px) {
	.non-grid-panel-bottom-padding{
		padding-bottom: 0px;
	}
}

.panel-body-wrapper{
	padding: 28px; 
	padding-bottom: 14px;
}

@media (max-width: 600px) {
	.panel-body-wrapper{
		padding: 14px; 
		padding-bottom: 0px;
	}
}

@media (max-width: 600px) {
	.panel-add-button{
		margin-bottom: 14px;
	}
}

.last-child-zero-margin{
	margin-bottom: 0px !important;
}

.card-margin-bottom{
	margin-bottom: 28px;
}

@media (max-width: 600px) {
	.card-margin-bottom{
		margin-bottom: 14px;
	}
}

.card-with-grid-padding-bottom{
	padding-bottom: 14px !important;
}

@media (max-width: 600px) {
	.card-with-grid-padding-bottom{
		padding-bottom: 6px !important;
	}
}

.responsive-card-padding{
	padding: 28px;
}

@media (max-width: 600px) {
	.responsive-card-padding{
		padding: 20px;
	}
}

.image-container {
    width: 300px;
    height: 300px;
	display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden;
}

.image-container img {
	object-fit: cover;
}

.p-dataview .p-dataview-header {
    background: transparent;
    color: transparent;
    border: none;
    border-width: 0;
    padding: 0;
    font-weight: 0;
}
""";
        }

        private string GetTranslocoSrLatnRSJsonCode()
        {
            return $$$"""
{
    "Submit": "Potvrdite",
    "UserList": "Korisnici",
    "SuperRoles": "Super uloge",
    "Save": "Sačuvajte",
    "PermissionList": "Dozvole",
    "NotificationList": "Notifikacije",
    "NotifyUsers": "Obavestite korisnike",
    "Recipients": "Primaoci",
    "SendEmailNotification": "Pošaljite email notifikaciju",
    "AgreementsOnRegister": "Klikom na Slažem se i pridružujem ili Nastavite, prihvatate",
    "UserAgreement": "uslove korišćenja",
    "PrivacyPolicy": "politiku privatnosti",
    "and": "i",
    "CookiePolicy": "politiku upotrebe kolčića",
    "AgreeAndJoin": "Slažem se i pridružujem",
    "AlreadyHasProfile": "Već imate profil? Prijavite se",
    "NewJoinNow": "Novi ste? Napravite profil",
    "ContinueWithGoogle": "Nastavite sa Google nalogom",
    "or": "ili",
    "All": "Sve",
    "AccountVerificationHeader": "Verifikacija profila",
    "AccountVerificationTitle": "Verifikujte svoju email adresu",
    "AccountVerificationDescription": "Poslali smo vam verifikacioni kod na {{ email }}. Molimo vas da proverite inbox ili spam folder i unesete kod koji smo vam poslali kako biste završili proces. Hvala!",
    "GoToGmail": "Idi na Gmail",
    "GoToYahoo": "Idi na Yahoo",
    "ResendVerificationCodeFirstPart": "Ako niste pronašli, možete",
    "ResendVerificationCodeLinkSecondPart": "ponovo poslati verifikacioni kod.",
    "ForgotPassword": "Zaboravili ste lozinku?",
    "Login": "Prijavite se",
    "RememberYourPassword": "Setili ste se lozinke?",
    "ResetPassword": "Promenite lozinku",
    "DragAndDropFilesHereToUpload": "Ovde prevucite i otpustite datoteke da biste ih otpremili.",
    "PleaseConfirmToProceed": "Molimo Vas potvrdite da biste nastavili.",
    "Cancle": "Odustanite",
    "Confirm": "Potvrdite",
    "Clear": "Uklonite",
    "ExportToExcel": "Izvezite u Excel",
    "Select": "Odaberite",
    "NoRecordsFound": "Ne postoji nijedan zapis.",
    "Loading": "Učitavanje",
    "TotalRecords": "Ukupno zapisa",
    "AddNew": "Dodajte",
    "Return": "Nazad",
    "Currency": "RSD",
    "Actions": "Akcije",
    "Details": "Detalji",
    "User": "Korisnik",
    "CreatedAt": "Kreirano",
    "Delete": "Obrišite",
    "Name": "Naziv",
    "Title": "Naslov",
    "SuccessfulAttempt": "Vaš pokušaj je obrađen.",
    "MarkAsRead": "Označite kao pročitano",
    "MarkAsUnread": "Označite kao nepročitano",
    "Email": "Email",
    "Slug": "Url putanja",
    "YourProfile": "Vaš profil",
    "Logout": "Odjavite se",
    "Home": "Početna",
    "SuperAdministration": "Super administracija",
    "Administration": "Administracija",
    "SuccessfullySentVerificationCode": "Verifikacioni kod je uspešno poslat.",
    "YouHaveSuccessfullyVerifiedYourAccount": "Uspešno ste verifikovali svoj profil.",
    "YouHaveSuccessfullyChangedYourPassword": "Uspešno ste promenili lozinku.",
    "SuccessfulAction": "Uspešno izvršena operacija",
    "Warning": "Upozorenje",
    "Error": "Greška",
    "ServerLostConnectionDetails": "Veza je izgubljena. Molimo proverite vašu internet konekciju. Ako se problem nastavi, kontaktirajte naš tim za podršku.",
    "ServerLostConnectionTitle": "Veza je izgubljena",
    "PermissionErrorDetails": "Nemate dozvolu za ovu operaciju.",
    "PermissionErrorTitle": "Nemate dozvolu",
    "NotFoundDetails": "Zatraženi resurs nije pronađen, molimo pokušajte ponovo.",
    "NotFoundTitle": "Nije pronađeno",
    "UnexpectedErrorTitle": "Dogodila se greška",
    "UnexpectedErrorDetails": "Naš tim je obavešten i radimo na rešenju problema. Molimo Vas da pokušate ponovo kasnije.",
    "SelectAColor": "Odaberite boju",
    "DatesBefore": "Datumi pre",
    "DatesAfter": "Datumi posle",
    "Equals": "Jednako",
    "MoreThan": "Više od",
    "LessThan": "Manje od",
    "AreYouSureToDelete": "Da li ste sigurni?",
    "SuccessfullyDeletedMessage": "Uspešno brisanje.",
    "Yes": "Da",
    "No": "Ne",
    "SuccessfulSaveToastDescription": "Uspešno sačuvano.",
    "SuccessfulSyncToastDescription": "Uspešno ste ažurirali podatke.",
    "YouHaveSomeInvalidFieldsDescription": "Neka od polja na formi nisu ispravno uneta, molimo Vas da proverite koja i pokušate ponovo.",
    "YouHaveSomeInvalidFieldsTitle": "Neispravna polja na formi",
    "Remove": "Ukloni",
    "AddAbove": "Dodaj iznad",
    "AddBelow": "Dodaj ispod",
    "ListCanNotBeEmpty": "Lista '{{value}}' ne može biti prazna.",
    "NotEmpty": "Polje ne sme biti prazno.",
    "NotEmptyLengthEmailAddress": "Polje ne sme biti prazno, mora da ima minimum {{min}}, a maksimum {{max}} karaktera i mora biti validna email adresa.",
    "NotEmptyLength": "Polje ne sme biti prazno i mora da ima minimum {{min}}, a maksimum {{max}} karaktera.",
    "NotEmptySingleLength": "Polje ne sme biti prazno i mora da ima {{length}} karaktera.",
    "Length": "Polje mora da ima minimum {{min}}, a maksimum {{max}} karaktera.",
    "NotEmptyNumberRangeMin": "Polje ne sme biti prazno i vrednost mora da bude veća ili jednaka {{min}}.",
    "NumberRangeMin": "Vrednost polja mora da bude veća ili jednaka {{min}}.",
    "SingleLength": "Polje mora da ima {{length}} karaktera.",
    "NotEmptyPrecisionScale": "Vrednost polja mora da ima ukupno {{precision}} cifara, i broj cifara nakon zareza ne sme biti veci od {{scale}}.",
    "IdToken": "/",
    "Browser": "/",
    "NewPassword": "Nova lozinka",
    "ExpireAt": "Ističe",
    "UserEmail": "Email",
    "AccessToken": "/",
    "Token": "/",
    "Password": "Lozinka",
    "RefreshToken": "/",
    "IpAddress": "Ip adresa",
    "Reload": "Osvežite",
    "TokenString": "/",
    "Status": "Status",
    "Message": "Poruka",
    "SelectedPermissionIds": "/",
    "SelectedUserIds": "/",
    "RoleDTO": "/",
    "VerificationCode": "Verifikacioni kod",
    "NameLatin": "Naziv latinicom",
    "Description": "Opis",
    "DescriptionLatin": "Opis latinicom",
    "Code": "Kod",
    "Id": "Id",
    "Version": "Verzija",
    "ModifiedAt": "Izmenjeno",
    "Roles": "Uloge",
    "Users": "Korisnici",
    "ExternalProvider": "/",
    "ForgotPasswordVerificationToken": "/",
    "JwtAuthResult": "/",
    "AuthResult": "/",
    "LoginVerificationToken": "/",
    "RefreshTokenRequest": "/",
    "Registration": "/",
    "RegistrationVerificationResult": "/",
    "RegistrationVerificationToken": "/",
    "RoleSaveBody": "/",
    "VerificationTokenRequest": "/",
    "Permission": "Dozvola",
    "Role": "Uloga",
    "RoleUser": "/",
    "IsMarkedAsRead": "Označeno kao pročitano",
    "Checked": "Čekirano",
    "NotificationDTO": "Notifikacija",
    "TableFilter": "Filter tabele",
    "SelectedIds": "Izabrani",
    "UnselectedIds": "Odčekirani",
    "IsAllSelected": "Sve je izabrano",
    "UserExtendedDTO": "/",
    "SelectedRoleIds": "/",
    "Price": "Cena",
    "Category": "Kategorija",
    "LinkToWebsite": "Link do sajta",
    "EmailBody": "Sadržaj email-a",
    "Notifications": "Notifikacije",
    "LogoImageData": "/",
    "LogoImage": "Logo",
    "PrimaryColor": "Primarna boja",
    "OrderNumber": "Redni broj",
    "ValidFrom": "Važi od",
    "ValidTo": "Važi do",
    "Guid": "Guid",
    "Product": "Proizvod",
    "Transaction": "Transakcija",
    "HasLoggedInWithExternalProvider": "Prijavljen sa eksternim provajderom",
    "NumberOfFailedAttemptsInARow": "Broj neuspešnih pokušaja uzastopno",
    "BirthDate": "Datum rođenja",
    "Gender": "Pol",
    "Notification": "Notifikacija",
    "UserExtended": "Korisnik",
    "Brand": "Brend",
    "NotificationSaveBody": "/",
    "QrCode": "QR kod",
    "NotificationUser": "/",
    "Primeng": {
      "dayNames": [
        "Nedelja",
        "Ponedeljak",
        "Utorak",
        "Sreda",
        "Četvrtak",
        "Petak",
        "Subota"
      ],
      "dayNamesShort": [
        "Ned",
        "Pon",
        "Uto",
        "Sre",
        "Čet",
        "Pet",
        "Sub"
      ],
      "dayNamesMin": [
        "Ne",
        "Po",
        "Ut",
        "Sr",
        "Če",
        "Pe",
        "Su"
      ],
      "monthNames": [
        "Januar",
        "Februar",
        "Mart",
        "April",
        "Maj",
        "Jun",
        "Jul",
        "Avgust",
        "Septembar",
        "Oktobar",
        "Novembar",
        "Decembar"
      ],
      "monthNamesShort": [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "Maj",
        "Jun",
        "Jul",
        "Avg",
        "Sep",
        "Okt",
        "Nov",
        "Dec"
      ],
      "today": "Danas",
      "weekHeader": "Vik",
      "clear": "Uklonite",
      "apply": "Pretražite",
      "emptyMessage": "Nema rezultata",
      "emptyFilterMessage": "Nema rezultata"
    },
    "EmptyMessage": "Nema rezultata",
    "ClearFilters": "Uklonite sve filtere",
    "YouDoNotHaveAnyNotifications": "Nemate nijednu notifikaciju.",
    "More than": "Više od",
    "BadRequestDetails": "Sistem ne može da obradi zahtev. Molimo vas da proverite zahtev i pokušate ponovo."
}
""";
        }

        private string GetTranslocoEnJsonCode()
        {
            return $$"""
{

}
""";
        }

        private string GetAppModuleTsData()
        {
            return $$"""
import { ErrorHandler, NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotfoundComponent } from './core/components/notfound/notfound.component';
import { AppLayoutModule } from './layout/components/layout/app.layout.module';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { MessagesModule } from 'primeng/messages';
import { CoreModule } from './core/modules/core.module';
import { SoftMessageService } from './core/services/soft-message.service';
import { SoftErrorHandler } from './core/handlers/soft-error-handler';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from './business/services/api/api.service';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { SocialLoginModule, SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import { GoogleLoginProvider } from '@abacritt/angularx-social-login';
import { environment } from 'src/environments/environment';
import { BusinessModule } from './business/business.module';
import { SoftTranslocoModule } from './core/modules/soft-transloco.module';

@NgModule({
  declarations: [
    AppComponent,
    NotfoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppLayoutModule,
    MessagesModule,
    ToastModule,
    SocialLoginModule,
    SoftTranslocoModule.forRoot(),
    NgxSpinnerModule.forRoot({ type: 'ball-clip-rotate-multiple' }),
    BusinessModule,
    CoreModule,
  ],
  providers: [
    SoftMessageService,
    MessageService,
    {
    provide: ErrorHandler,
    useClass: SoftErrorHandler,
    },
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              environment.googleClientId, 
              {
                scopes: 'email',
                oneTapEnabled: false,
                prompt: 'none',
                // plugin_name: 'the name of the Google OAuth project you created'
              },
            )
          },
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig
    },
    ApiService,
    NgxSpinnerService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
""";
        }

        private string GetAppComponentTsData()
        {
            return $$"""
import { TranslocoService } from '@jsverse/transloco';
import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

    constructor(private primengConfig: PrimeNGConfig, private translocoService: TranslocoService) { }

    ngOnInit() {
        this.primengConfig.ripple = true; // FT: We are using ripple because of the android mobile devices

        this.translocoService.selectTranslateObject('Primeng').subscribe((primengTranslations) => {
            this.primengConfig.setTranslation(primengTranslations);
          });
    }
}
""";
        }

        private string GetAppComponentHtmlData()
        {
            return $$"""
<!-- FT HACK: I don't know why, but translations on the layout component work only if wrap we everything with transloco -->
<ng-container *transloco="let t">
    <router-outlet></router-outlet>
</ng-container>

<ngx-spinner bdColor="rgba(0, 0, 0, 0.8)" size="medium" color="#fff" type="ball-clip-rotate-multiple" [fullScreen]="true"></ngx-spinner>
<p-toast [breakpoints]="{ '600px': { width: '100%', right: '0', left: '0' } }"></p-toast>
""";
        }

        private string GetAppRoutingModuleTsData()
        {
            return $$"""
import { PreloadAllModules, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NotfoundComponent } from './core/components/notfound/notfound.component';
import { AppLayoutComponent } from "./layout/components/layout/app.layout.component";
import { AuthGuard } from './core/guards/auth.guard';
import { NotAuthGuard } from './core/guards/not-auth.guard';

@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: '', 
                component: AppLayoutComponent,
                children: [
                    {
                        path: '',
                        loadChildren: () => import('./layout/components/dashboard/dashboard.module').then(m => m.DashboardModule),
                        canActivate: [AuthGuard]
                    },
                ],
            },
            {
                path: '',
                children: [
                    { 
                        path: 'auth',
                        loadChildren: () => import('./layout/components/auth/auth.module').then(m => m.AuthModule),
                        canActivate: [NotAuthGuard],
                    },
                ],
            },
            { path: 'not-found', component: NotfoundComponent },
            { path: '**', redirectTo: 'not-found' },
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload', preloadingStrategy: PreloadAllModules })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
""";
        }

        private string GetBusinessModuleTsData()
        {
            return $$"""
import { CommonModule } from '@angular/common';
import { NgModule, Optional, SkipSelf } from '@angular/core';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [
  ],
})
export class BusinessModule {
  constructor(@Optional() @SkipSelf() Business: BusinessModule) {
    if (Business) {
      throw new Error('Business Module can only be imported to AppModule.');
    }
  }
}
""";
        }

        private string GetValidationRulesTsCode()
        {
            return $$"""
import { ValidationErrors } from "@angular/forms";
import { SoftFormArray, SoftFormControl, SoftValidatorFn } from "src/app/core/components/soft-form-control/soft-form-control";
import { TranslocoService } from '@jsverse/transloco';
import { Injectable } from '@angular/core';
import { ValidatorServiceGenerated } from "./validation-rules.generated";

@Injectable({
    providedIn: 'root',
})
export class ValidatorService extends ValidatorServiceGenerated {

    constructor(
        protected override translocoService: TranslocoService,
    ) {
        super(translocoService)
    }

    isArrayEmpty(control: SoftFormControl): SoftValidatorFn {
        const validator: SoftValidatorFn = (): ValidationErrors | null => {
            const value = control.value;

            const notEmptyRule = typeof value !== 'undefined' && value !== null && value.length !== 0;

            const arrayValid = notEmptyRule;

            return arrayValid ? null : { _ : this.translocoService.translate('NotEmpty')};
        };
        validator.hasNotEmptyRule = true;
        control.required = true;
        return validator;
    }

    notEmpty(control: SoftFormControl): void {
        const validator: SoftValidatorFn = (): ValidationErrors | null => {
            const value = control.value;

            const notEmptyRule = typeof value !== 'undefined' && value !== null && value !== '';

            const arrayValid = notEmptyRule;

            return arrayValid ? null : { _ : this.translocoService.translate('NotEmpty')};
        };
        validator.hasNotEmptyRule = true;
        control.required = true;
        control.validator = validator;
        control.updateValueAndValidity();
    }

    isFormArrayEmpty(control: SoftFormArray): SoftValidatorFn {
        const validator: SoftValidatorFn = (): ValidationErrors | null => {
            const value = control;

            const notEmptyRule = typeof value !== 'undefined' && value !== null && value.length !== 0;

            const arrayValid = notEmptyRule;

            return arrayValid ? null : { _ : this.translocoService.translate('NotEmpty')};
        };
        validator.hasNotEmptyRule = true;
        control.required = true;
        return validator;
    }
}
""";
        }

        private string GetMergeLabelsCode()
        {
            return $$"""
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { TranslateLabelsGeneratedService } from "./labels.generated";


@Injectable({
    providedIn: 'root',
})
export class TranslateLabelsService {

    constructor(
        private translateLabelsGeneratedService: TranslateLabelsGeneratedService,
    ) {
    }

    translate(name: string){
        let result = null;

        result = this.translateLabelsGeneratedService.translate(name);
        if (result != null)
            return result;

        return name;
    }
}
""";
        }

        private string GetMergeClassNamesTsCode()
        {
            return $$"""
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { TranslateClassNamesGeneratedService } from "./class-names.generated";

@Injectable({
    providedIn: 'root',
})
export class TranslateClassNamesService {

    constructor(
        private translateClassNamesGeneratedService: TranslateClassNamesGeneratedService,
    ) {
    }

    translate(name: string){
        let result = null;

        result = this.translateClassNamesGeneratedService.translate(name);
        if (result != null)
            return result;

        return name;
    }
}
""";
        }

        private string GetAPIServiceTsCode()
        {
            return $$"""
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiGeneratedService } from './api.service.generated';
import { map, Observable } from 'rxjs';
import * as FileSaver from 'file-saver';
import { TableFilter } from '../../../core/entities/table-filter';
import { PrimengOption } from 'src/app/core/entities/primeng-option';
import { Namebook } from '../../../core/entities/namebook';
import { getFileNameFromContentDisposition } from 'src/app/core/services/helper-functions';
import { Codebook } from 'src/app/core/entities/codebook';

@Injectable()
export class ApiService extends ApiGeneratedService {

    constructor(protected override http: HttpClient) {
        super(http);
    }

    exportListToExcel(exportTableDataToExcelObservableMethod: (tableFilter: TableFilter) => Observable<any>, tableFilter: TableFilter) {
        exportTableDataToExcelObservableMethod(tableFilter).subscribe(res => {
            let fileName = getFileNameFromContentDisposition(res, "ExcelExport.xlsx");
            FileSaver.saveAs(res.body, decodeURIComponent(fileName));
        });
    }

    getPrimengNamebookListForDropdown(getListForDropdownObservable: () => Observable<Namebook[]>): Observable<PrimengOption[]>{
        return getListForDropdownObservable().pipe(
            map(res => {
                return res.map(x => ({ label: x.displayName, value: x.id }));
            })
        );
    }

    getPrimengCodebookListForDropdown(getListForDropdownObservable: () => Observable<Codebook[]>): Observable<PrimengOption[]>{
        return getListForDropdownObservable().pipe(
            map(res => {
                return res.map(x => ({ label: x.displayName, value: x.code }));
            })
        );
    }

    getPrimengNamebookListForAutocomplete(getListForAutocompleteObservable: (limit: number, query: string) => Observable<Namebook[]>, limit: number, query: string): Observable<PrimengOption[]>{
        return getListForAutocompleteObservable(limit, query).pipe(
            map(res => {
                return res.map(x => ({ label: x.displayName, value: x.id }));
            })
        );
    }

    getPrimengCodebookListForAutocomplete(getListForAutocompleteObservable: (limit: number, query: string) => Observable<Codebook[]>, limit: number, query: string): Observable<PrimengOption[]>{
        return getListForAutocompleteObservable(limit, query).pipe(
            map(res => {
                return res.map(x => ({ label: x.displayName, value: x.code }));
            })
        );
    }
}
""";
        }

        private string GetAPIServiceSecurityTsCode()
        {
            return $$"""
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Namebook } from '../../../core/entities/namebook';
import { TableFilter } from '../../../core/entities/table-filter';
import { TableResponse } from 'src/app/core/entities/table-response';
import { Login, Registration, RegistrationVerificationResult, RefreshTokenRequest, AuthResult, Role } from '../../entities/security-entities.generated';

@Injectable()
export class ApiSecurityService {

    constructor(protected http: HttpClient) {

    }

    //#region Authentication

    sendLoginVerificationEmail = (loginDTO: Login): Observable<any> => { 
        return this.http.post<any>(`${environment.apiUrl}/Security/SendLoginVerificationEmail`, loginDTO, environment.httpOptions);
    }

    sendRegistrationVerificationEmail = (registrationDTO: Registration): Observable<RegistrationVerificationResult> => { 
        return this.http.post<RegistrationVerificationResult>(`${environment.apiUrl}/Security/SendRegistrationVerificationEmail`, registrationDTO, environment.httpOptions);
    }

    logout = (browserId: string): Observable<any> => { 
        return this.http.get<any>(`${environment.apiUrl}/Security/Logout?browserId=${browserId}`);
    }

    refreshToken = (request: RefreshTokenRequest): Observable<AuthResult> => { 
        return this.http.post<AuthResult>(`${environment.apiUrl}/Security/RefreshToken`, request, environment.httpOptions);
    }

    //#endregion

    //#region Role

    getRoleTableData = (dto: TableFilter): Observable<TableResponse> => { 
        return this.http.post<TableResponse>(`${environment.apiUrl}/Security/GetRoleTableData`, dto, environment.httpSkipSpinnerOptions);
    }

    exportRoleTableDataToExcel = (dto: TableFilter): Observable<any> => { 
        return this.http.post<any>(`${environment.apiUrl}/Security/ExportRoleTableDataToExcel`, dto, environment.httpOptions);
    }

    deleteRole = (id: number): Observable<any> => { 
        return this.http.delete<any>(`${environment.apiUrl}/Security/DeleteRole?id=${id}`);
    }

    getRole = (id: number): Observable<Role> => {
        return this.http.get<Role>(`${environment.apiUrl}/Security/GetRole?id=${id}`);
    }

    saveRole = (dto: Role): Observable<Role> => { 
        return this.http.put<Role>(`${environment.apiUrl}/Security/SaveRole`, dto, environment.httpOptions);
    }

    getUsersNamebookListForRole = (roleId: number): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Security/GetUsersNamebookListForRole?roleId=${roleId}`, environment.httpSkipSpinnerOptions);
    }

    getRoleListForAutocomplete = (limit: number, query: string): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Security/GetRoleListForAutocomplete?limit=${limit}&query=${query}`, environment.httpSkipSpinnerOptions);
    }

    getRoleListForDropdown = (): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Security/GetRoleListForDropdown`, environment.httpSkipSpinnerOptions);
    }

    //#endregion

    //#region Permission

    getPermissionListForDropdown = (): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Security/GetPermissionListForDropdown`, environment.httpSkipSpinnerOptions);
    }

    getPermissionsNamebookListForRole = (roleId: number): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Security/GetPermissionsNamebookListForRole?roleId=${roleId}`, environment.httpSkipSpinnerOptions);
    }

    //#endregion

}


""";
        }

        #endregion

    }
}
