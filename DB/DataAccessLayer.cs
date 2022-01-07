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

        SqlConnection AccessLayer;

        public DataAccessLayer() {

            this.LoadSystemConfiguration();
            AccessLayer = new SqlConnection(@"Server" +this.GetNetworkId() + ","+ this.GetPort() +"; Database="+this.GetDatabaseName() +"; User ID="+ this.GetUserName()+"; Password="+this.GetPassword()+"; Integrated Security=true;");
        
        }


    }
}
