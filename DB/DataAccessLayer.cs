using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sales_management.DB
{
    class DataAccessLayer:DB.Config
    {

        SqlConnection sqlConnectionState;

        public DataAccessLayer() {

            this.LoadSystemConfiguration();
            sqlConnectionState = new SqlConnection(@"Server=" +this.GetNetworkId() + ","+ this.GetPort() +"; Database="+this.GetDatabaseName() +"; User ID="+ this.GetUserName()+"; Password="+this.GetPassword()+"; Integrated Security=true;");
            
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

    }
}
