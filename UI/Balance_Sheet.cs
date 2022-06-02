using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;

namespace sales_management.UI
{
    
    public partial class Balance_Sheet : Form
    {

        DSet.Balance_Sheet_ BalanceSheet = new DSet.Balance_Sheet_();
        PL.DailyEntries Entry = new PL.DailyEntries();
        Report Repo = new Report();

        public Balance_Sheet()
        {
            InitializeComponent();

            DataSet dstbls = Entry.Get_Balance_Sheet();
             
            
            DataTable current_assets = dstbls.Tables[0];
            DataTable fixed_assets = dstbls.Tables[1];
            DataTable current_liabilities = dstbls.Tables[2];
            DataTable long_liabilities = dstbls.Tables[3];
            DataTable owner_equity = dstbls.Tables[4];
            DataTable balance_sheet_totals = dstbls.Tables[5];

            foreach (DataColumn colx in long_liabilities.Columns) {
                foreach (DataRow rowx in long_liabilities.Rows)
                {
                    Console.WriteLine(colx.ColumnName.ToString() + " : " + rowx[colx.ColumnName.ToString()] );
                }
            }

           
            BalanceSheet.Tables["current_assets"].Merge(current_assets);
            BalanceSheet.Tables["fixed_assets"].Merge(fixed_assets);
            BalanceSheet.Tables["current_liabilities"].Merge(current_liabilities);
            BalanceSheet.Tables["long_liabilities"].Merge(long_liabilities);
            BalanceSheet.Tables["owner_equity"].Merge(owner_equity);
            BalanceSheet.Tables["balance_sheet_totals"].Merge(balance_sheet_totals);
             
            this.Repo.RegisterData(this.BalanceSheet, "balance_ssheet_dataset");
            this.Repo.Load(Application.StartupPath + "\\FReports\\Balanace_Sheet_Statement.frx");
            this.Repo.Preview = this.previewControl1;
            this.Repo.Show();

        }


    }
}
