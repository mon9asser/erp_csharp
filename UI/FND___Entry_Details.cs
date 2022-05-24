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
    public partial class FND___Entry_Details : Form
    {


        PL.DailyEntries entry = new PL.DailyEntries();
        PL.Installings sets = new PL.Installings();

        public DataSet DataSource;
        public DataTable Journals;
        public DataTable Journal_Details;
        public DataTable Settings;
        public int Current_Index = 0;
        public int Document_Type = 4;



        public FND___Entry_Details()
        {
            InitializeComponent();

            this.Extract_Data_Set_In_Data_Source();
            this.Settings = sets.Get_All_System_Settings();

            // Disable Elements 
            this.Disable_Form_Fields();

            // Load Data 
            this.Load_data_Entries();
        }

        public void Load_data_Entries() {
            // Fill All Data 
            int id = -1;
            if (this.Journals.Rows.Count != 0)
            {
                id = Convert.ToInt32(this.Journals.Rows[this.Journals.Rows.Count - 1]["id"]);
            }
             
            this.Fill_Datagridview_accounts(id);
            this.Fill_Journal_Fields(id);

        }

        public void Extract_Data_Set_In_Data_Source() {

            int[] except_types = new int[4];
            except_types[0] = 0;
            except_types[1] = 1;
            except_types[2] = 2;
            except_types[3] = 3;

            this.DataSource = this.entry.Get_Entries_Except_Fields(except_types);
            this.Journals = this.DataSource.Tables[0]; 
            this.Journal_Details = this.DataSource.Tables[1];
             
            if (this.Journals.Rows.Count == 0) {
                this.Current_Index = 0;
            } else 
            this.Current_Index = (this.Journals.Rows.Count - 1);


            this.set_paging_number();
        }

   

        public void Fill_Datagridview_accounts(int journal_id = -1 ) {

            DataTable details_table = new DataTable();

            // Copy Columns 
            foreach (DataColumn colums in this.Journal_Details.Columns)
            {
                details_table.Columns.Add(colums.ColumnName.ToString());
            }

            
            // Copy Selected Rows 
            DataRow drow;
            foreach (DataRow rox in this.Journal_Details.Rows)
            {
                 
                if (rox["journal_id"].ToString() == journal_id.ToString()) {
                   
                    drow = details_table.NewRow();
                    foreach (DataColumn colums in this.Journal_Details.Columns)
                    {
                        drow[colums.ColumnName.ToString()] = rox[colums.ColumnName.ToString()];
                    }
                    details_table.Rows.Add(drow);

                }
            }

            // ReOrdering Data 
            details_table.Columns["account_number"].SetOrdinal(0);
            details_table.Columns["account_name"].SetOrdinal(1);
            details_table.Columns["description1"].SetOrdinal(2);
            details_table.Columns["debit"].SetOrdinal(3);
            details_table.Columns["credit"].SetOrdinal(4);
             
            // Prepare DataGrid Items 
            this.Fill_DataGridView_Items(details_table);
        }

        public void Fill_Journal_Fields(int id ) {

            
            if (this.Journals.Rows.Count == 0) {
                return;
            }

            DataRow row__ = this.Journals.Rows[this.Journals.Rows.Count - 1];

            foreach (DataRow row in this.Journals.Rows) {
                if (row["id"].ToString().Equals(id.ToString()) ) {
                    row__ = row;
                }
            }

            
            entry_number_field.Text = row__["entry_number"].ToString();
            entry_id_field.Text = row__["id"].ToString();
            description_field.Text = row__["description"].ToString();
            if(row__["updated_date"] != System.DBNull.Value)
            datetime_field.Value = Convert.ToDateTime(row__["updated_date"]);

        }

        public void Fill_DataGridView_Items(DataTable table ) {

            // Add 20 empty Rows to this table 
            DataRow emptyRow;
            for (int i = table.Rows.Count; i < 10; i++) {
                emptyRow = table.NewRow();

                foreach ( DataColumn col in table.Columns ) {

                    if (col.GetType().ToString() == "Int32")
                    {
                        emptyRow[col] = 0;
                    }

                    if (col.GetType().ToString() == "String")
                    {
                        emptyRow[col] = "";
                    } 

                }

                table.Rows.Add(emptyRow);
            }
            

            datagridview_items.DataSource = table;

            datagridview_items.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);

            // VISIBLE SOME COLUMNS
            datagridview_items.Columns["debit"].ReadOnly = false;
            datagridview_items.Columns["credit"].ReadOnly = false;
            datagridview_items.Columns["description1"].ReadOnly = false;
            datagridview_items.Columns["debit"].Visible = true;
            datagridview_items.Columns["credit"].Visible = true;
            datagridview_items.Columns["description1"].Visible = true;
            datagridview_items.Columns["account_number"].Visible = true;
            datagridview_items.Columns["account_name"].Visible = true;
            datagridview_items.Columns["account_name"].Width = 190;
            datagridview_items.Columns["description1"].Width = 230;

            datagridview_items.Columns["debit"].HeaderText = "مدين";
            datagridview_items.Columns["credit"].HeaderText = "دائن";
            datagridview_items.Columns["description1"].HeaderText = "شرح";
            datagridview_items.Columns["account_number"].HeaderText = "رقم الحساب";
            datagridview_items.Columns["account_name"].HeaderText = "اسم الحساب";

            datagridview_items.Columns["debit"].ReadOnly = false;
            datagridview_items.Columns["credit"].ReadOnly = false;
            datagridview_items.Columns["description1"].ReadOnly = false;

            // Add new Column Of Deletion Button
            DataGridViewButtonColumn deletion_button = new DataGridViewButtonColumn();
            deletion_button.FlatStyle = FlatStyle.Flat;
            deletion_button.HeaderText = "حذف";
            deletion_button.Name = "deletion_et_button";
            deletion_button.Text = "حذف";
            deletion_button.UseColumnTextForButtonValue = true;
            datagridview_items.Columns.Add(deletion_button); 


        }
         

        public void Disable_Form_Fields(bool disabled = true) {

            entry_number_field.Enabled = !disabled;
            entry_id_field.Enabled = !disabled;
            description_field.Enabled = !disabled;
            datetime_field.Enabled = !disabled;
            datagridview_items.ReadOnly = disabled; 

            add_new_button.Enabled = disabled;
            save_button.Enabled = !disabled;
            first_record_button.Enabled = disabled;
            next_button.Enabled = disabled;
            current_invoice_page.Enabled = disabled;
            previous_button.Enabled = disabled;
            last_record_button.Enabled = disabled;
            edit_button.Enabled = disabled;
            search_button.Enabled = disabled;

            datetime_field.Value = DateTime.Now;
        }

        public bool Is_Empty_Grid_View(DataGridView name, string cell_name) {

            bool empty = true;
            foreach (DataGridViewRow rw in name.Rows)
            {
                if (rw.Cells[cell_name].Value != null || rw.Cells[cell_name].Value != DBNull.Value  )
                {
                    empty = false; 
                }
            }

            return empty;
        }

        private void add_new_button_Click(object sender, EventArgs e)
        {
            // Create new Id 
            DataTable tble = entry.Create_Entry_Id();
            this.Extract_Data_Set_In_Data_Source();

            if (tble.Rows.Count == 0) {
                return;
            }
             
            // Fill Top Fields 
            this.Fill_Journal_Fields(Convert.ToInt32(tble.Rows[0]["id"]));

            // Fill Data Grid Items  
            this.Fill_Datagridview_accounts(Convert.ToInt32(tble.Rows[0]["id"]));

            this.nextCallback();

            // Disable 
            this.Disable_Form_Fields(false);

        }

        public bool zakat_vat_detection() {

            bool is_right = false;

            if (this.Settings.Rows.Count != 0) {

                bool account_1 = false;
                bool account_2 = false; 

                string number_1 = this.Settings.Rows[0]["sales_vat_account"].ToString();
                string number_2 = this.Settings.Rows[0]["purchases_vat_account"].ToString();

                DataTable tbl = (DataTable)datagridview_items.DataSource;
                foreach ( DataRow row in tbl.Rows ) {
                    if (row["account_number"] != "" && row["account_number"] != System.DBNull.Value ) {

                        if (number_1 == row["account_number"].ToString() ) {
                            account_1 = true;
                            continue;
                        }

                        if (number_2 == row["account_number"].ToString())
                        {
                            account_2 = true;
                            continue;
                        }
                    }
                }

                if (account_1 && account_2) {
                    is_right = true;
                }

            }

            return is_right;
        
        }

        private void save_button_Click(object sender, EventArgs e)
        {


            if ((total_credit.Text != total_debit.Text) && (total_credit.Text != "" && total_debit.Text != "")) {
                MessageBox.Show("من فضلك تأكد من البيانات يجب ان يكون الجانب المدين متساوي مع الجانب الدائن تماما", "حدث خطأ", MessageBoxButtons.OK );
                return;
            }

            // Disable Elements 
            this.Disable_Form_Fields(true);

            //--------------------------------------------
            // Journals
            //--------------------------------------------
            DataTable journs = new DataTable();
            journs.Columns.Add("id"); // int
            journs.Columns.Add("updated_by");// int
            journs.Columns.Add("doc_id"); // int
            journs.Columns.Add("doc_type"); // int 
            journs.Columns.Add("description"); // string
            journs.Columns.Add("is_forwarded");// bool
            journs.Columns.Add("entry_number"); // string
            journs.Columns.Add("updated_date"); // datetime
            journs.Columns.Add("show_balances_in_period"); // datetime

            DataRow journs_rw = journs.NewRow();
            journs_rw["id"] = Convert.ToInt32(entry_id_field.Text); // int
            journs_rw["updated_by"] = Convert.ToInt32(-1);// int
            journs_rw["doc_id"] = Convert.ToInt32(entry_id_field.Text); // int
            journs_rw["doc_type"] = this.Document_Type; // int 
            journs_rw["description"] = description_field.Text.ToString(); // string
            journs_rw["is_forwarded"] = true;// bool
            journs_rw["entry_number"] = entry_number_field.Text.ToString(); // string
            journs_rw["updated_date"] = Convert.ToDateTime(datetime_field.Value); // datetime
            journs_rw["show_balances_in_period"] = this.zakat_vat_detection(); // bit 
            journs.Rows.Add(journs_rw);

            //--------------------------------------------
            // Journal Details 
            //--------------------------------------------
            DataTable journs_dets = new DataTable();
            journs_dets.Columns.Add("journal_id"); // int
            journs_dets.Columns.Add("debit");// decimal
            journs_dets.Columns.Add("credit"); // decimal
            journs_dets.Columns.Add("description"); // string
            journs_dets.Columns.Add("cost_center_number"); // string
            journs_dets.Columns.Add("date");// datetime
            journs_dets.Columns.Add("account_number"); // string

            
            DataTable CheckViewTable = (DataTable)datagridview_items.DataSource;

            DataRow drow;
            foreach (DataRow rw in CheckViewTable.Rows) {

                if (rw["account_number"].ToString() != "") {

                    drow = journs_dets.NewRow();

                    drow["journal_id"] = Convert.ToInt32(entry_id_field.Text); // int

                    if (rw["debit"] != System.DBNull.Value)
                        drow["debit"] = Convert.ToDecimal(rw["debit"]);// decimal
                    else drow["debit"] = 0;

                    if (rw["credit"] != System.DBNull.Value)
                        drow["credit"] = Convert.ToDecimal(rw["credit"]); // decimal
                    else drow["credit"] = 0;

                    drow["description"] = rw["description1"].ToString(); // string

                    if (rw["cost_center_number"] != null)
                        drow["cost_center_number"] = rw["cost_center_number"].ToString(); // string
                    else drow["cost_center_number"] = "";

                    if (rw["account_number"] != null)
                        drow["account_number"] = rw["account_number"].ToString(); // string
                    else drow["account_number"] = -1;

                    drow["date"] = datetime_field.Value;

                    journs_dets.Rows.Add(drow);
                }

            }

            // Storing 
            entry.Update_DataSet_Of_Daily_Entries(Convert.ToInt32(entry_id_field.Text), journs, journs_dets);

            // Referesh DataTables
            this.Extract_Data_Set_In_Data_Source();

            // Get Data Of Journals and Details 
            this.Extract_Data_Set_In_Data_Source();

        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            // Disable 
            this.Disable_Form_Fields(false);
        }

        private void datagridview_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1 || datagridview_items.ReadOnly )
            {
                return;
            }

            if(datagridview_items.Columns[e.ColumnIndex].Name.ToString() == "deletion_et_button") {
  
                datagridview_items.Rows[e.RowIndex].Cells["account_number"].Value = "";
                datagridview_items.Rows[e.RowIndex].Cells["account_name"].Value = "";
                datagridview_items.Rows[e.RowIndex].Cells["description1"].Value = "";
                datagridview_items.Rows[e.RowIndex].Cells["debit"].Value = 0;
                datagridview_items.Rows[e.RowIndex].Cells["credit"].Value =0;

            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (datagridview_items.Columns[datagridview_items.CurrentCell.ColumnIndex].Name.ToString() == "debit" || datagridview_items.Columns[datagridview_items.CurrentCell.ColumnIndex].Name.ToString() == "credit") //Desired Column
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
              
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' )
            {
                e.Handled = true;
            } 
        }

        private void datagridview_items_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) {
                return;
            }

            if (datagridview_items.Columns[e.ColumnIndex].Name.ToString() == "debit" || datagridview_items.Columns[e.ColumnIndex].Name.ToString() == "credit")
            {

                string cell_name = datagridview_items.Columns[e.ColumnIndex].Name.ToString();
                int index = e.RowIndex;

                string value = datagridview_items.Rows[index].Cells[cell_name].Value.ToString();

                 

               // datagridview_items.Rows[e.RowIndex].Cells[datagridview_items.Columns[e.ColumnIndex].Name.ToString()].Value = 200.00;

            } 
        }

        private void datagridview_items_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
         

        private void datagridview_items_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void datagridview_items_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (datagridview_items.ReadOnly) {
                return;
            }

            if (e.ColumnIndex == -1 || e.RowIndex == -1) {
                return;
            }


            string columnName = datagridview_items.Columns[e.ColumnIndex].Name.ToString();
            
            if (columnName == "account_number" || columnName == "account_name") {

                UI.Select_Journal_Account journal = new UI.Select_Journal_Account(this.Document_Type, e.RowIndex, this );
                journal.ShowDialog();

            }

        }

        public decimal[] calculate_debit_credit_values() {

            decimal debits = 0;
            decimal credits = 0;

            DataTable table = (DataTable)datagridview_items.DataSource;
            try
            {
                foreach (DataRow row in table.Rows)
                {

                    if (row["debit"] != "" && row["debit"] != System.DBNull.Value)
                        debits += Convert.ToDecimal(row["debit"]);

                    if (row["credit"] != "" && row["credit"] != System.DBNull.Value)
                        credits += Convert.ToDecimal(row["credit"]);

                }
            }
            catch (Exception) { }

            decimal[] calculated = new decimal[2];

            calculated[0] = debits;
            calculated[1] = credits;

            return calculated;
        }

        private void datagridview_items_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            decimal[] calcs = this.calculate_debit_credit_values();

            decimal debit = calcs[0];
            decimal credit = calcs[1];

            total_credit.Text = credit.ToString();
            total_debit.Text = debit.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (entry_id_field.Text == "") {
                return;
            }

            // Delete Entry
            this.entry.Delete_Records_With_Entries(Convert.ToInt32(entry_id_field.Text));

            // Referesh The Data 
            this.Extract_Data_Set_In_Data_Source();

            // Disable Elements 
            this.Disable_Form_Fields();

            // Prev Row 
            this.prevCallback();

            // Load Data 
            this.Load_data_Entries();

        }

        private void search_button_Click(object sender, EventArgs e)
        {
            UI.Search_On_Entries soe = new UI.Search_On_Entries(this.Document_Type, this );
            soe.ShowDialog();
        }

        private void first_record_button_Click(object sender, EventArgs e)
        {
            if (this.Journals.Rows.Count == 0) {
                return;
            }
            this.Current_Index = 0;

            // Search On Data 
            int id = Convert.ToInt32(this.Journals.Rows[this.Current_Index]["id"]);
            this.Fill_Datagridview_accounts(id);
            this.Fill_Journal_Fields(id);

            this.set_paging_number();
        }

        public void prevCallback() {

            if (this.Journals.Rows.Count == 0) {
                return;
            }

            this.Current_Index = this.Current_Index - 1;
            if (this.Current_Index < 0)
            {
                this.Current_Index = 0;
            }

            // Search On Data 
            int id = Convert.ToInt32(this.Journals.Rows[this.Current_Index]["id"]);
            this.Fill_Datagridview_accounts(id);
            this.Fill_Journal_Fields(id);

            this.set_paging_number();
        }

        public void nextCallback()
        {
            if (this.Journals.Rows.Count == 0)
            {
                return;
            }

            this.Current_Index = this.Current_Index + 1;
            if (this.Current_Index >= this.Journals.Rows.Count)
            {
                this.Current_Index = this.Journals.Rows.Count - 1;
            }

            // Search On Data 
            int id = Convert.ToInt32(this.Journals.Rows[this.Current_Index]["id"]);
            this.Fill_Datagridview_accounts(id);
            this.Fill_Journal_Fields(id);

            this.set_paging_number();
        }

        private void last_record_button_Click(object sender, EventArgs e)
        {
            if (this.Journals.Rows.Count == 0)
            {
                return;
            }

            this.Current_Index = this.Journals.Rows.Count - 1;
            if (this.Journals.Rows.Count == 0) {
                this.Current_Index = 0;
            }

            // Search On Data 
            int id = Convert.ToInt32(this.Journals.Rows[this.Current_Index]["id"]);
            this.Fill_Datagridview_accounts(id);
            this.Fill_Journal_Fields(id);

            this.set_paging_number();

        }

        private void next_button_Click(object sender, EventArgs e)
        {
            if (this.Journals.Rows.Count == 0)
            {
                return;
            }

            this.Current_Index = this.Current_Index + 1;
            if (this.Current_Index >= this.Journals.Rows.Count) {
                this.Current_Index = this.Journals.Rows.Count - 1;
            }

            // Search On Data 
            int id = Convert.ToInt32(this.Journals.Rows[this.Current_Index]["id"]);
            this.Fill_Datagridview_accounts(id);
            this.Fill_Journal_Fields(id);

            this.set_paging_number();
        }

        private void previous_button_Click(object sender, EventArgs e)
        {
            this.prevCallback();
        }

        public void set_paging_number() {

            
            // Left Part 
            string all_pages = this.Journals.Rows.Count.ToString();
            if (this.Journals.Rows.Count < 10) {
                all_pages = "0" + all_pages;
            }

            // Right Part ( Current Page )
            string current_page = (this.Current_Index + 1 ).ToString();
            if ((this.Current_Index + 1 ) < 10) {
                current_page = "0" + current_page;
            }

            current_invoice_page.Text = (all_pages + " / " + current_page);

        }
    }
}
