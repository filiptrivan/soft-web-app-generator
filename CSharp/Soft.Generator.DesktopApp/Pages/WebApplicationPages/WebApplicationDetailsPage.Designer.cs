namespace Soft.Generator.DesktopApp.Pages
{
    partial class WebApplicationDetailsPage
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
            tb_Name = new SoftTextbox();
            cb_Setting = new Controls.SoftCombobox();
            cb_Company = new Controls.SoftCombobox();
            btn_Save = new Button();
            btn_Return = new Button();
            btn_GenerateBusinessFiles = new Button();
            clb_GeneratedFile = new Controls.SoftCheckListBox();
            btn_GenerateNetAndAngularStructure = new Button();
            SuspendLayout();
            // 
            // tb_Name
            // 
            tb_Name.InvalidMessage = null;
            tb_Name.LabelValue = "Naziv";
            tb_Name.Location = new Point(3, 3);
            tb_Name.Name = "tb_Name";
            tb_Name.Size = new Size(238, 63);
            tb_Name.TabIndex = 0;
            tb_Name.TextBoxValue = "";
            // 
            // cb_Setting
            // 
            cb_Setting.DisplayMember = "Id";
            cb_Setting.InvalidMessage = null;
            cb_Setting.LabelValue = "Podešavanje";
            cb_Setting.Location = new Point(247, 3);
            cb_Setting.Name = "cb_Setting";
            cb_Setting.SelectedValue = null;
            cb_Setting.Size = new Size(238, 63);
            cb_Setting.TabIndex = 1;
            // 
            // cb_Company
            // 
            cb_Company.DisplayMember = "Id";
            cb_Company.InvalidMessage = null;
            cb_Company.LabelValue = "Kompanija";
            cb_Company.Location = new Point(3, 72);
            cb_Company.Name = "cb_Company";
            cb_Company.SelectedValue = null;
            cb_Company.Size = new Size(238, 63);
            cb_Company.TabIndex = 2;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(16, 151);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 23);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "Sačuvaj";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Return
            // 
            btn_Return.Location = new Point(113, 151);
            btn_Return.Name = "btn_Return";
            btn_Return.Size = new Size(75, 23);
            btn_Return.TabIndex = 4;
            btn_Return.Text = "Vrati se";
            btn_Return.UseVisualStyleBackColor = true;
            btn_Return.Click += btn_Return_Click;
            // 
            // btn_GenerateBusinessFiles
            // 
            btn_GenerateBusinessFiles.Location = new Point(257, 353);
            btn_GenerateBusinessFiles.Name = "btn_GenerateBusinessFiles";
            btn_GenerateBusinessFiles.Size = new Size(183, 23);
            btn_GenerateBusinessFiles.TabIndex = 6;
            btn_GenerateBusinessFiles.Text = "Generiši specifične datoteke";
            btn_GenerateBusinessFiles.UseVisualStyleBackColor = true;
            btn_GenerateBusinessFiles.Click += btn_GenerateBusinessFiles_Click;
            // 
            // clb_GeneratedFile
            // 
            clb_GeneratedFile.DisplayMember = "Id";
            clb_GeneratedFile.LabelValue = "Generisane datoteke";
            clb_GeneratedFile.Location = new Point(3, 196);
            clb_GeneratedFile.Name = "clb_GeneratedFile";
            clb_GeneratedFile.Size = new Size(481, 137);
            clb_GeneratedFile.TabIndex = 7;
            // 
            // btn_GenerateNetAndAngularStructure
            // 
            btn_GenerateNetAndAngularStructure.Location = new Point(16, 353);
            btn_GenerateNetAndAngularStructure.Name = "btn_GenerateNetAndAngularStructure";
            btn_GenerateNetAndAngularStructure.Size = new Size(225, 23);
            btn_GenerateNetAndAngularStructure.TabIndex = 8;
            btn_GenerateNetAndAngularStructure.Text = "Generiši backend i frontend strukturu";
            btn_GenerateNetAndAngularStructure.UseVisualStyleBackColor = true;
            btn_GenerateNetAndAngularStructure.Click += btn_GenerateNetAndAngularStructure_Click;
            // 
            // WebApplicationDetailsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_GenerateNetAndAngularStructure);
            Controls.Add(clb_GeneratedFile);
            Controls.Add(btn_GenerateBusinessFiles);
            Controls.Add(btn_Return);
            Controls.Add(btn_Save);
            Controls.Add(cb_Company);
            Controls.Add(cb_Setting);
            Controls.Add(tb_Name);
            Name = "WebApplicationDetailsPage";
            Size = new Size(609, 561);
            ResumeLayout(false);
        }

        #endregion

        private SoftTextbox tb_Name;
        private Controls.SoftCombobox cb_Setting;
        private Controls.SoftCombobox cb_Company;
        private Button btn_Save;
        private Button btn_Return;
        private Button btn_GenerateBusinessFiles;
        private Controls.SoftCheckListBox clb_GeneratedFile;
        private Button btn_GenerateNetAndAngularStructure;
    }
}
