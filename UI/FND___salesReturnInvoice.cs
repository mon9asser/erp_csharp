using CrystalDecisions.CrystalReports.Engine;
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
    public partial class FND___salesReturnInvoice : Form
    {
        // New Updates 
        PL.Return_Sales Sale = new PL.Return_Sales();
        PL.Journals journals = new PL.Journals();
        DSet.SalesInvoice CRT_DataSet = new DSet.SalesInvoice();

        DataSet dataSetDb;
        DataTable Sale_Table;
        DataTable Sale_Details;
        DataTable Accounts;
        DataTable Settings;
        DataTable Prods;
        DataTable Codes;
        DataTable Resources;
        DataTable unitName;

        // -----------------------------------
        PL.doc_items docs;
        public bool is_getting_data = true;
        public bool is_updating_data = false;
        public bool is_change_price = false;
        public int documentType = 2;
        public int currentInvoiceRowIndex = -1;
        public int lastRow = -1;
        public static FND___salesReturnInvoice frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FND___salesReturnInvoice GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new FND___salesReturnInvoice();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public FND___salesReturnInvoice()
        {
            InitializeComponent();
        }

        public DataTable Load_All_Products_Codes(DataTable products)
        {

            DataTable table = new DataTable();
            try
            {
                DataTable Items = products;

                table.Columns.Add("id");
                table.Columns.Add("code");
                table.Columns.Add("name");
                table.Columns.Add("unit_price");
                table.Columns.Add("unit_cost");
                table.Columns.Add("unit_id");
                table.Columns.Add("factor");

                // Id - Product Name - Code - Unit Price - Factor
                DataRow rowDefault;
                foreach (DataRow row in Items.Rows)
                {

                    row["code"].ToString();
                    row["default_sale_price"].ToString();
                    row["name"].ToString();

                    // Default prices 
                    rowDefault = table.NewRow();
                    rowDefault["id"] = row["id"].ToString();
                    rowDefault["code"] = row["code"].ToString();
                    rowDefault["name"] = row["name"].ToString();
                    rowDefault["unit_price"] = row["default_sale_price"].ToString();
                    rowDefault["unit_cost"] = row["purchase_price"].ToString();
                    rowDefault["unit_id"] = row["unit_id"].ToString();
                    rowDefault["factor"] = "1";
                    table.Rows.Add(rowDefault);

                    // Second prices 
                    DataRow rowSecond;
                    for (int i = 1; i <= 6; i++)
                    {
                        rowSecond = table.NewRow();
                        rowSecond["id"] = row["gr" + i + "_unit_id"].ToString();
                        rowSecond["code"] = row["gr" + i + "_barcode"].ToString();
                        rowSecond["name"] = row["name"].ToString();
                        rowSecond["unit_price"] = row["gr" + i + "_sale_price"].ToString();
                        rowSecond["unit_id"] = row["gr" + i + "_unit_id"].ToString();
                        rowSecond["factor"] = row["gr" + i + "_transform"].ToString();
                        rowSecond["unit_cost"] = row["gr" + i + "_purchase_price"].ToString();
                        table.Rows.Add(rowSecond);
                    }


                }
            }
            catch (Exception) { }

            return table;

        }

        public void Load_deletion_icon_in_datagridview()
        {
            try
            {
                items_datagridview.Columns["deletion_et_button"].DisplayIndex = items_datagridview.Columns.Count - 1;

            }
            catch (Exception){ }
        }
        public void Calculate_Datagridview_Row(int index)
        {
            try {
                // Getting Current Row Index   
                if (index == -1)
                {
                    return;
                }

                DataGridViewRow row = items_datagridview.Rows[index];

                if (row.Cells["product_name"].Value.ToString() == "")
                {
                    return;
                }

                decimal quantity = Convert.ToDecimal(0);
                decimal factor = Convert.ToDecimal(0);
                decimal unitPrice = Convert.ToDecimal(0);
                decimal unitCost = Convert.ToDecimal(0);

                // Calculate Factors AND Quantity 
                if (System.DBNull.Value.ToString() != row.Cells["quantity"].Value.ToString())
                {
                    quantity = Convert.ToDecimal(row.Cells["quantity"].Value);
                }

                if (System.DBNull.Value.ToString() != row.Cells["factor"].Value.ToString())
                {
                    factor = Convert.ToDecimal(row.Cells["factor"].Value);
                }

                if (System.DBNull.Value.ToString() != row.Cells["unit_price"].Value.ToString())
                {
                    unitPrice = Convert.ToDecimal(row.Cells["unit_price"].Value);
                }

                if (System.DBNull.Value.ToString() != row.Cells["unit_cost"].Value.ToString())
                {
                    unitCost = Convert.ToDecimal(row.Cells["unit_cost"].Value);
                }

                // Total Quantity 
                row.Cells["total_quantity"].Value = (quantity * factor).ToString();

                // Calculate Total 
                row.Cells["total_price"].Value = (quantity * unitPrice).ToString();

                // Calculate Unit Cost (purchase is the default price)
                row.Cells["unit_cost"].Value = (unitCost).ToString();
                row.Cells["total_cost"].Value = (quantity * unitCost).ToString();

            }
            catch (Exception) { }
        }

        public string[] Get_Account_Details(string account_number)
        {

            string[] account = new string[3];

            try
            {
                foreach (DataRow row in this.Accounts.Rows)
                {
                    if (Convert.ToInt32(account_number).Equals(Convert.ToInt32(row["account_number"])))
                    {

                        account[0] = row["id"].ToString();
                        account[1] = row["account_number"].ToString();
                        account[2] = row["account_name"].ToString();

                        break;
                    }
                }
            }
            catch (Exception) { }

            return account;

        }
        public void Set_Invoice_Row_Page_Index()
        {
            try
            {
                int current = this.currentInvoiceRowIndex + 1;
                int counts = this.Sale_Table.Rows.Count;

                current_invoice_page.Text = current + " / " + counts;
            }
            catch (Exception) { }
        }

        public void Fill_Invoice_Fields(DataRow row)
        {

            try
            {
                int invoiceType = this.documentType;
                if (this.Settings.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك تأكد من إعدادات النظام وشجرة الحسابات");
                    return;
                }
                entry_id.Text = row["id1"].ToString();
                invoice_id.Text = row["id"].ToString();
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

                if (legend_number.Text == "")
                {
                    string[] account = Get_Account_Details(this.Settings.Rows[0]["sale_cash_account"].ToString());
                    if (account.Length != 0)
                    {
                        legend_id.Text = account[0].ToString();
                        legend_number.Text = account[1].ToString();
                        legend_name.Text = account[2].ToString();
                    }
                }
            }
            catch (Exception ){ }

        }

        private DataTable Get_All_Invoice_Items_Copy(int invoiceId)
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

            foreach (DataRow row in this.Sale_Details.Rows)
            {

                if (Convert.ToInt32(row["doc_id"]).Equals(invoiceId))
                {
                    rox = table.NewRow();

                    foreach (DataColumn col in this.Sale_Details.Columns)
                    {
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
                foreach (DataColumn col in this.Sale_Details.Columns)
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
            try
            {

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

                table.Columns.Add("unit_cost");
                table.Columns.Add("total_cost");
                //table.Columns.Add("datemade");

                table.Columns["product_code"].SetOrdinal(0);
                table.Columns["product_name"].SetOrdinal(1);
                table.Columns["unit_price"].SetOrdinal(2);
                table.Columns["unit_name"].SetOrdinal(3);
                table.Columns["quantity"].SetOrdinal(4);
                table.Columns["total_price"].SetOrdinal(5);

                /*
                table.Columns["product_code"].ColumnName = "كود الصنف";
                table.Columns["product_name"].ColumnName = "الصنف";
                table.Columns["unit_name"].ColumnName = "اسم الوحدة";
                table.Columns["quantity"].ColumnName = "الكميات";
                table.Columns["total_price"].ColumnName = "إجمالي السعر";
                table.Columns["unit_price"].ColumnName = "سعر الوحدة";
                */
                DataRow rox;

                foreach (DataRow row in this.Sale_Details.Rows)
                {

                    if (Convert.ToInt32(row["doc_id"]).Equals(invoiceId))
                    {
                        rox = table.NewRow();

                        foreach (DataColumn col in this.Sale_Details.Columns)
                        {
                            rox[col.ToString()] = row[col.ToString()];
                        }

                        table.Rows.Add(rox);
                    }

                }


                // Add an empty rows
                DataRow emptyRow;
                for (int i = 0; i < 10; i++)
                {

                    emptyRow = table.NewRow();
                    foreach (DataColumn col in this.Sale_Details.Columns)
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
                            emptyRow["datagrid_id"] = Guid.NewGuid().ToString();
                        }

                        /*
                         * if (col.ToString() == "datemade")
                        {
                            emptyRow[col] = DateTime.Now;
                        }*/


                    }

                    table.Rows.Add(emptyRow);
                }

            }
            catch (Exception) { }
            return table;

        }

        private void last_record_button_Click(object sender, EventArgs e)
        {
            try {
                if (this.Sale_Table.Rows.Count == 0)
                {
                    return;
                }
                this.currentInvoiceRowIndex = 0;
                this.Set_Invoice_Row_Page_Index();

                DataRow rw = this.Sale_Table.Rows[this.currentInvoiceRowIndex];
                this.Fill_Invoice_Fields(rw);

                int id = Convert.ToInt32(this.Sale_Table.Rows[this.currentInvoiceRowIndex]["id"]);

                this.refill_datagridview(id, items_datagridview);
            } catch( Exception) { }

        }

        public void refill_datagridview(int id, DataGridView griddatatable)
        {

            try
            {
                // Datasource of table 
                DataTable tabl = this.Get_All_Invoice_Items(id);
                griddatatable.DataSource = tabl;

                items_datagridview.Columns[0].DisplayIndex = items_datagridview.Columns.Count - 1;
                // Datagridview Re-Organiztion
                items_datagridview.Columns[2].Width = 330;
                items_datagridview.ColumnHeadersHeight = 40;
            }
            catch (Exception) { }

        }

        private void previous_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Sale_Table.Rows.Count == 0)
                {
                    return;
                }
                this.currentInvoiceRowIndex = (this.currentInvoiceRowIndex - 1);
                if (this.currentInvoiceRowIndex < 0)
                {
                    this.currentInvoiceRowIndex = 0;
                }

                this.Set_Invoice_Row_Page_Index();

                DataRow rw = this.Sale_Table.Rows[this.currentInvoiceRowIndex];
                this.Fill_Invoice_Fields(rw);

                int id = Convert.ToInt32(this.Sale_Table.Rows[this.currentInvoiceRowIndex]["id"]);

                this.refill_datagridview(id, items_datagridview);
            }
            catch (Exception) { }

        }

        private void next_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Sale_Table.Rows.Count == 0)
                {
                    return;
                }

                this.currentInvoiceRowIndex = (this.currentInvoiceRowIndex + 1);
                if (this.currentInvoiceRowIndex >= this.Sale_Table.Rows.Count)
                {
                    this.currentInvoiceRowIndex = this.Sale_Table.Rows.Count - 1;
                }

                this.Set_Invoice_Row_Page_Index();

                DataRow rw = this.Sale_Table.Rows[this.currentInvoiceRowIndex];
                this.Fill_Invoice_Fields(rw);

                int id = Convert.ToInt32(this.Sale_Table.Rows[this.currentInvoiceRowIndex]["id"]);

                this.refill_datagridview(id, items_datagridview);
            }
            catch (Exception) { }

        }

        private void search_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (invoice_id.Text == "")
                {
                    return;
                }

                int id = Convert.ToInt32(invoice_id.Text);
                int index = 0;
                foreach (DataRow row in this.Sale_Table.Rows)
                {

                    if (Convert.ToInt32(row["id"]).Equals(id))
                    {

                        this.currentInvoiceRowIndex = index;

                        this.Set_Invoice_Row_Page_Index();

                        DataRow rw = this.Sale_Table.Rows[this.currentInvoiceRowIndex];
                        this.Fill_Invoice_Fields(rw);

                        items_datagridview.DataSource = this.Get_All_Invoice_Items(id);

                        break;
                    }

                    index++;
                }
            }
            catch (Exception) { }
        }

        private void items_datagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (e.ColumnIndex == 0)
                {
                    this.items_datagridview.Cursor = Cursors.Hand;
                }
                else
                {
                    this.items_datagridview.Cursor = Cursors.Default;
                }
            } catch ( Exception ) { }
        }

        public void Load_Target_Accounts(int paymentType)
        {

            try
            {
                if (this.Settings.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك تأكد من إعدادات النظام وشجرة الحسابات");
                    return;
                }

                string[] account;
                if (paymentType == 0)
                {
                    // Cash
                    account = Get_Account_Details(this.Settings.Rows[0]["sale_cash_account"].ToString());

                    legend_id.Text = account[0].ToString();
                    legend_number.Text = account[1].ToString();
                    legend_name.Text = account[2].ToString();
                }
                else if (paymentType == 1)
                {
                    // Deferred payment
                    account = Get_Account_Details(this.Settings.Rows[0]["sale_credit_account"].ToString());

                    legend_id.Text = account[0].ToString();
                    legend_number.Text = account[1].ToString();
                    legend_name.Text = account[2].ToString();
                }
                else if (paymentType == 2)
                {
                    // Banks
                    account = Get_Account_Details(this.Settings.Rows[0]["sale_bank_account"].ToString());

                    legend_id.Text = account[0].ToString();
                    legend_number.Text = account[1].ToString();
                    legend_name.Text = account[2].ToString();
                }
            }
            catch (Exception) { }


        }

        private void payment_methods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.payment_methods.SelectedIndex)
                {

                    // Cash 
                    case 0:

                        customer_name.Enabled = false;
                        legend_name.Enabled = true;
                        legend_number.Enabled = true;
                        details.Text = "مردود بضاعه وتم رد المبلغ نقدا";
                        this.Load_Target_Accounts(0);
                        break;

                    // Deferred payment
                    case 1:

                        customer_name.Enabled = true;
                        legend_name.Enabled = true;
                        legend_number.Enabled = true;
                        details.Text = "مردود بضاعه وسيتم رد المبلغ بالأجل";
                        this.Load_Target_Accounts(1);
                        break;

                    // By Network
                    case 2:

                        customer_name.Enabled = false;
                        legend_name.Enabled = true;
                        legend_number.Enabled = true;
                        details.Text = "مردود بضاعه وسيتم رد المبلغ عن طريق البنك";
                        this.Load_Target_Accounts(2);
                        break;

                    // Transfeer 
                    case 3:

                        customer_name.Enabled = false;
                        legend_name.Enabled = true;
                        legend_number.Enabled = true;
                        details.Text = "مردود بضاعه وسيتم رد المبلغ بضاعه عن طريق البنك";
                        this.Load_Target_Accounts(2);
                        break;

                }

                // Case Discount 
                if (discount_value.Text != "")
                {
                    if (dicount_percentage.Text != "")
                    {
                        details.Text += " - بخصم تجاري " + "%" + dicount_percentage.Text;
                    }
                    else
                    {
                        details.Text += " - بخصم تجاري " + discount_value.Text;
                    }
                }
            }
            catch (Exception) { }
        }

        private void legend_name_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (legend_name.Enabled == true)
                {
                    UI.___Accounts accounts = new UI.___Accounts();
                    accounts.InstanceType = 0;
                    accounts.ShowDialog();
                }
            }
            catch (Exception) { }
        }

        private void items_datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (items_datagridview.ReadOnly == true)
                {
                    return;
                }

                if (e.RowIndex == -1)
                {
                    return;
                }
                this.lastRow = e.RowIndex;
                if (e.ColumnIndex == 1 && false == this.is_change_price)
                {


                    string item_code_value = items_datagridview.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    bool is_found = false;


                    foreach (DataRow row in this.Codes.Rows)
                    {

                        if (row["code"].ToString() == item_code_value.ToString())
                        {
                            is_found = true;
                            // Setup Item In Current Row 
                            items_datagridview.Rows[e.RowIndex].Cells["doc_id"].Value = invoice_id.Text.ToString();
                            items_datagridview.Rows[e.RowIndex].Cells["doc_type"].Value = this.documentType;
                            items_datagridview.Rows[e.RowIndex].Cells["product_id"].Value = row["id"].ToString();
                            items_datagridview.Rows[e.RowIndex].Cells["unit_id"].Value = row["unit_id"].ToString();
                            items_datagridview.Rows[e.RowIndex].Cells["factor"].Value = row["factor"].ToString();
                            items_datagridview.Rows[e.RowIndex].Cells["is_out"].Value = false;
                            items_datagridview.Rows[e.RowIndex].Cells["quantity"].Value = "1";
                            items_datagridview.Rows[e.RowIndex].Cells["unit_price"].Value = row["unit_price"].ToString();
                            items_datagridview.Rows[e.RowIndex].Cells["unit_cost"].Value = row["unit_cost"].ToString();
                            items_datagridview.Rows[e.RowIndex].Cells["product_name"].Value = row["name"].ToString();

                            string unit_shortcut = "جرام";
                            foreach (DataRow col in unitName.Rows)
                            {

                                if (Convert.ToInt32(col["id"]).Equals(Convert.ToInt32(row["unit_id"])))
                                {
                                    unit_shortcut = col["shortcut"].ToString();
                                    break;
                                }

                            }

                            items_datagridview.Rows[e.RowIndex].Cells["unit_name"].Value = unit_shortcut.ToString();

                            break;
                        }
                    }

                    if (is_found == false)
                    {
                        foreach (DataGridViewColumn col in items_datagridview.Columns)
                        {

                            if (col.Name.ToString() != "deletion_et_button")
                            {

                                if (col.Name.ToString() == "id" || col.Name.ToString() == "doc_id" || col.Name.ToString() == "doc_type" || col.Name.ToString() == "product_id" || col.Name.ToString() == "unit_id")
                                {
                                    items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = -1;
                                }
                                else if (col.Name.ToString() == "is_out")
                                {
                                    items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = false;
                                }
                                else
                                {
                                    items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = "";
                                }


                            }
                        }
                    }

                }

                // Calcualte Row Of DataGridview 
                this.Calculate_Datagridview_Row(e.RowIndex);

                // Caluclate Total Fields 
                this.Fill_Total_Fields();
            }
            catch (Exception) { }
        }

        private void items_datagridview_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try {
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
            catch (Exception) { }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {

            try {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception) { }
        }

        private void items_datagridview_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
                {
                    return;
                }

                int rowIndex = items_datagridview.CurrentCell.OwningColumn.Index;
                this.lastRow = items_datagridview.CurrentCell.OwningRow.Index;
                if (items_datagridview.CurrentCell.OwningRow.Index == -1) return;

                if (items_datagridview.CurrentCell.OwningColumn.Index == 2)
                {
                    UI.Items ITEMS = new Items(rowIndex, this.documentType, this);
                    ITEMS.ShowDialog();
                }

                if (items_datagridview.CurrentCell.OwningColumn.Index == 3)
                {

                    if (items_datagridview.Rows[items_datagridview.CurrentCell.OwningRow.Index].Cells["product_name"].Value.ToString() == "")
                    {
                        return;
                    }

                    this.is_change_price = true;
                    //UI.Price.Get_Form.ShowDialog();
                }
            }

            catch (Exception) { }
        }

        public void Add_Item_To_Row(int iindex, int id, int rowId = -1)
        {

            try
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
                decimal unit_cost = 0;
                unit_cost = purchase_price;
                string unit_shortcut = "جرام";

                foreach (DataRow col in unitName.Rows)
                {

                    if (Convert.ToInt32(col["id"]) == unit_id)
                    {
                        unit_shortcut = col["shortcut"].ToString();
                        break;
                    }

                }

                //DataGridViewRow drow = items_datagridview.Rows[iindex];
                items_datagridview.Rows[iindex].Cells["id"].Value = rowId.ToString();
                items_datagridview.Rows[iindex].Cells["doc_id"].Value = invoice_id.Text.ToString();
                items_datagridview.Rows[iindex].Cells["doc_type"].Value = this.documentType;
                items_datagridview.Rows[iindex].Cells["product_id"].Value = pid.ToString();
                items_datagridview.Rows[iindex].Cells["product_name"].Value = name.ToString();
                items_datagridview.Rows[iindex].Cells["unit_id"].Value = unit_id.ToString();
                items_datagridview.Rows[iindex].Cells["unit_name"].Value = unit_shortcut.ToString();
                items_datagridview.Rows[iindex].Cells["unit_price"].Value = unit_price.ToString();
                items_datagridview.Rows[iindex].Cells["unit_cost"].Value = unit_cost.ToString();
                items_datagridview.Rows[iindex].Cells["factor"].Value = unit_factor;
                items_datagridview.Rows[iindex].Cells["is_out"].Value = 0;
                items_datagridview.Rows[iindex].Cells["product_code"].Value = item["code"].ToString();

                //drow.Cells["datagrid_id"].Value = "xxxxxxxxxxxxxxx";
                //drow.Cells["total_quantity"].Value = "xxxxxxxxxxxxxxx";
                //drow.Cells["total_price"].Value = "xxxxxxxxxxxxxxx";
            }
            catch (Exception) { }
        }

        public decimal Calculate_Sub_Total()
        {

            decimal value = 0;

            try
            {
                foreach (DataGridViewRow row in items_datagridview.Rows)
                {
                    if (row.Cells["total_price"].Value != System.DBNull.Value && row.Cells["total_price"].Value.ToString() != "")
                    {
                        decimal col = Convert.ToDecimal(row.Cells["total_price"].Value);

                        value = value + col;
                    }
                }
            }
            catch (Exception) { }
            return value;

        }

        public Decimal Extract_Vat(decimal amount)
        {

            return amount - (amount / Convert.ToDecimal(1.15));

        }

        public decimal Get_Vat_Amount()
        {
            decimal vat = 0;
            try
            {
                decimal net = this.Calculate_Sub_Total();
                decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
                decimal netval = net - discount_val;
                vat = this.Extract_Vat(netval);

                if (!price_includ_vat.Checked)
                {
                    vat = (netval * Convert.ToDecimal(1.15)) - netval;
                }

            }
            catch (Exception) { }
            return vat;

        }

        public decimal Calculate_Total_With_Vat()
        {
            decimal total = 0;
            try {
                decimal net = this.Calculate_Sub_Total();
                decimal discount_val = discount_value.Text == "" ? 0 : Convert.ToDecimal(discount_value.Text);
                decimal netval = net - discount_val;
                total = netval;

                if (!price_includ_vat.Checked)
                {
                    total = total * Convert.ToDecimal(1.15);
                }
            } 
            catch (Exception) { }
            return total;
        }

        public void Fill_Total_Fields()
        {

            try
            {
                if (this.is_getting_data == false)
                {
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
                    vat_amount.Text = Math.Round(this.Get_Vat_Amount(), 2).ToString();

                    // Total Value 
                    total_field_text.Text = Math.Round(this.Calculate_Total_With_Vat(), 2).ToString();
                    total_label_text.Text = string.Format("{0:n}", Convert.ToDecimal(Math.Round(this.Calculate_Total_With_Vat(), 2))).ToString();
                }
            }

            catch (Exception) { }
        }

        private void items_datagridview_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

                if (items_datagridview.ReadOnly == true)
                {
                    return;
                }
                this.lastRow = e.RowIndex;


                if (e.ColumnIndex == 2)
                {
                    UI.Items ITEMS = new UI.Items(
                        e.RowIndex, this.documentType, this
                    );
                    ITEMS.ShowDialog();
                }

                if (e.ColumnIndex == 4)
                {

                    if (System.DBNull.Value.Equals(items_datagridview.Rows[this.lastRow].Cells["product_name"].Value))
                    {
                        return;
                    }

                    this.is_change_price = true;

                    int product_id = Convert.ToInt32(items_datagridview.Rows[this.lastRow].Cells["product_id"].Value);

                    UI.ItemUnit item_units = new UI.ItemUnit(
                        this.documentType,
                        product_id,
                        this.Prods,
                        this.unitName,
                        e.RowIndex,
                        this
                    );

                    item_units.ShowDialog();

                }
            } catch (Exception) { }
             
        }

        public void Add_New_Item_Unit(int dataGridIndex, DataTable item_updates)
        {

            try
            {
                if (item_updates.Rows.Count < 1)
                {
                    return;
                }

                foreach (DataRow row in item_updates.Rows)
                {
                    foreach (DataColumn col in item_updates.Columns)
                    {
                        items_datagridview.Rows[dataGridIndex].Cells[col.ToString()].Value = row[col.ToString()];
                    }
                }

                this.is_change_price = false;
            }

            catch (Exception) { }
        }


        private void discount_value_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string value = discount_value.Text;

                if (value == "")
                {
                    discount_value.Text = "";
                }

                if (this.is_string(value))
                {
                    discount_value.Text = "";
                }


                switch (this.payment_methods.SelectedIndex)
                {

                    // Cash 
                    case 0:
                        details.Text = "مردود بضاعه وسيتم رد المبلغ نقدا";
                        break;

                    // Deferred payment
                    case 1:
                        details.Text = "مردود بضاعه وسيتم رد المبلغ بالأجل";
                        break;

                    // By Network
                    case 2:
                        details.Text = "مردود بضاعه وسيتم رد المبلغ عن طريق البنك";
                        break;

                    // Transfeer 
                    case 3:
                        details.Text = "مردود بضاعه وسيتم رد المبلغ عن طريق البنك";
                        break;
                }

                // Case Discount 
                if (discount_value.Text != "")
                {
                    if (dicount_percentage.Text != "")
                    {
                        details.Text += " - بخصم تجاري " + "%" + dicount_percentage.Text;
                    }
                    else
                    {
                        details.Text += " - بخصم تجاري " + discount_value.Text + " ريال سعودي";
                    }
                }

                this.Fill_Total_Fields();
            }
            catch (Exception) { }
        }

        public bool is_string(string value, bool allow_dots = true)
        {

            bool result = false;

            try {
                // Numeric
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsNumber(value[i]) && value[i].ToString() != ".")
                    {
                        result = true;
                        break;
                    }
                }

                // Dot Value 
                int dots = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i].ToString() == ".")
                    {
                        dots = dots + 1;
                    }
                }

                if (dots > 1)
                {
                    result = true;
                }


                if (allow_dots == false && dots > 0)
                {
                    result = true;
                }

            }
            catch (Exception) { }
            return result;
        }

        private decimal discount_percentage_value()
        {
            decimal discount_val = 0;
            try {
                decimal net_total = this.Calculate_Sub_Total();
                discount_val = dicount_percentage.Text == "" ? 0 : (net_total * Convert.ToDecimal(dicount_percentage.Text)) / 100;

                if (discount_not_more_than.Text != "")
                {

                    decimal not_more = Convert.ToDecimal(discount_not_more_than.Text);

                    if (discount_val >= not_more)
                    {
                        discount_val = not_more;
                    }

                }
            } catch (Exception) { }

            return discount_val;
        }

        private void dicount_percentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string value = dicount_percentage.Text;
                if (value == "")
                {
                    dicount_percentage.Text = "";
                }

                if (this.is_string(value, false))
                {
                    dicount_percentage.Text = "";
                }

                if (dicount_percentage.Text == "")
                {
                    discount_value.Text = "";
                    return;
                }

                decimal discount_val = this.discount_percentage_value();

                // new discount value
                discount_value.Text = discount_val.ToString();
            }
            catch (Exception) { }
        }

        public byte[] ImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;

        }

        private void discount_not_more_than_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string value = discount_not_more_than.Text;
                if (value == "")
                {
                    discount_not_more_than.Text = "";
                }

                if (this.is_string(value))
                {
                    discount_not_more_than.Text = "";
                }

                decimal discount_val = this.discount_percentage_value();

                // new discount value
                discount_value.Text = discount_val.ToString();
            }
            catch (Exception) { }
        }

        public string get_resource_code(string resource_id)
        {

            string res_code = "-1";

            DataTable resources = this.Resources;

            foreach (DataRow row in resources.Rows)
            {

                if (row["id"].ToString().Equals(resource_id))
                {
                    res_code = row["resource_code"].ToString();
                }

            }

            return res_code;

        }

        private Image QRCode_Generator()
        {

            /*
             * ===============================================
             * Generating QR Code Image 
             * ===============================================
             */

            // Generate Formated Date 
            string datevalue = datemade.Value.ToString("yyyy-MM-dd");
            string timevalue = datemade.Value.ToString("HH:mm:ss");
            string datetime_value = datevalue + "T" + timevalue;
            PL.QR_Code qrcode = new PL.QR_Code();
            Image qrcimg = qrcode.GeneratedQrCode(
                this.Settings.Rows[0]["establishment_name"].ToString(),
                total_field_text.Text,
                vat_amount.Text,
                datetime_value.ToString(),
                this.Settings.Rows[0]["vat_number"].ToString()
            ).GetGraphic(5);

            return qrcimg;

        }
        private void Store_Invoice_Data()
        {

            try {
                if (total_field_text.Text == "00" || total_field_text.Text == "")
                {
                    return;
                }

                if (invoice_id.Text == "")
                {
                    return;
                }

                if (customer_id.Text == "")
                {
                    customer_id.Text = "-1";
                }

                if (payment_methods.SelectedIndex == 1 && customer_id.Text == "-1")
                {
                    MessageBox.Show("من فضلك قم بإختيار حساب العميل الأجل");
                    return;
                }

                if (this.Settings.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك تأكد من إعدادات النظام وخصوصا شجرة الحسابات");
                    return;
                }

                DataRow setting = this.Settings.Rows[0];
                /*
                 * ===============================================
                 * Build Invoice Items
                 * ===============================================
                 */
                DataTable items = new DataTable();
                this.CRT_DataSet.Tables["Sales_Invoice_Items"].Rows.Clear();
                // add columns 
                items.Columns.Add("doc_id");
                items.Columns.Add("doc_type");
                items.Columns.Add("product_id");
                items.Columns.Add("unit_id");
                items.Columns.Add("is_out");
                items.Columns.Add("product_name");
                items.Columns.Add("unit_name");
                items.Columns.Add("unit_price");
                items.Columns.Add("factor");
                items.Columns.Add("quantity");
                items.Columns.Add("total_quantity");
                items.Columns.Add("datagrid_id");
                items.Columns.Add("product_code");
                items.Columns.Add("total_price");
                items.Columns.Add("unit_cost");
                items.Columns.Add("total_cost");
                //items.Columns.Add("datemade");

                foreach (DataGridViewRow row in items_datagridview.Rows)
                {

                    DataRow rtbl = items.NewRow();
                    DataRow InvoiceItemRow = this.CRT_DataSet.Tables["Sales_Invoice_Items"].NewRow();
                    if (row.Cells["product_name"].Value.ToString() != "")
                    {
                        rtbl["doc_id"] = invoice_id.Text;
                        rtbl["doc_type"] = this.documentType;
                        rtbl["product_id"] = Convert.ToInt32(row.Cells["product_id"].Value);
                        rtbl["unit_id"] = Convert.ToInt32(row.Cells["unit_id"].Value);
                        rtbl["is_out"] = false;
                        rtbl["product_name"] = row.Cells["product_name"].Value.ToString();
                        rtbl["unit_name"] = row.Cells["unit_name"].Value.ToString();
                        rtbl["unit_price"] = row.Cells["unit_price"].Value.ToString();
                        rtbl["factor"] = row.Cells["factor"].Value.ToString();
                        rtbl["quantity"] = row.Cells["quantity"].Value.ToString();
                        rtbl["total_quantity"] = row.Cells["total_quantity"].Value.ToString();
                        rtbl["datagrid_id"] = row.Cells["datagrid_id"].Value.ToString();
                        rtbl["product_code"] = row.Cells["product_code"].Value.ToString();
                        rtbl["total_price"] = row.Cells["total_price"].Value.ToString();
                        rtbl["unit_cost"] = row.Cells["unit_cost"].Value.ToString();
                        rtbl["total_cost"] = row.Cells["total_cost"].Value.ToString();
                        //rtbl["datemade"] = System.DBNull.Value == row.Cells["datemade"].Value ? DateTime.Now: Convert.ToDateTime(row.Cells["datemade"].Value);

                        // BUILD DOCUMENT FOR PRINT  
                        InvoiceItemRow["doc_id"] = invoice_id.Text;
                        InvoiceItemRow["doc_type"] = this.documentType;
                        InvoiceItemRow["product_name"] = row.Cells["product_name"].Value.ToString();
                        InvoiceItemRow["unit_name"] = row.Cells["unit_name"].Value.ToString();
                        InvoiceItemRow["unit_price"] = row.Cells["unit_price"].Value.ToString();
                        InvoiceItemRow["quantity"] = row.Cells["quantity"].Value.ToString();
                        InvoiceItemRow["total_quantity"] = row.Cells["total_quantity"].Value.ToString();
                        InvoiceItemRow["total_price"] = string.Format("{0:n}", Convert.ToDecimal(Math.Round(Convert.ToDecimal(row.Cells["total_price"].Value), 2))).ToString();

                        this.CRT_DataSet.Tables["Sales_Invoice_Items"].Rows.Add(InvoiceItemRow);
                        items.Rows.Add(rtbl);

                    }
                }


                /*
                * ===============================================
                * Build Header Entry
                * ===============================================
                */
                DataTable entry_header = new DataTable();
                entry_header.Columns.Add("id");
                entry_header.Columns.Add("updated_by");
                entry_header.Columns.Add("doc_id");
                entry_header.Columns.Add("doc_type");
                entry_header.Columns.Add("description");
                entry_header.Columns.Add("is_forwarded");
                entry_header.Columns.Add("entry_number");
                entry_header.Columns.Add("updated_date");
                entry_header.Columns.Add("show_balances_in_period");

                DataRow entry_header_row = entry_header.NewRow();
                entry_header_row["id"] = entry_id.Text;
                entry_header_row["updated_by"] = "-1";
                entry_header_row["doc_id"] = invoice_id.Text;
                entry_header_row["doc_type"] = this.documentType;
                entry_header_row["description"] = details.Text.ToString();
                entry_header_row["is_forwarded"] = true;
                entry_header_row["show_balances_in_period"] = false;
                entry_header_row["entry_number"] = Convert.ToDateTime(datemade.Value).Day + "/" + invoice_id.Text;
                entry_header_row["updated_date"] = Convert.ToDateTime(datemade.Value);
                entry_header.Rows.Add(entry_header_row);

                /*
                 * ===============================================
                 * Build Entry Details
                 * ===============================================
                 */
                DataTable entry_details = new DataTable();
                entry_details.Columns.Add("journal_id");
                entry_details.Columns.Add("debit");
                entry_details.Columns.Add("credit");
                entry_details.Columns.Add("description");
                entry_details.Columns.Add("cost_center_number");
                entry_details.Columns.Add("date");
                entry_details.Columns.Add("account_number");

                int salesPaymentType = Convert.ToInt32(payment_methods.SelectedIndex);

                // From 
                if (enable_zakat_taxes.Checked)
                {
                    DataRow salesRow_vat_to = entry_details.NewRow();
                    salesRow_vat_to["journal_id"] = entry_id.Text;
                    salesRow_vat_to["debit"] = Convert.ToDecimal(vat_amount.Text);
                    salesRow_vat_to["description"] = "ض.ق.م مردودات";
                    salesRow_vat_to["cost_center_number"] = "-1";
                    salesRow_vat_to["date"] = Convert.ToDateTime(datemade.Value);
                    salesRow_vat_to["account_number"] = setting["sales_vat_account"].ToString();
                    entry_details.Rows.Add(salesRow_vat_to);
                }

                DataRow salesRow_sales_to = entry_details.NewRow();
                salesRow_sales_to["journal_id"] = entry_id.Text;
                salesRow_sales_to["debit"] = enable_zakat_taxes.Checked ? Convert.ToDecimal(total_without_vat_field.Text) : Convert.ToDecimal(total_field_text.Text);
                salesRow_sales_to["description"] = "مردودات ";
                if (salesPaymentType == 0)
                {
                    salesRow_sales_to["description"] += "نقدا";
                }
                else if (salesPaymentType == 1)
                {
                    salesRow_sales_to["description"] += "أجلة";
                }
                else if (salesPaymentType == 2 || salesPaymentType == 3)
                {
                    salesRow_sales_to["description"] += "عن طريق البنك";
                }
                salesRow_sales_to["cost_center_number"] = "-1";
                salesRow_sales_to["date"] = datemade.Value;
                salesRow_sales_to["account_number"] = setting["return_sales_account"].ToString();
                entry_details.Rows.Add(salesRow_sales_to);


                // TO : 
                DataRow salesRow_from = entry_details.NewRow();
                salesRow_from["journal_id"] = entry_id.Text;
                salesRow_from["credit"] = Convert.ToDecimal(total_field_text.Text);
                salesRow_from["cost_center_number"] = "-1";
                salesRow_from["date"] = datemade.Value;
                if (salesPaymentType == 0)
                {
                    salesRow_from["description"] = "مردود بضاعه وسيتم رد المبلغ نقدا";
                    salesRow_from["account_number"] = setting["sale_cash_account"].ToString();
                }
                else if (salesPaymentType == 1)
                {
                    salesRow_from["description"] = "مردود بضاعه وسيتم رد المبلغ أجل";
                    salesRow_from["account_number"] = setting["sale_credit_account"].ToString();


                    if (legend_number.Text != "")
                    {
                        salesRow_from["account_number"] = legend_number.Text.ToString();
                    }
                }
                else if (salesPaymentType == 2 || salesPaymentType == 3)
                {
                    salesRow_from["description"] = "مردود بضاعه وسيتم رد المبلغ عن طريق البنك";
                    salesRow_from["account_number"] = setting["sale_bank_account"].ToString();
                }

                // Case Discount 
                if (discount_value.Text != "")
                {
                    if (dicount_percentage.Text != "")
                    {
                        salesRow_from["description"] += " - بخصم تجاري " + "%" + dicount_percentage.Text;
                    }
                    else
                    {
                        salesRow_from["description"] += " - بخصم تجاري " + discount_value.Text;
                    }
                }

                entry_details.Rows.Add(salesRow_from);


                // Cost Of Sold Goods 
                decimal cost_total = 0;
                foreach (DataGridViewRow row in items_datagridview.Rows)
                {
                    if (row.Cells["unit_cost"].Value != System.DBNull.Value && row.Cells["unit_cost"].Value.ToString() != "")
                    {
                        Console.WriteLine(row.Cells["total_cost"].Value);
                        cost_total += Convert.ToDecimal(row.Cells["total_cost"].Value);
                    }
                }
                //- FROM: 
                DataRow salesRow_cost_goods_to = entry_details.NewRow();
                salesRow_cost_goods_to["journal_id"] = entry_id.Text;
                salesRow_cost_goods_to["debit"] = Convert.ToDecimal(cost_total);
                salesRow_cost_goods_to["description"] = "إثبات  مردودات  لفاتورة المبيعات";
                salesRow_cost_goods_to["cost_center_number"] = "-1";
                salesRow_cost_goods_to["date"] = datemade.Value;
                salesRow_cost_goods_to["account_number"] = setting["inventory_account"].ToString();
                entry_details.Rows.Add(salesRow_cost_goods_to);

                //- TO: 
                DataRow salesRow_cost_goods = entry_details.NewRow();
                salesRow_cost_goods["journal_id"] = entry_id.Text;
                salesRow_cost_goods["credit"] = Convert.ToDecimal(cost_total);
                salesRow_cost_goods["description"] = "مردودات تكلفة فاتورة المبيعات";
                salesRow_cost_goods["cost_center_number"] = "-1";
                salesRow_cost_goods["date"] = datemade.Value;
                salesRow_cost_goods["account_number"] = setting["cost_of_goods_account"].ToString();
                entry_details.Rows.Add(salesRow_cost_goods);

                /*
                 * ===============================================
                 * Updating Data 
                 * ===============================================
                 */
                if (discount_value.Text.ToString() == "")
                {
                    discount_value.Text = "0";
                }
                Sale.Save_Updates_Sale_Invoice_Data_Set(
                    Convert.ToInt32(invoice_id.Text),
                    Convert.ToInt32(payment_methods.SelectedIndex),
                    Convert.ToInt32(payment_condition.SelectedIndex),
                    Convert.ToInt32(customer_id.Text),
                    Convert.ToInt32(legend_id.Text),
                    legend_number.Text.ToString(),
                    -1, -1,
                    legend_name.Text.ToString(),
                    "",
                    customer_name.Text.ToString(),
                    details.Text.ToString(),
                    net_total.Text.ToString(),
                    discount_value.Text.ToString(),
                    dicount_percentage.Text.ToString(),
                    discount_not_more_than.Text.ToString(),
                    total_without_vat_field.Text.ToString(),
                    total_field_text.Text.ToString(),
                    vat_amount.Text.ToString(),
                    Convert.ToDateTime(datemade.Value),
                    Convert.ToBoolean(price_includ_vat.Checked),
                    Convert.ToBoolean(enable_zakat_taxes.Checked),
                    items,
                    entry_header,
                    entry_details,
                    this.ImageToByteArray(this.QRCode_Generator())
                );


                // Get Last Records
                this.load_invoice_data_tables();

                // Diable Invoices
                this.disable_elements(false);
            } catch (Exception) { }
        }

        private void Print_This_Invoice()
        {

            try
            {
                ReportDocument cryRpt = new ReportDocument();
                string path = Application.StartupPath + "\\Reports\\SalesInvoice.rpt";
                cryRpt.Load(path);
                cryRpt.SetDataSource(this.CRT_DataSet);
                cryRpt.PrintToPrinter(1, false, 0, 0);
            }
             catch (Exception) { }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            this.Store_Invoice_Data();
        }

        public void disable_elements(bool yes = false)
        {
            try
            {
                legend_name.Enabled = yes;
                legend_number.Enabled = yes;
                details.Enabled = yes;
                datemade.Enabled = yes;
                payment_methods.Enabled = yes;
                items_datagridview.ReadOnly = !yes;
                net_total.Enabled = yes;
                discount_value.Enabled = yes;
                dicount_percentage.Enabled = yes;
                discount_not_more_than.Enabled = yes;
                total_without_vat_field.Enabled = yes;
                price_includ_vat.Enabled = yes;
                vat_amount.Enabled = yes;
                total_field_text.Enabled = yes;
                //total_label_text.Enabled = yes;
                enable_zakat_taxes.Enabled = yes;

                // Buttons 
                add_new_button.Enabled = !yes;
                save_button.Enabled = yes;
                first_record_button.Enabled = !yes;
                next_button.Enabled = !yes;
                previous_button.Enabled = !yes;
                last_record_button.Enabled = !yes;
                edit_button.Enabled = !yes;


                items_datagridview.Columns["product_name"].ReadOnly = true;
                //items_datagridview.Columns["unit_price"].ReadOnly = true;
                items_datagridview.Columns["total_price"].ReadOnly = true;
                items_datagridview.Columns["unit_name"].ReadOnly = true;

                if (this.Sale_Table.Rows.Count == 0)
                {
                    edit_button.Visible = false;
                }
                else
                {
                    edit_button.Visible = true;
                }
            }
            catch (Exception) { }
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.is_getting_data = false;
                this.is_updating_data = true;
                this.disable_elements(true);
            }
            catch (Exception) { }
        }

        private void add_new_button_Click(object sender, EventArgs e)
        {
            try
            {
                invoice_id.Text = "";
                this.is_getting_data = false;
                this.disable_elements(true);

                // Clear Current Datagridview 
                foreach (DataGridViewRow row in items_datagridview.Rows)
                {
                    foreach (DataGridViewColumn col in items_datagridview.Columns)
                    {

                        if (col.Name.ToString() != "deletion_et_button")
                        {

                            if (col.Name.ToString() == "datagrid_id")
                            {
                                row.Cells[col.Name.ToString()].Value = Guid.NewGuid().ToString();
                            }
                            else if (col.Name.ToString() == "id" || col.Name.ToString() == "doc_id" || col.Name.ToString() == "doc_type" || col.Name.ToString() == "product_id" || col.Name.ToString() == "unit_id")
                            {
                                row.Cells[col.Name.ToString()].Value = 0;
                            }
                            else if (col.Name.ToString() == "is_out")
                            {
                                row.Cells[col.Name.ToString()].Value = true;
                            }
                            else
                            {
                                row.Cells[col.Name.ToString()].Value = "";
                            }

                        }
                    }
                }

                DataTable table = Sale.Create_Sale_Invoice_Id();

                if (table.Rows.Count > 0)
                {
                    this.Fill_Invoice_Fields(table.Rows[0]);
                }
            }
            catch (Exception) { }


        }

        private void customer_name_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (items_datagridview.ReadOnly == true)
                {
                    return;
                }

                if (customer_name.Enabled == true)
                {
                    UI.FND___Customers Customers = new UI.FND___Customers(this.documentType, this);
                    Customers.ShowDialog();
                }
            }
            catch (Exception) { }
        }


        private void items_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (items_datagridview.ReadOnly == true)
                {
                    return;
                }

                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                {
                    return;
                }

                string colName = items_datagridview.Columns[e.ColumnIndex].Name.ToString();

                if (colName != "deletion_et_button")
                {
                    return;
                }

                // Empty Current Row 
                DataGridViewRow row = items_datagridview.Rows[e.RowIndex];
                foreach (DataGridViewColumn col in items_datagridview.Columns)
                {
                    if (col.Name.ToString() != "deletion_et_button")
                    {

                        if (col.Name.ToString() == "datagrid_id")
                        {
                            row.Cells[col.Name.ToString()].Value = Guid.NewGuid().ToString();
                        }
                        else if (col.Name.ToString() == "id" || col.Name.ToString() == "doc_id" || col.Name.ToString() == "doc_type" || col.Name.ToString() == "product_id" || col.Name.ToString() == "unit_id")
                        {
                            row.Cells[col.Name.ToString()].Value = 0;
                        }
                        else if (col.Name.ToString() == "is_out")
                        {
                            row.Cells[col.Name.ToString()].Value = false;
                        }
                        else
                        {
                            row.Cells[col.Name.ToString()].Value = "";
                        }

                    }
                }
            } catch (Exception) { }
        }

        public void load_invoice_data_tables()
        {
            try {

                // Load DataSet Of Purchase Invoices
                this.dataSetDb = Sale.Get_Sale_Invoice_Data_Set();

                // Extract Tables From DataSet 
                this.Sale_Table = this.dataSetDb.Tables[0];
                this.Sale_Details = this.dataSetDb.Tables[1];
                this.Accounts = this.dataSetDb.Tables[2];
                this.Settings = this.dataSetDb.Tables[3];
                this.Prods = this.dataSetDb.Tables[4];
                this.Codes = this.Load_All_Products_Codes(this.dataSetDb.Tables[4]);
                this.unitName = this.dataSetDb.Tables[5];
                this.Resources = this.dataSetDb.Tables[6];
            } catch (Exception) { }
        }

        private void salesInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                // Load DataSet Of Purchase Invoices
                this.load_invoice_data_tables();

                if (0 != this.Sale_Table.Rows.Count)
                {
                    this.currentInvoiceRowIndex = this.Sale_Table.Rows.Count - 1;
                    DataRow rw = this.Sale_Table.Rows[this.currentInvoiceRowIndex];
                    this.Fill_Invoice_Fields(rw);
                }

                int id = this.Sale_Table.Rows.Count != 0 ? Convert.ToInt32(this.Sale_Table.Rows[this.Sale_Table.Rows.Count - 1]["id"]) : -1;

                items_datagridview.DataSource = Sale.Get_Sale_Invoice_Items(this.documentType, id);


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
                items_datagridview.Columns["unit_cost"].Visible = false;
                items_datagridview.Columns["total_cost"].Visible = false;
                //items_datagridview.Columns["datemade"].Visible = false;

                this.Set_Invoice_Row_Page_Index();

                items_datagridview.Columns["product_code"].HeaderText = "كود الصنف";
                items_datagridview.Columns["product_name"].HeaderText = "الصنف";
                items_datagridview.Columns["unit_name"].HeaderText = "اسم الوحدة";
                items_datagridview.Columns["quantity"].HeaderText = "الكميات";
                items_datagridview.Columns["total_price"].HeaderText = "إجمالي السعر";
                items_datagridview.Columns["unit_price"].HeaderText = "سعر الوحدة";

                items_datagridview.Columns[2].Width = 330;
                items_datagridview.ColumnHeadersHeight = 40;

                items_datagridview.Columns["product_name"].ReadOnly = true;
                items_datagridview.Columns["unit_price"].ReadOnly = true;
                items_datagridview.Columns["total_price"].ReadOnly = true;
                items_datagridview.Columns["unit_name"].ReadOnly = true;

                // Load DataSet Of Crystal Report 


                // Add Button To Remove The Item From invoice 
                this.Load_deletion_icon_in_datagridview();
                this.disable_elements();
            }
            catch (Exception) { }

        }

        private void price_includ_vat_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (enable_zakat_taxes.Checked == false)
                {
                    return;
                }

                this.Fill_Total_Fields();
            }
            catch (Exception) { }

        }

        private void enable_zakat_taxes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (enable_zakat_taxes.Checked == false)
                {
                    total_without_vat_field.Text = total_field_text.Text;
                    vat_amount.Text = "0";
                }
                else
                {
                    this.Fill_Total_Fields();
                }
            }
            catch (Exception) { }
        }

        private void first_record_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Sale_Table.Rows.Count == 0)
                {
                    return;
                }

                this.currentInvoiceRowIndex = this.Sale_Table.Rows.Count - 1;
                this.Set_Invoice_Row_Page_Index();

                DataRow rw = this.Sale_Table.Rows[this.currentInvoiceRowIndex];
                this.Fill_Invoice_Fields(rw);

                int id = Convert.ToInt32(this.Sale_Table.Rows[this.currentInvoiceRowIndex]["id"]);

                this.refill_datagridview(id, items_datagridview);
            }
            catch (Exception) { }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Build_Data_Set_Of_Crystal_Report()
        {

            try
            {
                this.CRT_DataSet.Tables["System_Settings"].Rows.Clear();
                this.CRT_DataSet.Tables["Sales_Invoice"].Rows.Clear();

                // Sales Data             
                DataRow SalesRow = this.CRT_DataSet.Tables["Sales_Invoice"].NewRow();
                SalesRow["id"] = invoice_id.Text.ToString();
                SalesRow["date"] = datemade.Value;
                SalesRow["customer_name"] = customer_name.Text.ToString();
                SalesRow["price_include_vat"] = price_includ_vat.Text.ToString();
                SalesRow["net_total"] = net_total.Text.ToString();
                SalesRow["discount_name"] = discount_value.Text.ToString();
                if (discount_value.Text.ToString() == "")
                {
                    SalesRow["discount_name"] = "0.00";
                }
                SalesRow["total_without_vat"] = total_without_vat_field.Text.ToString();
                SalesRow["total_with_vat"] = total_label_text.Text.ToString();
                SalesRow["vat_amount"] = vat_amount.Text.ToString();
                SalesRow["serial"] = invoice_serial.Text.ToString();
                SalesRow["enabled_zakat_vat"] = enable_zakat_taxes.Checked;
                SalesRow["qrcode"] = this.ImageToByteArray(this.QRCode_Generator());
                this.CRT_DataSet.Tables["Sales_Invoice"].Rows.Add(SalesRow);

                // Sales Items 


                // System Settings 
                if (this.Settings.Rows.Count != 0)
                {

                    DataRow SettingsRow = this.Settings.Rows[0];
                    DataRow settingsr = this.CRT_DataSet.Tables["System_Settings"].NewRow();
                    settingsr["establishment_name"] = SettingsRow["establishment_name"];
                    settingsr["address"] = SettingsRow["address"];
                    settingsr["vat_number"] = SettingsRow["vat_number"];
                    settingsr["logo"] = SettingsRow["logo"];
                    this.CRT_DataSet.Tables["System_Settings"].Rows.Add(settingsr);

                }
            }
            catch (Exception ){ }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Store_Invoice_Data();
                this.Build_Data_Set_Of_Crystal_Report();
                this.Print_This_Invoice();
            }
            catch (Exception) { }

        }
    }
}
