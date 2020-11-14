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
using View.UI;

namespace View
{
    public partial class frmItemInfo : Form
    {
        public frmItemInfo()
        {
            InitializeComponent();
        }
       
        int itemid;
        private void ClearControls()
        {
            var aDatabase_DB = new Digital_AppEntities();
            cmbCategory.SelectedValue = -1;
            cmbSubcategory.SelectedValue = -1;
            txtName.Text = "";
            List<UOM> auom = aDatabase_DB.UOMs.ToList();
            DataTable dtItemInfo = Global.LINQToDataTable(auom);
            cmbUom.DataSource = dtItemInfo;
            cmbUom.DisplayMember = "Name";
            cmbUom.ValueMember = "ID";
            itemid = 0;

            List<Category> aCategory = aDatabase_DB.Categories.ToList();
            DataTable dtCategory = Global.LINQToDataTable(aCategory);
            cmbCategory.DataSource = dtCategory;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "ID";
            txtsalesPrice.Text = "0";
            chkActive.Checked = true;
            dgvItem.Rows.Clear();
            foreach (ItemInfo aitem in aDatabase_DB.ItemInfoes.OrderByDescending(c => c.ID))
            {
                dgvItem.Rows.Add(aitem.ID, aitem.Name, aitem.Category.Name, aitem.SubCategory.Name, aitem.Active);

            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var aDatabase_DB = new Digital_AppEntities();
            
                if (cmbCategory.SelectedValue != null)
                {
                    List<SubCategory> aCategory = aDatabase_DB.SubCategories.Where(c => c.CategoryID == (int)cmbCategory.SelectedValue).ToList();
                    DataTable dtCategory = Global.LINQToDataTable(aCategory);
                    cmbSubcategory.DataSource = dtCategory;
                    cmbSubcategory.DisplayMember = "Name";
                    cmbSubcategory.ValueMember = "ID";
                }
                else
                {
                    cmbSubcategory.DataSource = null;
                }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var ADbContext = new Digital_AppEntities())
            {

                ItemInfo aItemInfo = ADbContext.ItemInfoes.SingleOrDefault(c => c.ID == itemid);
                if (aItemInfo == null)
                {

                      aItemInfo = new ItemInfo();

                    aItemInfo.Name = txtName.Text;
                    if (cmbCategory.SelectedValue != null)
                    {
                        aItemInfo.CategoryId = (int)cmbCategory.SelectedValue;
                    }
                    if (cmbSubcategory.SelectedValue != null)
                    {
                        aItemInfo.SubcategoryID = (int)cmbSubcategory.SelectedValue;
                    }
                    if (cmbUom.SelectedValue != null)
                    {
                        aItemInfo.UOMID = (int)cmbUom.SelectedValue;
                    }
                    try
                    {
                        var Code = ADbContext.ItemInfoes.OrderByDescending(id => id.ID).Take(1).Single();
                        if (Code != null)
                        {
                            aItemInfo.StyleNo = Code.ID + 1.ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            aItemInfo.StyleNo = "1".PadLeft(4, '0');
                        }
                    }
                    catch
                    {
                        aItemInfo.StyleNo = "1".PadLeft(4, '0');
                    }

                    aItemInfo.Code = aItemInfo.StyleNo;
                    aItemInfo.Active = chkActive.Checked;
                    aItemInfo.SalePrice = Convert.ToDecimal(txtsalesPrice.Text);
                    ADbContext.ItemInfoes.Add(aItemInfo);
                    ADbContext.SaveChanges();
                    MessageBox.Show("Save Succesfully", "Success", MessageBoxButtons.OK);
                    this.ClearControls();
                }
                else
                {


                   
                    aItemInfo.Name = txtName.Text;
                    if (cmbCategory.SelectedValue != null)
                    {
                        aItemInfo.CategoryId = (int)cmbCategory.SelectedValue;
                    }
                    if (cmbSubcategory.SelectedValue != null)
                    {
                        aItemInfo.SubcategoryID = (int)cmbSubcategory.SelectedValue;
                    }
                    if (cmbUom.SelectedValue != null)
                    {
                        aItemInfo.UOMID = (int)cmbUom.SelectedValue;
                    }


                    aItemInfo.Active = chkActive.Checked;                    
                    ADbContext.SaveChanges();
                    MessageBox.Show("Update Succesfully", "Success", MessageBoxButtons.OK);
                    this.ClearControls();

                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
                this.ClearControls();
               
            
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             using(var aDatabase_DB = new Digital_AppEntities())
            {
                itemid = (int)dgvItem.CurrentRow.Cells[0].Value;
                ItemInfo aItemInfo = aDatabase_DB.ItemInfoes.SingleOrDefault(c => c.ID == itemid);
                txtID.Text = aItemInfo.ID.ToString();
                txtName.Text = aItemInfo.Name;
                cmbCategory.SelectedValue = aItemInfo.CategoryId;
                cmbSubcategory.SelectedValue = aItemInfo.SubcategoryID;
                cmbUom.SelectedValue = aItemInfo.UOMID;
                txtsalesPrice.Text = aItemInfo.SalePrice.ToString();
                chkActive.Checked = (bool)aItemInfo.Active;

            }
        }

        private void txtsalesPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

       
    }
}
