using Soft.Generator.DesktopApp.Client.Controllers;
using Soft.Generator.DesktopApp.Client.Controls;
using Soft.Generator.Shared.Entities;
using Soft.Generator.DesktopApp.Client.Pages;
using Soft.Generator.DesktopApp.Client.Pages.CompanyPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soft.Generator.DesktopApp.Client.Services;

namespace Soft.Generator.DesktopApp.Client.Pages
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<Company> companies = _companyController.GetCompanyList().Where(x => x.Name.StartsWith(textBox1.Text)).ToList();

            if (companies.Count == 0)
            {
                MessageBox.Show("Систем не може да нађе компаније по задатим критеријумима.");
            }
            else
            {
                softDataGridView1.SoftInitializeComponent<Company>(companies, true, CompanyAddEventHandler, true, true, CellContentClickHandler);
            }
        }
    }
}
