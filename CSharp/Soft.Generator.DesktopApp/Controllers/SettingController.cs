﻿using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Controllers
{
    public class SettingController
    {
        DesktopAppBusinessService _desktopAppBusinessService;

        public SettingController(DesktopAppBusinessService desktopAppBusinessService)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public Setting SaveSetting(Setting company)
        {
            return _desktopAppBusinessService.SaveSetting(company);
        }

        public List<Setting> GetSettingList()
        {
            return _desktopAppBusinessService.GetSettingList();
        }

        public Setting GetSetting(long id)
        {
            return _desktopAppBusinessService.GetSetting(id);
        }

        public void DeleteSetting(long id)
        {
            _desktopAppBusinessService.DeleteSetting(id);
        }

        public List<Framework> GetFrameworkList()
        {
            return _desktopAppBusinessService.GetFrameworkList();
        }
    }
}
