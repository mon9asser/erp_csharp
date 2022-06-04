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
    public partial class Select_Journal_Account : Form
    {

        FND___Entry_Details Entry;

        public int document_type = -1;
        public int DG_Index = -1;
        FND___salesInvoice Sales_Document;
        FND___salesReturnInvoice Return_Sales_Document;
        purchaseInvoice Purchase_Document;
        purchaseReturnInvoice Return_Purchase_Document;
        PL.AccountingTree Tree = new PL.AccountingTree();
        DataTable Useful_Accounts;

        public Select_Journal_Account(int doc_type, int index, purchaseReturnInvoice Purchase_Return_Document)
        {
            this.Useful_Accounts = this.Tree.Get_Useful_Accounts();
            this.document_type = doc_type;
            this.Return_Purchase_Document = Purchase_Return_Document;
            this.DG_Index = index;

            InitializeComponent();

            // Load All Accounts 
            this.Fill_DataGridView_Data();

            this.Useful_Accounts = this.Search_Extract_Accounts(this.Useful_Accounts, "11010", "11020");
            this.Fill_DataGridView_Data();
        }

        public Select_Journal_Account(int doc_type, int index, purchaseInvoice Purchase_Document)
        {
            this.Useful_Accounts = this.Tree.Get_Useful_Accounts();
            this.document_type = doc_type;
            this.Purchase_Document = Purchase_Document;
            this.DG_Index = index;

            InitializeComponent();

            // Load All Accounts 
            this.Fill_DataGridView_Data();

            this.Useful_Accounts = this.Search_Extract_Accounts(this.Useful_Accounts, "11010", "11020");
            this.Fill_DataGridView_Data();
        }

        // Return Sales Invoices 
        public Select_Journal_Account(int doc_type, int index, FND___salesReturnInvoice Return_Sales_Document)
        {
            this.Useful_Accounts = this.Tree.Get_Useful_Accounts();
            this.document_type = doc_type;
            this.Return_Sales_Document = Return_Sales_Document;
            this.DG_Index = index;

            InitializeComponent();

            // Load All Accounts 
            this.Fill_DataGridView_Data();

            this.Useful_Accounts = this.Search_Extract_Accounts(this.Useful_Accounts, "11010", "11020");
            this.Fill_DataGridView_Data();
        }

        // Sales Invoices 
        public Select_Journal_Account(int doc_type, int index, FND___salesInvoice Sales_Document )
        {
            this.Useful_Accounts = this.Tree.Get_Useful_Accounts();
            this.document_type = doc_type;
            this.Sales_Document = Sales_Document;
            this.DG_Index = index;

            InitializeComponent(); 

            // Load All Accounts 
            this.Fill_DataGridView_Data();

            this.Useful_Accounts = this.Search_Extract_Accounts(this.Useful_Accounts, "11010", "11020");
            this.Fill_DataGridView_Data();
        }

        // Add Journal Entries => doc type 4
        public Select_Journal_Account( int doc_type, int index, FND___Entry_Details entry )
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
            // Sales - Purchases And Returns  
            // ------------------------------------------------
            if (this.document_type == 0  )
            {
                this.Sales_Document.legend_name.Text = "حـ / " + account_name;
                this.Sales_Document.legend_number.Text = account_number;
            }

            if (this.document_type == 1)
            {
                this.Purchase_Document.legend_name.Text = "حـ / " + account_name;
                this.Purchase_Document.legend_number.Text = account_number;
            }

            if (this.document_type == 2)
            {
                this.Return_Sales_Document.legend_name.Text = "حـ / " + account_name;
                this.Return_Sales_Document.legend_number.Text = account_number;
            }

            if (this.document_type == 3)
            {

                this.Return_Purchase_Document.legend_name.Text = "حـ / " + account_name;
                this.Return_Purchase_Document.legend_number.Text = account_number;

            }
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

        public DataTable Search_Extract_Accounts(DataTable tbl, string searchValue, string secvalue) {

            DataTable newTable = new DataTable();

            foreach (DataColumn col in tbl.Columns)
            {
                newTable.Columns.Add(col.ToString());
            }

            string search = "account_name LIKE '%" + searchValue + "%' OR account_number LIKE '%" + secvalue + "%'";

            if (searchValue != secvalue) {
                search = "account_number LIKE '%" + searchValue + "%' OR account_number LIKE '%" + secvalue + "%'";
            }

            DataRow[] filteredRows = tbl.Select(search);

            if (filteredRows.Length != 0)
            {

                DataRow new_row;

                for (int i = 0; i < filteredRows.Length; i++)
                {

                    new_row = newTable.NewRow();

                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        new_row[col.Name.ToString()] = filteredRows[i][col.Name.ToString()]; 
                    }

                    newTable.Rows.Add(new_row);

                }

            }

            return newTable;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            this.Fill_DataGridView_Data();

            string searchValue = textBox1.Text;
            if (searchValue == "")
            {
                return;
            }

            // Search_Extract_Accounts
            DataTable tbl = (DataTable)dataGridView1.DataSource; 
            dataGridView1.DataSource = this.Search_Extract_Accounts(tbl, searchValue, searchValue);

        }
    }
}
