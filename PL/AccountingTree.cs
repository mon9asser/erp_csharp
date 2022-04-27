using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{
    class AccountingTree
    {
        public void Update_Tree_Of_Accounts(DataTable table) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
             
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@accounting_tree", SqlDbType.Structured);
            param[0].Value = table;

            DAL.Open();
            DAL.ExecuteCommand("Update_Tree_Of_Accounts_TableSet", param); 
            DAL.Close();

        }

        public void Create_Tree_Account(int id, string accountNumber, string accountName, string accountNameEn, string mainAccount, string debitCredit, string balance, bool is_main_account)
        {
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DataTable table = new DataTable();

            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@account_number", SqlDbType.VarChar);
            param[0].Value = accountNumber;

            param[1] = new SqlParameter("@account_name", SqlDbType.VarChar);
            param[1].Value = accountName;

            param[2] = new SqlParameter("@account_name_en", SqlDbType.VarChar);
            param[2].Value = accountNameEn;

            param[3] = new SqlParameter("@main_account", SqlDbType.VarChar);
            param[3].Value = mainAccount;

            param[4] = new SqlParameter("@debit_credit", SqlDbType.VarChar);
            param[4].Value = debitCredit;

            param[5] = new SqlParameter("@balance", SqlDbType.VarChar);
            param[5].Value = balance;

            param[6] = new SqlParameter("@id", SqlDbType.Int);
            param[6].Value = id;

            param[7] = new SqlParameter("@is_main_account", SqlDbType.Bit );
            param[7].Value = is_main_account;

            DAL.Open();

            DAL.ExecuteCommand("Create_Tree_Account", param);

            DAL.Close(); 
        }

        public void Delete_Account_By_Number(string account_number) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer(); 

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@account_number", SqlDbType.VarChar);
            param[0].Value = account_number;

            DAL.Open();

            DAL.ExecuteCommand("Delete_Account_By_Number", param);

            DAL.Close(); 

        }
        public DataTable Get_Accounting_Tree() {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            DataTable table = new DataTable();
            
            DAL.Open();
            
            table = DAL.SelectData("Get_Accounting_Tree", null);

            DAL.Close();
            
            return table;
        }

        public void Delete_All_Accounts() {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer(); 
            
            DAL.Open();

            DAL.ExecuteCommand( "Delete_All_Accounts", null );

            DAL.Close();
            
             
        }

    }
}
