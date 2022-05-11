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
    public partial class Export_Document : Form
    {
        PL.DailyEntries Exep = new PL.DailyEntries();
        DataSet dataSetDb;
        public bool is_out = true;
        public int documentType = 6;
        public int lastRow = -1;
        DataTable Document_Table;
        DataTable Document_Details;
        DataTable Accounts;
        DataTable Settings;
        DataTable Prods;
        DataTable Codes;
        DataTable unitName;
        public bool is_getting_data = true; 
        public bool is_change_price = false;
        public static Export_Document frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Export_Document GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Export_Document();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }
        public Export_Document()
        {
             
            InitializeComponent();

            this.load_invoice_data_tables();

           

            int id = -1;
            if (Exep_id.Text == "") {
                id = -1;
            }

            // Fill All Information 
            this.Load_DataGridView_And_Items(id);
            this.Is_Disabled_Elements(true);
        }
          

        public void Add_Item_To_Row(int iindex, int id, int rowId = -1)
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
            unit_price = purchase_price;
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
             
            items_datagridview.Rows[iindex].Cells["id"].Value = rowId.ToString();
            items_datagridview.Rows[iindex].Cells["doc_id"].Value = Exep_id.Text.ToString();
            items_datagridview.Rows[iindex].Cells["doc_type"].Value = this.documentType;
            items_datagridview.Rows[iindex].Cells["product_id"].Value = pid.ToString();
            items_datagridview.Rows[iindex].Cells["product_name"].Value = name.ToString();
            items_datagridview.Rows[iindex].Cells["unit_id"].Value = unit_id.ToString();
            items_datagridview.Rows[iindex].Cells["unit_name"].Value = unit_shortcut.ToString();
            items_datagridview.Rows[iindex].Cells["unit_price"].Value = unit_price.ToString();
            items_datagridview.Rows[iindex].Cells["unit_cost"].Value = unit_cost.ToString();
            items_datagridview.Rows[iindex].Cells["factor"].Value = unit_factor;
            items_datagridview.Rows[iindex].Cells["is_out"].Value = this.is_out;
            items_datagridview.Rows[iindex].Cells["product_code"].Value = item["code"].ToString(); ;
            items_datagridview.Rows[iindex].Cells["quantity"].Value = "1";


        }

        public DataTable Load_All_Products_Codes(DataTable products)
        {

            DataTable table = new DataTable();
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
                rowDefault["unit_price"] = row["purchase_price"].ToString();
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

            return table;

        }

        public void load_invoice_data_tables()
        {

            // Load DataSet Of Purchase Invoices
            this.dataSetDb = Exep.Get_Withdraw_Document();

            // Extract Tables From DataSet 
            this.Document_Table = this.dataSetDb.Tables[0];
            this.Document_Details = this.dataSetDb.Tables[1];
            this.Accounts = this.dataSetDb.Tables[2];
            this.Settings = this.dataSetDb.Tables[3];
            this.Prods = this.dataSetDb.Tables[4];
            this.Codes = this.Load_All_Products_Codes(this.dataSetDb.Tables[4]);
            this.unitName = this.dataSetDb.Tables[5];

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

            table.Columns.Add("unit_cost");
            table.Columns.Add("total_cost");
            //table.Columns.Add("datemade");

            table.Columns["product_code"].SetOrdinal(0);
            table.Columns["product_name"].SetOrdinal(1);
            table.Columns["unit_price"].SetOrdinal(2);
            table.Columns["quantity"].SetOrdinal(3);
            table.Columns["unit_name"].SetOrdinal(4);
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

            foreach (DataRow row in this.Document_Details.Rows)
            {

                if (Convert.ToInt32(row["doc_id"]).Equals(invoiceId))
                {
                    rox = table.NewRow();

                    foreach (DataColumn col in this.Document_Details.Columns)
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
                foreach (DataColumn col in this.Document_Details.Columns)
                {

                    if (col.GetType().ToString() == "Int32")
                    {
                        emptyRow[col] = 0;
                    }

                    if (col.GetType().ToString() == "String")
                    {
                        emptyRow[col] = "";
                    }

                    if (col.ToString() == "datagride_id")
                    {
                        emptyRow[col] = Guid.NewGuid().ToString();
                    }

                    /*
                     * if (col.ToString() == "datemade")
                    {
                        emptyRow[col] = DateTime.Now;
                    }*/


                }

                table.Rows.Add(emptyRow);
            }

            return table;

        }

        public void Load_DataGridView_And_Items(int id) {

             
            DataTable items = this.Get_All_Invoice_Items(id);
            items_datagridview.DataSource = items;
            items_datagridview.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
            //items_datagridview.Columns["unit_price"].Visible = true;
            //items_datagridview.Columns["total_price"].Visible = true;
            items_datagridview.Columns["product_code"].Visible = true;
            items_datagridview.Columns["product_name"].Visible = true;
            items_datagridview.Columns["quantity"].Visible = true;
            items_datagridview.Columns["unit_name"].Visible = true;

            items_datagridview.Columns["product_code"].HeaderText = "كود الصنف";
            items_datagridview.Columns["product_name"].HeaderText = "إسم الصنف";
            items_datagridview.Columns["quantity"].HeaderText = "الكميات";
            items_datagridview.Columns["unit_name"].HeaderText = "الوحدة";

            DataGridViewButtonColumn deletion_button = new DataGridViewButtonColumn();
            deletion_button.FlatStyle = FlatStyle.Flat;
            deletion_button.HeaderText = "حذف";
            deletion_button.Name = "deletion_button";
            deletion_button.Text = "حذف";
            deletion_button.UseColumnTextForButtonValue = true;
            items_datagridview.Columns.Add(deletion_button);
            items_datagridview.Columns["product_name"].Width = 400;

        }
         
    
        
        private void save_button_Click(object sender, EventArgs e)
        {

            Console.WriteLine(total_price_field.Text);
            Console.WriteLine(total_quantity_field.Text);
             
            // Disable Elements 
            this.Is_Disabled_Elements(false);

        }

        public void Load_All_Fields_With_Ids(DataRow row ){

            Exep_id.Text = row["id"].ToString();
            date_made.Value = ( System.DBNull.Value == row["date_made"]) ? DateTime.Now: Convert.ToDateTime(row["date_made"]);
            details.Text = row["details"].ToString();
            account_number.Text = row["account_number"].ToString();
            account_name.Text = row["account_name"].ToString();
            total_quantity_field.Text = row["total_quantity"].ToString();
            total_price_field.Text = row["total_price"].ToString();
            journal_id.Text = row["id1"].ToString(); 

        }

        public void Is_Disabled_Elements( bool is_disabled ) {

            Exep_id.Enabled = !is_disabled;
            date_made.Enabled = !is_disabled;
            details.Enabled = !is_disabled;
            account_number.Enabled = !is_disabled;
            account_name.Enabled = !is_disabled;
            total_quantity_field.Enabled = !is_disabled;
            total_price_field.Enabled = !is_disabled;
            journal_id.Enabled = !is_disabled;
            items_datagridview.ReadOnly = is_disabled;
             
            save_button.Enabled = !is_disabled; 
            current_invoice_page.Enabled = is_disabled;
            add_new_btn.Enabled = is_disabled; 
            first_record_button.Enabled = is_disabled;
            next_button.Enabled =  is_disabled;
            previous_button.Enabled =  is_disabled;
            last_record_button.Enabled = is_disabled;
            deletion_button.Enabled =  is_disabled;

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            this.is_getting_data = false;

            DataTable table = Exep.Create_Exp_Doucment_Id();
            if (table.Rows.Count == 0)
            {
                return;
            }

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
                            row.Cells[col.Name.ToString()].Value = this.is_out;
                        }
                        else
                        {
                            row.Cells[col.Name.ToString()].Value = "";
                        }

                    }
                }
            }
               
            this.Load_All_Fields_With_Ids(table.Rows[0]);
            this.Is_Disabled_Elements(false);
        }
         

        public void Add_New_Item_Unit(int dataGridIndex, DataTable item_updates)
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

        

        public decimal Calculate_Sub_Total()
        {

            decimal value = 0;

            foreach (DataGridViewRow row in items_datagridview.Rows)
            {
                if (row.Cells["total_price"].Value != System.DBNull.Value && row.Cells["total_price"].Value.ToString() != "")
                {
                    decimal col = Convert.ToDecimal(row.Cells["total_price"].Value);

                    value = value + col;
                }
            }

            return value;

        }


        public decimal Calculate_Quantities()
        {

            decimal value = 0;

            foreach (DataGridViewRow row in items_datagridview.Rows)
            {
                if (row.Cells["total_quantity"].Value != System.DBNull.Value && row.Cells["total_quantity"].Value.ToString() != "")
                {
                    decimal col = Convert.ToDecimal(row.Cells["total_quantity"].Value);

                    value = value + col;
                }
            }

            return value;

        }

        public void Fill_Total_Fields()
        {

            if (this.is_getting_data == false)
            {
                decimal price = this.Calculate_Sub_Total();
                decimal quantities = this.Calculate_Quantities();

                total_price_field.Text = price.ToString();
                total_quantity_field.Text = quantities.ToString();
                total_quantity.Text = quantities.ToString();

            }
        }

        public void Calculate_Datagridview_Row(int index)
        {

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

        private void items_datagridview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
            {
                return;
            }


            if (items_datagridview.CurrentCell.OwningRow.Index == -1) return;

            UI.Items.GetForm.DGRowIndex = items_datagridview.CurrentCell.OwningRow.Index; 

            UI.Items.GetForm.doc_type = this.documentType;

            if (items_datagridview.CurrentCell.OwningColumn.Index == 2)
            {
                UI.Items.GetForm.ShowDialog();
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
         

        void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void items_datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (items_datagridview.ReadOnly == true)
            {
                return;
            }


            if (e.RowIndex == -1)
            {
                return;
            } 

            // Calculate Items 
            this.Calculate_Datagridview_Row(e.RowIndex);

            // Caluclate Total Fields 
            this.Fill_Total_Fields();

        }

        private void items_datagridview_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress); 
            bool isCol = items_datagridview.CurrentCell.ColumnIndex == 4;

            if (isCol) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void items_datagridview_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (items_datagridview.ReadOnly == true)
            {
                return;
            }

            if (e.ColumnIndex == 1 || e.ColumnIndex == 2) {
                UI.Items item = new UI.Items(e.RowIndex, this.documentType, this);
                item.ShowDialog();
            }

            if (e.ColumnIndex == 5)
            {

                if (System.DBNull.Value.Equals(items_datagridview.Rows[e.RowIndex].Cells["product_name"].Value))
                {
                    return;
                }

                this.is_change_price = true;

                int product_id = Convert.ToInt32(items_datagridview.Rows[e.RowIndex].Cells["product_id"].Value);

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

        }

        private void items_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //xxxxxxxxxxx
        }

        private void items_datagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //xxxxxxxxxxxxxxxxxxx
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Is_Disabled_Elements(true);
        }

        private void items_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 0 )
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
                        row.Cells[col.Name.ToString()].Value = this.is_out;
                    }
                    else
                    {
                        row.Cells[col.Name.ToString()].Value = "";
                    }

                }
            }
        }
    }
}
