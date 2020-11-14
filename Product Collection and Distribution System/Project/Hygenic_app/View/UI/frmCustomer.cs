using Digital_app;
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
    public partial class frmCustomer : Form
    {
        #region Private Member Variables

        private short customerID;
        private bool isRecordSaved = false;
        private static frmCustomer _frmCustomer;

        private frmSalesDistribution _afrmOrderMultiple;
        private frmSalesDistribution _afrmOrderoffersales;
        private string Flag;

        #endregion

        #region Private Methods
        public int MainBranchID = 0;
        private void ClearControls()
        {
            customerID = 0;
            //cmbContactTitle.SelectedIndex = 0;
            txtContactName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;

            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            cmbCountry.SelectedItem = "Bangladesh";

            chkActive.Checked = true;

            if (!isRecordSaved)
            {
                if (dgvCustomer.Rows.Count > 0)
                {
                    dgvCustomer.ClearSelection();
                }
            }
            using (var posContext = new Digital_AppEntities())
            {


                dgvCustomer.Rows.Clear();
                foreach (CustomerInformation a in posContext.CustomerInformations.OrderByDescending(a => a.ID))
                {

                    dgvCustomer.Rows.Add(a.ID, a.Code, a.FullName, a.Mobile, a.Phone, a.Fax, a.Email, a.Address1, a.Address2, a.City, a.State, a.PostalCode, a.Country, a.DateOfBirth, a.Maragedate, a.Active);
                }
            }
        }

        private void LoadCustomers(Digital_AppEntities posContext)
        {
            dgvCustomer.AutoGenerateColumns = false;
           // dgvCustomer.DataSource = posContext.CustomerInformations.OrderByDescending(id => id.ID);
        }

        private void GenerateCode(Digital_AppEntities posContext)
        {
            var customers = posContext.Customers;
            if (customers.Count() == 0)
                txtCode.Text = "D" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + MainBranchID.ToString().PadLeft(2, '0') + "1".PadLeft(5, '0');
            else
            {
                Customer customer = customers.OrderByDescending(id => id.ID).Take(1).Single();
                txtCode.Text = "D" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + MainBranchID.ToString().PadLeft(2, '0') + ((customer.ID + 1).ToString()).PadLeft(5, '0');
            }
        }

        #endregion

        #region Private Constructor

        public frmCustomer()
        {
            InitializeComponent();
        }

        
       

        #endregion

        #region Public Properties

        public string CallerFrom
        {
            get;
            set;
        }

        public static frmCustomer Instance
        {
            get
            {
                if (_frmCustomer == null || _frmCustomer.IsDisposed)
                    _frmCustomer = new frmCustomer();
                return _frmCustomer;
            }
        }

        #endregion

        private void txtContactName_TextChanged(object sender, EventArgs e)
        {
            if (txtContactName.Text.Length > 0)
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
                if (string.IsNullOrEmpty(txtMobile.Text))
                {
                    MessageBox.Show("Please Input Mobile NO", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtMobile.Text))
                {
                    MessageBox.Show("Please Input Customer Name", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtMobile.Text.Replace(".", "").Length < 11)
                {
                    MessageBox.Show("Invalid Mobile No", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                using (var posContext = new Digital_AppEntities())
                {
                    Customer customer;
                    if (customerID == 0)
                    {
                        try
                        {
                            customer = posContext.Customers.Single(id => id.Mobile == txtMobile.Text);

                            if (customer != null)
                            {
                                MessageBox.Show("This MobileNo Already Added..", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        catch
                        {

                        }
                        customer = new Customer();
                        customer.Code = txtCode.Text;
                        // customer.ContactTitle = cmbContactTitle.SelectedItem.ToString();
                        customer.ContactName = txtContactName.Text;

                        customer.Mobile = txtMobile.Text;
                        customer.Phone = txtPhone.Text;
                        customer.Fax = txtFax.Text;
                        customer.Email = txtEmail.Text;

                        customer.Address1 = txtAddress1.Text;
                        customer.Address2 = txtAddress2.Text;
                        customer.City = txtCity.Text;
                        customer.State = txtState.Text;
                        customer.DateOfBirth = dtpDateofbirth.Value;
                        customer.Maragedate = dtpMarriagedate.Value;
                        customer.PostalCode = txtPostalCode.Text;
                        if (cmbCountry.SelectedValue != null)
                        {
                            customer.Country = cmbCountry.SelectedItem.ToString();
                        }
                        customer.Active = chkActive.Checked;
                        posContext.Customers.Add(customer);
                        posContext.SaveChanges();
                    }
                    else
                    {
                        try
                        {
                            customer = posContext.Customers.Single(id => id.Mobile == txtMobile.Text && id.ID != customerID);

                            if (customer != null)
                            {
                                MessageBox.Show("This MobileNo Already Added..", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        catch
                        {

                        }
                        customer = posContext.Customers.Single(id => id.ID == customerID);

                        // customer.ContactTitle = cmbContactTitle.SelectedItem.ToString();
                        customer.ContactName = txtContactName.Text;

                        customer.Mobile = txtMobile.Text;
                        customer.Phone = txtPhone.Text;
                        customer.Fax = txtFax.Text;
                        customer.Email = txtEmail.Text;

                        customer.Address1 = txtAddress1.Text;
                        customer.Address2 = txtAddress2.Text;
                        customer.City = txtCity.Text;
                        customer.State = txtState.Text;
                        customer.DateOfBirth = dtpDateofbirth.Value;
                        customer.Maragedate = dtpMarriagedate.Value;
                        customer.PostalCode = txtPostalCode.Text;
                        if (cmbCountry.SelectedValue != null)
                        {
                            customer.Country = cmbCountry.SelectedItem.ToString();
                        }

                        customer.Active = chkActive.Checked;
                        posContext.SaveChanges();
                    }

                    this.LoadCustomers(posContext);
                    isRecordSaved = true;

                    this.ClearControls();
                    this.GenerateCode(posContext);
                    txtContactName.Focus();

                    
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
            using (var posContext = new Digital_AppEntities())
            { this.GenerateCode(posContext); }
            txtContactName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
           // MainBranchID = IdManager.GetShowSingleValueInt("ServerID", "MainBranch", "BranchInfo", "1");
            using (var posContext = new Digital_AppEntities())
            {

                GenerateCode(posContext);
                // cmbContactTitle.SelectedIndex = 0;
                LoadCustomers(posContext);
                dgvCustomer.Rows.Clear();
                foreach (CustomerInformation a in posContext.CustomerInformations.OrderByDescending(a => a.ID))
                {

                    dgvCustomer.Rows.Add(a.ID,a.Code,a.FullName,a.Mobile,a.Phone,a.Fax,a.Email,a.Address1,a.Address2,a.City,a.State,a.PostalCode,a.Country,a.DateOfBirth,a.Maragedate,a.Active);
                }
                //Global.LoadCountry(cmbCountry);
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvCustomer.AutoGenerateColumns = false;
                dgvCustomer.DataSource = posContext.CustomerInformations.Where(id => (id.Code + id.ContactPerson + id.Mobile + id.Phone + id.Fax + id.Email).Contains(txtSearch.Text));
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            customerID = Convert.ToInt16(dgvCustomer.CurrentRow.Cells["colID"].Value);
            txtCode.Text = dgvCustomer.CurrentRow.Cells["colCode"].Value.ToString();
            // cmbContactTitle.Text = dgvCustomer.CurrentRow.Cells["colContactTitle"].Value.ToString();
            txtContactName.Text = dgvCustomer.CurrentRow.Cells["colContactPerson"].Value.ToString();
            if (dgvCustomer.CurrentRow.Cells["colMobile"].Value != null)
            {
                txtMobile.Text = dgvCustomer.CurrentRow.Cells["colMobile"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colPhone"].Value != null)
            {
                txtPhone.Text = dgvCustomer.CurrentRow.Cells["colPhone"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colFax"].Value != null)
            {
                txtFax.Text = dgvCustomer.CurrentRow.Cells["colFax"].Value.ToString();
            }
            try
            {
                if (dgvCustomer.CurrentRow.Cells["colDateOfBirth"].Value != null)
                {
                    dtpDateofbirth.Value = DataManager.DateEncode(dgvCustomer.CurrentRow.Cells["colDateOfBirth"].Value.ToString());
                }
            }
            catch
            {
            }
            try
            {
                if (dgvCustomer.CurrentRow.Cells["colMaragedate"].Value != null)
                {
                    dtpMarriagedate.Value = DataManager.DateEncode(dgvCustomer.CurrentRow.Cells["colMaragedate"].Value.ToString());

                }
            }
            catch
            {

            }

            if (dgvCustomer.CurrentRow.Cells["colEmail"].Value != null)
            {
                txtEmail.Text = dgvCustomer.CurrentRow.Cells["colEmail"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colAddress1"].Value != null)
            {
                txtAddress1.Text = dgvCustomer.CurrentRow.Cells["colAddress1"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colAddress2"].Value != null)
            {
                txtAddress2.Text = dgvCustomer.CurrentRow.Cells["colAddress2"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colCity"].Value != null)
            {
                txtCity.Text = dgvCustomer.CurrentRow.Cells["colCity"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colState"].Value != null)
            {
                txtState.Text = dgvCustomer.CurrentRow.Cells["colState"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colPostalCode"].Value != null)
            {
                txtPostalCode.Text = dgvCustomer.CurrentRow.Cells["colPostalCode"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colCountry"].Value != null)
            {
                cmbCountry.SelectedItem = dgvCustomer.CurrentRow.Cells["colCountry"].Value.ToString();
            }
            if (dgvCustomer.CurrentRow.Cells["colActive"].Value != null)
            {
                chkActive.Checked = Convert.ToBoolean(dgvCustomer.CurrentRow.Cells["colActive"].Value);
            }
            else
            {
                chkActive.Checked = false;
            }

            
        }

        private void dgvCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCustomer.ClearSelection();
        }

        private void txtContactName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
