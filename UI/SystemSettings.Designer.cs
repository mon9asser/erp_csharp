
namespace sales_management.UI
{
    partial class SystemSettings
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.vat_percentage_number = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.vat_percentage_value = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkbox_enable_vat = new System.Windows.Forms.CheckBox();
            this.isIncludeDelete = new System.Windows.Forms.CheckBox();
            this.isIncludeUpdate = new System.Windows.Forms.CheckBox();
            this.isIncludeAddress = new System.Windows.Forms.CheckBox();
            this.itemParcode_text = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.logoImage_byte = new System.Windows.Forms.PictureBox();
            this.address_text = new System.Windows.Forms.TextBox();
            this.vatNumber_Text = new System.Windows.Forms.TextBox();
            this.commercialName_text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.settingsIdText = new System.Windows.Forms.TextBox();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoImage_byte)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.checkbox_enable_vat);
            this.tabPage2.Controls.Add(this.isIncludeDelete);
            this.tabPage2.Controls.Add(this.isIncludeUpdate);
            this.tabPage2.Controls.Add(this.isIncludeAddress);
            this.tabPage2.Controls.Add(this.itemParcode_text);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(738, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "إعدادات الفواتير الإلكترونية";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.vat_percentage_number);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.vat_percentage_value);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(260, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 47);
            this.panel1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ضريبة القيمة المضافة ( المئوية ) :";
            // 
            // vat_percentage_number
            // 
            this.vat_percentage_number.Location = new System.Drawing.Point(225, 13);
            this.vat_percentage_number.Name = "vat_percentage_number";
            this.vat_percentage_number.Size = new System.Drawing.Size(59, 20);
            this.vat_percentage_number.TabIndex = 6;
            this.vat_percentage_number.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "%";
            // 
            // vat_percentage_value
            // 
            this.vat_percentage_value.Enabled = false;
            this.vat_percentage_value.Location = new System.Drawing.Point(16, 13);
            this.vat_percentage_value.Name = "vat_percentage_value";
            this.vat_percentage_value.Size = new System.Drawing.Size(49, 20);
            this.vat_percentage_value.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "النسبة والتناســــــــب";
            // 
            // checkbox_enable_vat
            // 
            this.checkbox_enable_vat.AutoSize = true;
            this.checkbox_enable_vat.Location = new System.Drawing.Point(571, 29);
            this.checkbox_enable_vat.Name = "checkbox_enable_vat";
            this.checkbox_enable_vat.Size = new System.Drawing.Size(154, 17);
            this.checkbox_enable_vat.TabIndex = 16;
            this.checkbox_enable_vat.Text = "تفعيل ضريبة القيمة المضافة";
            this.checkbox_enable_vat.UseVisualStyleBackColor = true;
            this.checkbox_enable_vat.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // isIncludeDelete
            // 
            this.isIncludeDelete.AutoSize = true;
            this.isIncludeDelete.Location = new System.Drawing.Point(579, 201);
            this.isIncludeDelete.Name = "isIncludeDelete";
            this.isIncludeDelete.Size = new System.Drawing.Size(137, 17);
            this.isIncludeDelete.TabIndex = 14;
            this.isIncludeDelete.Text = "تنشيط ذرار حذف الفاتورة";
            this.isIncludeDelete.UseVisualStyleBackColor = true;
            // 
            // isIncludeUpdate
            // 
            this.isIncludeUpdate.AutoSize = true;
            this.isIncludeUpdate.Location = new System.Drawing.Point(575, 165);
            this.isIncludeUpdate.Name = "isIncludeUpdate";
            this.isIncludeUpdate.Size = new System.Drawing.Size(140, 17);
            this.isIncludeUpdate.TabIndex = 13;
            this.isIncludeUpdate.Text = "تنشيط ذرار تعديل الفاتورة";
            this.isIncludeUpdate.UseVisualStyleBackColor = true;
            // 
            // isIncludeAddress
            // 
            this.isIncludeAddress.AutoSize = true;
            this.isIncludeAddress.Location = new System.Drawing.Point(585, 128);
            this.isIncludeAddress.Name = "isIncludeAddress";
            this.isIncludeAddress.Size = new System.Drawing.Size(129, 17);
            this.isIncludeAddress.TabIndex = 12;
            this.isIncludeAddress.Text = "تضمين العنوان بالفاتورة";
            this.isIncludeAddress.UseVisualStyleBackColor = true;
            // 
            // itemParcode_text
            // 
            this.itemParcode_text.FormattingEnabled = true;
            this.itemParcode_text.Items.AddRange(new object[] {
            "كود الصنف فقط",
            "كود الصنف مع الوحدة او الوزن",
            "كود الصنف مع السعر",
            "كود الصنف و الوحده و السعر"});
            this.itemParcode_text.Location = new System.Drawing.Point(335, 245);
            this.itemParcode_text.Name = "itemParcode_text";
            this.itemParcode_text.Size = new System.Drawing.Size(268, 21);
            this.itemParcode_text.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(622, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "نوع باركود  الصنف :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 374);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.logoImage_byte);
            this.tabPage1.Controls.Add(this.address_text);
            this.tabPage1.Controls.Add(this.vatNumber_Text);
            this.tabPage1.Controls.Add(this.commercialName_text);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage1.Size = new System.Drawing.Size(738, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "إعدادات الإسم التجاري";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Document, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(351, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "بالضغط علي هذا المربع يمكنك من إختيار صورة بأي صيغة تختارها";
            // 
            // logoImage_byte
            // 
            this.logoImage_byte.BackColor = System.Drawing.Color.Snow;
            this.logoImage_byte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoImage_byte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoImage_byte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoImage_byte.Location = new System.Drawing.Point(429, 136);
            this.logoImage_byte.Name = "logoImage_byte";
            this.logoImage_byte.Size = new System.Drawing.Size(193, 93);
            this.logoImage_byte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoImage_byte.TabIndex = 7;
            this.logoImage_byte.TabStop = false;
            this.logoImage_byte.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // address_text
            // 
            this.address_text.Location = new System.Drawing.Point(23, 21);
            this.address_text.Multiline = true;
            this.address_text.Name = "address_text";
            this.address_text.Size = new System.Drawing.Size(262, 80);
            this.address_text.TabIndex = 6;
            // 
            // vatNumber_Text
            // 
            this.vatNumber_Text.Location = new System.Drawing.Point(385, 78);
            this.vatNumber_Text.Name = "vatNumber_Text";
            this.vatNumber_Text.Size = new System.Drawing.Size(237, 20);
            this.vatNumber_Text.TabIndex = 5;
            // 
            // commercialName_text
            // 
            this.commercialName_text.Location = new System.Drawing.Point(385, 25);
            this.commercialName_text.Name = "commercialName_text";
            this.commercialName_text.Size = new System.Drawing.Size(237, 20);
            this.commercialName_text.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(653, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "شعار الشركة :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "الرقم الضريبي :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "العنوان :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(642, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "الإسم التجــــاري :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Location = new System.Drawing.Point(634, 392);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.button2.Size = new System.Drawing.Size(119, 37);
            this.button2.TabIndex = 9;
            this.button2.Text = "حفظ الإعدادات";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Location = new System.Drawing.Point(509, 392);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.button1.Size = new System.Drawing.Size(119, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "إلغاء";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // settingsIdText
            // 
            this.settingsIdText.Location = new System.Drawing.Point(16, 392);
            this.settingsIdText.Name = "settingsIdText";
            this.settingsIdText.Size = new System.Drawing.Size(392, 20);
            this.settingsIdText.TabIndex = 16;
            this.settingsIdText.Visible = false;
            // 
            // SystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 439);
            this.Controls.Add(this.settingsIdText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SystemSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات النظام";
            this.TopMost = true;
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoImage_byte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox logoImage_byte;
        private System.Windows.Forms.TextBox address_text;
        private System.Windows.Forms.TextBox vatNumber_Text;
        private System.Windows.Forms.TextBox commercialName_text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox vat_percentage_value;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox vat_percentage_number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox itemParcode_text;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox isIncludeDelete;
        private System.Windows.Forms.CheckBox isIncludeUpdate;
        private System.Windows.Forms.CheckBox isIncludeAddress;
        private System.Windows.Forms.TextBox settingsIdText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkbox_enable_vat;
    }
}