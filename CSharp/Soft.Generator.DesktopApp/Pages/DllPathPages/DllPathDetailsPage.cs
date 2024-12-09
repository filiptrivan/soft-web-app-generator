using Soft.Generator.DesktopApp.Controllers;
using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Interfaces;
using Soft.Generator.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soft.Generator.DesktopApp.Pages.DllPathPages
{
    public partial class DllPathDetailsPage : UserControl, ISoftDetailsPage
    {
        PageNavigator _pageNavigator;
        DllPathController _dllPathController;
        ClientSharedService _clientSharedService;
        ValidationService _validationService;

        private DllPath Entity { get; set; } = new DllPath();

        public DllPathDetailsPage(DllPathController dllPathController, PageNavigator pageNavigator, ClientSharedService clientSharedService, ValidationService validationService)
        {
            _dllPathController = dllPathController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;
            _validationService = validationService;

            InitializeComponent();
        }

        public void Initialize(ISoftEntity entity)
        {
            Entity = (DllPath)entity;

            tb_Path.TextBoxValue = Entity.Path;
            tb_Path.InvalidMessage = _validationService.DllPathPathValidationMessage;

            cb_WebApplication.DisplayMember = nameof(WebApplication.Name);
            cb_WebApplication.InvalidMessage = _validationService.DllPathWebApplicationIdValidationMessage;
            cb_WebApplication.Initialize<WebApplication>(_dllPathController.GetWebApplicationList());
            cb_WebApplication.SelectedValue = Entity.WebApplication?.Id ?? 0;
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateBack();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DllPath dllPath = new DllPath
            {
                Id = Entity.Id,
                Path = tb_Path.TextBoxValue,
                WebApplication = cb_WebApplication.SelectedValue == null ? null : new WebApplication { Id = (long)cb_WebApplication.SelectedValue },
            };

            if (_validationService.IsDllPathValid(dllPath) == false)
            {
                ValidateAllChildControls();
                return;
            }

            Entity = _dllPathController.SaveDllPath(dllPath);

            _clientSharedService.ShowSuccessfullMessage();
        }

        public void ValidateAllChildControls()
        {
            tb_Path.StartValidation();
            cb_WebApplication.StartValidation();
        }
    }
}
