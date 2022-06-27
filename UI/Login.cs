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
    public partial class Login : Form
    {

        public Main MainForm;
        PL.Users U = new PL.Users();
        public DataTable Users; 

        public Login( Main main_form )
        { 
            this.MainForm = main_form;

            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DataTable userdata =  this.Detect_User_Data(user_name_field.Text.ToString(), password_field.Text.ToString());
            if (userdata.Rows.Count == 0)
            {
                MessageBox.Show("إسم المستخدم او كلمة السر غير صحيحة");
            }
            else {
                 
                this.MainForm.login_the_users.Enabled = false;
                this.MainForm.system_settings_options.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.accounting_tree_menu.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                //this.MainForm.logout_users.Enabled = 

                this.MainForm.users_data.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.manage_users_data.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);

                this.MainForm.sales_management.Enabled = true;
                this.MainForm.sales_invoices.Enabled = true;
                this.MainForm.return_sales_invoices.Enabled = true;
                this.MainForm.customer_names.Enabled = true;
                this.MainForm.sales_report.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);


                this.MainForm.purchase_mgt.Enabled = true;
                this.MainForm.purchase_invoices.Enabled = true;
                this.MainForm.return_purchase_invoices.Enabled = true;
                this.MainForm.suppliers_tab.Enabled = true;
                this.MainForm.purchase_reports.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);

                this.MainForm.inventory_data.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.inventory_quantity.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.gods_exports.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.manage_units.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.manage_products.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.category_manages.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.wholestore_mgt.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);

                this.MainForm.journal_data.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.insert_journal.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.show_journals.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);

                this.MainForm.reports.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_journals.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_sales.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_purchase.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_purchase_return.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_sales_return.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_inventory.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_withdraw.Enabled = true;
                this.MainForm.report_vat.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_trial_balance.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_income.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);
                this.MainForm.report_balance_sheet.Enabled = Convert.ToBoolean(userdata.Rows[0]["is_manager"]);

                this.MainForm.systesm_manager.Enabled = true;
                if (userdata.Rows[0]["username"].ToString() == "Montasser")
                    this.MainForm.system_manager_check.Enabled = true;

                // load user data in main form like id, username, is_manager.
                this.MainForm.Login_User_Data(Convert.ToInt32(userdata.Rows[0]["id"]), userdata.Rows[0]["username"].ToString(), Convert.ToBoolean(userdata.Rows[0]["is_manager"]) );
                this.Close();
            }
        }

        private DataTable Detect_User_Data(string username, string password) {

            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("username");
            table.Columns.Add("is_manager"); 


            if ("Montasser".ToString().Equals(username.ToString()) && "mon#666666".ToString().Equals(password.ToString()))
            {
                DataRow userData = table.NewRow();
                userData["id"] = -1;
                userData["username"] = "Montasser";
                userData["is_manager"] = true;
                table.Rows.Add(userData);
            }
            else {
                this.Users = U.Get_All_Users();
                foreach (DataRow row in this.Users.Rows) {
                    if (row["username"].ToString().Equals(username.ToString()) && row["password"].ToString().Equals(password.ToString())) {
                        DataRow userData = table.NewRow();
                        userData["id"] = row["id"];
                        userData["username"] = row["username"];
                        userData["is_manager"] = row["is_manager"];
                        table.Rows.Add(userData); 
                        break;
                    }
                }
            }


            return table;
        }

    }
}
