
namespace sales_management.UI
{
    partial class Load_Products
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
            this.datagridview_items = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_items)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridview_items
            // 
            this.datagridview_items.AllowUserToAddRows = false;
            this.datagridview_items.AllowUserToDeleteRows = false;
            this.datagridview_items.AllowUserToOrderColumns = true;
            this.datagridview_items.AllowUserToResizeColumns = false;
            this.datagridview_items.AllowUserToResizeRows = false;
            this.datagridview_items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridview_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_items.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.datagridview_items.Location = new System.Drawing.Point(12, 12);
            this.datagridview_items.Name = "datagridview_items";
            this.datagridview_items.Size = new System.Drawing.Size(297, 294);
            this.datagridview_items.TabIndex = 0;
            // 
            // Load_Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 318);
            this.Controls.Add(this.datagridview_items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Load_Products";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إسم الصنف";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_items)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridview_items;
    }
}