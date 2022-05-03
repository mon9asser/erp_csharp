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

        public DataTable Get_All_Entries() {
             
            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer(); 

            DAL.Open();
            table = DAL.SelectData("Get_All_Entries", null);
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
