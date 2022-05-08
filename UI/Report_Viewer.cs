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
    public partial class Report_Viewer : Form
    {
         

        PL.DailyEntries proccess = new PL.DailyEntries();
        DSet.ReportSources DSources = new DSet.ReportSources();
         

        DataTable ReportTable;
        DataTable TotalTable;

        ReportDocument cryRpt = new ReportDocument();

        public Report_Viewer(DateTime from, DateTime to, int isEnabledVat, int document_type)
        {

            InitializeComponent();

            DataSet tables = proccess.Search_On_Process_Reports(from, to, isEnabledVat);

            this.ReportTable = tables.Tables[document_type];
            this.ReportTable.TableName = "Sources";

            this.TotalTable = tables.Tables[document_type + 4];/* total - vat_amount - dicount_amount */
            this.TotalTable.TableName = "Totals";

            // Build Date and title of report 
            this.DSources.Tables["Details"].Rows.Clear();
            DataRow DetailsRow = this.DSources.Tables["Details"].NewRow();
            DetailsRow["date_from"] = from.ToString("yyyy-MM-dd");
            DetailsRow["date_to"] = to.ToString("yyyy-MM-dd");
            DetailsRow["title"] = "تقرير المبيعات عن الفترة";
            if (document_type == 1)
            {
                DetailsRow["title"] = "تقرير المشتريات عن الفترة";
            }
            else if (document_type == 2)
            {
                DetailsRow["title"] = "تقرير مردود المبيعات عن الفترة";
            }
            else if (document_type == 3) {
                DetailsRow["title"] = "تقرير مردود المشتريات عن الفترة";
            } 

            this.DSources.Tables["Details"].Rows.Add(DetailsRow);

            this.DSources.Merge(this.TotalTable);
            this.DSources.Merge(this.ReportTable);
              

            // Load Reports   
            string path = Application.StartupPath + "\\Reports\\ReportSources.rpt";
            this.cryRpt.Load(path);

            this.cryRpt.SetDataSource(this.DSources);
            crystalReportViewer1.ReportSource = this.cryRpt; 

        }
    }
}
