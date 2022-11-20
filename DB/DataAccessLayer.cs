using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.DB
{
    class DataAccessLayer:DB.Config
    {

        SqlConnection sqlConnectionState;
        public bool connectionError = true; 

        public DataAccessLayer() {

            this.LoadSystemConfiguration();

            string connectionString = @"Server=" + this.GetNetworkId() + "; Database=" + this.GetDatabaseName() + "; Trusted_Connection=True;";


            if (this.isIntegratedSecurity())
            {
                connectionString = @"Server=" + this.GetNetworkId() + "," + this.GetPort() + "; Database=" + this.GetDatabaseName() + "; User ID=" + this.GetUserName() + "; Password=" + this.GetPassword() + "; Integrated Security=false;pooling=true;";
            }

            

            sqlConnectionState = new SqlConnection(connectionString);

            this.connectionError = false;

        }
         

        public void Open() {
           
            if( sqlConnectionState.State != System.Data.ConnectionState.Open)
            {
                sqlConnectionState.Open();
            }

        }

        public void Close()
        {

            if (sqlConnectionState.State == System.Data.ConnectionState.Open)
            {
                sqlConnectionState.Close();
            }

        }

        public System.Data.ConnectionState CheckStatus() {
            return sqlConnectionState.State;
        }

        // Method to select data 
        public DataTable SelectData( string stored_proc, SqlParameter[] param ) {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_proc;
            sqlcmd.Connection = sqlConnectionState;

            if (param != null) {
                for ( int i = 0; i< param.Length; i++ )
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataSet SelectDataSet(string stored_proc, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_proc;
            sqlcmd.Connection = sqlConnectionState;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        // Method to store and delete, update db 
        public void ExecuteCommand(string stored_proc, SqlParameter[] param ) {

            SqlCommand sqlcmd  = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_proc;
            sqlcmd.Connection  = sqlConnectionState;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }

            sqlcmd.ExecuteNonQuery();

        }

    }
}
