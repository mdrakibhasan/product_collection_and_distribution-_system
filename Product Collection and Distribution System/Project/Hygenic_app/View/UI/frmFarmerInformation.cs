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
    public partial class frmFarmerInformation : Form
    {

        #region Private Member Variables

        private short supplierID;
        private bool isRecordSaved = false;
        private static frmFarmerInformation _frmSupplier;

        #endregion

        #region Private Methods

        private void ClearControls()
        {
            supplierID = 0;
            txtName.Text = string.Empty;
            txtfathername.Text = txtMotherName.Text = "";
            txtMobileNo.Text = string.Empty;
            txtEmail.Text = string.Empty;

            txtAddress.Text = string.Empty;
            cmbDistrict.SelectedIndex = -1;
            cmbThana.SelectedIndex = -1;

            cmbCountry.SelectedItem = "Bangladesh";

            txtPostalCode.Text = "";
            chkActive.Checked = true;
            dgvFarmer.Rows.Clear();
            if (!isRecordSaved)
            {
                if (dgvFarmer.Rows.Count > 0)
                {
                    dgvFarmer.ClearSelection();
                }
            }

            try
            {

                using (var posContext = new Digital_AppEntities())
                {
                    foreach (var a in posContext.FarmerInfoes.OrderByDescending(c => c.ID).ToList())
                    {
                        dgvFarmer.Rows.Add(a.ID, a.Code, a.FarmerName, a.FarmerName, a.MotherName, a.MobileNo, a.Email, a.Address, a.PostalCode, a.COUNTRY_INFO.COUNTRY_DESC, a.Active);
                    }
                }
            }

            catch
            {
            }
        }

        private void GenerateCode()
        {
            Digital_AppEntities posContext = new Digital_AppEntities();
            var suppliers = posContext.FarmerInfoes;
            if (suppliers.Count() == 0)
                txtcode.Text = "FR-" + "1".PadLeft(6, '0');
            else
            {

                FarmerInfo supplier = suppliers.OrderByDescending(id => id.ID).Take(1).Single();
                txtcode.Text = "FR-" + ((Convert.ToInt16(supplier.Code.Substring(4)) + 1).ToString().PadLeft(6, '0'));
            }
        }

        private void LoadSuppliers(Digital_AppEntities posContext)
        {
            dgvFarmer.AutoGenerateColumns = false;
            dgvFarmer.DataSource = posContext.FarmerInfoes.OrderByDescending(id => id.ID);
        }

        private void EnableButton()
        {
            if (txtName.Text.Length > 0 && txtMobileNo.Text.Length > 0)
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

        #endregion
       

        public string CallerFrom
        {
            get;
            set;
        }



        public frmFarmerInformation()
        {
            InitializeComponent();
        }

        private void frmFarmerInformation_Load(object sender, EventArgs e)
        {

            RefreshAll();
        }

        private void RefreshAll()
        {
            GenerateCode();
            

            try
            {

                using (var posContext = new Digital_AppEntities())
                {
                    btnDelete.Enabled = false;
                    List<COUNTRY_INFO> aCategory = posContext.COUNTRY_INFO.ToList();
                    DataTable dtCategory = Global.LINQToDataTable(aCategory);
                    cmbCountry.DataSource = dtCategory;
                    cmbCountry.DisplayMember = "COUNTRY_DESC";
                    cmbCountry.ValueMember = "COUNTRY_CODE";
                    List<DISTRICTINFO> aDISTRICTINFO = posContext.DISTRICTINFOes.ToList();
                    DataTable dtDISTRICTINFO = Global.LINQToDataTable(aDISTRICTINFO);
                    cmbDistrict.DataSource = dtDISTRICTINFO;
                    cmbDistrict.DisplayMember = "DISTRICT_NAME";
                    cmbDistrict.ValueMember = "ID";
                    cmbDistrict.SelectedIndex = -1;
                    dgvFarmer.Rows.Clear();

                    foreach (var a in posContext.FarmerInfoes.OrderByDescending(c => c.ID).ToList())
                    {
                        dgvFarmer.Rows.Add(a.ID, a.Code, a.FarmerName, a.FarmerName, a.MotherName, a.MobileNo, a.Email, a.Address, a.PostalCode, a.COUNTRY_INFO.COUNTRY_DESC, a.Active);
                    }
                }
            }

            catch
            {
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            EnableButton();
           
        }

        private void cmbSupplierGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButton();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var posContext = new Digital_AppEntities())
                {
                    FarmerInfo aFarmerInfo;
                    if (supplierID == 0)
                    {
                        int Count = posContext.FarmerInfoes.Count(a=>a.MobileNo==txtMobileNo.Text);
                        if (Count>0)
                        {
                            MessageBox.Show("This MobileNo Already Exist..!!", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        aFarmerInfo = new FarmerInfo();
                        aFarmerInfo.Code = txtcode.Text;
                        aFarmerInfo.FarmerName = txtName.Text;
                        aFarmerInfo.FatherName = txtfathername.Text;
                        aFarmerInfo.MotherName = txtMotherName.Text;
                        aFarmerInfo.MobileNo = txtMobileNo.Text;
                        aFarmerInfo.Email = txtEmail.Text;
                        aFarmerInfo.Address = txtAddress.Text;
                        aFarmerInfo.PostalCode = txtPostalCode.Text;
                        if (cmbCountry.SelectedValue != null)
                        {
                            aFarmerInfo.CountryID = (int)cmbCountry.SelectedValue;
                        }
                        if (cmbDistrict.SelectedValue != null)
                        {
                            aFarmerInfo.DistricID = (int)cmbDistrict.SelectedValue;
                        }
                        if (cmbThana.SelectedValue != null)
                        {
                            aFarmerInfo.ThanaID = (int)cmbThana.SelectedValue;
                        }
                        aFarmerInfo.Active = chkActive.Checked;
                        posContext.FarmerInfoes.Add(aFarmerInfo);
                        MessageBox.Show("Save Successfully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    }
                    else
                    {
                        int Count = posContext.FarmerInfoes.Count(a => a.MobileNo == txtMobileNo.Text && a.ID != supplierID);
                        if (Count > 0)
                        {
                            MessageBox.Show("This MobileNo Already Exist..!!", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        aFarmerInfo = posContext.FarmerInfoes.Single(id => id.ID == supplierID);
                        aFarmerInfo.Code = txtcode.Text;
                        aFarmerInfo.FarmerName = txtName.Text;
                        aFarmerInfo.FatherName = txtfathername.Text;
                        aFarmerInfo.MotherName = txtMotherName.Text;
                        aFarmerInfo.MobileNo = txtMobileNo.Text;
                        aFarmerInfo.Email = txtEmail.Text;
                        aFarmerInfo.Address = txtAddress.Text;
                        aFarmerInfo.PostalCode = txtPostalCode.Text;
                        if (cmbCountry.SelectedValue != null)
                        {
                            aFarmerInfo.CountryID = (int)cmbCountry.SelectedValue;
                        }
                        if (cmbDistrict.SelectedValue != null)
                        {
                            aFarmerInfo.DistricID = (int)cmbDistrict.SelectedValue;
                        }
                        if (cmbThana.SelectedValue != null)
                        {
                            aFarmerInfo.ThanaID = (int)cmbThana.SelectedValue;
                        }

                        MessageBox.Show("Update Successfully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    }
                    aFarmerInfo.Active = chkActive.Checked;
                    posContext.SaveChanges();
                    //this.LoadSuppliers(posContext);
                    isRecordSaved = true;

                   

                    this.ClearControls();
                    this.GenerateCode();
                    txtName.Focus();


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
             this.GenerateCode(); 
            txtName.Focus();
            btnDelete.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var posContext = new Digital_AppEntities();
            supplierID = Convert.ToInt16(dgvFarmer.CurrentRow.Cells["colID"].Value);


            var a = posContext.FarmerInfoes.Single(c => c.ID == supplierID);

            txtcode.Text = a.Code;
            txtName.Text = a.FarmerName;

            txtMobileNo.Text = a.MobileNo;
            txtfathername.Text = a.FarmerName;
            txtMotherName.Text = a.MotherName;

            txtEmail.Text = a.Email;

            txtAddress.Text = a.Address;
            txtPostalCode.Text = a.PostalCode;
            cmbCountry.SelectedItem = a.CountryID;
            if (a.DistricID != null)
            { cmbDistrict.SelectedValue = a.DistricID; 
            }
            else
            {
                cmbDistrict.SelectedIndex = -1; 
            }
            if (a.ThanaID != null)
            {
                cmbThana.SelectedValue = a.ThanaID;
            }
            else
            {
                cmbThana.SelectedIndex = -1;
            }

            chkActive.Checked = Convert.ToBoolean(dgvFarmer.CurrentRow.Cells["colActive"].Value);

            btnDelete.Enabled = true;
        }

        private void dgvSuppliers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvFarmer.ClearSelection();
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDistrict.SelectedItem != null)
                {
                    using (var posContext = new Digital_AppEntities())
                    {
                        if (!string.IsNullOrEmpty(cmbDistrict.SelectedItem.ToString()))
                        {
                            List<THANAINFO> aTHANAINFO = posContext.THANAINFOes.Where(c => c.DISTRICT_ID == (int)cmbDistrict.SelectedValue).ToList();
                            DataTable dtTHANAINFO = Global.LINQToDataTable(aTHANAINFO);
                            cmbThana.DataSource = dtTHANAINFO;
                            cmbThana.DisplayMember = "THANA_NAME";
                            cmbThana.ValueMember = "ID";
                        }
                    }
                }
            }
            catch
            {

            }
                    
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                FarmerInfo aFarmerInfo;
               aFarmerInfo = posContext.FarmerInfoes.Single(c => c.ID == supplierID);

               posContext.FarmerInfoes.Remove(aFarmerInfo);
               posContext.SaveChanges();
               MessageBox.Show("Delete Successfully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
            }
            ClearControls();
            this.GenerateCode();
            txtName.Focus();
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}
