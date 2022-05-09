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

        DataTable Document_Table;
        DataTable Document_Details;
        DataTable Accounts;
        DataTable Settings;
        DataTable Prods;
        DataTable Codes;
        DataTable unitName; 

        public Export_Document()
        {

             
            InitializeComponent();

            this.load_invoice_data_tables();

            // Get All Export Documents 
            this.Load_All_Documents();

            // Get All Documents 
            this.Load_All_Items();

            int id = -1;
            if (Exep_id.Text == "") {
                id = -1;
            }

            // Fill All Information 
            this.Load_DataGridView_And_Items(id);

        }

        public void Load_All_Documents() {

        }

        public void Load_All_Items() {

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
            items_datagridview.Columns["product_code"].Visible = true;
            items_datagridview.Columns["product_name"].Visible = true;
            //items_datagridview.Columns["unit_price"].Visible = true;
            items_datagridview.Columns["quantity"].Visible = true;
            items_datagridview.Columns["unit_name"].Visible = true;
            //items_datagridview.Columns["total_price"].Visible = true;
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

        }
    }
}
