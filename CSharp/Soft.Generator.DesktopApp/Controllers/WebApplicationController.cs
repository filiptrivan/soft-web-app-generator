using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Soft.Generator.Shared.Interfaces;

namespace Soft.Generator.DesktopApp.Controllers
{
    public class WebApplicationController
    {
        DesktopAppBusinessService _desktopAppBusinessService;
        ISqlConnection _connection;

        public WebApplicationController(
            DesktopAppBusinessService desktopAppBusinessService, 
            ISqlConnection connection
        )
        {
            _desktopAppBusinessService = desktopAppBusinessService;
            _connection = connection;
        }

        public WebApplication SaveWebApplication(WebApplication webApplication)
        {
            return new SaveWebApplicationSO(_connection, webApplication).Execute();
        }

        public void DeleteWebApplication(long webApplicationId)
        {
            new DeleteWebApplicationSO(_connection, webApplicationId).Execute();
        }

        public List<WebApplication> GetWebApplicationList()
        {
            return new GetWebApplicationListSO(_connection).Execute();
        }

        public WebApplication GetWebApplication(long webApplicationId)
        {
            return new GetWebApplicationSO(_connection, webApplicationId).Execute();
        }

        public List<Company> GetCompanyList()
        {
            return new GetCompanyListSO(_connection).Execute();
        }

        public List<Setting> GetSettingList()
        {
            return new GetSettingListSO(_connection).Execute();
        }

        public List<DllPath> GetDllPathList()
        {
            return new GetDllPathListSO(_connection).Execute();
        }

        public List<DllPath> GetDllPathListForTheWebApplication(long webApplicationId)
        {
            return new GetDllPathListForWebApplicationSO(_connection, webApplicationId).Execute();
        }

        public void GenerateNetAndAngularStructure(long webApplicationId)
        {
            _desktopAppBusinessService.GenerateNetAndAngularStructure(webApplicationId);
        }

    }
}
