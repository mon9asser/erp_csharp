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

        public void Store_Invoice_Details(string datagride_id, int invoiceType, int is_out, string factor, string product_name, string total_quantity, string totalPrice, string quantity, int unitId, string unitPrice, string product_id,  int invoiceId ) {
           
            string procName = this.Create_Proc_Name(invoiceType, "Update", "Details");

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@invoice_id", SqlDbType.Int);
            param[0].Value = invoiceId;

            param[1] = new SqlParameter("@invoice_type", SqlDbType.Int);
            param[1].Value = invoiceType;

            param[2] = new SqlParameter("@product_id", SqlDbType.Int);
            param[2].Value = product_id;

            param[3] = new SqlParameter("@unit_price", SqlDbType.VarChar);
            param[3].Value = unitPrice;

            param[4] = new SqlParameter("@unit_id", SqlDbType.Int);
            param[4].Value = unitId;

            param[5] = new SqlParameter("@quantity", SqlDbType.VarChar);
            param[5].Value = quantity;

            param[6] = new SqlParameter("@total_price", SqlDbType.VarChar);
            param[6].Value = totalPrice;

            param[7] = new SqlParameter("@total_quantity", SqlDbType.VarChar);
            param[7].Value = total_quantity;

            param[8] = new SqlParameter("@product_name", SqlDbType.VarChar);
            param[8].Value = product_name;

            param[9] = new SqlParameter("@factor", SqlDbType.VarChar);
            param[9].Value = factor;

            param[10] = new SqlParameter("@document_type", SqlDbType.Int);
            param[10].Value = invoiceType;

            param[11] = new SqlParameter("@is_out", SqlDbType.Int);
            param[11].Value = is_out;

            param[12] = new SqlParameter("@datagride_id", SqlDbType.VarChar);
            param[12].Value = datagride_id;

            DAL.Open();
            DAL.ExecuteCommand(procName, param);
            DAL.Close();
             
        }

        public void Store_Invoice_Data( int id, string serial, int payment_method, string details, string total_with_vat, string total_without_vat, string discount, string vat_value, bool is_include_vat, string net_total, string discount_perc, string discount_not_more, int invoiceType ) {

            string procName = this.Create_Proc_Name(invoiceType, "Update", "Data");

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@serial", SqlDbType.VarChar);
            param[1].Value = serial;

            param[2] = new SqlParameter("@payment_method", SqlDbType.Int);
            param[2].Value = payment_method;

            param[3] = new SqlParameter("@date", SqlDbType.DateTime);
            param[3].Value = DateTime.Now;

            param[4] = new SqlParameter("@details", SqlDbType.Text);
            param[4].Value = details;

            param[5] = new SqlParameter("@total_with_vat", SqlDbType.VarChar);
            param[5].Value = total_with_vat;

            param[6] = new SqlParameter("@total_without_vat", SqlDbType.VarChar);
            param[6].Value = total_without_vat;

            param[7] = new SqlParameter("@discount", SqlDbType.VarChar);
            param[7].Value = discount;

            param[8] = new SqlParameter("@vat_value", SqlDbType.VarChar);
            param[8].Value = vat_value;

            param[9] = new SqlParameter("@is_include_vat", SqlDbType.Bit);
            param[9].Value = is_include_vat;

            param[10] = new SqlParameter("@net_total", SqlDbType.VarChar);
            param[10].Value = net_total;

            param[11] = new SqlParameter("@discount_perc", SqlDbType.VarChar);
            param[11].Value = discount_perc;

            param[12] = new SqlParameter("@discount_not_more", SqlDbType.VarChar);
            param[12].Value = discount_not_more;

            DAL.Open();
            DAL.ExecuteCommand(procName, param);
            DAL.Close();
        }

    }
}
