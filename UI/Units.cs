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
    public partial class Units : Form
    {
        
        PL.Products prods = new PL.Products();

        public static Units frm;
        
        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Units getMainForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Units();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }
    

        public Units()
        {
            InitializeComponent();
            
            if (frm == null) {
                frm = this;
            }

            this.load_datagridview_units(); 
        
        }

         

        public void load_datagridview_units() {
            
            dataGridView1.DataSource = prods.Get_All_Product_Units();

            dataGridView1.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
            dataGridView1.Columns["id"].Visible = false;

            dataGridView1.Columns["title"].Visible = true;
            dataGridView1.Columns["shortcut"].Visible = true;
            dataGridView1.Columns["unit_counts"].Visible = true; 
            dataGridView1.Columns["mod_date"].Visible = true;
            dataGridView1.Columns["mod_date"].ReadOnly = true; 
            dataGridView1.Columns["id"].ReadOnly = true;

            dataGridView1.Columns["title"].HeaderText = "نوع الوحدة";
            dataGridView1.Columns["shortcut"].HeaderText = "إختصار الوحدة";
            dataGridView1.Columns["unit_counts"].HeaderText = "عدد الوحدات";
            dataGridView1.Columns["mod_date"].HeaderText = "تاريخ التحديث";

            dataGridView1.Columns["title"].Width = 250;
            dataGridView1.Columns["shortcut"].Width = 183;
            dataGridView1.Columns["unit_counts"].Width = 140;
            dataGridView1.Columns["mod_date"].Width = 140;
             

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            int gridCounts = dataGridView1.Rows.Count;
            for (int i = 0; i < gridCounts; i++) {

    
                string id = (null == dataGridView1.Rows[i].Cells[0].Value ) ? "" : dataGridView1.Rows[i].Cells[0].Value.ToString();
                string title = null == dataGridView1.Rows[i].Cells[1].Value ? "" : dataGridView1.Rows[i].Cells[1].Value.ToString();
                string shortcut = null == dataGridView1.Rows[i].Cells[2].Value ? "" : dataGridView1.Rows[i].Cells[2].Value.ToString();
                string unit_counts = null == dataGridView1.Rows[i].Cells[3].Value ? "1" : dataGridView1.Rows[i].Cells[3].Value.ToString();
                DateTime mod_date = DateTime.Now;

               if (id == "") {
                    id = "-1";
               }

               if( title != "" && shortcut != "" ) {
                  prods.Update_Product_Units(Convert.ToInt32(id), title, shortcut, unit_counts);
               }
    
            }

        }

        private void delete_button_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null) { 
                
                if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() != "")
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                        dataGridView1.DataSource = prods.Delete_Product_Units(id);
                    }
                    else {

                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable ds = (DataTable)dataGridView1.DataSource;
            DataRow dr = ds.NewRow();
            ds.Rows.InsertAt(dr, (dataGridView1.Rows.Count - 1  ) + 1);
            dataGridView1.DataSource = ds;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UI.Products.getForm.isOpenUints) {

                UI.Products.getForm.isOpenUints = false;

                if (dataGridView1.CurrentRow != null)
                {
                    MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
                }

                this.Close();
            }
        }
    }
}
