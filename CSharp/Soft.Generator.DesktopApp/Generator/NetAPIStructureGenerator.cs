using Soft.Generator.DesktopApp.Generator.Helpers;
using Soft.Generator.DesktopApp.Generator.Models;
using Soft.Generator.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseExtensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Soft.Generator.DesktopApp.Generator
{
    public class NetAndAngularStructureGenerator
    {
        public void Generate(string outputPath, string projectName)
        {
            SoftFolder projectStructure = new SoftFolder
            {
                Name = projectName,
                ChildFolders = new List<SoftFolder>
                {
                    new SoftFolder
                    {
                        Name = "Angular",
                        ChildFolders = new List<SoftFolder>
                        {
                            new SoftFolder
                            {
                                Name = "src",
                                ChildFolders = new List<SoftFolder>
                                {
                                    new SoftFolder
                                    {
                                        Name = "app",
                                        ChildFolders = new List<SoftFolder>
                                        {
                                            new SoftFolder
                                            {
                                                Name = "business",
                                                ChildFolders = new List<SoftFolder>
                                                {
                                                    new SoftFolder 
                                                    {
                                                        Name = "components",
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "entities",
                                                        ChildFolders = new List<SoftFolder>
                                                        {
                                                            new SoftFolder { Name = "generated" }
                                                        }
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "enums",
                                                        ChildFolders = new List<SoftFolder>
                                                        {
                                                            new SoftFolder { Name = "generated" }
                                                        }
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "guards",
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "interceptors",
                                                    },
                                                    new SoftFolder
                                                    {
                                                        Name = "services",
                                                        ChildFolders = new List<SoftFolder>
                                                        {
                                                            new SoftFolder
                                                            {
                                                                Name = "api",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "api.service.security.ts", Data = GetAPIServiceSecurityTsCode() },
                                                                    new SoftFile { Name = "api.service.ts", Data = GetAPIServiceTsCode() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "helpers",
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "translates",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "merge-class-names.ts", Data = GetMergeClassNamesTsCode() },
                                                                    new SoftFile { Name = "merge-labels.ts", Data = GetMergeLabelsCode() },
                                                                }
                                                            },
                                                            new SoftFolder
                                                            {
                                                                Name = "validation",
                                                                SoftFiles = new List<SoftFile>
                                                                {
                                                                    new SoftFile { Name = "validation-rules.ts", Data = GetValidationRulesTsCode() },
                                                                }
                                                            },
                                                        },
                                                    },
                                                },
                                                SoftFiles = new List<SoftFile>
                                                {
                                                    new SoftFile { Name = "business.module.ts", Data = GetBusinessModuleTsData() }
                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "core", // FT: Copy
                                            },
                                            new SoftFolder
                                            {
                                                Name = "layout", // FT: Copy
                                            },
                                            new SoftFolder
                                            {
                                                Name = "modules",
                                            },
                                        },
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "app.component.html", Data = GetAppComponentHtmlData() },
                                            new SoftFile { Name = "app.component.ts", Data = GetAppComponentTsData() },
                                            new SoftFile { Name = "app.config.ts", Data = GetAppConfigTsData() },
                                            new SoftFile { Name = "app.module.ts", Data = GetAppModuleTsData() },
                                            new SoftFile { Name = "app-routing.module.ts", Data = GetAppRoutingModuleTsData() },
                                            new SoftFile { Name = "transloco-root.module.ts", Data = GetTranslocoRootModuleTsData() },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "assets",
                                        ChildFolders = new List<SoftFolder>
                                        {
                                            new SoftFolder 
                                            {
                                                Name = "i18n",
                                                SoftFiles = new List<SoftFile>
                                                {
                                                    new SoftFile { Name = "en.json", Data = GetTranslocoEnJsonCode() },
                                                    new SoftFile { Name = "sr-Latn-RS.json", Data = GetTranslocoSrLatnRSJsonCode() },
                                                }
                                            },
                                            new SoftFolder
                                            {
                                                Name = "primeng",
                                                ChildFolders = new List<SoftFolder>
                                                {
                                                    new SoftFolder
                                                    {
                                                        Name = "styles", // FT: Copy
                                                    }
                                                }
                                            },
                                        },
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "shared.scss", Data = GetSharedScssCode() },
                                            new SoftFile { Name = "styles.scss", Data = GetStylesScssCode() },
                                        }
                                    },
                                    new SoftFolder
                                    {
                                        Name = "environments",
                                        SoftFiles = new List<SoftFile>
                                        {
                                            new SoftFile { Name = "environment.prod.ts", Data = null },
                                            new SoftFile { Name = "styles.scss", Data = GetEnvironmentTsCode() },
                                        }
                                    }
                                },
                                SoftFiles = new List<SoftFile>
                                {
                                    new SoftFile { Name = "index.html", Data = GetIndexHtmlData() },
                                    new SoftFile { Name = "main.ts", Data = GetMainTsData() },
                                }
                            }
                        },
                        SoftFiles = new List<SoftFile>
                        {
                            new SoftFile { Name = ".editorconfig", Data = GetEditOrConfigData() },
                            new SoftFile { Name = "angular.json", Data = GetAngularJsonData(appName) },
                            new SoftFile { Name = "package.json", Data = GetPackageData(appName) },
                            new SoftFile { Name = "README.md", Data = null },
                            new SoftFile { Name = "tsconfig.app.json", Data = GetTsConfigAppJsonData() },
                            new SoftFile { Name = ".tsconfig.json", Data = GetTsConfigJsonData() },
                            new SoftFile { Name = ".tsconfig.spec.json", Data = GetTsConfigSpecJsonData() },
                            new SoftFile { Name = "vercel.json", Data = GetVercelJsonData() },
                        }
                    }
                },
                SoftFiles = new List<SoftFile>
                {
                    new SoftFile { Name = ".gitignore", Data = null },
                    new SoftFile { Name = "License", Data = null },
                }
            };

            string projectPath = Path.Combine(outputPath, projectName);
        }

        #region Angular

        private string GetVercelJsonData()
        {
            return $$"""
{
    "rewrites": [{ "source": "/(.*)", "destination": "/src/index.html" }]
}
""";
        }

        private string GetTsConfigSpecJsonData()
        {
            return $$"""
/* To learn more about this file see: https://angular.io/config/tsconfig. */
{
  "extends": "./tsconfig.json",
  "compilerOptions": {
    "outDir": "./out-tsc/spec",
    "types": [
      "jasmine",
      "@angular/localize"
    ]
  },
  "include": [
    "src/**/*.spec.ts",
    "src/**/*.d.ts"
  ]
}
""";
        }

        private string GetTsConfigJsonData()
        {
            return $$"""
/* To learn more about this file see: https://angular.io/config/tsconfig. */
{
  "compileOnSave": false,
  "compilerOptions": {
    "baseUrl": "./",
    "paths": {
      "@core/*": ["app/core/*"]
    },
    "outDir": "./dist/out-tsc",
    "forceConsistentCasingInFileNames": true,
    "strict": false,
    "noImplicitOverride": true,
    "noPropertyAccessFromIndexSignature": true,
    "noImplicitReturns": true,
    "noFallthroughCasesInSwitch": true,
    "sourceMap": true,
    "declaration": false,
    "downlevelIteration": true,
    "importHelpers": true,
    "module": "ES2022",
    // "module": "es2020",
    "moduleResolution": "node",
    "experimentalDecorators": true,
    "target": "ES2022",
    // "target": "es5",
    "resolveJsonModule": true,
    "useDefineForClassFields": false,
    "lib": [
      "ES2022",
      // "es2021",
      "dom"
    ]
  },
  "exclude": ["node_modules", "**/node_modules/*"],
  "angularCompilerOptions": {
    "enableI18nLegacyMessageIdFormat": false,
    "fullTemplateTypeCheck": true,
    "strictInjectionParameters": true,
    "strictInputAccessModifiers": true,
    "strictTemplates": true,
    "strictInputTypes": true,
  }
}

""";
        }

        private string GetTsConfigAppJsonData()
        {
            return $$"""
/* To learn more about this file see: https://angular.io/config/tsconfig. */
{
  "extends": "./tsconfig.json",
  "compilerOptions": {
    "outDir": "./out-tsc/app",
    "types": [
      "@angular/localize"
    ]
  },
  "files": [
    "src/main.ts"
  ],
  "include": [
    "src/**/*.d.ts"
  ]
}

""";
        }

        private string GetPackageData(string projectName)
        {
            return $$"""
{
  "name": "{{projectName}}.spa",
  "version": "0.0.0",
  "scripts": {
    "ng": "ng",
    "start": "ng serve --port=4200 --open --configuration=development",
    "build": "ng build",
    "watch": "ng build --watch --configuration development",
    "test": "ng test",
    "i18n:extract": "transloco-keys-manager extract --langs en sr-Latn-RS",
    "i18n:find": "transloco-keys-manager find"
  },
  "private": true,
  "dependencies": {
    "@abacritt/angularx-social-login": "^2.2.0",
    "@angular/animations": "^17.0.0",
    "@angular/cdk": "^17.2.0",
    "@angular/common": "^17.0.0",
    "@angular/compiler": "^17.0.0",
    "@angular/core": "^17.0.0",
    "@angular/forms": "^17.0.0",
    "@angular/platform-browser": "^17.0.0",
    "@angular/platform-browser-dynamic": "^17.0.0",
    "@angular/router": "^17.0.0",
    "@jsverse/transloco": "^7.5.0",
    "angularx-qrcode": "^17.0.1",
    "file-saver": "^2.0.5",
    "json-parser": "^3.1.2",
    "json.date-extensions": "^1.2.2",
    "ngx-spinner": "^16.0.2",
    "primeflex": "^3.3.1",
    "primeicons": "^7.0.0",
    "primeng": "^17.18.9",
    "quill": "^2.0.2",
    "rxjs": "~7.8.0",
    "tslib": "^2.3.0",
    "webpack-dev-server": "^4.15.1",
    "zone.js": "^0.14.10"
  },
  "devDependencies": {
    "@angular-devkit/build-angular": "^17.0.7",
    "@angular/cli": "^17.0.7",
    "@angular/compiler-cli": "^17.0.0",
    "@angular/localize": "^17.2.1",
    "@jsverse/transloco-keys-manager": "^5.1.0",
    "@types/jasmine": "~5.1.0",
    "jasmine-core": "~5.1.0",
    "karma": "~6.4.0",
    "karma-chrome-launcher": "~3.2.0",
    "karma-coverage": "~2.2.0",
    "karma-jasmine": "~5.1.0",
    "karma-jasmine-html-reporter": "~2.1.0",
    "typescript": "~5.2.2"
  }
}
""";
        }

        private string GetAngularJsonData(string appName)
        {
            return $$"""
{
  "$schema": "./node_modules/@angular/cli/lib/config/schema.json",
  "version": 1,
  "newProjectRoot": "projects",
  "projects": {
    "{{appName}}.SPA": {
      "projectType": "application",
      "schematics": {
        "@schematics/angular:component": {
          "style": "scss",
          "standalone": false
        },
        "@schematics/angular:directive": {
          "standalone": false
        },
        "@schematics/angular:pipe": {
          "standalone": false
        }
      },
      "root": "",
      "sourceRoot": "src",
      "prefix": "app",
      "architect": {
        "build": {
          "builder": "@angular-devkit/build-angular:application",
          "options": {
            "outputPath": "dist/{{appName}}.spa",
            "index": "src/index.html",
            "browser": "src/main.ts",
            "polyfills": [
              "zone.js"
            ],
            "tsConfig": "tsconfig.app.json",
            "inlineStyleLanguage": "scss",
            "assets": [
              "src/favicon.ico",
              "src/assets",
              "src/robots.txt"
            ],
            "styles": [
              "src/assets/styles.scss",
              "node_modules/ngx-spinner/animations/ball-clip-rotate-multiple.css"
            ],
            "scripts": []
          },
          "configurations": {
            "production": {
              "budgets": [
                {
                  "type": "initial",
                  "maximumWarning": "1mb",
                  "maximumError": "2mb"
                },
                {
                  "type": "anyComponentStyle",
                  "maximumWarning": "2kb",
                  "maximumError": "4kb"
                }
              ],
              "outputHashing": "all",
              "fileReplacements": [
                {
                  "replace": "src/environments/environment.ts",
                  "with": "src/environments/environment.prod.ts"
                }
              ]
            },
            "development": {
              "optimization": false,
							"extractLicenses": false,
              "sourceMap": true,
							"outputHashing": "all",
							"namedChunks": true,
              "aot": true
            }
          },
          "defaultConfiguration": "production"
        },
        "serve": {
          "builder": "@angular-devkit/build-angular:dev-server",
          "configurations": {
            "production": {
              "buildTarget": "{{appName}}.SPA:build:production"
            },
            "development": {
              "buildTarget": "{{appName}}.SPA:build:development"
            }
          },
          "defaultConfiguration": "development"
        },
        "extract-i18n": {
          "builder": "@angular-devkit/build-angular:extract-i18n",
          "options": {
            "buildTarget": "{{appName}}.SPA:build"
          }
        },
        "test": {
          "builder": "@angular-devkit/build-angular:karma",
          "options": {
            "polyfills": [
              "zone.js",
              "zone.js/testing"
            ],
            "tsConfig": "tsconfig.spec.json",
            "inlineStyleLanguage": "scss",
            "assets": [
              "src/assets"
            ],
            "styles": [
              "src/assets/styles.scss"
            ],
            "scripts": []
          }
        }
      }
    }
  },
  "cli": {
    "analytics": false
  }
}
""";
        }

        private string GetEditOrConfigData()
        {
            return $$"""
# Editor configuration, see https://editorconfig.org
root = true

[*]
charset = utf-8
indent_style = space
indent_size = 2
insert_final_newline = true
trim_trailing_whitespace = true

[*.ts]
quote_type = single

[*.md]
max_line_length = off
trim_trailing_whitespace = false
""";
        }

        private string GetMainTsData()
        {
            return $$"""
/// <reference types="@angular/localize" />

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
""";
        }

        private string GetIndexHtmlData(string appName)
        {
            return $$"""
<!doctype html>
<html lang="sr-Latn-RS">
<head>
  <meta charset="utf-8">
  <title>{{appName.SpaceEveryUpperChar()}}</title>
  <meta name="description" content="{{appName.SpaceEveryUpperChar()}}">
  <meta name="author" content="{{appName.SpaceEveryUpperChar()}}">
  <base href="/">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="icon" type="image/x-icon" href="./assets/demo/images/logo/favicon.ico">
</head>
<body>
  <app-root></app-root>
</body>
</html>
""";
        }

        private string GetEnvironmentTsCode(string appName, string primaryColor)
        {
            return $$"""
import { HttpHeaders, HttpParams } from "@angular/common/http";

export const environment = {
    production: false,
    apiUrl: 'https://localhost:44388/api',
    frontendUrl: 'http://localhost:4200',
    googleAuth: true,
    googleClientId: '24372003240-44eprq8dn4s0b5f30i18tqksep60uk5u.apps.googleusercontent.com',
    companyName: '{{appName.SpaceEveryUpperChar()}}',
    primaryColor: '{{primaryColor}}',
    usersCanRegister: true,
    httpOptions: {
      // headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    },
    httpSkipSpinnerOptions: {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      params: new HttpParams().set('X-Skip-Spinner', 'true')
    },
  };
""";
        }

        private string GetStylesScssCode()
        {
            return $$"""
/* You can add global styles to this file, and also import other style files */

$gutter: 1rem; //for primeflex grid system
@import "./primeng/styles/layout/layout.scss";

/* PrimeNG */
@import "./primeng/styles/themes/saga/saga-blue/theme.scss";

@import "../../node_modules/primeng/resources/primeng.min.css";
@import "../../node_modules/primeflex/primeflex.scss";
@import "../../node_modules/primeicons/primeicons.css";
// PrimeNG editor
@import "../../node_modules/quill/dist/quill.core.css";
@import "../../node_modules/quill/dist/quill.snow.css";


@import "shared.scss";
""";
        }

        private string GetSharedScssCode()
        {
            return $$"""
@import './primeng/styles/layout/variables';

.table-header {
	display: flex;
	justify-content: space-between; 
	align-items: center;
}

@media (max-width: 640px) {
	.table-header {
		display: flex;
		flex-direction: column;
		align-items: start;
		gap: 14px;
	}
}

.c-dashboard-item {
	position: relative;
	display: flex;
	flex-direction: column;
	justify-content: flex-start;
	align-items: center;
	border: solid 1px #e0e0e0;
	border-radius: 5px;
	padding: 20px 30px;
	flex-grow:1;

	&__icon {
		margin-bottom: 10px;
		font-size: 3.2em;
	}
	&__title {
		font-size: 1.1em;
		text-align: center;
		text-decoration: none !important;
	}
	&__bullets {

	}
	&__bullet {

	}

	&__bg {
		position: absolute;
		top: 0px;
		bottom: 0px;
		left: 0px;
		right: 0px;
		background-color: #fff;
		z-index: -5;

		&-icon {
			position: absolute;
			bottom: 0px;
			right: 30px;
			font-size: 15em;
			//transform: rotate(-45deg);
			opacity: 0.04;
			text-decoration: none !important;
		}
	}

	&--eo {
		min-height: 200px;
	}
	&--codebooks {
		min-height: 100px;
		cursor: pointer;
	}
	&--home {
		min-height: 160px;
		cursor: pointer;
    z-index: 1;
		&:hover {
			text-decoration: none;

			.c-dashboard-item__bg {
				background-color: #f8f8f8;
			}
			.c-dashboard-item__bg-icon {
				opacity: 0.2;
				transform: rotate(0deg);
			}
		}

		.c-dashboard-item__icon {
			font-size: 4em;
		}
		.c-dashboard-item__title {
			font-size: 1.3em;
		}
		.c-dashboard-item__bg-icon {
			font-size: 9em;
			right: 40px;
			bottom: 20px;
			transform: rotate(-20deg);
			opacity: 0.1;
			transition: all 1s;
		}
	}
}

.error-color{
	background-color: $errorColor;
}

.error-color-font{
	color: $errorColor;
}

.success-color-font{
	color: green;
}

.error-color-light{
	background-color: $errorColorLight;
}

.soft-table {
	.p-paginator {
		padding: 1rem;
	}
	.p-paginator-left-content {
		@media (min-width: 1400px) {			
			position: absolute;
			padding: 14px;
			left: 0;
		}
	}
	.p-paginator-right-content {
		@media (min-width: 1400px) {			
			position: absolute;
			padding: 14px;
			right: 0;
		}
	}
}

.soft-panel{
	.p-panel-content{
		padding: 0;
	}

	.soft-panel-footer{
		display: flex; 
		align-items: center; 
		justify-content: space-between; 
		gap: 10px; 
		border-top: 1px solid #dee2e6;
		border-bottom-right-radius: 12px;
    	border-bottom-left-radius: 12px;
		padding: 1rem;
	}
}

.disabled{
	background-color: $disabled;
}

.primary-color{
	color: var(--primary-color);
}

.primary-color-background{
	background-color: var(--primary-color);
}

.primary-lighter-color-background{
	background-color: var(--primary-lighter-color);
}

.bold {
	font-weight: 500;
}

.separator{
	border-top: 1px solid var(--primary-color);
	width: 100%;
}

.gray-separator{
	border-top: 1px solid $shade400;
	width: 100%;
}

// FT: You need to manually adjust the height
.vertical-gray-separator{
	border-left: 1px solid $shade400;
}



.google-signin-button {
	width: 100%;
	max-width: 300px;
}

.hover-card {
	padding: 10px;
	border-radius: 12px;
	cursor: pointer;
}

.hover-card:hover {
	background-color: $disabled;
}

.dialog{
	width: 600px;
}

@media (max-width: 600px) {
	.dialog{
		width: 100%;
	}
}

.header{
	font-size: 17.5px;
}

.header-separator{
	margin-top: 7px;
	border-top: 3px solid var(--primary-color);
	width: 60px;
}

.big-header{
	font-size: 34px; 
	font-weight: 400;
	i{
		font-size: 32px; 
		font-weight: 400;
	}
}

.bold-header-separator{
	margin-top: 7px;
	border-top: 6px solid var(--primary-color);
	width: 100px;
}

@media (max-width: 600px) {
	.big-header{
		font-size: 28px;
		i{
			font-size: 26px; 
			font-weight: 400;
		}
	}
}

.link{
	color: var(--primary-color);
	cursor: pointer;
}

.link:hover {
	color: var(--primary-dark-color);
}

.blockHead {
	background-color: var(--primary-color);
	/*width: 150px; */
	height: 60px;
	line-height: 60px;
	display: inline-block;
	position: relative;
  }

.blockHead:after {
	color: var(--primary-color);
	border-left: 30px solid;
	border-top: 30px solid transparent;
	border-bottom: 30px solid transparent;
	display: inline-block;
	content: '';
	position: absolute;
	right: -30px;
	top:0
}

.blocktext{
	color:white;
	font-weight:bold;
	padding-left:10px;
	font-family:Arial;
	font-size:11;
}

.qr-component-wrapper{
	display: flex; 
	gap: 13px; 
	align-items: center;
	.text-wrapper{
		width: 60%;
	}
}

@media (max-width: 600px) {
	.qr-component-wrapper{
		display: flex; 
		flex-direction: column;
		gap: 13px;
		align-items: unset;
		.text-wrapper{
			padding-top: 20px;
			padding-bottom: 20px;
			margin-bottom: 10px;
			width: 100%;
			border-bottom: 1px solid $shade400;
			width: 100%;
		}
	}
}

@media (max-width: 600px) {
	.responsive-hidden{
		display: none;
	}
}

.qr-code{
	border: 2px solid var(--primary-dark-color);
}

.notification-border{
	border-top: 1px solid var(--primary-light-color);
	border-left: 1px solid var(--primary-light-color);
	border-right: 1px solid var(--primary-light-color);
}

.notification-border:last-child {
    border-bottom: 1px solid var(--primary-light-color);
}

.card-overflow-icon{
    text-align: center;
	transform: rotate(30deg);
	color: var(--primary-light-color);
	opacity: 0.2;
	position: absolute; 
	overflow: hidden; 
	right: -30px; 
	top: -25px; 
	z-index: 1;
	i {
		font-size: 270px;
	}
}

.badge {
	position: absolute;
	width: 10px;
	height: 10px;
	top: -5px;
	right: -1px;
	border-radius: 100%;
	background: $dangerButtonBg;
  }

.dashboard-card-wrapper {
	display: flex; 
	flex-direction: column; 
	gap: 14px; 
	padding: 30px;
	position: relative; 
	overflow: hidden;
}

@media (max-width: 600px) {
	.dashboard-card-wrapper{
		padding: 20px;
	}
}

.dashboard-card-wrapper-with-grid {
	display: flex; 
	flex-direction: column; 
	gap: 14px; 
	padding: 30px;
	padding-bottom: 16px; // -14px
	position: relative; 
	overflow: hidden;
}

@media (max-width: 600px) {
	.dashboard-card-wrapper-with-grid{
		padding: 20px;
		padding-bottom: 6px; // -14px
	}
}

.icon-hover {
	cursor: pointer;
	padding: 7px;
	border-radius: 50%;
	transition: background-color 0.3s ease;
}

.icon-hover:hover {
	background-color: $shade200;
}

.gray-color {
	color: $shade600;
}

.multiple-panel-first{
	.p-panel .p-panel-content {
		border-bottom-left-radius: 0px;
		border-bottom-right-radius: 0px;
		border-bottom: none;
	}
}

.multiple-panel-middle{
	.p-panel-header {
		border-top-left-radius: 0px;
		border-top-right-radius: 0px;
	}

	.p-panel .p-panel-content {
		border-bottom-left-radius: 0px;
		border-bottom-right-radius: 0px;
		border-bottom: none;
	}
}

.multiple-panel-last{
	.p-panel-header {
		border-top-left-radius: 0px;
		border-top-right-radius: 0px;
	}
}

.index-card-wrapper {
	.text {
		.header {
			font-size: large;
			font-weight: 500;
			color: rgb(131, 131, 131);
			margin-bottom: 5px;
		}
		.description {
			font-size: small;
			color: rgb(150, 150, 150);
		}
	}
}

.last-card-child {
	margin-bottom: 0px !important;
}

.number-circle {
	border-radius: 50%;
	width: 30px;
	height: 30px;
	padding: 5px;

	background: var(--primary-dark-color);
	border: 1px solid var(--primary-dark-color);
	color: white;
	text-align: center;
	margin-right: 16px;
	display: inline-block;
}

.non-grid-panel-bottom-padding{
	padding-bottom: 14px;
}

@media (max-width: 600px) {
	.non-grid-panel-bottom-padding{
		padding-bottom: 0px;
	}
}

.panel-body-wrapper{
	padding: 28px; 
	padding-bottom: 14px;
}

@media (max-width: 600px) {
	.panel-body-wrapper{
		padding: 14px; 
		padding-bottom: 0px;
	}
}

@media (max-width: 600px) {
	.panel-add-button{
		margin-bottom: 14px;
	}
}

.last-child-zero-margin{
	margin-bottom: 0px !important;
}

.card-margin-bottom{
	margin-bottom: 28px;
}

@media (max-width: 600px) {
	.card-margin-bottom{
		margin-bottom: 14px;
	}
}

.card-with-grid-padding-bottom{
	padding-bottom: 14px !important;
}

@media (max-width: 600px) {
	.card-with-grid-padding-bottom{
		padding-bottom: 6px !important;
	}
}

.responsive-card-padding{
	padding: 28px;
}

@media (max-width: 600px) {
	.responsive-card-padding{
		padding: 20px;
	}
}

.image-container {
    width: 300px;
    height: 300px;
	display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden;
}

.image-container img {
	object-fit: cover;
}

.p-dataview .p-dataview-header {
    background: transparent;
    color: transparent;
    border: none;
    border-width: 0;
    padding: 0;
    font-weight: 0;
}
""";
        }

        private string GetTranslocoSrLatnRSJsonCode()
        {
            return $$$"""
{
    "ContinueWithGoogle": "Nastavite sa Google nalogom",
    "Email": "Email",
    "Password": "Lozinka",
    "Login": "Prijavi se",
    "Name": "Missing value for 'Name'",
    "NameLatin": "Missing value for 'NameLatin'",
    "Code": "Missing value for 'Code'",
    "Checked": "Missing value for 'Checked'",
    "NotificationDTO": "Missing value for 'NotificationDTO'",
    "SelectedIds": "Missing value for 'SelectedIds'",
    "Submit": "Potvrdite",
    "UserList": "Korisnici",
    "SuperRoles": "Super uloge",
    "Save": "Sačuvajte",
    "PermissionList": "Dozvole",
    "NotificationList": "Notifikacije",
    "NotifyUsers": "Obavestite korisnike",
    "Recipients": "Primaoci",
    "SendEmailNotification": "Pošaljite email notifikaciju",
    "AgreementsOnRegister": "Klikom na Slažem se i pridružujem ili Nastavite, prihvatate",
    "UserAgreement": "uslove korišćenja",
    "PrivacyPolicy": "politiku privatnosti",
    "and": "i",
    "CookiePolicy": "politiku upotrebe kolčića",
    "AgreeAndJoin": "Slažem se i pridružujem",
    "AlreadyOnLoyalty": "Već imate profil? Prijavite se",
    "ContinueWithGoogle": "Nastavite sa Google nalogom",
    "or": "ili",
    "All": "Sve",
    "AccountVerificationHeader": "Verifikacija profila",
    "AccountVerificationTitle": "Verifikujte svoju email adresu",
    "AccountVerificationDescription": "Poslali smo vam verifikacioni kod na {{ email }}. Molimo vas da proverite inbox ili spam folder i unesete kod koji smo vam poslali kako biste završili proces. Hvala!",
    "GoToGmail": "Idi na Gmail",
    "GoToYahoo": "Idi na Yahoo",
    "ResendVerificationCodeFirstPart": "Ako niste pronašli, možete",
    "ResendVerificationCodeLinkSecondPart": "ponovo poslati verifikacioni kod.",
    "ForgotPassword": "Zaboravili ste lozinku?",
    "Login": "Prijavite se",
    "RememberYourPassword": "Setili ste se lozinke?",
    "ResetPassword": "Promenite lozinku",
    "DragAndDropFilesHereToUpload": "Ovde prevucite i otpustite datoteke da biste ih otpremili.",
    "PleaseConfirmToProceed": "Molimo Vas potvrdite da biste nastavili.",
    "Cancle": "Odustanite",
    "Confirm": "Potvrdite",
    "Clear": "Uklonite",
    "ExportToExcel": "Izvezite u Excel",
    "Select": "Odaberite",
    "NoRecordsFound": "Ne postoji nijedan zapis.",
    "Loading": "Učitavanje",
    "TotalRecords": "Ukupno zapisa",
    "AddNew": "Dodajte",
    "Return": "Nazad",
    "Currency": "RSD",
    "Actions": "Akcije",
    "Details": "Detalji",
    "User": "Korisnik",
    "CreatedAt": "Kreirano",
    "Delete": "Obrišite",
    "Name": "Naziv",
    "Title": "Naslov",
    "SuccessfulAttempt": "Vaš pokušaj je obrađen.",
    "MarkAsRead": "Označite kao pročitano",
    "MarkAsUnread": "Označite kao nepročitano",
    "Email": "Email",
    "Slug": "Url putanja",
    "YourProfile": "Vaš profil",
    "Logout": "Odjavite se",
    "Home": "Početna",
    "SuperAdministration": "Super administracija",
    "Administration": "Administracija",
    "SuccessfullySentVerificationCode": "Verifikacioni kod je uspešno poslat.",
    "YouHaveSuccessfullyVerifiedYourAccount": "Uspešno ste verifikovali svoj profil.",
    "YouHaveSuccessfullyChangedYourPassword": "Uspešno ste promenili lozinku.",
    "SuccessfulAction": "Uspešno izvršena operacija",
    "Warning": "Upozorenje",
    "Error": "Greška",
    "ServerLostConnectionDetails": "Veza je izgubljena. Molimo proverite vašu internet konekciju. Ako se problem nastavi, kontaktirajte naš tim za podršku.",
    "ServerLostConnectionTitle": "Veza je izgubljena",
    "PermissionErrorDetails": "Nemate dozvolu za ovu operaciju.",
    "PermissionErrorTitle": "Nemate dozvolu",
    "NotFoundDetails": "Zatraženi resurs nije pronađen, molimo pokušajte ponovo.",
    "NotFoundTitle": "Nije pronađeno",
    "UnexpectedErrorTitle": "Dogodila se greška",
    "UnexpectedErrorDetails": "Naš tim je obavešten i radimo na rešenju problema. Molimo Vas da pokušate ponovo kasnije.",
    "SelectAColor": "Odaberite boju",
    "DatesBefore": "Datumi pre",
    "DatesAfter": "Datumi posle",
    "Equals": "Jednako",
    "MoreThan": "Više od",
    "LessThan": "Manje od",
    "AreYouSureToDelete": "Da li ste sigurni?",
    "SuccessfullyDeletedMessage": "Uspešno brisanje.",
    "Yes": "Da",
    "No": "Ne",
    "SuccessfulSaveToastDescription": "Uspešno sačuvano.",
    "SuccessfulSyncToastDescription": "Uspešno ste ažurirali podatke.",
    "YouHaveSomeInvalidFieldsDescription": "Neka od polja na formi nisu ispravno uneta, molimo Vas da proverite koja i pokušate ponovo.",
    "YouHaveSomeInvalidFieldsTitle": "Neispravna polja na formi",
    "Remove": "Ukloni",
    "AddAbove": "Dodaj iznad",
    "AddBelow": "Dodaj ispod",
    "ListCanNotBeEmpty": "Lista '{{value}}' ne može biti prazna.",
    "NotEmpty": "Polje ne sme biti prazno.",
    "NotEmptyLengthEmailAddress": "Polje ne sme biti prazno, mora da ima minimum {{min}}, a maksimum {{max}} karaktera i mora biti validna email adresa.",
    "NotEmptyLength": "Polje ne sme biti prazno i mora da ima minimum {{min}}, a maksimum {{max}} karaktera.",
    "NotEmptySingleLength": "Polje ne sme biti prazno i mora da ima {{length}} karaktera.",
    "Length": "Polje mora da ima minimum {{min}}, a maksimum {{max}} karaktera.",
    "NotEmptyNumberRangeMin": "Polje ne sme biti prazno i vrednost mora da bude veća ili jednaka {{min}}.",
    "NumberRangeMin": "Vrednost polja mora da bude veća ili jednaka {{min}}.",
    "SingleLength": "Polje mora da ima {{length}} karaktera.",
    "NotEmptyPrecisionScale": "Vrednost polja mora da ima ukupno {{precision}} cifara, i broj cifara nakon zareza ne sme biti veci od {{scale}}.",
    "IdToken": "/",
    "Browser": "/",
    "NewPassword": "Nova lozinka",
    "ExpireAt": "Ističe",
    "UserEmail": "Email",
    "AccessToken": "/",
    "Token": "/",
    "Password": "Lozinka",
    "RefreshToken": "/",
    "IpAddress": "Ip adresa",
    "Reload": "Osvežite",
    "TokenString": "/",
    "Status": "Status",
    "Message": "Poruka",
    "SelectedPermissionIds": "/",
    "SelectedUserIds": "/",
    "RoleDTO": "/",
    "VerificationCode": "Verifikacioni kod",
    "NameLatin": "Naziv latinicom",
    "Description": "Opis",
    "DescriptionLatin": "Opis latinicom",
    "Code": "Kod",
    "Id": "Id",
    "Version": "Verzija",
    "ModifiedAt": "Izmenjeno",
    "Roles": "Uloge",
    "Users": "Korisnici",
    "ExternalProvider": "/",
    "ForgotPasswordVerificationToken": "/",
    "JwtAuthResult": "/",
    "AuthResult": "/",
    "LoginVerificationToken": "/",
    "RefreshTokenRequest": "/",
    "Registration": "/",
    "RegistrationVerificationResult": "/",
    "RegistrationVerificationToken": "/",
    "RoleSaveBody": "/",
    "VerificationTokenRequest": "/",
    "Permission": "Dozvola",
    "Role": "Uloga",
    "RoleUser": "/",
    "IsMarkedAsRead": "Označeno kao pročitano",
    "Checked": "Čekirano",
    "NotificationDTO": "Notifikacija",
    "TableFilter": "Filter tabele",
    "SelectedIds": "Izabrani",
    "UnselectedIds": "Odčekirani",
    "IsAllSelected": "Sve je izabrano",
    "UserExtendedDTO": "/",
    "SelectedRoleIds": "/",
    "Price": "Cena",
    "Category": "Kategorija",
    "LinkToWebsite": "Link do sajta",
    "EmailBody": "Sadržaj email-a",
    "Notifications": "Notifikacije",
    "LogoImageData": "/",
    "LogoImage": "Logo",
    "PrimaryColor": "Primarna boja",
    "OrderNumber": "Redni broj",
    "ValidFrom": "Važi od",
    "ValidTo": "Važi do",
    "Guid": "Guid",
    "Product": "Proizvod",
    "Transaction": "Transakcija",
    "HasLoggedInWithExternalProvider": "Prijavljen sa eksternim provajderom",
    "NumberOfFailedAttemptsInARow": "Broj neuspešnih pokušaja uzastopno",
    "BirthDate": "Datum rođenja",
    "Gender": "Pol",
    "Notification": "Notifikacija",
    "UserExtended": "Korisnik",
    "Brand": "Brend",
    "NotificationSaveBody": "/",
    "QrCode": "QR kod",
    "NotificationUser": "/",
    "Primeng": {
      "dayNames": [
        "Nedelja",
        "Ponedeljak",
        "Utorak",
        "Sreda",
        "Četvrtak",
        "Petak",
        "Subota"
      ],
      "dayNamesShort": [
        "Ned",
        "Pon",
        "Uto",
        "Sre",
        "Čet",
        "Pet",
        "Sub"
      ],
      "dayNamesMin": [
        "Ne",
        "Po",
        "Ut",
        "Sr",
        "Če",
        "Pe",
        "Su"
      ],
      "monthNames": [
        "Januar",
        "Februar",
        "Mart",
        "April",
        "Maj",
        "Jun",
        "Jul",
        "Avgust",
        "Septembar",
        "Oktobar",
        "Novembar",
        "Decembar"
      ],
      "monthNamesShort": [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "Maj",
        "Jun",
        "Jul",
        "Avg",
        "Sep",
        "Okt",
        "Nov",
        "Dec"
      ],
      "today": "Danas",
      "weekHeader": "Vik",
      "clear": "Uklonite",
      "apply": "Pretražite",
      "emptyMessage": "Nema rezultata",
      "emptyFilterMessage": "Nema rezultata"
    },
    "EmptyMessage": "Nema rezultata",
    "ClearFilters": "Uklonite sve filtere",
    "YouDoNotHaveAnyNotifications": "Nemate nijednu notifikaciju.",
    "More than": "Više od",
    "BadRequestDetails": "Sistem ne može da obradi zahtev. Molimo vas da proverite zahtev i pokušate ponovo.",
}
""";
        }

        private string GetTranslocoEnJsonCode()
        {
            return $$"""
{

}
""";
        }

        private string GetTranslocoRootModuleTsData()
        {
            return $$"""
import { provideTransloco, TranslocoModule } from '@jsverse/transloco';
import { NgModule } from '@angular/core';

import { TranslocoHttpLoader } from './core/services/transloco-loader';
import { environment } from 'src/environments/environment';

@NgModule({
  exports: [TranslocoModule],
  providers: [
    provideTransloco({
      config: {
        availableLangs: ['sr-Latn-RS', 'en'],
        defaultLang: 'sr-Latn-RS',

        // Remove this option if your application doesn't support changing language in runtime.
        // reRenderOnLangChange: true,
        prodMode: environment.production,
      },
      loader: TranslocoHttpLoader,
    }),
  ],
})
export class TranslocoRootModule {}
""";
        }

        private string GetAppModuleTsData()
        {
            return $$"""
import { ErrorHandler, NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotfoundComponent } from './layout/components/notfound/notfound.component';
import { AppLayoutModule } from './layout/components/layout/app.layout.module';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { MessagesModule } from 'primeng/messages';
import { CoreModule } from './core/modules/core.module';
import { SoftMessageService } from './core/services/soft-message.service';
import { SoftErrorHandler } from './core/handlers/soft-error-handler';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from './business/services/api/api.service';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { SocialLoginModule, SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import { GoogleLoginProvider } from '@abacritt/angularx-social-login';
import { environment } from 'src/environments/environment';
import { TranslocoRootModule } from './transloco-root.module';
import { BusinessModule } from './business/business.module';

@NgModule({
  declarations: [
    AppComponent,
    NotfoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppLayoutModule,
    MessagesModule,
    ToastModule,
    SocialLoginModule,
    TranslocoRootModule,
    NgxSpinnerModule.forRoot({ type: 'ball-clip-rotate-multiple' }),
    BusinessModule,
    CoreModule,
  ],
  providers: [
    SoftMessageService,
    MessageService,
    {
    provide: ErrorHandler,
    useClass: SoftErrorHandler,
    },
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              environment.googleClientId, 
              {
                scopes: 'email',
                oneTapEnabled: false,
                prompt: 'none',
                // plugin_name: 'the name of the Google OAuth project you created'
              },
            )
          },
        ],
        onError: (err) => {
          console.error(err);
        }
      } as SocialAuthServiceConfig
    },
    ApiService,
    NgxSpinnerService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
""";
        }

        private string GetAppConfigTsData()
        {
            return $$"""

""";
        }

        private string GetAppComponentTsData()
        {
            return $$"""

""";
        }

        private string GetAppComponentHtmlData()
        {
            return $$"""

""";
        }

        private string GetAppRoutingModuleTsData()
        {
            return $$"""

""";
        }

        private string GetBusinessModuleTsData()
        {
            return $$"""

""";
        }

        private string GetValidationRulesTsCode()
        {
            return $$"""

""";
        }

        private string GetMergeLabelsCode()
        {
            return $$"""

""";
        }

        private string GetMergeClassNamesTsCode()
        {
            return $$"""

""";
        }

        private string GetAPIServiceTsCode()
        {
            return $$"""

""";
        }

        private string GetAPIServiceSecurityTsCode()
        {
            return $$"""

""";
        }

        #endregion

    }
}
