﻿using Spider.DesktopApp.Client.Controllers;
using Spider.Shared.Entities;
using Spider.DesktopApp.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spider.DesktopApp.Client.Pages
{
    public partial class WebApplicationListPage : UserControl
    {
        WebApplicationController _webApplicationController;
        PageNavigator _pageNavigator;
        ClientSharedService _clientSharedService;

        public WebApplicationListPage(WebApplicationController webApplicationController, PageNavigator pageNavigator, ClientSharedService clientSharedService)
        {
            _webApplicationController = webApplicationController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;

            InitializeComponent();

            LoadTable();
        }

        private void LoadTable()
        {
            softDataGridView1.SoftInitializeComponent<WebApplication>(_webApplicationController.GetWebApplicationList(), true, ApplicationAddEventHandler, true, true, CellContentClickHandler);
        }

        public void ApplicationAddEventHandler(object sender, EventArgs e)
        {
            WebApplicationDetailsPage webApplicationDetailsPage = _pageNavigator.NavigateToPage<WebApplicationDetailsPage>(this);
            webApplicationDetailsPage.Initialize(new WebApplication());
        }

        public void CellContentClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            _clientSharedService.CellContentClickHandler<WebApplicationDetailsPage, WebApplication, long>(
                e,
                this,
                softDataGridView1,
                _pageNavigator.NavigateToPage<WebApplicationDetailsPage>,
                _webApplicationController.GetWebApplication,
                _webApplicationController.DeleteWebApplication,
                LoadTable
            );
        }

    }
}
