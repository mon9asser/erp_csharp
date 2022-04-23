namespace sales_management.UI
{
    partial class SelectTreeCols
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
            this.datagrid_accounts_tree_columns = new System.Windows.Forms.DataGridView();
            this.AccountingTreeData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excelSheetCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree_columns)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_accounts_tree_columns
            // 
            this.datagrid_accounts_tree_columns.AllowUserToAddRows = false;
            this.datagrid_accounts_tree_columns.AllowUserToDeleteRows = false;
            this.datagrid_accounts_tree_columns.AllowUserToResizeColumns = false;
            this.datagrid_accounts_tree_columns.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_accounts_tree_columns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid_accounts_tree_columns.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_accounts_tree_columns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_accounts_tree_columns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountingTreeData,
            this.excelSheetCol});
            this.datagrid_accounts_tree_columns.GridColor = System.Drawing.Color.DodgerBlue;
            this.datagrid_accounts_tree_columns.Location = new System.Drawing.Point(12, 46);
            this.datagrid_accounts_tree_columns.MultiSelect = false;
            this.datagrid_accounts_tree_columns.Name = "datagrid_accounts_tree_columns";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_accounts_tree_columns.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid_accounts_tree_columns.RowHeadersVisible = false;
            this.datagrid_accounts_tree_columns.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.datagrid_accounts_tree_columns.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid_accounts_tree_columns.RowTemplate.Height = 26;
            this.datagrid_accounts_tree_columns.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_accounts_tree_columns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrid_accounts_tree_columns.ShowEditingIcon = false;
            this.datagrid_accounts_tree_columns.Size = new System.Drawing.Size(358, 331);
            this.datagrid_accounts_tree_columns.TabIndex = 31;
            // 
            // AccountingTreeData
            // 
            this.AccountingTreeData.HeaderText = "شجرة الحسابات";
            this.AccountingTreeData.Name = "AccountingTreeData";
            this.AccountingTreeData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountingTreeData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AccountingTreeData.Width = 150;
            // 
            // excelSheetCol
            // 
            this.excelSheetCol.HeaderText = "بيانات ملف الإكسيل";
            this.excelSheetCol.Name = "excelSheetCol";
            this.excelSheetCol.Width = 200;
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(12, 390);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(149, 34);
            this.button8.TabIndex = 38;
            this.button8.Text = "بدء الإستيراد";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(177, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 34);
            this.button1.TabIndex = 39;
            this.button1.Text = "إلغـــاء";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "من فضلك اختر العمود المناسب لشجرة الحسابات وما يقابلها في الإكسيل شيت";
            // 
            // SelectTreeCols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.datagrid_accounts_tree_columns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectTreeCols";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ربط ملف الإكسيل بشجرة الحسابات";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_accounts_tree_columns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView datagrid_accounts_tree_columns;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountingTreeData;
        private System.Windows.Forms.DataGridViewComboBoxColumn excelSheetCol;
    }
}