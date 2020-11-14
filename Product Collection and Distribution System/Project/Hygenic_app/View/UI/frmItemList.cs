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
    public partial class frmItemList : Form
    {


        private static frmItemList _frmItemList;

        public static frmItemList Instance
        {
            get
            {
                if (_frmItemList == null || _frmItemList.IsDisposed)
                    _frmItemList = new frmItemList();
                return _frmItemList;
            }
        }

        public string CallerForm
        {
            get;
            set;
        }
        public frmItemList()
        {
            InitializeComponent();
        }

        private void frmItemList_Load(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvItem.AutoGenerateColumns = false;
                //if (this.CallerForm != "frmOrder")
                //{

                dgvItem.Rows.Clear();
                if (this.CallerForm == "frmItemPurchase")
                {
                    foreach (var a in posContext.ItemInfoes)
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory.Name, a.Category.Name, a.Design, a.UOMID, a.UOM.Name, a.SalePrice, 0, a.ClosingStock);
                    }
                }
                else
                {
                    foreach (var a in posContext.ItemWithUOMs.Where(v => v.UnitsInStock >= 0))
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory, a.Category, a.Design, a.UOMID, a.UOMName, a.CostPrice, a.Discount, a.UnitsInStock);
                    }
                }

                //}
                //else
                //{
                //    dgvItem.DataSource = posContext.ItemFor_orders.Where(it => it.CompanyId == Global.Company.ID);
                //}
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvItem.Rows.Clear();
                if (this.CallerForm == "frmItemPurchase")
                {
                    foreach (var a in posContext.ItemInfoes.Where(s => (s.Code + s.Name + s.StyleNo).Contains(txtSearch.Text)))
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory.Name, a.Category.Name, a.Design, a.UOMID, a.UOM.Name, a.CostPrice,0, 0);
                    }
                }
                else
                {
                    foreach (var a in posContext.ItemWithUOMs.Where(s => (s.Code + s.Name + s.StyleNo).Contains(txtSearch.Text) && s.UnitsInStock>0))
                    {
                        dgvItem.Rows.Add(a.ID, a.Code, a.StyleNo, a.Name, a.SubCategory, a.Category, a.Design, a.UOMID, a.UOMName, a.CostPrice, a.Discount, a.UnitsInStock);
                    }
                }
            }


        }

        private void dgvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvItem.CurrentCell = null;
            dgvItem.ClearSelection();
        }
        private frmSalesDistribution _afrmOrderMultiple;
        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int totalRows, availableRecord;
            string searchValue;

            if (this.CallerForm == "frmItemPurchase")
            {
                totalRows = frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows.Count;
                availableRecord = 0;
                searchValue = dgvItem.CurrentRow.Cells["colName"].Value.ToString();

                if (totalRows > 0)
                {
                    availableRecord = frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows
                        .Cast<DataGridViewRow>()
                        .Count(r => r.Cells["colItemName"].Value.ToString().Equals(searchValue));
                }

                if (availableRecord == 0)
                {
                    int index = frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows.Count == 0 ? 0 : frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows.Count;

                    frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows.Add();
                    frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows[index].Cells["colItemID"].Value = dgvItem.CurrentRow.Cells["colID"].Value.ToString();
                    frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows[index].Cells["colItemCode"].Value = dgvItem.CurrentRow.Cells["colCode"].Value.ToString();
                    frmItemPurchase.Instance.dgvItemPurchaseDetail.Rows[index].Cells["colItemName"].Value = searchValue;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("This item already exists.", Application.ProductName);
                }
            }
            else if (CallerForm == "frmSalesDistribution")
            {



                ////////////////////////////////
                totalRows = frmSalesDistribution.Instance.dgvItemList.Rows.Count;
                availableRecord = 0;
                searchValue = "0";
                searchValue = dgvItem.CurrentRow.Cells["colCode"].Value.ToString();
                if (totalRows > 0)
                {
                    availableRecord = frmSalesDistribution.Instance.dgvItemList.Rows
                        .Cast<DataGridViewRow>()
                        .Count(r => r.Cells["colItemCode"].Value.ToString().Equals(searchValue));
                }

                if (availableRecord == 0)
                {
                    int index = frmSalesDistribution.Instance.dgvItemList.Rows.Count == 0 ? 0 : frmSalesDistribution.Instance.dgvItemList.Rows.Count;

                    if (Convert.ToDouble(dgvItem.CurrentRow.Cells["colUnitsInStock"].Value) <= 0)
                    {
                        MessageBox.Show("insufficient stock.\n Please check your stock.!!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    frmSalesDistribution.Instance.dgvItemList.Rows.Add();

                    decimal unitPrice = Convert.ToDecimal(dgvItem.CurrentRow.Cells["colUnitPrice"].Value),
                        taxRate = 0,
                        discountAmount = Convert.ToDecimal(dgvItem.CurrentRow.Cells["colDiscountAmount"].Value);



                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colItemID"].Value = dgvItem.CurrentRow.Cells["colID"].Value.ToString();
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colItemCode"].Value = dgvItem.CurrentRow.Cells["colCode"].Value.ToString();
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colItemName"].Value = dgvItem.CurrentRow.Cells["colName"].Value.ToString();
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colUOMID"].Value = dgvItem.CurrentRow.Cells["colUOMID"].Value.ToString();
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colUOM"].Value = dgvItem.CurrentRow.Cells["colUOM"].Value.ToString();
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colUnitPrice"].Value = unitPrice.ToString("N2");

                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colDiscountAmount"].Value = discountAmount.ToString("N2");
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colTaxRate"].Value = taxRate.ToString("N2");

                    //// If VAT TYPE OR DISCOUNT TYPE IS GLOBAL THEN THE SALE VALUE WILL BE NOT AFFECTED
                    //if (ConfigurationManager.AppSettings[MessageManager.VATTYPE].ToString() == MessageManager.VALUEGLOBAL)
                    //{
                    //    frmOrder.Instance.dgvItemList.Rows[index].Cells["colTaxRate"].Value = MessageManager.VATAMOUNT;
                    //    if (ConfigurationManager.AppSettings[MessageManager.DISCOUNTTYPE].ToString() == MessageManager.VALUEGLOBAL)
                    //    {
                    //        frmOrder.Instance.dgvItemList.Rows[index].Cells["colSalePrice"].Value = unitPrice;
                    //    }
                    //    else if (ConfigurationManager.AppSettings[MessageManager.DISCOUNTTYPE].ToString() != MessageManager.VALUEGLOBAL)
                    //    {
                    //        frmOrder.Instance.dgvItemList.Rows[index].Cells["colSalePrice"].Value = unitPrice - (unitPrice * (discountAmount / 100));
                    //    }
                    //}
                    //else if (ConfigurationManager.AppSettings[MessageManager.VATTYPE].ToString() != MessageManager.VALUEGLOBAL)
                    //{
                    //    frmOrder.Instance.dgvItemList.Rows[index].Cells["colTaxRate"].Value = taxRate.ToString();
                    //    if (ConfigurationManager.AppSettings[MessageManager.DISCOUNTTYPE].ToString() == MessageManager.VALUEGLOBAL)
                    //    {
                    //        frmOrder.Instance.dgvItemList.Rows[index].Cells["colSalePrice"].Value = (unitPrice + (unitPrice * (taxRate / 100)));
                    //    }
                    //    else if (ConfigurationManager.AppSettings[MessageManager.DISCOUNTTYPE].ToString() != MessageManager.VALUEGLOBAL)
                    //    {
                    //        frmOrder.Instance.dgvItemList.Rows[index].Cells["colSalePrice"].Value = (unitPrice + (unitPrice * (taxRate / 100))) - (unitPrice * (discountAmount / 100));
                    //    }
                    // }
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colSalePrice"].Value = unitPrice;
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colQuantity"].Value = "1";
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colTotalPrice"].Value = frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colSalePrice"].Value;
                    if (dgvItem.CurrentRow.Cells["colItemSize"].Value != null)
                    {
                        frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colItemSize"].Value =
                            dgvItem.CurrentRow.Cells["colItemSize"].Value.ToString();
                    }
                    else
                    {
                        frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colItemSize"].Value = "";
                    }

                    //frmOrder.Instance.dgvItemList.Rows[index].Cells["colItemColor"].Value = dgvItem.CurrentRow.Cells["colItemColor"].Value.ToString();
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colUnitsInStock"].Value = dgvItem.CurrentRow.Cells["colUnitsInStock"].Value.ToString();

                }
                else
                {
                    int index = frmSalesDistribution.Instance.dgvItemList.Rows
                        .Cast<DataGridViewRow>().Where(r => r.Cells["colItemCode"].Value.ToString().Equals(searchValue))
                        .First().Index;

                    if (Convert.ToDouble(frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colQuantity"].Value) >=Convert.ToDouble(dgvItem.CurrentRow.Cells["colUnitsInStock"].Value))
                    {
                        MessageBox.Show("insufficient stock.\n Please check your stock.!!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int newQuantity = Convert.ToInt32(frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colQuantity"].Value) + 1;
                    decimal salePrice = Convert.ToDecimal(frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colSalePrice"].Value);
                    decimal totalPrice = salePrice * newQuantity;

                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colQuantity"].Value = newQuantity.ToString();
                    frmSalesDistribution.Instance.dgvItemList.Rows[index].Cells["colTotalPrice"].Value = totalPrice;
                }
                frmSalesDistribution.Instance.dgvItemList.CurrentCell = null;
                frmSalesDistribution.Instance.Calculate(-1, 0, 0, 0);

                this.Close();
            }
        }
    }
}
