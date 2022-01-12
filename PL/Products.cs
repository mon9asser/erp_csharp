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

        /* --------------------------------------  CATEGORIES --------------------  */
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


        /* ---------------------- PRODUCT UNITS --------------------  */
        public DataTable Get_All_Product_Units()
        {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            Layer.Open();

            DataTable tbl = new DataTable();

            tbl = Layer.SelectData("Get_Product_Units", null);

            Layer.Close();

            return tbl;
        }

        public DataTable Delete_Product_Units( int id )
        {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter( "@id", SqlDbType.Int );
            param[0].Value = id; 

            Layer.Open();

            DataTable tbl = new DataTable();

            tbl = Layer.SelectData("Delete_Product_Units", param );

            Layer.Close();

            return tbl;
        }

        public DataTable Update_Product_Units( int id, string title, string shortcut, string unit_counts) {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();
            
            int userId = Convert.ToInt32(UI.Main.getMainForm.getUserInfo()[0]);

            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@title", SqlDbType.VarChar);
            param[1].Value = title;

            param[2] = new SqlParameter("@shortcut", SqlDbType.VarChar);
            param[2].Value = shortcut;

            param[3] = new SqlParameter("@created_by", SqlDbType.Int);
            param[3].Value = userId;

            param[4] = new SqlParameter("@unit_counts", SqlDbType.VarChar);
            param[4].Value = unit_counts;

            param[5] = new SqlParameter("@updated_by", SqlDbType.Int);
            param[5].Value = userId;

            param[6] = new SqlParameter("@date_made", SqlDbType.DateTime);
            param[6].Value = DateTime.Now;

            param[7] = new SqlParameter("@mod_date", SqlDbType.DateTime);
            param[7].Value = DateTime.Now;

            Layer.Open();

            DataTable tbl = new DataTable();

            tbl = Layer.SelectData("Update_Product_Units", param);

            Layer.Close();

            return tbl;

        }


        public DataTable Create_Product_ID() {
            
            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            Layer.Open();

            DataTable tbl = new DataTable();

            tbl = Layer.SelectData("Create_Product_Code", null);

            Layer.Close();

            return tbl;

        }

    }
}
