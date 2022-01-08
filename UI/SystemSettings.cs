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
    public partial class SystemSettings : Form
    {
        public SystemSettings()
        {
            InitializeComponent();
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
            MessageBox.Show("Changed ...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int settingsID = Convert.ToInt32(settingsIdText.Text);
            string name = commercialName_text.ToString();
            string vat_number = vatNumber_Text.ToString();
            string image_src = logoImage_byte.ImageLocation.ToString();
            string address = address_text.Text.ToString();
            int vat_percentage = Convert.ToInt32(vat_percentage_number.Text);
            double vat_value = Convert.ToDouble(vat_percentage_value.Text);
            int barcode_type = Convert.ToInt32(itemParcode_text.SelectedIndex);
            bool address_enable = Convert.ToBoolean(isIncludeAddress.Checked);
            bool edit_enable = Convert.ToBoolean(isIncludeUpdate.Checked);
            bool delete_enable =  Convert.ToBoolean(isIncludeDelete.Checked);
            

        }
    }
}
