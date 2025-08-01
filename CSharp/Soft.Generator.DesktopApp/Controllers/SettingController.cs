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
    public class SettingController
    {
        DesktopAppBusinessService _desktopAppBusinessService;
        ISqlConnection _connection;

        public SettingController(
            DesktopAppBusinessService desktopAppBusinessService,
            ISqlConnection connection
        )
        {
            _desktopAppBusinessService = desktopAppBusinessService;
            _connection = connection;
        }

        public Setting SaveSetting(Setting company)
        {
            return new SaveSettingSO(_connection, company).Execute();
        }

        public List<Setting> GetSettingList()
        {
            return new GetSettingListSO(_connection).Execute();
        }

        public Setting GetSetting(long id)
        {
            return new GetSettingSO(_connection, id).Execute();
        }

        public void DeleteSetting(long id)
        {
            new DeleteSettingSO(_connection, id).Execute();
        }

        public List<Framework> GetFrameworkList()
        {
            return new GetFrameworkListSO(_connection).Execute();
        }
    }
}
