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
    public partial class Categories : Form
    {
        
        PL.Products prod = new PL.Products();

        public Categories()
        {
            InitializeComponent();

            this.load_categories_data_gridview(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.is_enabled_categories_add_new(true);
            this.empty_categories_fields();
        }

        public void empty_categories_fields() {
            cats_name_text.Text = "";
            cat_code_text.Text = "";
        }
        
        public void is_enabled_categories_add_new( bool is_enabled ) {
            cats_name_text.Enabled = is_enabled; 
            save_button.Enabled = is_enabled;
        }


        public void load_categories_data_gridview() {
            
            datagridview_cats.DataSource = prod.Get_All_Categories();

            datagridview_cats.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
            datagridview_cats.Columns["id"].Visible = false;

            datagridview_cats.Columns["category"].Visible = true;
            datagridview_cats.Columns["name"].Visible = true;
            datagridview_cats.Columns["mod_date"].Visible = true;

            datagridview_cats.Columns["category"].HeaderText = "إسم الفئــــة";
            datagridview_cats.Columns["name"].HeaderText = "أخر تحديث بواسطة";
            datagridview_cats.Columns["mod_date"].HeaderText = "تاريخ التحديث";

            datagridview_cats.Columns["category"].Width = 260;
            datagridview_cats.Columns["name"].Width = 183;
            datagridview_cats.Columns["mod_date"].Width = 140; 

            /**
             * datagridview_cats.Columns["id"].Visible = false;
            datagridview_cats.Columns["created_by"].Visible = false;
            datagridview_cats.Columns["created_date"].Visible = false;

            datagridview_cats.Columns["category"].HeaderText = "إسم الفئــــة";
            datagridview_cats.Columns["updated_by"].HeaderText = "أخر تحديث بواسطة";
            datagridview_cats.Columns["mod_date"].HeaderText = "تاريخ التحديث";

            datagridview_cats.Columns["category"].Width = 260;
            datagridview_cats.Columns["updated_by"].Width = 200;
            datagridview_cats.Columns["mod_date"].Width = 160;
            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string category = cats_name_text.Text.ToString();
            int code_id = cat_code_text.Text == "" ? -1 : Convert.ToInt32(cat_code_text.Text);

            prod.Update_Categories(code_id, category, Convert.ToInt32(Main.getMainForm.getUserInfo()[0]));

            this.load_categories_data_gridview();

            this.is_enabled_categories_add_new(false);

        }

        private void datagridview_cats_SelectionChanged(object sender, EventArgs e)
        { 

            if(datagridview_cats.CurrentRow != null )
            {
                int id = Convert.ToInt32(datagridview_cats.Rows[datagridview_cats.CurrentRow.Index].Cells[0].Value);
                cat_code_text.Text = id.ToString();

                cats_name_text.Text = datagridview_cats.Rows[datagridview_cats.CurrentRow.Index].Cells[1].Value.ToString();

                delete_button.Enabled = true;
                edit_button.Enabled = true;
            }

        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            this.is_enabled_categories_add_new(true);
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            int code_id = cat_code_text.Text == "" ? -1 : Convert.ToInt32(cat_code_text.Text);
            if (code_id != -1) {
                
                prod.Delete_Category(code_id);
                
                this.load_categories_data_gridview();
                this.is_enabled_categories_add_new(false);

            }
        }
    }
}
