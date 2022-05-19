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
    public partial class Viewer : Form
    {

        Report Repo = new Report();

        public Viewer(string file_source, DataSet dataSource, string dataSetName, string title )
        {
            InitializeComponent();


            this.Text = title;
            this.Repo.RegisterData(dataSource, dataSetName);
            this.Repo.Load(Application.StartupPath + file_source );
            this.Repo.Preview = this.previewControl1;
            this.Repo.Show();
            
        }
    }
}
