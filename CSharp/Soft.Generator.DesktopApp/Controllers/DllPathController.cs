﻿using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Services;
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

        public DllPathController(DesktopAppBusinessService desktopAppBusinessService)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public DllPath SaveDllPath(DllPath dllPath)
        {
            return _desktopAppBusinessService.SaveDllPath(dllPath);
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
