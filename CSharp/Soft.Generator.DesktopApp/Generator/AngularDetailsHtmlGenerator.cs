using Soft.Generator.DesktopApp.Attributes.UI;
using Soft.Generator.DesktopApp.Generator.Helpers;
using Soft.Generator.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator
{
    public class AngularDetailsHtmlGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities)
        {
            foreach (Type entity in entities)
            {
                string generatedCode = GenerateCode(entity);

                Helper.WriteToTheFile(generatedCode, $@"{Settings.DownloadPath}\{entity.Name.FromPascalToKebabCase()}-details.component.html");
            }
        }

        private string GenerateCode(Type entity)
        {
            if (entity == null)
                return null;

            string result = $$"""
<ng-container *transloco="let t">
    @defer (when {{entity.Name.FirstCharToLower()}}FormGroup != null) {
        <soft-card [title]="t('{{entity.Name}}')" icon="pi pi-file-edit">
            <soft-panel>
                <panel-header></panel-header>

                <panel-body>
                    <form [formGroup]="formGroup" class="grid">
{{string.Join("\n", GetControlBlocks(entity))}}
                    </form>
                </panel-body>

                <panel-footer>
                    <p-button (onClick)="onSave()" [label]="t('Save')" icon="pi pi-save"></p-button>
                </panel-footer>

            </soft-panel>
        </soft-card>
    } @placeholder {
        <card-skeleton [height]="502"></card-skeleton>
    }
</ng-container>
""";

            return result;
        }

        private List<string> GetControlBlocks(Type entity)
        {
            List<string> result = new List<string>();

            List<PropertyInfo> properties = entity.GetProperties()
                .Where(x => x.Name != "Id" && x.Name != "Version" && x.Name != "CreatedAt" && x.Name != "ModifiedAt" && x.PropertyType.IsListType() == false)
                .OrderBy(x => x.SafeGetAttribute<StringLengthAttribute>()?.MaximumLength > Settings.LimitLengthForTextArea ? 1 : 0)
                .ToList();

            foreach (PropertyInfo property in properties)
                result.Add(GetControlBlock(property, entity));

            return result;
        }

        private string GetControlBlock(PropertyInfo property, Type entity)
        {
            string result = null;

            if (property.PropertyType.IsManyToOneType())
            {
                DropdownAttribute dropdownAttribute = property.SafeGetAttribute<DropdownAttribute>();

                if (dropdownAttribute == null)
                {
                    result = $$"""
                        <div class="col-12 md:col-6">
                            <soft-autocomplete [control]="{{GetControlArguments(property, entity)}}" [options]="{{property.Name.FirstCharToLower()}}Options" (onTextInput)="search{{property.Name}}($event)"></soft-autocomplete>
                        </div>
""";
                }
                else
                {
                    result = $$"""
                        <div class="col-12 md:col-6">
                            <soft-dropdown [control]="{{GetControlArguments(property, entity)}}", {{entity.Name.FirstCharToLower()}}FormGroup)" [options]="{{property.Name.FirstCharToLower()}}Options"></soft-dropdown>
                        </div>
""";
                }
            }
            else if (property.PropertyType == typeof(string))
            {
                int? maximumLength = property.SafeGetAttribute<StringLengthAttribute>()?.MaximumLength;

                if (maximumLength != null && maximumLength > Settings.LimitLengthForTextArea)
                {
                    result = $$"""
                        <div class="col-12">
                            <soft-textarea [control]="{{GetControlArguments(property, entity)}}"></soft-textbox>
                        </div>
""";
                }
                else
                {
                    result = $$"""
                        <div class="col-12 md:col-6">
                            <soft-textbox [control]="{{GetControlArguments(property, entity)}}"></soft-textbox>
                        </div>
""";
                }

            }
            else if (property.PropertyType.IsWholeNumber())
            {
                result = $$"""
                        <div class="col-12 md:col-6">
                            <soft-number [control]="{{GetControlArguments(property, entity)}}"></soft-number>
                        </div>
""";
            }
            else if (property.PropertyType.IsDecimal())
            {
                int scale = property.GetDecimalScale();

                result = $$"""
                        <div class="col-12 md:col-6">
                            <soft-number [control]="{{GetControlArguments(property, entity)}}" [decimal]="true" [maxFractionDigits]="{{scale}}"></soft-number>
                        </div>
""";
            }
            else if (property.PropertyType.IsDateTime())
            {
                result = $$"""
                        <div class="col-12 md:col-6">
                            <soft-calendar [control]="{{GetControlArguments(property, entity)}}"></soft-calendar>
                        </div>
""";
            }

            return result;
        }

        private string GetControlArguments(PropertyInfo property, Type entity)
        {
            if (property.PropertyType.IsManyToOneType())
                return $"control('{property.Name.FirstCharToLower()}Id', {entity.Name.FirstCharToLower()}FormGroup)";
            else
                return $"control('{property.Name.FirstCharToLower()}', {entity.Name.FirstCharToLower()}FormGroup)";
        }

    }
}
