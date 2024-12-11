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
        public string Generate(List<Type> entities)
        {
            GenerateControllerCode(entities);
        }

        private void GenerateControllerCode(List<Type> entities)
        {
            foreach (Type entity in entities)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($$"""
using Microsoft.AspNetCore.Mvc;
using {{Settings.BaseProjectNamespace}}.Business.DTO;
using {{Settings.BaseProjectNamespace}}.Business.Entities;
using {{Settings.BaseProjectNamespace}}.Business.Services;
using {{Settings.BaseProjectNamespace}}.Services;
using {{Settings.BaseProjectNamespace}}.Shared.Terms;
using Soft.Generator.Shared.Attributes;
using Soft.Generator.Shared.DTO;
using Soft.Generator.Shared.Helpers;
using Soft.Generator.Shared.Interfaces;

namespace {{Settings.BaseProjectNamespace}}.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class {{entity.Name}}Controller : SoftControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly {{Settings.BaseBusinessServiceName}}BusinessService _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;

        public StoreController(IApplicationDbContext context, {{Settings.BaseBusinessServiceName}}BusinessService {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService)
        {
            _context = context;
            _{{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService = {{Settings.BaseBusinessServiceName.FirstCharToLower()}}BusinessService;
        }

{{string.Join("\n", GetControllerMethods(entity))}}

    }
}
""");

                // Write to the file
            }
        }

        private List<string> GetControllerMethods(Type entity)
        {
            List<string> result = new List<string>();

            result.AddRange(GetEntityControllerMethods(entity));

            result.AddRange(GetEntityOneToManyControllerMethods(entity));

            return result;
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
public async Task<StoreDTO> SaveStore(StoreDTO storeDTO)
{
    return await _loyalsBusinessService.SaveStoreAndReturnDTOAsync(storeDTO, false, false);
}

""");

            foreach (PropertyInfo manyToOneProperty in entity.GetProperties().Where(x => x.PropertyType.IsManyToOneType()))
            {
                // TODO FT: When you make these methods, check if the type is ManyToMany first, if it's not throw exception
                if (manyToOneProperty.IsAutocomplete())
                {
                    
                }

                if (manyToOneProperty.IsDropdown())
                {

                }
                result.Add
            }

            return result;
        }

        private List<string> GetEntityOneToManyControllerMethods(Type entity)
        {
            throw new NotImplementedException();
        }
    }
}
