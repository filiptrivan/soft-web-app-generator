using Soft.Generator.Shared.Classes;
using Soft.Generator.Shared.Shared;
using Spider.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Client.Controllers
{
    public class DllPathController
    {
        public DllPath SaveDllPath(DllPath dllPath)
        {
            return Helpers.Request<DllPath>(new RequestBody
            {
                Args = [JsonSerializer.Serialize(dllPath)],
            });
        }

        public List<DllPath> GetDllPathList()
        {
            return Helpers.Request<List<DllPath>>(new RequestBody());
        }

        public DllPath GetDllPath(long id)
        {
            return Helpers.Request<DllPath>(new RequestBody
            {
                Args = [$"{id}"],
            });
        }

        public void DeleteDllPath(long id)
        {
            Helpers.Request<DllPath>(new RequestBody
            {
                Args = [$"{id}"],
            });
        }

        /// <summary>
        /// TODO FT: This method returns all web applications, it should return only web applications for currently logged in user
        /// </summary>
        public List<WebApplication> GetWebApplicationList()
        {
            return Helpers.Request<List<WebApplication>>(new RequestBody());
        }
    }
}
