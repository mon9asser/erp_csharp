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
             
            DAL.Open();
            table = DAL.SelectData("Create_Store_Id", null);
            DAL.Close();

            return table;

        }


    }
}
