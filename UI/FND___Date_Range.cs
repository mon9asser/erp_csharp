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
    public partial class FND___Date_Range : Form
    {
         
         
        Report Repo = new Report();
        PL.DailyEntries Entries = new PL.DailyEntries();
        PL.Installings installs = new PL.Installings();
        PL.AccountingTree __Tree = new PL.AccountingTree();

        DSet.Statments DS_Statement = new DSet.Statments();
        DSet.DailyEntries DS_Entry= new DSet.DailyEntries();

        DataTable Accounts;
        DataTable Settings;
        DataSet dstables;
        DataTable All_Entries;
        DataTable All_Row_Entries;

        public int SearchType = -1;

        public FND___Date_Range()
        {
            InitializeComponent();
        }
        

        public FND___Date_Range(int searchType )
        { 
            this.SearchType = searchType;  
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from_date = Convert.ToDateTime(date_from.Value);
                DateTime to_date = Convert.ToDateTime(date_to.Value);

                // Journal Entries Data 
                if (this.SearchType == 0)
                {

                    this.Load_Entries_Statment_Report(from_date, to_date);

                }
                else if (this.SearchType == 1)
                {

                    this.Load_Zakat_Statment_Report(from_date, to_date);

                } else if (this.SearchType == 2) {

                    this.Load_goods_Withdraw_Report(from_date, to_date);
                }

                this.Close();
            }
            catch (Exception) { }

        }



        /**
         * ===============================================================================
         * Withdraw Report 
         * ===============================================================================
         * 
         **/
        public void Load_goods_Withdraw_Report(DateTime from_date_var, DateTime to_date_var ) {
            try
            {

                DataSet dset = Entries.Get_Withdraw_Report_DataSet(from_date_var, to_date_var);

                DataTable 

            }
            catch (Exception) {

            }
        }

        /**
         * ===============================================================================
         * Entries Statement 
         * ===============================================================================
         * 
         **/
        public void Load_Entries_Statment_Report( DateTime from_date_var, DateTime to_date_var ) {

            try {

                this.DS_Entry.Tables["Dates"].Rows.Clear();
                this.DS_Entry.Tables["Journals"].Rows.Clear();

                this.All_Entries = this.Entries.Get_All_Journals_By_Date(from_date_var, to_date_var);
                this.All_Entries.Columns.Remove("parent_account");
                this.All_Entries.Columns.Remove("balance");
                this.All_Entries.Columns.Remove("debit_credit");
                this.All_Entries.Columns.Remove("main_account");
                this.All_Entries.Columns.Remove("account_number1");
                this.All_Entries.Columns.Remove("id2");
                this.All_Entries.Columns.Remove("is_main_account");
                this.DS_Entry.Tables["Journals"].Merge(this.All_Entries);

                string from_date_var_string = from_date_var.ToString("yyyy-MM-dd");
                string to_date_var_string = to_date_var.ToString("yyyy-MM-dd");

                this.Fill_Target_Dates(from_date_var_string, to_date_var_string);

                // Load Fast Report  
                UI.FND___Viewer viewer = new UI.FND___Viewer(
                    "\\FReports\\Journal_Entry_Report.frx",
                    this.DS_Entry,
                    "journals_statment",
                    "قيود اليومية عن الفترة"
                );
                viewer.Show();

            } catch (Exception) { }

        }


        public void Fill_Target_Dates(string from, string to)
        {
            try {

                this.DS_Entry.Tables["Dates"].Rows.Clear();
                DataRow datewRow = this.DS_Entry.Tables["Dates"].NewRow();
                datewRow["from_date"] = from;
                datewRow["to_date"] = to;
                this.DS_Entry.Tables["Dates"].Rows.Add(datewRow);

            } catch (Exception) { }
        }

        
        /**
         * ===============================================================================
         * Zakat Statment Report 
         * ===============================================================================
         * 
         **/
        public void Load_Zakat_Statment_Report( DateTime from_date_var, DateTime to_date_var) {

            // Some Givens 
            try {

                this.Accounts = this.__Tree.Get_Accounting_Tree();
                this.Settings = this.installs.Get_All_System_Settings();


                string account_name_1 = "";
                string account_number_1 = "";
                string account_name_2 = "";
                string account_number_2 = "";

                if (this.Settings.Rows.Count != 0)
                {

                    DataRow Options = this.Settings.Rows[0];

                    account_number_1 = Options["sales_vat_account"].ToString();
                    account_name_1 = this.Extract_Account_Name(account_number_1);

                    account_number_2 = Options["purchases_vat_account"].ToString();
                    if (account_number_2 == account_number_1)
                    {
                        account_number_2 = "-1";
                    }

                    account_name_2 = this.Extract_Account_Name(account_number_2);
                }
                this.dstables = Entries.Get_Report_Statment(account_number_1, from_date_var, to_date_var, account_number_2);

                // Build Query Data 
                DataRow baccd = this.DS_Statement.Tables["Query_Data"].NewRow();
                baccd["account_number_1"] = account_number_1;
                baccd["account_name_1"] = account_name_1;
                baccd["account_number_2"] = account_number_2;
                baccd["account_name_2"] = account_name_2;
                baccd["date_from"] = from_date_var;
                baccd["date_to"] = to_date_var;
                baccd["report_title"] = "كشف حركة ضريبة القيمة المضافة";
                this.DS_Statement.Tables["Query_Data"].Rows.Add(baccd);
                 
                // Build Statments And Queries 
                this.DS_Statement.Tables["Statement"].Merge(this.dstables.Tables[0]);
                this.DS_Statement.Tables["Totals"].Merge(this.dstables.Tables[1]);

                // Load Fast Report  
                UI.FND___Viewer viewer = new UI.FND___Viewer(
                    "\\FReports\\Zakat_Statement.frx",
                    this.DS_Statement,
                    "statements_dataset",
                    this.DS_Statement.Tables["Query_Data"].Rows[0]["report_title"].ToString()
                );
                viewer.Show();
            } catch (Exception) { }
        }

        public string Extract_Account_Name(string account_number)
        {
            string name = "";

            try {
                foreach (DataRow row in this.Accounts.Rows)
                {
                    if (row["account_number"].ToString().Equals(account_number.ToString()))
                    {
                        name = row["account_name"].ToString();
                        Console.WriteLine(name);
                        break;
                    }
                }
            } catch (Exception) { }

            return name;
        }


    }
}
