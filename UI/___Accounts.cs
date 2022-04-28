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
    public partial class ___Accounts : Form
    {
        PL.AccountingTree tree = new PL.AccountingTree();
        DataTable table;
        public int InstanceType = 0;
        

        public static ___Accounts frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static ___Accounts GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new ___Accounts();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }
         

        public ___Accounts()
        {
            InitializeComponent();

            try {
                if (frm == null)
                {
                    frm = this;
                }

                this.table = tree.Get_Accounting_Tree();
                this.Fill_Accounting_Tree();
            } catch (Exception) { }
        }

        IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in Collect(node.Nodes))
                    yield return child;
            }
        }
        public void Fill_Tree_View(int acc_number, string acc_title, string parent_account)
        {

            if (Convert.ToInt32(parent_account) == 0)
            {
                TreeNode nodes = new TreeNode();
                nodes.Text = acc_title.ToString();
                nodes.Tag = acc_number.ToString();
                accounting_tree.Nodes.Add(nodes);
            }

            foreach (var node in Collect(accounting_tree.Nodes))
            {

                if (Convert.ToInt32(parent_account) != 0 && Convert.ToInt32(node.Tag).Equals(Convert.ToInt32(parent_account)))
                {
                    TreeNode childer = new TreeNode();
                    childer.Text = acc_title.ToString();
                    childer.Tag = acc_number.ToString();
                    node.Nodes.Add(childer);
                }

            }

        }

        public void Fill_Accounting_Tree()
        {

            accounting_tree.Nodes.Clear();

            table = tree.Get_Accounting_Tree();

            foreach (DataRow row in table.Rows)
            {

                int acc_number = Convert.ToInt32(row["account_number"]);
                string acc_title = row["account_name"].ToString();
                string parent_account = row["main_account"].ToString();

                this.Fill_Tree_View(acc_number, acc_title, parent_account);


            }



            accounting_tree.ExpandAll();

        }

        private void accounting_tree_DoubleClick(object sender, EventArgs e)
        {
            
            if( !accounting_tree.SelectedNode.IsSelected )
            {
                return; 
            }
             
            if (this.InstanceType == 0)
            {
                // System Settings 
                UI.SystemSettings.GetForm.input.Text = accounting_tree.SelectedNode.Tag.ToString();
                UI.SystemSettings.GetForm.Fill_Target_Account_Number(UI.SystemSettings.GetForm.input.Text);
            }
            else if (this.InstanceType == 1) {

                // Sales Invoice 
                UI.AA___salesInvoice.GetForm.legend_name.Text = accounting_tree.SelectedNode.Text.ToString();
                UI.AA___salesInvoice.GetForm.legend_number.Text = accounting_tree.SelectedNode.Tag.ToString();
                UI.AA___salesInvoice.GetForm.legend_id.Text = "-1";

            }

            //MessageBox.Show(this.InstanceType.ToString());
            this.Close();
        }
    }
}
