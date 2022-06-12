using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{
    class Users
    {

        /*
            =====================================================================
            USERS DATA
            =====================================================================
        */
        public void Update( string username, string fullname, string password, bool is_manager, int userId = -1)
        {
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = userId;

            param[1] = new SqlParameter("@username", SqlDbType.VarChar);
            param[1].Value = username;

            param[2] = new SqlParameter("@fullname", SqlDbType.VarChar);
            param[2].Value = fullname;

            param[3] = new SqlParameter("@password", SqlDbType.VarChar);
            param[3].Value = password;

            param[4] = new SqlParameter("@is_manager", SqlDbType.Bit);
            param[4].Value = is_manager;
             
            DAL.Open();
            DAL.ExecuteCommand("Update_User_Data", param);
            DAL.Close();

        }

        public DataTable Get_All_Users() {

            DataTable tble;

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DAL.Open();
            tble = DAL.SelectData("Get_All_User_Data", null);
            DAL.Close();

            return tble;

        }

        public void Delete( int userId = -1)
        {
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = userId; 

            DAL.Open();
            DAL.ExecuteCommand("Delete_User_Data", param);
            DAL.Close();

        }


        /*
           =====================================================================
           PRIVILEGE AND RESP DATA -> FOR NEXT VERSION 
           =====================================================================
       */ 

    }
}
