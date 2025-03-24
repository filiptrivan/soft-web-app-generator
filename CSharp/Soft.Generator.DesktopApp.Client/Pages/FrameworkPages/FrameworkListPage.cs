using Spider.DesktopApp.Client.Controllers;
using Spider.Shared.Entities;
using Spider.DesktopApp.Client.Pages.FrameworkPages;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spider.DesktopApp.Client.Services;

namespace Spider.DesktopApp.Client.Pages
{
    public partial class FrameworkListPage : UserControl
    {
        FrameworkController _frameworkController;
        PageNavigator _pageNavigator;
        ClientSharedService _clientSharedService;

        public FrameworkListPage(FrameworkController frameworkController, PageNavigator pageNavigator, ClientSharedService clientSharedService)
        {
            _frameworkController = frameworkController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;

            InitializeComponent();

            LoadTable();
        }

        private void LoadTable()
        {
            softDataGridView1.SoftInitializeComponent<Framework>(_frameworkController.GetFrameworkList(), true, FrameworkAddEventHandler, true, true, CellContentClickHandler);
        }

        public void FrameworkAddEventHandler(object sender, EventArgs e)
        {
            FrameworkDetailsPage frameworkDetailsPage = _pageNavigator.NavigateToPage<FrameworkDetailsPage>(this);
            frameworkDetailsPage.Initialize(new Framework());
        }

        public void CellContentClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            _clientSharedService.CellContentClickHandler<FrameworkDetailsPage, Framework, long>(
                e,
                this,
                softDataGridView1,
                _pageNavigator.NavigateToPage<FrameworkDetailsPage>,
                _frameworkController.GetFramework,
                _frameworkController.DeleteFramework,
                LoadTable
            );
        }
    }
}
