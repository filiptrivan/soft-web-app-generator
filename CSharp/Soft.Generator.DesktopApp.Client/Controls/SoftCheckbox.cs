using System.ComponentModel;

namespace Spider.DesktopApp.Client.Controls
{
    public partial class SoftCheckbox : UserControl
    {
        public string LabelValue
        {
            get { return checkBox1.Text; }
            set { checkBox1.Text = value; }
        }

        public bool Value
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        public Func<bool?, string> InvalidMessage { get; set; }

        public SoftCheckbox()
        {
            InitializeComponent();

            checkBox1.Validating += checkBox1_Validating;
        }

        private void checkBox1_Validating(object sender, CancelEventArgs e)
        {
            if (InvalidMessage != null)
            {
                if (InvalidMessage(checkBox1.Checked) == "")
                {
                    errorProvider1.SetError(checkBox1, null);
                }
                else
                {
                    errorProvider1.SetError(checkBox1, InvalidMessage(checkBox1.Checked));
                }
            }
        }

        public void StartValidation()
        {
            var cancelEventArgs = new CancelEventArgs();
            checkBox1_Validating(checkBox1, cancelEventArgs);
        }
    }
}
