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
        public int last_row = -1; 
        public DataTable __Entries_Accounts;
        public DataTable __Created_Entry;
        public int doc_type = 4; 
        public int entry_id = -1;
        public string entry_number = "-1";
        public bool isExtendedWidow = false;
        public FRM_ALL_ENTRIES records;

        public Add_New_Entry(int id, FRM_ALL_ENTRIES frm)
        {

            InitializeComponent();
            this.records = frm;
            if (id == -1)
            {
                // Create New 
                this.__Created_Entry = Entry.Create_Entry_Id();
                if (this.__Created_Entry.Rows.Count != 0)
                {
                    this.entry_number = this.__Created_Entry.Rows[0]["entry_number"].ToString();
                    this.entry_id = Convert.ToInt32(this.__Created_Entry.Rows[0]["id"]);
                }
                this.__Entries_Accounts = Entry.Get_All_Row_Entries_By_Id(this.entry_id);
            }
            else {
                 
                // Update Window 
                this.entry_id = id; 
                this.__Created_Entry = Entry.Get_This_Entry_By_Id(this.entry_id);
                this.__Entries_Accounts = Entry.Get_All_Row_Entries_By_Id(this.entry_id);

                this.entry_number = this.__Created_Entry.Rows[0]["entry_number"].ToString();
                this.entry_id = Convert.ToInt32(this.__Created_Entry.Rows[0]["id"]);

            }

            

            this.Fill_Form_Components();
            this.isExtendedWidow = true;

        }


        private void Add_New_Entry_Load(object sender, EventArgs e)
        { 
        }

        public void Set_Needed_accounts_in_entries( string account_name, string account_number ) {
            
            if (this.last_row == -1) {
                return;
            }

            datagrid_entry_accounts.Rows[this.last_row].Cells["account_name"].Value = account_name;
            datagrid_entry_accounts.Rows[this.last_row].Cells["account_number"].Value = account_number;

        }

        public void Calculate_Totals() {

            decimal debits = 0;
            decimal credits = 0;

            DataTable tblxeds = (DataTable) datagrid_entry_accounts.DataSource;
            foreach (DataRow row in tblxeds.Rows)
            {
                if (row["account_name"].ToString() != "")
                {

                    if (  row["debit"].ToString() != "" )
                    debits += Convert.ToDecimal(row["debit"]);

                    if (row["credit"].ToString() != "")
                    credits += Convert.ToDecimal(row["credit"].ToString());

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
            datagrid_entry_accounts.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.ReadOnly = true);

            datagrid_entry_accounts.Columns["debit"].ReadOnly = false;
            datagrid_entry_accounts.Columns["credit"].ReadOnly = false;
            datagrid_entry_accounts.Columns["description"].ReadOnly = false; 
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
            DataGridViewButtonColumn deletionButtonDG = new DataGridViewButtonColumn();
            deletionButtonDG.HeaderText = "حذف";
            deletionButtonDG.Name = "deletion";
            deletionButtonDG.Text = "dasd";
            //dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch; 
            datagrid_entry_accounts.Columns.Insert(datagrid_entry_accounts.Columns.Count - 1, deletionButtonDG);

            this.Calculate_Totals();
            if (this.__Created_Entry.Rows.Count != 0)
            {
                entry_date_field.Value = Convert.ToDateTime(__Created_Entry.Rows[0]["updated_date"]);
                entry_details_field.Text = __Created_Entry.Rows[0]["description"].ToString();
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
             
            if (debit_label_text.Text.ToString() != credit_label_text.Text.ToString()) {

                MessageBox.Show("يجب ان يكون قيمة الدائن تساوي قيمة المدين", "حدث خطأ",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

            DataTable tableView = (DataTable)datagrid_entry_accounts.DataSource;
            foreach ( DataRow xy in tableView.Rows ) {

                if (xy["account_number"].ToString() != "") { 
                    row = table.NewRow(); 
                    row["journal_id"] = Convert.ToInt32(entry_id_field.Text); 
                    if (xy["debit"] != null)
                    {
                        row["debit"] = Convert.ToDecimal(xy["debit"]);
                    }
                    else
                    {
                        row["debit"] = 0;
                    }

                    if (xy["credit"] != null)
                    {
                        row["credit"] = Convert.ToDecimal(xy["credit"]);
                    }
                    else
                    {
                        row["credit"] =0;
                    }

                    row["description"] = xy["description"].ToString();
                    row["cost_center_number"] = "-1";
                    row["account_number"] = xy["account_number"].ToString();

                    table.Rows.Add(row);
                }
            }
            /*-----------------------------------------
            Create Journal  
            ------------------------------------------ */
            
            Entry.Update_Entries_Data(table, entry_date_field.Value , entry_details_field.Text.ToString(), Convert.ToInt32(entry_id_field.Text) );

            if (this.isExtendedWidow) {
                this.records.Load_All_Records();
                this.Close();
            }

        }

        private void datagrid_entry_accounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.Calculate_Totals();
        }

        public void execute_col_events(int indexCol, int indexRow ) {

            this.last_row = indexRow;

            if (indexCol == -1 || indexRow == -1) {
                return;
            }

            if (indexCol == 1 || indexCol == 2) {
                UI.___Accounts accs = new UI.___Accounts(5, this);
                accs.ShowDialog();
            }

            //Deletion 
            if (indexCol == 0) {
                datagrid_entry_accounts.Rows[indexRow].Cells["account_number"].Value = "";
                datagrid_entry_accounts.Rows[indexRow].Cells["account_name"].Value = "";
                datagrid_entry_accounts.Rows[indexRow].Cells["description"].Value = "";
                datagrid_entry_accounts.Rows[indexRow].Cells["debit"].Value = 0;
                datagrid_entry_accounts.Rows[indexRow].Cells["credit"].Value = 0; 
            }
        }

        private void datagrid_entry_accounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.execute_col_events(e.ColumnIndex, e.RowIndex);
        }

        private void datagrid_entry_accounts_KeyDown(object sender, KeyEventArgs e)
        { 
            this.execute_col_events(datagrid_entry_accounts.CurrentCell.OwningColumn.Index, datagrid_entry_accounts.CurrentCell.OwningRow.Index);
        }


        private void datagrid_entry_accounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            bool isCol = datagrid_entry_accounts.CurrentCell.ColumnIndex == 5 || datagrid_entry_accounts.CurrentCell.ColumnIndex == 4;

            if (isCol) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (entry_id_field.Text == "-1" || entry_id_field.Text == "") {
                return;
            }

            Entry.Delete_Records_With_Entries(Convert.ToInt32(entry_id_field.Text) );

            if (this.isExtendedWidow)
            {
                this.records.Load_All_Records();
                this.Close();
            }

        }
    }
}
