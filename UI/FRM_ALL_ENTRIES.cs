using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_management.UI
{
    public partial class FRM_ALL_ENTRIES : Form
    {
        PL.DailyEntries entry = new PL.DailyEntries();
        public FRM_ALL_ENTRIES()
        {
            InitializeComponent();
            datagrid_entry_accounts.DataSource = entry.Get_All_Entries();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI.Add_New_Entry entry = new UI.Add_New_Entry();
            entry.Show();
        }
    }
}
