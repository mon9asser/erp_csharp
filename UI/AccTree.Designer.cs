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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accounting_tree = new System.Windows.Forms.TreeView();
            this.datagrid_accounts_tree = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.account_number = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).BeginInit();
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_accounts_tree.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.datagrid_accounts_tree.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_accounts_tree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_accounts_tree.GridColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this.datagrid_accounts_tree, "datagrid_accounts_tree");
            this.datagrid_accounts_tree.MultiSelect = false;
            this.datagrid_accounts_tree.Name = "datagrid_accounts_tree";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_accounts_tree.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.button8.Click += new System.EventHandler(this.button8_Click);
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
            // account_number
            // 
            resources.ApplyResources(this.account_number, "account_number");
            this.account_number.Name = "account_number";
            // 
            // AccTree
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.account_number);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.datagrid_accounts_tree);
            this.Controls.Add(this.accounting_tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AccTree";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).EndInit();
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
        private System.Windows.Forms.TextBox account_number;
    }
}