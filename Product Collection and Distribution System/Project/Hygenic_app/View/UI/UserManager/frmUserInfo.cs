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
    public partial class  frmUserInfo: Form
    {
        #region Private Member Variables

        private short userID;
        private bool isRecordSaved = false;
        private static frmUserInfo _frmUser;

        #endregion

        #region Private Methods

        private void ValidateUserForm()
        {
            if (txtFullName.Text.Length > 0 && txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0 && cmbUserGroup.SelectedIndex != -1)
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

        private void ClearControls()
        {
            userID = 0;
            txtFullName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbUserGroup.SelectedIndex = -1;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtNationalID.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPosatalCode.Text = string.Empty;
            //cmbCountry.SelectedItem = "Bangladesh";
            chkActive.Checked = false;

            if (!isRecordSaved)
            {
                if (dgvUserInformation.Rows.Count > 0)
                    dgvUserInformation.ClearSelection();
            }

            txtFullName.Focus();
        }

        #endregion

        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                List<UserGroup> auom = posContext.UserGroups.ToList();
                DataTable dtItemInfo = Global.LINQToDataTable(auom);
               

                cmbUserGroup.DataSource = dtItemInfo;
                cmbUserGroup.DisplayMember = "Name";
                cmbUserGroup.ValueMember = "ID";
                cmbUserGroup.SelectedIndex = -1;

               // Global.LoadCountry(cmbCountry);
                dgvUserInformation.AutoGenerateColumns = false;
                foreach (var a in posContext.Users.OrderByDescending(id => id.ID))
                {
                    dgvUserInformation.Rows.Add(a.ID, a.FullName, a.UserName, a.UserPassword, a.Mobile, a.Phone, a.Fax, a.Email, a.UserGroupID, "", a.NationalID, a.Address1, a.Address2, a.City, a.State, a.PostalCode, a.Active);

                }
                

            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            ValidateUserForm();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.ValidateUserForm();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this.ValidateUserForm();
        }

        private void cmbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ValidateUserForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var posContext = new Digital_AppEntities())
                {
                    User user;
                    PasswordManager passwordManager = new PasswordManager();
                    if (userID == 0)
                    {
                        user = new User();

                        user.FullName = txtFullName.Text;
                        user.UserName = txtUserName.Text;
                        user.UserPassword = passwordManager.Encrypt(txtPassword.Text);
                        user.Mobile = txtMobile.Text;
                        user.NationalID = txtNationalID.Text;
                        user.Mobile = txtMobile.Text;
                        user.Phone = txtPhone.Text;
                        user.Fax = txtFax.Text;
                        user.Email = txtEmail.Text;
                        user.Address1 = txtAddress1.Text;
                        user.Address2 = txtAddress2.Text;
                        user.City = txtCity.Text;
                        user.State = txtState.Text;
                        user.PostalCode = txtPosatalCode.Text;
                       // user.Country = cmbCountry.SelectedItem.ToString();
                        user.UserGroupID = Convert.ToInt16(cmbUserGroup.SelectedValue);
                        user.Active = chkActive.Checked;
                        user.CreatedBy = Global.LoggedInUser.ID;
                        user.CreatedDate = DateTime.Now;
                        user.CompanyId = 1;
                        posContext.Users.Add(user);
                    }
                    else
                    {
                        user = posContext.Users.Single(id => id.ID == userID);
                        user.FullName = txtFullName.Text;
                        user.UserName = txtUserName.Text;
                        user.UserPassword = passwordManager.Encrypt(txtPassword.Text);
                        user.Mobile = txtMobile.Text;
                        user.NationalID = txtNationalID.Text;
                        user.Mobile = txtMobile.Text;
                        user.Phone = txtPhone.Text;
                        user.Fax = txtFax.Text;
                        user.Email = txtEmail.Text;
                        user.Address1 = txtAddress1.Text;
                        user.Address2 = txtAddress2.Text;
                        user.City = txtCity.Text;
                        user.State = txtState.Text;
                        user.PostalCode = txtPosatalCode.Text;
                       // user.Country = cmbCountry.SelectedItem.ToString();
                        user.UserGroupID = Convert.ToInt16(cmbUserGroup.SelectedValue);
                        user.Active = chkActive.Checked;
                        user.ModifiedBy = Global.LoggedInUser.ID;
                        user.ModifiedDate = DateTime.Now;
                        user.CompanyId = 1;
                    }
                    posContext.SaveChanges();
                    dgvUserInformation.Rows.Clear();

                    foreach (var a in posContext.Users.OrderByDescending(id => id.ID))
                    {
                        dgvUserInformation.Rows.Add(a.ID, a.FullName, a.UserName, a.UserPassword, a.Mobile, a.Phone, a.Fax, a.Email, a.UserGroupID, "", a.NationalID, a.Address1, a.Address2, a.City, a.State, a.PostalCode, a.Active);

                    }
                    isRecordSaved = true;
                    ClearControls();
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
            this.ClearControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvUserInformation.Rows.Clear();
                if (txtSearch.Text.Length > 0)
                {
                    foreach (var a in posContext.Users.Where(id => (id.FullName + id.UserName + id.Mobile + id.Email + id.UserGroup.Name).Contains(txtSearch.Text.Trim())).OrderByDescending(id => id.ID))
                    {
                        dgvUserInformation.Rows.Add(a.ID,a.FullName,a.UserName,a.UserPassword,a.Mobile,a.Phone,a.Fax,a.Email,a.UserGroupID,"",a.NationalID,a.Address1,a.Address2,a.City,a.State,a.PostalCode,a.Active);

                    }
                    
                    
                   }

                else
                {

                    foreach (var a in posContext.Users.OrderByDescending(id => id.ID))
                    {
                        dgvUserInformation.Rows.Add(a.ID, a.FullName, a.UserName, a.UserPassword, a.Mobile, a.Phone, a.Fax, a.Email, a.UserGroupID, "", a.NationalID, a.Address1, a.Address2, a.City, a.State, a.PostalCode, a.Active);

                    }
                }
                    
            }
        }

        private void dgvUserInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PasswordManager passwordManager = new PasswordManager();
                userID = Convert.ToInt16(dgvUserInformation.CurrentRow.Cells["colID"].Value);
                txtFullName.Text = dgvUserInformation.CurrentRow.Cells["colFullName"].Value.ToString();
                txtUserName.Text = dgvUserInformation.CurrentRow.Cells["colUserName"].Value.ToString();
                txtPassword.Text = passwordManager.Decrypt(dgvUserInformation.CurrentRow.Cells["colPassword"].Value.ToString());

                if (dgvUserInformation.CurrentRow.Cells["colMobile"].Value != null)
                {
                    txtMobile.Text = dgvUserInformation.CurrentRow.Cells["colMobile"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colPhone"].Value != null)
                {
                    txtPhone.Text = dgvUserInformation.CurrentRow.Cells["colPhone"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colFax"].Value != null)
                {
                    txtFax.Text = dgvUserInformation.CurrentRow.Cells["colFax"].Value.ToString();
                }

                if (dgvUserInformation.CurrentRow.Cells["colNationalID"].Value != null)
                {
                    txtNationalID.Text = dgvUserInformation.CurrentRow.Cells["colNationalID"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colActive"].Value != null)
                {
                    chkActive.Checked = Convert.ToBoolean(dgvUserInformation.CurrentRow.Cells["colActive"].Value);
                }
                //if (dgvUserInformation.CurrentRow.Cells["colCountry"].Value != null)
                //{
                //    cmbCountry.SelectedItem = dgvUserInformation.CurrentRow.Cells["colCountry"].Value.ToString();
                //}
                if (dgvUserInformation.CurrentRow.Cells["colPostalCode"].Value != null)
                {

                    txtPosatalCode.Text = dgvUserInformation.CurrentRow.Cells["colPostalCode"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colState"].Value != null)
                {
                    txtState.Text = dgvUserInformation.CurrentRow.Cells["colState"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colCity"].Value != null)
                {
                    txtCity.Text = dgvUserInformation.CurrentRow.Cells["colCity"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colAddress2"].Value != null)
                {
                    txtAddress2.Text = dgvUserInformation.CurrentRow.Cells["colAddress2"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colAddress1"].Value != null)
                {
                    txtAddress1.Text = dgvUserInformation.CurrentRow.Cells["colAddress1"].Value.ToString();
                }
                if (dgvUserInformation.CurrentRow.Cells["colUserGroupID"].Value != null)
                {
                    cmbUserGroup.SelectedValue = dgvUserInformation.CurrentRow.Cells["colUserGroupID"].Value;
                }
                if (dgvUserInformation.CurrentRow.Cells["colEmail"].Value != null)
                {
                    txtEmail.Text = dgvUserInformation.CurrentRow.Cells["colEmail"].Value.ToString();
                }
            }
            catch
            {

            }
        }

        private void dgvUserInformation_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUserInformation.ClearSelection();
        }
    }
}
