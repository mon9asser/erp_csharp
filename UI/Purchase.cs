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
        
        public int InvoiceType = 1;
        public int lastRow = -1;

        DataTable Products;
        DataTable unitName;

        public static Purchase frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Purchase GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Purchase();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }


        public Purchase() {
            
            InitializeComponent();

            // Get All Products 
            PL.Products prd = new PL.Products();
            Products = prd.Get_All_Products();
            unitName = prd.Get_All_Product_Units();

            // Get All Untis 

            if (frm == null)
            {
                frm = this;
            }

            this.enable_invoice_element( true );
        }



        // Disable OR Enable
        public void enable_invoice_element(bool isDisabled)
        {

            details.Enabled = !isDisabled;
            payment_methods.Enabled = !isDisabled;
            enable_vat.Enabled = !isDisabled;
            invoice_number.Enabled = !isDisabled;
            datemade.Enabled = !isDisabled;
            invoice_detail_datagridview.Enabled = !isDisabled;
            total_without_vat.Enabled = !isDisabled;
            discount_value.Enabled = !isDisabled; 
            short_vat_amount.Enabled = !isDisabled;
            total_with_vat.Enabled = !isDisabled;
            invoice_serial.Enabled = !isDisabled;

            newInvoiceBtn.Enabled = isDisabled;
            deleteInvoiceBtn.Enabled = isDisabled;
            editInvoiceBtn.Enabled = isDisabled;
            printInvoiceBtn.Enabled = isDisabled;
            storeInvoiceBtn.Enabled = !isDisabled;
        }

        public void Fill_Invoice_Data( DataTable invoiceTable )
        {

            if (invoiceTable.Rows.Count != 0) { 
                
                DataRow row = invoiceTable.Rows[0];
                
                // Get Invoice Table 
                string id              = row["id"].ToString();
                string serials              = row["serial"].ToString();
                string payment_method = row["payment_method"].ToString();
                DateTime date = row["date"].Equals(System.DBNull.Value) ? DateTime.Now: Convert.ToDateTime(row["date"]);
                string detailss = row["details"].ToString();
                string total_with_vats = row["total_with_vat"].ToString();
                string total_without_vats = row["total_without_vat"].ToString();
                string discounts = row["discount"].ToString();
                string vat_value = row["vat_value"].ToString();
                bool is_include_vat = row["is_include_vat"].Equals(System.DBNull.Value) ? true : Convert.ToBoolean(row["is_include_vat"]);
                bool is_paid_vat = row["is_paid_vat"].Equals(System.DBNull.Value)? false: Convert.ToBoolean(row["is_paid_vat"]);

                invoice_number.Text = id;
                payment_methods.SelectedIndex = 0;
                datemade.Value = date;
                enable_vat.Checked = true;
                details.Text = detailss;
                total_without_vat.Text = total_without_vats;
                discount_value.Text = discounts;
                vat_amount.Text = vat_value;
                if(vat_value != "")
                    short_vat_amount.Text = Math.Round(Convert.ToDecimal(vat_value), 4).ToString();
                total_with_vat.Text = total_with_vats;
                invoice_serial.Text = serials;

                // Get Invoice Details
                this.Fill_DataGridview_With_Invoice_Details( Convert.ToInt32(id) );

            }

        }

        public void Fill_DataGridview_With_Invoice_Details(int id, bool Use_Format = true ) {
            
            if (id != -1 )
             invoice_detail_datagridview.DataSource = Invoice.Get_Invoice_Details(1, id);

            // Data Grid View Organization 
            if ( Use_Format ) {

                invoice_detail_datagridview.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
                //invoice_detail_datagridview.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight);
               

                invoice_detail_datagridview.Columns["id"].Visible = false;

                invoice_detail_datagridview.Columns["product_name"].Visible = true;
                invoice_detail_datagridview.Columns["shortcut"].Visible = true;
                invoice_detail_datagridview.Columns["unit_price"].Visible = true;
                invoice_detail_datagridview.Columns["quantity"].Visible = true;
                invoice_detail_datagridview.Columns["total_price"].Visible = true;

                invoice_detail_datagridview.Columns["product_name"].HeaderText = "الصنف";
                invoice_detail_datagridview.Columns["quantity"].HeaderText = "الكمية";
                invoice_detail_datagridview.Columns["shortcut"].HeaderText = "اسم الوحدة";
                invoice_detail_datagridview.Columns["unit_price"].HeaderText = "سعر الوحدة";
                invoice_detail_datagridview.Columns["total_price"].HeaderText = "إجمالي السعر";

                invoice_detail_datagridview.Columns["product_name"].ReadOnly = true;
                invoice_detail_datagridview.Columns["shortcut"].ReadOnly = true;
                invoice_detail_datagridview.Columns["unit_price"].ReadOnly = true;

                invoice_detail_datagridview.Columns["product_name"].Width = 340;
                invoice_detail_datagridview.Columns["quantity"].Width = 80;
                invoice_detail_datagridview.Columns["shortcut"].Width = 80;
                invoice_detail_datagridview.Columns["unit_price"].Width = 80;
                invoice_detail_datagridview.Columns["total_price"].Width = 150;

                DataGridViewButtonColumn delete_btn = new DataGridViewButtonColumn();
                delete_btn.HeaderText = "حذف";
                delete_btn.Name = "delete_btn";
                delete_btn.Text = "X";
                delete_btn.UseColumnTextForButtonValue = true;
                invoice_detail_datagridview.Columns.Add(delete_btn);

                
                invoice_detail_datagridview.Columns["total_price"].DisplayIndex = 4;
                invoice_detail_datagridview.Columns["product_name"].DisplayIndex = 0;
                invoice_detail_datagridview.Columns["quantity"].DisplayIndex = 1;
                invoice_detail_datagridview.Columns["shortcut"].DisplayIndex = 2;
                invoice_detail_datagridview.Columns["unit_price"].DisplayIndex = 3;
                invoice_detail_datagridview.Columns[invoice_detail_datagridview.Columns.Count - 1].DisplayIndex = 5;

                // Fill An Empty Rows

            }

            DataTable ds = (DataTable)invoice_detail_datagridview.DataSource;
            for (int i = 0; i < 10; i++) {
                DataRow dr = ds.NewRow();
                ds.Rows.InsertAt(dr, (invoice_detail_datagridview.Rows.Count - 1) + 1);
                invoice_detail_datagridview.DataSource = ds;
            }

           
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            int id = invoice_number.Text == "" ? 0 : Convert.ToInt32(invoice_number.Text);
            
            DataTable table = Invoice.Create_Invoice_Id( 1, id);
            this.Fill_Invoice_Data(table);
            this.enable_invoice_element(false);
            this.Fill_DataGridview_With_Invoice_Details( -1 );

           
        }

        public void Set_Datagrid_View(int index, int id) {

            if (Products.Rows.Count == 0) return;

            int indexer = 0;

            foreach (DataRow row in Products.Rows) {
                 

                if (Convert.ToInt32(row["id"]) == id )
                {
                    break;
                }

                indexer++;
            }

            
            
            string productName = Products.Rows[indexer]["name"].ToString();
            int productId = Convert.ToInt32(Products.Rows[indexer]["id"]);
            int default_group = Convert.ToInt32(Products.Rows[indexer]["default_group"]);

            Decimal purchase_price = Convert.ToDecimal(Products.Rows[indexer]["purchase_price"]);
            Decimal default_sale_price = Convert.ToDecimal(Products.Rows[indexer]["default_sale_price"]);
            int unit_id = Convert.ToInt32(Products.Rows[indexer]["unit_id"]);
            decimal unit_factor =1;

            //Decimal total_quantity = Convert.ToDecimal(Products.Rows[indexer]["total_quantity"]);

            // Get Prices 
            if (default_group != 0)
            {
                purchase_price = Convert.ToDecimal(Products.Rows[indexer]["gr" + default_group + "_purchase_price"]);
                default_sale_price = Convert.ToDecimal(Products.Rows[indexer]["gr" + default_group + "_sale_price"]);
                unit_id = Convert.ToInt32(Products.Rows[indexer]["gr" + default_group + "_unit_id"]);
                unit_factor = Convert.ToDecimal(Products.Rows[indexer]["gr" + default_group + "_transform"]);
            }


            // Calculate Row 
            decimal unit_price = 0;
            if (this.InvoiceType == 0 || this.InvoiceType == 3 )
            {
                unit_price = default_sale_price;
            }
            else if (this.InvoiceType == 1 || this.InvoiceType == 2 ) {
                unit_price = purchase_price;
            }



            string unit_shortcut = "جرام"; 
            foreach (DataRow col in unitName.Rows)
            {

                if (Convert.ToInt32(col["id"]) == unit_id)
                {
                    unit_shortcut = col["shortcut"].ToString(); 
                    break;
                } 

            }


            this.Calculate_Row(index, Convert.ToDecimal(1), unit_price, productName, unit_shortcut, unit_id, unit_factor, productId);

            // Calculate Totals 
            this.Calculate_Totals();

            // Calculate Inventories 


           // MessageBox.Show(purchase_price.ToString() + " | " + default_sale_price.ToString() + " | " +  default_group.ToString());
        }

        public void Calculate_Row( int rowIndex, decimal quantity, decimal unit_price, string productName, string shortcut, int unit_id, decimal unit_factor, int productId) {

            Decimal total = quantity * unit_price;
            invoice_detail_datagridview.Rows[rowIndex].Cells["quantity"].Value = quantity.ToString();
            
            if ( unit_price != 0 )
                invoice_detail_datagridview.Rows[rowIndex].Cells["unit_price"].Value = unit_price.ToString();
            invoice_detail_datagridview.Rows[rowIndex].Cells["product_id"].Value = productId.ToString();
            invoice_detail_datagridview.Rows[rowIndex].Cells["total_price"].Value = total.ToString();
            invoice_detail_datagridview.Rows[rowIndex].Cells["product_name"].Value = productName.ToString();
            invoice_detail_datagridview.Rows[rowIndex].Cells["shortcut"].Value = shortcut.ToString();
            invoice_detail_datagridview.Rows[rowIndex].Cells["unit_id"].Value = unit_id.ToString();
            invoice_detail_datagridview.Rows[rowIndex].Cells["total_quantity"].Value = Convert.ToDecimal(unit_factor) * quantity;
            invoice_detail_datagridview.Rows[rowIndex].Cells["factor"].Value = unit_factor.ToString();
            
            //MessageBox.Show(productName.ToString());
        }

        public void Calculate_Totals() {

            decimal net_total = 0;
            for (int i = 0; i < invoice_detail_datagridview.Rows.Count; i ++) {
                if( System.DBNull.Value != invoice_detail_datagridview.Rows[i].Cells["total_price"].Value)
                net_total += Convert.ToDecimal(invoice_detail_datagridview.Rows[i].Cells["total_price"].Value);
            }

            // Calculate Vat 
            this.Calculate_Vat_Total( net_total );

        }

        private void invoice_detail_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return;

            // Stor Index of Row 
            
            
            
            // Item Name 
            if ( e.ColumnIndex == 10) {
                UI.Purchase.GetForm.lastRow = e.RowIndex;
                UI.Items.GetForm.ShowDialog();
            }
             
            if ((e.ColumnIndex == 81 || e.ColumnIndex == 5 ) && invoice_detail_datagridview.Rows[e.RowIndex].Cells["product_name"].Value.ToString() != "") {
                
                UI.Price.GetForm.ShowDialog();
            }
        }
        private void invoice_detail_datagridview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {

                int rowIndex = invoice_detail_datagridview.CurrentCell.OwningRow.Index;
                int colIndex = invoice_detail_datagridview.CurrentCell.OwningColumn.Index;
                if (invoice_detail_datagridview.CurrentCell.OwningRow.Index == -1) return;


                // Item Name 
                if (invoice_detail_datagridview.CurrentCell.OwningColumn.Index == 10)
                {
                    UI.Purchase.GetForm.lastRow = invoice_detail_datagridview.CurrentCell.OwningRow.Index;
                    UI.Items.GetForm.ShowDialog();
                }


                if ((colIndex == 81 || colIndex == 5) && invoice_detail_datagridview.Rows[rowIndex].Cells["product_name"].Value.ToString() != "")
                {
                    UI.Price.GetForm.ShowDialog();
                }

            }

        }
        private void invoice_detail_datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex == -1 ) return;

            // Change Value 
            if (e.ColumnIndex == 7 && System.DBNull.Value != invoice_detail_datagridview.Rows[e.RowIndex].Cells["unit_id"].Value) {
                decimal quantity = Convert.ToDecimal(invoice_detail_datagridview.Rows[e.RowIndex].Cells["quantity"].Value);
                string productName = invoice_detail_datagridview.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                string shortcut = invoice_detail_datagridview.Rows[e.RowIndex].Cells["shortcut"].Value.ToString();
                int unit_id = Convert.ToInt32(invoice_detail_datagridview.Rows[e.RowIndex].Cells["unit_id"].Value);
                string factor = invoice_detail_datagridview.Rows[e.RowIndex].Cells["factor"].Value.ToString();
                string unit_price = invoice_detail_datagridview.Rows[e.RowIndex].Cells["unit_price"].Value.ToString();
                int product_id = Convert.ToInt32(invoice_detail_datagridview.Rows[e.RowIndex].Cells["product_id"].Value);

                this.Calculate_Row(e.RowIndex, quantity, Convert.ToDecimal(unit_price), productName, shortcut, unit_id, Convert.ToDecimal(factor), product_id);
                this.Calculate_Totals();
            }
        }

       

        private void discount_value_TextChanged(object sender, EventArgs e)
        {
            this.Calculate_Totals();
        }

        private void enable_vat_CheckedChanged(object sender, EventArgs e)
        {
            
            this.Calculate_Totals();

        }

        public void Set_Datagrid_View_New_Price(int index, int unit_id, string factor, string price, string shortcut) {
            
            invoice_detail_datagridview.Rows[index].Cells["unit_id"].Value = unit_id.ToString();
            invoice_detail_datagridview.Rows[index].Cells["factor"].Value = factor.ToString();
            invoice_detail_datagridview.Rows[index].Cells["unit_price"].Value = price.ToString();
            invoice_detail_datagridview.Rows[index].Cells["shortcut"].Value = shortcut.ToString();

            decimal quantity = Convert.ToDecimal(invoice_detail_datagridview.Rows[index].Cells["quantity"].Value);
            string productName = invoice_detail_datagridview.Rows[index].Cells["product_name"].Value.ToString();
            int product_id = Convert.ToInt32(invoice_detail_datagridview.Rows[index].Cells["product_id"].Value);

            this.Calculate_Row(index, quantity, Convert.ToDecimal(price), productName, shortcut, unit_id, Convert.ToDecimal(factor), product_id);
            this.Calculate_Totals();
        }
        
        public void Calculate_Vat_Total( decimal net_total ) {

            Decimal net_out_disc = Convert.ToDecimal(net_total);
            Decimal vat_cal = 0;
            Decimal total_invoice = 0;
            Decimal discount = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
            Decimal net_after_discount = (net_out_disc - discount);

            if (enable_vat.Checked == true)
            {
                vat_cal = net_after_discount - (net_after_discount / Convert.ToDecimal(1.15));
                total_invoice = net_after_discount;
            }
            else
            {
                vat_cal = (net_after_discount * Convert.ToDecimal(1.15)) - net_after_discount;
                total_invoice = net_after_discount + vat_cal;
            }


            total_without_vat.Text = Math.Round((net_after_discount - vat_cal),2).ToString();
            vat_amount.Text = vat_cal.ToString(); 
            short_vat_amount.Text = Math.Round(Convert.ToDecimal(vat_cal),2).ToString();
            total_with_vat.Text = total_invoice.ToString();
        }

         
    }
}
