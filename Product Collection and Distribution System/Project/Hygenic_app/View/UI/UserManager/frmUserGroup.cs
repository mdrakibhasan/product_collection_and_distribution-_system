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

namespace View.UI.UserManager
{
    public partial class frmUserGroup : Form
    {
        private short userGroupID;
        private bool isRecordSaved = false;
        private static frmUserGroup _frmUserGroup;

        private void ClearControls()
        {
            userGroupID = 0;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkActive.Checked = false;

           
            using (var posContext = new Digital_AppEntities())
            {
                dgvUserGroup.Rows.Clear();
                dgvUserGroup.AutoGenerateColumns = false;
                foreach (var usergroup in posContext.UserGroups)
                {
                    dgvUserGroup.Rows.Add(usergroup.ID,usergroup.Name,usergroup.Description,usergroup.Active);
                }
            }

            txtName.Focus();
        }
        public frmUserGroup()
        {
            InitializeComponent();
        }

        private void frmUserGroup_Load(object sender, EventArgs e)
        {
            ClearControls();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var posContext = new Digital_AppEntities();
                {
                    UserGroup userGroup;
                    if (userGroupID == 0)
                    {
                        userGroup = new UserGroup();
                        userGroup.Name = txtName.Text;
                        userGroup.Description = txtDescription.Text.Trim();
                        userGroup.Active = chkActive.Checked;
                        userGroup.CreatedBy = (short)Global.LoggedInUser.ID;
                        posContext.UserGroups.Add(userGroup);
                    }
                    else
                    {
                        userGroup = posContext.UserGroups.Single(id => id.ID == userGroupID);
                        userGroup.Name = txtName.Text;
                        userGroup.Description = txtDescription.Text.Trim();
                        userGroup.Active = chkActive.Checked;
                        userGroup.ModifiedBy = (short)Global.LoggedInUser.ID;
                        userGroup.ModifiedDate = DateTime.Now;
                    }
                    posContext.SaveChanges();
                    
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
                {
                    if (ex.GetType().Name == "SqlException")
                    {
                        int errorNumber = ((System.Data.SqlClient.SqlException)(ex)).Number;
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
                        MessageBox.Show(MessageManager.CommonExceptionMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void dgvUserGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userGroupID = Convert.ToInt16(dgvUserGroup.CurrentRow.Cells["colID"].Value);
            txtName.Text = dgvUserGroup.CurrentRow.Cells["colName"].Value.ToString();
            txtDescription.Text = dgvUserGroup.CurrentRow.Cells["colDescription"].Value.ToString();
            chkActive.Checked = Convert.ToBoolean(dgvUserGroup.CurrentRow.Cells["colActive"].Value);
        }

        private void dgvUserGroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUserGroup.ClearSelection();
        }
    }
}
