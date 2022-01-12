
namespace sales_management.UI
{
    partial class Categories
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
            this.cats_name_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cat_code_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datagridview_cats = new System.Windows.Forms.DataGridView();
            this.edit_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_cats)).BeginInit();
            this.SuspendLayout();
            // 
            // cats_name_text
            // 
            this.cats_name_text.Enabled = false;
            this.cats_name_text.Location = new System.Drawing.Point(74, 19);
            this.cats_name_text.Name = "cats_name_text";
            this.cats_name_text.Size = new System.Drawing.Size(208, 20);
            this.cats_name_text.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "إسم الفئة";
            // 
            // cat_code_text
            // 
            this.cat_code_text.Enabled = false;
            this.cat_code_text.Location = new System.Drawing.Point(428, 19);
            this.cat_code_text.Name = "cat_code_text";
            this.cat_code_text.Size = new System.Drawing.Size(208, 20);
            this.cat_code_text.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "كود الفئة";
            // 
            // datagridview_cats
            // 
            this.datagridview_cats.AllowUserToAddRows = false;
            this.datagridview_cats.AllowUserToDeleteRows = false;
            this.datagridview_cats.AllowUserToResizeColumns = false;
            this.datagridview_cats.AllowUserToResizeRows = false;
            this.datagridview_cats.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datagridview_cats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_cats.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagridview_cats.Location = new System.Drawing.Point(12, 56);
            this.datagridview_cats.MultiSelect = false;
            this.datagridview_cats.Name = "datagridview_cats";
            this.datagridview_cats.ReadOnly = true;
            this.datagridview_cats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridview_cats.RowTemplate.Height = 30;
            this.datagridview_cats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview_cats.Size = new System.Drawing.Size(626, 235);
            this.datagridview_cats.TabIndex = 4;
            this.datagridview_cats.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_cats_CellDoubleClick);
            this.datagridview_cats.SelectionChanged += new System.EventHandler(this.datagridview_cats_SelectionChanged);
            // 
            // edit_button
            // 
            this.edit_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.edit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_button.Enabled = false;
            this.edit_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.edit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_button.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.edit_button.Location = new System.Drawing.Point(468, 302);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(82, 34);
            this.edit_button.TabIndex = 23;
            this.edit_button.Text = "تعديل";
            this.edit_button.UseVisualStyleBackColor = false;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.delete_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_button.Enabled = false;
            this.delete_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.delete_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_button.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.delete_button.Location = new System.Drawing.Point(556, 302);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(82, 34);
            this.delete_button.TabIndex = 22;
            this.delete_button.Text = "حذف";
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // save_button
            // 
            this.save_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.Enabled = false;
            this.save_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.save_button.Location = new System.Drawing.Point(127, 302);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(82, 34);
            this.save_button.TabIndex = 21;
            this.save_button.Text = "حفظ";
            this.save_button.UseVisualStyleBackColor = false;
            this.save_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Location = new System.Drawing.Point(13, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "إضافة جديد";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 347);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datagridview_cats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cat_code_text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cats_name_text);
            this.MaximizeBox = false;
            this.Name = "Categories";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة الفئـــات";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_cats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cats_name_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cat_code_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView datagridview_cats;
    }
}