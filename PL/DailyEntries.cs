using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{
    class DailyEntries
    {

        public void Update_Entries_Data( DataTable table, DateTime date_field, string details, int id ) {
             
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@entries", SqlDbType.Structured);
            param[0].Value = table;

            param[1] = new SqlParameter("@date_time", SqlDbType.DateTime);
            param[1].Value = date_field;

            param[2] = new SqlParameter("@detail", SqlDbType.VarChar);
            param[2].Value = details;

            param[3] = new SqlParameter("@id", SqlDbType.Int);
            param[3].Value = id;

            DAL.Open();
            DAL.ExecuteCommand("Update_Entries_DataSet", param);
            DAL.Close(); 

        }

        public DataTable Create_Entry_Id() {

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DAL.Open();
            table = DAL.SelectData("Create_Entry_Id", null);
            DAL.Close();

            return table;
        }

        public DataTable Get_All_Entries() {
             
            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer(); 

            DAL.Open();
            table = DAL.SelectData("Get_All_Entries", null);
            DAL.Close();

            return table;

        }

        public DataTable Get_All_Row_Entries_By_Id( int id ) {

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter( "@id", SqlDbType.Int );
            param[0].Value = id;

            DAL.Open();
            table = DAL.SelectData("Get_All_Row_Entries_By_Id", param);
            DAL.Close();

            return table;
        }

        public DataTable Get_All_Row_Entries()
        {

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DAL.Open();
            table = DAL.SelectData("Get_All_Row_Entries", null);
            DAL.Close();

            return table;

        }


    }
}
