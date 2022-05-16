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
        DateTime date_from;
        DateTime date_to;
        PL.Installings installs = new PL.Installings();
        PL.DailyEntries Entries = new PL.DailyEntries();
        PL.AccountingTree __Tree = new PL.AccountingTree();
        DataTable Accounts;
        DSet.Statments DSet = new DSet.Statments();
        DataSet dstables;
        DataTable Settings;
        ReportDocument cryRpt = new ReportDocument();

        public Vat_Statment_Viewer(DateTime date_from, DateTime date_to)
        {

            this.date_from = date_from;
            this.date_to = date_to;
            this.Settings = this.installs.Get_All_System_Settings();
            this.Accounts = this.__Tree.Get_Accounting_Tree();

            DataRow row = this.Settings.Rows[0];
            string sale_vat = row["sales_vat_account"].ToString();
            string purchase_vat = row["purchases_vat_account"].ToString();

            string account_1 = sale_vat;
            string account_2 = sale_vat == purchase_vat ? "-1" : purchase_vat;
             
            string account_1_name = this.Extract_Account_Name(account_1);
            string account_2_name = this.Extract_Account_Name(account_2);

            InitializeComponent();

            if (this.Settings.Rows.Count == 0)
            {
                return;
            }
             
            this.dstables = Entries.Get_Report_Statment(account_1, date_from, date_to, account_2);

            DataTable statments = this.dstables.Tables[0];
            DataTable first_balance = this.dstables.Tables[1];
            DataTable totals = this.dstables.Tables[2];

            if (statments.Rows.Count == 0) {
                return;
            }

            // First Balance
            DataTable define_first_balance = new DataTable();
            define_first_balance.Columns.Add("balance_title");
            define_first_balance.Columns.Add("balance_value");
            define_first_balance.Columns.Add("date");
            DataRow define_first_balance_row = define_first_balance.NewRow();
            define_first_balance_row["balance_title"] = "رصيد أول المدة";

            if (first_balance.Rows.Count == 0)
            {
                define_first_balance_row["balance_value"] = "0.00";
                define_first_balance_row["date"] = date_from.ToString("yyyy-MM-dd");
            }
            else
            {
                define_first_balance_row["balance_value"] = first_balance.Rows[first_balance.Rows.Count - 1]["balance"];
                define_first_balance_row["date"] = Convert.ToDateTime(first_balance.Rows[first_balance.Rows.Count - 1]["date"]).ToString("yyyy-MM-dd");
            }
            define_first_balance.Rows.Add(define_first_balance_row);

            // Totals 
            DataTable define_totals = new DataTable();
            define_totals.Columns.Add("debit");
            define_totals.Columns.Add("credit");
            define_totals.Columns.Add("balance");
            DataRow define_totals_row = define_totals.NewRow();
            if (totals.Rows.Count == 0)
            {
                define_totals_row["debit"] = "0.00";
                define_totals_row["credit"] = "0.00";
                define_totals_row["balance"] = "0.00";
            }
            else
            {
                define_totals_row["debit"] = totals.Rows[0]["debit"];
                define_totals_row["credit"] = totals.Rows[0]["credit"];
                define_totals_row["balance"] = statments.Rows[statments.Rows.Count - 1]["balance"];
            }
            define_totals.Rows.Add(define_totals_row);

            
            // Add Account Details    
            DataRow AccRow = DSet.Tables["Account_Details"].NewRow();
            AccRow["account_number_1"] = account_1;
            AccRow["account_name_1"] = account_1_name;
            AccRow["account_number_2"] = "";
            AccRow["account_name_2"] = "";
            
            if (account_2 != "-1") {
                AccRow["account_number_2"] = account_2;
                AccRow["account_name_2"] = account_2_name;
            }

            DSet.Tables["Account_Details"].Rows.Add(AccRow);
             
            DSet.Tables["Statement"].Merge(statments);
            DSet.Tables["First_Balance"].Merge(define_first_balance);
            DSet.Tables["Totals"].Merge(define_totals);

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
             
            foreach ( DataRow row in this.Accounts.Rows )
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
