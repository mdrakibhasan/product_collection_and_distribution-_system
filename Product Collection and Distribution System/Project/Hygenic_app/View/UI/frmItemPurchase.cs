using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UYSYS.POS.App_Code;
using View.DataModel;
using View.DBManager;

namespace View.UI
{
    public partial class frmItemPurchase : Form
    {

        public static frmItemPurchase Instance
        {
            get
            {
                if (_frmItemPurchase == null || _frmItemPurchase.IsDisposed)
                    _frmItemPurchase = new frmItemPurchase();
                return _frmItemPurchase;
            }
        }

        #region Private Member Variables


        private static frmItemPurchase _frmItemPurchase;
        private short itemPurchaseMstID, totalRows, pageSize, SupplierID;
        private decimal pageCount, currentPage, TotalAmount, Discount;

        #endregion

        #region Private Methods

        private void GenerateCode(Digital_AppEntities posContext)
        {
            var purchaseTransactions = posContext.ItemPurchaseMsts;
            if (purchaseTransactions.Count() == 0)
            {
                txtGRNO.Text = "GRN-" + DateTime.Now.Year.ToString() + "-" + "1".PadLeft(6, '0');
            }
            else
            {
                ItemPurchaseMst itemPurchaseMst = purchaseTransactions.OrderByDescending(id => id.ID).Take(1).Single();
                if (itemPurchaseMst.CreatedDate.Value.Year == DateTime.Now.Year)
                {
                    var a = Convert.ToInt16(itemPurchaseMst.GRN.Replace("GRN-" + DateTime.Now.Year.ToString() + "-", ""));
                    txtGRNO.Text = "GRN-" + DateTime.Now.Year.ToString() + "-" + (Convert.ToInt16(itemPurchaseMst.GRN.Replace("GRN-" + DateTime.Now.Year.ToString() + "-", "")) + 1).ToString().PadLeft(6, '0');
                }
                else
                {
                    txtGRNO.Text = "GRN-" + DateTime.Now.Year.ToString() + "-" + "1".PadLeft(6, '0');
                }
            }
            txtPO.Text = txtGRNO.Text.Replace("GRN-", "PO-");
        }

        private void ClearForm()
        {
            this.itemPurchaseMstID = 0;
            this.txtGRNO.Text = string.Empty;
            this.txtPO.Text = string.Empty;
            this.txtChallanNo.Text = string.Empty;

            this.dtpGRNODate.Value = DateTime.Now;
           // this.dtpPODate.Value = DateTime.Now;
            //this.dtpChallanDate.Value = DateTime.Now;

            this.txtRemarks.Text =txtMobileNo.Text= string.Empty;
            this.cmbSupplier.SelectedIndex = -1;
           // this.cmbCurrency.SelectedItem = "Peso";
            this.lblTotalData.Text = "0";
            this.txtDiscount.Text = "0";
            this.txtCarriageCharg.Text = "0";
            this.txtLabureCharge.Text = "0";
            //this.txtTotalPayable.Text = "0";
            //this.txtDueAmount.Text = "0";
            this.dgvItemPurchaseDetail.Rows.Clear();

            using (var posContext = new Digital_AppEntities())
            {
                this.GenerateCode(posContext);
            }
            dtpGRNODate.Value = DateTime.Now;
            //dtpPODate.Value = DateTime.Now;
           // dtpChallanDate.Value = DateTime.Now;
            this.btnSave.Enabled = true;
            txtPO.Focus();
        }

        private void SetRecordLabel()
        {
            pageCount = Math.Ceiling(Convert.ToDecimal(totalRows) / Convert.ToDecimal(this.pageSize));

            int startRecord = Convert.ToInt32(dgvItemPurchaseMst.Rows.Count > 0 ? dgvItemPurchaseMst.Rows[0].Cells["dgvRowNum"].Value : 0);
            int endRecord = Convert.ToInt32(dgvItemPurchaseMst.Rows.Count > 0 ? dgvItemPurchaseMst.Rows[this.pageSize == dgvItemPurchaseMst.Rows.Count ? this.pageSize - 1 : dgvItemPurchaseMst.Rows.Count - 1].Cells["dgvRowNum"].Value : 0);

            this.lblRecordLabel.Text = startRecord + " to " + endRecord + " out of " + totalRows.ToString() + " records";

            lblStatus.Text = this.currentPage + "/" + this.pageCount;
        }

        private void LoadItemPurchaseList()
        {
            using (var posContext = new Digital_AppEntities())
            {
                this.dgvItemPurchaseMst.AutoGenerateColumns = false;
                dgvItemPurchaseMst.Rows.Clear();
                foreach (var a in posContext.View_GetItemPurchaseMst.Where(s => s.Keyword.Contains(txtSearch.Text) && s.CreatedBy == Global.UserLoginID))
                {
                  //  this.dgvItemPurchaseMst.DataSource = posContext.GetItemPurchaseMst(pageSize, Convert.ToInt16(this.currentPage), "AV", txtSearch.Text);
                    dgvItemPurchaseMst.Rows.Add(a.ID,a.GRN,a.ReceivedDate,a.PO,a.PODate,a.ChallanNo,a.ChallanDate,a.SupplierID,a.SupplierName,a.Total,a.Currency,a.Remarks,a.RowNum,a.TotalRows,a.discount,a.SupplierMobileNo,a.labure_charge);
                }
                if (this.dgvItemPurchaseMst.Rows.Count > 0)
                    this.totalRows = Convert.ToInt16(this.dgvItemPurchaseMst.Rows[0].Cells["dgvTotalRows"].Value);
                else
                   this.totalRows = 0;
                this.SetRecordLabel();
            }
        }

        private void CalculateTotal()
        {
            lblTotalData.Text = dgvItemPurchaseDetail.Rows.Cast<DataGridViewRow>().Sum(r => Convert.ToDecimal(r.Cells["colTotal"].Value)).ToString();
            TotalAmount = dgvItemPurchaseDetail.Rows.Cast<DataGridViewRow>().Sum(r => Convert.ToDecimal(r.Cells["colTotal"].Value));
        }

        #endregion


       
        public frmItemPurchase()
        {
            InitializeComponent();
        }

       
        private void frmItemPurchase_Load(object sender, EventArgs e)
        {
            bool Act = true;
            using (var posContext = new Digital_AppEntities())
            {
                List<FarmerInfo> aFarmerInfo = posContext.FarmerInfoes.ToList();
                DataTable dtFarmerInfo = Global.LINQToDataTable(aFarmerInfo);
                cmbSupplier.DataSource = dtFarmerInfo;
                cmbSupplier.DisplayMember = "FarmerName";
                cmbSupplier.ValueMember = "ID";
                cmbSupplier.SelectedIndex = -1;
                this.ClearForm();
            }
            this.btnSave.Enabled = true;
            btnCancel.Enabled = true;
            this.cmbPageSize.SelectedIndex = 0;

            this.pageSize = Convert.ToInt16(this.cmbPageSize.SelectedItem);
            this.currentPage = 1;
        }
         private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvItemPurchaseDetail.Rows.Count <= 0)
            {
                MessageBox.Show("Please Iput Purchase Item..!!", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }
                ItemPurchaseMst itemPurchaseMst;

                using (var posContext = new Digital_AppEntities())
                {
                    if (itemPurchaseMstID == 0)
                    {
                        itemPurchaseMst = new ItemPurchaseMst();
                        itemPurchaseMst.GRN = txtGRNO.Text;
                        itemPurchaseMst.ReceivedDate = Convert.ToDateTime(dtpGRNODate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                        itemPurchaseMst.PO = txtPO.Text;
                        itemPurchaseMst.PODate = Convert.ToDateTime(dtpGRNODate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                        itemPurchaseMst.ChallanNo = txtChallanNo.Text;
                        itemPurchaseMst.ChallanDate = Convert.ToDateTime(dtpGRNODate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                        if (cmbSupplier.SelectedValue != null)
                        {
                            itemPurchaseMst.SupplierID = Convert.ToInt16(cmbSupplier.SelectedValue);
                        }
                        itemPurchaseMst.Currency = "BD";
                        itemPurchaseMst.Total = Convert.ToDecimal(lblTotalData.Text);
                        itemPurchaseMst.Remarks = txtRemarks.Text;
                        itemPurchaseMst.CreatedBy = Global.LoggedInUser.ID;
                        itemPurchaseMst.CreatedDate = DateTime.Now;
                        itemPurchaseMst.discount = Convert.ToDecimal(txtDiscount.Text);
                        itemPurchaseMst.carriage_charge = Convert.ToDecimal(txtCarriageCharg.Text);
                        itemPurchaseMst.labure_charge = Convert.ToDecimal(txtLabureCharge.Text);
                        itemPurchaseMst.SupplierMobileNo = txtMobileNo.Text;

                        posContext.ItemPurchaseMsts.Add(itemPurchaseMst);

                        posContext.SaveChanges();

                        int id = itemPurchaseMst.ID;

                        itemPurchaseMstID = Convert.ToInt16(itemPurchaseMst.ID);
                        SupplierID = Convert.ToInt16(cmbSupplier.SelectedValue);
                        TotalAmount = Convert.ToDecimal(lblTotalData.Text);
                        Discount = Convert.ToDecimal(txtDiscount.Text);

                        ItemPurchaseDtl itemPurchaseDtl;
                        decimal totqty = 0;
                        foreach (DataGridViewRow row in dgvItemPurchaseDetail.Rows)
                        {
                            itemPurchaseDtl = new ItemPurchaseDtl();
                            itemPurchaseDtl.ItemPurchaseMstID = id;
                            itemPurchaseDtl.ItemID = Convert.ToInt32(row.Cells["colItemID"].Value);
                            //itemPurchaseDtl.BatchNo = (row.Cells["BatchNo"].Value).ToString();
                            itemPurchaseDtl.BatchNo = "0";
                            itemPurchaseDtl.ExpireDate = Convert.ToDateTime(row.Cells["ColExpireDate"].Value);
                            itemPurchaseDtl.UnitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                            itemPurchaseDtl.Quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                            itemPurchaseDtl.ReturnQuantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                            itemPurchaseDtl.Total = Convert.ToDecimal(row.Cells["colTotal"].Value);
                            totqty += Convert.ToDecimal(itemPurchaseDtl.Quantity);
                            posContext.ItemPurchaseDtls.Add(itemPurchaseDtl);

                        }
                        posContext.SaveChanges();

                        try
                        {
                            if (chkSentSMS.Checked)
                            {
                                if (!string.IsNullOrEmpty(txtMobileNo.Text) && txtMobileNo.Text.Length > 10)
                                {
                                    string Year = DateTime.Now.Year.ToString("");
                                    string TotalAmount2 = (itemPurchaseMst.Total * 1 + 0).ToString().Replace(" ", "").Replace(",", "");
                                    string Invoice = "Dear Sir/Madam " + cmbSupplier.Text + ", Your Receipt No:" + itemPurchaseMst.PO + " Quantity :" + totqty.ToString() + " Amount :" + TotalAmount2 + " Thank's you for with us. For any query:01996513255";
                                  //  string Text = "Dear Sir/Madam,Thanks for shopping with Dorjibari.Invoice:" + invoiceNumber.Replace("INV-" + Year + "-", "") + ", Qty:" + totalSaleQuantity.ToString() + ",Amt:" + TotalAmount + ", Visit our online shop www.dorjibari.com.bd, For any query:01708449690";
                                    int ln = (int)Text.Length;
                                    DialogResult values1 = MessageBox.Show("Are you want To Sent SMS!!", "",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    SMSGEtwayCode aSMSGEtwayCode = new SMSGEtwayCode();
                                    if (values1.ToString() == "Yes")
                                    {
                                        aSMSGEtwayCode.SampleTestHttpApi(txtMobileNo.Text, Invoice, "userName", "Password");
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }
                        MessageBox.Show("Save SuccessFully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                        //var categoryid = (from cats in posContext.ItemPurchaseMsts.LastOrDefaul() select cats.id).SingleOrDefault(); 
                    }
                    else
                    {
                        itemPurchaseMst = posContext.ItemPurchaseMsts.Single(s => s.ID == itemPurchaseMstID);
                        itemPurchaseMst.GRN = txtGRNO.Text;
                        itemPurchaseMst.ReceivedDate = Convert.ToDateTime(dtpGRNODate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                        itemPurchaseMst.PO = txtPO.Text;
                        itemPurchaseMst.PODate = Convert.ToDateTime(dtpGRNODate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                        itemPurchaseMst.ChallanNo = txtChallanNo.Text;
                        itemPurchaseMst.ChallanDate = Convert.ToDateTime(dtpGRNODate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                        if (cmbSupplier.SelectedValue != null)
                        {
                            itemPurchaseMst.SupplierID = Convert.ToInt16(cmbSupplier.SelectedValue);
                        }
                        itemPurchaseMst.Currency = "BD";
                        itemPurchaseMst.Total = Convert.ToDecimal(lblTotalData.Text);
                        itemPurchaseMst.Remarks = txtRemarks.Text;
                        itemPurchaseMst.ModifiedBy = Global.LoggedInUser.ID;
                        itemPurchaseMst.ModifiedDate = DateTime.Now;
                        itemPurchaseMst.discount = Convert.ToDecimal(txtDiscount.Text);
                        itemPurchaseMst.carriage_charge = Convert.ToDecimal(txtCarriageCharg.Text);
                        itemPurchaseMst.labure_charge = Convert.ToDecimal(txtLabureCharge.Text);
                        itemPurchaseMst.SupplierMobileNo = txtMobileNo.Text;
                        posContext.SaveChanges();

                        int id = itemPurchaseMst.ID;

                        foreach (ItemPurchaseDtl item in posContext.ItemPurchaseMsts.Single(s => s.ID == itemPurchaseMstID).ItemPurchaseDtls.ToList())
                        {
                            posContext.ItemPurchaseDtls.Remove(item);
                        }
                        posContext.SaveChanges();
                        ItemPurchaseDtl itemPurchaseDtl;

                        foreach (DataGridViewRow row in dgvItemPurchaseDetail.Rows)
                        {
                            itemPurchaseDtl = new ItemPurchaseDtl();
                            itemPurchaseDtl.ItemPurchaseMstID = id;
                            itemPurchaseDtl.ItemID = Convert.ToInt32(row.Cells["colItemID"].Value);
                            itemPurchaseDtl.BatchNo = "0";
                                //(row.Cells["BatchNo"].Value).ToString();
                            itemPurchaseDtl.ExpireDate = Convert.ToDateTime(row.Cells["ColExpireDate"].Value);
                            itemPurchaseDtl.UnitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                            itemPurchaseDtl.Quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                            itemPurchaseDtl.ReturnQuantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                            itemPurchaseDtl.Total = Convert.ToDecimal(row.Cells["colTotal"].Value);
                            posContext.ItemPurchaseDtls.Add(itemPurchaseDtl);
                        }
                        posContext.SaveChanges();
                        MessageBox.Show("Update Successfully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                    }
                   // this.ClearForm();
                    this.btnSave.Enabled = false;
                }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void dgvItemPurchaseDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            int column = dgvItemPurchaseDetail.CurrentCellAddress.X;
            if (column == 6 || column == 7)
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
                        dgvItemPurchaseDetail[column + 2, row].Value = (quantity*unitPrice);
                    }
                    else if (column == 7) // Quantity
                    {
                        if (dgvItemPurchaseDetail[column - 1, row].Value == null)
                            dgvItemPurchaseDetail[column - 1, row].Value = "0";
                        decimal unitPrice = dgvItemPurchaseDetail[column - 1, row].Value.ToString() == "0"? 0: 
                            Convert.ToDecimal(dgvItemPurchaseDetail[column - 1, row].Value);

                        decimal quantity = Convert.ToDecimal(cellValue == "" ? "0" : cellValue);
                        //dgvItemPurchaseDetail[column + 1, row].Value = Convert.ToDecimal(dgvItemPurchaseDetail[column - 1, row].Value) * quantity;
                        dgvItemPurchaseDetail[column + 1, row].Value = (unitPrice*quantity);
                    }
                }
            }
        }

        private void dgvItemPurchaseDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                if (MessageBox.Show(MessageManager.RecordDeleteConfirmationMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvItemPurchaseDetail.Rows.RemoveAt(e.RowIndex);
                    this.CalculateTotal();
                }
            }
        }

        private void dgvItemPurchaseDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) // Total
            {
                this.CalculateTotal();
            }
        }

        private void tcItemPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcItemPurchase.SelectedIndex == 1)
            {
                this.currentPage = 1;
                LoadItemPurchaseList();                
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                if (this.currentPage == this.pageCount)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
            }
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.currentPage = 1;
            this.LoadItemPurchaseList();
            this.btnFirst.Enabled = false;
            this.btnPrevious.Enabled = false;
            this.btnLast.Enabled = true;
            this.btnNext.Enabled = true;
            if (this.currentPage == pageCount) 
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcItemPurchase.SelectedIndex == 1)
            {
                this.pageSize = Convert.ToInt16(this.cmbPageSize.SelectedItem);
                this.currentPage = 1;
                this.LoadItemPurchaseList();
                
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnLast.Enabled = true;
                this.btnNext.Enabled = true;
                if (this.currentPage == pageCount) 
                {
                    this.btnLast.Enabled = false;
                    this.btnNext.Enabled = false;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPage < this.pageCount)
                this.currentPage = this.currentPage + 1;
            this.LoadItemPurchaseList();

            if (this.currentPage == this.pageCount)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            btnPrevious.Enabled = true;
            btnFirst.Enabled = true;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.currentPage = this.pageCount;
            this.LoadItemPurchaseList();
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnPrevious.Enabled = true;
            btnFirst.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.currentPage > 1)
                this.currentPage = this.currentPage - 1;
            this.LoadItemPurchaseList();

            if (this.currentPage == 1)
            {
                btnPrevious.Enabled = false;
                btnFirst.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
            }
            btnNext.Enabled = true;
            btnLast.Enabled = true;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.currentPage = 1;

            this.LoadItemPurchaseList();

            btnPrevious.Enabled = false;
            btnFirst.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
        }

        private void dgvItemPurchaseMst_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {

               // ItemPurchaseMst aItemPurchaseMst = posContext.ItemPurchaseMsts.SingleOrDefault(s => s.ID == Convert.ToInt32(dgvItemPurchaseMst.CurrentRow.Cells["dgvID"].Value));
                
                this.itemPurchaseMstID = Convert.ToInt16(dgvItemPurchaseMst.CurrentRow.Cells["dgvID"].Value);
                this.txtGRNO.Text = dgvItemPurchaseMst.CurrentRow.Cells["dgvGRN"].Value.ToString();
                this.dtpGRNODate.Value = Convert.ToDateTime(dgvItemPurchaseMst.CurrentRow.Cells["DgvReceiveDate"].Value);
                this.txtPO.Text = dgvItemPurchaseMst.CurrentRow.Cells["dgvPO"].Value.ToString();
                // this.dtpPODate.Value = Convert.ToDateTime(dgvItemPurchaseMst.CurrentRow.Cells["dgvPODate"].Value);
                this.txtChallanNo.Text = dgvItemPurchaseMst.CurrentRow.Cells["dgvChallanNo"].Value.ToString();
                // this.dtpChallanDate.Value = Convert.ToDateTime(dgvItemPurchaseMst.CurrentRow.Cells["dgvChallanDate"].Value);
                if (dgvItemPurchaseMst.CurrentRow.Cells["dgvSupplierID"].Value != null)
                {
                    this.cmbSupplier.SelectedValue = Convert.ToInt16(dgvItemPurchaseMst.CurrentRow.Cells["dgvSupplierID"].Value);
                }
                else
                {
                    this.cmbSupplier.SelectedIndex = -1;
                }
                //this.cmbCurrency.SelectedItem = dgvItemPurchaseMst.CurrentRow.Cells["dgvCurrency"].Value;
                this.txtRemarks.Text = dgvItemPurchaseMst.CurrentRow.Cells["dgvRemarks"].Value.ToString();
                this.txtDiscount.Text = dgvItemPurchaseMst.CurrentRow.Cells["dgvDiscount"].Value.ToString();
                txtMobileNo.Text = dgvItemPurchaseMst.CurrentRow.Cells["dgvCCharge"].Value.ToString();
                this.txtLabureCharge.Text = dgvItemPurchaseMst.CurrentRow.Cells["dgvlCharge"].Value.ToString();
                Discount = Convert.ToDecimal(txtDiscount.Text);
                
                    this.dgvItemPurchaseDetail.AutoGenerateColumns = false;
                    this.dgvItemPurchaseDetail.Rows.Clear();
                    int index = 0;
                    foreach (View_GetItemPurchaseDetails result in posContext.View_GetItemPurchaseDetails.Where(c => c.ItemPurchaseMstID == itemPurchaseMstID).ToList())
                    {
                        dgvItemPurchaseDetail.Rows.Add();
                        dgvItemPurchaseDetail.Rows[index].Cells["colID"].Value = result.ID;
                        dgvItemPurchaseDetail.Rows[index].Cells["colItemID"].Value = result.ItemID;
                        dgvItemPurchaseDetail.Rows[index].Cells["colItemCode"].Value = result.ItemCode;

                        //dgvItemPurchaseDetail.Rows[index].Cells["BatchNo"].Value = result.i;
                        // dgvItemPurchaseDetail.Rows[index].Cells["colItemCode"].Value = result.ItemCode;

                        dgvItemPurchaseDetail.Rows[index].Cells["colItemName"].Value = result.ItemName;
                        dgvItemPurchaseDetail.Rows[index].Cells["colItemPurchaseMstID"].Value = result.ItemPurchaseMstID;
                        dgvItemPurchaseDetail.Rows[index].Cells["colUnitPrice"].Value = result.UnitPrice;
                        dgvItemPurchaseDetail.Rows[index].Cells["colQuantity"].Value = result.Quantity;
                        dgvItemPurchaseDetail.Rows[index].Cells["colTotal"].Value = result.Total;
                        index++;
                    }
                    
                //btnBillPay.Enabled = false;
                this.tcItemPurchase.SelectedTab = tpItemPurchase;
                //dgvItemPurchaseDetail.Rows[0].Cells["colItemCode"].Selected = false;
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButton();
        }

        private void EnableButton()
        {
            if (cmbSupplier.SelectedIndex != -1)
            {
                using (var posContext = new Digital_AppEntities())
                {
                    FarmerInfo aFarmerInfo = posContext.FarmerInfoes.SingleOrDefault(s=>s.ID==(int)cmbSupplier.SelectedValue);
                    this.btnAdd.Enabled = true;
                    txtMobileNo.Text = aFarmerInfo.MobileNo;

                    if (dgvItemPurchaseDetail.Rows.Count > 0)
                    {
                        this.btnSave.Enabled = true;
                        this.btnCancel.Enabled = true;
                    }
                }
            }
            
        }

        private void dgvItemPurchaseDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                int column = dgvItemPurchaseDetail.CurrentCellAddress.X;
                int row = dgvItemPurchaseDetail.CurrentCellAddress.Y;
                dgvItemPurchaseDetail[column, row].Value = "0";
            }
        }

       

        private void dgvItemPurchaseDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.EnableButton();
        }

        private void dgvItemPurchaseDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.EnableButton();
        }
        string TotalPay;
      

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmFarmerInformation a = new frmFarmerInformation();
           
            a.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmItemList.Instance.CallerForm = this.Name;
            frmItemList.Instance.ShowDialog();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgvItemPurchaseMst.Rows.Clear();
                foreach (var a in posContext.View_GetItemPurchaseMst.Where(s => s.Keyword.Contains(textBox1.Text) && s.CreatedBy == Global.UserLoginID))
                {
                    //  this.dgvItemPurchaseMst.DataSource = posContext.GetItemPurchaseMst(pageSize, Convert.ToInt16(this.currentPage), "AV", txtSearch.Text);
                    dgvItemPurchaseMst.Rows.Add(a.ID, a.GRN, a.ReceivedDate, a.PO, a.PODate, a.ChallanNo, a.ChallanDate, a.SupplierID, a.SupplierName, a.Total, a.Currency, a.Remarks, a.RowNum, a.TotalRows, a.discount, a.SupplierMobileNo, a.labure_charge);
                }
            }
        }
    }
}
