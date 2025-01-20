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
    public class NetControllerMethodsGenerator : IFileGenerator
    {
        public void Generate(List<Type> entities)
        {
            foreach (Type entity in entities)
            {
                string generatedCode = GenerateControllerCode(entity);

                Helper.WriteToFile(generatedCode, @$"{Settings.DownloadPath}\{entity.Name}.cs");
            }
        }

        private string GenerateControllerCode(Type entity)
        {
            return $$"""
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using Soft.Generator.Shared.Attributes;
using Soft.Generator.Shared.DTO;
using Soft.Generator.Shared.Helpers;
using Soft.Generator.Shared.Interfaces;
using {{Settings.BaseProjectNamespace}}.Business.DTO;
using {{Settings.BaseProjectNamespace}}.Business.Entities;
using {{Settings.BaseProjectNamespace}}.Business.Services;
using {{Settings.BaseProjectNamespace}}.Services;
using {{Settings.BaseProjectNamespace}}.Shared.Terms;

namespace {{Settings.BaseProjectNamespace}}.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class {{entity.Name}}Controller : {{entity.Name}}BaseController
    {
        private readonly IApplicationDbContext _context;
        private readonly {{Settings.BaseBusinessServiceName}}BusinessService _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;

        public {{entity.Name}}Controller(IApplicationDbContext context, {{Settings.BaseBusinessServiceName}}BusinessService {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService, BlobContainerClient blobContainerClient)
            : base(context, plenumRMTBusinessService, blobContainerClient)
        {
            _context = context;
            _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService = {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;
        }

    }
}
""";
        }

        private List<string> GetEntityControllerMethods(Type entity)
        {
            List<string> result = new List<string>();

            result.Add($$"""
        [HttpPost]
        [AuthGuard]
        public async Task<TableResponseDTO<{{entity.Name}}DTO>> Load{{entity.Name}}TableData(TableFilterDTO tableFilterDTO)
        {
            return await _loyalsBusinessService.Load{{entity.Name}}TableData(tableFilterDTO, _context.DbSet<{{entity.Name}}>(), false);
        }

        [HttpPost]
        [AuthGuard]
        public async Task<IActionResult> Export{{entity.Name}}TableDataToExcel(TableFilterDTO tableFilterDTO)
        {
            byte[] fileContent = await _loyalsBusinessService.Export{{entity.Name}}TableDataToExcel(tableFilterDTO, _context.DbSet<{{entity.Name}}>(), false);
            return File(fileContent, SettingsProvider.Current.ExcelContentType, Uri.EscapeDataString($"{Terms.{{entity.Name}}ExcelExportName}.xlsx"));
        }

        [HttpDelete]
        [AuthGuard]
        public async Task Delete{{entity.Name}}(int id)
        {
            await _loyalsBusinessService.Delete{{entity.Name}}Async(id, false);
        }

        [HttpGet]
        [AuthGuard]
        public async Task<{{entity.Name}}DTO> Get{{entity.Name}}(int id)
        {
            return await _loyalsBusinessService.Get{{entity.Name}}DTOAsync(id, false);
        }

        [HttpPut]
        [AuthGuard]
        public async Task<{{entity.Name}}DTO> Save{{entity.Name}}({{entity.Name}}DTO {{entity.Name.FirstCharToLower()}}DTO)
        {
            return await _loyalsBusinessService.Save{{entity.Name}}AndReturnDTOAsync({{entity.Name.FirstCharToLower()}}DTO, false, false);
        }

{{string.Join("\n", GetEntityOneToManyControllerMethods(entity))}}

""");

            return result;
        }

        private List<string> GetEntityOneToManyControllerMethods(Type entity)
        {
            List<string> result = new List<string>();

            foreach (PropertyInfo manyToOneProperty in entity.GetProperties().Where(x => x.PropertyType.IsManyToOneType()))
            {
                if (manyToOneProperty.IsAutocomplete())
                {
                    result.Add($$"""
        [HttpGet]
        [AuthGuard]
        public async Task<List<NamebookDTO<{{Helper.GetGenericIdTypeFromTheBaseType(manyToOneProperty.PropertyType)}}>>> Load{{entity.Name}}ListForAutocomplete(int limit, string query)
        {
            return await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.Load{{entity.Name}}ListForAutocomplete(limit, query, _context.DbSet<{{entity.Name}}>());
        }
""");
                }

                if (manyToOneProperty.IsDropdown())
                {
                    result.Add($$"""
        [HttpGet]
        [AuthGuard]
        public async Task<List<NamebookDTO<{{Helper.GetGenericIdTypeFromTheBaseType(manyToOneProperty.PropertyType)}}>>> Load{{manyToOneProperty.Name}}ListForDropdown()
        {
            return await _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService.Load{{manyToOneProperty.Name}}ListForDropdown(_context.DbSet<{{manyToOneProperty.Name}}>(), false);
        }
""");
                }
            }

            return result;
        }
    }
}
