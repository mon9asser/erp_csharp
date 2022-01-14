using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 
using System.IO;

namespace sales_management.PL
{
    class Installings
    {

        public void Install_Default_data() {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();
    
            Layer.Open();
            Layer.ExecuteCommand( "Installing", null);
            Layer.Close();

        }

        public byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }

        public void Update_Settings_System_Logo( int id, byte[] image ) {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@image", SqlDbType.Image);
            param[1].Value = image;

            Layer.Open();
            Layer.ExecuteCommand( "Update_Settings_System_Logo", param );
            Layer.Close();

        }
        
        public void Update_Settings_System( int id, string name, string address, string vat_number, int vat_percentage, string vat_percentage_value, int product_barcode_type, bool enable_delete_invoices, bool enable_edit_invoices, bool show_address_in_invoice, int created_by_id, int update_by_id, DateTime mod_date, DateTime date_made, bool isEnabledVat) {
            
            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@establishment_name", SqlDbType.VarChar);
            param[1].Value = name;

            param[2] = new SqlParameter("@address", SqlDbType.VarChar);
            param[2].Value = address;

            param[3] = new SqlParameter("@vat_number", SqlDbType.VarChar);
            param[3].Value = vat_number;

            param[4] = new SqlParameter("@vat_percentage", SqlDbType.Int);
            param[4].Value = vat_percentage;

            param[5] = new SqlParameter("@vat_percentage_value", SqlDbType.VarChar);
            param[5].Value = vat_percentage_value;

            param[6] = new SqlParameter("@product_barcode_type", SqlDbType.Int);
            param[6].Value = product_barcode_type;

            param[7] = new SqlParameter("@enable_delete_invoices", SqlDbType.Bit);
            param[7].Value = enable_delete_invoices;

            param[8] = new SqlParameter("@enable_edit_invoices", SqlDbType.Bit);
            param[8].Value = enable_edit_invoices;

            param[9] = new SqlParameter("@show_address_in_invoice", SqlDbType.Bit);
            param[9].Value = show_address_in_invoice;

            param[10] = new SqlParameter("@created_by_id", SqlDbType.Int);
            param[10].Value = created_by_id;

            param[11] = new SqlParameter("@update_by_id", SqlDbType.Int);
            param[11].Value = update_by_id;

            param[12] = new SqlParameter("@mod_date", SqlDbType.DateTime);
            param[12].Value = mod_date;

            param[13] = new SqlParameter("@date_made", SqlDbType.DateTime);
            param[13].Value = date_made;

            param[14] = new SqlParameter("@is_enabled_vat", SqlDbType.Bit);
            param[14].Value = isEnabledVat;

            
            Layer.Open();
            Layer.ExecuteCommand("Update_System_Settings", param);
            Layer.Close();

        }

        public DataTable Get_All_System_Settings() {

            DataTable tble = new DataTable();
            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            Layer.Open();

            tble = Layer.SelectData("Get_All_Settings", null );

            Layer.Close();
            

            return tble;

        }


        public void Take_Database_Backups( string folder_source )
        {

            DB.DataAccessLayer Layer = new DB.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];


            string file_location = folder_source + "/backup-database.bak"; 

            param[0] = new SqlParameter("@file_location", SqlDbType.VarChar);
            param[0].Value = file_location;

            param[1] = new SqlParameter("@database_name", SqlDbType.VarChar);
            param[1].Value = Layer.GetDatabaseName();

            Layer.Open();
            Layer.ExecuteCommand("Backup_Database", param);
            Layer.Close();

        }
    }
}
