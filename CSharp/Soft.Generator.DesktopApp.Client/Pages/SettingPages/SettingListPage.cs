using Spider.DesktopApp.Client.Controllers;
using Spider.Shared.Entities;
using Spider.DesktopApp.Client.Pages.SettingPages;
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
    public partial class SettingListPage : UserControl
    {
        SettingController _settingController;
        PageNavigator _pageNavigator;
        ClientSharedService _clientSharedService;

        public SettingListPage(SettingController settingController, PageNavigator pageNavigator, ClientSharedService clientSharedService)
        {
            _settingController = settingController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;

            InitializeComponent();

            LoadTable();
        }

        private void LoadTable()
        {
            softDataGridView1.SoftInitializeComponent<Setting>(_settingController.GetSettingList(), true, SettingAddEventHandler, true, true, CellContentClickHandler);
        }

        public void SettingAddEventHandler(object sender, EventArgs e)
        {
            SettingDetailsPage settingDetailsPage = _pageNavigator.NavigateToPage<SettingDetailsPage>(this);
            settingDetailsPage.Initialize(new Setting());
        }

        public void CellContentClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            _clientSharedService.CellContentClickHandler<SettingDetailsPage, Setting, long>(
                e,
                this,
                softDataGridView1,
                _pageNavigator.NavigateToPage<SettingDetailsPage>,
                _settingController.GetSetting,
                _settingController.DeleteSetting,
                LoadTable
            );
        }
    }
}
