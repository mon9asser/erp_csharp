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
    public partial class Select_Journal_Account : Form
    {

        Entry_Details Entry;

        public int document_type = -1;
        public int DG_Index = -1;

        PL.AccountingTree Tree = new PL.AccountingTree();
        DataTable Useful_Accounts;



        // Add Journal Entries => doc type 4
        public Select_Journal_Account( int doc_type, int index, Entry_Details entry )
        {
            this.Useful_Accounts = this.Tree.Get_Useful_Accounts();
            this.document_type = doc_type;
            this.Entry = entry;
            this.DG_Index = index;

            InitializeComponent();

            // Load All Accounts 
            this.Fill_DataGridView_Data();

        }

        public void Fill_DataGridView_Data() {

            dataGridView1.DataSource = this.Useful_Accounts;
            dataGridView1.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);

            dataGridView1.Columns["account_number"].Visible = true;
            dataGridView1.Columns["account_name"].Visible = true;

            dataGridView1.Columns["account_name"].HeaderText = "إسم الحساب";
            dataGridView1.Columns["account_number"].HeaderText = "رقم الحساب";

            dataGridView1.Columns["account_name"].Width = 230;
            dataGridView1.Columns["account_number"].Width = 70;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) {
                return;
            }


            string account_number = dataGridView1.Rows[e.RowIndex].Cells["account_number"].Value.ToString();
            string account_name   = dataGridView1.Rows[e.RowIndex].Cells["account_name"].Value.ToString();

            // ------------------------------------------------
            // Journal Entry 
            // ------------------------------------------------

            if (this.document_type == 4) {

                this.Entry.datagridview_items.ReadOnly = true;
                if (this.DG_Index == -1) {
                    return;
                }

                this.Entry.datagridview_items.Rows[this.DG_Index].Cells["account_number"].Value = account_number;
                this.Entry.datagridview_items.Rows[this.DG_Index].Cells["account_name"].Value = "حـ / " + account_name;
                this.Entry.datagridview_items.ReadOnly = false;
            }


            this.Close();
        }
    }
}
