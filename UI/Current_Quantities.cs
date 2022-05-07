using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace sales_management.UI
{
    public partial class Current_Quantities : Form
    {
        ReportDocument cryRpt = new ReportDocument();
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

            // Load Document Source 
            string path = Application.StartupPath + "\\Reports\\Inventory_Report.rpt";
            this.cryRpt.Load(path); 

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

        public DataTable Extract_OutGoing_InComing_Row(int product_id, bool is_outgoing = true ) {

            DataTable currentTable = this.OutGoing;
            if (is_outgoing == false) {
                currentTable = this.InComing;
            }

            DataTable table = new DataTable();
            table.Columns.Add("product_id");
            table.Columns.Add("product_name");
            table.Columns.Add("total_quantity"); 
            DataRow row;

            foreach (DataRow rox in currentTable.Rows) {

                if (Convert.ToInt32(rox["product_id"]).Equals(product_id)) {

                    row = table.NewRow();
                    row["product_id"] = rox["product_id"];
                    row["product_name"] = rox["product_name"];
                    row["total_quantity"] = rox["total_quantity"]; 
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
            decimal all_totals = 0; 

            if ( this.Products.Rows.Count != 0 ) {

                foreach (DataRow prods in this.Products.Rows ) {

                    int product_id = Convert.ToInt32(prods["id"]);
                    DataTable in_coming = this.Extract_OutGoing_InComing_Row(product_id, false);
                    DataTable out_going = this.Extract_OutGoing_InComing_Row(product_id, true);

                    decimal incoming_quantity = 0;
                    decimal outgoing_quantity = 0;
                    

                    if (in_coming.Rows.Count != 0 )
                    {
                        incoming_quantity = Convert.ToDecimal(in_coming.Rows[0]["total_quantity"]);
                    }

                    if (out_going.Rows.Count != 0)
                    {
                        outgoing_quantity = Convert.ToDecimal(out_going.Rows[0]["total_quantity"]);
                    }

                    // Givens 
                    int basic_unit_id = prods["unit_id"].ToString() == "" ? -1:  Convert.ToInt32(prods["unit_id"]);
                    int last_unit_id = -1;
                    int last_transform = -1;

                    // Quantity in minimum unit 
                    // ----------------------------------------------------------------

                    decimal total_qty = incoming_quantity - outgoing_quantity;
                    string unit_name = "";

                    decimal total_qty_max = 0;
                    string unit_max_name = "";
                    
                    // ----------------------------------------------------------------

                    for ( int i=6; i >= 1; i-- ) {

                        last_unit_id = Convert.ToInt32(prods["gr" + i + "_unit_id"]);
                        last_transform  = Convert.ToInt32(prods["gr" + i + "_transform"]);

                        if (Convert.ToInt32(prods["gr" + i + "_transform"]) != 1) {
                            break;
                        }

                    }

                    // Calcualte the last transform 
                    if (total_qty != 0) {
                        total_qty_max = Convert.ToDecimal(total_qty) / Convert.ToDecimal(last_transform);
                    }

                   

                    // Exctact Unit Shortcut 
                    unit_name = this.Extract_Unit_Name(basic_unit_id);
                    unit_max_name = this.Extract_Unit_Name(last_unit_id);
                    all_totals += total_qty; 

                    // Start To Fill Data 
                    DataRow DSetRow = Inventory.Tables["Inventory"].NewRow();
                    DSetRow["product_id"] = product_id;
                    DSetRow["product_name"] = prods["name"].ToString();
                    DSetRow["total_quantity_min"] = string.Format("{0:n}", Convert.ToDecimal(total_qty)).ToString();
                    DSetRow["total_quantity_max"] = string.Format("{0:n}", Convert.ToDecimal(total_qty_max)).ToString();
                    DSetRow["min_unit_name"] = unit_name.ToString();
                    DSetRow["max_unit_name"] = unit_max_name.ToString();
                    Inventory.Tables["Inventory"].Rows.Add(DSetRow);

                    
                }

            }

            // Set all totals 
            DataRow rowTota = this.Inventory.Tables["Totals"].NewRow();
            rowTota["total_field"] = string.Format("{0:n}", Convert.ToDecimal(all_totals)).ToString();             this.Inventory.Tables["Totals"].Rows.Add(rowTota);

            // Load Crystal Report 
            this.cryRpt.SetDataSource(this.Inventory);
            this.cryRpt.Refresh();
            crystalReportViewer1.ReportSource = this.cryRpt;

             

        }
    }
}
