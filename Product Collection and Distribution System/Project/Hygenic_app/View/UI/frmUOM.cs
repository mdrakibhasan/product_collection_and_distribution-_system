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

namespace View.UI
{
    public partial class frmUOM : Form
    
    {
        
        

        private int uomID;
        private bool isRecordSaved = false;
        public static frmUOM _frmUOM;


        public frmUOM()
        {
            InitializeComponent();
        }
       
        private void ClearControls()
        {
            uomID = 0;
            txtName.Text = string.Empty;
            chkActive.Checked = true;

            using (var posContext = new Digital_AppEntities())
            {
                dgvUOM.Rows.Clear();
                dgvUOM.AutoGenerateColumns = false;
                //dgvUOM.DataSource = posContext.UOMs;
                foreach (UOM auom in posContext.UOMs.OrderByDescending(c => c.ID))
                {
                    dgvUOM.Rows.Add(auom.ID, auom.Name, auom.Active);
                }
            }

            txtName.Focus();
        }

      

       
      
       

        private void frmUOM_Load(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvUOM.AutoGenerateColumns = false;
                //dgvUOM.DataSource = posContext.UOMs;
                foreach(UOM auom in posContext.UOMs.OrderByDescending(c=>c.ID))
                {
                    dgvUOM.Rows.Add(auom.ID,auom.Name,auom.Active);
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var posContext = new Digital_AppEntities();
                {
                    UOM auom;
                    if (uomID == 0)
                    {
                        if (CheckInput())
                            return;
                        
                         auom = new UOM();
                        auom.Name = txtName.Text;
                        auom.Active = chkActive.Checked;
                        auom.CreatedBy = (short)Global.LoggedInUser.ID;
                        auom.CreatedDate = DateTime.Now;
                         posContext.UOMs.Add(auom);
                       posContext.SaveChanges();;
                    }
                    else
                    {
                        auom = posContext.UOMs.SingleOrDefault(c => c.ID == uomID);
                        auom.Name = txtName.Text;
                        auom.Active = chkActive.Checked;
                        //uom.ModifiedBy = Global.LoggedInUser.ID;
                        auom.ModifiedDate = DateTime.Now;
                    }
                    posContext.SaveChanges();
                    //dgvUOM.DataSource = posContext.UOMs;
                    isRecordSaved = true;
                    this.ClearControls();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.GetType().Name == "SqlException")
                    {
                        int errorNumber = ((System.Data.SqlClient.SqlException)(ex.InnerException)).Number;
                        switch (errorNumber)
                        {
                            case 2601:
                                MessageBox.Show(MessageManager.GetDuplicateErrorMsg(this.Text.ToLower()), Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                MessageBox.Show(MessageManager.CommonExceptionMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                        MessageBox.Show(ex.InnerException.Message, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(MessageManager.CommonExceptionMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isRecordSaved = false;
            ClearControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUOM_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUOM.ClearSelection();
        }

        private void dgvUOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uomID = Convert.ToInt16(dgvUOM.CurrentRow.Cells["dgvID"].Value);
            txtName.Text = dgvUOM.CurrentRow.Cells["dgvName"].Value.ToString();
            chkActive.Checked = Convert.ToBoolean(dgvUOM.CurrentRow.Cells["dgvActive"].Value);
        }

        public bool CheckInput()
        {
            var posContext = new Digital_AppEntities();

            string name = txtName.Text;
            var searchData = posContext.UOMs.ToList();
            foreach (var itemData in searchData)
            {
                if (itemData.Name == name)
                {
                    MessageBox.Show("Sorry  This Item alrady Exist ;", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return true;
                }

            }
            return false;

        }
    }
}
