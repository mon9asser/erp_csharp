using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable table = new DataTable();

            // Define Table Columns 
            table.Columns.Add("account_number", typeof(String));
            table.Columns.Add("account_name", typeof(String));
            table.Columns.Add("parent_account", typeof(String));

            // Assets 
            DataRow assets_rw = table.NewRow();
            assets_rw["account_number"] = "100";
            assets_rw["account_name"] = "Assets";
            assets_rw["parent_account"] = "0";
            table.Rows.Add(assets_rw);

            // Current Assets 
            DataRow current_assets_rw = table.NewRow();
            current_assets_rw["account_number"] = "110";
            current_assets_rw["account_name"] = "Current Assets";
            current_assets_rw["parent_account"] = "100";
            table.Rows.Add(current_assets_rw);

            // Banks Assets 
            DataRow bank_rw = table.NewRow();
            bank_rw["account_number"] = "11001";
            bank_rw["account_name"] = "Banks";
            bank_rw["parent_account"] = "110";
            table.Rows.Add(bank_rw);

            // Cash Assets 
            DataRow cash_rw = table.NewRow();
            cash_rw["account_number"] = "11002";
            cash_rw["account_name"] = "Cashes";
            cash_rw["parent_account"] = "110";
            table.Rows.Add(cash_rw);

            // Banks Assets 
            DataRow inventory_rw = table.NewRow();
            inventory_rw["account_number"] = "11003";
            inventory_rw["account_name"] = "Inventory";
            inventory_rw["parent_account"] = "110";
            table.Rows.Add(inventory_rw);

            // None Current Assets 
            DataRow none_current_assets_rw = table.NewRow();
            none_current_assets_rw["account_number"] = "120";
            none_current_assets_rw["account_name"] = "None Current Assets";
            none_current_assets_rw["parent_account"] = "100";
            table.Rows.Add(none_current_assets_rw);

            // Liabilities and equity 
            DataRow liabilities_rw = table.NewRow();
            liabilities_rw["account_number"] = "200";
            liabilities_rw["account_name"] = "Liabilities and equity";
            liabilities_rw["parent_account"] = "0";
            table.Rows.Add(liabilities_rw);

            // Liabilities and equity 
            DataRow owner_eq_rw = table.NewRow();
            owner_eq_rw["account_number"] = "300";
            owner_eq_rw["account_name"] = "Owner's Equity";
            owner_eq_rw["parent_account"] = "0";
            table.Rows.Add(owner_eq_rw);

            // Sending Table to procedure  
            string con_string;
            SqlConnection cnn;
            con_string = @"Data Source=.\SQLEXPRESS;Initial Catalog=dbtest; Integrated Security =true";
            cnn = new SqlConnection(con_string);
            cnn.Open(); 
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "table_valued_parameter";
            sqlcmd.Connection = cnn;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@table_params", SqlDbType.Structured);
            param[0].Value = table;
            sqlcmd.Parameters.AddRange(param);
            sqlcmd.ExecuteNonQuery();
            cnn.Close();

        }
    }
}
