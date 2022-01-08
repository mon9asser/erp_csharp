using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace sales_management.UI
{
    public partial class Backups : Form
    {
        public Backups()
        {
            InitializeComponent();
        }
 

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    textBox1.Text = fbd.SelectedPath.ToString();
                }
            }
        }

        private void BackupBTN_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != null) { 
                
                PL.Installings backups = new PL.Installings();
            
                backups.Take_Database_Backups(textBox1.Text.ToString());
            
            }

        }
    }
}
