
namespace sales_management.UI
{
    partial class ItemUnit
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
            this.label3 = new System.Windows.Forms.Label();
            this.combobox_price_type = new System.Windows.Forms.ComboBox();
            this.datagridprices_items = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridprices_items)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "نوع التسعيرة :";
            // 
            // combobox_price_type
            // 
            this.combobox_price_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_price_type.FormattingEnabled = true;
            this.combobox_price_type.Items.AddRange(new object[] {
            "سعر الشراء",
            "سعر البيع",
            "سعر بيع 2",
            "سعر الجملة"});
            this.combobox_price_type.Location = new System.Drawing.Point(98, 15);
            this.combobox_price_type.Name = "combobox_price_type";
            this.combobox_price_type.Size = new System.Drawing.Size(228, 21);
            this.combobox_price_type.TabIndex = 4;
            this.combobox_price_type.SelectedIndexChanged += new System.EventHandler(this.combobox_price_type_SelectedIndexChanged);
            // 
            // datagridprices_items
            // 
            this.datagridprices_items.AllowUserToAddRows = false;
            this.datagridprices_items.AllowUserToDeleteRows = false;
            this.datagridprices_items.AllowUserToResizeColumns = false;
            this.datagridprices_items.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            this.datagridprices_items.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridprices_items.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.datagridprices_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridprices_items.Location = new System.Drawing.Point(19, 53);
            this.datagridprices_items.MultiSelect = false;
            this.datagridprices_items.Name = "datagridprices_items";
            this.datagridprices_items.RowHeadersVisible = false;
            this.datagridprices_items.RowTemplate.Height = 30;
            this.datagridprices_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridprices_items.ShowCellToolTips = false;
            this.datagridprices_items.ShowEditingIcon = false;
            this.datagridprices_items.Size = new System.Drawing.Size(307, 359);
            this.datagridprices_items.TabIndex = 5;
            this.datagridprices_items.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridprices_items_CellDoubleClick);
            // 
            // ItemUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 431);
            this.Controls.Add(this.datagridprices_items);
            this.Controls.Add(this.combobox_price_type);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemUnit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسعير الصنف";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ItemUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridprices_items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combobox_price_type;
        public System.Windows.Forms.DataGridView datagridprices_items;
    }
}