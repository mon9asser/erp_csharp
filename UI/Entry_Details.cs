﻿using System;
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
    public partial class Entry_Details : Form
    {


        PL.DailyEntries entry = new PL.DailyEntries();
        DataSet DataSource;
        DataTable Journals;
        DataTable Journal_Details; 
        public int Document_Type = 4;

        public Entry_Details()
        {
            InitializeComponent();

            this.Extract_Data_Set_In_Data_Source();

            // Disable Elements 
            this.Disable_Form_Fields(); 

            // Fill All Data 
            int id = -1;
            if (this.Journals.Rows.Count != 0) {
                id = Convert.ToInt32(this.Journals.Rows[this.Journals.Rows.Count - 1]["id"]);
            }
             
            this.Fill_Data_Fields(id);
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
        }

        public void Fill_Data_Fields(int jorunal_id = -1 ) {

            DataTable table = this.Journal_Details; 
            if (jorunal_id != -1 && this.Journal_Details.Rows.Count != 0) {
                table = this.Journal_Details.Select("journal_id = '"+ jorunal_id  + "'", "journal_id DESC").CopyToDataTable();
            }

            //MessageBox.Show(this.Journal_Details.Rows.Count.ToString());
            // Re Ordering 
            table.Columns["account_number"].SetOrdinal(0);
            table.Columns["account_name"].SetOrdinal(1);
            table.Columns["description"].SetOrdinal(2);
            table.Columns["debit"].SetOrdinal(3);
            table.Columns["credit"].SetOrdinal(4);

            DataTable table_header = this.Journal_Details;
            if (this.Journal_Details.Rows.Count == 0) {
                table_header = this.Journals;
            }

            // Prepare Basic Fields 
            this.Fill_Journal_Fields(table_header);  

            // Prepare DataGrid Items 
            this.Fill_DataGridView_Items(table);

        }

        public void Fill_Journal_Fields(DataTable table) {

            if (table.Rows.Count == 0) {
                return;
            }

            DataRow row__ = table.Rows[table.Rows.Count - 1];
            entry_number_field.Text = row__["entry_number"].ToString();
            entry_id_field.Text = row__["id"].ToString();
            description_field.Text = row__["description"].ToString();
            datetime_field.Value = ( row__["updated_date"] == "" ) ? DateTime.Now : Convert.ToDateTime(row__["updated_date"]);

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
            datagridview_items.Columns["description"].ReadOnly = false;
            datagridview_items.Columns["debit"].Visible = true;
            datagridview_items.Columns["credit"].Visible = true;
            datagridview_items.Columns["description"].Visible = true;
            datagridview_items.Columns["account_number"].Visible = true;
            datagridview_items.Columns["account_name"].Visible = true;
            datagridview_items.Columns["account_name"].Width = 190;
            datagridview_items.Columns["description"].Width = 230;

            datagridview_items.Columns["debit"].HeaderText = "مدين";
            datagridview_items.Columns["credit"].HeaderText = "دائن";
            datagridview_items.Columns["description"].HeaderText = "شرح";
            datagridview_items.Columns["account_number"].HeaderText = "رقم الحساب";
            datagridview_items.Columns["account_name"].HeaderText = "اسم الحساب";

            datagridview_items.Columns["debit"].ReadOnly = false;
            datagridview_items.Columns["credit"].ReadOnly = false;
            datagridview_items.Columns["description"].ReadOnly = false;

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

            if (tble.Rows.Count == 0) {
                return;
            }

            // Clear DataGridView 
            if ( this.Is_Empty_Grid_View( datagridview_items, "account_name" ) == false ) {

                DataTable table = this.Journal_Details;
                table.Rows.Clear();
                this.Fill_DataGridView_Items(table);

            }

            // Fill IDs
            this.Fill_Journal_Fields(tble);

            // Disable 
            this.Disable_Form_Fields(false);

        }

        private void save_button_Click(object sender, EventArgs e)
        {


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

            DataRow journs_rw = journs.NewRow();
            journs_rw["id"] = Convert.ToInt32(entry_id_field.Text); // int
            journs_rw["updated_by"] = Convert.ToInt32(-1);// int
            journs_rw["doc_id"] = Convert.ToInt32(entry_id_field.Text); // int
            journs_rw["doc_type"] = this.Document_Type; // int 
            journs_rw["description"] = description_field.Text.ToString(); // string
            journs_rw["is_forwarded"] = true;// bool
            journs_rw["entry_number"] = entry_number_field.Text.ToString(); // string
            journs_rw["updated_date"] = Convert.ToDateTime(datetime_field.Value); // datetime
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

                    if (rw["description"] != null)
                        drow["description"] = rw["description"].ToString(); // string
                    else drow["description"] = "";

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
            if (e.ColumnIndex == -1 || e.RowIndex == -1 )
            {
                return;
            }

            if(datagridview_items.Columns[e.ColumnIndex].Name.ToString() == "deletion_et_button") {
  
                datagridview_items.Rows[e.RowIndex].Cells["account_number"].Value = "";
                datagridview_items.Rows[e.RowIndex].Cells["account_name"].Value = "";
                datagridview_items.Rows[e.RowIndex].Cells["description"].Value = "";
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
    }
}