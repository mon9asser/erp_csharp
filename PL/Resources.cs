using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sales_management.PL
{

    class Resources
    {

        public DataTable Create_Resource_Id( int type  )
        {
            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            
            DataTable table = new DataTable();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@type", SqlDbType.Int);
            param[0].Value = type;

            DAL.Open();
            
            table = DAL.SelectData("Create_Resource_Id", param);

            DAL.Close();

            return table;
        }

        public void Update_Resource_Data( int id, string sup_name, string sup_mob_numbber, string sup_address, string sup_email, string establishment_name, string vat_number, int type ) {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@id", SqlDbType.Int );
            param[0].Value = id;

            param[1] = new SqlParameter("@resource_name", SqlDbType.VarChar);
            param[1].Value = sup_name;
            
            param[2] = new SqlParameter("@resource_phone", SqlDbType.VarChar);
            param[2].Value = sup_mob_numbber;
            
            param[3] = new SqlParameter("@resource_address", SqlDbType.VarChar);
            param[3].Value = sup_address;

            param[4] = new SqlParameter("@resource_email", SqlDbType.VarChar);
            param[4].Value = sup_email;

            param[5] = new SqlParameter("@date_update", SqlDbType.DateTime);
            param[5].Value = DateTime.Now;

            param[6] = new SqlParameter("@updated_by", SqlDbType.Int);
            param[6].Value = Convert.ToInt32(UI.Main.getMainForm.getUserInfo()[0]);

            param[7] = new SqlParameter("@type", SqlDbType.Int);
            param[7].Value = type;

            param[8] = new SqlParameter("@establishment_name", SqlDbType.VarChar);
            param[8].Value = establishment_name;


            param[9] = new SqlParameter("@vat_number", SqlDbType.VarChar);
            param[9].Value = vat_number;

            DAL.Open();
            DAL.ExecuteCommand("Update_Resource_Data", param);
            DAL.Close();
             
        }


        public DataTable Delete_Resource_Data(int id, int type )
        {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", System.Data.SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@type", System.Data.SqlDbType.Int);
            param[1].Value = type;

            DataTable table = new DataTable();

            DAL.Open();
            table = DAL.SelectData("Delete_Resources_Data", param);
            DAL.Close();

            return table;
        }

        public DataTable Get_All_Resource_Data( int type )
        {

            DB.DataAccessLayer DAL = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@type", System.Data.SqlDbType.Int);
            param[0].Value = type;

            DataTable table = new DataTable(); 

            DAL.Open();
            table = DAL.SelectData("Get_All_Resources", param );
            DAL.Close();

            return table;
        }
    }
}
