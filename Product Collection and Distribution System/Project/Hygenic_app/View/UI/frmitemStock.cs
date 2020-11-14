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

namespace View.UI
{
    public partial class frmitemStock : Form
    {
        public frmitemStock()
        {
            InitializeComponent();
        }

        private void frmitemStock_Load(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvItem.AutoGenerateColumns = false;
                //if (this.CallerForm != "frmOrder")
                //{

                dgvItem.Rows.Clear();
                if (this.CallerForm == "frmItemPurchase")
                {
                    foreach (var a in posContext.ItemWithUOMs)
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory, a.Category, a.Design, a.UOMID, a.UOMName, a.CostPrice,a.SalePrice, a.UnitsInStock);
                    }
                }
                else
                {
                    foreach (var a in posContext.ItemWithUOMs.Where(v => v.UnitsInStock > 0))
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory, a.Category, a.Design, a.UOMID, a.UOMName,a.CostPrice, a.SalePrice, a.UnitsInStock);
                    }
                }

                //}
                //else
                //{
                //    dgvItem.DataSource = posContext.ItemFor_orders.Where(it => it.CompanyId == Global.Company.ID);
                //}
            }
        }

        public string CallerForm { get; set; }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvItem.Rows.Clear();
                if (this.CallerForm == "frmItemPurchase")
                {
                    foreach (var a in posContext.ItemWithUOMs.Where(s => (s.Code + s.Name + s.StyleNo).Contains(txtSearch.Text)))
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory, a.Category, a.Design, a.UOMID, a.UOMName, a.CostPrice,  a.UnitsInStock);
                    }
                }
                else
                {
                    foreach (var a in posContext.ItemWithUOMs.Where(s => (s.Code + s.Name + s.StyleNo).Contains(txtSearch.Text) && s.UnitsInStock > 0))
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory, a.Category, a.Design, a.UOMID, a.UOMName, a.CostPrice,  a.UnitsInStock);
                    }
                }
            }
        }
    }
}
