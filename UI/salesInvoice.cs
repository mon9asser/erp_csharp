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
        PL.Products products = new PL.Products();

        DataTable Sales_Table;
        DataTable Sales_Details;
        DataTable Accounts;
        DataTable Settings;
        DataTable Codes;
        DataTable Prods;
        DataTable unitName;

        public int documentType = 0; // Sales Invoice
        public int currentInvoiceRowIndex = -1;

        public static salesInvoice frm;
        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static salesInvoice GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new salesInvoice();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public salesInvoice()
        {
            InitializeComponent();

            PL.AccountingTree Accs = new PL.AccountingTree();
            PL.Installings sysSettings = new PL.Installings();

            if (frm == null)
            {
                frm = this;
            }

            // Head Sales Invoices 
            this.Sales_Table = Sales.Get_All_Sales_Invoices();
            this.Sales_Details = Sales.Get_All_Sales_Invoice_Details();
            this.Accounts = Accs.Get_Accounting_Tree();
            this.Settings = sysSettings.Get_All_System_Settings();
            this.Codes = this.Load_All_Products_Codes();
            this.Prods = this.products.Get_All_Products();
            this.unitName = this.products.Get_All_Product_Units();

            // Load Default Data 
            if (0 != this.Sales_Table.Rows.Count) {
                this.currentInvoiceRowIndex = this.Sales_Table.Rows.Count - 1;
                DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
                this.Fill_Invoice_Fields(rw);
            }

            int id = this.Sales_Table.Rows.Count != 0 ? Convert.ToInt32(this.Sales_Table.Rows[this.Sales_Table.Rows.Count - 1]["id"]) : -1;
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

            items_datagridview.Columns["product_code"].HeaderText = "كود الصنف";
            items_datagridview.Columns["product_name"].HeaderText = "الصنف";
            items_datagridview.Columns["unit_name"].HeaderText = "اسم الوحدة";
            items_datagridview.Columns["quantity"].HeaderText = "الكميات";
            items_datagridview.Columns["total_price"].HeaderText = "إجمالي السعر";
            items_datagridview.Columns["unit_price"].HeaderText = "سعر الوحدة";

            items_datagridview.Columns["product_name"].ReadOnly = true;

            items_datagridview.Columns[1].Width = 330;
            items_datagridview.ColumnHeadersHeight = 40;

            // Add Button To Remove The Item From invoice 
            this.Load_deletion_icon_in_datagridview();

        }

        public DataTable Load_All_Products_Codes() {
 
            DataTable table = new DataTable();
            DataTable Items = products.Get_All_Products();

            table.Columns.Add("id");
            table.Columns.Add("code");
            table.Columns.Add("name");
            table.Columns.Add("unit_price");
            table.Columns.Add("unit_id");
            table.Columns.Add("factor");

            // Id - Product Name - Code - Unit Price - Factor
            DataRow rowDefault;
            foreach (DataRow row in Items.Rows) {

                row["code"].ToString();
                row["default_sale_price"].ToString();
                row["name"].ToString();

                // Default prices 
                rowDefault = table.NewRow();
                rowDefault["id"] = row["id"].ToString();
                rowDefault["code"] = row["code"].ToString();
                rowDefault["name"] = row["name"].ToString();
                rowDefault["unit_price"] = row["default_sale_price"].ToString();
                rowDefault["unit_id"] = row["unit_id"].ToString();
                rowDefault["factor"] = "1";
                table.Rows.Add(rowDefault);

                // Second prices 
                DataRow rowSecond; 
                for (int i = 1; i <= 6; i++) {
                    rowSecond = table.NewRow();
                    rowSecond["id"] = row["gr1_unit_id"].ToString();
                    rowSecond["code"] = row["gr1_barcode"].ToString();
                    rowSecond["name"] = row["name"].ToString();
                    rowSecond["unit_price"] = row["gr1_sale_price"].ToString();
                    rowSecond["unit_id"] = row["gr1_unit_id"].ToString();
                    rowSecond["factor"] = row["gr1_transform"].ToString();
                    table.Rows.Add(rowSecond);
                } 
                    

            } 

            return table;

        }
        
        public void Load_deletion_icon_in_datagridview() { 

            DataGridViewImageColumn deletionImage = new DataGridViewImageColumn();
            deletionImage.Image = Properties.Resources.delete_16;
            deletionImage.ImageLayout = DataGridViewImageCellLayout.NotSet;
            deletionImage.Name = "deletion_button";
            deletionImage.HeaderText = "حذف";
            this.items_datagridview.Columns.Add(deletionImage);

            foreach (DataGridViewRow row in this.items_datagridview.Rows) {
                row.Cells["deletion_button"].Value = Properties.Resources.delete_16;
            }

        }

        public void Calculate_Datagridview_Row( int index ) {

            // Getting Current Row Index   
            if ( index == -1 ) {
                return;
            }

             
            
            DataGridViewRow row = items_datagridview.Rows[index];

            if (row.Cells["product_name"].Value.ToString() == "") {
               return;
            }

            decimal quantity = Convert.ToDecimal(0);
            decimal factor = Convert.ToDecimal(0);
            decimal unitPrice = Convert.ToDecimal(0);

            // Calculate Factors AND Quantity 
            if ( System.DBNull.Value.ToString() != row.Cells["quantity"].Value.ToString()) {
                quantity = Convert.ToDecimal(row.Cells["quantity"].Value );
            }

            if (System.DBNull.Value.ToString() != row.Cells["factor"].Value.ToString()) {
                factor = Convert.ToDecimal(row.Cells["factor"].Value);
            }

            if (System.DBNull.Value.ToString() != row.Cells["unit_price"].Value.ToString()) {
                unitPrice = Convert.ToDecimal(row.Cells["unit_price"].Value);
            }
            
            // Total Quantity 
            row.Cells["total_quantity"].Value = (quantity * factor ).ToString();

            // Calculate Total 
            row.Cells["total_price"].Value = ( quantity * unitPrice ).ToString();
            

        }
        
        public string[] Get_Account_Details(string account_number ) {

            string[] account = new string[3];

            foreach (DataRow row in this.Accounts.Rows) {
                if (Convert.ToInt32(account_number).Equals(Convert.ToInt32(row["account_number"]))) {

                    account[0] = row["id"].ToString();
                    account[1] = row["account_number"].ToString();
                    account[2] = row["account_name"].ToString();

                    break;
                }
            }
            
            return account;

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
            payment_methods.SelectedIndex = Convert.ToInt32(row["payment_method"]);
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
            total_without_vat_field.Text = row["total_without_vat"].ToString();
            price_includ_vat.Checked = Convert.ToBoolean(row["price_include_vat"]);
            vat_amount.Text = row["vat_amount"].ToString();
            total_field_text.Text = row["total_with_vat"].ToString();
            total_label_text.Text = string.Format("{0:n}", Convert.ToDecimal(row["total_with_vat"])).ToString();

            if (legend_number.Text == "" ) {
                string[] account = Get_Account_Details(this.Settings.Rows[0]["sales_cash_acc_number"].ToString());
                if (account.Length != 0) {
                    legend_id.Text = account[0].ToString();
                    legend_number.Text = account[1].ToString();
                    legend_name.Text = account[2].ToString();
                }
            }

        }

        private DataTable Get_All_Invoice_Items_Copy( int invoiceId ) {
            
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

            // Add an empty rows
            DataRow emptyRow;
            for (int i = 0; i < 10; i++)
            {

                emptyRow = table.NewRow();
                foreach (DataColumn col in this.Sales_Details.Columns)
                {
                    if (col.GetType().ToString() == "Int32")
                    {
                        emptyRow[col] = 0;
                    }

                    if (col.GetType().ToString() == "String")
                    {
                        emptyRow[col] = "";
                    }

                    if (col.ToString() == "datagrid_id")
                    {
                        emptyRow[col] = Guid.NewGuid().ToString();
                    }
                }

                table.Rows.Add(emptyRow);
            }

            return table;

        }


        private DataTable Get_All_Invoice_Items(int invoiceId)
        {

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

            foreach (DataRow row in this.Sales_Details.Rows)
            {

                if (Convert.ToInt32(row["doc_id"]).Equals(invoiceId))
                {
                    rox = table.NewRow();

                    foreach (DataColumn col in this.Sales_Details.Columns)
                    {
                        rox[col] = row["col"];
                    }

                    table.Rows.Add(rox);
                }

            }

            
            // Add an empty rows
            DataRow emptyRow;
            for (int i = 0; i < 10; i++) {
                
                emptyRow = table.NewRow();
                foreach (DataColumn col in this.Sales_Details.Columns)
                {
                    if (col.GetType().ToString() == "Int32")
                    {
                        emptyRow[col] = 0;
                    }

                    if (col.GetType().ToString() == "String")
                    {
                        emptyRow[col] = "";
                    }

                    if (col.ToString() == "datagride_id") {
                        emptyRow[col] = Guid.NewGuid().ToString();
                    }
                }

                table.Rows.Add(emptyRow);
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

        private void items_datagridview_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.items_datagridview.Columns.Contains("deletion_button"))
            {
                //this.items_datagridview.Rows[e.RowIndex].Cells["deletion_button"].Value = Properties.Resources.trash__1_;
            }

        }

        private void items_datagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        { 
            if(e.ColumnIndex == 0 )
            {
                this.items_datagridview.Cursor = Cursors.Hand;
            } else
            {
                this.items_datagridview.Cursor = Cursors.Default;
            }
            
        }

         
        private void payment_condition_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            
        }

        public void Load_Target_Accounts( int paymentType ) {

            string[] account;
            if (paymentType == 0)
            {
                // Cash 
                account = Get_Account_Details(this.Settings.Rows[0]["sales_cash_acc_number"].ToString());

                legend_id.Text = account[0].ToString();
                legend_number.Text = account[1].ToString();
                legend_name.Text = account[2].ToString();
            }
            else if (paymentType == 1)
            {
                // Deferred payment
                account = Get_Account_Details(this.Settings.Rows[0]["sales_credit_acc_number"].ToString());

                legend_id.Text = account[0].ToString();
                legend_number.Text = account[1].ToString();
                legend_name.Text = account[2].ToString();
            }
            else if (paymentType == 2) {
                // Banks
                account = Get_Account_Details(this.Settings.Rows[0]["sales_bank_acc_number"].ToString());

                legend_id.Text = account[0].ToString();
                legend_number.Text = account[1].ToString();
                legend_name.Text = account[2].ToString();
            }

            

        }
        
        private void payment_methods_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.payment_methods.SelectedIndex)
            {

                // Cash 
                case 0:

                    customer_name.Enabled = false;
                    legend_name.Enabled = true;
                    legend_number.Enabled = true;

                    this.Load_Target_Accounts(0);
                    break;

                // Deferred payment
                case 1:

                    customer_name.Enabled = true;
                    legend_name.Enabled = true;
                    legend_number.Enabled = true;

                    this.Load_Target_Accounts(1);
                    break;

                // By Network
                case 2:

                    customer_name.Enabled = false;
                    legend_name.Enabled = true;
                    legend_number.Enabled = true;

                    this.Load_Target_Accounts(2);
                    break;

                // Transfeer 
                case 3:

                    customer_name.Enabled = false;
                    legend_name.Enabled = true;
                    legend_number.Enabled = true;

                    this.Load_Target_Accounts(2);
                    break;

            }
        }

        private void legend_name_MouseClick(object sender, MouseEventArgs e)
        {
            UI.Accounts accounts = new UI.Accounts();
            accounts.InstanceType = 1;
            accounts.ShowDialog();
        }

        private void legend_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void legend_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void items_datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if( e.RowIndex == -1 )
            {
                return; 
            }


            UI.Items.GetForm.DGRowIndex = e.RowIndex;
            // Select Item By Code 
            if (e.ColumnIndex == 1) {
                
                string item_code_value = items_datagridview.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                bool is_found = false;
                
                foreach (DataRow row in this.Codes.Rows) {
                    if (row["code"].ToString() == item_code_value.ToString()) {
                        is_found = true;

                        // Setup Item In Current Row 
                        items_datagridview.Rows[e.RowIndex].Cells["doc_id"].Value = invoice_id.Text.ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["doc_type"].Value = this.documentType;
                        items_datagridview.Rows[e.RowIndex].Cells["product_id"].Value = row["id"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["unit_id"].Value = row["unit_id"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["factor"].Value = row["factor"].ToString(); 
                        items_datagridview.Rows[e.RowIndex].Cells["is_out"].Value = true;
                        items_datagridview.Rows[e.RowIndex].Cells["quantity"].Value = "1";
                        items_datagridview.Rows[e.RowIndex].Cells["unit_price"].Value = row["unit_price"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["product_name"].Value = row["name"].ToString();

                        string unit_shortcut = "جرام";
                        foreach (DataRow col in unitName.Rows)
                        {

                            if (Convert.ToInt32(col["id"]).Equals(Convert.ToInt32(row["unit_id"]) ) )
                            {
                                unit_shortcut = col["shortcut"].ToString();
                                break;
                            }

                        }

                        items_datagridview.Rows[e.RowIndex].Cells["unit_name"].Value= unit_shortcut.ToString();

                        break;
                    }
                }

                if (is_found == false) {  
                    foreach (DataGridViewColumn col in items_datagridview.Columns) {
                        
                        if ( col.Name.ToString() != "deletion_button") {
                             
                            if (col.Name.ToString() == "id" || col.Name.ToString() == "doc_id" || col.Name.ToString() == "doc_type" || col.Name.ToString() == "product_id" || col.Name.ToString() == "unit_id")
                            {
                                items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = -1;
                            }
                            else if (col.Name.ToString() == "is_out")
                            {
                                items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = true;
                            }
                            else {
                                items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = "";
                            }

                            
                        }
                    }
                }

            }

            // Calcualte Row Of DataGridview 
            this.Calculate_Datagridview_Row( e.RowIndex );

            // Caluclate Total Fields 
            this.Fill_Total_Fields();

        }

        private void items_datagridview_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            bool isCol = items_datagridview.CurrentCell.ColumnIndex == 1 || items_datagridview.CurrentCell.ColumnIndex == 5;

            if (isCol) //Desired Column
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

        private void items_datagridview_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
            {
                return;
            }


            if (items_datagridview.CurrentCell.OwningRow.Index == -1) return;

            UI.Items.GetForm.DGRowIndex = items_datagridview.CurrentCell.OwningRow.Index;
            UI.Items.GetForm.doc_type = 0;

            if ( items_datagridview.CurrentCell.OwningColumn.Index == 2)
            {
                UI.Items.GetForm.ShowDialog();
            } 
        }

        private void items_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void Add_Item_To_Row(int iindex, int id, int rowId = -1 )
        {
             
            if (Prods.Rows.Count == 0) return;

            // Setup Column For Table 
            int index = -1;
            for (int i = 0; i < Prods.Rows.Count; i++)
            {
                if (Prods.Rows[i]["id"].ToString() == id.ToString())
                {
                    index = i;
                    break;
                }
            }

            DataRow item = Prods.Rows[index];

            string name = item["name"].ToString();
            int pid = Convert.ToInt32(item["id"]);
            int default_group = Convert.ToInt32(item["default_group"]);
            Decimal purchase_price = Convert.ToDecimal(item["purchase_price"]);
            Decimal default_sale_price = Convert.ToDecimal(item["default_sale_price"]);
            int unit_id = Convert.ToInt32(item["unit_id"]);
            decimal unit_factor = 1;


            if (default_group != 0)
            {
                purchase_price = Convert.ToDecimal(item["gr" + default_group + "_purchase_price"]);
                default_sale_price = Convert.ToDecimal(item["gr" + default_group + "_sale_price"]);
                unit_id = Convert.ToInt32(item["gr" + default_group + "_unit_id"]);
                unit_factor = Convert.ToDecimal(item["gr" + default_group + "_transform"]);
            }

            decimal unit_price = 0;
            unit_price = default_sale_price;
            string unit_shortcut = "جرام";
            foreach (DataRow col in unitName.Rows)
            {

                if (Convert.ToInt32(col["id"]) == unit_id)
                {
                    unit_shortcut = col["shortcut"].ToString();
                    break;
                }

            }

            MessageBox.Show(iindex.ToString());

            

            DataGridViewRow drow = items_datagridview.Rows[iindex];
            drow.Cells["id"].Value = rowId.ToString();
            drow.Cells["doc_id"].Value = invoice_id.Text.ToString();
            drow.Cells["doc_type"].Value = 0;
            drow.Cells["product_id"].Value = pid.ToString();
            drow.Cells["product_name"].Value = name.ToString();
            drow.Cells["unit_id"].Value = unit_id.ToString(); 
            drow.Cells["unit_name"].Value = unit_shortcut.ToString();
            drow.Cells["unit_price"].Value = unit_price.ToString();
            drow.Cells["factor"].Value = unit_factor;
            drow.Cells["is_out"].Value = 1;
            drow.Cells["product_code"].Value = item["code"].ToString(); ;

            //drow.Cells["datagrid_id"].Value = "xxxxxxxxxxxxxxx";
            //drow.Cells["total_quantity"].Value = "xxxxxxxxxxxxxxx";
            //drow.Cells["total_price"].Value = "xxxxxxxxxxxxxxx";

        }

        public decimal Calculate_Sub_Total() {
            
            decimal value = 0;

            foreach (DataGridViewRow row in items_datagridview.Rows) {
                if (row.Cells["total_price"].Value != System.DBNull.Value && row.Cells["total_price"].Value.ToString() != "") { 
                    decimal col = Convert.ToDecimal(row.Cells["total_price"].Value);

                    value = value + col;
                }
            }

            return value;

        }

 

        public Decimal Extract_Vat(decimal amount)
        {

            return amount - (amount / Convert.ToDecimal(1.15));

        }

        public decimal Get_Vat_Amount()
        {

            decimal net = this.Calculate_Sub_Total();
            decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
            decimal netval = net - discount_val;
            decimal vat = this.Extract_Vat(netval);

            if (!price_includ_vat.Checked)
            {
                vat = (netval * Convert.ToDecimal(1.15)) - netval;
            }

            return vat;

        }

        public decimal Calculate_Total_With_Vat()
        {

            decimal net = this.Calculate_Sub_Total();
            decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
            decimal netval = net - discount_val;
            decimal total = netval;

            if (!price_includ_vat.Checked)
            {
                total = total * Convert.ToDecimal(1.15);
            }

            return total;
        }
        public void Fill_Total_Fields() {

            decimal net = this.Calculate_Sub_Total();
            decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
            decimal total_without_vat = net - discount_val;
            if (price_includ_vat.Checked)
            {
                total_without_vat = total_without_vat - this.Extract_Vat(total_without_vat);
            }

            // Net Total 
            net_total.Text = net.ToString();

            // Without Vat 
            total_without_vat_field.Text = Math.Round(total_without_vat, 2).ToString();  

            // Vat Value 
            vat_amount.Text =  Math.Round(this.Get_Vat_Amount(), 2).ToString();

            // Total Value 
            total_field_text.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();
            total_label_text.Text = string.Format("{0:n}", Convert.ToDecimal(Math.Round(this.Calculate_Total_With_Vat(), 2) )).ToString();   
        }

        private void items_datagridview_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.RowIndex == -1) return;

            UI.Items.GetForm.DGRowIndex = e.RowIndex;
            UI.Items.GetForm.doc_type = 0;

            if (e.ColumnIndex == 2)
            {
                UI.Items.GetForm.ShowDialog();
            }
        }
    }
}
