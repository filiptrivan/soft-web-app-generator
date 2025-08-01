using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Services;
using Soft.Generator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Controllers
{
    public class PermissionController
    {
        DesktopAppBusinessService _desktopAppBusinessService;
        ISqlConnection _connection;

        public PermissionController(DesktopAppBusinessService desktopAppBusinessService, ISqlConnection connection) 
        {
            _desktopAppBusinessService = desktopAppBusinessService;
            _connection = connection;
        }

        public List<Permission> GetPermissionList()
        {
            return new GetPermissionListSO(_connection).Execute();
        }
    }
}
