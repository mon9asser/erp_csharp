namespace sales_management.UI
{
    partial class FRM_Stores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid_accounts_tree = new System.Windows.Forms.DataGridView();
            this.button8 = new System.Windows.Forms.Button();
            this.textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_accounts_tree
            // 
            this.datagrid_accounts_tree.AllowUserToAddRows = false;
            this.datagrid_accounts_tree.AllowUserToDeleteRows = false;
            this.datagrid_accounts_tree.AllowUserToResizeColumns = false;
            this.datagrid_accounts_tree.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_accounts_tree.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid_accounts_tree.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_accounts_tree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_accounts_tree.GridColor = System.Drawing.Color.DodgerBlue;
            this.datagrid_accounts_tree.Location = new System.Drawing.Point(12, 12);
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
            this.datagrid_accounts_tree.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_accounts_tree.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagrid_accounts_tree.ShowEditingIcon = false;
            this.datagrid_accounts_tree.Size = new System.Drawing.Size(700, 293);
            this.datagrid_accounts_tree.TabIndex = 31;
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(12, 321);
            this.button8.Name = "button8";
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button8.Size = new System.Drawing.Size(143, 34);
            this.button8.TabIndex = 39;
            this.button8.Text = "إضافة مخزن جديد";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(370, 321);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(262, 20);
            this.textbox.TabIndex = 40;
            // 
            // FRM_Stores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 368);
            this.Controls.Add(this.textbox);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.datagrid_accounts_tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_Stores";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المخازن";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView datagrid_accounts_tree;
        private System.Windows.Forms.Button button8;
        public System.Windows.Forms.TextBox textbox;
    }
}