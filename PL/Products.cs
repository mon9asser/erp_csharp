using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{
    class Products
    {

        public void Update_Categories( int id, string cat_name, int userId ) {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@category", SqlDbType.VarChar);
            param[1].Value = cat_name;

            param[2] = new SqlParameter("@created_by", SqlDbType.Int);
            param[2].Value = userId;

            param[3] = new SqlParameter("@mod_date", SqlDbType.DateTime);
            param[3].Value = DateTime.Now;

            param[4] = new SqlParameter("@created_date", SqlDbType.DateTime);
            param[4].Value = DateTime.Now;

            param[5] = new SqlParameter("@updated_by", SqlDbType.Int);
            param[5].Value = userId;

            Layer.Open();
            Layer.ExecuteCommand("Update_Categories", param);
            Layer.Close();

        }

        public DataTable Get_All_Categories() {
            
            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            Layer.Open();
            
            DataTable tbl = new DataTable();
            
            tbl = Layer.SelectData("Get_All_Categories", null);

            Layer.Close();

            return tbl;
        }

        public void Delete_Category( int id ) {
            
            DB.DataAccessLayer Layer = new DB.DataAccessLayer();
            
            SqlParameter[] param = new SqlParameter[1];

            Layer.Open();

            param[0] = new SqlParameter("@id", SqlDbType.Int );
            param[0].Value = id;

            Layer.ExecuteCommand("Delete_Category", param );

            Layer.Close();

        }

    }
}
