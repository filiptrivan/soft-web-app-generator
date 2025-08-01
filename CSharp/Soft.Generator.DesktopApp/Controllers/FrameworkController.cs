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
    public class FrameworkController
    {
        DesktopAppBusinessService _desktopAppBusinessService;
        ISqlConnection _connection;

        public FrameworkController(DesktopAppBusinessService desktopAppBusinessService, ISqlConnection connection)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
            _connection = connection;
        }

        public Framework SaveFramework(Framework framework)
        {
            return new SaveFrameworkSO(_connection, framework).Execute();
        }

        public List<Framework> GetFrameworkList()
        {
            return new GetFrameworkListSO(_connection).Execute();
        }

        public Framework GetFramework(long id)
        {
            return new GetFrameworkSO(_connection, id).Execute();
        }

        public void DeleteFramework(long id)
        {
            new DeleteFrameworkSO(_connection, id).Execute();
        }
    }
}
