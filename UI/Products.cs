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
            comboBox6.Enabled = isEnabled;
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
            price_included.Enabled = isEnabled;
        }

        public void Create_Product_ID() {

            DataTable dtble = new DataTable();
            dtble = prd.Create_Product_ID();

        }

        private void add_new_Click(object sender, EventArgs e)
        {
            //this.Create_Product_ID();
            this.enalbe_proccess_inputs(true);
        }

        private void save_button_Click(object sender, EventArgs e)
        {

            this.enalbe_proccess_inputs(false);
        }
    }
}
