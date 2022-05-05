using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 مبيعات - قيد صرف بضاعه----------------0
مشتريات - قيد مشتريات---------------1
مصروفات------------------------------2
مردود مبيعات--------------------------3
مردود مشتريات------------------------4

قيد صرف أموال
قيد قبض أموال

 */
namespace sales_management.UI
{

    public partial class Add_New_Entry : Form
    {
        PL.DailyEntries Entry = new PL.DailyEntries();
        public DataTable __Entries;
        public DataTable __Entries_Accounts;
        public DataTable __Created_Entry;
        Image deletionImage;
        public int entry_id = -1;
        public string entry_number = "-1";

        public Add_New_Entry()
        {

            // Create New Entry Here 
            __Created_Entry = Entry.Create_Entry_Id();
            if (__Created_Entry.Rows.Count != 0 ) {
                this.entry_number = this.__Created_Entry.Rows[0]["entry_number"].ToString();
                this.entry_id = Convert.ToInt32(this.__Created_Entry.Rows[0]["id"]);
            }

            // Init Components 
            InitializeComponent(); 

        }
        
        private void Add_New_Entry_Load(object sender, EventArgs e)
        {
            
            this.__Entries = Entry.Get_All_Entries();
            this.__Entries_Accounts = Entry.Get_All_Row_Entries_By_Id(this.entry_id);

            // Fill Components 
            this.Fill_Form_Components();

        }

        public void Fill_Form_Components() {

            entry_id_field.Text = this.entry_id.ToString();
            entry_number_field.Text = this.entry_number.ToString();
            entry_date_field.Text = entry_date_field.Value.ToString();
            entry_details_field.Text = entry_details_field.Text.ToString();

            DataRow emptyRow;
            for (int i = __Entries_Accounts.Rows.Count; i < 15; i++) {
                emptyRow = __Entries_Accounts.NewRow();
                foreach (DataColumn col in __Entries_Accounts.Columns) {
                    if (col.GetType().ToString() == "Int32")
                    {
                        emptyRow[col] = 0;
                    }

                    if (col.GetType().ToString() == "String")
                    {
                        emptyRow[col] = "";
                    }
                }
                __Entries_Accounts.Rows.Add(emptyRow);
            }

            datagrid_entry_accounts.DataSource = __Entries_Accounts;

            datagrid_entry_accounts.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);

            datagrid_entry_accounts.Columns["debit"].Visible = true; 
            datagrid_entry_accounts.Columns["credit"].Visible = true; 
            datagrid_entry_accounts.Columns["description"].Visible = true; 
            datagrid_entry_accounts.Columns["account_number"].Visible = true; 
            datagrid_entry_accounts.Columns["account_name"].Visible = true;
             
            DataGridViewImageColumn dgvImageColumn = new DataGridViewImageColumn();
            dgvImageColumn.HeaderText = "حذف";
            dgvImageColumn.Name = "deletion";

            //dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch; 
            datagrid_entry_accounts.Columns.Add(dgvImageColumn);  

            foreach ( DataGridViewRow rows in datagrid_entry_accounts.Rows ) {

                rows.Cells["deletion"].Value = Properties.Resources.icons8_delete_20;
 
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
