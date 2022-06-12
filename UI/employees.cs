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
    public partial class employees : Form
    {
        PL.Users U = new PL.Users();

        public DataTable Users;
        public int userIndex = 0;

        public employees()
        {
            this.Users = U.Get_All_Users();
            InitializeComponent();

            this.Fill_User_Data_According_To_Index(-1);
        }

        public void Fill_User_Data_According_To_Index(int index) {

            if (this.Users.Rows.Count == 0) {
                return; 
            }

            if (index == -1) {
                if (this.Users.Rows.Count != 0) {
                    index = this.Users.Rows.Count - 1;
                }
            } 

            DataRow row = this.Users.Rows[index];

            string username = row["username"].ToString();
            string fullname = row["fullname"].ToString();
            string password = row["password"].ToString();
            bool is_manager = Convert.ToBoolean(row["is_manager"]);
            int user_id_    = Convert.ToInt32(row["id"]);

            user_id.Text = user_id_.ToString();
            user_name.Text = username;
            full_name.Text = fullname;
            password_field.Text = password;
            is_manager_check.Checked = is_manager;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (user_id.Text == "")
            {
                return;
            }

            U.Delete(Convert.ToInt32(user_id.Text));

            this.Users = U.Get_All_Users();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int user_id_value = -1;

            if (user_id.Text != "") {
                user_id_value = Convert.ToInt32(user_id.Text);
            }

            U.Update(
                user_name.Text,
                full_name.Text,
                password_field.Text,
                is_manager_check.Checked,
                user_id_value
            );

            this.Users = U.Get_All_Users();
        }

        private void first_record_button_Click(object sender, EventArgs e)
        {
            if (this.Users.Rows.Count == 0)
            {
                return;
            }
            this.userIndex = 0;
            this.Fill_User_Data_According_To_Index(this.userIndex);
        }

        private void last_record_button_Click(object sender, EventArgs e)
        {
            if (this.Users.Rows.Count == 0) {
                return;
            }

            this.userIndex = this.Users.Rows.Count - 1;
            this.Fill_User_Data_According_To_Index(this.userIndex);
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            if (this.Users.Rows.Count == 0)
            {
                return;
            }

            this.userIndex++;
            if (this.userIndex > (this.Users.Rows.Count - 1)) {
                this.userIndex = this.Users.Rows.Count - 1;
            }

            this.Fill_User_Data_According_To_Index(this.userIndex);
        }

        private void previous_button_Click(object sender, EventArgs e)
        {
            if (this.Users.Rows.Count == 0)
            {
                return;
            }

            this.userIndex--;
            if (this.userIndex < 0)
            {
                this.userIndex = 0;
            }

            this.Fill_User_Data_According_To_Index(this.userIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user_id.Text = "";
            user_name.Text = "";
            full_name.Text = "";
            password_field.Text = "";
            is_manager_check.Checked = false;

        }
    }
}
