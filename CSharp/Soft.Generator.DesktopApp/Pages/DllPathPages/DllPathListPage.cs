using Spider.DesktopApp.Controllers;
using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Pages.DllPathPages;
using Spider.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spider.DesktopApp.Pages
{
    public partial class DllPathListPage : UserControl
    {
        DllPathController _dllPathController;
        PageNavigator _pageNavigator;
        ClientSharedService _clientSharedService;

        public DllPathListPage(DllPathController dllPathController, PageNavigator pageNavigator, ClientSharedService clientSharedService)
        {
            _dllPathController = dllPathController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;

            InitializeComponent();

            LoadTable();
        }

        private void LoadTable()
        {
            softDataGridView1.SoftInitializeComponent<DllPath>(_dllPathController.GetDllPathList(), true, DllPathAddEventHandler, true, true, CellContentClickHandler);
        }

        public void DllPathAddEventHandler(object sender, EventArgs e)
        {
            DllPathDetailsPage dllPathDetailsPage = _pageNavigator.NavigateToPage<DllPathDetailsPage>(this);
            dllPathDetailsPage.Initialize(new DllPath());
        }

        public void CellContentClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            _clientSharedService.CellContentClickHandler<DllPathDetailsPage, DllPath, long>(
                e,
                this,
                softDataGridView1,
                _pageNavigator.NavigateToPage<DllPathDetailsPage>,
                _dllPathController.GetDllPath,
                _dllPathController.DeleteDllPath,
                LoadTable
            );
        }
    }
}
