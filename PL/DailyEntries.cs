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

        public DataSet Get_Withdraw_Document()
        {
            DataSet table;
            DB.DataAccessLayer DAL = new DB.DataAccessLayer(); 
            DAL.Open();
            table = DAL.SelectDataSet("Get_Withdraw_Document", null );
            DAL.Close();
            return table;
        }

        public void Update_Withdraw_Document( int id, DateTime date_made, string details, string account_number, string account_name, string total_quantity, string total_price, string journal_id, DataTable items_table, DataTable header_entry, DataTable details_entry )
        {
             
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[11];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@date_made", SqlDbType.DateTime);
            param[1].Value = date_made;

            param[2] = new SqlParameter("@details", SqlDbType.VarChar);
            param[2].Value = details;

            param[3] = new SqlParameter("@account_number", SqlDbType.VarChar);
            param[3].Value = account_number;

            param[4] = new SqlParameter("@account_name", SqlDbType.VarChar);
            param[4].Value = account_number;

            param[5] = new SqlParameter("@total_quantity", SqlDbType.VarChar);
            param[5].Value = total_quantity;

            param[6] = new SqlParameter("@total_price", SqlDbType.VarChar);
            param[6].Value = total_price;

            param[7] = new SqlParameter("@journal_id", SqlDbType.VarChar);
            param[7].Value = journal_id;

            param[8] = new SqlParameter("@items_table", SqlDbType.Structured);
            param[8].Value = items_table;

            param[9] = new SqlParameter("@header_entry", SqlDbType.Structured);
            param[9].Value = header_entry;

            param[10] = new SqlParameter("@details_entry", SqlDbType.Structured);
            param[10].Value = details_entry;

            DAL.Open();
            DAL.ExecuteCommand("Update_Withdraw_Document", param );
            DAL.Close();
             
        }

        public DataSet Search_On_Process_Reports( DateTime date_from, DateTime date_to, int enable_zakat ) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[3];
            DataSet setters;
            param[0] = new SqlParameter("@date_from", SqlDbType.VarChar);
            param[0].Value = date_from.ToString("yyyy-MM-dd") + " 00:00:00";

            param[1] = new SqlParameter("@date_to", SqlDbType.VarChar);
            param[1].Value = date_to.ToString("yyyy-MM-dd") + " 23:59:59";

            Console.WriteLine(date_from.ToString("yyyy-MM-dd") + " 00:00:00");
            Console.WriteLine(date_to.ToString("yyyy-MM-dd") + " 23:59:59");

            param[2] = new SqlParameter("@filter_with", SqlDbType.Int);
            param[2].Value = enable_zakat;
            
            DAL.Open();
            setters = DAL.SelectDataSet("Search_On_Process_Reports", param);
            DAL.Close();

            return setters;

        }

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

        public void Delete_Records_With_Entries( int id  ) {
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
             
            DAL.Open();
            DAL.ExecuteCommand("Delete_Entries_And_Record", param);
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

        public DataTable Get_This_Entry_By_Id( int entry_id )
        {

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter( "@id", SqlDbType.Int );
            param[0].Value = entry_id; 

            DAL.Open();
            table = DAL.SelectData("Get_This_Entry_By_Id", param);
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
