using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Controllers
{
    public class PermissionController
    {
        DesktopAppBusinessService _desktopAppBusinessService;

        public PermissionController(DesktopAppBusinessService desktopAppBusinessService) 
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public List<Permission> GetPermissionList()
        {
            return _desktopAppBusinessService.GetPermissionList();
        }
    }
}
