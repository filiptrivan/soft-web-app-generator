using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Interfaces;
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

namespace Spider.DesktopApp.Controls
{
    public partial class SoftCheckListBox : UserControl
    {
        public string LabelValue
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string DisplayMember
        {
            get { return checkedListBox1.DisplayMember; }
            set { checkedListBox1.DisplayMember = value; }
        }

        public List<long> CheckedValues
        {
            get { return checkedListBox1.CheckedItems.Cast<ISoftEntity>().Select(x => x.Id).ToList(); }
        }

        public SoftCheckListBox()
        {
            InitializeComponent();

            checkedListBox1.ValueMember = "Id";
        }

        public void Initialize<T>(
            List<T> dataSource,
            List<long> selectedIds,
            EventHandler selectedValueChangedHandler = null
        )
            where T : ISoftEntity
        {
            checkedListBox1.DataSource = dataSource;

            checkedListBox1.SelectedValueChanged += selectedValueChangedHandler;


            for (int i = 0; i < dataSource.Count; i++)
            {
                if (selectedIds.Contains(dataSource[i].Id))
                    checkedListBox1.SetItemChecked(i, true);
                else
                    checkedListBox1.SetItemChecked(i, false);
            }

            checkedListBox1.SelectedIndex = -1;
        }
    }
}
