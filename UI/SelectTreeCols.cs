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

            int rowCount = rang.Rows.Count;
            int colCount = rang.Columns.Count;

            Dictionary<int, string> projectsDictionary = new Dictionary<int, string>();
            excelSheetCol.Items.Clear();

            DataTable ExcelSheetTable = new DataTable(); 

            // Build DataTable Columns
            for (int i = 1; i <= rowCount; i++)
            {

                int newX = 0;
                for (int x = 1; x <= colCount; x++) {
                    if (!string.IsNullOrEmpty(rang.Cells[i, x].Text.ToString()))
                    {
                        string value = rang.Cells[i, x].Value2.ToString();
                         
                        // Prepare Columns
                        if (i == 1) {
                            projectsDictionary.Add(newX, value);
                            ExcelSheetTable.Columns.Add(value);

                            if (x == colCount) {
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

                        if (x == colCount) {
                          ExcelSheetTable.Rows.Add(ExcelSheetTableRow);
                        }

                        newX++;
                    }
                }
            }


            foreach (KeyValuePair<int, string> res in projectsDictionary)
            {
                excelSheetCol.Items.Add(res.Value);
                excelSheetCol.ValueMember = res.Key.ToString();
                excelSheetCol.DisplayMember = res.Value.ToString();
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

            
            for (int i = 0; i < AccountsData.Length; i++) {
                int rowId = datagrid_accounts_tree_columns.Rows.Add();
                DataGridViewRow row = datagrid_accounts_tree_columns.Rows[rowId];
                row.Cells["AccountingTreeData"].Value = AccountsData[i];
                row.Cells["excelSheetCol"].Value = (row.Cells["excelSheetCol"] as DataGridViewComboBoxCell).Items[0];
            }

            this.ExcelSheetDataTable = ExcelSheetTable;


         }

        private void button8_Click(object sender, EventArgs e)
        {

            // Build Account Number Column 
            if(datagrid_accounts_tree_columns.Rows.Count == 0 && datagrid_accounts_tree_columns.Rows.Count < 3 ) {
                return;
            }

            DataGridViewRow account_number_row  = datagrid_accounts_tree_columns.Rows[0];

            MessageBox.Show((account_number_row.Cells["excelSheetCol"] as DataGridViewComboBoxCell).Tag.ToString()); 


        }
    }
}
