﻿using Soft.Generator.DesktopApp.Client.Controllers;
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
using Soft.Generator.DesktopApp.Client.Interfaces;
using Soft.Generator.DesktopApp.Client.Services;

namespace Soft.Generator.DesktopApp.Client.Pages.CompanyPages
{
    public partial class CompanyDetailsPage : UserControl, ISoftDetailsPage
    {
        PageNavigator _pageNavigator;
        CompanyController _companyController;
        ClientSharedService _clientSharedService;
        ValidationService _validationService;

        private Company Entity { get; set; } = new Company();

        public CompanyDetailsPage(CompanyController companyController, PageNavigator pageNavigator, ClientSharedService clientSharedService, ValidationService validationService)
        {
            _companyController = companyController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;
            _validationService = validationService;

            InitializeComponent();
        }

        public void Initialize(ISoftEntity entity)
        {
            Entity = (Company)entity;

            tb_Name.TextBoxValue = Entity.Name;
            tb_Name.InvalidMessage = _validationService.CompanyNameValidationMessage;

            tb_Email.TextBoxValue = Entity.Email;
            tb_Email.InvalidMessage = _validationService.CompanyEmailValidationMessage;

            tb_Password.TextBoxValue = Entity.Password;
            tb_Password.InvalidMessage = _validationService.CompanyPasswordValidationMessage;

            List<Permission> permissions = _companyController.GetPermissionList();
            List<long> selectedPermissionIds = _companyController.GetPermissionListForTheCompany(Entity.Id).Select(x => x.Id).ToList();
            clb_Permission.DisplayMember = nameof(Permission.Name);
            clb_Permission.Initialize(permissions, selectedPermissionIds);
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateBack();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Company company = new Company
            {
                Id = Entity.Id,
                Name = tb_Name.TextBoxValue,
                Email = tb_Email.TextBoxValue,
                Password = tb_Password.TextBoxValue,
                
            };

            if (_validationService.IsCompanyValid(company) == false)
            {
                ValidateAllChildControls();
                return;
            }

            Entity = _companyController.SaveCompany(company, clb_Permission.CheckedValues);

            _clientSharedService.ShowSuccessfullMessage();
        }

        public void ValidateAllChildControls()
        {
            tb_Name.StartValidation();
            tb_Email.StartValidation();
            tb_Password.StartValidation();
        }
    }
}
