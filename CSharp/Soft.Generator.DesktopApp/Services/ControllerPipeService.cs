using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Soft.Generator.Shared.Classes;
using Spider.DesktopApp.Controllers;
using Spider.DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Services
{
    public class ControllerPipeService
    {
        private readonly WebApplicationController _webApplicationController;
        private readonly CompanyController _companyController;
        private readonly FrameworkController _frameworkController;
        private readonly HomeController _homeController;
        private readonly DllPathController _dllPathController;
        private readonly PermissionController _permissionController;
        private readonly SettingController _settingController;

        public ControllerPipeService(
            WebApplicationController webApplicationController,
            CompanyController companyController,
            FrameworkController frameworkController,
            HomeController homeController,
            DllPathController dllPathController,
            PermissionController permissionController,
            SettingController settingController
        )
        {
            _webApplicationController = webApplicationController;
            _companyController = companyController;
            _frameworkController = frameworkController;
            _homeController = homeController;
            _dllPathController = dllPathController;
            _permissionController = permissionController;
            _settingController = settingController;
        }

        public string GetResponse(RequestBody getRequestBody)
        {
            string controllerName = getRequestBody.ControllerName;
            string methodName = getRequestBody.MethodName;
            List<string> args = getRequestBody.Args;

            if (controllerName == nameof(CompanyController))
            {
                if (methodName == nameof(CompanyController.GetCompanyList))
                {
                    return JsonSerializer.Serialize(_companyController.GetCompanyList());
                }
                else if (methodName == nameof(CompanyController.GetCompany))
                {
                    return JsonSerializer.Serialize(_companyController.GetCompany(long.Parse(args[0])));
                }
                else if (methodName == nameof(CompanyController.SaveCompany))
                {
                    return JsonSerializer.Serialize(_companyController.SaveCompany(JsonSerializer.Deserialize<Company>(args[0]), JsonSerializer.Deserialize<List<long>>(args[1])));
                }
                else if (methodName == nameof(CompanyController.DeleteCompany))
                {
                    _companyController.DeleteCompany(long.Parse(args[0]));
                    return null;
                }
                else if (methodName == nameof(CompanyController.GetPermissionList))
                {
                    return JsonSerializer.Serialize(_companyController.GetPermissionList());
                }
                else if (methodName == nameof(CompanyController.GetPermissionListForTheCompany))
                {
                    return JsonSerializer.Serialize(_companyController.GetPermissionListForTheCompany(long.Parse(args[0])));
                }
            }

            if (controllerName == nameof(DllPathController))
            {
                if (methodName == nameof(DllPathController.GetDllPathList))
                {
                    return JsonSerializer.Serialize(_dllPathController.GetDllPathList());
                }
                else if (methodName == nameof(DllPathController.GetDllPath))
                {
                    return JsonSerializer.Serialize(_dllPathController.GetDllPath(long.Parse(args[0])));
                }
                else if (methodName == nameof(DllPathController.SaveDllPath))
                {
                    return JsonSerializer.Serialize(_dllPathController.SaveDllPath(JsonSerializer.Deserialize<DllPath>(args[0])));
                }
                else if (methodName == nameof(DllPathController.DeleteDllPath))
                {
                    _dllPathController.DeleteDllPath(long.Parse(args[0]));
                    return null;
                }
                else if (methodName == nameof(DllPathController.GetWebApplicationList))
                {
                    return JsonSerializer.Serialize(_dllPathController.GetWebApplicationList());
                }
            }

            if (controllerName == nameof(FrameworkController))
            {
                if (methodName == nameof(FrameworkController.GetFrameworkList))
                {
                    return JsonSerializer.Serialize(_frameworkController.GetFrameworkList());
                }
                else if (methodName == nameof(FrameworkController.GetFramework))
                {
                    return JsonSerializer.Serialize(_frameworkController.GetFramework(long.Parse(args[0])));
                }
                else if (methodName == nameof(FrameworkController.SaveFramework))
                {
                    return JsonSerializer.Serialize(_frameworkController.SaveFramework(JsonSerializer.Deserialize<Framework>(args[0])));
                }
                else if (methodName == nameof(FrameworkController.DeleteFramework))
                {
                    _frameworkController.DeleteFramework(long.Parse(args[0]));
                    return null;
                }
            }

            if (controllerName == nameof(PermissionController))
            {
                if (methodName == nameof(PermissionController.GetPermissionList))
                {
                    return JsonSerializer.Serialize(_permissionController.GetPermissionList());
                }
            }

            if (controllerName == nameof(SettingController))
            {
                if (methodName == nameof(SettingController.GetSettingList))
                {
                    return JsonSerializer.Serialize(_settingController.GetSettingList());
                }
                else if (methodName == nameof(SettingController.GetSetting))
                {
                    return JsonSerializer.Serialize(_settingController.GetSetting(long.Parse(args[0])));
                }
                else if (methodName == nameof(SettingController.SaveSetting))
                {
                    return JsonSerializer.Serialize(_settingController.SaveSetting(JsonSerializer.Deserialize<Setting>(args[0])));
                }
                else if (methodName == nameof(SettingController.DeleteSetting))
                {
                    _settingController.DeleteSetting(long.Parse(args[0]));
                    return null;
                }
                else if (methodName == nameof(SettingController.GetFrameworkList))
                {
                    return JsonSerializer.Serialize(_settingController.GetFrameworkList());
                }
            }

            if (controllerName == nameof(WebApplicationController))
            {
                if (methodName == nameof(WebApplicationController.GetWebApplicationList))
                {
                    return JsonSerializer.Serialize(_webApplicationController.GetWebApplicationList());
                }
                else if (methodName == nameof(WebApplicationController.GetWebApplication))
                {
                    return JsonSerializer.Serialize(_webApplicationController.GetWebApplication(long.Parse(args[0])));
                }
                else if (methodName == nameof(WebApplicationController.SaveWebApplication))
                {
                    return JsonSerializer.Serialize(_webApplicationController.SaveWebApplication(JsonSerializer.Deserialize<WebApplication>(args[0])));
                }
                else if (methodName == nameof(WebApplicationController.DeleteWebApplication))
                {
                    _webApplicationController.DeleteWebApplication(long.Parse(args[0]));
                    return null;
                }
                else if (methodName == nameof(WebApplicationController.GetCompanyList))
                {
                    return JsonSerializer.Serialize(_webApplicationController.GetCompanyList());
                }
                else if (methodName == nameof(WebApplicationController.GetSettingList))
                {
                    return JsonSerializer.Serialize(_webApplicationController.GetSettingList());
                }
                else if (methodName == nameof(WebApplicationController.GetDllPathList))
                {
                    return JsonSerializer.Serialize(_webApplicationController.GetDllPathList());
                }
                else if (methodName == nameof(WebApplicationController.GetDllPathListForTheWebApplication))
                {
                    return JsonSerializer.Serialize(_webApplicationController.GetDllPathListForTheWebApplication(long.Parse(args[0])));
                }
                else if (methodName == nameof(WebApplicationController.GenerateNetAndAngularStructure))
                {
                    _webApplicationController.GenerateNetAndAngularStructure(long.Parse(args[0]));
                    return null;
                }
                else if (methodName == nameof(WebApplicationController.GenerateBusinessFiles))
                {
                    _webApplicationController.GenerateBusinessFiles(long.Parse(args[0]));
                    return null;
                }
            }

            throw new NotImplementedException($"The controller: {controllerName} and method: {methodName} are not implemented.");
        }
    }
}
