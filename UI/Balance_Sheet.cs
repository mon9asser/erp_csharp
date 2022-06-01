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

        DSet.Balance_Sheet BalanceSheet = new DSet.Balance_Sheet();
        PL.DailyEntries Entry = new PL.DailyEntries();
        Report Repo = new Report();

        public Balance_Sheet()
        {
            InitializeComponent();

            DataSet dstbls = Entry.Get_Balance_Sheet();

            DataTable current_assets = dstbls.Tables[0];
            DataTable current_assets_totals = dstbls.Tables[1];

            DataTable none_current_assets = dstbls.Tables[2];
            DataTable none_current_assets_totals = dstbls.Tables[3];

            DataTable current_liabilities = dstbls.Tables[4];
            DataTable current_liabilities_totals = dstbls.Tables[5];

            DataTable none_current_liabilities = dstbls.Tables[6];
            DataTable none_current_liabilities_total = dstbls.Tables[7];

            DataTable owner_equity = dstbls.Tables[8];
            DataTable owner_equity_title = dstbls.Tables[9];

            BalanceSheet.Tables["current_assets"].Merge(current_assets);
            BalanceSheet.Tables["current_assets_totals"].Merge(current_assets_totals);
            BalanceSheet.Tables["none_current_assets"].Merge(none_current_assets);
            BalanceSheet.Tables["none_current_assets_totals"].Merge(none_current_assets_totals);
            BalanceSheet.Tables["current_liabilities"].Merge(current_liabilities);
            BalanceSheet.Tables["current_liabilities_totals"].Merge(current_liabilities_totals);
            BalanceSheet.Tables["none_current_liabilities"].Merge(none_current_liabilities);
            BalanceSheet.Tables["none_current_liabilities_total"].Merge(none_current_liabilities_total);
            BalanceSheet.Tables["owner_equity"].Merge(owner_equity);
            BalanceSheet.Tables["owner_equity_title"].Merge(owner_equity_title); 
              
            this.Repo.RegisterData(this.BalanceSheet, "balance_Sheet1");
            this.Repo.Load(Application.StartupPath + "\\FReports\\Balanace_Sheet_Statement.frx");
            this.Repo.Preview = this.previewControl1;
            this.Repo.Show();

        }


    }
}
