using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sales_management.UI
{
    public partial class SystemSettings : Form
    {
        public SystemSettings()
        {
            InitializeComponent();

            this.load_setting_form_data();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                logoImage_byte.Image = new Bitmap(opnfd.FileName);
                logoImage_byte.ImageLocation = opnfd.FileName;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int percentValueHun = Convert.ToInt32(vat_percentage_number.Text) + 100;
            decimal percentVal = percentValueHun / 100m;
            vat_percentage_value.Text = percentVal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void load_setting_form_data() {
            
            PL.Installings install = new PL.Installings();
            
            DataTable tbl = new DataTable();
            tbl = install.Get_All_System_Settings();

            if (tbl.Rows.Count > 0) {
                
                DataRow drow = tbl.Rows[0];

                settingsIdText.Text = drow["id"].ToString();
                commercialName_text.Text = drow["establishment_name"].ToString();
                address_text.Text = drow["address"].ToString();
                vatNumber_Text.Text = drow["vat_number"].ToString();
                vat_percentage_number.Text = drow["vat_percentage"].ToString();
                vat_percentage_value.Text = drow["vat_value"].ToString();
                itemParcode_text.SelectedIndex =Convert.ToInt32(drow["product_barcode_type"]);
                isIncludeAddress.Checked = Convert.ToBoolean(drow["show_address_in_invoice"]);
                isIncludeUpdate.Checked = Convert.ToBoolean(drow["enable_edit_invoices"]);
                isIncludeDelete.Checked = Convert.ToBoolean(drow["enable_delete_invoices"]);
                checkbox_enable_vat.Checked = (bool) drow["enabled_vat"];

                if ( (bool)drow["enabled_vat"] == true) {
                    panel1.Enabled = true;
                }

                byte[] imageData = (byte []) drow["logo"];

                //Initialize image variable
                Image newImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }
                //
                //set picture
                logoImage_byte.Image = newImage;

            }
            

        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            int settingsID = settingsIdText.Text == "" ? -1 : Convert.ToInt32(settingsIdText.Text);
            string name = commercialName_text.Text.ToString();
            string address = address_text.Text.ToString();
            string vat_number = vatNumber_Text.Text.ToString();
            int vat_percentage = vat_percentage_number.Text == "" ? 15 : Convert.ToInt32(vat_percentage_number.Text);
            string vat_value = vat_percentage_value.Text =="" ? "1.15" : vat_percentage_value.Text.ToString();
            int barcode_type = itemParcode_text.SelectedIndex < 0 ? 0 : Convert.ToInt32(itemParcode_text.SelectedIndex);
            bool address_enable = Convert.ToBoolean(isIncludeAddress.Checked);
            bool edit_enable = Convert.ToBoolean(isIncludeUpdate.Checked);
            bool delete_enable = Convert.ToBoolean(isIncludeDelete.Checked); 
            int userId = Convert.ToInt32(Main.getMainForm.getUserInfo()[0]);
            bool isEnabledVat = Convert.ToBoolean(checkbox_enable_vat.Checked);

            PL.Installings sysSettings = new PL.Installings();
            sysSettings.Update_Settings_System(settingsID, name, address, vat_number, vat_percentage, vat_value, barcode_type, delete_enable, edit_enable, address_enable, userId, userId, DateTime.Now, DateTime.Now, isEnabledVat );

            if ( logoImage_byte.ImageLocation != "" && logoImage_byte.ImageLocation != null ) {

                sysSettings.Update_Settings_System_Logo( settingsID, sysSettings.ReadFile(logoImage_byte.ImageLocation) );

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_enable_vat.Checked == true)
            {
                panel1.Enabled = true;
            }
            else {
                panel1.Enabled = false;
            }
        }
    }
}
