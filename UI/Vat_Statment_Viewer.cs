using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace sales_management.UI
{
    public partial class Vat_Statment_Viewer : Form
    {
        PL.DailyEntries Entries = new PL.DailyEntries();
        PL.Installings installs = new PL.Installings();
        PL.AccountingTree __Tree = new PL.AccountingTree();
        DSet.Statments DSet = new DSet.Statments();

        DataTable Accounts;
        DataTable Settings;
        DataSet dstables;

        ReportDocument cryRpt = new ReportDocument();

        public Vat_Statment_Viewer(DateTime date_from, DateTime date_to) {

            // Some Givens 
            this.Accounts   = this.__Tree.Get_Accounting_Tree();
            this.Settings   = this.installs.Get_All_System_Settings();
             

            string account_name_1 = "";
            string account_number_1 = "";
            string account_name_2= "";
            string account_number_2 = "";

            if ( this.Settings.Rows.Count != 0 ) {

                DataRow Options = this.Settings.Rows[0];

                account_number_1 = Options["sales_vat_account"].ToString();
                account_name_1 = this.Extract_Account_Name(account_number_1);

                account_number_2 = Options["purchases_vat_account"].ToString();
                if (account_number_2 == account_number_1) {
                    account_number_2 = "-1";
                }

                account_name_2 = this.Extract_Account_Name(account_number_2); 
            }
            this.dstables = Entries.Get_Report_Statment(account_number_1, date_from, date_to, account_number_2);

            InitializeComponent();


            // Build Query Data 
            DataRow baccd = DSet.Tables["Query_Data"].NewRow();
            baccd["account_number_1"] = account_number_1;
            baccd["account_name_1"] = account_name_1;
            baccd["account_number_2"] = account_number_2;
            baccd["account_name_2"] = account_name_2;
            baccd["date_from"] = date_from;
            baccd["date_to"] = date_to;
            baccd["report_title"] = "هيئة الزكاة والضريبة عن الفترة";
            DSet.Tables["Query_Data"].Rows.Add(baccd);

            // Build Statments And Queries 
            DSet.Tables["Statement"].Merge(this.dstables.Tables[0]);
            DSet.Tables["Totals"].Merge(this.dstables.Tables[1]);

            // Fill Statement Data 
            string path = Application.StartupPath + "\\Reports\\Statement.rpt";
            this.cryRpt.Load(path);
            this.cryRpt.SetDataSource(this.DSet);
            this.cryRpt.Refresh();
            crystalReportViewer1.ReportSource = this.cryRpt;

        }

        public string Extract_Account_Name(string account_number)
        {
            string name = "";

            foreach (DataRow row in this.Accounts.Rows)
            {
                if (row["account_number"].ToString().Equals(account_number.ToString()))
                {
                    name = row["account_name"].ToString();
                    Console.WriteLine(name);
                    break;
                }
            }

            return name;
        }
    }
}
