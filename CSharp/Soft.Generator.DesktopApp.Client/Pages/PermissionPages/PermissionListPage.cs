﻿using Microsoft.Data.SqlClient;
using Soft.Generator.DesktopApp.Client.Controllers;
using Soft.Generator.Shared.Entities;
using Soft.Generator.DesktopApp.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soft.Generator.DesktopApp.Client.Pages
{
    public partial class PermissionListPage : UserControl
    {
        private readonly PermissionController _permissionController;

        public PermissionListPage(PermissionController permissionController)
        {
            _permissionController = permissionController;

            InitializeComponent();

            softDataGridView1.SoftInitializeComponent<Permission>(_permissionController.GetPermissionList(), false, null, false, false);
        }
    }
}
