using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{
    class Sales
    {
        public DataTable Create_Sales_Invoice_Id( int id ) {
            
            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            table = DAL.SelectData("Create_Sales_Invoice_Id", param);
            DAL.Close();
            
            return table;

        }

        public DataTable Get_All_Sales_Invoices() {

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DAL.Open();
            table = DAL.SelectData("Get_All_Sales_Invoices", null );
            DAL.Close();

            return table;
        }

        public DataTable Get_All_Sales_Invoice_Details() {

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[0].Value = 0;

            DAL.Open();
            table = DAL.SelectData( "Get_All_Sales_Invoice_Details", param );
            DAL.Close();

            return table;
        }

        public DataTable Get_Sales_Invoice_Items_details(int invoiceType, int invoiceId) {
            DataTable table = new DataTable();

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[0].Value = invoiceType;

            param[1] = new SqlParameter("@invoice_id", SqlDbType.Int);
            param[1].Value = invoiceId;

            DAL.Open();
            table = DAL.SelectData("Get_Sales_Invoice_Items", param);
            DAL.Close();
            return table;
        }

        public DataTable Get_Sales_Invoice_Items( int invoiceType , int invoiceId) {
            
            DataTable table = new DataTable();

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[0].Value = invoiceType;

            param[1] = new SqlParameter("@invoice_id", SqlDbType.Int);
            param[1].Value = invoiceId;

            DAL.Open();
            table = DAL.SelectData( "Get_Sales_Invoice_Items", param );

            // Change Indexes Here 
            table.Columns["product_code"].SetOrdinal(0);
            table.Columns["product_name"].SetOrdinal(1);
            table.Columns["unit_price"].SetOrdinal(2);
            table.Columns["unit_name"].SetOrdinal(3);
            table.Columns["quantity"].SetOrdinal(4);
            table.Columns["total_price"].SetOrdinal(5);
                          
            DataRow emptyRow;
            for (int i = 0; i < 15; i++)
            {

                emptyRow = table.NewRow();
                foreach (DataColumn col in table.Columns)
                {

                    if (col.GetType().ToString() == "Int32") {
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

            DAL.Close();
             
            return table;

        }

        public void Save_Updates_Invoice_Data(
            int id,
            int payment_method,
            int payment_condition_id,
            int customer_id,
            int account_id,
            int account_number,
            int cost_center_id,
            int cost_center_number,
            string account_name,
            string cost_center_name,
            string customer_name,
            string details,
            string net_total,
            string discount_name,
            string discount_percentage,
            string discount_not_more,
            string total_without_vat,
            string total_with_vat,
            string vat_amount,
            DateTime date,
            bool price_include_vat
        ) {

            // Update Invoice Data 
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[22];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@payment_method", SqlDbType.Int);
            param[1].Value = payment_method;

            param[2] = new SqlParameter("@date", SqlDbType.DateTime);
            param[2].Value = date;

            param[3] = new SqlParameter("@details", SqlDbType.VarChar);
            param[3].Value = details;

            param[4] = new SqlParameter("@payment_condition_id", SqlDbType.Int);
            param[4].Value = payment_condition_id;

            param[5] = new SqlParameter("@customer_id", SqlDbType.Int);
            param[5].Value = customer_id;

            param[6] = new SqlParameter("@customer_name", SqlDbType.VarChar);
            param[6].Value = customer_name;

            param[7] = new SqlParameter("@account_id", SqlDbType.Int);
            param[7].Value = account_id;

            param[8] = new SqlParameter("@account_number", SqlDbType.VarChar);
            param[8].Value = account_number;

            param[9] = new SqlParameter("@account_name", SqlDbType.VarChar);
            param[9].Value = account_name;

            param[10] = new SqlParameter("@cost_center_id", SqlDbType.Int);
            param[10].Value = cost_center_id;

            param[11] = new SqlParameter("@cost_center_number", SqlDbType.Int);
            param[11].Value = cost_center_number;

            param[12] = new SqlParameter("@cost_center_name", SqlDbType.VarChar);
            param[12].Value = cost_center_name;

            param[13] = new SqlParameter("@price_include_vat", SqlDbType.Bit);
            param[13].Value = price_include_vat;

            param[14] = new SqlParameter("@net_total", SqlDbType.VarChar);
            param[14].Value = net_total;

            param[15] = new SqlParameter("@discount_name", SqlDbType.VarChar);
            param[15].Value = discount_name;

            param[16] = new SqlParameter("@discount_percentage", SqlDbType.VarChar);
            param[16].Value = discount_percentage;

            param[17] = new SqlParameter("@discount_not_more", SqlDbType.VarChar);
            param[17].Value = discount_not_more;

            param[18] = new SqlParameter("@total_without_vat", SqlDbType.VarChar);
            param[18].Value = total_without_vat;

            param[19] = new SqlParameter("@total_with_vat", SqlDbType.VarChar);
            param[19].Value = total_with_vat;

            param[20] = new SqlParameter("@vat_amount", SqlDbType.VarChar);
            param[20].Value = vat_amount;

            param[21] = new SqlParameter("@updated_by", SqlDbType.Int);
            param[21].Value = UI.Main.getMainForm.getUserInfo()[0];

            DAL.Open();
            DAL.ExecuteCommand("Save_Updates_Invoice_Data", param);
            DAL.Open();

        }

    }
}
