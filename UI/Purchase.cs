﻿using System;
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
        public int isOutInventory = 0;
        public int lastRow = -1;
        public bool invoiceContinue = false;

        DataTable Products;
        DataTable unitName;
        DataTable all_invoices;
        DataTable all_details;

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

            all_invoices = Invoice.Get_All_Invoices_Data(this.InvoiceType);
            all_details  = Invoice.Get_All_Invoices_Details(this.InvoiceType);
             
            // Get All Untis 

            if (frm == null)
            {
                frm = this;
            }

            // Get Last Invoice When Load 
            this.Load_Invoice_Data_Table(-1);
            DataTable table = Get_Invoice_Items_Details(Convert.ToInt32(invoice_number.Text));
            this.Setup_Datagridview_Invoice_Items(table);
            this.invoiceContinue = true;
        }


        public void Setup_Datagridview_Invoice_Items(DataTable table ) {
            
            
            table.Columns["product_name"].SetOrdinal(0);
            table.Columns["quantity"].SetOrdinal(1);
            table.Columns["shortcut"].SetOrdinal(2);
            table.Columns["unit_price"].SetOrdinal(3);
            table.Columns["total_price"].SetOrdinal(4); 

            invoice_detail_datagridview.DataSource = table;
            DataGridViewButtonColumn delete_btn = new DataGridViewButtonColumn(); 
            delete_btn.Name = "delete_btn";
            delete_btn.Text = "X";
            delete_btn.UseColumnTextForButtonValue = true;
            delete_btn.DefaultCellStyle.BackColor = Color.Transparent;
            invoice_detail_datagridview.Columns.Add(delete_btn);

            invoice_detail_datagridview.Columns["product_name"].HeaderText = "الصنف";
            invoice_detail_datagridview.Columns["quantity"].HeaderText = "الكمية";
            invoice_detail_datagridview.Columns["shortcut"].HeaderText = "اسم الوحدة";
            invoice_detail_datagridview.Columns["unit_price"].HeaderText = "سعر الوحدة";
            invoice_detail_datagridview.Columns["total_price"].HeaderText = "إجمالي السعر";
            invoice_detail_datagridview.Columns["delete_btn"].HeaderText = "حذف";

            invoice_detail_datagridview.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);

            invoice_detail_datagridview.Columns["product_name"].ReadOnly = true; 
            invoice_detail_datagridview.Columns["shortcut"].ReadOnly = true;
            invoice_detail_datagridview.Columns["unit_price"].ReadOnly = true;
            invoice_detail_datagridview.Columns["total_price"].ReadOnly = true;

            invoice_detail_datagridview.Columns["product_name"].Visible = true;
            invoice_detail_datagridview.Columns["shortcut"].Visible = true;
            invoice_detail_datagridview.Columns["unit_price"].Visible = true;
            invoice_detail_datagridview.Columns["quantity"].Visible = true;
            invoice_detail_datagridview.Columns["total_price"].Visible = true;
            invoice_detail_datagridview.Columns["delete_btn"].Visible = true;

            invoice_detail_datagridview.Columns["product_name"].Width = 340;
            invoice_detail_datagridview.Columns["quantity"].Width = 80;
            invoice_detail_datagridview.Columns["shortcut"].Width = 80;
            invoice_detail_datagridview.Columns["unit_price"].Width = 80;
            invoice_detail_datagridview.Columns["total_price"].Width = 150;
            invoice_detail_datagridview.Columns["delete_btn"].Width = 80;

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

            not_more_than.Enabled = !isDisabled;
            percentage_discount.Enabled = !isDisabled;

            newInvoiceBtn.Enabled = isDisabled;
            deleteInvoiceBtn.Enabled = isDisabled;
            editInvoiceBtn.Enabled = isDisabled;
            printInvoiceBtn.Enabled = isDisabled;
            storeInvoiceBtn.Enabled = !isDisabled;
        }

        public void Get_Invoice_Details_By_Id( int invoiceId = -1 ) {
            
            int docType = this.InvoiceType;

            Invoice.Get_All_Invoices_Data(this.InvoiceType);

            Invoice.Get_Invoice_Details_By_Id(invoiceId);
            
        }

        public string getValue(string stringValue ) {

            if ( System.DBNull.Value.Equals(stringValue) ) {
                return "0";
            }

            return stringValue.ToString();
        }

        public void Load_Invoice_Data_Table( int dex = -1 ) {
            
            if(all_invoices.Rows.Count == 0 )
            {
                return;
            }


            int index = dex;

            if (dex == -1)
                index = all_invoices.Rows.Count - 1;

            DataRow invoice = all_invoices.Rows[index];
             
            // Setup Fields 
            invoice_serial.Text = this.getValue(invoice["serial"].ToString());
            invoice_number.Text = this.getValue(invoice["id"].ToString());
            datemade.Value = System.DBNull.Value == invoice["date"] ? DateTime.Now:  Convert.ToDateTime(invoice["date"]);
            payment_methods.SelectedIndex = Convert.ToInt32(invoice["payment_method"]);
            details.Text = this.getValue(invoice["details"].ToString());
            short_vat_amount.Text = invoice["vat_value"] == System.DBNull.Value ? "0": Math.Round(Convert.ToDecimal(invoice["vat_value"]), 2).ToString();
            net_total.Text = this.getValue(invoice["net_total"].ToString());



            vat_amount.Text = this.getValue(invoice["vat_value"].ToString());
            total_with_vat.Text = this.getValue(invoice["total_with_vat"].ToString());
            total_without_vat.Text = this.getValue(invoice["total_without_vat"].ToString());
            enable_vat.Checked = invoice["is_include_vat"] == System.DBNull.Value ? true: Convert.ToBoolean(invoice["is_include_vat"]);

            discount_value.Text = this.getValue(invoice["discount"].ToString());
            percentage_discount.Text = this.getValue(invoice["discount_perc"].ToString());
            not_more_than.Text = this.getValue(invoice["discount_not_more"].ToString());


        }

        public DataTable Get_Invoice_Items_Details( int invoice_id) {
            
            DataTable table = new DataTable();

            foreach (DataColumn cols in all_details.Columns) {
                table.Columns.Add(cols.ToString());
            }

            DataRow rowx;
            foreach (DataRow row in all_details.Rows) {

                
                if (Convert.ToInt32(row["invoice_id"]) == invoice_id) {
                    rowx = table.NewRow();

                    foreach (DataColumn cols in all_details.Columns)
                    {
                        string colx = cols.ToString();
                        rowx[colx] = row[colx].ToString();
                    }

                    table.Rows.Add(rowx);

                }

               

            } 
            return table;

        }
        
        public void Fill_Invoice_Data( DataTable invoiceTable )
        {

            if (invoiceTable.Rows.Count != 0) { 
                
                DataRow row = invoiceTable.Rows[0];
                
                // Get Invoice Table 
                string id               = row["id"].ToString();
                string serials          = row["serial"].ToString();
                string payment_method   = row["payment_method"].ToString();
                DateTime date           = row["date"].Equals(System.DBNull.Value) ? DateTime.Now: Convert.ToDateTime(row["date"]);
                string detailss         = row["details"].ToString();
                string total_with_vats  = row["total_with_vat"].ToString();
                string total_without_vats = row["total_without_vat"].ToString();
                string discounts          = row["discount"].ToString();
                string vat_value          = row["vat_value"].ToString();
                bool is_include_vat       = row["is_include_vat"].Equals(System.DBNull.Value) ? true : Convert.ToBoolean(row["is_include_vat"]);
                bool is_paid_vat          = row["is_paid_vat"].Equals(System.DBNull.Value)? false: Convert.ToBoolean(row["is_paid_vat"]);

                invoice_number.Text = id;
                payment_methods.SelectedIndex = Convert.ToInt32(payment_method);
                datemade.Value = date;
                enable_vat.Checked = is_include_vat;
                details.Text = detailss;
                total_without_vat.Text = total_without_vats;
                discount_value.Text = discounts;
                vat_amount.Text = vat_value;
                if(vat_value != "")
                    short_vat_amount.Text = Math.Round(Convert.ToDecimal(vat_value), 4).ToString();
                total_with_vat.Text = total_with_vats;
                invoice_serial.Text = serials;

                // Get Invoice Details
                //bool setup = false;
                //if (invoice_detail_datagridview.Rows.Count == 0) setup = true;
               // this.Fill_DataGridview_With_Invoice_Details( Convert.ToInt32(id), setup);

            }

        }

        

        public void Truncate_Element_From_Data() {
            invoice_serial.Text = "";
            invoice_number.Text = "";
            payment_methods.SelectedIndex = 0;
            details.Text = "";
            datemade.Value = DateTime.Now;
            net_total.Text = "";
            discount_value.Text = "";
            percentage_discount.Text = "";
            not_more_than.Text = "";
            total_without_vat.Text = "";
            short_vat_amount.Text = "";
            vat_amount.Text = "";
            enable_vat.Checked = true;
            total_with_vat.Text = "";


            for (int i = 0; i < invoice_detail_datagridview.Rows.Count; i++) {
                invoice_detail_datagridview.Rows.RemoveAt(i);
            }
        }

        public void add_an_empty_rows() {

            if (invoice_detail_datagridview.Rows.Count > 0) {

                for (int i = 0; i < invoice_detail_datagridview.Rows.Count; i++) {
                    invoice_detail_datagridview.Rows.RemoveAt(i);
                }

            }

            DataTable ds = (DataTable)invoice_detail_datagridview.DataSource;
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = ds.NewRow();
                dr["datagride_id"] = Guid.NewGuid().ToString();
                ds.Rows.InsertAt(dr, (invoice_detail_datagridview.Rows.Count - 1) + 1);
                invoice_detail_datagridview.DataSource = ds;
            }

        }
        
        private void button7_Click(object sender, EventArgs e)
        {

            // Truncate current invoice 
            this.Truncate_Element_From_Data();

            // Add new invoice 
            int id = invoice_number.Text == "" ? 0 : Convert.ToInt32(invoice_number.Text);
            DataTable table = Invoice.Create_Invoice_Id( 1, id);
            this.Fill_Invoice_Data(table);
            this.enable_invoice_element(false);
            this.add_an_empty_rows();

           
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

            
        }

        public void Calculate_Row( int rowIndex, decimal quantity, decimal unit_price, string productName, string shortcut, int unit_id, decimal unit_factor, int productId, int gridId = -1) {

            Decimal total = quantity * unit_price;
            invoice_detail_datagridview.Rows[rowIndex].Cells["id"].Value = gridId.ToString();
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
            invoice_detail_datagridview.Rows[rowIndex].Cells["document_type"].Value = UI.Purchase.GetForm.InvoiceType;
            invoice_detail_datagridview.Rows[rowIndex].Cells["is_out"].Value = UI.Purchase.GetForm.isOutInventory;
            
           
        }

        public decimal Calculate_Invoice_Prices() {
            
            decimal net_total = 0;
            
            for (int i = 0; i < invoice_detail_datagridview.Rows.Count; i++)
            {
                if (System.DBNull.Value != invoice_detail_datagridview.Rows[i].Cells["total_price"].Value)
                    net_total += Convert.ToDecimal(invoice_detail_datagridview.Rows[i].Cells["total_price"].Value);
            }
            
            return net_total;

        }

        public Decimal Extract_Vat( decimal amount ) {
            
            return amount - (amount / Convert.ToDecimal(1.15));

        }

        public Decimal Total_Without_Vat() {

            decimal net = this.Calculate_Invoice_Prices();
            decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
            decimal total_without_vat = net - discount_val;

            if (enable_vat.Checked) {
                total_without_vat = total_without_vat - this.Extract_Vat(total_without_vat);
            }

            return total_without_vat;
        }

        public decimal Get_Vat_Amount() {

            decimal net = this.Calculate_Invoice_Prices();
            decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
            decimal netval = net - discount_val;
            decimal vat = this.Extract_Vat(netval);

            if ( !enable_vat.Checked)
            {
                vat = (netval * Convert.ToDecimal(1.15) ) - netval;
            }

            return vat;

        }

        public decimal Calculate_Total_With_Vat() {
            
            decimal net = this.Calculate_Invoice_Prices();
            decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
            decimal netval = net - discount_val;
            decimal total = netval;

            if (!enable_vat.Checked)
            {
                total = total * Convert.ToDecimal(1.15);
            }

            return total;
        }

        private void invoice_detail_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return;

            // Stor Index of Row 
            UI.Purchase.GetForm.lastRow = e.RowIndex;
             
            // Item Name 
            if ( e.ColumnIndex == 1) {
                UI.Items.GetForm.ShowDialog();
            }
             
            if ((e.ColumnIndex == 4 || e.ColumnIndex == 3 ) && invoice_detail_datagridview.Rows[e.RowIndex].Cells["product_name"].Value.ToString() != "") {
                UI.Price.GetForm.ShowDialog();
            }

            // Calculate Total Amounts  
            net_total.Text = this.Calculate_Invoice_Prices().ToString();
            total_without_vat.Text = Math.Round(this.Total_Without_Vat(), 2).ToString();
            short_vat_amount.Text = Math.Round(this.Get_Vat_Amount(), 2).ToString();
            vat_amount.Text = this.Get_Vat_Amount().ToString();
            total_with_vat.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();

            this.Calculate_Discount_Percentage();
            decimal discount_val = Calculate_Discount_Percentage();
            discount_value.Text = discount_val.ToString();

        }
        private void invoice_detail_datagridview_KeyDown(object sender, KeyEventArgs e)
        {
             
            if (invoice_detail_datagridview.CurrentCell.OwningRow.Index == -1) return;

            UI.Purchase.GetForm.lastRow = invoice_detail_datagridview.CurrentCell.OwningRow.Index;

            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {

                int rowIndex = invoice_detail_datagridview.CurrentCell.OwningRow.Index;
                int colIndex = invoice_detail_datagridview.CurrentCell.OwningColumn.Index;
                if (invoice_detail_datagridview.CurrentCell.OwningRow.Index == -1) return;


                // Item Name 
                if (invoice_detail_datagridview.CurrentCell.OwningColumn.Index == 1)
                {
                    UI.Items.GetForm.ShowDialog();
                }


                if ((colIndex == 3 || colIndex == 4) && invoice_detail_datagridview.Rows[rowIndex].Cells["product_name"].Value.ToString() != "")
                {
                    UI.Price.GetForm.ShowDialog();
                }


                // Fill Net total 
                net_total.Text = this.Calculate_Invoice_Prices().ToString();
                total_without_vat.Text = Math.Round(this.Total_Without_Vat(), 2).ToString();
                short_vat_amount.Text = Math.Round(this.Get_Vat_Amount(), 2).ToString();
                vat_amount.Text = this.Get_Vat_Amount().ToString();
                total_with_vat.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();

                this.Calculate_Discount_Percentage();
                decimal discount_val = Calculate_Discount_Percentage();
                discount_value.Text = discount_val.ToString();
            }

        }
        private void invoice_detail_datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex == -1 ) return;
           

            UI.Purchase.GetForm.lastRow = e.RowIndex;


            
            // Change Value 
            if (e.ColumnIndex == 2 && System.DBNull.Value != invoice_detail_datagridview.Rows[e.RowIndex].Cells["unit_id"].Value) {


                decimal quantity = invoice_detail_datagridview.Rows[e.RowIndex].Cells["quantity"].Value == System.DBNull.Value ? 0 : Convert.ToDecimal(invoice_detail_datagridview.Rows[e.RowIndex].Cells["quantity"].Value);
                string productName = invoice_detail_datagridview.Rows[e.RowIndex].Cells["product_name"].Value.ToString();
                string shortcut = invoice_detail_datagridview.Rows[e.RowIndex].Cells["shortcut"].Value.ToString();
                int unit_id = Convert.ToInt32(invoice_detail_datagridview.Rows[e.RowIndex].Cells["unit_id"].Value);
                string factor = invoice_detail_datagridview.Rows[e.RowIndex].Cells["factor"].Value.ToString();
                string unit_price = invoice_detail_datagridview.Rows[e.RowIndex].Cells["unit_price"].Value.ToString();
                int product_id = Convert.ToInt32(invoice_detail_datagridview.Rows[e.RowIndex].Cells["product_id"].Value);

                this.Calculate_Row(e.RowIndex, quantity, Convert.ToDecimal(unit_price), productName, shortcut, unit_id, Convert.ToDecimal(factor), product_id);
                 
            }

            // Fill Net total 
            net_total.Text = this.Calculate_Invoice_Prices().ToString();
            total_without_vat.Text = Math.Round(this.Total_Without_Vat(), 2).ToString();
            short_vat_amount.Text = Math.Round(this.Get_Vat_Amount(), 2).ToString();
            vat_amount.Text = this.Get_Vat_Amount().ToString();
            total_with_vat.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();

            this.Calculate_Discount_Percentage();
            decimal discount_val = Calculate_Discount_Percentage();
            discount_value.Text = discount_val.ToString();

        }

        

        private void enable_vat_CheckedChanged(object sender, EventArgs e)
        {
            // Calculate Total Amounts  
            net_total.Text = this.Calculate_Invoice_Prices().ToString();
            total_without_vat.Text = Math.Round(this.Total_Without_Vat(), 2).ToString();
            short_vat_amount.Text = Math.Round(this.Get_Vat_Amount(), 2).ToString();
            vat_amount.Text = this.Get_Vat_Amount().ToString();
            total_with_vat.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();

            this.Calculate_Discount_Percentage();
            decimal discount_val = Calculate_Discount_Percentage();
            discount_value.Text = discount_val.ToString();

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
             
        }

        private void discount_value_TextChanged_1(object sender, EventArgs e)
        {
            // Calculate Total Amounts  
            if (this.invoiceContinue) { 
            
                net_total.Text = this.Calculate_Invoice_Prices().ToString();
                total_without_vat.Text = Math.Round(this.Total_Without_Vat(), 2).ToString();
                short_vat_amount.Text = Math.Round(this.Get_Vat_Amount(), 2).ToString();
                vat_amount.Text = this.Get_Vat_Amount().ToString();
                total_with_vat.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();
            
            }
        }


        public decimal Calculate_Discount_Percentage() {

            decimal net_total = this.Calculate_Invoice_Prices();
            decimal discount_val = percentage_discount.Text == "" ? 0: (net_total * Convert.ToDecimal(percentage_discount.Text)) / 100;
            if (not_more_than.Text != "")
            {

                decimal not_more = Convert.ToDecimal(not_more_than.Text);

                if (discount_val >= not_more)
                {
                    discount_val = not_more;
                }

            }

            return discount_val;
        }

        private void percentage_discount_TextChanged(object sender, EventArgs e)
        {
            if (this.invoiceContinue)
            {
                if (percentage_discount.Text == "")
                {
                    discount_value.Text = "";
                    return;
                }

                this.Calculate_Discount_Percentage();
                decimal discount_val = Calculate_Discount_Percentage();
                discount_value.Text = discount_val.ToString();
            }

        }

        private void not_more_than_TextChanged(object sender, EventArgs e)
        {
            if (this.invoiceContinue)
            {
                if (percentage_discount.Text == "")
                {
                    discount_value.Text = "";
                    return;
                }

                this.Calculate_Discount_Percentage();
                decimal discount_val = Calculate_Discount_Percentage();
                discount_value.Text = discount_val.ToString();
            }
        }

        private void invoice_detail_datagridview_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
             
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (invoice_detail_datagridview.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void Store_Invoice_Data() {



            // Storing Invoice Data 
            Invoice.Store_Invoice_Data(
                Convert.ToInt32(invoice_number.Text),
                invoice_serial.Text.ToString(),
                Convert.ToInt32(payment_methods.SelectedIndex),
                details.Text.ToString(),
                total_with_vat.Text.ToString(),
                total_without_vat.Text.ToString(),
                discount_value.Text.ToString(),
                vat_amount.Text.ToString(), 
                Convert.ToBoolean(enable_vat.Checked),
                net_total.Text.ToString(),
                percentage_discount.Text.ToString(),
                not_more_than.Text.ToString(), 
                Convert.ToInt32( UI.Purchase.GetForm.InvoiceType )
            );

            // Invoice.Store_Invoice_Data();

            foreach (DataGridViewRow row in invoice_detail_datagridview.Rows) {
                
                if (row.Cells["product_name"].Value != System.DBNull.Value) {
                     
                    Invoice.Store_Invoice_Details(
                        row.Cells["datagride_id"].Value.ToString(),
                        Convert.ToInt32(UI.Purchase.GetForm.InvoiceType),
                        Convert.ToInt32(UI.Purchase.GetForm.isOutInventory),
                        row.Cells["factor"].Value.ToString(),
                        row.Cells["product_name"].Value.ToString(),
                        row.Cells["total_quantity"].Value.ToString(),
                        row.Cells["total_price"].Value.ToString(),
                        row.Cells["quantity"].Value.ToString(),
                        Convert.ToInt32(row.Cells["unit_id"].Value),
                        row.Cells["unit_price"].Value.ToString(),
                        row.Cells["product_id"].Value.ToString(),
                        Convert.ToInt32(invoice_number.Text)
                    );
                    
                }
                  
            }

            


        }

        private void storeInvoiceBtn_Click(object sender, EventArgs e)
        {
             
            // Storing Invoice Data
            this.Store_Invoice_Data();

            this.enable_invoice_element(true);
        }

        private void invoice_detail_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 90) return;
            if (e.RowIndex == -1) return;

            int rowIndex = Convert.ToInt32(e.RowIndex);

            if ( invoice_detail_datagridview.Rows[rowIndex].Cells["datagride_id"].Value != System.DBNull.Value ) {
                
                string id = invoice_detail_datagridview.Rows[rowIndex].Cells["datagride_id"].Value.ToString();
                Invoice.Delete_Item_In_Invoice(id, UI.Purchase.GetForm.InvoiceType);

                invoice_detail_datagridview.Rows.RemoveAt(rowIndex);

                // Recalculate  
                net_total.Text = this.Calculate_Invoice_Prices().ToString();
                total_without_vat.Text = Math.Round(this.Total_Without_Vat(), 2).ToString();
                short_vat_amount.Text = Math.Round(this.Get_Vat_Amount(), 2).ToString();
                vat_amount.Text = this.Get_Vat_Amount().ToString();
                total_with_vat.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();

                this.Calculate_Discount_Percentage();
                decimal discount_val = Calculate_Discount_Percentage();
                discount_value.Text = discount_val.ToString();
            }


        }

        private void deleteInvoiceBtn_Click(object sender, EventArgs e)
        {

            if ( invoice_number.Text == "") return;

            // DELETE INVOICE DATA AND DETAILS 
            Invoice.Delete_Item_In_Invoice("-1", UI.Purchase.GetForm.InvoiceType, Convert.ToInt32(invoice_number.Text));

            all_invoices = Invoice.Get_All_Invoices_Data(this.InvoiceType);
            all_details = Invoice.Get_All_Invoices_Details(this.InvoiceType);

        }
    }
}
