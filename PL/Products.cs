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

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = Convert.ToInt32(UI.Main.getMainForm.getUserInfo()[0]);

            param[1] = new SqlParameter("@current_date", SqlDbType.DateTime);
            param[1].Value = DateTime.Now;

            Layer.Open();
             
            DataTable tbl = Layer.SelectData("Create_Product_Code", param);
             
            Layer.Close();

            return tbl;

        }

        public void Update_Product_Image(int id, byte[] image )
        {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@image", SqlDbType.Image);
            param[1].Value = image;

            Layer.Open();

            DataTable tbl = Layer.SelectData("Update_Product_Image", param);
             
            Layer.Close(); 

        }

        public DataTable Get_All_Products() {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            Layer.Open();

            DataTable tbl = Layer.SelectData("Get_All_Products", null );

            Layer.Close();

            return tbl; 
        }

        public DataTable Get_Product_By_Id( int id )
        {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            Layer.Open();
            
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DataTable tbl = Layer.SelectData( "Get_All_Product_By_Id", param );

            Layer.Close();

            return tbl;
        }
        
        public void Delete_Product_By_Id(int id)
        {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter( "@id", SqlDbType.Int );
            param[0].Value = id; 

            Layer.Open();

            Layer.ExecuteCommand("Delete_Product_By_Id", param);

            Layer.Close(); 

        }


        public DataTable Selcted_By_Searched_Value( string searched_value ) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DataTable table = new DataTable();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@search_value", SqlDbType.VarChar);
            param[0].Value = searched_value;

            
            table = DAL.SelectData("Search_In_Products", param);

            DAL.Close();

            return table; 



        }


        public void Update_Product_Data( 
            int id , 
            string min_limit, 
            string max_limit, 
            string request_limit, 
            string name, 
            string purchase_price, 
            string less_sale_price, 
            string wholesale_sale, 
            bool request_limit_notify, 
            bool minmax_limit_notify, 
            string allowed_discount, 
            string discount_percentage_val, 
            
            int gr1_unit_id, 
            string gr1_purchase_price, 
            string gr1_sale_price, 
            string gr1_less_sale_price, 
            string gr1_wholesale_sale, 
            string gr1_transform, 

            int gr2_unit_id, 
            string gr2_purchase_price, 
            string gr2_sale_price, 
            string gr2_less_sale_price, 
            string gr2_wholesale_sale, 
            string gr2_transform,

            int gr3_unit_id,
            string gr3_purchase_price,
            string gr3_sale_price,
            string gr3_less_sale_price,
            string gr3_wholesale_sale,
            string gr3_transform,

            int gr4_unit_id,
            string gr4_purchase_price,
            string gr4_sale_price,
            string gr4_less_sale_price,
            string gr4_wholesale_sale,
            string gr4_transform,

            int gr5_unit_id,
            string gr5_purchase_price,
            string gr5_sale_price,
            string gr5_less_sale_price,
            string gr5_wholesale_sale,
            string gr5_transform,

            int gr6_unit_id,
            string gr6_purchase_price,
            string gr6_sale_price,
            string gr6_less_sale_price,
            string gr6_wholesale_sale,
            string gr6_transform,

            int unit_id,
            bool enable_expiration_notification,
            DateTime expiration_date,
            int category_id, 
            int default_group,
            string default_sale_price
            ) {
            
            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[56];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@min_limit", SqlDbType.VarChar);
            param[1].Value = min_limit;

            param[2] = new SqlParameter("@max_limit", SqlDbType.VarChar);
            param[2].Value = max_limit;

            param[3] = new SqlParameter("@request_limit", SqlDbType.VarChar);
            param[3].Value = request_limit;

            param[4] = new SqlParameter("@name", SqlDbType.VarChar);
            param[4].Value = name;

            param[5] = new SqlParameter("@purchase_price", SqlDbType.VarChar);
            param[5].Value = purchase_price;

            param[6] = new SqlParameter("@less_sale_price", SqlDbType.VarChar);
            param[6].Value = less_sale_price;

            param[7] = new SqlParameter("@wholesale_sale", SqlDbType.VarChar);
            param[7].Value = wholesale_sale;

            param[8] = new SqlParameter("@request_limit_notify", SqlDbType.Bit);
            param[8].Value = request_limit_notify;

            param[9] = new SqlParameter("@minmax_limit_notify", SqlDbType.Bit);
            param[9].Value = minmax_limit_notify;

            param[10] = new SqlParameter("@allowed_discount", SqlDbType.VarChar);
            param[10].Value = allowed_discount;

            param[11] = new SqlParameter("@discount_percentage_val", SqlDbType.VarChar);
            param[11].Value = discount_percentage_val;

            param[12] = new SqlParameter("@gr1_unit_id", SqlDbType.Int);
            param[12].Value = gr1_unit_id;

            param[13] = new SqlParameter("@gr1_purchase_price", SqlDbType.VarChar);
            param[13].Value = gr1_purchase_price;

            param[14] = new SqlParameter("@gr1_sale_price", SqlDbType.VarChar);
            param[14].Value = gr1_sale_price;

            param[15] = new SqlParameter("@gr1_less_sale_price", SqlDbType.VarChar);
            param[15].Value = gr1_less_sale_price;

            param[16] = new SqlParameter("@gr1_wholesale_sale", SqlDbType.VarChar);
            param[16].Value = gr1_wholesale_sale;

            param[17] = new SqlParameter("@gr1_transform", SqlDbType.VarChar);
            param[17].Value = gr1_transform;

            param[18] = new SqlParameter("@gr2_unit_id", SqlDbType.Int);
            param[18].Value = gr2_unit_id;

            param[19] = new SqlParameter("@gr2_purchase_price", SqlDbType.VarChar);
            param[19].Value = gr2_purchase_price;

            param[20] = new SqlParameter("@gr2_sale_price", SqlDbType.VarChar);
            param[20].Value = gr2_sale_price;

            param[21] = new SqlParameter("@gr2_less_sale_price", SqlDbType.VarChar);
            param[21].Value = gr2_less_sale_price;

            param[22] = new SqlParameter("@gr2_wholesale_sale", SqlDbType.VarChar);
            param[22].Value = gr2_wholesale_sale;

            param[23] = new SqlParameter("@gr2_transform", SqlDbType.VarChar);
            param[23].Value = gr2_transform;





            param[24] = new SqlParameter("@gr3_unit_id", SqlDbType.Int);
            param[24].Value = gr3_unit_id;

            param[25] = new SqlParameter("@gr3_purchase_price", SqlDbType.VarChar);
            param[25].Value = gr3_purchase_price;

            param[26] = new SqlParameter("@gr3_sale_price", SqlDbType.VarChar);
            param[26].Value = gr3_sale_price;

            param[27] = new SqlParameter("@gr3_less_sale_price", SqlDbType.VarChar);
            param[27].Value = gr3_less_sale_price;

            param[28] = new SqlParameter("@gr3_wholesale_sale", SqlDbType.VarChar);
            param[28].Value = gr3_wholesale_sale;

            param[29] = new SqlParameter("@gr3_transform", SqlDbType.VarChar);
            param[29].Value = gr3_transform;




            param[30] = new SqlParameter("@gr4_unit_id", SqlDbType.Int);
            param[30].Value = gr4_unit_id;

            param[31] = new SqlParameter("@gr4_purchase_price", SqlDbType.VarChar);
            param[31].Value = gr4_purchase_price;

            param[32] = new SqlParameter("@gr4_sale_price", SqlDbType.VarChar);
            param[32].Value = gr4_sale_price;

            param[33] = new SqlParameter("@gr4_less_sale_price", SqlDbType.VarChar);
            param[33].Value = gr4_less_sale_price;

            param[34] = new SqlParameter("@gr4_wholesale_sale", SqlDbType.VarChar);
            param[34].Value = gr4_wholesale_sale;

            param[35] = new SqlParameter("@gr4_transform", SqlDbType.VarChar);
            param[35].Value = gr4_transform;


            param[36] = new SqlParameter("@gr5_unit_id", SqlDbType.Int);
            param[36].Value = gr5_unit_id;

            param[37] = new SqlParameter("@gr5_purchase_price", SqlDbType.VarChar);
            param[37].Value = gr5_purchase_price;

            param[38] = new SqlParameter("@gr5_sale_price", SqlDbType.VarChar);
            param[38].Value = gr5_sale_price;

            param[39] = new SqlParameter("@gr5_less_sale_price", SqlDbType.VarChar);
            param[39].Value = gr5_less_sale_price;

            param[40] = new SqlParameter("@gr5_wholesale_sale", SqlDbType.VarChar);
            param[40].Value = gr5_wholesale_sale;

            param[41] = new SqlParameter("@gr5_transform", SqlDbType.VarChar);
            param[41].Value = gr5_transform;

    
            param[42] = new SqlParameter("@gr6_unit_id", SqlDbType.Int);
            param[42].Value = gr6_unit_id;

            param[43] = new SqlParameter("@gr6_purchase_price", SqlDbType.VarChar);
            param[43].Value = gr6_purchase_price;

            param[44] = new SqlParameter("@gr6_sale_price", SqlDbType.VarChar);
            param[44].Value = gr6_sale_price;

            param[45] = new SqlParameter("@gr6_less_sale_price", SqlDbType.VarChar);
            param[45].Value = gr6_less_sale_price;

            param[46] = new SqlParameter("@gr6_wholesale_sale", SqlDbType.VarChar);
            param[46].Value = gr6_wholesale_sale;

            param[47] = new SqlParameter("@gr6_transform", SqlDbType.VarChar);
            param[47].Value = gr6_transform;
             
            param[48] = new SqlParameter("@unit_id", SqlDbType.Int);
            param[48].Value = unit_id;

            param[49] = new SqlParameter("@enable_expiration_notification", SqlDbType.Bit);
            param[49].Value = enable_expiration_notification;

            param[50] = new SqlParameter("@expiration_date", SqlDbType.DateTime);
            param[50].Value = expiration_date;

            param[51] = new SqlParameter("@category_id", SqlDbType.Int);
            param[51].Value = category_id;

            param[52] = new SqlParameter("@date_mod", SqlDbType.DateTime);
            param[52].Value = DateTime.Now;

            param[53] = new SqlParameter("@default_group", SqlDbType.Int);
            param[53].Value = default_group;

            param[54] = new SqlParameter("@updated_by", SqlDbType.Int);
            param[54].Value = Convert.ToInt32(UI.Main.getMainForm.getUserInfo()[0]);

            param[55] = new SqlParameter("@default_sale_price", SqlDbType.VarChar);
            param[55].Value = default_sale_price;
            

            Layer.Open();

            Layer.ExecuteCommand("Update_Product_DB", param );

            Layer.Close();
        }

    }
}
