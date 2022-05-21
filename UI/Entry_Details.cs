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
    public partial class Entry_Details : Form
    {


        PL.DailyEntries entry = new PL.DailyEntries();
        DataTable DataSource;
        public int Document_Type = -1;

        public Entry_Details()
        {
            InitializeComponent();

            int[] except_types = new int [4];
            except_types[0] = 0;
            except_types[1] = 1;
            except_types[2] = 2;
            except_types[3] = 3; 
            this.DataSource = this.entry.Get_Entries_Except_Fields(except_types);

            // Disable Elements 
            this.Disable_Form_Fields();

            // Extract Only Journal Table To Do Paging


            // Fill All Data 
            int id = -1;
            if (this.DataSource.Rows.Count != 0) {
                id = Convert.ToInt32(this.DataSource.Rows[this.DataSource.Rows.Count - 1]["journal_id"]);
            }
            this.Fill_Data_Fields(id);
        }

        public void Fill_Data_Fields(int jorunal_id = -1 ) {

            DataTable table = this.DataSource; 
            if (jorunal_id != -1) {
                table = this.DataSource.Select("journal_id = '"+ jorunal_id  + "'", "journal_id DESC").CopyToDataTable();
            }

            // Re Ordering 
            table.Columns["account_number"].SetOrdinal(0);
            table.Columns["account_name"].SetOrdinal(1);
            table.Columns["description"].SetOrdinal(2);
            table.Columns["debit"].SetOrdinal(3);
            table.Columns["credit"].SetOrdinal(4);

            if (table.Rows.Count == 0)
            {
                this.Fill_DataGridView_Items(table);
                return;
            }
             
            // Prepare Basic Fields 
            DataRow row__ = table.Rows[0];
            entry_number_field.Text = row__["entry_number"].ToString();
            entry_id_field.Text = row__["id"].ToString();
            description_field.Text = row__["description"].ToString();
            datetime_field.Value = (row__["updated_date"] == "" )? DateTime.Now:Convert.ToDateTime(row__["updated_date"]);

            // Prepare DataGrid Items 
            this.Fill_DataGridView_Items(table);

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
            datagridview_items.ReadOnly = !disabled;


            add_new_button.Enabled = disabled;
            save_button.Enabled = !disabled;
            first_record_button.Enabled = disabled;
            next_button.Enabled = disabled;
            current_invoice_page.Enabled = disabled;
            previous_button.Enabled = disabled;
            last_record_button.Enabled = disabled;
            edit_button.Enabled = !disabled;
            search_button.Enabled = !disabled;

            datetime_field.Value = DateTime.Now;
        }

        private void add_new_button_Click(object sender, EventArgs e)
        {
            this.Disable_Form_Fields(false);
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            this.Disable_Form_Fields(true);
        }
    }
}
