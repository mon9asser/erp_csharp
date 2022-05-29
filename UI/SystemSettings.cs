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

        public System.Windows.Forms.TextBox input;
        DataTable All_Accounts;
        public static SystemSettings frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static SystemSettings GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new SystemSettings();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public void Fill_Target_Account_Number( string account_number ) {
            UI.SystemSettings.GetForm.input.Text = account_number;
        }

        public string Get_Account_Name( string account_number ) {
            
            string account_name = "";

            if (account_number == "")
            {
                return account_name;
            }

            foreach (DataRow row in this.All_Accounts.Rows) {
                 
                if (Convert.ToInt32(row["account_number"]).Equals(Convert.ToInt32(account_number))) {
                    account_name = row["account_name"].ToString();
                    break;
                }

            }

            return account_name;

        }
        
        public void Fill_Fields_W_Texts() {
            
            UI.SystemSettings.GetForm.cash_account_number_field_name.Text = this.Get_Account_Name(cash_account_number_field.Text.ToString());
            //UI.SystemSettings.GetForm.sale_credit_account_field_name.Text = this.Get_Account_Name(sale_credit_account_field.Text.ToString());
            UI.SystemSettings.GetForm.sale_bank_account_field_name.Text = this.Get_Account_Name(sale_bank_account_field.Text.ToString());
            //UI.SystemSettings.GetForm.purchases_account_field_name.Text = this.Get_Account_Name(purchases_account_field.Text.ToString());
            //UI.SystemSettings.GetForm.purchase_text_name_acc_credit.Text = this.Get_Account_Name(purchase_credit_acc_number.Text.ToString());
            //UI.SystemSettings.GetForm.purchase_text_name_acc_bank.Text = this.Get_Account_Name(purchase_bank_acc_number.Text.ToString());
            UI.SystemSettings.GetForm.sales_account_field_name.Text = this.Get_Account_Name(sales_vat_account_field.Text.ToString());

            UI.SystemSettings.GetForm.sales_vat_account_field_name.Text = this.Get_Account_Name(sales_account_field.Text.ToString());
            //UI.SystemSettings.GetForm.part_2_sales_text_name_acc_credit.Text = this.Get_Account_Name(part_2_sales_credit_acc_number.Text.ToString());
            //UI.SystemSettings.GetForm.part_2_sales_text_name_acc_bank.Text = this.Get_Account_Name(part_2_sales_bank_acc_number.Text.ToString());
            //UI.SystemSettings.GetForm.purchase_cash_account_field_name.Text = this.Get_Account_Name(purchase_cash_account_field.Text.ToString());
            //UI.SystemSettings.GetForm.purchase_credit_account_field_name.Text = this.Get_Account_Name(purchase_credit_account_field.Text.ToString());
            //UI.SystemSettings.GetForm.purchase_bank_account_field_name.Text = this.Get_Account_Name(purchase_bank_account_field.Text.ToString());
            UI.SystemSettings.GetForm.cost_of_goods_account_field_name.Text = this.Get_Account_Name(cost_of_goods_account_field.Text.ToString());
            UI.SystemSettings.GetForm.inventory_account_field_name.Text = this.Get_Account_Name(inventory_account_field.Text.ToString());
            UI.SystemSettings.GetForm.purchases_vat_account_field_name.Text = this.Get_Account_Name(purchases_vat_account_field.Text.ToString());

            UI.SystemSettings.GetForm.customers_account_field_name.Text = this.Get_Account_Name(customers_account_field.Text.ToString());
            UI.SystemSettings.GetForm.suppliers_account_field_name.Text = this.Get_Account_Name(suppliers_account_field.Text.ToString());

            UI.SystemSettings.GetForm.return_sales_account_name.Text = this.Get_Account_Name(return_sales_account_field.Text.ToString());
           // UI.SystemSettings.GetForm.return_purchase_account_name.Text = this.Get_Account_Name(return_purchase_account_field.Text.ToString());


        }

        public SystemSettings()
        {
            InitializeComponent();

            if (frm == null)
            {
                frm = this;
            }
            
            PL.AccountingTree accs = new PL.AccountingTree();

            this.All_Accounts = accs.Get_Accounting_Tree();
            this.load_setting_form_data();
            this.Fill_Fields_W_Texts();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png;.*.gif;)|*.jpg;*.png;*.jpeg;.*.gif";
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

                cash_account_number_field.Text = drow["sale_cash_account"].ToString();
                //sale_credit_account_field.Text = drow["sale_credit_account"].ToString();
                sale_bank_account_field.Text = drow["sale_bank_account"].ToString();
                sales_account_field.Text = drow["sales_account"].ToString();
                sales_vat_account_field.Text = drow["sales_vat_account"].ToString();
                //purchase_cash_account_field.Text = drow["purchase_cash_account"].ToString();
                //purchase_credit_account_field.Text = drow["purchase_credit_account"].ToString();
                //purchase_bank_account_field.Text = drow["purchase_bank_account"].ToString();
                //purchases_account_field.Text = drow["purchases_account"].ToString();
                purchases_vat_account_field.Text = drow["purchases_vat_account"].ToString();
                cost_of_goods_account_field.Text = drow["cost_of_goods_account"].ToString();
                inventory_account_field.Text = drow["inventory_account"].ToString();
                customers_account_field.Text = drow["customers_account"].ToString();
                suppliers_account_field.Text = drow["suppliers_account"].ToString();
                return_sales_account_field.Text = drow["return_sales_account"].ToString();
                //return_purchase_account_field.Text = drow["return_purchase_account"].ToString();
                isIncludeAddress.Checked = Convert.ToBoolean(drow["show_address_in_invoice"]);
                isIncludeUpdate.Checked = Convert.ToBoolean(drow["enable_edit_invoices"]);
                isIncludeDelete.Checked = Convert.ToBoolean(drow["enable_delete_invoices"]);
                checkbox_enable_vat.Checked = (bool) drow["enabled_vat"];
                 
                asset_account_field.Text = drow["asset_account"].ToString();
                debits_account_field.Text = drow["debits_account"].ToString();
                profits_account_field.Text = drow["profits_account"].ToString();
                owners_account_field.Text = drow["owners_account"].ToString();
                expenses_account_field.Text = drow["expenses_account"].ToString();

                if ( (bool)drow["enabled_vat"] == true) {
                    panel1.Enabled = true;
                }

                if (drow["logo"] != System.DBNull.Value ) { 

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
            

        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            int settingsID = settingsIdText.Text == "" ? -1 : Convert.ToInt32(settingsIdText.Text);
            string name = commercialName_text.Text.ToString();
            string address = address_text.Text.ToString();
            string vat_number = vatNumber_Text.Text.ToString();
            int vat_percentage = vat_percentage_number.Text == "" ? 15 : Convert.ToInt32(vat_percentage_number.Text);
            string vat_value = vat_percentage_value.Text =="" ? "1.15" : vat_percentage_value.Text.ToString();
            //int barcode_type = itemParcode_text.SelectedIndex < 0 ? 0 : Convert.ToInt32(itemParcode_text.SelectedIndex);
           
            bool address_enable = Convert.ToBoolean(isIncludeAddress.Checked);
            bool edit_enable = Convert.ToBoolean(isIncludeUpdate.Checked);
            bool delete_enable = Convert.ToBoolean(isIncludeDelete.Checked); 
            int userId = Convert.ToInt32(Main.getMainForm.getUserInfo()[0]);
            bool isEnabledVat = Convert.ToBoolean(checkbox_enable_vat.Checked);

            PL.Installings sysSettings = new PL.Installings();
            sysSettings.Update_Settings_System(

                settingsID,
                name,
                address,
                vat_number,
                vat_percentage,
                vat_value,
                0,
                delete_enable,
                edit_enable,
                address_enable,
                userId,
                userId,
                DateTime.Now,
                DateTime.Now,
                isEnabledVat, 

                cash_account_number_field.Text, 
                sale_bank_account_field.Text,
                sales_account_field.Text,
                sales_vat_account_field.Text, 
                purchases_vat_account_field.Text,
                cost_of_goods_account_field.Text,
                inventory_account_field.Text,
                customers_account_field.Text,
                suppliers_account_field.Text, 
                return_sales_account_field.Text, 
                asset_account_field.Text,
                debits_account_field.Text,
                profits_account_field.Text,
                owners_account_field.Text,
                expenses_account_field.Text
            );

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
          

        private void sales_cash_acc_number_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = cash_account_number_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }


        private void sales_bank_acc_number_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = sale_bank_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }
         
         
         

        private void vat_acc_number_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = sales_vat_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }
         

        private void part_2_sales_cash_acc_number_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = sales_account_field; 
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }
         

        private void product_cost_acc_number_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = cost_of_goods_account_field; 
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }
         

        private void textBox2_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = purchases_vat_account_field; 
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void customer_acc_number_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = customers_account_field; 
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void supplier_acc_number_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = suppliers_account_field; 
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void vat_acc_number_TextChanged_1(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.Fill_Fields_W_Texts();
        }

        private void inventory_account_field_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = inventory_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }
 
         

        private void return_sales_account_field_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = return_sales_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void asset_account_field_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = asset_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void debits_account_field_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = debits_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void profits_account_field_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = profits_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void owners_account_field_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = owners_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }

        private void expenses_account_field_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.input = expenses_account_field;
            UI.___Accounts.GetForm.InstanceType = 0;
            UI.___Accounts.GetForm.ShowDialog();
        }
    } 

}
