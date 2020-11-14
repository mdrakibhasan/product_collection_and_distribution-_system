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
    public partial class frmProductReceived : Form
    {
        public frmProductReceived()
        {
            InitializeComponent();
        }

        private void frmProductReceived_Load(object sender, EventArgs e)
        {
            Cleardata();
            CalculateTotal();
            
        }
        private void Cleardata()
        {
            using (var posContext = new Digital_AppEntities())
            {
                panel1.Visible = false;
                panel2.Visible = true;
                dgvItemPurchaseDetail.Rows.Clear();
                dgPurchaseInformation.Rows.Clear();
                txtCarriageCharg.Text = "0";
                txtLabureCharge.Text= "0";
                lblTotalData.Text = "0";

                foreach (View_ProductReceivedInformation aView_PurchaseInformation in posContext.View_ProductReceivedInformation.Where(a => a.Satatus != "R").ToList().OrderByDescending(a => a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, Convert.ToDateTime(aView_PurchaseInformation.PODate).ToString("dd/MM/yyyy"), aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total, aView_PurchaseInformation.Satt);
                }

            }
        }

        private void dgPurchaseInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (var posContext = new Digital_AppEntities())
                {

                    panel1.Visible = true;
                    panel2.Visible = false;
                    short itemPurchaseMstID = Convert.ToInt16(dgPurchaseInformation.Rows[e.RowIndex].Cells[0].Value);
                    int index = 0;
                    txtPoCode.Text = dgPurchaseInformation.Rows[e.RowIndex].Cells[2].Value.ToString();
                    dgvItemPurchaseDetail.Rows.Clear();
                    foreach (View_ReceivedDetails result in posContext.View_ReceivedDetails.Where(c => c.MstID == itemPurchaseMstID).ToList())
                    {
                        dgvItemPurchaseDetail.Rows.Add();
                        dgvItemPurchaseDetail.Rows[index].Cells["colID"].Value = result.ID;
                        dgvItemPurchaseDetail.Rows[index].Cells["colItemID"].Value = result.ProductID;
                        dgvItemPurchaseDetail.Rows[index].Cells["colItemCode"].Value = result.ItemCode;

                        //dgvItemPurchaseDetail.Rows[index].Cells["BatchNo"].Value = result.i;
                        dgvItemPurchaseDetail.Rows[index].Cells["colSalePrice"].Value = result.SalePrice;
                        dgvItemPurchaseDetail.Rows[index].Cells["colItemName"].Value = result.ItemName;
                        dgvItemPurchaseDetail.Rows[index].Cells["colItemPurchaseMstID"].Value = result.MstID;
                        dgvItemPurchaseDetail.Rows[index].Cells["colUnitPrice"].Value = result.UnitPrice;
                        dgvItemPurchaseDetail.Rows[index].Cells["colQuantity"].Value = result.Quantity;
                        dgvItemPurchaseDetail.Rows[index].Cells["colTotal"].Value = result.Total;
                        index++;
                    }
                    this.CalculateTotal();
                }
            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                ProductReceivedMst aProductReceivedMst;
                ItemPurchaseMst aItemPurchaseMst;
                if(dgvItemPurchaseDetail.Rows.Count>0)
                {
                    int mstID=Convert.ToInt32(dgvItemPurchaseDetail.Rows[0].Cells["colItemPurchaseMstID"].Value) ;
                    aProductReceivedMst = posContext.ProductReceivedMsts.SingleOrDefault(a => a.ID == mstID);
                    if(aProductReceivedMst!=null)
                    {
                        aItemPurchaseMst = posContext.ItemPurchaseMsts.SingleOrDefault(s => s.PO == txtPoCode.Text);
                        aItemPurchaseMst.Satatus = "R";
                        aProductReceivedMst.ReceivedAmount = Convert.ToDecimal(lblTotalData.Text);
                        aProductReceivedMst.LaberCost = Convert.ToDecimal(txtLabureCharge.Text);
                        aProductReceivedMst.ShippingCost = Convert.ToDecimal(txtCarriageCharg.Text);
                        aProductReceivedMst.ReguestStatus = "R";
                        aProductReceivedMst.CollectDate = dtpReceivedDate.Value;
                        aProductReceivedMst.UpdateBy = Global.UserLoginID;
                        aProductReceivedMst.UpdateDate = DateTime.Now;
                        posContext.SaveChanges();
                        foreach(ProductReceivedDtl aProductReceivedDtl in posContext.ProductReceivedDtls.Where(a=>a.MstID==aProductReceivedMst.ID).ToList())
                        {
                            aProductReceivedDtl.DeleteBy = Global.UserLoginID;
                            aProductReceivedMst.DeleteDate = DateTime.Now;
                            posContext.SaveChanges();

                        }
                        
                        foreach (DataGridViewRow dr in dgvItemPurchaseDetail.Rows)
                        {
                            ProductReceivedDtl aProductCollectedDtl;
                            int IDdt = Convert.ToInt32(dr.Cells["colID"].Value);
                            aProductCollectedDtl = posContext.ProductReceivedDtls.SingleOrDefault(a =>  a.ID == IDdt);
                         
                            aProductCollectedDtl.ReceivedQuantity = Convert.ToDecimal(dr.Cells["colQuantity"].Value);
                            aProductCollectedDtl.Total = Convert.ToDecimal(dr.Cells["colTotal"].Value);
                            aProductCollectedDtl.SalePrice = Convert.ToDecimal(dr.Cells["ColSalePrice"].Value);
                            aProductCollectedDtl.DeleteBy = null;
                            aProductCollectedDtl.DeleteDate = null;
                            posContext.SaveChanges();
                        }
                        PurchaseHistory aPurchaseHistory;
                        aPurchaseHistory = new PurchaseHistory();
                        aPurchaseHistory.PurchaseID = aItemPurchaseMst.ID;
                        aPurchaseHistory.StatusType = aItemPurchaseMst.Satatus;
                        aPurchaseHistory.AddDate = DateTime.Now;
                        aPurchaseHistory.AddBy = Global.UserLoginID;
                        aPurchaseHistory.StatusDescription = "Pdoduct Received";
                        posContext.PurchaseHistories.Add(aPurchaseHistory);
                        posContext.SaveChanges();
                       
                        MessageBox.Show("Update successfully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }

                    Cleardata();

                }
                else
                    {
                        MessageBox.Show("Please Select Item First", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

        }

     
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string date = Convert.ToDateTime(a.PODate);
            using (var posContext = new Digital_AppEntities())
            {
                dgPurchaseInformation.Rows.Clear();
                foreach (View_ProductReceivedInformation aView_PurchaseInformation in posContext.View_ProductReceivedInformation.Where(a => a.Satatus == "S" && a.PODate >= dttpFromDate.Value.Date && a.PODate <= dtpTodate.Value.Date).ToList().OrderByDescending(a => a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, Convert.ToDateTime(aView_PurchaseInformation.PODate).ToString("dd/MM/yyyy"), aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cleardata();
            CalculateTotal();
        }

        private void dgvItemPurchaseDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) // Total
            {
                //dgvItemPurchaseDetail.Rows[e.RowIndex].Cells["colTotal"].Value = Convert.ToDecimal(dgvItemPurchaseDetail.Rows[e.RowIndex].Cells["UnitPrice"].Value) * Convert.ToDecimal(dgvItemPurchaseDetail.Rows[e.RowIndex].Cells["UnitPrice"].Value);
                this.CalculateTotal();
            }
        }
      
        private void CalculateTotal()
        {
            lblTotalData.Text = dgvItemPurchaseDetail.Rows.Cast<DataGridViewRow>().Sum(r => Convert.ToDecimal(r.Cells["colTotal"].Value)).ToString();
           decimal TotalAmount = dgvItemPurchaseDetail.Rows.Cast<DataGridViewRow>().Sum(r => Convert.ToDecimal(r.Cells["colTotal"].Value));
        }

        private void dgvItemPurchaseDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            int column = dgvItemPurchaseDetail.CurrentCellAddress.X;
            if (column == 6 || column ==7)
            {
                Global.ValidateDecimalValue(sender, e);
                if (char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
                {
                    string newValue = Char.ToString(e.KeyChar);
                    //Get the column and row position of the selected cell

                    int row = dgvItemPurchaseDetail.CurrentCellAddress.Y;

                    //Gets the value that existings in that cell
                    string cellValue = dgvItemPurchaseDetail[column, row].EditedFormattedValue.ToString();


                    //combines current key press to the contents of the cell
                    if (char.IsNumber(e.KeyChar))
                        cellValue = cellValue + newValue;
                    else if (e.KeyChar == '\b' && cellValue.Length > 0)
                        cellValue = cellValue.Substring(0, cellValue.Length - 1);

                    if (column == 6) // Unit Price
                    {
                        decimal unitPrice = Convert.ToDecimal(cellValue == "" ? 0 : Convert.ToDecimal(cellValue));
                        if (dgvItemPurchaseDetail[column + 1, row].Value == null)
                            dgvItemPurchaseDetail[column + 1, row].Value = "0";
                        decimal quantity = dgvItemPurchaseDetail[column + 1, row].Value.ToString() == "0"
                            ? 0
                            : Convert.ToDecimal(dgvItemPurchaseDetail[column + 1, row].Value);
                        //dgvItemPurchaseDetail[column + 2, row].Value = Convert.ToDecimal(dgvItemPurchaseDetail[column + 1, row].Value) * unitPrice;
                        dgvItemPurchaseDetail[column + 2, row].Value = (quantity * unitPrice);
                    }
                    else if (column ==7) // Quantity
                    {
                        if (dgvItemPurchaseDetail[column - 1, row].Value == null)
                            dgvItemPurchaseDetail[column - 1, row].Value = "0";
                        decimal unitPrice = dgvItemPurchaseDetail[column - 1, row].Value.ToString() == "" ? 0 :
                            Convert.ToDecimal(dgvItemPurchaseDetail[column - 1, row].Value);

                        decimal quantity = Convert.ToDecimal(cellValue == "" ? "0" : cellValue);
                        //dgvItemPurchaseDetail[column + 1, row].Value = Convert.ToDecimal(dgvItemPurchaseDetail[column - 1, row].Value) * quantity;
                        dgvItemPurchaseDetail[column + 1, row].Value = (unitPrice * quantity);
                    }
                }
            }
        }

        private void dgvItemPurchaseDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                int column = dgvItemPurchaseDetail.CurrentCellAddress.X;
                int row = dgvItemPurchaseDetail.CurrentCellAddress.Y;
                dgvItemPurchaseDetail[column, row].Value = string.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgPurchaseInformation.Rows.Clear();
                foreach (View_ProductReceivedInformation aView_PurchaseInformation in posContext.View_ProductReceivedInformation.Where(a => a.Satatus == "S" && (a.PoCode + a.SupplierMobileNo + a.FarmerName + a.ChallanNo).Contains(textBox1.Text)).ToList().OrderByDescending(a => a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, Convert.ToDateTime(aView_PurchaseInformation.PODate).ToString("dd/MM/yyyy"), aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total);
                }

            }
        }

    }
}
