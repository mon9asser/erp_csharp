using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sales_management.UI
{
    public partial class Products : Form
    {
        public bool isOpenUints = false;
        public bool isOpenCatsForm = false;
        PL.Products prd = new PL.Products();

        public static Products frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Products getForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Products();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public Products()
        {
            InitializeComponent();
            
            if(frm == null )
            {
                frm = this;
            }

            this.load_combobox_search_type();

        }

        // load combbox of search type 
        public void load_combobox_search_type() {
            search_type_combobox.SelectedIndex = 2;
        }

        // Disply uniit management
        private void textBox7_Click(object sender, EventArgs e)
        {
            UI.Products.getForm.isOpenUints = true;
            UI.Units.getMainForm.addnew_button.Enabled = false;
            UI.Units.getMainForm.delete_button.Enabled = false;
            UI.Units.getMainForm.save_button.Enabled = false;
            UI.Units.getMainForm.dataGridView1.AllowUserToAddRows = false;

            if (UI.Units.getMainForm.IsDisposed != true) {
                UI.Units.getMainForm.Show();
            }
            
        }

        private void product_cats_MouseClick(object sender, MouseEventArgs e)
        {
            if (product_name_text.Enabled == true) { 
                UI.Products.getForm.isOpenCatsForm = true;
                UI.Categories.getForm.ShowDialog();
            }
        }

        public void load_system_settings() { 
            
        }

        public void enalbe_proccess_inputs( bool isEnabled ) {
 
            product_min_limit_box.Enabled = isEnabled;
            product_max_limit_box.Enabled = isEnabled;
            product_request_limit_box.Enabled = isEnabled;
            product_name_text.Enabled = isEnabled;
            combo_unit_name.Enabled = isEnabled;
            purchase_default_price.Enabled = isEnabled;
            default_price_textbox.Enabled = isEnabled;
            less_sales_price_sub.Enabled = isEnabled;
            gather_price_sub.Enabled = isEnabled;
            default_price_barcode.Enabled = isEnabled;
            request_limit_notify.Enabled = isEnabled;
            minmax_limit_notify.Enabled = isEnabled;
            allowed_discount.Enabled = isEnabled;
            discount_percentage_val.Enabled = isEnabled;
            pictureImage.Enabled = isEnabled;
            groupBox3.Enabled = isEnabled;
            groupBox4.Enabled = isEnabled;
            groupBox5.Enabled = isEnabled;
            groupBox8.Enabled = isEnabled;
            groupBox7.Enabled = isEnabled;
            groupBox6.Enabled = isEnabled;

            delete_button.Enabled = !isEnabled;
            update_button.Enabled = !isEnabled;
            save_button.Enabled = isEnabled;

            button_first_record.Enabled = !isEnabled;
            button_last_record.Enabled = !isEnabled;
            button_play_prev.Enabled = !isEnabled;
            button_play_next.Enabled = !isEnabled;
            item_number_in_all.Enabled = !isEnabled;

            search_type_combobox.Enabled = !isEnabled;
            search_textbox.Enabled = !isEnabled;
            search_button.Enabled = !isEnabled;
            add_new.Enabled = !isEnabled;

            default_price_combo.Enabled = isEnabled;
        }
         
         

        public void fill_product_ui_elements( DataTable table ) {

            if (table.Rows.Count > 0)
            {

                DataRow row = table.Rows[0];
                DataColumnCollection columns = table.Columns;

                DataTable units = prd.Get_All_Product_Units();


                if (units.Rows.Count < 1)
                {

                    MessageBox.Show("من فضلك قم بتعريف الوحدات التخزينية أولا ومن بعدها يمكنك إضافة منتج جديد");
                    UI.Products.getForm.Close();
                    UI.Units.getMainForm.Show();
                }
                else { 

                    

                    default_price_barcode.Text = row["code"].ToString();
                    product_num_box.Text = row["id"].ToString();
                    product_min_limit_box.Text = row["min_limit"].ToString();
                    product_max_limit_box.Text = row["max_limit"].ToString();
                    category_text_id.Text = row["category_id"].ToString();
                    product_cats.Text = columns.Contains("category") ? row["category"].ToString(): "";
                    product_request_limit_box.Text = row["request_limit"].ToString();
                    product_name_text.Text = row["name"].ToString();
                    get_inventory_value.Text = row["invetory_value"].ToString();

                    defaultUnitId_Text.Text = row["unit_id"].ToString();

                    // Default Group  
                    combo_unit_name.DataSource = units;
                    combo_unit_name.ValueMember = "id";
                    combo_unit_name.DisplayMember = "title";
                    if (row["unit_id"].ToString() != "")
                    {
                        combo_unit_name.SelectedValue = row["unit_id"].ToString();
                    }
                    else {
                        combo_unit_name.SelectedIndex = 0;
                    }
                    purchase_default_price.Text = row["purchase_price"].ToString();
                    default_price_textbox.Text = row["default_sale_price"].ToString();
                    less_sales_price_sub.Text = row["less_sale_price"].ToString();
                    gather_price_sub.Text = row["wholesale_sale"].ToString();
                    request_limit_notify.Checked = Convert.ToBoolean(row["request_limit_notify"]) ;
                    minmax_limit_notify.Checked = Convert.ToBoolean(row["minmax_limit_notify"]);
                    allowed_discount.Text = row["allowed_discount"].ToString();
                    discount_percentage_val.Text = row["discount_percentage_val"].ToString();
                    default_price_combo.SelectedIndex = Convert.ToInt32(row["default_group"]);

                     
                    // pictureImage 
                    if ( row["image"] != System.DBNull.Value) {
                        MessageBox.Show("Image Not Null");
                    } else
                    {
                        MessageBox.Show("Image Is Null");
                    }
                   
                    

                }
            } else
            {
                MessageBox.Show("حدث خطأ .. من فضلك تأكد من إتصال السيرفر المحلي ويفضل الإتصال بالدعم الفني");
                UI.Products.getForm.Close();
            }

        }

        private void add_new_Click(object sender, EventArgs e)
        {
            this.fill_product_ui_elements( prd.Create_Product_ID() );
            this.enalbe_proccess_inputs(true);
        }

        private void save_button_Click(object sender, EventArgs e)
        {

            this.enalbe_proccess_inputs(false);
        }
    }
}
