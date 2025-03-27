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
    public class SettingController
    {
        public Setting SaveSetting(Setting company)
        {
            return Helpers.Request<Setting>(new RequestBody
            {
                Args = [JsonSerializer.Serialize(company)]
            });
        }

        public List<Setting> GetSettingList()
        {
            return Helpers.Request<List<Setting>>(new RequestBody());
        }

        public Setting GetSetting(long id)
        {
            return Helpers.Request<Setting>(new RequestBody
            {
                Args=[$"{id}"]
            });
        }

        public void DeleteSetting(long id)
        {
            Helpers.Request<List<Setting>>(new RequestBody
            {
                Args = [$"{id}"],
            });
        }

        public List<Framework> GetFrameworkList()
        {
            return Helpers.Request<List<Framework>>(new RequestBody());
        }
    }
}
