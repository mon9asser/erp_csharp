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

    public partial class Add_New_Entry : Form
    {
        PL.DailyEntries Entry = new PL.DailyEntries();
        public DataTable __Entries;
        public DataTable __Entries_Accounts;
        public DataTable __Created_Entry;
        public int doc_type = 4; 
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

        public void Calculate_Totals() {

            decimal debits = 0;
            decimal credits = 0; 

            foreach (DataGridViewRow row in datagrid_entry_accounts.Rows)
            {
                if (System.DBNull.Value != row.Cells["account_name"].Value )
                {

                    if (  row.Cells["debit"].Value != System.DBNull.Value)
                    debits += Convert.ToDecimal(row.Cells["debit"].Value);

                    if (row.Cells["credit"].Value != System.DBNull.Value )
                    credits += Convert.ToDecimal(row.Cells["credit"].Value);

                }
            }

            debit_label_text.Text = string.Format("{0:n}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(debits), 2))).ToString();  
            credit_label_text.Text = string.Format("{0:n}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(credits), 2))).ToString(); 

        }

        public void Fill_Form_Components() {

            entry_id_field.Text = this.entry_id.ToString();
            entry_number_field.Text = this.entry_number.ToString();
             
            // Reorder Items 
            __Entries_Accounts.Columns["account_number"].SetOrdinal(0);
            __Entries_Accounts.Columns["account_name"].SetOrdinal(1);
            __Entries_Accounts.Columns["description"].SetOrdinal(2);
            __Entries_Accounts.Columns["debit"].SetOrdinal(3);
            __Entries_Accounts.Columns["credit"].SetOrdinal(4);

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
            datagrid_entry_accounts.Columns["account_name"].Width = 150;
            datagrid_entry_accounts.Columns["description"].Width = 260;

            datagrid_entry_accounts.Columns["debit"].HeaderText = "مدين";
            datagrid_entry_accounts.Columns["credit"].HeaderText = "دائن";
            datagrid_entry_accounts.Columns["description"].HeaderText = "شرح";
            datagrid_entry_accounts.Columns["account_number"].HeaderText = "رقم الحساب";
            datagrid_entry_accounts.Columns["account_name"].HeaderText = "اسم الحساب";
            DataGridViewImageColumn dgvImageColumn = new DataGridViewImageColumn();
            dgvImageColumn.HeaderText = "حذف";
            dgvImageColumn.Name = "deletion";

            //dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch; 
            datagrid_entry_accounts.Columns.Add(dgvImageColumn);  

            foreach ( DataGridViewRow rows in datagrid_entry_accounts.Rows ) { 
                rows.Cells["deletion"].Value = Properties.Resources.icons8_delete_20; 
            }

            this.Calculate_Totals();
            if (this.__Entries.Rows.Count != 0)
            {
                entry_date_field.Value = Convert.ToDateTime(__Entries.Rows[0]["updated_date"]);
                entry_details_field.Text = __Entries.Rows[0]["description"].ToString();
            }
            else {
                entry_date_field.Value = DateTime.Now;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           /*-----------------------------------------
            *  // Create DataTable For Jounral Items 
            ------------------------------------------ */
            DataTable table = new DataTable();
            table.Columns.Add("journal_id");
            table.Columns.Add("debit");
            table.Columns.Add("credit");
            table.Columns.Add("description");
            table.Columns.Add("cost_center_number");
            table.Columns.Add("account_number"); 

            DataRow row; 
            foreach (DataGridViewRow xy in datagrid_entry_accounts.Rows) {
                row = table.NewRow();
                row["journal_id"] = Convert.ToInt32(xy.Cells["journal_id"].Value);
                row["debit"] = xy.Cells["journal_id"].Value.ToString();
                row["credit"] = xy.Cells["journal_id"].Value.ToString();
                row["description"] = xy.Cells["journal_id"].Value.ToString();
                row["cost_center_number"] = "-1";
                row["account_number"] = xy.Cells["journal_id"].Value.ToString();
                datagrid_entry_accounts.Rows.Add(row);
            }

            /*-----------------------------------------
            Create Journal  
            ------------------------------------------ */
            Entry.Update_Entries_Data(table, entry_date_field.Value , entry_details_field.Text.ToString());
            
               

        }

        private void datagrid_entry_accounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.Calculate_Totals();
        }
    }
}
