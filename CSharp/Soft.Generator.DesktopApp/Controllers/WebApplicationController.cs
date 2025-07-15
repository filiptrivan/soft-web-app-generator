using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Controllers
{
    public class WebApplicationController
    {
        DesktopAppBusinessService _desktopAppBusinessService;

        public WebApplicationController(DesktopAppBusinessService desktopAppBusinessService)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public WebApplication SaveWebApplication(WebApplication webApplication)
        {
            return _desktopAppBusinessService.SaveWebApplication(webApplication);
        }

        public void DeleteWebApplication(long webApplicationId)
        {
            _desktopAppBusinessService.DeleteWebApplication(webApplicationId);
        }

        public List<WebApplication> GetWebApplicationList()
        {
            return _desktopAppBusinessService.GetWebApplicationList();
        }

        public WebApplication GetWebApplication(long webApplicationId)
        {
            return _desktopAppBusinessService.GetWebApplication(webApplicationId);
        }

        public List<Company> GetCompanyList()
        {
            return _desktopAppBusinessService.GetCompanyList();
        }

        public List<Setting> GetSettingList()
        {
            return _desktopAppBusinessService.GetSettingList();
        }

        public List<DllPath> GetDllPathList()
        {
            return _desktopAppBusinessService.GetDllPathList();
        }

        public List<DllPath> GetDllPathListForTheWebApplication(long webApplicationId)
        {
            return _desktopAppBusinessService.GetDllPathListForWebApplication(webApplicationId);
        }

        public void GenerateNetAndAngularStructure(long webApplicationId)
        {
            _desktopAppBusinessService.GenerateNetAndAngularStructure(webApplicationId);
        }

    }
}
