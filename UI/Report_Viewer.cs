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
    public partial class Report_Viewer : Form
    {
        DateTime date_from;
        DateTime date_to;

        PL.DailyEntries proccess = new PL.DailyEntries();
        DSet.ReportSources DSources = new DSet.ReportSources();
        DataSet DataSources = new DataSet();
        DataTable ReportTable;
        DataTable TotalTable;
        public Report_Viewer(DateTime from, DateTime to, int isEnabledVat, int document_type )
        {
            // select * from invoice_purchases where [date] >= '2022/05/07 00:00:00' and [date] <= '2022/05/07 23:59:59';
            this.date_from = from;
            this.date_to = to;

            DataSet tables = proccess.Search_On_Process_Reports(from, to, isEnabledVat );
            
            this.ReportTable = tables.Tables[document_type];
            this.TotalTable = tables.Tables[document_type + 4];/* total - vat_amount - dicount_amount */
             
            DataSources.Tables.Add(TotalTable); --

            InitializeComponent();
             

            // Load Reports  
            Console.WriteLine("Table Rows Count : "+this.ReportTable.Rows.Count);

        }
    }
}
