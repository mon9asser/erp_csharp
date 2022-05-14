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
    public partial class Vat_Statment_Viewer : Form
    {
        DateTime date_from;
        DateTime date_to;
        PL.Installings installs = new PL.Installings();
        PL.DailyEntries Entries = new PL.DailyEntries();
        DataSet dstables;
        DataTable Settings;

        public Vat_Statment_Viewer(DateTime date_from, DateTime date_to)
        {
            
            this.date_from = date_from;
            this.date_to = date_to;
            this.Settings = this.installs.Get_All_System_Settings();
            
            InitializeComponent();

            if (this.Settings.Rows.Count == 0) {
                return;
            }

            DataRow row = this.Settings.Rows[0];
            string sale_vat = row["sales_vat_account"].ToString();
            string purchase_vat = row["purchases_vat_account"].ToString();


            string account_1 = sale_vat;
            string account_2 = sale_vat == purchase_vat ? "-1": purchase_vat;

            this.dstables = Entries.Get_Report_Statment(account_1, date_from, date_to, account_2 );

            DataTable statments = this.dstables.Tables[0];
            DataTable first_balance = this.dstables.Tables[1];
            DataTable totals = this.dstables.Tables[2];

            foreach ( DataRow ros in statments.Rows ) {
                foreach (DataColumn col in statments.Columns)
                {
                    Console.WriteLine(col + " : " + ros[col]);
                }
                Console.WriteLine("==============================================");
            }

            foreach (DataRow ros in first_balance.Rows)
            {
                foreach (DataColumn col in first_balance.Columns)
                {
                    Console.WriteLine(col + " : " + ros[col]);
                }
                Console.WriteLine("==============================================");
            }

            foreach (DataRow ros in totals.Rows)
            {
                foreach (DataColumn col in totals.Columns)
                {
                    Console.WriteLine(col + " : " + ros[col]);
                }
                Console.WriteLine("==============================================");
            }
        }


    }
}
