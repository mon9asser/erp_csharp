using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{
    class doc_items
    {

        public void Update_Document_Details(

                int doc_id,
                int doc_type,
                int product_id,
                int unit_id,
                bool is_out,
                string product_name,
                string unit_name,
                string unit_price,
                string factor,
                string quantity,
                string total_quantity,
                string datagrid_id,
                string product_code,
                string total_price



            )
        {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[14];

            param[0] = new SqlParameter("@doc_id", SqlDbType.Int);
            param[0].Value = doc_id;

            param[1] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[1].Value = doc_type;

            param[2] = new SqlParameter("@product_id", SqlDbType.Int);
            param[2].Value = product_id;

            param[3] = new SqlParameter("@unit_id", SqlDbType.Int);
            param[3].Value = unit_id;

            param[4] = new SqlParameter("@is_out", SqlDbType.Bit);
            param[4].Value = is_out;

            param[5] = new SqlParameter("@product_name", SqlDbType.VarChar);
            param[5].Value = product_name;

            param[6] = new SqlParameter("@unit_name", SqlDbType.VarChar);
            param[6].Value = unit_name;

            param[7] = new SqlParameter("@unit_price", SqlDbType.VarChar);
            param[7].Value = unit_price;

            param[8] = new SqlParameter("@factor", SqlDbType.VarChar);
            param[8].Value = factor;

            param[9] = new SqlParameter("@quantity", SqlDbType.VarChar);
            param[9].Value = quantity;

            param[10] = new SqlParameter("@total_quantity", SqlDbType.VarChar);
            param[10].Value = total_quantity;

            param[11] = new SqlParameter("@datagrid_id", SqlDbType.VarChar);
            param[11].Value = datagrid_id;

            param[12] = new SqlParameter("@product_code", SqlDbType.VarChar);
            param[12].Value = product_code;

            param[13] = new SqlParameter("@total_price", SqlDbType.VarChar);
            param[13].Value = total_price;

            DAL.Open();
            DAL.ExecuteCommand("Update_Document_Details", param);
            DAL.Close();
        }

    }
}
