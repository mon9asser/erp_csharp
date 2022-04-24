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
    public partial class FRM_UpdateStore : Form
    {

        PL.Stores storing = new PL.Stores();
        private int store_id = -1;
        private string code = null;
        private FRM_Stores store_obj;
        private DataTable TableSource;
        public FRM_UpdateStore()
        {
            InitializeComponent();
        }

        public FRM_UpdateStore( DataTable table, FRM_Stores FRM_Store)
        {
             
            InitializeComponent();

            if (table.Rows.Count == 0)
            {
                this.Close();
                return;
            }

            this.store_id = Convert.ToInt32(table.Rows[0]["id"]);
            this.code = table.Rows[0]["code"].ToString();
            this.TableSource = table; 
            this.store_obj = FRM_Store; 
            this.Fill_Data_Table_Fields();
        }

        private string get_cost_center_name_by_id(int cost_center_id) {
            string name = "Name";
            //--- CODE HERE---
            return name;
        }

        private void Fill_Data_Table_Fields() {

            DataRow row = this.TableSource.Rows[0];

            id_field.Text = row["id"].ToString();
            code_field.Text = row["code"].ToString();
            store_name_field.Text = row["store_name"].ToString();
            branch_name_field.Text = row["store_branch"].ToString();
            tel_field.Text = row["telephone"].ToString();
            email_field.Text = row["fax"].ToString();
            cost_center_id_field.Text = row["cost_center_id"].ToString();

            if (row["cost_center_id"] != DBNull.Value) { 
                cost_center_name_field.Text = this.get_cost_center_name_by_id(Convert.ToInt32(row["cost_center_id"]) );
            }

            address_field.Text = row["address"].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            this.storing.Update_Data_Of_Stores(
                Convert.ToInt32(id_field.Text), 
                store_name_field.Text.ToString(),
                branch_name_field.Text.ToString(),
                tel_field.Text.ToString(),
                address_field.Text.ToString(),
                email_field.Text.ToString(),
                cost_center_id_field.Text.ToString()
            );

            this.store_obj.load_datagridview_stores();
            this.Close();

        }
    }
}
