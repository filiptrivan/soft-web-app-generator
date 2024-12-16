using Soft.Generator.DesktopApp.Attributes.UI;
using Soft.Generator.DesktopApp.Generator.Helpers;
using Soft.Generator.DesktopApp.Interfaces;
using Pluralize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator
{
    public class AngularModulesGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities)
        {
            foreach (var entityGroup in entities.GroupBy(x => x.SafeGetAttribute<MenuNameAttribute>()?.Name))
            {
                if (entityGroup.Key == null)
                    continue;

                string generatedCode = GenerateCode(entityGroup);

                Helper.WriteToTheFile(generatedCode, $@"{Settings.DownloadPath}\{entityGroup.Key.FromPascalToKebabCase()}.module.ts");
            }
        }

        private string GenerateCode(IGrouping<string, Type> entityGroup)
        {
            string result = $$"""
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PartnerUserListComponent } from './pages/users/partner-user-list.component';
import { PrimengModule } from 'src/app/layout/modules/primeng.module';
import { PartnerUserDetailsComponent } from './pages/users/partner-user-details.component';
import { SoftControlsModule } from 'src/app/core/controls/soft-controls.module';
import { CardSkeletonComponent } from "../../core/components/card-skeleton/card-skeleton.component";
import { SoftDataTableComponent } from 'src/app/core/components/soft-data-table/soft-data-table.component';
import { CommonModule } from '@angular/common';
import { IndexCardComponent } from 'src/app/core/components/index-card/index-card.component';
import { TranslocoDirective } from '@jsverse/transloco';

{{string.Join("\n", GetDynamicImports(entityGroup.ToList()))}}

const routes: Routes = [
{{string.Join("\n", GetRoutes(entityGroup.ToList()))}}
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
        CommonModule,
        PrimengModule,
        TranslocoDirective,
        SoftDataTableComponent,
        SoftControlsModule,
        CardSkeletonComponent,
        IndexCardComponent,
        SegmentationSelectComponent,
        UserProgressbarComponent,
    ],
    declarations: [
{{string.Join("\n", GetComponentDeclarations(entityGroup.ToList()))}}
    ],
    providers:[]
})
export class {{entityGroup.Key}}Module { }

""";

            return result;
        }

        private static List<string> GetDynamicImports(List<Type> types)
        {
            List<string> result = new List<string>();

            foreach (Type type in types)
            {
                result.Add($$"""
import { {{type.Name}}TableComponent } from './pages/{{type.Name.FromPascalToKebabCase()}}/{{type.Name.FromPascalToKebabCase()}}-table.component';
import { {{type.Name}}DetailsComponent } from './pages/{{type.Name.FromPascalToKebabCase()}}/{{type.Name.FromPascalToKebabCase()}}-details.component';
""");
            }

            return result;
        }

        private static List<string> GetRoutes(List<Type> types)
        {
            List<string> result = new List<string>();

            foreach (Type type in types)
            {
                result.Add($$"""
    {
        path: '{{type.Name.Pluralize()}}',
        component: {{type.Name}}TableComponent,
    },
    {
        path: '{{type.Name.Pluralize()}}/:id',
        component: {{type.Name}}DetailsComponent,
    },
""");
            }

            return result;
        }

        private static List<string> GetComponentDeclarations(List<Type> types)
        {
            List<string> result = new List<string>();

            foreach (Type type in types)
            {
                result.Add($$"""
        {{type.Name}}TableComponent,
        {{type.Name}}DetailsComponent, 
""");
            }

            return result;
        }

    }
}
