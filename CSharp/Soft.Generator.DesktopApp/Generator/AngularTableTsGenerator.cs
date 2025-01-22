using Soft.Generator.DesktopApp.Entities;
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
        public void Generate(List<Type> entities, WebApplication webApplication)
        {
            GenerateTableCode(entities);
        }

        private void GenerateTableCode(List<Type> entities)
        {

            foreach (Type entity in entities)
            {
                if (entity.IsManyToManyType() ||
                    entity.IsCoreEntity())
                    continue;

                StringBuilder sb = new StringBuilder();

                sb.AppendLine($$"""
import { Component, OnInit } from '@angular/core';
import { TranslocoService } from '@jsverse/transloco';
import { ApiService } from 'src/app/business/services/api/api.service';
import { Column } from 'src/app/core/components/soft-data-table/soft-data-table.component';
import { {{entity.Name}} } from 'src/app/business/entities/business-entities.generated';
import { firstValueFrom } from 'rxjs';

@Component({
    selector: '{{entity.Name.FromPascalToKebabCase()}}-table',
    templateUrl: './{{entity.Name.FromPascalToKebabCase()}}-table.component.html',
    styles: []
})
export class {{entity.Name}}TableComponent implements OnInit {
    cols: Column<{{entity.Name}}>[];

    get{{entity.Name}}TableDataObservableMethod = this.apiService.get{{entity.Name}}TableData;
    export{{entity.Name}}TableDataToExcelObservableMethod = this.apiService.export{{entity.Name}}TableDataToExcel;
    delete{{entity.Name}}ObservableMethod = this.apiService.delete{{entity.Name}};

    constructor(
        private apiService: ApiService,
        private translocoService: TranslocoService,
    ) { }

    async ngOnInit(){
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

                Helper.WriteToFileAndMakeFolders(sb, $@"{Settings.DownloadPath}\{entity.Name.FromPascalToKebabCase()}\pages\{entity.Name.FromPascalToKebabCase()}-table.component.ts");
            }
        }

        private List<string> GetTableColumns(Type entity)
        {
            List<string> result = new List<string>();

            List<PropertyInfo> properties = entity.GetProperties().ToList();

            foreach (PropertyInfo property in properties)
            {
                // Many to one can be only filtered as: text or multiselect (text is like autocomplete)
                // AutocompleteAttribute autoCompleteAttribute = property.SafeGetAttribute<AutocompleteAttribute>();

                if (property.PropertyType.IsManyToOneType())
                {
                    result.Add($$"""
            {name: this.translocoService.translate('{{property.Name}}'), filterType: 'text', field: '{{property.Name.FirstCharToLower()}}DisplayName'},
            {name: this.translocoService.translate('{{property.Name}}'), filterType: 'multiselect', field: '{{property.Name.FirstCharToLower()}}DisplayName', filterField: '{{property.Name.FirstCharToLower()}}Id', dropdownOrMultiselectValues: await firstValueFrom(this.apiService.getPrimengNamebookListForDropdown(this.apiService.get{{property.Name}}ListForDropdown)) },
""");
                }
                else if (property.PropertyType == typeof(string))
                {
                    result.Add($$"""
            {name: this.translocoService.translate('{{property.Name}}'), filterType: 'text', field: '{{property.Name.FirstCharToLower()}}'},
""");
                }
                else if (property.PropertyType.IsWholeNumber())
                {
                    result.Add($$"""
            {name: this.translocoService.translate('{{property.Name}}'), filterType: 'numeric', field: '{{property.Name.FirstCharToLower()}}', showMatchModes: true},
""");
                }
                else if (property.PropertyType.IsDateTime())
                {
                    result.Add($$"""
            {name: this.translocoService.translate('{{property.Name}}'), filterType: 'date', field: '{{property.Name.FirstCharToLower()}}', showMatchModes: true},
""");
                }
            }

            //foreach (PropertyInfo property in propertyDTOList)
            //{
            //    ...
            //}

            return result;
        }

    }
}
