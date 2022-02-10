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
    public partial class Purchase : Form
    {

        PL.Invoice Invoice = new PL.Invoice();
        //DataTable[] tables;

        public Purchase()
        {
            InitializeComponent();
            //tables = Invoice.Load_Invoice_Data(1);
            //this.Load_Invoice_Data(table);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            
            
            if (invoice_number.Text == "") {
                invoice_number.Text = "-1";
            }

            DataTable table = Invoice.Create_Invoice_Id(1, Convert.ToInt32(invoice_number.Text) );
            this.Load_Invoice_Data(table);
            this.enable_invoice_element(false);

        }

        public void Load_Invoice_Data( DataTable table ) {

            if (table.Rows.Count != 0) { 
                DataRow row = table.Rows[0];
                invoice_number.Text = row["id"].ToString();
            }
        }

        public void enable_invoice_element( bool isDisabled ) {

            details.Enabled = !isDisabled;
            payment_methods.Enabled = !isDisabled;
            enable_vat.Enabled = !isDisabled;
            invoice_number.Enabled = !isDisabled;
            datemade.Enabled = !isDisabled;
            invoice_detail_datagridview.Enabled = !isDisabled;
            total_without_vat.Enabled = !isDisabled;
            discount.Enabled = !isDisabled;
            vat_amount.Enabled = !isDisabled;
            total_with_vat.Enabled = !isDisabled;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.enable_invoice_element(true);
        }

        private void show_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            invoice_detail_datagridview.DataSource = Invoice.Get_Invoice_Details(Convert.ToInt32(invoice_number.Text));
        }
    }
}
