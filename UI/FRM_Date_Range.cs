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
    public partial class FRM_Date_Range : Form
    {
        EntriesReportViewer Entries_Form; 
        public int SearchType = -1;

        public FRM_Date_Range()
        {
            InitializeComponent();
        }
          
        public FRM_Date_Range(EntriesReportViewer Entries ) {
            this.Entries_Form = Entries;
            this.SearchType = 0;
            InitializeComponent();
        }

        public FRM_Date_Range(int searchType )
        { 
            this.SearchType = searchType;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime from_date = Convert.ToDateTime(date_from.Value);
            DateTime to_date = Convert.ToDateTime(date_to.Value);

            // Journal Entries Data 
            if (this.SearchType == 0) {

                this.Entries_Form.rearrange_report_date(
                    from_date, to_date
                );

            } else if (this.SearchType == 1) {

                UI.Vat_Statment_Viewer nview = new UI.Vat_Statment_Viewer(from_date, to_date);
                nview.Show();
            }  

            this.Close();

        }
    }
}
