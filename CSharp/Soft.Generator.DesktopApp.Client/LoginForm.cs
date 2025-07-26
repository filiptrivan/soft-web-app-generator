using Microsoft.Extensions.DependencyInjection;
using Soft.Generator.DesktopApp.Client.Controllers;
using Soft.Generator.DesktopApp.Client.Pages;
using Soft.Generator.DesktopApp.Client.Services;
using Soft.Generator.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Soft.Generator.DesktopApp.Client
{
    public partial class LoginForm : Form
    {
        PageNavigator _pageNavigator;
        CompanyController _companyController;
        ClientSharedService _clientSharedService;
        ValidationService _validationService;

        private Company Entity { get; set; } = new();

        public LoginForm(CompanyController companyController, PageNavigator pageNavigator, ClientSharedService clientSharedService, ValidationService validationService)
        {
            _companyController = companyController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;
            _validationService = validationService;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Company login = new Company
            {
                Email = textBox1.Text,
                Password = textBox2.Text,
            };

            if (
                string.IsNullOrWhiteSpace(login.Email) ||
                string.IsNullOrWhiteSpace(login.Password)
            )
            {
                MessageBox.Show("Email and Password are required.");
                return;
            }

            Program.CurrentCompany = _companyController.Login(login);

            Hide();
            Form1 mainForm = Program.ServiceProvider.GetRequiredService<Form1>();
            mainForm.ShowDialog();
            Show();
        }
    }
}
