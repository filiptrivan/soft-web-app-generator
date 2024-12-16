using Soft.Generator.DesktopApp.Attributes.UI;
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
    @defer (when storeFormGroup != null) {
        <soft-card [title]="t('Store')" icon="pi pi-file-edit">
            <soft-panel>
                <panel-header></panel-header>

                <panel-body>
                    <form [formGroup]="formGroup" class="grid">
                        <div class="col-12 md:col-6">
                            <soft-textbox [control]="control('name', storeFormGroup)"></soft-textbox>
                        </div>
                        <div class="col-12 md:col-6">
                            <soft-textbox [control]="control('getTransactionsEndpoint', storeFormGroup)"></soft-textbox>
                        </div>
                        <div class="col-12 md:col-6">
                            <soft-textbox [control]="control('createUserEndpoint', storeFormGroup)"></soft-textbox>
                        </div>
                        <div class="col-12 md:col-6">
                            <soft-textbox [control]="control('updateUserGroupEndpoint', storeFormGroup)"></soft-textbox>
                        </div>
                        <div class="col-12 md:col-6">
                            <soft-textbox [control]="control('getDiscountCategoriesEndpoint', storeFormGroup)"></soft-textbox>
                        </div>
                    </form>
                </panel-body>

                <panel-footer>
                    <p-button (onClick)="onSave()" [label]="t('Save')" icon="pi pi-save"></p-button>
                    <p-button (onClick)="onSyncDiscountCategories()" [label]="t('SyncDiscountCategories')" icon="pi pi-sync"></p-button>
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

            foreach (PropertyInfo property in entity.GetProperties())
            {

            }

            return result;
        }

        private string GetControlBlock(PropertyInfo property)
        {
            string result = null;

            if (property.PropertyType.IsManyToOneType())
            {
                DropdownAttribute dropdownAttribute = property.SafeGetAttribute<DropdownAttribute>();

                if (dropdownAttribute == null)
                {
                    result = $$"""
                        <soft-autocomplete [control]="selectedPartner" [options]="partnerOptions" (onTextInput)="searchPartners($event)"></soft-autocomplete>
""";
                }
                else if (false)
                {

                }
            }
            else if (property.PropertyType == typeof(string))
            {
            }
            else if (property.PropertyType.IsWholeNumber())
            {
            }
            else if (property.PropertyType.IsDateTime())
            {
            }

            return result;
        }
    }
}
