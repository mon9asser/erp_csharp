
namespace sales_management.UI
{
    partial class ___Accounts
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
            this.accounting_tree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // accounting_tree
            // 
            this.accounting_tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accounting_tree.Location = new System.Drawing.Point(0, 0);
            this.accounting_tree.Name = "accounting_tree";
            this.accounting_tree.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.accounting_tree.RightToLeftLayout = true;
            this.accounting_tree.Size = new System.Drawing.Size(267, 393);
            this.accounting_tree.TabIndex = 0;
            this.accounting_tree.DoubleClick += new System.EventHandler(this.accounting_tree_DoubleClick);
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 393);
            this.Controls.Add(this.accounting_tree);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Accounts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حساب الأستاذ";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView accounting_tree;
    }
}