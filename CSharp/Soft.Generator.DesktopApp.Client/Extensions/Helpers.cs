using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Client.Extensions
{
    public static class Helpers
    {
        /// <summary>
        /// Check if the column exists in the DataGridView 
        /// </summary>
        public static bool HasColumn(this DataGridView dataGridView, string columnName)
        {
            return dataGridView.Columns
                .Cast<DataGridViewColumn>()
                .Any(column => column.Name == columnName);
        }
    }
}
