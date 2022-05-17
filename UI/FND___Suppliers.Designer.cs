namespace sales_management.UI
{
    partial class FND___Suppliers
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
            this.button1 = new System.Windows.Forms.Button();
            this.suppliers_datagridview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.suppliers_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(745, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "إضافة مورد جدبد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // suppliers_datagridview
            // 
            this.suppliers_datagridview.AllowUserToAddRows = false;
            this.suppliers_datagridview.AllowUserToDeleteRows = false;
            this.suppliers_datagridview.AllowUserToResizeColumns = false;
            this.suppliers_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.suppliers_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.suppliers_datagridview.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.suppliers_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.suppliers_datagridview.GridColor = System.Drawing.Color.DodgerBlue;
            this.suppliers_datagridview.Location = new System.Drawing.Point(12, 8);
            this.suppliers_datagridview.MultiSelect = false;
            this.suppliers_datagridview.Name = "suppliers_datagridview";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.suppliers_datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.suppliers_datagridview.RowHeadersVisible = false;
            this.suppliers_datagridview.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.suppliers_datagridview.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.suppliers_datagridview.RowTemplate.Height = 26;
            this.suppliers_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.suppliers_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.suppliers_datagridview.ShowEditingIcon = false;
            this.suppliers_datagridview.Size = new System.Drawing.Size(853, 345);
            this.suppliers_datagridview.TabIndex = 32;
            this.suppliers_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliers_datagridview_CellContentClick_1);
            this.suppliers_datagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliers_datagridview_CellDoubleClick);
            // 
            // FRM_Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 410);
            this.Controls.Add(this.suppliers_datagridview);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Suppliers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الموردين";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.suppliers_datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView suppliers_datagridview;
    }
}