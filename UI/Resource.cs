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
    public partial class Resource : Form
    {

        public int resource_type;

        PL.Resources Sup = new PL.Resources();


        public static Resource frm;
        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static Resource GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Resource();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public void displayForm( int res ) {
            this.resource_type = res;
            this.Show();
        }

        public Resource()
        {

            if (frm == null)
            {
                frm = this;
            }

            InitializeComponent();

            this.Read_All_resources();

        }

        public void Read_All_resources() {

            if (this.resource_type == 0)
            {
                this.Text = "الموردين";
            }
            else {
                this.Text = "العمــلاء";
            }

            dataGridView1.DataSource = Sup.Get_All_Resource_Data(this.resource_type); 

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            dataGridView1.Columns[1].HeaderText = this.resource_type == 0 ? "كـود المورد" : "كـود العميل";
            dataGridView1.Columns[3].HeaderText = this.resource_type == 0 ?"إسم المورد" : "إسم العميل";
            dataGridView1.Columns[4].HeaderText = "الهاتف";
            dataGridView1.Columns[5].HeaderText = "العنوان";

            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 300; 

        }

        private void disableFields( bool isDisable = false ) {
            resource_name.Enabled = isDisable;
            resource_phone.Enabled = isDisable;
            resource_address.Enabled = isDisable;
            resource_email.Enabled = isDisable;
            resource_id.Enabled = isDisable;

            add_button.Enabled = !isDisable;
            delete_button.Enabled = !isDisable;
            edit_button.Enabled = !isDisable;
            save_button.Enabled = isDisable;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string resource_name_text = resource_name.Text.ToString();
            string resource_phone_text = resource_phone.Text.ToString(); 
            string resource_address_text = resource_address.Text.ToString();
            string resource_email_text = resource_email.Text.ToString();
            string resource_id_text = resource_id.Text.ToString();
             
            Sup.Update_Resource_Data(Convert.ToInt32(resource_id_text), resource_name_text, resource_phone_text, resource_address_text, resource_email_text, this.resource_type);
            
            this.Read_All_resources();
            this.disableFields();
        
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.disableFields();
            
            if (dataGridView1.CurrentRow!= null ) {

                int index = dataGridView1.CurrentRow.Index;

                resource_id.Text      = dataGridView1.Rows[index].Cells[0].Value.ToString();
                resource_code.Text      = dataGridView1.Rows[index].Cells[1].Value.ToString();

                resource_name.Text    = dataGridView1.Rows[index].Cells[3].Value.ToString();
                resource_phone.Text   = dataGridView1.Rows[index].Cells[4].Value.ToString();
                resource_address.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                resource_email.Text   = dataGridView1.Rows[index].Cells[6].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.disableFields(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (resource_id.Text != "" && resource_id.Text != "-1") {
                
                int id = Convert.ToInt32(resource_id.Text);
                dataGridView1.DataSource = Sup.Delete_Resource_Data(id, this.resource_type);

            }
            
        }

        private void add_button_Click(object sender, EventArgs e)
        {


            DataTable resoueceTable = Sup.Create_Resource_Id(this.resource_type);

            if (resoueceTable.Rows.Count > 0) { 
                
                DataRow row = resoueceTable.Rows[0];

                resource_name.Text = row["resource_name"].ToString();
                resource_phone.Text = row["resource_phone"].ToString();
                resource_address.Text = row["resource_address"].ToString();
                resource_email.Text = row["resource_email"].ToString();
                resource_code.Text = row["resource_code"].ToString();
                resource_id.Text = row["id"].ToString();

            }

            this.disableFields(true);
        }
    }
}
