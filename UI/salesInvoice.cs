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
    public partial class salesInvoice : Form
    {
        PL.Sales Sales = new PL.Sales();
        DataTable Sales_Table;
        DataTable Sales_Details;

        public int documentType = 0; // Sales Invoice
        public int currentInvoiceRowIndex = -1;

        public salesInvoice()
        {
            InitializeComponent();
              
            // Head Sales Invoices 
            this.Sales_Table = Sales.Get_All_Sales_Invoices();
            this.Sales_Details = Sales.Get_All_Sales_Invoice_Details();
             
            // Load Default Data 
            if (0 != this.Sales_Table.Rows.Count) {
                this.currentInvoiceRowIndex = this.Sales_Table.Rows.Count - 1;
                DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
                this.Fill_Invoice_Fields(rw);
            }

            int id = this.Sales_Table.Rows.Count == 0 ? Convert.ToInt32(this.Sales_Table.Rows[this.Sales_Table.Rows.Count - 1]["id"]) : -1;
            items_datagridview.DataSource = Sales.Get_Sales_Invoice_Items(0, id);

            //table.Columns["product_code"].Count;
            items_datagridview.Columns["id"].Visible = false;
            items_datagridview.Columns["doc_id"].Visible = false;
            items_datagridview.Columns["doc_type"].Visible = false;
            items_datagridview.Columns["product_id"].Visible = false;
            items_datagridview.Columns["unit_id"].Visible = false;
            items_datagridview.Columns["factor"].Visible = false;
            items_datagridview.Columns["total_quantity"].Visible = false;
            items_datagridview.Columns["datagrid_id"].Visible = false;
            items_datagridview.Columns["is_out"].Visible = false;

            // Load Current Invoice Index 
            this.Set_Invoice_Row_Page_Index();

            //items_datagridview.Columns["product_code"].
            items_datagridview.Columns[1].Width = 330;
            items_datagridview.ColumnHeadersHeight = 40;
            //items_datagridview.Columns["deletion_btn"].DisplayIndex = items_datagridview.Columns.Count - 1;
            //items_datagridview.Columns["unit_name"].ColumnName = "اسم الوحدة";
            //items_datagridview.Columns["quantity"].ColumnName = "الكميات";
            //items_datagridview.Columns["total_price"].ColumnName = "إجمالي السعر";
            //items_datagridview.Columns["unit_price"].ColumnName = "سعر الوحدة";

            // Add Columns for icon to datagrid view 

        }
    

        public void Set_Invoice_Row_Page_Index() {

            int current = this.currentInvoiceRowIndex + 1;
            int counts = this.Sales_Table.Rows.Count;

            current_invoice_page.Text = current  + " / " + counts;
        }

        private void salesInvoice_Load(object sender, EventArgs e)
        {
            
        }

        public void disable( bool isDisable = true ) { 
            
        }

        private void add_new_button_Click(object sender, EventArgs e)
        {

            int id = -1;
            if (invoice_id.Text != "") {
                id = Convert.ToInt32(invoice_id.Text);
            }

            // Create New Invoice ID 
            DataTable table = Sales.Create_Sales_Invoice_Id(id);

            if ( table.Rows.Count > 0) {
                this.Fill_Invoice_Fields(table.Rows[0] );
            }
        }
 

        public void Fill_Invoice_Fields( DataRow row ) {
            
            int invoiceType = this.documentType;

            invoice_id.Text     = row["id"].ToString();
            invoice_serial.Text = row["serial"].ToString();
            datemade.Text = row["date"].ToString();
            payment_methods.Text = row["payment_method"].ToString();
            details.Text = row["details"].ToString();
            //payment_condition.SelectedIndex = Convert.ToInt32(row["payment_condition_id"]);
            customer_id.Text = row["customer_id"].ToString();
            customer_name.Text = row["customer_name"].ToString();

            legend_id.Text = row["account_id"].ToString();
            legend_number.Text = row["account_number"].ToString();
            legend_name.Text = row["account_name"].ToString();
            cost_center_number.Text = row["cost_center_number"].ToString();
            cost_center_id.Text = row["cost_center_id"].ToString();

            net_total.Text = row["net_total"].ToString();
            discount_value.Text = row["discount_name"].ToString();
            dicount_percentage.Text = row["discount_percentage"].ToString();
            discount_not_more_than.Text = row["discount_not_more"].ToString();
            total_without_vat.Text = row["total_without_vat"].ToString();
            price_includ_vat.Checked = Convert.ToBoolean(row["price_include_vat"]);
            vat_amount.Text = row["vat_amount"].ToString();
            total.Text = row["total_with_vat"].ToString();
            total_label_text.Text = string.Format("{0:n}", Convert.ToDecimal(row["total_with_vat"])).ToString();

            

        }

        private DataTable Get_All_Invoice_Items( int invoiceId ) {
            
            DataTable table = new DataTable();

            // Copy Column From Main Table 
            table.Columns.Add("id");
            table.Columns.Add("doc_id");
            table.Columns.Add("doc_type");
            table.Columns.Add("product_id");
            table.Columns.Add("product_name");
            table.Columns.Add("unit_id");
            table.Columns.Add("unit_name");
            table.Columns.Add("unit_price");
            table.Columns.Add("factor");
            table.Columns.Add("quantity");
            table.Columns.Add("total_quantity");
            table.Columns.Add("datagrid_id");
            table.Columns.Add("is_out");    
            table.Columns.Add("product_code");    
            table.Columns.Add("total_price");


            table.Columns["product_code"].SetOrdinal(0);
            table.Columns["product_name"].SetOrdinal(1);
            table.Columns["unit_price"].SetOrdinal(2);
            table.Columns["unit_name"].SetOrdinal(3);
            table.Columns["quantity"].SetOrdinal(4);
            table.Columns["total_price"].SetOrdinal(5);


            table.Columns["product_code"].ColumnName = "كود الصنف";
            table.Columns["product_name"].ColumnName = "الصنف";
            table.Columns["unit_name"].ColumnName = "اسم الوحدة";
            table.Columns["quantity"].ColumnName = "الكميات";
            table.Columns["total_price"].ColumnName = "إجمالي السعر";
            table.Columns["unit_price"].ColumnName = "سعر الوحدة";

            DataRow rox;
            foreach (DataRow row in this.Sales_Details.Rows) {

                if (Convert.ToInt32(row["doc_id"]).Equals(invoiceId) ) {
                    rox = table.NewRow();

                    foreach (DataColumn col in this.Sales_Details.Columns) {
                        rox[col] = row["col"]; 
                    }

                    table.Rows.Add(rox);
                }

            }

            return table;

        }

        private void first_record_button_Click(object sender, EventArgs e)
        {
            this.currentInvoiceRowIndex = this.Sales_Table.Rows.Count - 1;
            this.Set_Invoice_Row_Page_Index();


            DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
            this.Fill_Invoice_Fields(rw);

            int id = Convert.ToInt32(this.Sales_Table.Rows[this.currentInvoiceRowIndex]["id"]);
            
            items_datagridview.DataSource = this.Get_All_Invoice_Items(id);
        }

        private void last_record_button_Click(object sender, EventArgs e)
        {
            this.currentInvoiceRowIndex = 0;
            this.Set_Invoice_Row_Page_Index();

            DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
            this.Fill_Invoice_Fields(rw);

            int id = Convert.ToInt32(this.Sales_Table.Rows[this.currentInvoiceRowIndex]["id"]);
            
           items_datagridview.DataSource = this.Get_All_Invoice_Items(id);
        }

        private void previous_button_Click(object sender, EventArgs e)
        {
            this.currentInvoiceRowIndex = (this.currentInvoiceRowIndex - 1);
            if (this.currentInvoiceRowIndex < 0) {
                this.currentInvoiceRowIndex = 0;
            }

            this.Set_Invoice_Row_Page_Index();

            DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
            this.Fill_Invoice_Fields(rw);

            int id = Convert.ToInt32(this.Sales_Table.Rows[this.currentInvoiceRowIndex]["id"]);

            items_datagridview.DataSource = this.Get_All_Invoice_Items(id);
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            this.currentInvoiceRowIndex = (this.currentInvoiceRowIndex + 1);
            if (this.currentInvoiceRowIndex >= this.Sales_Table.Rows.Count) {
                this.currentInvoiceRowIndex = this.Sales_Table.Rows.Count - 1;
            }

            this.Set_Invoice_Row_Page_Index();

            DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
            this.Fill_Invoice_Fields(rw);

            int id = Convert.ToInt32(this.Sales_Table.Rows[this.currentInvoiceRowIndex]["id"]);

            items_datagridview.DataSource = this.Get_All_Invoice_Items(id);
        }

        private void search_button_Click(object sender, EventArgs e)
        {

            if (invoice_serial.Text == "") {
                return;
            }

            int id = Convert.ToInt32(invoice_serial.Text);
            int index = 0;
            foreach (DataRow row in this.Sales_Table.Rows) {
                
                if (Convert.ToInt32(row["serial"]).Equals(id)) {

                    this.currentInvoiceRowIndex = index;

                    this.Set_Invoice_Row_Page_Index();

                    DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
                    this.Fill_Invoice_Fields(rw); 

                    items_datagridview.DataSource = this.Get_All_Invoice_Items(id);

                    break;
                }

                index++;
            }

        }

        private void invoice_serial_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
            
        }
    }
}
