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
    public partial class FRM_Date_Range_Form : Form
    {
         
        public int SearchType = -1;
        public int document_type = -1;

        public FRM_Date_Range_Form(int document_type)
        {
            this.document_type = document_type;
            InitializeComponent();
            display_invoices_item_with.SelectedIndex = 0;
        }
         

        private void button1_Click(object sender, EventArgs e)
        {

            // Date Time Details 
            DateTime from_date = Convert.ToDateTime(date_from.Value);
            DateTime to_date = Convert.ToDateTime(date_to.Value);  
             
            // Journal Entries Data 
            UI.Report_Viewer frm = new UI.Report_Viewer(
                from_date, to_date,
                display_invoices_item_with.SelectedIndex,
                this.document_type
            );

            frm.Show();

            this.Close();

        }
    }
}
