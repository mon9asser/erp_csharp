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
    public partial class ItemUnit : Form
    {
         
        private int doc_type = -1;
        private int datagrid_row_index = -1;
        private int product_id; 
        DataTable products;
        DataTable units;
         
        public ItemUnit(int type, int product_id, DataTable products, DataTable units, int index)
        {

            InitializeComponent();

            this.doc_type = type;
            this.product_id = product_id;
            this.products = products;
            this.units = units;
            this.datagrid_row_index = index;
            
            this.load_combo_box();
            this.load_item_name();
            this.load_dataGrid_prices();

        }

        public void load_item_name() { 
            
        }

        public void load_combo_box() {
            
            if (this.doc_type == 0) {
                combobox_price_type.SelectedIndex = 1;
            }

            if (this.doc_type == 1)
            {
                combobox_price_type.SelectedIndex = 0;
            }

        }

        public void load_dataGrid_prices() {

            string productName = "";
            
            foreach (DataRow row in this.products.Rows) {
                if (Convert.ToInt32(row["id"]) == this.product_id) {
                    productName = row["name"].ToString();
                }
            }
             
            this.Text = productName;
        }

        public string extract_unit_name( int id ) {
            
            string unitName = "";

            foreach (DataRow row in this.units.Rows) {
                if (Convert.ToInt32(row["id"]).Equals(id)) {
                    unitName = row["shortcut"].ToString();
                    break;
                }
            }

            return unitName;

        }

        

        private DataTable get_price_type( int price_type ) {

            DataTable current_item = new DataTable();

            // Columns 
            current_item.Columns.Add("code");
            current_item.Columns.Add("unit_id"); 
            current_item.Columns.Add("unit_shortcut");
            current_item.Columns.Add("factor");
            current_item.Columns.Add("unit_price");
            current_item.Columns.Add("unit_cost"); 

            DataRow item_row;
            foreach (DataRow row in this.products.Rows)
            {

                if (Convert.ToInt32(row["id"]).Equals(this.product_id))
                {
                    item_row = current_item.NewRow(); 
                    if (row["purchase_price"].ToString() == "" || row["purchase_price"].ToString() == "") {
                        continue;
                    }

                    // Basic Price 
                    item_row["code"] = row["code"];
                    item_row["unit_id"] = row["unit_id"];
                    item_row["unit_shortcut"] = this.extract_unit_name(Convert.ToInt32(row["unit_id"]));
                    item_row["factor"] = 1;
                    item_row["unit_price"] = row["purchase_price"];
                    item_row["unit_cost"] = row["purchase_price"];

                    if (this.doc_type == 0 ) {
                        item_row["unit_id"] = row["default_sale_price"];
                    }

                    // Setup according to price type 
                    if (price_type == 0) {
                        item_row["unit_price"] = row["purchase_price"];
                    }

                    if (price_type == 1)
                    {
                        item_row["unit_price"] = row["default_sale_price"];
                    }

                    if (price_type == 2)
                    {
                        item_row["unit_price"] = row["less_sale_price"];
                    }

                    if (price_type == 3)
                    {
                        item_row["unit_price"] = row["wholesale_sale"];
                    }
                     
                    current_item.Rows.Add(item_row);



                    // The Six Prices
                    DataRow six_rows;
                    for (int i = 1; i <= 6; i++) {
                        
                        if (row["gr" + i + "_purchase_price"].ToString() == "0" || row["gr" + i + "_sale_price"].ToString() == "0") {
                            continue;
                        }

                        six_rows = current_item.NewRow();
                        six_rows["code"] = row["gr" + i + "_barcode"];
                        six_rows["unit_id"] = row["unit_id"];
                        six_rows["unit_shortcut"] = this.extract_unit_name(Convert.ToInt32(row["gr"+i+"_unit_id"]));
                        six_rows["factor"] = row["gr" + i + "_transform"];
                        six_rows["unit_price"] = row["gr" + i + "_purchase_price"];
                        six_rows["unit_cost"] = row["gr" + i + "_purchase_price"];

                        if (this.doc_type == 0)
                        {
                            six_rows["unit_id"] = row["gr" + i + "_sale_price"];
                        }

                        // Setup according to price type 
                        if (price_type == 0)
                        {
                            six_rows["unit_price"] = row["gr" + i + "_purchase_price"];
                        }

                        if (price_type == 1)
                        {
                            six_rows["unit_price"] = row["gr" + i + "_sale_price"];
                        }

                        if (price_type == 2)
                        {
                            six_rows["unit_price"] = row["gr" + i + "_less_sale_price"];
                        }

                        if (price_type == 3)
                        {
                            six_rows["unit_price"] = row["gr" + i + "_wholesale_sale"];
                        }

                        current_item.Rows.Add(six_rows);
                    }

                        
                    break;
                }

            }

            return current_item;

        }

        private void ItemUnit_Load(object sender, EventArgs e)
        {
            this.datagridprices_items.DataSource = this.get_price_type(combobox_price_type.SelectedIndex);
            
            this.datagridprices_items.Columns["code"].Visible = false;
            this.datagridprices_items.Columns["unit_id"].Visible = false;
            this.datagridprices_items.Columns["factor"].Visible = false;
            this.datagridprices_items.Columns["unit_cost"].Visible = false;
            this.datagridprices_items.Columns["unit_shortcut"].HeaderText= "الوحدة";
            this.datagridprices_items.Columns["unit_price"].HeaderText = "سعر الوحدة";
            this.datagridprices_items.Columns["unit_shortcut"].Width = 200;

            foreach ( DataGridViewColumn col in this.datagridprices_items.Columns) {
                col.ReadOnly = true;
            }
 
            
        }
          

        private void combobox_price_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.datagridprices_items.DataSource = this.get_price_type(combobox_price_type.SelectedIndex);
        }
 

        private void datagridprices_items_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            DataTable currentItem = new DataTable();
            currentItem.Columns.Add("product_id");
            currentItem.Columns.Add("product_code");
            currentItem.Columns.Add("unit_id");
            currentItem.Columns.Add("factor");
            currentItem.Columns.Add("unit_cost");
            currentItem.Columns.Add("unit_name");
            currentItem.Columns.Add("unit_price"); 

            DataRow row = currentItem.NewRow();              
            row["product_id"] = this.product_id;
            row["product_code"] = datagridprices_items.Rows[e.RowIndex].Cells["code"].Value.ToString();
            row["unit_id"] = datagridprices_items.Rows[e.RowIndex].Cells["unit_id"].Value.ToString();
            row["factor"] = datagridprices_items.Rows[e.RowIndex].Cells["factor"].Value.ToString();
            row["unit_cost"] = datagridprices_items.Rows[e.RowIndex].Cells["unit_cost"].Value.ToString();
            row["unit_name"] = datagridprices_items.Rows[e.RowIndex].Cells["unit_shortcut"].Value.ToString();
            row["unit_price"] = datagridprices_items.Rows[e.RowIndex].Cells["unit_price"].Value.ToString();
            currentItem.Rows.Add(row);

            switch (this.doc_type)
            {

                case 1:
                    UI.purchaseInvoice.GetForm.Add_New_Item_Unit(this.datagrid_row_index, currentItem );
                    break;

                case 0:
                    /**
                     * 
                     * Here We Need To Get First Unit Cost ( First In First Out )
                     */
                    // UI.salesInvoice.GetForm.Add_New_Item_Unit(this.datagrid_row_index, currentItem);
                    break;

            }

            this.Close();
        }
    }
}
