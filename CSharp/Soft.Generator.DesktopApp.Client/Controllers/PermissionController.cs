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
    public class PermissionController
    {
        public List<Permission> GetPermissionList()
        {
            return Helpers.Request<List<Permission>>(new RequestBody());
        }
    }
}
