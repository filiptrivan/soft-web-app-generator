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
    public class DllPathController
    {
        DesktopAppBusinessService _desktopAppBusinessService;
        ISqlConnection _connection;

        public DllPathController(DesktopAppBusinessService desktopAppBusinessService, ISqlConnection connection)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
            _connection = connection;
        }

        public DllPath SaveDllPath(DllPath dllPath)
        {
            return new SaveDllPathSO(_connection, dllPath).Execute();
        }

        public List<DllPath> GetDllPathList()
        {
            return new GetDllPathListSO(_connection).Execute();
        }

        public DllPath GetDllPath(long id)
        {
            return new GetDllPathSO(_connection, id).Execute();
        }

        public void DeleteDllPath(long id)
        {
            new DeleteDllPathSO(_connection, id).Execute();
        }

        /// <summary>
        /// TODO FT: This method returns all web applications, it should return only web applications for currently logged in user
        /// </summary>
        public List<WebApplication> GetWebApplicationList()
        {
            return new GetWebApplicationListSO(_connection).Execute();
        }
    }
}
