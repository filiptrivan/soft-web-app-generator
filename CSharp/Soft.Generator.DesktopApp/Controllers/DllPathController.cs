using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Controllers
{
    public class DllPathController
    {
        DesktopAppBusinessService _desktopAppBusinessService;

        public DllPathController(DesktopAppBusinessService desktopAppBusinessService)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public DllPath SaveDllPath(DllPath company)
        {
            return _desktopAppBusinessService.SaveDllPath(company);
        }

        public List<DllPath> GetDllPathList()
        {
            return _desktopAppBusinessService.GetDllPathList();
        }

        public DllPath GetDllPath(long id)
        {
            return _desktopAppBusinessService.GetDllPath(id);
        }

        public void DeleteDllPath(long id)
        {
            _desktopAppBusinessService.DeleteDllPath(id);
        }

        /// <summary>
        /// TODO FT: This method returns all web applications, it should return only web applications for currently logged in user
        /// </summary>
        public List<WebApplication> GetWebApplicationList()
        {
            return _desktopAppBusinessService.GetWebApplicationList();
        }
    }
}
