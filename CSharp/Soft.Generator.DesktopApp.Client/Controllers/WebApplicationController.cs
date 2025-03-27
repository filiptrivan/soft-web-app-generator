using Spider.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Soft.Generator.Shared.Classes;
using Soft.Generator.Shared.Shared;
using System.Reflection;

namespace Spider.DesktopApp.Client.Controllers
{
    public class WebApplicationController
    {
        public WebApplication SaveWebApplication(WebApplication webApplication)
        {
            return Helpers.Request<WebApplication>(new RequestBody
            {
                Args = [JsonSerializer.Serialize(webApplication)],
            });
        }

        public void DeleteWebApplication(long webApplicationId)
        {
            Helpers.Request(new RequestBody
            {
                Args = [$"{webApplicationId}"],
            });
        }

        public List<WebApplication> GetWebApplicationList()
        {
            return Helpers.Request<List<WebApplication>>(new RequestBody());
        }

        public WebApplication GetWebApplication(long webApplicationId)
        {
            return Helpers.Request<WebApplication>(new RequestBody
            {
                Args = [$"{webApplicationId}"],
            });
        }

        public List<Company> GetCompanyList()
        {
            return Helpers.Request<List<Company>>(new RequestBody());
        }

        public List<Setting> GetSettingList()
        {
            return Helpers.Request<List<Setting>>(new RequestBody());
        }

        public List<DllPath> GetDllPathList()
        {
            return Helpers.Request<List<DllPath>>(new RequestBody());
        }

        public List<DllPath> GetDllPathListForTheWebApplication(long webApplicationId)
        {
            return Helpers.Request<List<DllPath>>(new RequestBody
            {
                Args = [$"{webApplicationId}"],
            });
        }

        public void GenerateNetAndAngularStructure(long webApplicationId)
        {
            Helpers.Request(new RequestBody
            {
                Args = [$"{webApplicationId}"],
            });
        }

        public void GenerateBusinessFiles(long webApplicationId)
        {
            Helpers.Request(new RequestBody
            {
                Args = [$"{webApplicationId}"],
            });
        }
    }
}
