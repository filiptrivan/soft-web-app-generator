using Spider.DesktopApp.Client.Controllers;
using Spider.DesktopApp.Client.Controls;
using Spider.Shared.Entities;
using Spider.DesktopApp.Client.Pages;
using Spider.DesktopApp.Client.Pages.CompanyPages;
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
    public partial class CompanyListPage : UserControl
    {
        CompanyController _companyController;
        PageNavigator _pageNavigator;
        ClientSharedService _clientSharedService;

        public CompanyListPage(CompanyController companyController, PageNavigator pageNavigator, ClientSharedService clientSharedService)
        {
            _companyController = companyController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;

            InitializeComponent();

            LoadTable();
        }

        private void LoadTable()
        {
            softDataGridView1.SoftInitializeComponent<Company>(_companyController.GetCompanyList(), true, CompanyAddEventHandler, true, true, CellContentClickHandler);
        }

        public void CompanyAddEventHandler(object sender, EventArgs e)
        {
            CompanyDetailsPage companyDetailsPage = _pageNavigator.NavigateToPage<CompanyDetailsPage>(this);
            companyDetailsPage.Initialize(new Company());
        }

        public void CellContentClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            _clientSharedService.CellContentClickHandler<CompanyDetailsPage, Company, long>(
                e,
                this,
                softDataGridView1,
                _pageNavigator.NavigateToPage<CompanyDetailsPage>,
                _companyController.GetCompany,
                _companyController.DeleteCompany,
                LoadTable
            );
        }
    }
}
