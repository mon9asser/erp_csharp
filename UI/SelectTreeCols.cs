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

namespace sales_management.UI
{  
    public partial class SelectTreeCols : Form
    {

        private DataTable ExcelSheetDataTable;
        public SelectTreeCols()
        {
            InitializeComponent();
        }

        public SelectTreeCols(Microsoft.Office.Interop.Excel.Range rang )
        {

            InitializeComponent();

            try {

                int rowCount = rang.Rows.Count;
                int colCount = rang.Columns.Count;

                Dictionary<int, string> projectsDictionary = new Dictionary<int, string>();
                excelSheetCol.Items.Clear();

                DataTable ExcelSheetTable = new DataTable();

                // Build DataTable Columns
                for (int i = 1; i <= rowCount; i++)
                {

                    int newX = 0;
                    for (int x = 1; x <= colCount; x++)
                    {
                        if (!string.IsNullOrEmpty(rang.Cells[i, x].Text.ToString()))
                        {
                            string value = rang.Cells[i, x].Value2.ToString();

                            // Prepare Columns
                            if (i == 1)
                            {
                                projectsDictionary.Add(newX, value);
                                ExcelSheetTable.Columns.Add(value);

                                if (x == colCount)
                                {
                                    break;
                                }
                            }

                            newX++;
                        }
                    }
                }

                // Build DataTable Rows
                DataRow ExcelSheetTableRow;
                for (int i = 2; i <= rowCount; i++)
                {
                    int newX = 0;
                    ExcelSheetTableRow = ExcelSheetTable.NewRow();
                    for (int x = 1; x <= colCount; x++)
                    {
                        if (!string.IsNullOrEmpty(rang.Cells[i, x].Text.ToString()))
                        {
                            string value = rang.Cells[i, x].Value2.ToString();
                            
                            // Prepare Rows
                            ExcelSheetTableRow[newX] = value;
                             
                            if (x == colCount)
                            {
                                ExcelSheetTable.Rows.Add(ExcelSheetTableRow);
                            }

                            newX++;
                        }
                    }
                }


                foreach (KeyValuePair<int, string> res in projectsDictionary)
                {
                    excelSheetCol.Items.Add(res.Value);
                    excelSheetCol.ValueMember = res.Value.ToString();
                    excelSheetCol.DisplayMember = res.Key.ToString();
                    excelSheetCol.Tag = res.Key.ToString();
                }

                // Fill THE DATA GRIDVIEW 
                DataTable SourcesTable = new DataTable();
                SourcesTable.Columns.Add("AccountingTreeData");
                SourcesTable.Columns.Add("excelSheetCol");

                string[] AccountsData = new string[3];
                AccountsData[0] = "رقم الحساب";
                AccountsData[1] = "إسم الحساب";
                AccountsData[2] = "الحساب الرئيسى";


                for (int i = 0; i < AccountsData.Length; i++)
                {
                    int rowId = datagrid_accounts_tree_columns.Rows.Add();
                    DataGridViewRow row = datagrid_accounts_tree_columns.Rows[rowId];
                    row.Cells["AccountingTreeData"].Value = AccountsData[i];
                    row.Cells["excelSheetCol"].Value = (row.Cells["excelSheetCol"] as DataGridViewComboBoxCell).Items[0];
                }

                 this.ExcelSheetDataTable = ExcelSheetTable;

            } catch (Exception) { }


         }

        private void button8_Click(object sender, EventArgs e)
        {

            try {
                // Build Account Number Column 
                if (datagrid_accounts_tree_columns.Rows.Count == 0 && datagrid_accounts_tree_columns.Rows.Count < 3)
                {
                    return;
                }

                DataGridViewRow account_number_row = datagrid_accounts_tree_columns.Rows[0];
                DataGridViewComboBoxCell account_number_row_dc = (DataGridViewComboBoxCell)account_number_row.Cells["excelSheetCol"];
                int account_number_col_index = account_number_row_dc.Items.IndexOf(account_number_row_dc.Value);

                DataGridViewRow account_name_row = datagrid_accounts_tree_columns.Rows[1];
                DataGridViewComboBoxCell account_name_row_dc = (DataGridViewComboBoxCell)account_name_row.Cells["excelSheetCol"];
                int account_name_col_index = account_name_row_dc.Items.IndexOf(account_name_row_dc.Value);

                DataGridViewRow main_account_row = datagrid_accounts_tree_columns.Rows[2];
                DataGridViewComboBoxCell main_account_row_dc = (DataGridViewComboBoxCell)main_account_row.Cells["excelSheetCol"];
                int main_account_col_index = main_account_row_dc.Items.IndexOf(main_account_row_dc.Value);

                // Clear Current DataGridview Items 
                if (UI.FRM_AccountsGuid.GetForm.datagrid_accounts_tree.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in UI.FRM_AccountsGuid.GetForm.datagrid_accounts_tree.Rows)
                    {
                        UI.FRM_AccountsGuid.GetForm.datagrid_accounts_tree.Rows.Remove(row);
                    }
                }

                if (UI.FRM_AccountsGuid.GetForm.accounting_tree.Nodes.Count != 0) { 
                    UI.FRM_AccountsGuid.GetForm.accounting_tree.Nodes.Clear();
                }

                // Create New DataTable 
                DataTable DataTableSource = new DataTable();
                DataTableSource.Columns.Add("id");
                DataTableSource.Columns.Add("account_number");
                DataTableSource.Columns.Add("account_name");
                DataTableSource.Columns.Add("account_name_en");
                DataTableSource.Columns.Add("main_account");
                DataTableSource.Columns.Add("debit_credit");
                DataTableSource.Columns.Add("balance");
                DataTableSource.Columns.Add("is_main_account");
                DataRow dgrow;
                 
                foreach (DataRow row in this.ExcelSheetDataTable.Rows)
                {

                    // Add to Tree View 
                    UI.FRM_AccountsGuid.GetForm.Fill_Tree_View(
                        row[account_number_col_index].ToString(),
                        row[account_name_col_index].ToString(),
                        row[main_account_col_index].ToString()
                    );

                    // Add to DataTable
                    dgrow = DataTableSource.NewRow();
                    dgrow["account_number"] = row[account_number_col_index].ToString();
                    dgrow["main_account"] = row[main_account_col_index].ToString();
                    dgrow["account_name"] = row[account_name_col_index].ToString();
                    DataTableSource.Rows.Add(dgrow);
                }
                 
                // Fill DataGridView
                UI.FRM_AccountsGuid.GetForm.datagrid_accounts_tree.DataSource = DataTableSource;

                
            }
            catch (Exception) {
                MessageBox.Show("حدث خطأ من فضلك تأكد قم بملء ملف الإكسيل بشكل صحيح");
            }

            // Close
            UI.FRM_AccountsGuid.GetForm.panelWait.Visible = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Close
            this.Close();
            UI.FRM_AccountsGuid.GetForm.panelWait.Visible = false;
        }
    }
}
