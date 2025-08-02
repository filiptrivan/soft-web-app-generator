using Soft.Generator.DesktopApp.Client.Controllers;
using Soft.Generator.Shared.Entities;
using Soft.Generator.DesktopApp.Client.Services;
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<WebApplication> webApplications = _webApplicationController.GetWebApplicationList().Where(x => x.Name.StartsWith(textBox1.Text)).ToList();

            if (webApplications.Count == 0)
            {
                MessageBox.Show("Систем не може да нађе апликације по задатим критеријумима.");
            }
            else
            {
                softDataGridView1.SoftInitializeComponent<WebApplication>(webApplications, true, ApplicationAddEventHandler, true, true, CellContentClickHandler);
            }
        }
    }
}
