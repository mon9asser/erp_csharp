
namespace sales_management.UI
{
    partial class FRM_Date_Range_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date_from = new System.Windows.Forms.DateTimePicker();
            this.date_to = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.display_invoices_item_with = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "من تاريخ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "إلي تاريخ :";
            // 
            // date_from
            // 
            this.date_from.Location = new System.Drawing.Point(12, 41);
            this.date_from.Name = "date_from";
            this.date_from.Size = new System.Drawing.Size(257, 20);
            this.date_from.TabIndex = 2;
            // 
            // date_to
            // 
            this.date_to.Location = new System.Drawing.Point(13, 124);
            this.date_to.Name = "date_to";
            this.date_to.Size = new System.Drawing.Size(257, 20);
            this.date_to.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(14, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "عرض التقرير";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "عرض الفواتير الإلكترونية بناءا علي الأتي :";
            // 
            // display_invoices_item_with
            // 
            this.display_invoices_item_with.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.display_invoices_item_with.FormattingEnabled = true;
            this.display_invoices_item_with.Items.AddRange(new object[] {
            "عرض الفواتير الغير خاضعه للضريبة",
            "عرض الفواتير الخاضعه الضريبية فقط",
            "عرض الجميع"});
            this.display_invoices_item_with.Location = new System.Drawing.Point(15, 210);
            this.display_invoices_item_with.Name = "display_invoices_item_with";
            this.display_invoices_item_with.Size = new System.Drawing.Size(254, 21);
            this.display_invoices_item_with.TabIndex = 8;
            // 
            // FRM_Date_Range_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 373);
            this.Controls.Add(this.display_invoices_item_with);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.date_to);
            this.Controls.Add(this.date_from);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FRM_Date_Range_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خلال الفترة";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_from;
        private System.Windows.Forms.DateTimePicker date_to;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox display_invoices_item_with;
    }
}