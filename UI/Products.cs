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
using System.IO;

namespace sales_management.UI
{
    public partial class Products : Form
    {
        public bool isOpenUints = false;
        public bool isOpenCatsForm = false;
        public int prodIndex = 0;

        
        PL.Products prd = new PL.Products();
        DataTable table;

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
            table = this.prd.Get_All_Products(); 

            InitializeComponent();
            
            if(frm == null )
            {
                frm = this;
            }

            this.load_combobox_search_type();


            this.load_last_record();
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

        public void load_last_record() {

            

            if (table.Rows.Count > 0) {

                this.prodIndex = table.Rows.Count - 1 ;
                this.fill_product_ui_elements(table, (this.prodIndex));
                item_number_in_all.Text = table.Rows.Count.ToString() + " / " + table.Rows.Count.ToString();

            }
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
            request_limit_notify.Enabled = isEnabled;
            minmax_limit_notify.Enabled = isEnabled;
            enable_expiration_date.Enabled = isEnabled;
            datepicker_expiration_date.Enabled = isEnabled;

        }



        public void fill_product_ui_elements( DataTable table, int index = 0 ) {

            if (table.Rows.Count > 0)
            {

                DataRow row = table.Rows[index];
                DataColumnCollection columns = table.Columns;

                DataTable units_dt = prd.Get_All_Product_Units();


                if (units_dt.Rows.Count < 1)
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
                    combo_unit_name.DataSource = prd.Get_All_Product_Units();
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
                    if (row["image"] != System.DBNull.Value)
                    {

                        byte[] imageData = (byte[])row["image"];

                        //Initialize image variable
                        Image newImage;

                        //Read image data into a memory stream
                        using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                        {
                            ms.Write(imageData, 0, imageData.Length);

                            //Set image variable value using memory stream.
                            newImage = Image.FromStream(ms, true);
                        }

                        //set picture
                        pictureImage.Image = newImage;

                    }
                    else {
                        pictureImage.Image = null ;
                    }


                    // Group 1
                    gr1_unitId_text.Text = row["gr1_unit_id"].ToString();
                    gr1_unit_text.DataSource = prd.Get_All_Product_Units();
                    gr1_unit_text.ValueMember = "id";
                    gr1_unit_text.DisplayMember = "title";
                    if (row["gr1_unit_id"].ToString() != "")
                    {
                        gr1_unit_text.SelectedValue = row["gr1_unit_id"].ToString();
                    }
                    else
                    {
                        gr1_unit_text.SelectedIndex = 0;
                    }
                    gr1_purchase_text.Text = row["gr1_purchase_price"].ToString();
                    gr1_sell_text.Text = row["gr1_sale_price"].ToString();
                    gr1_less_sell_text.Text = row["gr1_less_sale_price"].ToString();
                    gr1_gather_sell_text.Text = row["gr1_wholesale_sale"].ToString();
                    gr1_transform_pr_text.Text = row["gr1_transform"].ToString();
                    gr1_barcode_text.Text = row["gr1_barcode"].ToString();

                    // Group 2
                    gr2_unitId_text.Text = row["gr2_unit_id"].ToString();
                    gr2_unit_text.DataSource = prd.Get_All_Product_Units();
                    gr2_unit_text.ValueMember = "id";
                    gr2_unit_text.DisplayMember = "title";
                    if (row["gr2_unit_id"].ToString() != "")
                    {
                        gr2_unit_text.SelectedValue = row["gr2_unit_id"].ToString();
                    }
                    else
                    {
                        gr2_unit_text.SelectedIndex = 0;
                    }
                    gr2_purchase_text.Text = row["gr2_purchase_price"].ToString();
                    gr2_sell_text.Text = row["gr2_sale_price"].ToString();
                    gr2_less_sell_text.Text = row["gr2_less_sale_price"].ToString();
                    gr2_gather_sell_text.Text = row["gr2_wholesale_sale"].ToString();
                    gr2_transform_pr_text.Text = row["gr2_transform"].ToString();
                    gr2_barcode_text.Text = row["gr2_barcode"].ToString();

                    // Group 3
                    gr3_unitId_text.Text = row["gr3_unit_id"].ToString();
                    gr3_unit_text.DataSource = prd.Get_All_Product_Units();
                    gr3_unit_text.ValueMember = "id";
                    gr3_unit_text.DisplayMember = "title";
                    if (row["gr3_unit_id"].ToString() != "")
                    {
                        gr3_unit_text.SelectedValue = row["gr3_unit_id"].ToString();
                    }
                    else
                    {
                        gr3_unit_text.SelectedIndex = 0;
                    }
                    gr3_purchase_text.Text = row["gr3_purchase_price"].ToString();
                    gr3_sell_text.Text = row["gr3_sale_price"].ToString();
                    gr3_less_sell_text.Text = row["gr3_less_sale_price"].ToString();
                    gr3_gather_sell_text.Text = row["gr3_wholesale_sale"].ToString();
                    gr3_transform_pr_text.Text = row["gr3_transform"].ToString();
                    gr3_barcode_text.Text = row["gr3_barcode"].ToString();

                    // Group 4
                    gr4_unitId_text.Text = row["gr4_unit_id"].ToString();
                    gr4_unit_text.DataSource = prd.Get_All_Product_Units();
                    gr4_unit_text.ValueMember = "id";
                    gr4_unit_text.DisplayMember = "title";
                    if (row["gr4_unit_id"].ToString() != "")
                    {
                        gr4_unit_text.SelectedValue = row["gr4_unit_id"].ToString();
                    }
                    else
                    {
                        gr4_unit_text.SelectedIndex = 0;
                    }
                    gr4_purchase_text.Text = row["gr4_purchase_price"].ToString();
                    gr4_sell_text.Text = row["gr4_sale_price"].ToString();
                    gr4_less_sell_text.Text = row["gr4_less_sale_price"].ToString();
                    gr4_gather_sell_text.Text = row["gr4_wholesale_sale"].ToString();
                    gr4_transform_pr_text.Text = row["gr4_transform"].ToString();
                    gr4_barcode_text.Text = row["gr4_barcode"].ToString();

                    // Group 5
                    gr5_unitId_text.Text = row["gr5_unit_id"].ToString();
                    gr5_unit_text.DataSource = prd.Get_All_Product_Units();
                    gr5_unit_text.ValueMember = "id";
                    gr5_unit_text.DisplayMember = "title";
                    if (row["gr5_unit_id"].ToString() != "")
                    {
                        gr5_unit_text.SelectedValue = row["gr5_unit_id"].ToString();
                    }
                    else
                    {
                        gr5_unit_text.SelectedIndex = 0;
                    }
                    gr5_purchase_text.Text = row["gr5_purchase_price"].ToString();
                    gr5_sell_text.Text = row["gr5_sale_price"].ToString();
                    gr5_less_sell_text.Text = row["gr5_less_sale_price"].ToString();
                    gr5_gather_sell_text.Text = row["gr5_wholesale_sale"].ToString();
                    gr5_transform_pr_text.Text = row["gr5_transform"].ToString();
                    gr5_barcode_text.Text = row["gr5_barcode"].ToString();

                    // Group 6
                    gr6_unitId_text.Text = row["gr6_unit_id"].ToString();
                    gr6_unit_text.DataSource = prd.Get_All_Product_Units();
                    gr6_unit_text.ValueMember = "id";
                    gr6_unit_text.DisplayMember = "title";
                    if (row["gr6_unit_id"].ToString() != "")
                    {
                        gr6_unit_text.SelectedValue = row["gr6_unit_id"].ToString();
                    }
                    else
                    {
                        gr5_unit_text.SelectedIndex = 0;
                    }
                    gr6_purchase_text.Text = row["gr6_purchase_price"].ToString();
                    gr6_sell_text.Text = row["gr6_sale_price"].ToString();
                    gr6_less_sell_text.Text = row["gr6_less_sale_price"].ToString();
                    gr6_gather_sell_text.Text = row["gr6_wholesale_sale"].ToString();
                    gr6_transform_pr_text.Text = row["gr6_transform"].ToString();
                    gr6_barcode_text.Text = row["gr6_barcode"].ToString();



                    if (row["unit_id"].ToString() != "")
                    {
                        combo_unit_name.SelectedValue = row["unit_id"].ToString();
                    }
                    else
                    {
                        combo_unit_name.SelectedIndex = 0;
                    }

                    enable_expiration_date.Checked = Convert.ToBoolean(row["enable_expiration_notification"]);
                    datepicker_expiration_date.Value = row["expiration_date"] != System.DBNull.Value ? Convert.ToDateTime(row["expiration_date"]): DateTime.Now;
                    default_price_combo.SelectedIndex = Convert.ToInt32(row["default_group"]);

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

            int cats_ID = category_text_id.Text == "" ? -1 : Convert.ToInt32(category_text_id.Text); 

            prd.Update_Product_Data(
                Convert.ToInt32(product_num_box.Text),
                product_min_limit_box.Text.ToString(),
                product_max_limit_box.Text.ToString(),
                product_request_limit_box.Text.ToString(),
                product_name_text.Text.ToString(),
                purchase_default_price.Text.ToString(),
                less_sales_price_sub.Text.ToString(),
                gather_price_sub.Text.ToString(),
                Convert.ToBoolean(request_limit_notify.Checked),
                Convert.ToBoolean(minmax_limit_notify.Checked),
                allowed_discount.Text.ToString(),
                discount_percentage_val.Text.ToString(),
                
                
                Convert.ToInt32(gr1_unit_text.SelectedValue),
                gr1_purchase_text.Text.ToString(),
                gr1_sell_text.Text.ToString(),
                gr1_less_sell_text.Text.ToString(),
                gr1_gather_sell_text.Text.ToString(),
                gr1_transform_pr_text.Text.ToString(),

                Convert.ToInt32(gr2_unit_text.SelectedValue),
                gr2_purchase_text.Text.ToString(),
                gr2_sell_text.Text.ToString(),
                gr2_less_sell_text.Text.ToString(),
                gr2_gather_sell_text.Text.ToString(),
                gr2_transform_pr_text.Text.ToString(),

                Convert.ToInt32(gr3_unit_text.SelectedValue),
                gr3_purchase_text.Text.ToString(),
                gr3_sell_text.Text.ToString(),
                gr3_less_sell_text.Text.ToString(),
                gr3_gather_sell_text.Text.ToString(),
                gr3_transform_pr_text.Text.ToString(),

                 Convert.ToInt32(gr4_unit_text.SelectedValue),
                gr4_purchase_text.Text.ToString(),
                gr4_sell_text.Text.ToString(),
                gr4_less_sell_text.Text.ToString(),
                gr4_gather_sell_text.Text.ToString(),
                gr4_transform_pr_text.Text.ToString(),

                Convert.ToInt32(gr5_unit_text.SelectedValue),
                gr5_purchase_text.Text.ToString(),
                gr5_sell_text.Text.ToString(),
                gr5_less_sell_text.Text.ToString(),
                gr5_gather_sell_text.Text.ToString(),
                gr5_transform_pr_text.Text.ToString(),

                Convert.ToInt32(gr6_unit_text.SelectedValue),
                gr6_purchase_text.Text.ToString(),
                gr6_sell_text.Text.ToString(),
                gr6_less_sell_text.Text.ToString(),
                gr6_gather_sell_text.Text.ToString(),
                gr6_transform_pr_text.Text.ToString(),

                Convert.ToInt32(combo_unit_name.SelectedValue),
                Convert.ToBoolean(enable_expiration_date.Checked),
                Convert.ToDateTime(datepicker_expiration_date.Value),
                cats_ID, 
                Convert.ToInt32(default_price_combo.SelectedIndex),
                default_price_textbox.Text.ToString()
            );
            

            if (pictureImage.ImageLocation != "" && pictureImage.ImageLocation != null)
            {

                PL.Installings ins = new PL.Installings();
                
                if (product_num_box.Text != null) {
                    prd.Update_Product_Image( Convert.ToInt32(product_num_box.Text), ins.ReadFile(pictureImage.ImageLocation));
                }
                
            }

            

            this.enalbe_proccess_inputs(false);

        }

        private void pictureImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureImage.Image = new Bitmap(opnfd.FileName);
                pictureImage.ImageLocation = opnfd.FileName;
            }
        }

        private void combo_unit_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            gr1_unitId_text.Text = combo_unit_name.SelectedValue.ToString();
        }

        private void button_last_record_Click(object sender, EventArgs e)
        {
            if ( this.prodIndex != (table.Rows.Count - 1)) {

                this.prodIndex = table.Rows.Count - 1;

                this.fill_product_ui_elements(table, (this.prodIndex));
                item_number_in_all.Text = table.Rows.Count.ToString() + " / " + table.Rows.Count.ToString();

            }
        }

        private void button_first_record_Click(object sender, EventArgs e)
        {
            if (this.prodIndex != 0 )
            {

                this.prodIndex = 0;

                this.fill_product_ui_elements(table, (this.prodIndex));
                item_number_in_all.Text = table.Rows.Count.ToString() + " / " + ( this.prodIndex + 1 ).ToString();

            }
        }

        private void button_play_prev_Click(object sender, EventArgs e)
        {

            this.prodIndex = (this.prodIndex - 1);
            if (this.prodIndex == -1) {
                this.prodIndex = 0;
            }

            this.fill_product_ui_elements(table, (this.prodIndex));
            item_number_in_all.Text = table.Rows.Count.ToString() + " / " + (this.prodIndex + 1).ToString();
        }

        private void button_play_next_Click(object sender, EventArgs e)
        {
            this.prodIndex = (this.prodIndex + 1);
            if (this.prodIndex >= table.Rows.Count )
            {
                this.prodIndex = (table.Rows.Count - 1 );
            }

            this.fill_product_ui_elements(table, (this.prodIndex));
            item_number_in_all.Text = table.Rows.Count.ToString() + " / " + (this.prodIndex + 1).ToString();
        }
    }
}
