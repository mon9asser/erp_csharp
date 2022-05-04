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

        public FRM_Date_Range()
        {
            InitializeComponent();
        }

        public FRM_Date_Range(EntriesReportViewer Entries ) {
            this.Entries_Form = Entries;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Entries_Form.rearrange_report_date(
                  Convert.ToDateTime(date_from.Value),
                  Convert.ToDateTime(date_to.Value)
              );

            this.Close();
        }
    }
}
