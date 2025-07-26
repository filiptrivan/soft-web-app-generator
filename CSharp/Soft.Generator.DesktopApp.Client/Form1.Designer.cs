namespace Soft.Generator.DesktopApp.Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            applicationToolStripMenuItem = new ToolStripMenuItem();
            companyToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            codebookToolStripMenuItem = new ToolStripMenuItem();
            frameworkToolStripMenuItem = new ToolStripMenuItem();
            permissionToolStripMenuItem = new ToolStripMenuItem();
            pathToDomainFolderToolStripMenuItem = new ToolStripMenuItem();
            pnl_Main = new Panel();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(224, 224, 224);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, applicationToolStripMenuItem, companyToolStripMenuItem, settingToolStripMenuItem, codebookToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(930, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(62, 20);
            homeToolStripMenuItem.Text = "Početna";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // applicationToolStripMenuItem
            // 
            applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            applicationToolStripMenuItem.Size = new Size(70, 20);
            applicationToolStripMenuItem.Text = "Aplikacija";
            applicationToolStripMenuItem.Click += applicationToolStripMenuItem_Click;
            // 
            // companyToolStripMenuItem
            // 
            companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            companyToolStripMenuItem.Size = new Size(76, 20);
            companyToolStripMenuItem.Text = "Kompanija";
            companyToolStripMenuItem.Click += companyToolStripMenuItem_Click;
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(85, 20);
            settingToolStripMenuItem.Text = "Podešavanje";
            settingToolStripMenuItem.Click += settingToolStripMenuItem_Click;
            // 
            // codebookToolStripMenuItem
            // 
            codebookToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { frameworkToolStripMenuItem, permissionToolStripMenuItem, pathToDomainFolderToolStripMenuItem });
            codebookToolStripMenuItem.Name = "codebookToolStripMenuItem";
            codebookToolStripMenuItem.Size = new Size(61, 20);
            codebookToolStripMenuItem.Text = "Šifarnici";
            // 
            // frameworkToolStripMenuItem
            // 
            frameworkToolStripMenuItem.Name = "frameworkToolStripMenuItem";
            frameworkToolStripMenuItem.Size = new Size(237, 22);
            frameworkToolStripMenuItem.Text = "Okvir";
            frameworkToolStripMenuItem.Click += frameworkToolStripMenuItem_Click;
            // 
            // permissionToolStripMenuItem
            // 
            permissionToolStripMenuItem.Name = "permissionToolStripMenuItem";
            permissionToolStripMenuItem.Size = new Size(237, 22);
            permissionToolStripMenuItem.Text = "Permisija";
            permissionToolStripMenuItem.Click += permissionToolStripMenuItem_Click;
            // 
            // pathToDomainFolderToolStripMenuItem
            // 
            pathToDomainFolderToolStripMenuItem.Name = "pathToDomainFolderToolStripMenuItem";
            pathToDomainFolderToolStripMenuItem.Size = new Size(237, 22);
            pathToDomainFolderToolStripMenuItem.Text = "Putanja do domenskog foldera";
            pathToDomainFolderToolStripMenuItem.Click += pathToDomainFolderToolStripMenuItem_Click;
            // 
            // pnl_Main
            // 
            pnl_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_Main.BackColor = Color.Transparent;
            pnl_Main.Location = new Point(0, 27);
            pnl_Main.Name = "pnl_Main";
            pnl_Main.Size = new Size(930, 404);
            pnl_Main.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(193, 445);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 2;
            label2.Text = "/";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 445);
            label1.Name = "label1";
            label1.Size = new Size(175, 15);
            label1.TabIndex = 1;
            label1.Text = "Trenutno ulogovana kompanija:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(12, 467);
            button1.Name = "button1";
            button1.Size = new Size(202, 23);
            button1.TabIndex = 0;
            button1.Text = "Odjavi se";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 502);
            Controls.Add(label2);
            Controls.Add(pnl_Main);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem applicationToolStripMenuItem;
        private ToolStripMenuItem companyToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem codebookToolStripMenuItem;
        private ToolStripMenuItem frameworkToolStripMenuItem;
        private ToolStripMenuItem permissionToolStripMenuItem;
        private ToolStripMenuItem pathToDomainFolderToolStripMenuItem;
        private ToolStripMenuItem homeToolStripMenuItem;
        private Panel pnl_Main;
        private Button button1;
        private Label label2;
        private Label label1;
    }
}
