using Soft.Generator.DesktopApp.Attributes.UI;
using Soft.Generator.DesktopApp.Generator.Helpers;
using Soft.Generator.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator
{
    public class AngularDetailsTsGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities)
        {
            foreach (Type entity in entities)
            {
                string generatedCode = GenerateCode(entity);

                Helper.WriteToTheFile(generatedCode, $@"{Settings.DownloadPath}\{entity.Name.FromPascalToKebabCase()}-details.component.ts");
            }
        }

        private string GenerateCode(Type entity)
        {
            if (entity == null)
                return null;

            string result = $$"""
import { SoftFormControl, SoftFormGroup } from '../../../../core/components/soft-form-control/soft-form-control';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, KeyValueDiffers, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslocoService } from '@jsverse/transloco';
import { forkJoin, Observable } from 'rxjs';
import { ApiService } from 'src/app/business/services/api/api.service';
import { TranslateClassNamesService } from 'src/app/business/services/translates/translated-class-names.generated';
import { ValidatorService } from 'src/app/business/services/validation/validation-rules';
import { BaseFormCopy } from 'src/app/core/components/base-form/base-form copy';
import { nameof } from 'src/app/core/services/helper-functions';
import { SoftMessageService } from 'src/app/core/services/soft-message.service';
import { Column } from 'src/app/core/components/soft-data-table/soft-data-table.component';
import { SoftTab } from 'src/app/core/components/soft-panels/panel-header/panel-header.component';
import { PrimeIcons } from 'primeng/api';
import { {{entity.Name}} } from 'src/app/business/entities/generated/business-entities.generated';

@Component({
    selector: '{{entity.Name.FromPascalToKebabCase()}}-details',
    templateUrl: './{{entity.Name.FromPascalToKebabCase()}}-details.component.html',
    styles: [],
})
export class {{entity.Name}}DetailsComponent extends BaseFormCopy implements OnInit {
    override saveObservableMethod = this.apiService.save{{entity.Name}};

    {{entity.Name.FirstCharToLower()}}FormGroup: SoftFormGroup<{{entity.Name}}>;
    {{entity.Name.FirstCharToLower()}}SaveBodyName: string = nameof<{{entity.Name}}SaveBody>('{{entity.Name.FirstCharToLower()}}DTO');

    constructor(
        protected override differs: KeyValueDiffers,
        protected override http: HttpClient,
        protected override messageService: SoftMessageService, 
        protected override changeDetectorRef: ChangeDetectorRef,
        protected override router: Router, 
        protected override route: ActivatedRoute, 
        protected override translocoService: TranslocoService,
        protected override translateClassNamesService: TranslateClassNamesService,
        protected override validatorService: ValidatorService,
        private apiService: ApiService,
    ) {
        super(differs, http, messageService, changeDetectorRef, router, route, translocoService, translateClassNamesService, validatorService);
    }

    override ngOnInit() {
        this.route.params.subscribe((params) => {
            this.modelId = params['id'];

            if (this.modelId > 0) {
                forkJoin({
                    {{entity.Name.FirstCharToLower()}}: this.apiService.get{{entity.Name}}(this.modelId),
                })
                .subscribe(({ {{entity.Name.FirstCharToLower()}} }) => {
                    this.{{entity.Name.FirstCharToLower()}}FormGroup = this.initFormGroup(new {{entity.Name}}({{entity.Name.FirstCharToLower()}}), this.{{entity.Name.FirstCharToLower()}}SaveBodyName);
                });
            }else{
                this.{{entity.Name.FirstCharToLower()}}FormGroup = this.initFormGroup(new {{entity.Name}}({id: 0}), this.{{entity.Name.FirstCharToLower()}}SaveBodyName);
            }
        });
    }

    override onBeforeSave(): void {
        let saveBody: {{entity.Name}}SaveBody = new {{entity.Name}}SaveBody();

        saveBody.{{entity.Name.FirstCharToLower()}}DTO = this.{{entity.Name.FirstCharToLower()}}FormGroup.getRawValue();

        this.saveBody = saveBody;
    }

}

""";

            return result;
        }
    }
}
