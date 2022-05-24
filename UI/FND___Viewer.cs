using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;

namespace sales_management.UI
{
    public partial class FND___Viewer : Form
    {

        Report Repo = new Report();

        public FND___Viewer(string file_source, DataSet dataSource, string dataSetName, string title, bool print_direct = false )
        {
            InitializeComponent();

            try
            {
                this.Text = title;
                this.Repo.RegisterData(dataSource, dataSetName);
                this.Repo.Load(Application.StartupPath + file_source);

                if (print_direct == false)
                {
                    this.Repo.Preview = this.previewControl1;
                    this.Repo.Show();
                }
                else
                {
                    this.Repo.Print();
                }
            }
            catch (Exception) { }
        }
    }
}
