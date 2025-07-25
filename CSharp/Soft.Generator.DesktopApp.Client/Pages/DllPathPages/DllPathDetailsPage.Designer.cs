﻿namespace Soft.Generator.DesktopApp.Client.Pages.DllPathPages
{
    partial class DllPathDetailsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_Path = new SoftTextbox();
            btn_Save = new Button();
            btn_Return = new Button();
            cb_WebApplication = new Controls.SoftCombobox();
            SuspendLayout();
            // 
            // tb_Path
            // 
            tb_Path.InvalidMessage = null;
            tb_Path.LabelValue = "Dll putanja";
            tb_Path.Location = new Point(3, 3);
            tb_Path.Name = "tb_Path";
            tb_Path.Size = new Size(238, 63);
            tb_Path.TabIndex = 0;
            tb_Path.TextBoxValue = "";
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(16, 81);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 23);
            btn_Save.TabIndex = 1;
            btn_Save.Text = "Sačuvaj";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Return
            // 
            btn_Return.Location = new Point(109, 81);
            btn_Return.Name = "btn_Return";
            btn_Return.Size = new Size(75, 23);
            btn_Return.TabIndex = 2;
            btn_Return.Text = "Vrati se";
            btn_Return.UseVisualStyleBackColor = true;
            btn_Return.Click += btn_Return_Click;
            // 
            // cb_WebApplication
            // 
            cb_WebApplication.DisplayMember = "Id";
            cb_WebApplication.InvalidMessage = null;
            cb_WebApplication.LabelValue = "Web aplikacija";
            cb_WebApplication.Location = new Point(247, 3);
            cb_WebApplication.Name = "cb_WebApplication";
            cb_WebApplication.SelectedValue = null;
            cb_WebApplication.Size = new Size(238, 63);
            cb_WebApplication.TabIndex = 3;
            // 
            // DllPathDetailsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cb_WebApplication);
            Controls.Add(btn_Return);
            Controls.Add(btn_Save);
            Controls.Add(tb_Path);
            Name = "DllPathDetailsPage";
            Size = new Size(520, 251);
            ResumeLayout(false);
        }

        #endregion

        private SoftTextbox tb_Path;
        private Button btn_Save;
        private Button btn_Return;
        private Controls.SoftCombobox cb_WebApplication;
    }
}
