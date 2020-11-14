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
    public partial class frmCategory : Form
    {

        private short categoryID;
        private static frmCategory _frmCategory;
        public frmCategory()
        {
            InitializeComponent();
        }
       

        private void ClearControls()
        {
            categoryID = 0;
            using (var posContext = new Digital_AppEntities())
            {
                var categories = posContext.Categories;
                if (categories.Count() == 0)
                    txtCode.Text = "1".PadLeft(3, '0');
                else
                {
                    Category category = categories.OrderByDescending(id => id.ID).Take(1).Single();
                    txtCode.Text = (Convert.ToInt16(category.Code) + 1).ToString().PadLeft(3, '0');
                }
                dgvCategory.Rows.Clear();
            dgvCategory.AutoGenerateColumns = false;
            foreach (Category actegory in posContext.Categories.OrderByDescending(id => id.ID))
            {
                dgvCategory.Rows.Add(actegory.ID, actegory.Code, actegory.Name, actegory.Description, actegory.Active);
            }
            
            }
           

            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkActive.Checked = true;
            txtName.Focus();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                var categories = posContext.Categories;
                if (categories.Count() == 0)
                    txtCode.Text = "1".PadLeft(3, '0');
                else
                {
                    Category category = categories.OrderByDescending(id => id.ID).Take(1).Single();
                    txtCode.Text = (Convert.ToInt16(category.ID) + 1).ToString().PadLeft(3, '0');
                }
              
            }
            ClearControls();
        }

        private void dgvCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCategory.ClearSelection();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                categoryID = Convert.ToInt16(dgvCategory.CurrentRow.Cells["colID"].Value);
                txtCode.Text = dgvCategory.CurrentRow.Cells["colCode"].Value.ToString();
                txtName.Text = dgvCategory.CurrentRow.Cells["colName"].Value.ToString();
                txtDescription.Text = dgvCategory.CurrentRow.Cells["colDescription"].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dgvCategory.CurrentRow.Cells["colActive"].Value);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var posContext = new Digital_AppEntities();
                {
                    Category category;
                    if (categoryID == 0)
                    {
                        if (CheckInput())
                            return;
                        category = new Category();
                        category.Code = txtCode.Text;
                        category.Name = txtName.Text;
                        category.Description = txtDescription.Text.Trim();
                        category.Active = chkActive.Checked;
                      //  category.CreatedBy = (short)Global.LoggedInUser.ID;
                        category.CreatedDate = DateTime.Now;
                        posContext.Categories.Add(category);
                    }
                    else
                    {
                        category = posContext.Categories.Single(id => id.ID == categoryID);
                        category.Name = txtName.Text;
                        category.Description = txtDescription.Text.Trim();
                        category.Active = chkActive.Checked;
                       // category.ModifiedBy = Global.LoggedInUser.ID;
                        category.ModifiedDate = DateTime.Now;
                    }
                    posContext.SaveChanges();
                   // dgvCategory.DataSource = posContext.Categories.OrderByDescending(id => id.ID);
                }
                this.ClearControls();
            }
            catch (Exception ex)
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
                    MessageBox.Show(MessageManager.CommonExceptionMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearControls();
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

        public bool CheckInput()
        {
            var posContext = new Digital_AppEntities();

            string name = txtName.Text;
            var searchData = posContext.Categories.ToList();
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
