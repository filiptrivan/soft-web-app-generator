using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Controllers
{
    public class FrameworkController
    {
        DesktopAppBusinessService _desktopAppBusinessService;

        public FrameworkController(DesktopAppBusinessService desktopAppBusinessService)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public Framework SaveFramework(Framework framework)
        {
            return _desktopAppBusinessService.SaveFramework(framework);
        }

        public List<Framework> GetFrameworkList()
        {
            return _desktopAppBusinessService.GetFrameworkList();
        }

        public Framework GetFramework(long id)
        {
            return _desktopAppBusinessService.GetFramework(id);
        }

        public void DeleteFramework(long id)
        {
            _desktopAppBusinessService.DeleteFramework(id);
        }
    }
}
