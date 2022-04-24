namespace sales_management.UI
{
    partial class FRM_AccountsGuid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_AccountsGuid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accounting_tree = new System.Windows.Forms.TreeView();
            this.datagrid_accounts_tree = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.account_number = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelWait = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).BeginInit();
            this.panelWait.SuspendLayout();
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_accounts_tree.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid_accounts_tree.RowHeadersVisible = false;
            this.datagrid_accounts_tree.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.datagrid_accounts_tree.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid_accounts_tree.RowTemplate.Height = 26;
            this.datagrid_accounts_tree.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
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
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelWait
            // 
            this.panelWait.Controls.Add(this.label1);
            resources.ApplyResources(this.panelWait, "panelWait");
            this.panelWait.Name = "panelWait";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button8, "button8");
            this.button8.Image = global::sales_management.Properties.Resources.save_data;
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button7, "button7");
            this.button7.Image = global::sales_management.Properties.Resources.delete_16;
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // FRM_AccountsGuid
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWait);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.account_number);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.datagrid_accounts_tree);
            this.Controls.Add(this.accounting_tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_AccountsGuid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).EndInit();
            this.panelWait.ResumeLayout(false);
            this.panelWait.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        public System.Windows.Forms.DataGridView datagrid_accounts_tree;
        private System.Windows.Forms.TextBox account_number;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TreeView accounting_tree;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Panel panelWait;
        private System.Windows.Forms.Label label1;
    }
}