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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid_accounts_tree = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.idselected = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_accounts_tree
            // 
            this.datagrid_accounts_tree.AllowUserToAddRows = false;
            this.datagrid_accounts_tree.AllowUserToDeleteRows = false;
            this.datagrid_accounts_tree.AllowUserToResizeColumns = false;
            this.datagrid_accounts_tree.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_accounts_tree.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.datagrid_accounts_tree.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_accounts_tree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_accounts_tree.GridColor = System.Drawing.Color.DodgerBlue;
            this.datagrid_accounts_tree.Location = new System.Drawing.Point(12, 12);
            this.datagrid_accounts_tree.MultiSelect = false;
            this.datagrid_accounts_tree.Name = "datagrid_accounts_tree";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_accounts_tree.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.datagrid_accounts_tree.RowHeadersVisible = false;
            this.datagrid_accounts_tree.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            this.datagrid_accounts_tree.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.datagrid_accounts_tree.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid_accounts_tree.RowTemplate.Height = 26;
            this.datagrid_accounts_tree.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_accounts_tree.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrid_accounts_tree.ShowEditingIcon = false;
            this.datagrid_accounts_tree.Size = new System.Drawing.Size(700, 293);
            this.datagrid_accounts_tree.TabIndex = 31;
            this.datagrid_accounts_tree.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_accounts_tree_CellClick);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(564, 322);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(148, 34);
            this.button2.TabIndex = 41;
            this.button2.Text = "حذف المخزن المحدد";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // idselected
            // 
            this.idselected.Location = new System.Drawing.Point(368, 330);
            this.idselected.Name = "idselected";
            this.idselected.Size = new System.Drawing.Size(23, 20);
            this.idselected.TabIndex = 42;
            this.idselected.Visible = false;
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(401, 322);
            this.button8.Name = "button8";
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button8.Size = new System.Drawing.Size(157, 34);
            this.button8.TabIndex = 39;
            this.button8.Text = "تحديث المخزن المحدد";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(12, 322);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(153, 34);
            this.button1.TabIndex = 45;
            this.button1.Text = "إضافة مخزن جديد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FRM_Stores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.idselected);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox idselected;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button1;
    }
}