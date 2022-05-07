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
    public partial class Current_Quantities : Form
    {
        DSet.Inventory Inventory = new DSet.Inventory();
        PL.Products prod = new PL.Products();
        DataSet tables;
        DataTable OutGoing;
        DataTable InComing;
        DataTable Products;
        DataTable Product_Units;

        public Current_Quantities()
        {
            InitializeComponent();
        }

        public string Extract_Unit_Name( int id ) {
            string unitName = "";
            foreach (DataRow row in this.Product_Units.Rows) {
                if (Convert.ToInt32(row["id"]).Equals(id)) {
                    unitName = row["shortcut"].ToString();
                    break;
                }
            }
            return unitName;
        }

        public DataTable Extract_OutGoing_Row(int product_id) {
            
            DataTable table = new DataTable();
            table.Columns.Add("product_id");
            table.Columns.Add("product_name");
            table.Columns.Add("total_quantity_min");
            table.Columns.Add("total_quantity_max");
            table.Columns.Add("min_unit_name");
            table.Columns.Add("max_unit_name");
            DataRow row;

            foreach (DataRow rox in this.OutGoing.Rows) {
                if (Convert.ToInt32(rox["product_id"]).Equals(product_id)) {
                    row = table.NewRow();
                    row["product_id"] = rox["product_id"];
                    row["product_name"] = rox["product_id"];
                    row["total_quantity_min"] = rox["product_id"];
                    row["total_quantity_max"] = rox["product_id"];
                    row["min_unit_name"] = rox["product_id"];
                    row["max_unit_name"] = rox["product_id"];
                    table.Rows.Add(row);
                    break;
                }
                
            }
             
            return table;
        }

        private void Current_Quantities_Load(object sender, EventArgs e)
        {
            this.tables = prod.Get_Inventory_Details();

            if (this.tables.Tables.Count < 4) {
                return;
            }

            this.InComing = this.tables.Tables[0];
            this.OutGoing = this.tables.Tables[1];
            this.Products = this.tables.Tables[2];
            this.Product_Units = this.tables.Tables[3];

            for (int i = 0; i < this.InComing.Rows.Count; i++) {
                DataRow comming = this.InComing.Rows[i]; 
                DataTable tbl = this.Extract_OutGoing_Row(Convert.ToInt32(comming["product_id"]));

                decimal total_quantity = 0;

                if (tbl.Rows.Count != 0 )
                {
                    // Incoming - Outgoing = total quantity in inventory 
                    DataRow going = tbl.Rows[0];

                    total_quantity = Convert.ToDecimal(comming["total_quantity"]) - Convert.ToDecimal(going["total_quantity"]);
                }
                else {
                    // Only Incomming 
                    total_quantity = Convert.ToDecimal(comming["total_quantity"]);
                }

                Console.WriteLine("The total is : " + total_quantity);
            }

        }
    }
}
