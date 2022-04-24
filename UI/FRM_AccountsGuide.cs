using System;
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
    public partial class FRM_AccountsGuid : Form
    {
        PL.AccountingTree tree = new PL.AccountingTree();
        DataTable table;
        public int edited_row_index = -1;
        public int last_account_id = 0;

        public static FRM_AccountsGuid frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_AccountsGuid GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new FRM_AccountsGuid();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public FRM_AccountsGuid()
        {
            InitializeComponent();

            if (frm == null)
            {
                frm = this;
            }

            try
            {
                table = tree.Get_Accounting_Tree();
                this.Fill_Accounting_Tree();
            }
            catch (Exception) { }
            
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

            try {
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
                datagrid_accounts_tree.Columns["main_account"].HeaderText = "الحساب الرئيسي";


                datagrid_accounts_tree.Columns["account_number"].Width = 130;
                datagrid_accounts_tree.Columns["account_name"].Width = 295;
                datagrid_accounts_tree.Columns["main_account"].Width = 130;

                foreach (DataRow row in table.Rows)
                {

                    string acc_number = row["account_number"].ToString();
                    string acc_title = row["account_name"].ToString();
                    string parent_account = row["main_account"].ToString();

                    this.Fill_Tree_View(acc_number, acc_title, parent_account);


                }



                accounting_tree.ExpandAll();

            } catch (Exception) { }

        }
         
        public void Fill_Tree_View(string acc_number, string acc_title, string parent_account) {

            try
            {
                if (parent_account == "" || acc_title == "")
                {
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
            catch (Exception) { 
            
            }

        }
         
        
        private void accounting_tree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            //account_name.Text = accounting_tree.SelectedNode.Text.ToString();
           // account_number.Text = accounting_tree.SelectedNode.Tag.ToString();

            //foreach (DataRow row in table.Rows ) {
               
              //  if (Convert.ToInt32(row["account_number"]).Equals(Convert.ToInt32(accounting_tree.SelectedNode.Tag))) {

                 //   main_account_number.Text = row["main_account"].ToString();
                 //   account_name_en.Text = row["account_name_en"].ToString();

                 //   break;
                //}

            //}

        }
         
        private void datagrid_accounts_tree_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
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
            catch (Exception) { }
        }

         

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception) { }
        }

        public void live_tree_accounts() {

            try
            {
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

                    if (row["account_number"].ToString() == "" || row["account_name"].ToString() == "" || row["main_account"].ToString() == "")
                    {
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
            catch(Exception) { }
            

        }
        private void datagrid_accounts_tree_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try {
                bool validIndexes = e.ColumnIndex == -1 || e.RowIndex == -1;

                if (validIndexes)
                {
                    return;
                }


                account_number.Text = datagrid_accounts_tree.Rows[e.RowIndex].Cells["account_number"].Value.ToString();

                this.live_tree_accounts();
            
            } catch (Exception) { }           
        }

        private void datagrid_accounts_tree_KeyUp(object sender, KeyEventArgs e)
        {
            try {
                int rowIndex = datagrid_accounts_tree.CurrentCell.OwningRow.Index;
                int colIndex = datagrid_accounts_tree.CurrentCell.OwningColumn.Index;


                bool validIndexes = rowIndex == -1 || colIndex == -1;

                if (validIndexes)
                {
                    return;
                }

                account_number.Text = datagrid_accounts_tree.Rows[rowIndex].Cells["account_number"].Value.ToString();
                this.live_tree_accounts();
            
            } catch (Exception) { }
        }

        private void datagrid_accounts_tree_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                this.edited_row_index = e.RowIndex;

                if (this.edited_row_index == -1 || e.ColumnIndex == -1)
                {
                    return;
                }

                DataGridViewRow row = datagrid_accounts_tree.Rows[this.edited_row_index];

                if (row.Cells["account_number"].Value.ToString() != "" && row.Cells["account_name"].Value.ToString() != "" && row.Cells["main_account"].Value.ToString() != "")
                {
                    this.datagrid_accounts_tree.Sort(this.datagrid_accounts_tree.Columns["account_number"], ListSortDirection.Ascending);
                }
            }
            catch (Exception) { 
            
            }

            
        }
         

        private void button7_Click(object sender, EventArgs e)
        {
            try {
                if (account_number.Text.ToString() == "")
                {
                    return;
                }

                foreach (DataGridViewRow row in datagrid_accounts_tree.Rows)
                {

                    if (row.Cells["account_number"].Value == null || row.Cells["account_number"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["account_number"].ToString()))
                    {
                        break;
                    }

                    if (row.Cells["account_number"].Value.ToString().Equals(account_number.Text.ToString()))
                    {
                        datagrid_accounts_tree.Rows.Remove(row);
                    }

                }
            } catch (Exception) { }
        }

        private void datagrid_accounts_tree_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                account_number.Text = datagrid_accounts_tree.Rows[e.RowIndex].Cells["account_number"].Value.ToString();

            }
            catch (Exception) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
             
            try
            {
                DataTable table_2 = new DataTable();
                table_2.Columns.Add("account_number");
                table_2.Columns.Add("account_name");
                table_2.Columns.Add("main_account");

                DataRow newRow;
                foreach (DataGridViewRow row in datagrid_accounts_tree.Rows)
                {
                    if (row.Cells["account_number"].Value != null && row.Cells["account_number"].Value != DBNull.Value && !String.IsNullOrWhiteSpace(row.Cells["account_number"].ToString()))
                    {
                        newRow = table_2.NewRow();
                        newRow["account_number"] = row.Cells["account_number"].Value.ToString();
                        newRow["account_name"] = row.Cells["account_name"].Value.ToString();
                        newRow["main_account"] = row.Cells["main_account"].Value.ToString();
                        table_2.Rows.Add(newRow);
                    }
                }

                tree.Update_Tree_Of_Accounts(table_2);
            }
            catch (Exception) { }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                string dirPath = Directory.GetCurrentDirectory().ToString() + "\\Trees";

                if (Directory.Exists(dirPath))
                {
                    openFileDialog1.InitialDirectory = dirPath;
                }

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    panelWait.Visible = true;
                    Excel.Application oExcel = new Excel.Application();
                    Excel.Workbook WB = oExcel.Workbooks.Open(openFileDialog1.FileName);
                    string ExcelWorkbookname = WB.Name;
                    int worksheetcount = WB.Worksheets.Count;
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(openFileDialog1.FileName);
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                    UI.SelectTreeCols LoadExcelTree = new UI.SelectTreeCols(excelRange);
                    LoadExcelTree.ShowDialog();
                }
            }
            catch (Exception) { }
             

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTableSource = new DataTable();
                DataTableSource.Columns.Add("id");
                DataTableSource.Columns.Add("account_number");
                DataTableSource.Columns.Add("account_name");
                DataTableSource.Columns.Add("account_name_en");
                DataTableSource.Columns.Add("main_account");
                DataTableSource.Columns.Add("debit_credit");
                DataTableSource.Columns.Add("balance");
                DataTableSource.Columns.Add("is_main_account");

                DialogResult dialogResult = MessageBox.Show("هل أنت موفق علي حذف جميع حسابات الدليل ؟ مع العلم سيأثر هذا في جميع العمليات التي تمت من قبل وخصوصا عمليات الشراء والبيع", "تأكيد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.accounting_tree.Nodes.Clear();
                    this.datagrid_accounts_tree.DataSource = DataTableSource;

                    DataTable table_2 = new DataTable();
                    table_2.Columns.Add("account_number");
                    table_2.Columns.Add("account_name");
                    table_2.Columns.Add("main_account");
                    tree.Update_Tree_Of_Accounts(table_2);
                }
            }
            catch (Exception) { }
                
        }
    }
}


// this.datagrid_accounts_tree.Sort(this.datagrid_accounts_tree.Columns["account_number"], ListSortDirection.Ascending);
