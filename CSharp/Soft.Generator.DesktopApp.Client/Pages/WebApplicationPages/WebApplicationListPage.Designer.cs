namespace Soft.Generator.DesktopApp.Client.Pages
{
    partial class WebApplicationListPage
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
            softDataGridView1 = new Controls.SoftDataGridView();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // softDataGridView1
            // 
            softDataGridView1.Location = new Point(0, 0);
            softDataGridView1.Name = "softDataGridView1";
            softDataGridView1.Size = new Size(666, 313);
            softDataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 319);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Naziv aplikacije";
            textBox1.Size = new Size(193, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(12, 348);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Pretraži";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // WebApplicationListPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(softDataGridView1);
            Name = "WebApplicationListPage";
            Size = new Size(666, 389);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.SoftDataGridView softDataGridView1;
        private TextBox textBox1;
        private Button button1;
    }
}
