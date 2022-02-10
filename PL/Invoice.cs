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
        public string get_proc_name(int type, string action, string action_param) {
            
            string invoice_type = "Sales";

            if (type == 0)
            {
                invoice_type = "Sales";
            }
            else if (type == 1) {
                invoice_type = "Purchase";
            }
            else if (type == 2)
            {
                invoice_type = "Return_Purchase";
            }
            else if (type == 3)
            {
                invoice_type = "Return_Sales";
            }

            string proc_name = action + "_" + invoice_type + "_Invoice_" + action_param;

            return proc_name;
        }

        public DataTable Create_Invoice_Id( int type, int id) {
            
            /**
             *
             * 0 => SALES
             * 1 => PURCHASE
             * 2 => RETURN PURCHASE
             * 3 => RETURN SALES
             *
             */
            string Proc_Name = this.get_proc_name( type, "Create", "Id" );


            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DataTable table = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();

            table = DAL.SelectData(Proc_Name, param);

            DAL.Close();

            return table;

        }


        public void Update_Invoice_Details( DataTable table ) { 
            
        }


        public DataTable Get_Invoice_Details(int id)
        {
            DataTable table = new DataTable();

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@invoice_id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            
            table = DAL.SelectData("Get_Invoice_Details", param);

            DAL.Close();

            return table;
        }

        public DataTable[] Load_Invoice_Data( int InvoiceType = 0 ) {

            DataTable[] tables = new DataTable[2];

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            string invoices = this.get_proc_name(InvoiceType, "Get", "Data");
            
            return tables;
        }
    }
}
