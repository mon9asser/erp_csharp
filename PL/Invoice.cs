using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sales_management.PL
{
    class Invoice
    {
        public string Create_Proc_Name(int type, string action, string last_string)
        {

            string invoice_type = "Sales_Invoice";

            if (type == 0)
            {
                invoice_type = "Sales_Invoice";
            }
            else if (type == 1)
            {
                invoice_type = "Purchase_Invoice";
            }
            else if (type == 2)
            {
                invoice_type = "Return_Purchase_Invoice";
            }
            else if (type == 3)
            {
                invoice_type = "Return_Sales_Invoice";
            }

            string proc_name = action + "_" + invoice_type + "_" + last_string;

            return proc_name;

        }

        /*
         * Proc names +++++ 
         * Create_Purchase_Invoice_Id
         * Create_Sales_Invoice_Id
         * Create_Return_Purchase_Invoice_Id
         * Create_Return_Sales_Invoice_Id
         */
        public DataTable Create_Invoice_Id( int type, int id ) {

            string procName = this.Create_Proc_Name(type, "Create", "Id");

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            table = DAL.SelectData(procName, param);
            DAL.Close();

            return table;

        }


         

        /*
        * Proc names +++++ 
        * Get_Purchase_Invoice_Details
        * Get_Sales_Invoice_Details
        * Get_Return_Purchase_Invoice_Details
        * Get_Return_Sales_Invoice_Details
        */
        public DataTable Get_Invoice_Details(int type, int invoiceId ) {

            string procName = this.Create_Proc_Name(type, "Get", "Details");

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@invoice_id", SqlDbType.Int);
            param[0].Value = invoiceId;

            param[1] = new SqlParameter("@type", SqlDbType.Int);
            param[1].Value = type;

            DAL.Open();
            table = DAL.SelectData(procName, param);
            DAL.Close();

            return table;

        }
    }
}
