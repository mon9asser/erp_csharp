using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_management.UI
{
    public partial class FND___UpdateSupplier : Form
    {
         
        public static FND___UpdateSupplier frm;
        public FND___Suppliers Supplier_Form;
        public DataTable Resource_Table;
          

        public FND___UpdateSupplier(DataTable resoTable, FND___Suppliers supplier )
        {
            try
            {
                this.Supplier_Form = supplier;
                this.Resource_Table = resoTable;
                InitializeComponent();

                this.Set_Data_Of_Suppliers();
            }
            catch (Exception) { }
        }

        public void Set_Data_Of_Suppliers() {
            try {
                if (this.Resource_Table.Rows.Count > 0)
                {

                    DataRow row = this.Resource_Table.Rows[0];
                    resource_name.Text = row["resource_name"].ToString();
                    phone_number.Text = row["resource_phone"].ToString();
                    address.Text = row["resource_address"].ToString();
                    email_text.Text = row["resource_email"].ToString();
                    id_text.Text = row["id"].ToString();
                    account_number.Text = row["resource_code"].ToString();
                    vat_number.Text = row["vat_number"].ToString();
                    establishment_name.Text = row["establishment_name"].ToString();
                }
            } catch (Exception) { } 
        }
         

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            try {
                PL.Resources Sup = new PL.Resources();
                Sup.Update_Resource_Data(Convert.ToInt32(id_text.Text), resource_name.Text.ToString(), phone_number.Text.ToString(), address.Text.ToString(), email_text.Text.ToString(), establishment_name.Text.ToString(), vat_number.Text.ToString(), 0);

                this.Supplier_Form.Read_All_resources(true);
                this.Close();
            }
            catch (Exception) {  }
        }
    }
}
