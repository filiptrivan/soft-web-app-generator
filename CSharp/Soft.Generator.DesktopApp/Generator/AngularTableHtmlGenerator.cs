using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Generator.Helpers;
using Soft.Generator.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator
{
    public class AngularTableHtmlGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities, WebApplication webApplication)
        {
            foreach (Type entity in entities)
            {
                if (entity.IsManyToManyType() ||
                    entity.IsCoreEntity())
                    continue;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine($$"""
<ng-container *transloco="let t">
    <soft-data-table 
    [tableTitle]="t('{{entity.Name}}List')" 
    [cols]="cols" 
    [getTableDataObservableMethod]="get{{entity.Name}}TableDataObservableMethod" 
    [exportTableDataToExcelObservableMethod]="export{{entity.Name}}TableDataToExcelObservableMethod"
    [deleteItemFromTableObservableMethod]="delete{{entity.Name}}ObservableMethod"
    ></soft-data-table>
</ng-container>
""");

                Helper.WriteToFileAndMakeFolders(sb, $@"{Settings.DownloadPath}\{entity.Name.FromPascalToKebabCase()}\pages\{entity.Name.FromPascalToKebabCase()}-table.component.html");
            }
        }
    }
}
