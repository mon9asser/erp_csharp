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
    }
}
