
namespace sales_management.UI
{
    partial class FRM_UpdateCustomer
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
            this.account_number = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phone_number = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vat_number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.establishment_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resource_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // account_number
            // 
            this.account_number.Location = new System.Drawing.Point(18, 37);
            this.account_number.Name = "account_number";
            this.account_number.ReadOnly = true;
            this.account_number.Size = new System.Drawing.Size(208, 20);
            this.account_number.TabIndex = 33;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(182, 454);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 28);
            this.button2.TabIndex = 32;
            this.button2.Text = "إلغاء";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // save_button
            // 
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.Location = new System.Drawing.Point(80, 454);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(96, 28);
            this.save_button.TabIndex = 31;
            this.save_button.Text = "حفظ";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "الإيميل";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(18, 374);
            this.address.Multiline = true;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(260, 67);
            this.address.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "العنوان";
            // 
            // email_text
            // 
            this.email_text.Location = new System.Drawing.Point(18, 313);
            this.email_text.Multiline = true;
            this.email_text.Name = "email_text";
            this.email_text.Size = new System.Drawing.Size(260, 20);
            this.email_text.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "رقم الهاتف";
            // 
            // phone_number
            // 
            this.phone_number.Location = new System.Drawing.Point(18, 256);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(260, 20);
            this.phone_number.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "الرقم الضريبي";
            // 
            // vat_number
            // 
            this.vat_number.Location = new System.Drawing.Point(18, 199);
            this.vat_number.Name = "vat_number";
            this.vat_number.Size = new System.Drawing.Size(260, 20);
            this.vat_number.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "إسم المنشأة";
            // 
            // establishment_name
            // 
            this.establishment_name.Location = new System.Drawing.Point(18, 144);
            this.establishment_name.Name = "establishment_name";
            this.establishment_name.Size = new System.Drawing.Size(260, 20);
            this.establishment_name.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "إسم العميل";
            // 
            // resource_name
            // 
            this.resource_name.Location = new System.Drawing.Point(18, 89);
            this.resource_name.Name = "resource_name";
            this.resource_name.Size = new System.Drawing.Size(260, 20);
            this.resource_name.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "كود العميل";
            // 
            // id_text
            // 
            this.id_text.Location = new System.Drawing.Point(232, 37);
            this.id_text.Name = "id_text";
            this.id_text.ReadOnly = true;
            this.id_text.Size = new System.Drawing.Size(45, 20);
            this.id_text.TabIndex = 17;
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 494);
            this.Controls.Add(this.account_number);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.email_text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phone_number);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.vat_number);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.establishment_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resource_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_text);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCustomer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحديث بيانات العميل";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox account_number;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vat_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox establishment_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox resource_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id_text;
    }
}