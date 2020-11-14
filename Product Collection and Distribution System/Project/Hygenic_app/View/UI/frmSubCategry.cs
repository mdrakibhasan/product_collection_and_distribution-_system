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
    public partial class frmSubCategry : Form
    {
        public frmSubCategry()
        {
            InitializeComponent();
        }

        private void frmSubCategry_Load(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                //cmbCategory.DataSource = posContext.Categories.Where(id => id.Active == true); ;
               // cmbCategory.SelectedIndex = -1;
                List<Category> auom = posContext.Categories.ToList();
                DataTable dtItemInfo = Global.LINQToDataTable(auom);
                cmbCategory.DataSource = dtItemInfo;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "ID";

                cmbCategorySearch.DataSource = dtItemInfo;
                cmbCategorySearch.DisplayMember = "Name";
                cmbCategorySearch.ValueMember = "ID";

                //cmbCategorySearch.DataSource = posContext.Categories.Where(id => id.Active == true); ;
                //cmbCategorySearch.SelectedIndex = -1;
                txtCode.Text = string.Empty;
                dgvSubCategory.AutoGenerateColumns = false;
                dgvSubCategory.Rows.Clear();

                foreach (var subCategory in posContext.SubCategories.OrderByDescending(id => id.ID))
                {
                    dgvSubCategory.Rows.Add(subCategory.ID, subCategory.Code, subCategory.Name, subCategory.Description, subCategory.CategoryID, subCategory.Category.Name, subCategory.Active);

                }
            }
        }

        #region Private Member Variables

        private short subCategoryID;
        private bool isRecordSaved = false;
        private static frmSubCategry _frmSubCategory;

        #endregion

        #region Private Methods

        private void ClearControls()
        {
            subCategoryID = 0;

            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkActive.Checked = true;

            if (isRecordSaved)
            {
                this.GenerateCode();
            }
            else
            {
                cmbCategory.SelectedIndex = -1;
                txtCode.Text = string.Empty;

                if (dgvSubCategory.Rows.Count > 0)
                {
                    dgvSubCategory.ClearSelection();
                }
            }
            txtName.Focus();
        }
        
        private void GenerateCode()
        {
            using (var posContext = new Digital_AppEntities())
            {
                short categoryID = Convert.ToInt16(cmbCategory.SelectedValue);
                var subCategories = posContext.SubCategories.Where(id => id.CategoryID == categoryID);
                if (subCategories.Count() == 0)
                    txtCode.Text = "1".PadLeft(3, '0');
                else
                {
                    SubCategory subCategory = subCategories.OrderByDescending(id => id.ID).Take(1).Single();
                    txtCode.Text = (Convert.ToInt16(subCategory.Code) + 1).ToString().PadLeft(3, '0');
                }
            }
        }
        
        private short SelectCategory()
        {
            short categoryID;
            if (cmbCategorySearch.SelectedIndex != -1)
            {
                categoryID = Convert.ToInt16(cmbCategorySearch.SelectedValue);
            }
            else
            {
                categoryID = 0;
            }
            return categoryID;
        }

        private void LoadSubCategoriesByCategoryID(short categoryID)
        {
            using (var posContext = new Digital_AppEntities())
            {
                var subCategories = posContext.SubCategories.Where(id => id.CategoryID == categoryID);
                if (txtKeyword.Text != string.Empty)
                {
                    string keyword = txtKeyword.Text.Trim();
                    subCategories = posContext.SubCategories.Where(id => id.CategoryID == categoryID &&
                        (id.Code + id.Name).Contains(keyword));

                }
                dgvSubCategory.AutoGenerateColumns = false;
                dgvSubCategory.Rows.Clear();
                foreach (var subCategory in subCategories.OrderByDescending(id => id.ID))
                {
                    dgvSubCategory.Rows.Add(subCategory.ID, subCategory.Code, subCategory.Name, subCategory.Description, subCategory.CategoryID, subCategory.Category.Name, subCategory.Active);

                }
            }
        }

        #endregion

        private void frmSubCategory_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            EnableButton();
        }

        private void EnableButton()
        {
            if (txtName.Text.Length > 0 && cmbCategory.SelectedIndex != -1)
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

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != -1)
            {
                if (subCategoryID == 0)
                {
                    this.GenerateCode();
                }
                cmbCategorySearch.SelectedValue = cmbCategory.SelectedValue;
            }
            EnableButton();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (cmbCategory.SelectedIndex == -1)
            //    MessageBox.Show(MessageManager.CategoryRequired, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else
            //{
                try
                {
                    using (var posContext = new Digital_AppEntities())
                    {
                        string name = txtName.Text.Trim();
                        short categoryID = Convert.ToInt16(cmbCategory.SelectedValue);
                        var existingSubCategory = posContext.SubCategories.FirstOrDefault(id => id.Name == name && id.CategoryID == categoryID);
                        
                        if (existingSubCategory != null)
                        {
                            if(existingSubCategory.ID == subCategoryID)
                                this.ManageSubCategory(posContext, categoryID);
                            else
                                MessageBox.Show(MessageManager.GetDuplicateErrorMsg(this.Text.ToLower()), Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            ManageSubCategory(posContext, categoryID);
                        }
                    }
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
            //}
        }

        private void ManageSubCategory(Digital_AppEntities posContext, short categoryID)
        {
            SubCategory subCategory;
            if (subCategoryID == 0)
            {
                subCategory = new SubCategory();
                subCategory.Code = txtCode.Text;
                subCategory.Name = txtName.Text;
                subCategory.Description = txtDescription.Text;
                subCategory.CategoryID = categoryID;
                subCategory.Active = chkActive.Checked;
               // subCategory.CreatedBy = Global.LoggedInUser.ID;
                subCategory.CreatedDate = DateTime.Now;
                posContext.SubCategories.Add(subCategory);
            }
            else
            {
                subCategory = posContext.SubCategories.Single(id => id.ID == subCategoryID);
                subCategory.Name = txtName.Text;
                subCategory.Description = txtDescription.Text;
                subCategory.CategoryID = categoryID;
                subCategory.Active = chkActive.Checked;
               // subCategory.ModifiedBy = Global.LoggedInUser.ID;
                subCategory.ModifiedDate = DateTime.Now;
            }
            posContext.SaveChanges();
            isRecordSaved = true;
            ClearControls();
            this.LoadSubCategoriesByCategoryID(categoryID);
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

        private void cmbCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            short categoryID = SelectCategory();
            LoadSubCategoriesByCategoryID(categoryID);
            txtKeyword.Focus();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            short categoryID = SelectCategory();
            LoadSubCategoriesByCategoryID(categoryID);
        }

        private void dgvSubCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            subCategoryID = Convert.ToInt16(dgvSubCategory.CurrentRow.Cells["dgvID"].Value);
            txtCode.Text = dgvSubCategory.CurrentRow.Cells["dgvCode"].Value.ToString();
            txtName.Text = dgvSubCategory.CurrentRow.Cells["dgvName"].Value.ToString();
            txtDescription.Text = dgvSubCategory.CurrentRow.Cells["dgvDescription"].Value.ToString();
            cmbCategory.SelectedValue = Convert.ToInt16(dgvSubCategory.CurrentRow.Cells["dgvCategoryID"].Value);
            chkActive.Checked = Convert.ToBoolean(dgvSubCategory.CurrentRow.Cells["dgvActive"].Value);
        }

        private void dgvSubCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSubCategory.ClearSelection();
        }
    }
}
