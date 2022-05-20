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
    public partial class FND____Date_Range_Form : Form
    {

        PL.DailyEntries proccess = new PL.DailyEntries();
        DSet.ReportSources DSources = new DSet.ReportSources();


        DataTable ReportTable;
        DataTable TotalTable;

        public int SearchType = -1;
        public int document_type = -1;

        public FND____Date_Range_Form(int document_type)
        {
            this.document_type = document_type;
            InitializeComponent();
            display_invoices_item_with.SelectedIndex = 2;
        }
         

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Date Time Details 
                DateTime from_date = Convert.ToDateTime(date_from.Value);
                DateTime to_date = Convert.ToDateTime(date_to.Value);


                DataSet tables = proccess.Search_On_Process_Reports(from_date, to_date, display_invoices_item_with.SelectedIndex);

                this.ReportTable = tables.Tables[document_type];
                this.ReportTable.TableName = "Sources";

                this.TotalTable = tables.Tables[document_type + 4];/* total - vat_amount - dicount_amount */
                this.TotalTable.TableName = "Totals";

                // Build Date and title of report 
                this.DSources.Tables["Details"].Rows.Clear();
                DataRow DetailsRow = this.DSources.Tables["Details"].NewRow();
                DetailsRow["date_from"] = from_date.ToString("yyyy-MM-dd");
                DetailsRow["date_to"] = to_date.ToString("yyyy-MM-dd");
                DetailsRow["title"] = "تقرير المبيعات عن الفترة";
                if (document_type == 1)
                {
                    DetailsRow["title"] = "تقرير المشتريات عن الفترة";
                }
                else if (document_type == 2)
                {
                    DetailsRow["title"] = "تقرير مردود المبيعات عن الفترة";
                }
                else if (document_type == 3)
                {
                    DetailsRow["title"] = "تقرير مردود المشتريات عن الفترة";
                }

                this.DSources.Tables["Details"].Rows.Add(DetailsRow);

                this.DSources.Merge(this.TotalTable);
                this.DSources.Merge(this.ReportTable);


                UI.Viewer viewer = new UI.Viewer(
                    "\\FReports\\Report_Sources.frx",
                    this.DSources,
                    "reportSources1",
                    this.DSources.Tables["Details"].Rows[0]["title"].ToString()
                );
                viewer.Show();

                // Journal Entries Data 

                /*
                UI.Report_Viewer frm = new UI.Report_Viewer(
                    from_date, to_date,
                    display_invoices_item_with.SelectedIndex,
                    this.document_type
                );
                frm.Show();
                */
                this.Close();
            }
            catch (Exception) { }

        }


    }
}
