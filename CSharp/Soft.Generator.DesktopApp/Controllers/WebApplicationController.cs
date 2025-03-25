using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Controllers
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

        public void DeleteWebApplication(long id)
        {
            _desktopAppBusinessService.DeleteWebApplication(id);
        }

        public List<WebApplication> GetWebApplicationList()
        {
            return _desktopAppBusinessService.GetWebApplicationList();
        }

        public WebApplication GetWebApplication(long id)
        {
            return _desktopAppBusinessService.GetWebApplication(id);
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

        public void GenerateBusinessFiles(long webApplicationId)
        {
            _desktopAppBusinessService.GenerateBusinessFiles(webApplicationId);
        }
    }
}
