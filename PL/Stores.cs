using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{
    class Stores
    {

        public DataTable Get_Sotore_Id()
        {

            DataTable table;

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@created_by", SqlDbType.Int);
            param[0].Value = UI.Main.getMainForm.getUserInfo()[0];

            param[1] = new SqlParameter("@datemade", SqlDbType.DateTime);
            param[1].Value = DateTime.Now;

            DAL.Open();
            table = DAL.SelectData("Create_Store_Id", param);
            DAL.Close();

            return table;

        }

        public DataTable Get_All_Stores() {

            DataTable table;

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
              
            DAL.Open();
            table = DAL.SelectData("Create_Store_Id", null);
            DAL.Close();

            return table;
        }

        public void Update_Data_Of_Stores( int id, string name, string branch, string telphone, string address, string fax, string cost_center_number)
        {
             
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id; 

            param[1] = new SqlParameter("@store_name", SqlDbType.VarChar);
            param[1].Value = name;

            param[2] = new SqlParameter("@store_branch", SqlDbType.VarChar);
            param[2].Value = branch;

            param[3] = new SqlParameter("@telephone", SqlDbType.VarChar);
            param[3].Value = telphone;

            param[4] = new SqlParameter("@address", SqlDbType.Text);
            param[4].Value = address;

            param[5] = new SqlParameter("@fax", SqlDbType.VarChar);
            param[5].Value = fax;

            param[6] = new SqlParameter("@cost_center_id", SqlDbType.VarChar);
            param[6].Value = cost_center_number;

            param[7] = new SqlParameter("@updated_by", SqlDbType.VarChar);
            param[7].Value = UI.Main.getMainForm.getUserInfo()[0];

            DAL.Open();
            DAL.ExecuteCommand("Update_Data_Of_Stores", param);
            DAL.Close(); 

        }


    }
}
