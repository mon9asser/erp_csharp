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

        public void Update_Entries_Data( DataTable table, DateTime date_field, string details ) {

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
