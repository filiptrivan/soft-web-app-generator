using Spider.DesktopApp.Attributes.UI;
using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Generator.Helpers;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Generator
{
    public class AngularMenuGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities, WebApplication webApplication)
        {
            string generatedCode = GenerateCode(entities);

            Helper.WriteToFileAndMakeFolders(generatedCode, $@"{Settings.DownloadPath}\{webApplication.Name}\helpers\side-menu.txt");
        }

        private string GenerateCode(List<Type> entities)
        {
            return $$"""
this.menu = [
    {
        visible: true,
        items: [
            { 
                label: this.translocoService.translate('Home'), 
                icon: 'pi pi-fw pi-home', 
                routerLink: [''],
                visible: true,
            },
{{string.Join("\n", GetSideMenuItems(entities))}}
            {
                label: this.translocoService.translate('Administration'),
                icon: 'pi pi-fw pi-cog',
                visible: true,
                items: [
                    {
                        label: this.translocoService.translate('UserList'),
                        icon: 'pi pi-fw pi-user',
                        routerLink: [`/${environment.administrationSlug}/users`],
                        // hasPermission: (permissionCodes: string[]): boolean => { 
                        //     return (permissionCodes?.includes(PermissionCodes[PermissionCodes.ReadUserExtended]))
                        // } 
                        visible: true,
                    },
                    {
                        label: this.translocoService.translate('RoleList'),
                        icon: 'pi pi-fw pi-id-card',
                        routerLink: [`/${environment.administrationSlug}/roles`],
                        // hasPermission: (permissionCodes: string[]): boolean => { 
                        //     return (permissionCodes?.includes(PermissionCodes[PermissionCodes.ReadRole]))
                        // }
                        visible: true,
                    },
                    {
                        label: this.translocoService.translate('NotificationList'),
                        icon: 'pi pi-fw pi-bell',
                        routerLink: [`/${environment.administrationSlug}/notifications`],
                        // hasPermission: (permissionCodes: string[]): boolean => { 
                        //     return (permissionCodes?.includes(PermissionCodes[PermissionCodes.ReadNotification]))
                        // }
                        visible: true,
                    }
                ]
            }
        ]
    },
];
""";
        }

        private List<string> GetSideMenuItems(List<Type> entities)
        {
            List<string> result = new List<string>();

            foreach (var entityGroup in entities
                .Where(x => x.IsManyToManyType() == false && x.IsCoreEntity() == false)
                .GroupBy(x => x.SafeGetAttribute<MenuNameAttribute>()?.Name ?? x.Name))
            {
                foreach (Type entity in entityGroup.ToList())
                {
                    result.Add($$"""
            {
                label: this.translocoService.translate('{{entity.Name}}List'),
                icon: 'pi pi-fw pi-list',
                routerLink: [`{{Helper.GetPagesSubfolder(entityGroup, entity)}}/{{entity.Name.Pluralize().FromPascalToKebabCase()}}`],
                // hasPermission: (permissionCodes: string[]): boolean => { 
                //     return (permissionCodes?.includes(PermissionCodes[PermissionCodes.Read{{entity.Name}}]))
                // }
                visible: true,
            },
""");
                }
            }


            return result;
        }
    }
}
