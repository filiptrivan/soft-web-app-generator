using Soft.Generator.DesktopApp.Generator.Helpers;
using Soft.Generator.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator
{
    public class AngularTableTsGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities)
        {
            GenerateTableCode(entities);
        }

        private void GenerateTableCode(List<Type> entities)
        {
            List<string> helperForDelete = new List<string>();

            foreach (Type entity in entities)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($$"""
import { Component, OnInit } from '@angular/core';
import { TranslocoService } from '@jsverse/transloco';
import { ApiService } from 'src/app/business/services/api/api.service';
import { Column } from 'src/app/core/components/soft-data-table/soft-data-table.component';

@Component({
    selector: '{{entity.Name}}-table',
    templateUrl: './{{entity.Name}}-table.component.html',
    styles: []
})
export class {{entity.Name}}TableComponent implements OnInit {
    cols: Column[];

    load{{entity.Name}}TableDataObservableMethod = this.apiService.load{{entity.Name}}TableData;
    export{{entity.Name}}TableDataToExcelObservableMethod = this.apiService.export{{entity.Name}}TableDataToExcel;
    delete{{entity.Name}}ObservableMethod = this.apiService.delete{{entity.Name}};

    constructor(
        private apiService: ApiService,
        private translocoService: TranslocoService,
    ) { }

    ngOnInit(){
        this.cols = [
            {name: this.translocoService.translate('Actions'), actions:[
                {name: this.translocoService.translate('Details'), field: 'Details'},
                {name: this.translocoService.translate('Delete'), field: 'Delete'},
            ]},
            {{string.Join("\n", GetTableColumns(entity))}}
        ]
    }

}
""");

                helperForDelete.Add($$"""
    {{entity.Name.ToUpper()}}:

    HTML:

<ng-container *transloco="let t">
    <soft-data-table 
    [tableTitle]="t('{{entity.Name}}List')" 
    [cols]="cols" 
    [loadTableDataObservableMethod]="load{{entity.Name}}TableDataObservableMethod" 
    [exportTableDataToExcelObservableMethod]="export{{entity.Name}}TableDataToExcelObservableMethod"
    [deleteItemFromTableObservableMethod]="delete{{entity.Name}}ObservableMethod"
    >
    </soft-data-table>
</ng-container>

    TS:

    load{{entity.Name}}TableDataObservableMethod = this.apiService.load{{entity.Name}}TableData;
    export{{entity.Name}}TableDataToExcelObservableMethod = this.apiService.export{{entity.Name}}TableDataToExcel;
    delete{{entity.Name}}ObservableMethod = this.apiService.delete{{entity.Name}};

    constructor(
        private apiService: ApiService,
        private translocoService: TranslocoService,
    ) { }

    -----------------------------------------------------------
""");

                // Write to the file
            }

            // TODO FT: Delete this is only helper
            Helper.WriteToTheFile(string.Join("\n", helperForDelete), $@"C:\Users\user\Downloads\helper.txt");
        }

        private List<string> GetTableColumns(Type entity)
        {
            List<string> result = new List<string>();

            List<PropertyInfo> properties = entity.GetProperties().ToList();

            foreach (PropertyInfo property in properties)
            {
                //List<Attribute> propertyAttributes = property.GetCustomAttributes().ToList();

                //if (propertyAttributes.Any(x => x is AutoCompleteAttribute))
                //{

                //}

                if (property.PropertyType.IsManyToOneType())
                {
                    result.Add($$"""
{name: this.translocoService.translate('{{property.Name}}'), filterType: 'multiselect', field: '{{property.Name.FirstCharToLower()}}DisplayName', filterField: '{{property.Name.FirstCharToLower()}}Id', dropdownOrMultiselectValues: await firstValueFrom(this.apiService.load{{property.Name}}ListForDropdown()) },
""");
                }
                else if (property.PropertyType == typeof(string))
                {
                    result.Add($$"""
{name: this.translocoService.translate('{{property.Name}}'), filterType: 'text', field: '{{property.Name.FirstCharToLower()}}'},
""");
                }
                else if (property.PropertyType == typeof(long))
                {

                }
            }

            return result;
        }

    }
}
