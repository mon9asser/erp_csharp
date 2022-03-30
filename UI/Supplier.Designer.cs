namespace sales_management.UI
{
    partial class Supplier
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
            this.suppliers_datagridview = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.suppliers_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // suppliers_datagridview
            // 
            this.suppliers_datagridview.AllowUserToAddRows = false;
            this.suppliers_datagridview.AllowUserToDeleteRows = false;
            this.suppliers_datagridview.AllowUserToResizeColumns = false;
            this.suppliers_datagridview.AllowUserToResizeRows = false;
            this.suppliers_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.suppliers_datagridview.Location = new System.Drawing.Point(12, 12);
            this.suppliers_datagridview.MultiSelect = false;
            this.suppliers_datagridview.Name = "suppliers_datagridview";
            this.suppliers_datagridview.ReadOnly = true;
            this.suppliers_datagridview.RowHeadersVisible = false;
            this.suppliers_datagridview.RowTemplate.Height = 30;
            this.suppliers_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.suppliers_datagridview.Size = new System.Drawing.Size(853, 347);
            this.suppliers_datagridview.TabIndex = 0;
            this.suppliers_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliers_datagridview_CellContentClick);
            this.suppliers_datagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suppliers_datagridview_CellDoubleClick);
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
            // Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 410);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.suppliers_datagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Supplier";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
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