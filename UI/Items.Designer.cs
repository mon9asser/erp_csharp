
namespace sales_management.UI
{
    partial class Items
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.items_view_grids = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.items_view_grids)).BeginInit();
            this.SuspendLayout();
            // 
            // items_view_grids
            // 
            this.items_view_grids.AllowUserToAddRows = false;
            this.items_view_grids.AllowUserToDeleteRows = false;
            this.items_view_grids.AllowUserToResizeColumns = false;
            this.items_view_grids.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.items_view_grids.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.items_view_grids.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.items_view_grids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.items_view_grids.DefaultCellStyle = dataGridViewCellStyle4;
            this.items_view_grids.Location = new System.Drawing.Point(12, 12);
            this.items_view_grids.Name = "items_view_grids";
            this.items_view_grids.ReadOnly = true;
            this.items_view_grids.RowHeadersVisible = false;
            this.items_view_grids.RowTemplate.Height = 35;
            this.items_view_grids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.items_view_grids.ShowCellErrors = false;
            this.items_view_grids.ShowCellToolTips = false;
            this.items_view_grids.ShowEditingIcon = false;
            this.items_view_grids.ShowRowErrors = false;
            this.items_view_grids.Size = new System.Drawing.Size(230, 287);
            this.items_view_grids.TabIndex = 0;
            this.items_view_grids.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_view_grids_CellDoubleClick);
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 311);
            this.Controls.Add(this.items_view_grids);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Items";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إختر صنف";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Items_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.items_view_grids)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView items_view_grids;
    }
}