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
    public partial class EntriesReportViewer : Form
    {
        ReportDocument cryRpt = new ReportDocument();
        DSet.DailyEntries CRT_DataSet = new DSet.DailyEntries();
        PL.DailyEntries EntryAPI = new PL.DailyEntries();
        public EntriesReportViewer DailyEntriesReport;

        DataTable All_Entries;
        DataTable All_Row_Entries; 

        public EntriesReportViewer()
        {

            this.All_Entries = EntryAPI.Get_All_Entries();
            this.All_Row_Entries = EntryAPI.Get_All_Row_Entries();
            this.DailyEntriesReport = this;

            InitializeComponent();

            string path = Application.StartupPath + "\\Reports\\Daily_Entries.rpt";
            this.cryRpt.Load(path);

            this.Load_Entry_Crystal_Report();
        }

        public void reload_crystal_report_document() {
            this.cryRpt.SetDataSource(this.CRT_DataSet);
            this.cryRpt.Refresh();
            crystalReportViewer1.ReportSource = this.cryRpt;
        }

        public void Fill_Entry_data_In_Period(string from, string to) {

            this.CRT_DataSet.Tables["Journals"].Rows.Clear();
            this.CRT_DataSet.Tables["Entries"].Rows.Clear();

            var date_from = Convert.ToDateTime(from).ToString("yyyy-MM-dd");
            var date_to = Convert.ToDateTime(to).ToString("yyyy-MM-dd");
            DateTime timeDateField = DateTime.Now;

            foreach (DataRow row in this.All_Entries.Rows)
            {
                var date_db_string = Convert.ToDateTime(row["updated_date"]).ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(date_db_string) >= Convert.ToDateTime(date_from) && Convert.ToDateTime(date_db_string) <= Convert.ToDateTime(date_to))
                {
                    timeDateField = Convert.ToDateTime(row["updated_date"]);
                    DataRow rowJournals = this.CRT_DataSet.Tables["Journals"].NewRow();
                    rowJournals["id"] = row["id"].ToString();
                    rowJournals["description"] = row["description"].ToString();
                    rowJournals["entry_number"] = row["entry_number"].ToString();
                    rowJournals["updated_date"] = Convert.ToDateTime(row["updated_date"]);
                    rowJournals["doc_id"] = row["doc_id"].ToString();
                    rowJournals["doc_type"] = row["doc_type"].ToString();
                    this.CRT_DataSet.Tables["Journals"].Rows.Add(rowJournals);
                }
            }

            foreach (DataRow row in this.All_Row_Entries.Rows)
            {
                DataRow rowEntries = this.CRT_DataSet.Tables["Entries"].NewRow();
                rowEntries["journal_id"] = row["journal_id"].ToString();

                rowEntries["debit"] = row["debit"].ToString();
                if (rowEntries["debit"].ToString() != "")
                {
                    rowEntries["debit"] = string.Format("{0:n}", Convert.ToDecimal(rowEntries["debit"])).ToString();
                }

                rowEntries["credit"] = row["credit"].ToString();
                if (rowEntries["credit"].ToString() != "")
                {
                    rowEntries["credit"] = string.Format("{0:n}", Convert.ToDecimal(rowEntries["credit"])).ToString();
                }

                if (row["date"] != System.DBNull.Value)
                {
                    rowEntries["date"] = Convert.ToDateTime(row["date"]).ToString("yyyy-MM-dd");
                }
                else {
                    rowEntries["date"] = timeDateField.ToString("yyyy-MM-dd"); ;
                }

                rowEntries["description"] = row["description"].ToString();
                rowEntries["account_number"] = row["account_number"].ToString();
                rowEntries["account_name"] = "";
                if (row["debit"].ToString() != "")
                {
                    rowEntries["account_name"] += "من ح /  ";
                }
                else
                {
                    rowEntries["account_name"] += "إالى ح /  ";
                }
                rowEntries["account_name"] += row["account_name"].ToString();

                if (row["debit"].ToString() == "")
                {
                    rowEntries["account_name"] += "       .";
                }

                this.CRT_DataSet.Tables["Entries"].Rows.Add(rowEntries);
            }

        }

        public void Fill_Target_Dates(string from, string to)
        {
            this.CRT_DataSet.Tables["Dates"].Rows.Clear();
            DataRow datewRow = this.CRT_DataSet.Tables["Dates"].NewRow();
            datewRow["from_date"] = from;
            datewRow["to_date"] = to;
            this.CRT_DataSet.Tables["Dates"].Rows.Add(datewRow);
        }

        public void Load_Entry_Crystal_Report()
        {

            string from = DateTime.Now.ToString("yyyy-MM-dd");
            string to = DateTime.Now.ToString("yyyy-MM-dd");

            this.Fill_Entry_data_In_Period(from, to);
            this.Fill_Target_Dates(from, to);
            this.reload_crystal_report_document();
        }

        public void rearrange_report_date(DateTime from_dte, DateTime to_dte)
        {
            this.CRT_DataSet.Tables["Entries"].Rows.Clear();
            this.CRT_DataSet.Tables["Dates"].Rows.Clear();
            this.CRT_DataSet.Tables["Journals"].Rows.Clear();

            string from = from_dte.ToString("yyyy-MM-dd");
            string to = to_dte.ToString("yyyy-MM-dd");

            this.Fill_Entry_data_In_Period(from, to);
            this.Fill_Target_Dates(from, to);
            this.reload_crystal_report_document();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            UI.FRM_Date_Range date_frm = new UI.FRM_Date_Range(
                DailyEntriesReport
            );

            date_frm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.cryRpt.PrintToPrinter(1, false, 0, 0);
        }
    }
}
