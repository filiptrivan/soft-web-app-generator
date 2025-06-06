﻿using Spider.Shared.Attributes.UI;
using Spider.DesktopApp.Generator.Helpers;
using Spider.DesktopApp.Interfaces;
using Pluralize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spider.DesktopApp.Entities;

namespace Spider.DesktopApp.Generator
{
    public class AngularModulesGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities, WebApplication webApplication)
        {
            foreach (var entityGroup in entities
                .Where(x => x.IsManyToManyType() == false && x.IsCoreEntity() == false)
                .GroupBy(x => x.SafeGetAttribute<MenuNameAttribute>()?.Name ?? x.Name))
            {
                string generatedCode = GenerateCode(entityGroup);

                Helper.WriteToFileAndMakeFolders(generatedCode, $@"{Settings.DownloadPath}\{entityGroup.Key.FromPascalToKebabCase()}\{entityGroup.Key.FromPascalToKebabCase()}.module.ts");
            }
        }

        private string GenerateCode(IGrouping<string, Type> entityGroup)
        {
            string result = $$"""
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrimengModule } from 'src/app/core/modules/primeng.module';
import { SpiderControlsModule } from 'src/app/core/controls/spider-controls.module';
import { CardSkeletonComponent } from "../../core/components/card-skeleton/card-skeleton.component";
import { SpiderDataTableComponent } from 'src/app/core/components/spider-data-table/spider-data-table.component';
import { CommonModule } from '@angular/common';
import { IndexCardComponent } from 'src/app/core/components/index-card/index-card.component';
import { TranslocoDirective } from '@jsverse/transloco';

{{string.Join("\n", GetDynamicImports(entityGroup))}}

const routes: Routes = [
{{string.Join("\n", GetRoutes(entityGroup.ToList()))}}
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
        CommonModule,
        PrimengModule,
        TranslocoDirective,
        SpiderDataTableComponent,
        SpiderControlsModule,
        CardSkeletonComponent,
        IndexCardComponent,
{{string.Join("\n", GetBaseDetailsComponentImports(entityGroup.ToList()))}}
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

        private List<string> GetBaseDetailsComponentImports(List<Type> types)
        {
            List<string> result = new List<string>();

            foreach (Type type in types)
            {
                result.Add($$"""
        {{type.Name}}BaseDetailsComponent,
""");
            }

            return result;
        }

        private static List<string> GetDynamicImports(IGrouping<string, Type> entityGroup)
        {
            List<string> result = new List<string>();

            foreach (Type type in entityGroup.ToList())
            {
                result.Add($$"""
import { {{type.Name}}TableComponent } from './pages{{Helper.GetPagesSubfolder(entityGroup, type)}}/{{type.Name.FromPascalToKebabCase()}}-table.component';
import { {{type.Name}}DetailsComponent } from './pages{{Helper.GetPagesSubfolder(entityGroup, type)}}/{{type.Name.FromPascalToKebabCase()}}-details.component';
import { {{type.Name}}BaseDetailsComponent } from 'src/app/business/components/base-details/business-base-details.generated';
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
        path: '{{type.Name.Pluralize().FromPascalToKebabCase()}}',
        component: {{type.Name}}TableComponent,
    },
    {
        path: '{{type.Name.Pluralize().FromPascalToKebabCase()}}/:id',
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
