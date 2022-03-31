
namespace sales_management.UI
{
    partial class Price
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
            this.datagridview_prices = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_prices)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridview_prices
            // 
            this.datagridview_prices.AllowUserToAddRows = false;
            this.datagridview_prices.AllowUserToDeleteRows = false;
            this.datagridview_prices.AllowUserToResizeColumns = false;
            this.datagridview_prices.AllowUserToResizeRows = false;
            this.datagridview_prices.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.datagridview_prices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridview_prices.DefaultCellStyle = dataGridViewCellStyle1;
            this.datagridview_prices.Location = new System.Drawing.Point(12, 12);
            this.datagridview_prices.MultiSelect = false;
            this.datagridview_prices.Name = "datagridview_prices";
            this.datagridview_prices.ReadOnly = true;
            this.datagridview_prices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridview_prices.RowTemplate.Height = 35;
            this.datagridview_prices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview_prices.Size = new System.Drawing.Size(360, 263);
            this.datagridview_prices.TabIndex = 0;
            //this.datagridview_prices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_prices_CellDoubleClick);
            //this.datagridview_prices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datagridview_prices_KeyDown);
            // 
            // Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 287);
            this.Controls.Add(this.datagridview_prices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Price";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إختر السعر المناسب ";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_prices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView datagridview_prices;
    }
}