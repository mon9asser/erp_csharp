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
            this.Load_All_Records();
        }

        public void Load_All_Records() {

            datagrid_entry_accounts.DataSource = entry.Get_All_Entries();

            datagrid_entry_accounts.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);

            datagrid_entry_accounts.Columns["id"].Visible = true;
            datagrid_entry_accounts.Columns["description"].Visible = true;
            datagrid_entry_accounts.Columns["updated_date"].Visible = true;
            datagrid_entry_accounts.Columns["entry_number"].Visible = true;

            datagrid_entry_accounts.Columns["id"].DisplayIndex = 0;
            datagrid_entry_accounts.Columns["description"].DisplayIndex = 1;
            datagrid_entry_accounts.Columns["entry_number"].DisplayIndex = 2;
            datagrid_entry_accounts.Columns["updated_date"].DisplayIndex = 3;

            datagrid_entry_accounts.Columns["id"].HeaderText = "مسلسل";
            datagrid_entry_accounts.Columns["description"].HeaderText = "الوصف";
            datagrid_entry_accounts.Columns["entry_number"].HeaderText = "رقم القيد";
            datagrid_entry_accounts.Columns["updated_date"].HeaderText = "التاريخ";

            datagrid_entry_accounts.Columns["description"].Width = 420;
            datagrid_entry_accounts.Columns["updated_date"].Width = 185;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI.Add_New_Entry entry = new UI.Add_New_Entry(-1, this);
            entry.ShowDialog();
        }

        private void datagrid_entry_accounts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1 || e.ColumnIndex == -1) {
                return;
            }

            if (datagrid_entry_accounts.Rows[e.RowIndex].Cells["id"].Value == System.DBNull.Value) {
                return; 
            }

            if (datagrid_entry_accounts.Rows[e.RowIndex].Cells["id"].Value.ToString() == "") {
                return;
            }

            UI.Add_New_Entry entry = new UI.Add_New_Entry(Convert.ToInt32(datagrid_entry_accounts.Rows[e.RowIndex].Cells["id"].Value) , this);
            entry.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //EntriesReportViewer rptviewer = new EntriesReportViewer();
            //rptviewer.ShowDialog();
        }
    }
}
