﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace sales_management.UI
{
    public partial class AccTree : Form
    {
        PL.AccountingTree tree = new PL.AccountingTree();
        DataTable table;
        public int edited_row_index = -1;
        public int last_account_id = 0;

        public AccTree()
        {
            InitializeComponent();

            table = tree.Get_Accounting_Tree();
            this.Fill_Accounting_Tree();
            this.disable(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter ="Excel Files|*.xls;*.xlsx;*.xlsm";
            string dirPath = Directory.GetCurrentDirectory().ToString() + "\\Trees";

            if (Directory.Exists(dirPath))
            {
                openFileDialog1.InitialDirectory = dirPath;
            }
             

             
        }



        IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in Collect(node.Nodes))
                    yield return child;
            }
        }

        public void Fill_Accounting_Tree() {

            accounting_tree.Nodes.Clear();

            table = tree.Get_Accounting_Tree(); 
            datagrid_accounts_tree.DataSource = table;

            datagrid_accounts_tree.Columns["id"].Visible = false;
            datagrid_accounts_tree.Columns["account_name_en"].Visible = false;
            datagrid_accounts_tree.Columns["debit_credit"].Visible = false;
            datagrid_accounts_tree.Columns["balance"].Visible = false;
            datagrid_accounts_tree.Columns["is_main_account"].Visible = false; 
             

            datagrid_accounts_tree.Columns["account_number"].HeaderText = "رقم الحساب";
            datagrid_accounts_tree.Columns["account_name"].HeaderText = "إسم الحســـاب";
            datagrid_accounts_tree.Columns["main_account"].HeaderText = "تابع لحساب رقم";


            datagrid_accounts_tree.Columns["account_number"].Width = 140;
            datagrid_accounts_tree.Columns["account_name"].Width = 290;
            datagrid_accounts_tree.Columns["main_account"].Width = 140;

            foreach (DataRow row in table.Rows) {

                int acc_number = Convert.ToInt32(row["account_number"]);
                string acc_title = row["account_name"].ToString();
                string parent_account = row["main_account"].ToString();

                this.Fill_Tree_View(acc_number, acc_title, parent_account );


            }



            accounting_tree.ExpandAll();

        }


         

        public void Fill_Tree_View( int acc_number, string acc_title, string parent_account) {

            if (parent_account == "" || acc_title =="") {
                return;
            }

            if (Convert.ToInt32(parent_account) == 0)
            {
                TreeNode nodes = new TreeNode();
                nodes.Text = acc_title.ToString();
                nodes.Tag = acc_number.ToString();
                accounting_tree.Nodes.Add(nodes);
            }

            foreach (var node in Collect(accounting_tree.Nodes))
            {

                if (Convert.ToInt32(parent_account) != 0 && Convert.ToInt32(node.Tag).Equals(Convert.ToInt32(parent_account)))
                {
                    TreeNode childer = new TreeNode();
                    childer.Text = acc_title.ToString();
                    childer.Tag = acc_number.ToString();
                    node.Nodes.Add(childer);
                }

            }

        }

        public void LoadAccountingTree(string filepath) {

            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook WB = oExcel.Workbooks.Open(filepath);
            string ExcelWorkbookname = WB.Name;
            int worksheetcount = WB.Worksheets.Count;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filepath);
            Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;
            int rowCount = excelRange.Rows.Count;  //get row count of excel data
            int colCount = excelRange.Columns.Count; // get column count of excel data
             
            for (int i = 1; i <= rowCount; i++)
            {
                if (i != 1) { 
                    // Accounting Tree Data  
                    string accountNo       = excelRange.Cells[i, 1].Value2.ToString();
                    string accountName     = excelRange.Cells[i, 2].Value2.ToString();
                    string accountNameEn   = excelRange.Cells[i, 3].Value2.ToString();
                    string mainAccount     = excelRange.Cells[i, 4].Value2.ToString();
                    string isDebit         = excelRange.Cells[i, 5].Value2.ToString();
                    string balance         = (excelRange.Cells[i, 6].Value2.ToString() == "") ? "0" : excelRange.Cells[i, 6].Value2.ToString();

                    tree.Create_Tree_Account(-1, accountNo, accountName, accountNameEn, mainAccount, isDebit, balance, true );
                } 
            }
             
            // Fill The Tree 
            this.Fill_Accounting_Tree();

                   

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string textmsg = "سيتم حذف جميع الحسابات الرئيسية والفرعية هل انت موافق ؟"; 
            var confirmResult = MessageBox.Show( textmsg, "تأكيد الحذف", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            { 
                
                tree.Delete_All_Accounts();
                accounting_tree.Nodes.Clear(); 
            }
        }

        public void disable( bool isDisalbe, bool emptyValue = true ) {
            account_name.Enabled = !isDisalbe;
            account_number.Enabled =  !isDisalbe;
            account_name_en.Enabled = !isDisalbe;
            main_account_number.Enabled = !isDisalbe;
            account_type.Enabled = !isDisalbe;

            if (isDisalbe == false && emptyValue )
            {
                account_type.SelectedIndex = 0;
                account_name.Text = "";
                account_number.Text = "";
                account_name_en.Text = "";
                main_account_number.Text = "";
                main_account_number.ReadOnly = false;
            }
        }
        private void accounting_tree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            account_name.Text = accounting_tree.SelectedNode.Text.ToString();
            account_number.Text = accounting_tree.SelectedNode.Tag.ToString();

            foreach (DataRow row in table.Rows ) {
                
                if (Convert.ToInt32(row["account_number"]).Equals(Convert.ToInt32(accounting_tree.SelectedNode.Tag))) {

                    main_account_number.Text = row["main_account"].ToString();
                    account_name_en.Text = row["account_name_en"].ToString();

                    break;
                }

            }

        }

        public void add_new_account_to_tree( string account_number, string account_name, string main_account_number ){
            foreach (var node in Collect(accounting_tree.Nodes)){
                int main_acc_number = Convert.ToInt32(main_account_number);
                
                if (Convert.ToInt32(node.Tag).Equals(main_acc_number)) {

                    TreeNode child = new TreeNode();
                    child.Text = account_name.ToString();
                    child.Tag = account_number.ToString();
                    node.Nodes.Add(child);
  
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            tree.Create_Tree_Account(-1, account_number.Text.ToString(), account_name.Text.ToString(), account_name_en.Text.ToString(), main_account_number.Text.ToString(), account_type.SelectedIndex.ToString(), "0", false);
            this.add_new_account_to_tree(account_number.Text.ToString(), account_name.Text.ToString(), main_account_number.Text.ToString());
            this.disable(true);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (account_number.Text != "") {

                bool is_main = true;

                foreach (DataRow row in table.Rows)
                {

                    if (Convert.ToInt32(row["account_number"]).Equals(Convert.ToInt32(account_number.Text)))
                    {

                        is_main = Convert.ToBoolean(row["is_main_account"]);
                        break;
                    }

                }

                if (is_main)
                {
                    MessageBox.Show("لا يمكنك حذف حساب رئيسي من شجرة الحسابات");
                }
                else { 

                    string textmsg = "سيتم حذف جميع الحسابات الفرعية أيضا من هذا الحساب..  هل انت موافق ؟";
                    var confirmResult = MessageBox.Show(textmsg, "تأكيد الحذف", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {

                        tree.Delete_Account_By_Number(account_number.Text.ToString());
                        this.Fill_Accounting_Tree();
                        this.disable(true);
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.disable(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.disable(false, false);
        }

        private void datagrid_accounts_tree_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
             
            bool isCol = datagrid_accounts_tree.CurrentCell.ColumnIndex == 1 || datagrid_accounts_tree.CurrentCell.ColumnIndex == 4;

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

        public void live_tree_accounts() {

            DataTable table = (DataTable)datagrid_accounts_tree.DataSource;
            /*
             * table.Columns.Remove("id");
           table.Columns.Remove("account_name_en");
           table.Columns.Remove("debit_credit");
           table.Columns.Remove("balance");
           table.Columns.Remove("is_main_account");*/

             
            //  Clear The Tree
            accounting_tree.Nodes.Clear();

            foreach (DataRow row in table.Rows)
            {

                if (row["account_number"].ToString() == "" || row["account_name"].ToString() == "" || row["main_account"].ToString() == "") {
                    return;
                }

                int acc_number = Convert.ToInt32(row["account_number"]);
                string acc_title = row["account_name"].ToString();
                string parent_account = row["main_account"].ToString() == "" ? 0.ToString() : row["main_account"].ToString();



                if (Convert.ToInt32(parent_account) == 0)
                {
                    TreeNode nodes = new TreeNode();
                    nodes.Text = acc_title.ToString();
                    nodes.Tag = acc_number.ToString();
                    accounting_tree.Nodes.Add(nodes);
                }

                foreach (var node in Collect(accounting_tree.Nodes))
                {

                    if (Convert.ToInt32(parent_account) != 0 && Convert.ToInt32(node.Tag).Equals(Convert.ToInt32(parent_account)))
                    {
                        TreeNode childer = new TreeNode();
                        childer.Text = acc_title.ToString();
                        childer.Tag = acc_number.ToString();
                        node.Nodes.Add(childer);
                    }

                }
            }

            accounting_tree.ExpandAll();
            

        }
        private void datagrid_accounts_tree_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            

            bool validIndexes = e.ColumnIndex == -1 || e.RowIndex == -1;
            
            if (validIndexes) {
                return;
            }


            this.live_tree_accounts();
           
        }

        private void datagrid_accounts_tree_KeyUp(object sender, KeyEventArgs e)
        {
            int rowIndex = datagrid_accounts_tree.CurrentCell.OwningRow.Index;
            int colIndex = datagrid_accounts_tree.CurrentCell.OwningColumn.Index;

            bool validIndexes = rowIndex == -1 || colIndex == -1;

            if (validIndexes)
            {
                return;
            }

            this.live_tree_accounts();
        }

        private void datagrid_accounts_tree_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            this.edited_row_index = e.RowIndex;

            if (this.edited_row_index == -1 || e.ColumnIndex == -1 ) {
                return;
            } 

            DataGridViewRow row = datagrid_accounts_tree.Rows[this.edited_row_index];

            if (row.Cells["account_number"].Value.ToString() != "" && row.Cells["account_name"].Value.ToString() != "" && row.Cells["main_account"].Value.ToString() != "") {
                this.datagrid_accounts_tree.Sort(this.datagrid_accounts_tree.Columns["account_number"], ListSortDirection.Ascending);
            }

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            string dirPath = Directory.GetCurrentDirectory().ToString() + "\\Trees";

            if (Directory.Exists(dirPath))
            {
                openFileDialog1.InitialDirectory = dirPath;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {


                Excel.Application oExcel = new Excel.Application();
                Excel.Workbook WB = oExcel.Workbooks.Open(openFileDialog1.FileName);
                string ExcelWorkbookname = WB.Name;
                int worksheetcount = WB.Worksheets.Count;
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(openFileDialog1.FileName);
                Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;
                int rowCount = excelRange.Rows.Count;  //get row count of excel data
                int colCount = excelRange.Columns.Count;

                Console.WriteLine(excelRange.Cells[2,2].Value2);


            }
             
            /*
            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook WB = oExcel.Workbooks.Open(filepath);
            string ExcelWorkbookname = WB.Name;
            int worksheetcount = WB.Worksheets.Count;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filepath);
            Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;
            int rowCount = excelRange.Rows.Count;  //get row count of excel data
            int colCount = excelRange.Columns.Count; // get column count of excel data
            */
        }
    }
}


// this.datagrid_accounts_tree.Sort(this.datagrid_accounts_tree.Columns["account_number"], ListSortDirection.Ascending);
