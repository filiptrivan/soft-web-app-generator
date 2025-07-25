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

namespace Soft.Generator.DesktopApp.Client.Pages.FrameworkPages
{
    public partial class FrameworkDetailsPage : UserControl, ISoftDetailsPage
    {
        PageNavigator _pageNavigator;
        FrameworkController _frameworkController;
        ClientSharedService _clientSharedService;
        ValidationService _validationService;

        private Framework Entity { get; set; } = new Framework();

        public FrameworkDetailsPage(FrameworkController frameworkController, PageNavigator pageNavigator, ClientSharedService clientSharedService, ValidationService validationService)
        {
            _frameworkController = frameworkController;
            _pageNavigator = pageNavigator;
            _clientSharedService = clientSharedService;
            _validationService = validationService;

            InitializeComponent();
        }

        public void Initialize(ISoftEntity entity)
        {
            Entity = (Framework)entity;

            tb_Name.TextBoxValue = Entity.Name;
            tb_Name.InvalidMessage = _validationService.FrameworkNameValidationMessage;

            tb_Code.TextBoxValue = Entity.Code;
            tb_Code.InvalidMessage = _validationService.FrameworkCodeValidationMessage;
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            _pageNavigator.NavigateBack();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Framework framework = new Framework
            {
                Id = Entity.Id,
                Name = tb_Name.TextBoxValue,
                Code = tb_Code.TextBoxValue,
            };

            if (_validationService.IsFrameworkValid(framework) == false)
            {
                ValidateAllChildControls();
                return;
            }

            Entity = _frameworkController.SaveFramework(framework);

            _clientSharedService.ShowSuccessfullMessage();
        }

        public void ValidateAllChildControls()
        {
            tb_Name.StartValidation();
            tb_Code.StartValidation();
        }
    }
}
