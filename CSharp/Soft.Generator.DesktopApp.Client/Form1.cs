﻿using Microsoft.Data.SqlClient;
using Soft.Generator.DesktopApp.Client.Controllers;
using Soft.Generator.DesktopApp.Client.Extensions;
using Soft.Generator.DesktopApp.Client.Pages;
using Soft.Generator.DesktopApp.Client.Services;
using System.Data;

namespace Soft.Generator.DesktopApp.Client
{
    public partial class Form1 : Form
    {
        #region Pages

        private readonly WebApplicationController _applicationController;
        private readonly CompanyController _companyController;
        private readonly FrameworkController _frameworkController;
        private readonly HomeController _homeController;
        private readonly DllPathController _pathToDomainFolderController;
        private readonly PermissionController _permissionController;
        private readonly SettingController _settingController;

        #endregion

        private readonly PageNavigator _pageNavigator;
        private readonly ClientSharedService _clientSharedService;

        public Form1(
            PageNavigator pageNavigator, ClientSharedService clientSharedService,
            WebApplicationController applicationController, CompanyController companyController, FrameworkController frameworkController, HomeController homeController,
            DllPathController pathToDomainFolderController, PermissionController permissionController, SettingController settingController
            )
        {
            _applicationController = applicationController;
            _companyController = companyController;
            _frameworkController = frameworkController;
            _homeController = homeController;
            _pathToDomainFolderController = pathToDomainFolderController;
            _permissionController = permissionController;
            _settingController = settingController;


            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;

            InitializeComponent();

            label2.Text = Program.CurrentCompany.Email;

            _pageNavigator.InitializeMainPanel(pnl_Main);

            homeToolStripMenuItem_Click(null, null);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateToPage<HomePage>();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateToPage<WebApplicationListPage>();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateToPage<CompanyListPage>();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateToPage<SettingListPage>();
        }

        private void frameworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateToPage<FrameworkListPage>();
        }

        private void permissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateToPage<PermissionListPage>();
        }

        private void pathToDomainFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateToPage<DllPathListPage>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
