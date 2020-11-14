using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.DataModel;
using View.DBManager;

namespace View.UI
{
    public partial class Company : Form
    {

        private static Master _frmPOSMDI;
        private bool isApplicationClosed = false;
        private int childFormNumber = 0;
        private short CompanyID;
        private static Company _frmCompany;

        public static Company Instance
        {
            get
            {
                if (_frmCompany == null || _frmCompany.IsDisposed)
                    _frmCompany = new Company();
                return _frmCompany;
            }
        }
        public Company()
        {
            InitializeComponent();
        }

        private void Company_Load(object sender, EventArgs e)
        {
            Global.LoadCountry(cmbCountry);

            using (var posContext = new Digital_AppEntities())
            {
                dgvCompany.AutoGenerateColumns = false;
                dgvCompany.Rows.Clear();
                foreach (CompanyInfo a in posContext.CompanyInfoes.OrderByDescending(id => id.ID).ToList())
                {
                    dgvCompany.Rows.Add(a.Name,a.Mobile,a.Phone,a.VATRegistration,a.ID,a.ParentID,a.Fax,a.Country,a.Logo,a.Email,a.Website,a.Address1,a.Address2,a.City,a.State,a.PostalCode);
                }
                //dgvCompany.DataSource = posContext.CompanyInfoes.OrderByDescending(id => id.ID);

                //cmbParentName.DataSource = posContext.CompanyInfoes.Where(c => c.ParentID == 0);
                //cmbParentName.SelectedIndex = -1;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgFileOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (dlgFileOpen.ShowDialog() == DialogResult.OK)
            {
                pbLogo.Image = new Bitmap(dlgFileOpen.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var posContext = new Digital_AppEntities())
                {
                    CompanyInfo company;
                    if (CompanyID == 0)
                    {
                        company = new CompanyInfo();
                        if (cmbParentName.SelectedValue == null)
                        {
                            company.ParentID = 0;
                        }
                        else
                        {
                            company.ParentID = Convert.ToInt32(cmbParentName.SelectedValue);
                        }
                        company.Name = txtName.Text;
                        company.Mobile = txtMobile.Text;
                        company.Phone = txtPhone.Text;
                        company.Fax = txtFax.Text;
                        company.Email = txtEmail.Text;
                        company.Website = txtWebsite.Text;
                        company.VATRegistration = txtVATNo.Text;

                        MemoryStream stream = new MemoryStream();
                        if (pbLogo.Image != null)
                            pbLogo.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        company.Logo = stream.ToArray();

                        company.Address1 = txtAddress1.Text;
                        company.Address2 = txtAddress2.Text;
                        company.City = txtCity.Text;
                        company.State = txtState.Text;
                        company.PostalCode = txtPosatalCode.Text;
                        company.Country = cmbCountry.SelectedItem.ToString();
                        posContext.CompanyInfoes.Add(company);


                        MessageBox.Show(MessageManager.CompanySaved, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        company = posContext.CompanyInfoes.Single(id => id.ID == CompanyID);
                        if (cmbParentName.SelectedValue == null)
                        {
                            company.ParentID = 0;
                        }
                        else
                        {
                            company.ParentID = Convert.ToInt32(cmbParentName.SelectedValue);
                        }
                        company.Name = txtName.Text;
                        company.Mobile = txtMobile.Text;
                        company.Phone = txtPhone.Text;
                        company.Fax = txtFax.Text;
                        company.Email = txtEmail.Text;
                        company.Website = txtWebsite.Text;
                        company.VATRegistration = txtVATNo.Text;

                        MemoryStream stream = new MemoryStream();
                        if (pbLogo.Image != null)
                            pbLogo.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        company.Logo = stream.ToArray();

                        company.Address1 = txtAddress1.Text;
                        company.Address2 = txtAddress2.Text;
                        company.City = txtCity.Text;
                        company.State = txtState.Text;
                        company.PostalCode = txtPosatalCode.Text;
                        company.Country = cmbCountry.SelectedItem.ToString();
                    }
                    posContext.SaveChanges();
                    this.ClearForm();
                    cmbParentName.DataSource = posContext.CompanyInfoes.OrderBy(id => id.Name);
                    cmbParentName.SelectedIndex = -1;
                    //dgvCompany.DataSource = posContext.CompanyInfoes.OrderByDescending(id => id.ID);
                    int ComId = Convert.ToInt32(Global.LoggedInUser.CompanyId);
                    Global.Company = posContext.CompanyInfoes.SingleOrDefault(c => c.ID == ComId);

                }
                //isApplicationClosed = true;
                //Application.Restart();



            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.GetType().Name == "SqlException")
                    {
                        MessageBox.Show(ex.InnerException.Message, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show(MessageManager.CommonExceptionMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            CompanyID = 0;
            this.cmbParentName.SelectedIndex = -1;
            this.txtName.Text = string.Empty;
            this.txtMobile.Text = string.Empty;
            this.txtPhone.Text = string.Empty;

            this.txtFax.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtWebsite.Text = string.Empty;

            this.txtVATNo.Text = string.Empty;
            this.txtAddress1.Text = string.Empty;
            this.txtAddress2.Text = string.Empty;
            this.txtCity.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtPosatalCode.Text = string.Empty;
            this.cmbCountry.SelectedItem = "Bangladesh";
            this.pbLogo.Image = null;

            using (var posContext = new Digital_AppEntities())
            {
                dgvCompany.AutoGenerateColumns = false;
                dgvCompany.Rows.Clear();
                foreach (CompanyInfo a in posContext.CompanyInfoes.OrderByDescending(id => id.ID).ToList())
                {
                    dgvCompany.Rows.Add(a.Name, a.Mobile, a.Phone, a.VATRegistration, a.ID, a.ParentID, a.Fax, a.Country, a.Logo, a.Email, a.Website, a.Address1, a.Address2, a.City, a.State, a.PostalCode);
                }
                //dgvCompany.DataSource = posContext.CompanyInfoes.OrderByDescending(id => id.ID);

                //cmbParentName.DataSource = posContext.CompanyInfoes.Where(c => c.ParentID == 0);
                //cmbParentName.SelectedIndex = -1;
            }
            txtName.Focus();
        }

        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                CompanyID = Convert.ToInt16(dgvCompany.CurrentRow.Cells["ID"].Value);
                cmbParentName.SelectedValue = Convert.ToInt16(dgvCompany.CurrentRow.Cells["ParentCompany"].Value);
                txtName.Text = dgvCompany.CurrentRow.Cells["CompanyName"].Value.ToString();
                txtVATNo.Text = dgvCompany.CurrentRow.Cells["VATRegistration"].Value.ToString();
                txtMobile.Text = dgvCompany.CurrentRow.Cells["Mobile"].Value.ToString();
                txtPhone.Text = dgvCompany.CurrentRow.Cells["Phone"].Value.ToString();
                txtFax.Text = dgvCompany.CurrentRow.Cells["Fax"].Value.ToString();
                txtEmail.Text = dgvCompany.CurrentRow.Cells["Email"].Value.ToString();
                txtWebsite.Text = dgvCompany.CurrentRow.Cells["Website"].Value.ToString();
                txtAddress1.Text = dgvCompany.CurrentRow.Cells["Address1"].Value.ToString();
                txtAddress2.Text = dgvCompany.CurrentRow.Cells["Address2"].Value.ToString();
                txtCity.Text = dgvCompany.CurrentRow.Cells["City"].Value.ToString();
                txtState.Text = dgvCompany.CurrentRow.Cells["State"].Value.ToString();
                txtPosatalCode.Text = dgvCompany.CurrentRow.Cells["PostalCode"].Value.ToString();

                byte[] image = (byte[])dgvCompany.CurrentRow.Cells["Logo"].Value;
                if (image != null)
                {
                    MemoryStream stream = new MemoryStream(image);
                    if (stream.Length > 0)
                        pbLogo.Image = Image.FromStream(stream);
                    else
                        pbLogo.Image = null;
                }
                else { pbLogo.Image = null; }


                cmbCountry.SelectedItem = dgvCompany.CurrentRow.Cells["Country"].Value.ToString();
            }

        }
    }
}
