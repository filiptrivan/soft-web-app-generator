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
    public class AngularDetailsTsGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities, WebApplication webApplication)
        {
            foreach (Type entity in entities)
            {
                if (entity.IsManyToManyType() ||
                    entity.IsCoreEntity())
                    continue;

                string generatedCode = GenerateCode(entity);

                Helper.WriteToFileAndMakeFolders(generatedCode, $@"{Settings.DownloadPath}\{entity.Name.FromPascalToKebabCase()}\pages\{entity.Name.FromPascalToKebabCase()}-details.component.ts");
            }
        }

        private string GenerateCode(Type entity)
        {
            if (entity == null)
                return null;

            string result = $$"""
import { SpiderFormGroup } from 'src/app/core/components/spider-form-control/spider-form-control';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, KeyValueDiffers, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslocoService } from '@jsverse/transloco';
import { ApiService } from 'src/app/business/services/api/api.service';
import { TranslateClassNamesService } from 'src/app/business/services/translates/merge-class-names';
import { ValidatorService } from 'src/app/business/services/validators/validation-rules';
import { BaseFormCopy } from 'src/app/core/components/base-form/base-form copy';
import { BaseFormService } from 'src/app/core/services/base-form.service';
import { SpiderMessageService } from 'src/app/core/services/spider-message.service';
import { {{entity.Name}} } from 'src/app/business/entities/business-entities.generated';

@Component({
    selector: '{{entity.Name.FromPascalToKebabCase()}}-details',
    templateUrl: './{{entity.Name.FromPascalToKebabCase()}}-details.component.html',
    styles: [],
})
export class {{entity.Name}}DetailsComponent extends BaseFormCopy implements OnInit {
    {{entity.Name.FirstCharToLower()}}FormGroup = new SpiderFormGroup<{{entity.Name}}>({});

    constructor(
        protected override differs: KeyValueDiffers,
        protected override http: HttpClient,
        protected override messageService: SpiderMessageService, 
        protected override changeDetectorRef: ChangeDetectorRef,
        protected override router: Router, 
        protected override route: ActivatedRoute, 
        protected override translocoService: TranslocoService,
        protected override translateClassNamesService: TranslateClassNamesService,
        protected override validatorService: ValidatorService,
        protected override baseFormService: BaseFormService,
        private apiService: ApiService,
    ) {
        super(differs, http, messageService, changeDetectorRef, router, route, translocoService, translateClassNamesService, validatorService, baseFormService);
    }

    override ngOnInit() {
        
    }

    override onBeforeSave = (): void => {
        
    }

}

""";

            return result;
        }
    }
}
