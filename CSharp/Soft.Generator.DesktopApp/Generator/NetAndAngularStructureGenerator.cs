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
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "entities",
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "enums",
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
                                                                Name = "validation",
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
                                            new SoftFile { Name = "transloco-root.module.ts", Data = GetTranslocoRootModuleTsData() },
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
                                            new SoftFile { Name = "styles.scss", Data = GetEnvironmentTsCode(appName, primaryColor) },
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
                            new SoftFile { Name = ".tsconfig.json", Data = GetTsConfigJsonData() },
                            new SoftFile { Name = ".tsconfig.spec.json", Data = GetTsConfigSpecJsonData() },
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

        private string GetUserNotificationCsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes.EF;

namespace {{appName}}.Business.Entities
{
    public class UserNotification 
    {
        [M2MMaintanceEntity(nameof(Notification.Users))]
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
using Soft.Generator.Shared.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace {{appName}}.Business.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class UserExtended : BusinessObject<long>, IUser
    {
        [SoftDisplayName]
        [CustomValidator("EmailAddress()")]
        [StringLength(70, MinimumLength = 5)]
        [Required]
        public string Email { get; set; }

        public bool? HasLoggedInWithExternalProvider { get; set; }

        public bool? IsDisabled { get; set; }

        public virtual List<Role> Roles { get; } = new();

        public virtual List<Notification> Notifications { get; } = new();
    }
}
""";
        }

        private string GetNotificationCsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.Attributes.EF;
using Soft.Generator.Shared.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace {{appName}}.Business.Entities
{
    public class Notification : BusinessObject<long>
    {
        [SoftDisplayName]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [StringLength(400, MinimumLength = 1)]
        [Required]
        public string Description { get; set; }

        [StringLength(1000, MinimumLength = 1)]
        public string EmailBody { get; set; }

        public virtual List<UserExtended> Users { get; } = new();
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
        public List<int> SelectedRoleIds { get; set; }
    }
}
""";
        }

        private string GetNotificationSaveBodyDTOCsData(string appName)
        {
            return $$"""
using Soft.Generator.Shared.DTO;

namespace {{appName}}.Business.DTO
{
    public partial class NotificationSaveBodyDTO : LazyTableSelectionDTO<long>
    {
        public bool IsMarkedAsRead { get; set; }
    }
}
""";
        }

        private string GetNotificationDTOCsData(string appName)
        {
            return $$"""
namespace {{appName}}.Business.DTO
{
    public partial class NotificationDTO
    {
        /// <summary>
        /// This property is only for currently logged in user
        /// </summary>
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
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.Generator.Security", "..\..\Soft.Generator\Source\Soft.Generator.Security\Soft.Generator.Security.csproj", "{3B328631-AB3B-4B28-9FA5-4DA790670199}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.Generator.Shared", "..\..\Soft.Generator\Source\Soft.Generator.Shared\Soft.Generator.Shared.csproj", "{53565A13-28F1-424F-B5A0-34125EF303CD}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.Generator.Infrastructure", "..\..\Soft.Generator\Source\Soft.Generator.Infrastructure\Soft.Generator.Infrastructure.csproj", "{587D08A6-A975-4673-90A4-77CF61B7B526}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Soft.SourceGenerators", "..\..\Soft.Generator\Source\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj", "{A30DFD0D-9EDD-4FD2-8CAF-85492EEEE6F1}"
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
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Infrastructure\Soft.Generator.Infrastructure.csproj" />
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Security\Soft.Generator.Security.csproj" />
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Shared\Soft.Generator.Shared.csproj" />
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
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
        [Output(@"E:\Projects\{{appName}}\Angular\src\app\business\services\api\api.service.generated.ts")]
        public string NgControllersGenerator { get; set; }

        [Output(@"E:\Projects\{{appName}}\Angular\src\app\business\services\translates")]
        public string NgTranslatesGenerator { get; set; }

        [Output(@"E:\Projects\{{appName}}\Angular\src\app\business\services\validators")]
        public string NgValidatorsGenerator { get; set; }
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
    <ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Shared\Soft.Generator.Shared.csproj" />
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
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Infrastructure\Soft.Generator.Infrastructure.csproj" />
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Security\Soft.Generator.Security.csproj" />
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Shared\Soft.Generator.Shared.csproj" />
		<ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
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
    <ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.Generator.Security\Soft.Generator.Security.csproj" />
    <ProjectReference Include="..\..\..\Soft.Generator\Source\Soft.SourceGenerator.NgTable\Soft.SourceGenerators.csproj" OutputItemType="Analyzer" ReferenceOutputAssembly="false" />
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
        [Output(@"E:\Projects\{{appName}}\Angular\src\app\business\entities")]
        public string NgEntitiesGenerator { get; set; }

        [Output(@"E:\Projects\{{appName}}\Angular\src\app\business\enums")]
        public string NgEnumsGenerator { get; set; }
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

        public async Task<UserExtendedDTO> SaveUserExtendedAndReturnDTOExtendedAsync(UserExtendedSaveBodyDTO userExtendedSaveBodyDTO)
        {
            return await _context.WithTransactionAsync(async () =>
            {
                if (userExtendedSaveBodyDTO.UserExtendedDTO.Id == 0)
                    throw new HackerException("You can't add new user.");

                UserExtended user = await LoadInstanceAsync<UserExtended, long>(userExtendedSaveBodyDTO.UserExtendedDTO.Id, userExtendedSaveBodyDTO.UserExtendedDTO.Version);

                if (userExtendedSaveBodyDTO.UserExtendedDTO.Email != user.Email)
                    throw new HackerException("You can't change email from here.");

                if (userExtendedSaveBodyDTO.SelectedRoleIds != null)
                    await _securityBusinessService.UpdateRoleListForUser(userExtendedSaveBodyDTO.UserExtendedDTO.Id, userExtendedSaveBodyDTO.SelectedRoleIds);

                return await SaveUserExtendedAndReturnDTOAsync(userExtendedSaveBodyDTO.UserExtendedDTO, false, false); // FT: Here we can let Save after update many to many association because we are sure that we will never send 0 from the UI
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

        public async Task<NotificationDTO> SaveNotificationAndReturnDTOExtendedAsync(NotificationSaveBodyDTO notificationSaveBodyDTO)
        {
            return await _context.WithTransactionAsync(async () =>
            {
                NotificationDTO savedNotificationDTO = await SaveNotificationAndReturnDTOAsync(notificationSaveBodyDTO.NotificationDTO, true, true);

                PaginationResult<UserExtended> paginationResult = await LoadUserExtendedListForPagination(notificationSaveBodyDTO.TableFilter, _context.DbSet<UserExtended>());

                await UpdateUserExtendedListForNotificationWithLazyTableSelection(paginationResult.Query, savedNotificationDTO.Id, notificationSaveBodyDTO);

                return savedNotificationDTO;
            });
        }

        public async Task SendNotificationEmail(long notificationId, int notificationVersion)
        {
            await _context.WithTransactionAsync(async () =>
            {
                await _authorizationService.AuthorizeAndThrowAsync<UserExtended>(PermissionCodes.EditNotification);

                Notification notification = await LoadInstanceAsync<Notification, long>(notificationId, notificationVersion); // FT: Checking version because if the user didn't save and some other user changed the version, he will send emails to wrong users

                List<string> recipients = notification.Users.Select(x => x.Email).ToList();

                await _emailingService.SendEmailAsync(recipients, notification.Title, notification.EmailBody);
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
import { environment } from 'src/environments/environment';
import { filter, Subscription, switchMap } from 'rxjs';
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
                ]
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
    private partnerService: PartnerService,
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
import { ValidatorService } from 'src/app/business/services/validation/validation-rules';

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
                    <p-button [label]="t('AlreadyOnLoyalty', {companyName: companyName})" routerLink="/auth/login" [style]="{width: '100%'}"></p-button>
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
import { environment } from "src/environments/environment.prod";
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
    @Input() showGoogleAuth: boolean = true;

    hasGoogleAuth: boolean = environment.googleAuth;
    companyName: string;
    image: string;

    constructor(public layoutService: LayoutService) {}

    ngOnInit(){
        this.image = `assets/primeng/images/${this.layoutService.config.colorScheme === 'light' ? 'logo-dark' : 'logo-white'}.svg`
        this.companyName = environment.companyName;
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
                    <div class="text-center mb-6">
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
import { ValidatorService } from 'src/app/business/services/validation/validation-rules';

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
                    <p-button *ngIf="usersCanRegister" [label]="t('NewToLoyaltyJoinNow', {companyName: companyName})" routerLink="/auth/registration" [style]="{width: '100%'}"></p-button>
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
  "name": "{{projectName}}.spa",
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
    "@abacritt/angularx-social-login": "^2.2.0",
    "@angular/animations": "^17.0.0",
    "@angular/cdk": "^17.2.0",
    "@angular/common": "^17.0.0",
    "@angular/compiler": "^17.0.0",
    "@angular/core": "^17.0.0",
    "@angular/forms": "^17.0.0",
    "@angular/platform-browser": "^17.0.0",
    "@angular/platform-browser-dynamic": "^17.0.0",
    "@angular/router": "^17.0.0",
    "@jsverse/transloco": "^7.5.0",
    "angularx-qrcode": "^17.0.1",
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
    "@angular-devkit/build-angular": "^17.0.7",
    "@angular/cli": "^17.0.7",
    "@angular/compiler-cli": "^17.0.0",
    "@angular/localize": "^17.2.1",
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
            "outputPath": "dist/{{appName}}.spa",
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
    "ContinueWithGoogle": "Nastavite sa Google nalogom",
    "Email": "Email",
    "Password": "Lozinka",
    "Login": "Prijavi se",
    "Name": "Missing value for 'Name'",
    "NameLatin": "Missing value for 'NameLatin'",
    "Code": "Missing value for 'Code'",
    "Checked": "Missing value for 'Checked'",
    "NotificationDTO": "Missing value for 'NotificationDTO'",
    "SelectedIds": "Missing value for 'SelectedIds'",
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
    "AlreadyOnLoyalty": "Već imate profil? Prijavite se",
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
    "BadRequestDetails": "Sistem ne može da obradi zahtev. Molimo vas da proverite zahtev i pokušate ponovo.",
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

        private string GetTranslocoRootModuleTsData()
        {
            return $$"""
import { provideTransloco, TranslocoModule } from '@jsverse/transloco';
import { NgModule } from '@angular/core';

import { TranslocoHttpLoader } from './core/services/transloco-loader';
import { environment } from 'src/environments/environment';

@NgModule({
  exports: [TranslocoModule],
  providers: [
    provideTransloco({
      config: {
        availableLangs: ['sr-Latn-RS', 'en'],
        defaultLang: 'sr-Latn-RS',

        // Remove this option if your application doesn't support changing language in runtime.
        // reRenderOnLangChange: true,
        prodMode: environment.production,
      },
      loader: TranslocoHttpLoader,
    }),
  ],
})
export class TranslocoRootModule {}
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
import { TranslocoRootModule } from './transloco-root.module';
import { BusinessModule } from './business/business.module';

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
    TranslocoRootModule,
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
        this.primengConfig.ripple = true;

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
<!-- FT HACK: I don't know why, but translations on the layout component work only if wrap everything with transloco -->
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
import { HTTP_INTERCEPTORS } from '@angular/common/http';
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
        return validator;
    }

    isFormArrayEmpty(control: SoftFormArray): SoftValidatorFn {
        const validator: SoftValidatorFn = (): ValidationErrors | null => {
            const value = control;

            const notEmptyRule = typeof value !== 'undefined' && value !== null && value.length !== 0;

            const arrayValid = notEmptyRule;

            return arrayValid ? null : { _ : this.translocoService.translate('NotEmpty')};
        };
        validator.hasNotEmptyRule = true;
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

    loadPrimengListForDropdown(loadListForDropdownObservable: () => Observable<Namebook[]>): Observable<PrimengOption[]>{
        return loadListForDropdownObservable().pipe(
            map(res => {
                return res.map(x => ({ label: x.displayName, value: x.id }));
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

    sendLoginVerificationEmail = (loginDTO: Login): Observable<any> => { 
        return this.http.post<any>(`${environment.apiUrl}/Auth/SendLoginVerificationEmail`, loginDTO, environment.httpOptions);
    }

    sendRegistrationVerificationEmail = (registrationDTO: Registration): Observable<RegistrationVerificationResult> => { 
        return this.http.post<RegistrationVerificationResult>(`${environment.apiUrl}/Auth/SendRegistrationVerificationEmail`, registrationDTO, environment.httpOptions);
    }

    logout = (browserId: string): Observable<any> => { 
        return this.http.get<any>(`${environment.apiUrl}/Auth/Logout?browserId=${browserId}`);
    }

    refreshToken = (request: RefreshTokenRequest): Observable<AuthResult> => { 
        return this.http.post<AuthResult>(`${environment.apiUrl}/Auth/RefreshToken`, request, environment.httpOptions);
    }

    loadRoleListForAutocomplete(limit: number, query: string): Observable<Namebook[]> {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Auth/LoadRoleListForAutocomplete?limit=${limit}&query=${query}`, environment.httpSkipSpinnerOptions);
    }

    loadRoleListForDropdown(): Observable<Namebook[]> {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Auth/LoadRoleListForDropdown`, environment.httpSkipSpinnerOptions);
    }

    loadRoleTableData = (dto: TableFilter): Observable<TableResponse> => { 
        return this.http.post<TableResponse>(`${environment.apiUrl}/Auth/LoadRoleTableData`, dto, environment.httpSkipSpinnerOptions);
    }

    exportRoleTableDataToExcel = (dto: TableFilter): Observable<any> => { 
        return this.http.post<any>(`${environment.apiUrl}/Auth/ExportRoleTableDataToExcel`, dto, environment.httpOptions);
    }

    deleteRole = (id: number): Observable<any> => { 
        return this.http.delete<any>(`${environment.apiUrl}/Auth/DeleteRole?id=${id}`);
    }

    getRole(id: number): Observable<Role> {
        return this.http.get<Role>(`${environment.apiUrl}/Auth/GetRole?id=${id}`);
    }

    saveRole = (dto: Role): Observable<Role> => { 
        return this.http.put<Role>(`${environment.apiUrl}/Auth/SaveRole`, dto, environment.httpOptions);
    }

    loadPermissionListForDropdown = (): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Auth/LoadPermissionListForDropdown`, environment.httpSkipSpinnerOptions);
    }

    loadPermissionListForRole = (roleId: number): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Auth/LoadPermissionListForRole?roleId=${roleId}`, environment.httpSkipSpinnerOptions);
    }

    loadUserListForRole = (roleId: number): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Auth/LoadUserListForRole?roleId=${roleId}`, environment.httpSkipSpinnerOptions);
    }

    loadRoleNamebookListForUserExtended = (userId: number): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Auth/LoadRoleNamebookListForUserExtended?userId=${userId}`, environment.httpSkipSpinnerOptions);
    }

    loadNotificationNamebookListForUserExtended = (userId: number): Observable<Namebook[]> => {
        return this.http.get<Namebook[]>(`${environment.apiUrl}/Auth/LoadNotificationNamebookListForUserExtended?userId=${userId}`, environment.httpSkipSpinnerOptions);
    }

    getUnreadNotificationCountForTheCurrentUser = (): Observable<number> => {
        return this.http.get<number>(`${environment.apiUrl}/Auth/GetUnreadNotificationCountForTheCurrentUser`, environment.httpSkipSpinnerOptions);
    }

}
""";
        }

        #endregion

    }
}
