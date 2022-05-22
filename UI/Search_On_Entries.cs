using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sales_management.UI
{
    public partial class Search_On_Entries : Form
    {

        Entry_Details Entries;
        public int document_type = -1;

        public Search_On_Entries( int doc_type, Entry_Details entry )
        {

            this.Entries = entry;
            this.document_type = doc_type;
            InitializeComponent();

            this.Fill_Titles( "بحث عن قيد", "بحث برقم الفيد" );

        }

        public void Fill_Titles(string title, string label_title ) {
            label1.Text = label_title;
            this.Text = title;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Entry Journals 
            if (this.document_type == 4) {

                bool found_it = false;
                int id = -1;
                if (Entries.Journal_Details.Rows.Count != 0 && textBox1.Text != "" ) {

                    foreach (DataRow row in Entries.Journals.Rows) {
                        if (row["entry_number"].ToString().Equals(textBox1.Text.ToString())) {
                            found_it = true;
                            id = Convert.ToInt32(row["id"]);
                            break;
                        }
                    }

                }

                if (found_it == false) {
                    MessageBox.Show( "حدث خطأ من فضلك تأكد من إدخال رقم القيد الصحيح", "خطأ", MessageBoxButtons.OK );
                    return;
                } 

                Entries.Fill_Datagridview_accounts(id);
                Entries.Fill_Journal_Fields(id);

            }

            this.Close();
        }
    }
}
