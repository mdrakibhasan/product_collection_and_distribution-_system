using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.DBManager;

namespace View.UI
{
    public partial class AgentMaster : Form
    {
        private int childFormNumber = 0;

        public AgentMaster()
        {
            InitializeComponent();
        }
        #region Public Methods

        public void SetLoggedInUserToStatusStrip(string UserID, string CompanyID, string MainBranchID, string GroupID)
        {
           
            this.WindowState = FormWindowState.Maximized;
            // this.EnableMenuByGroupID();

        }

        #endregion

        private static AgentMaster _frmPOSMDI;
        #region Public Properties

        public static AgentMaster Instance
        {
            get
            {
                if (_frmPOSMDI == null || _frmPOSMDI.IsDisposed)
                    _frmPOSMDI = new AgentMaster();
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
            this.Close();
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
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
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

        private void farmerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFarmerInformation a = new frmFarmerInformation();
            a.MdiParent = this;
            a.Show();
        }

        private void productCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemPurchase.Instance.MdiParent = this;
            frmItemPurchase.Instance.Show();
        }

        private void productRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductRequest a = new frmProductRequest();
            a.MdiParent = this;
            a.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private bool isApplicationClosed = false;
        private void AgentMaster_FormClosing(object sender, FormClosingEventArgs e)
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
