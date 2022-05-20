using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
//using System.Drawing.Text;
namespace sales_management.UI
{
    public partial class Main : Form
    {
        
        private int userId = 1;
        private string userName = "Montasser";
        private string fullName = "Montasser Mossallem"; 
        public Sunisoft.IrisSkin.SkinEngine skin;

        public static Main frm;
        static void frm_formClosed(object sernder, FormClosedEventArgs e) {
            frm = null; 
        }
        public static Main getMainForm
        {
            get
            {
                
                if (frm == null ) {
                    frm = new Main();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public void setUserInfo( int userId, string userName, string fullName ) {
            this.userId = userId;
            this.userName = userName;
            this.fullName = fullName;
        }

        public string[] getUserInfo() {

            string[] userInfo = new string[3];

            userInfo[0] = this.userId.ToString();
            userInfo[1] = this.userName;
            userInfo[2] = this.fullName;

            return userInfo;
        }

         
        public Main()
        {

            InitializeComponent();
            DB.DataAccessLayer db = new DB.DataAccessLayer();
             

           // this.skinEngines.SkinFile = "Skins/SteelBlack.ssk";

            if ( frm == null )
            {
                frm = this;
            }

            //this.ChangeLayoutTheme( "SteelBlack.ssk" );
            //this.ChangeLayoutTheme("office2007.ssk");

            /*
             * PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = Properties.Resources.K_Art_bold_Regular.Length;
            byte[] fontdata = Properties.Resources.K_Art_bold_Regular;
            System.IntPtr data = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontLength);
            System.Runtime.InteropServices.Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            label1.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            */

            /*
            foreach ( Control c in this.Controls ) { 
                c.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            }
            */

        }

        public void ChangeLayoutTheme( string skinName ) {

            // Change Layout Theme 
            UI.Main.getMainForm.skin = new Sunisoft.IrisSkin.SkinEngine();
            UI.Main.getMainForm.skin.SerialNumber = "kUb2DF5pvGF3X9dKPFvIdkXQ0sE8LkAVp9fMme9wCnjZ+ArdRVlxKw==";
            UI.Main.getMainForm.skin.SkinFile = "Skins/" + skinName;

        }

        private void فحصالإتصالبالسيرفرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.ServerSettings serverSettings = new UI.ServerSettings();
            serverSettings.Show();
        }

        
        private void إعداداتالنظامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.SystemSettings.GetForm.Show(); 
        }

        private void تهيةالبياناتالأفتراضيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.DefaultData defData = new UI.DefaultData();
            defData.Show();
        }

        private void نسخةإحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Backups beackup = new UI.Backups();
            beackup.Show();
        }

        private void إدارةصلاحياتالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Permissions Perm = new UI.Permissions();
            Perm.Show();
        }

        private void إدارةالمنتجاتوالفئاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Products.getForm.Show();
        }

        private void إدارةالفئاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Categories.getForm.Show();
        }

        private void إدارةالوحداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FRM_ProductUnits units = new UI.FRM_ProductUnits();
            units.Show();
        }

        private void شجرةالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void الموردينوالتجارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND___Suppliers Suppliers = new UI.FND___Suppliers();
            Suppliers.Show();
        }

        private void كشفالرواتبالشهريToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void العملاءوالمناديبToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UI.FND___Customers Customers = new FND___Customers();
            Customers.Show();

        }

        private void شجرةالحساباتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void فاتورةالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.purchaseInvoice pinvoice = new UI.purchaseInvoice();
            //pinvoice.MdiParent = this;  
            pinvoice.Show();
            //UI.purchaseInvoice.GetForm.Show();
        }

        private void شجرةالحساباToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FRM_AccountsGuid.GetForm.Show();
        }

        private void فاتورةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND___salesInvoice.GetForm.Show();
        }

        private void إعداداتالإجراءاتالمخزنهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void المخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FRM_Stores Store = new UI.FRM_Stores();
            Store.Show();
        }

        private void دليلمراكزالتكلفةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FRM_CostCenterGuide center_cost = new UI.FRM_CostCenterGuide();
            center_cost.Show();
        }

        private void قيوداليوميةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND___Date_Range rmrange = new UI.FND___Date_Range(0);
            rmrange.ShowDialog();
        }

        private void قيدتسويةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FRM_ALL_ENTRIES _entryfrm = new FRM_ALL_ENTRIES();
            _entryfrm.Show();
        }

        private void مرتجعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND___salesReturnInvoice.GetForm.Show();
        }

        private void تقريرالكمياتالحاليةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND___Current_Quantities Inventory = new UI.FND___Current_Quantities();
            Inventory.Show();
        }

        private void مسترداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.purchaseReturnInvoice.GetForm.Show();
        }

        private void تقريرالمبيعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Document Type here is sales report 
            UI.FND____Date_Range_Form frm = new UI.FND____Date_Range_Form(0);
            frm.Show();
        }

        private void تقريرالمشترياتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.FND____Date_Range_Form frm = new UI.FND____Date_Range_Form(1);
            frm.Show();
        }

        private void تقريرمردودالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND____Date_Range_Form frm = new UI.FND____Date_Range_Form(2);
            frm.Show();
        }

        private void تقريرمردودالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND____Date_Range_Form frm = new UI.FND____Date_Range_Form(3);
            frm.Show();
        }

        private void تقريرالمخزونالحاليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND___Current_Quantities Inventory = new UI.FND___Current_Quantities();
            Inventory.Show();
        }

        private void إذنصرفبضاعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Export_Document EXP = new UI.Export_Document();
            EXP.Show();
        }

        private void تقريرالقيمةالمضافهعنالفترةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.FND___Date_Range rmrange = new UI.FND___Date_Range(1);
            rmrange.ShowDialog();
        }
    }
}
