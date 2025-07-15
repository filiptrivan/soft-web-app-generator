using Soft.Generator.Shared.Classes;
using Soft.Generator.Shared.Shared;
using Soft.Generator.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Client.Controllers
{
    public class FrameworkController
    {
        public Framework SaveFramework(Framework framework)
        {
            return Helpers.Request<Framework>(new RequestBody
            {
                Args = [JsonSerializer.Serialize(framework)],
            });
        }

        public List<Framework> GetFrameworkList()
        {
            return Helpers.Request<List<Framework>>(new RequestBody());
        }

        public Framework GetFramework(long id)
        {
            return Helpers.Request<Framework>(new RequestBody
            {
                Args = [$"{id}"],
            });
        }

        public void DeleteFramework(long id)
        {
            Helpers.Request(new RequestBody
            {
                Args = [$"{id}"],
            });
        }
    }
}
