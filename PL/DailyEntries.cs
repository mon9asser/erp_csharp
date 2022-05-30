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


        public DataTable Income_Statement_List(DateTime date_from, DateTime date_to)
        {

            DataTable tble;

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@date_from", SqlDbType.VarChar);
            param[0].Value = date_from.ToString("yyyy-MM-dd") + " 00:00:00.000";

            param[1] = new SqlParameter("@date_to", SqlDbType.VarChar);
            param[1].Value = date_to.ToString("yyyy-MM-dd") + " 23:59:59.000";

            DAL.Open();
            tble = DAL.SelectData("Income_Statement_List", param);
            DAL.Close(); 

            return tble;

        }


        public DataSet Get_Withdraw_Report_DataSet(DateTime date_from, DateTime date_to )
        {

            DataSet tble;

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@date_from", SqlDbType.VarChar);
            param[0].Value = date_from.ToString("yyyy-MM-dd") + " 00:00:00.000";

            param[1] = new SqlParameter("@date_to", SqlDbType.VarChar);
            param[1].Value = date_to.ToString("yyyy-MM-dd") + " 23:59:59.000";

            DAL.Open();
            tble = DAL.SelectDataSet("WithdraW_Summery_Report", param);
            DAL.Close();

            return tble;
        }

        public DataSet Get_Entries_Except_Fields( int [] not_in ) {

            DataSet tble;


            
            if (not_in.Length == 0) {

                not_in = new int[4];
                not_in[0] = 0;
                not_in[1] = 1;
                not_in[2] = 2;
                not_in[3] = 3;
            }

            DataTable numbers = new DataTable();
            numbers.Columns.Add("document_types");
            DataRow rowx;
            for (int i = 0; i < not_in.Length; i++)
            {
                rowx = numbers.NewRow();
                rowx["document_types"] = not_in[i];
                numbers.Rows.Add(rowx);
            }

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@not_in", SqlDbType.Structured);
            param[0].Value = numbers;

            DAL.Open();
            tble = DAL.SelectDataSet("Get_Entries_Except_Fields", param);
            DAL.Close();

            return tble;

        }


        public DataSet Get_Report_Statment( string account_1, DateTime date_from, DateTime date_to, string account_2 = "-1" ) {

            DataSet DataSet;

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@account_1", SqlDbType.VarChar);
            param[0].Value = account_1;

            param[1] = new SqlParameter("@date_from", SqlDbType.VarChar);
            param[1].Value = date_from.ToString("yyyy-MM-dd") + " 00:00:00";

            param[2] = new SqlParameter("@date_to", SqlDbType.VarChar);
            param[2].Value = date_to.ToString("yyyy-MM-dd") + " 23:59:59";

            param[3] = new SqlParameter("@account_2", SqlDbType.VarChar);
            param[3].Value = account_2;

            DAL.Open();
            DataSet = DAL.SelectDataSet("Report_Statement_Document", param);
            DAL.Close();

            return DataSet;

        }

        public DataTable Create_Exp_Doucment_Id() {

            DataTable table;

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DAL.Open();
            table = DAL.SelectData("Create_Exp_Doucment_Id", null);
            DAL.Close();

            return table;

        }

        public void Delete_Export_Cart(int cid, int jid) {
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@cid", SqlDbType.Int);
            param[0].Value = cid;

            param[1] = new SqlParameter("@jid", SqlDbType.Int);
            param[1].Value = jid;

            DAL.Open();
            DAL.ExecuteCommand("Delete_Export_Cart", param);
            DAL.Close();
        }

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
            param[4].Value = account_name;

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
        public DataTable Update_DataSet_Of_Daily_Entries( int journal_id, DataTable header_entry, DataTable details_entry ) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            DataTable tbl;
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@journal_id", SqlDbType.Int);
            param[0].Value = journal_id; 

            param[1] = new SqlParameter("@header_entry", SqlDbType.Structured);
            param[1].Value = header_entry;

            param[2] = new SqlParameter("@details_entry", SqlDbType.Structured);
            param[2].Value = details_entry;

            DAL.Open();
            tbl = DAL.SelectData( "Update_DataSet_Of_Daily_Entries" , param );
            DAL.Close();
            return tbl;
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

        public DataTable Get_All_Journals_By_Date(DateTime from, DateTime to ) {

            DataTable table = new DataTable();
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@date_from", SqlDbType.VarChar);
            param[0].Value = from.ToString("yyyy-MM-dd") + " 00:00:00.000";

            param[1] = new SqlParameter("@date_to", SqlDbType.VarChar);
            param[1].Value = to.ToString("yyyy-MM-dd") + " 23:59:59.000";

            DAL.Open();
            table = DAL.SelectData("Get_All_Entries_By_Order", param );
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
