using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sales_management.PL
{

    class Journals
    {

        public void Update_Journal_Document_Details( int doc_id, int doc_type, string description, DateTime datemade, DataTable table, bool allowChangeDate = false )
        {

            // Update Journal 
            this.Update_Journal_Document(doc_id, doc_type, description, datemade, allowChangeDate);

            /* 
             * Insert a New Record 
             */
            this.Update_Journal_Document_Accounts(doc_id, doc_type, table);

        }

        public void Update_Journal_Document_Accounts(int doc_id, int doc_type, DataTable table ) {

             
            foreach (DataRow accounts in table.Rows) {

                Console.WriteLine(accounts["account_number"] + " - " + accounts["amount"].ToString());
                this.Insert_Journal_Account_Details(
                    accounts["account_number"].ToString(),
                    accounts["amount"].ToString(),
                    Convert.ToBoolean(accounts["is_debit"]),
                    accounts["description"].ToString(),
                    doc_id,
                    doc_type
                );
            }

        }

        public void Insert_Journal_Account_Details( string acc_number, string amount, bool is_debit, string description, int doc_id, int doc_type ) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[6];
             

            string debit_amount = "0";
            string credit_amount = "0";
            if (is_debit)
            {
                debit_amount = amount;
            }
            else {
                credit_amount = amount;
            }

            param[0] = new SqlParameter("@account_number", SqlDbType.VarChar);
            param[0].Value = acc_number;

            param[1] = new SqlParameter("@debit", SqlDbType.VarChar);
            param[1].Value = debit_amount;

            param[2] = new SqlParameter("@credit", SqlDbType.VarChar);
            param[2].Value = credit_amount; 

            param[3] = new SqlParameter("@description", SqlDbType.VarChar);
            param[3].Value = description;

            param[4] = new SqlParameter("@doc_id", SqlDbType.Int);
            param[4].Value = doc_id;

            param[5] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[5].Value = doc_type;

            DAL.Open();
            DAL.ExecuteCommand("Insert_Journal_Account_Details", param);
            DAL.Close();

        }

        public void Update_Journal_Document(int doc_id, int doc_type, string description, DateTime datemade, bool allowChangeDate ) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@doc_id", SqlDbType.Int );
            param[0].Value = doc_id;

            param[1] = new SqlParameter("@doc_type", SqlDbType.Int);
            param[1].Value = doc_type;

            param[2] = new SqlParameter("@description", SqlDbType.Text);
            param[2].Value = description;

            param[3] = new SqlParameter("@datemade", SqlDbType.DateTime);
            param[3].Value = datemade;// Convert.ToInt32(datemade.Day);

            param[4] = new SqlParameter("@allow_update_date", SqlDbType.Bit );
            param[4].Value = allowChangeDate;

            param[5] = new SqlParameter("@daynumber", SqlDbType.Int);
            param[5].Value = Convert.ToInt32(datemade.Day);

            DAL.Open();
            DAL.ExecuteCommand("Update_Journal_Document", param );
            DAL.Close();

        }

    }

}
