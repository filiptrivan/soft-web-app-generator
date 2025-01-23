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
    <spider-data-table 
    [tableTitle]="t('{{entity.Name}}List')" 
    [cols]="cols" 
    [getTableDataObservableMethod]="get{{entity.Name}}TableDataObservableMethod" 
    [exportTableDataToExcelObservableMethod]="export{{entity.Name}}TableDataToExcelObservableMethod"
    [deleteItemFromTableObservableMethod]="delete{{entity.Name}}ObservableMethod"
    ></spider-data-table>
</ng-container>
""");

                Helper.WriteToFileAndMakeFolders(sb, $@"{Settings.DownloadPath}\{entity.Name.FromPascalToKebabCase()}\pages\{entity.Name.FromPascalToKebabCase()}-table.component.html");
            }
        }
    }
}
