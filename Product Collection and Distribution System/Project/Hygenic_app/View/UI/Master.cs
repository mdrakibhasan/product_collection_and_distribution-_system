using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.DataModel;
using View.DBManager;
using View.Reports;
using View.UI.UserManager;

namespace View.UI
{
    public partial class Master : Form
    {
        private int childFormNumber = 0;

        public Master()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void SetLoggedInUserToStatusStrip(User User, string CompanyID, string MainBranchID, string GroupID)
        {

            Global.LoggedInUser = User;
            this.WindowState = FormWindowState.Maximized;
            // this.EnableMenuByGroupID();

        }

        #endregion

        private static Master _frmPOSMDI;
        #region Public Properties

        public static Master Instance
        {
            get
            {
                if (_frmPOSMDI == null || _frmPOSMDI.IsDisposed)
                    _frmPOSMDI = new Master();
                return _frmPOSMDI;

            }
        }
        #endregion
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemInfo a = new frmItemInfo();
            a.MdiParent = this;
            a.Show();
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUOM a = new frmUOM();
            a.MdiParent = this;
            a.Show();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void categorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory a = new frmCategory();
            a.MdiParent = this;
            a.Show();

        }

        private void subCategorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubCategry a = new frmSubCategry();
            a.MdiParent = this;
            a.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo a = new frmUserInfo();
            a.MdiParent = this;
            a.Show();
        }

        private void productReceivedInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseAuthontication a = new frmPurchaseAuthontication();
            a.MdiParent = this;
            a.Show();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            var dbContext=new Digital_AppEntities();
            Global.LoggedInUser = dbContext.Users.Where(c=>c.ID==1).SingleOrDefault();
        }

        private void userGroupSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserGroup a = new frmUserGroup();
            a.MdiParent = this;
            a.Show();
        }

        private void newFarmerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFarmerInformation a = new frmFarmerInformation();
            a.MdiParent = this;
            a.Show();
        }

        private void collectProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemPurchase.Instance.MdiParent = this;
            frmItemPurchase.Instance.Show();
        }

        private void sentRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductRequest a = new frmProductRequest();
            a.MdiParent = this;
            a.Show();
        }

        private void productReceivedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseAuthontication a = new frmPurchaseAuthontication();
            a.MdiParent = this;
            a.Show();
        }

        private void productReceivedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductReceived a = new frmProductReceived();
            a.MdiParent = this;
            a.Show();
        }

        private void productStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmitemStock a = new frmitemStock();
            a.MdiParent = this;
            a.Show();
        }

        private void productDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmSalesDistribution.Instance.MdiParent = this;
            frmSalesDistribution.Instance.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Company a = new Company();
            a.MdiParent = this;
            a.Show();
        }

        private void productCollectInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportViewer a = new frmReportViewer();
            a.MdiParent = this;
            a.Show();
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer a = new frmCustomer();
            a.MdiParent = this;
            a.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportViewer a = new frmReportViewer();
            a.MdiParent = this;
            a.Show();
        }

        private void requestAuthorizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseAuthontication a = new frmPurchaseAuthontication();
            a.MdiParent = this;
            a.Show();
        }

        private void productReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductReceived a = new frmProductReceived();
            a.MdiParent = this;
            a.Show();
        }

        private void distributionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmSalesDistribution.Instance.MdiParent = this;
            frmSalesDistribution.Instance.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmitemStock a = new frmitemStock();
            a.MdiParent = this;
            a.Show();
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReportViewer a = new frmReportViewer();
            a.MdiParent = this;
            a.Show();
        }
        private bool isApplicationClosed = false;
        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.IsLoggedIn)
            {
                if (!isApplicationClosed)
                {
                    var closeMsg = MessageBox.Show(MessageManager.ApplicationCloseConfirmationMsg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (closeMsg == DialogResult.Yes)
                    {
                         isApplicationClosed = true;
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
