﻿using Spider.Shared.Attributes.UI;
using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Generator.Helpers;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Generator
{
    public class AngularDetailsHtmlGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities, WebApplication webApplication)
        {
            foreach (Type entity in entities)
            {
                if (entity.IsManyToManyType() ||
                    entity.IsCoreEntity())
                    continue;

                string generatedCode = GenerateCode(entity);

                Helper.WriteToFileAndMakeFolders(generatedCode, $@"{Settings.DownloadPath}\{entity.Name.FromPascalToKebabCase()}\pages\{entity.Name.FromPascalToKebabCase()}-details.component.html");
            }
        }

        private string GenerateCode(Type entity)
        {
            if (entity == null)
                return null;

            string result = $$"""
<ng-container *transloco="let t">
    <spider-card [title]="t('{{entity.Name}}')" icon="pi pi-file">

        <{{entity.Name.FromPascalToKebabCase()}}-base-details 
        [formGroup]="formGroup" 
        [{{entity.Name.FirstCharToLower()}}FormGroup]="{{entity.Name.FirstCharToLower()}}FormGroup" 
        (onSave)="onSave()" 
        [getCrudMenuForOrderedData]="getCrudMenuForOrderedData"
        ></{{entity.Name.FromPascalToKebabCase()}}-base-details>

    </spider-card>
</ng-container>
""";

            return result;
        }

    }
}
