namespace sales_management.UI
{
    partial class FRM_ProductUnits
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid_product_units = new System.Windows.Forms.DataGridView();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_product_units)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid_product_units
            // 
            this.datagrid_product_units.AllowUserToResizeColumns = false;
            this.datagrid_product_units.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_product_units.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.datagrid_product_units.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_product_units.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_product_units.GridColor = System.Drawing.Color.DodgerBlue;
            this.datagrid_product_units.Location = new System.Drawing.Point(12, 10);
            this.datagrid_product_units.MultiSelect = false;
            this.datagrid_product_units.Name = "datagrid_product_units";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_product_units.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.datagrid_product_units.RowHeadersVisible = false;
            this.datagrid_product_units.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.datagrid_product_units.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid_product_units.RowTemplate.Height = 26;
            this.datagrid_product_units.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_product_units.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagrid_product_units.ShowEditingIcon = false;
            this.datagrid_product_units.Size = new System.Drawing.Size(357, 390);
            this.datagrid_product_units.TabIndex = 31;
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button8.Image = global::sales_management.Properties.Resources.save_data;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(12, 412);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button8.Size = new System.Drawing.Size(149, 34);
            this.button8.TabIndex = 39;
            this.button8.Text = "حفظ التعديلات";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button7.Image = global::sales_management.Properties.Resources.delete_16;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(167, 412);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.button7.Size = new System.Drawing.Size(110, 34);
            this.button7.TabIndex = 38;
            this.button7.Text = "حذف الوحدة";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // FRM_ProductUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 459);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.datagrid_product_units);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_ProductUnits";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة الوحدات";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FRM_ProductUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_product_units)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView datagrid_product_units;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
    }
}