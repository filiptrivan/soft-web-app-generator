using Soft.Generator.DesktopApp.Entities;
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
        public void Generate(List<Type> entities, WebApplication webApplication)
        {
            foreach (Type entity in entities)
            {
                string generatedCode = GenerateControllerCode(entity, webApplication.Name);

                Helper.WriteToFile(generatedCode, @$"{Settings.DownloadPath}\{entity.Name}Controller.cs");
            }
        }

        private string GenerateControllerCode(Type entity, string appName)
        {
            return $$"""
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using Soft.Generator.Shared.Attributes;
using Soft.Generator.Shared.DTO;
using Soft.Generator.Shared.Helpers;
using Soft.Generator.Shared.Interfaces;
using {{appName}}.Business.DTO;
using {{appName}}.Business.Entities;
using {{appName}}.Business.Services;
using {{appName}}.Shared.Terms;

namespace {{appName}}.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class {{entity.Name}}Controller : {{entity.Name}}BaseController
    {
        private readonly IApplicationDbContext _context;
        private readonly {{appName}}BusinessService _{{appName.FirstCharToLower()}}BusinessService;

        public {{entity.Name}}Controller(IApplicationDbContext context, {{appName}}BusinessService {{appName.FirstCharToLower()}}BusinessService, BlobContainerClient blobContainerClient)
            : base(context, {{appName.FirstCharToLower()}}BusinessService, blobContainerClient)
        {
            _context = context;
            _{{appName.FirstCharToLower()}}BusinessService = {{appName.FirstCharToLower()}}BusinessService;
        }

    }
}
""";
        }

    }
}
