namespace sales_management.UI
{
    partial class AccTree
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccTree));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accounting_tree = new System.Windows.Forms.TreeView();
            this.datagrid_accounts_tree = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.account_type = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.account_number = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.account_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.main_account_number = new System.Windows.Forms.TextBox();
            this.account_name_en = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accounting_tree
            // 
            resources.ApplyResources(this.accounting_tree, "accounting_tree");
            this.accounting_tree.Name = "accounting_tree";
            this.accounting_tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.accounting_tree_AfterSelect);
            // 
            // datagrid_accounts_tree
            // 
            this.datagrid_accounts_tree.AllowUserToResizeColumns = false;
            this.datagrid_accounts_tree.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_accounts_tree.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid_accounts_tree.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_accounts_tree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_accounts_tree.GridColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this.datagrid_accounts_tree, "datagrid_accounts_tree");
            this.datagrid_accounts_tree.MultiSelect = false;
            this.datagrid_accounts_tree.Name = "datagrid_accounts_tree";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_accounts_tree.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid_accounts_tree.RowHeadersVisible = false;
            this.datagrid_accounts_tree.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.datagrid_accounts_tree.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid_accounts_tree.RowTemplate.Height = 26;
            this.datagrid_accounts_tree.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrid_accounts_tree.ShowEditingIcon = false;
            this.datagrid_accounts_tree.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_accounts_tree_CellClick);
            this.datagrid_accounts_tree.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_accounts_tree_CellEndEdit);
            this.datagrid_accounts_tree.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_accounts_tree_CellValueChanged);
            this.datagrid_accounts_tree.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.datagrid_accounts_tree_EditingControlShowing);
            this.datagrid_accounts_tree.KeyUp += new System.Windows.Forms.KeyEventHandler(this.datagrid_accounts_tree_KeyUp);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button9, "button9");
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.account_type);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.account_number);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.account_name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.main_account_number);
            this.panel1.Controls.Add(this.account_name_en);
            this.panel1.Controls.Add(this.label3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // account_type
            // 
            this.account_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.account_type.FormattingEnabled = true;
            this.account_type.Items.AddRange(new object[] {
            resources.GetString("account_type.Items"),
            resources.GetString("account_type.Items1")});
            resources.ApplyResources(this.account_type, "account_type");
            this.account_type.Name = "account_type";
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // account_number
            // 
            resources.ApplyResources(this.account_number, "account_number");
            this.account_number.Name = "account_number";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // account_name
            // 
            resources.ApplyResources(this.account_name, "account_name");
            this.account_name.Name = "account_name";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // main_account_number
            // 
            resources.ApplyResources(this.main_account_number, "main_account_number");
            this.main_account_number.Name = "main_account_number";
            this.main_account_number.ReadOnly = true;
            // 
            // account_name_en
            // 
            resources.ApplyResources(this.account_name_en, "account_name_en");
            this.account_name_en.Name = "account_name_en";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // AccTree
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.datagrid_accounts_tree);
            this.Controls.Add(this.accounting_tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AccTree";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView accounting_tree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        public System.Windows.Forms.DataGridView datagrid_accounts_tree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox account_type;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox account_number;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox account_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox main_account_number;
        private System.Windows.Forms.TextBox account_name_en;
        private System.Windows.Forms.Label label3;
    }
}