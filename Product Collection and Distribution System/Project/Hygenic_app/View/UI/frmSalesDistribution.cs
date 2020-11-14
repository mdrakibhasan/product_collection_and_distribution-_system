using Digital_app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.DataModel;
using View.DBManager;

namespace View.UI
{
    public partial class frmSalesDistribution : Form
    {
          private const int DiscountColumnIndex = 11; //Column Index of Discount Cell
        private const int QtyColumnIndex = 13; //Column Index of Qty Cell

        private bool isNewClicked = false;

        public frmSalesDistribution()
        {
            InitializeComponent();
        }
        public static frmSalesDistribution _frmOrder;

        public static frmSalesDistribution Instance
        {
            get
            {
                if (_frmOrder == null || _frmOrder.IsDisposed)
                    _frmOrder = new frmSalesDistribution();
                return _frmOrder;
            }
        }
        private List<GetOrderInfoForMoneyReceipt_Result> orderForMoneyReceipt;
     private void GenerateCode()
        {
            using (var posContext = new Digital_AppEntities())
            {
                var orders = posContext.Orders;
                if (orders.Count() == 0)
                {
                    txtInvoiceNo.Text = "INV-" + DateTime.Now.Year.ToString() + "-" + Global.LoggedInUser.ID.ToString().PadLeft(3, '0') + "-" + "1".PadLeft(6, '0');
                }
                else
                {
                    Order order;
                    if (orders.Where(id => id.CreatedBy == Global.LoggedInUser.ID).Count() == 0)
                    {
                        txtInvoiceNo.Text = "INV-" + DateTime.Now.Year.ToString() + "-" + Global.LoggedInUser.ID.ToString().PadLeft(3, '0') + "-" + "1".PadLeft(6, '0');
                    }
                    else
                    {
                        order = orders.Where(id => id.CreatedBy == Global.LoggedInUser.ID).OrderByDescending(id => id.ID).Take(1).Single();
                        if (order.CreatedDate.Value.Year == DateTime.Now.Year)
                        {
                            txtInvoiceNo.Text = "INV-" + DateTime.Now.Year.ToString() + "-" + Global.LoggedInUser.ID.ToString().PadLeft(3, '0') + "-" + (Convert.ToInt16(order.InvoiceNo.Substring(13)) + 1).ToString().PadLeft(6, '0'); // StartIndex 13, only takes the serial no
                        }
                        else
                        {
                            txtInvoiceNo.Text = "INV-" + DateTime.Now.Year.ToString() + "-" + Global.LoggedInUser.ID.ToString().PadLeft(3, '0') + "-" + "1".PadLeft(6, '0');
                        }
                    }
                }
            }
        }

        private void LoadItem()
        {
            int totalRows = dgvItemList.Rows.Count, availableRecord = 0;
            string searchValue = txtSearch.Text.Trim();

            ItemWithUOM itemWithUOM;
            using (var posContext = new Digital_AppEntities())
            {
                itemWithUOM = posContext.ItemWithUOMs.SingleOrDefault(i => (i.Code == searchValue));
            }

            if (itemWithUOM == null)
            {
                MessageBox.Show("Your search for " + searchValue + " did not match any items. Please try again.", Application.ProductName);
                txtSearch.Focus();
            }
            else
            {
                if (totalRows > 0)
                {
                    availableRecord = dgvItemList.Rows
                        .Cast<DataGridViewRow>()
                        .Count(r => r.Cells["colItemCode"].Value.ToString().Equals(searchValue));
                }

                if (availableRecord == 0)
                {
                    int index = dgvItemList.Rows.Count == 0 ? 0 : dgvItemList.Rows.Count;

                    if (Convert.ToDouble(itemWithUOM.UnitsInStock) <= 0)
                    {
                        MessageBox.Show("insufficient stock.\n Please check your stock.!!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearch.Text = string.Empty;
                        txtSearch.Focus();
                        return;
                    }

                    dgvItemList.Rows.Add();
                    dgvItemList.Rows[index].Cells["colItemID"].Value = itemWithUOM.ID;
                    dgvItemList.Rows[index].Cells["colItemCode"].Value = itemWithUOM.Code;
                    dgvItemList.Rows[index].Cells["colItemName"].Value = itemWithUOM.Name;
                    dgvItemList.Rows[index].Cells["colUOMID"].Value = itemWithUOM.UOMID;
                    dgvItemList.Rows[index].Cells["colUOM"].Value = itemWithUOM.UOMName;
                    dgvItemList.Rows[index].Cells["colUnitPrice"].Value = itemWithUOM.SalePrice;
                    dgvItemList.Rows[index].Cells["colDiscountAmount"].Value = itemWithUOM.DiscountAmount;

              
                    dgvItemList.Rows[index].Cells["colQuantity"].Value = "1";
                    dgvItemList.Rows[index].Cells["colTotalPrice"].Value = dgvItemList.Rows[index].Cells["colSalePrice"].Value;
                    if (itemWithUOM.StyleNo != null)
                    {
                        dgvItemList.Rows[index].Cells["colItemSize"].Value = itemWithUOM.StyleNo;
                    }
                    else
                    {
                        dgvItemList.Rows[index].Cells["colItemSize"].Value = "";
                    }
                   // dgvItemList.Rows[index].Cells["colItemColor"].Value = itemWithUOM.ColorName;
                    dgvItemList.Rows[index].Cells["colUnitsInStock"].Value = itemWithUOM.UnitsInStock;
                }
                else
                {
                    int index = dgvItemList.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["colItemCode"].Value.ToString().Equals(searchValue))
                        .First().Index;

                    int newQuantity = Convert.ToInt32(dgvItemList.Rows[index].Cells["colQuantity"].Value) + 1;
                    decimal salePrice = Convert.ToDecimal(dgvItemList.Rows[index].Cells["colSalePrice"].Value);
                    decimal totalPrice = salePrice * newQuantity;

                    dgvItemList.Rows[index].Cells["colQuantity"].Value = newQuantity.ToString();
                    dgvItemList.Rows[index].Cells["colTotalPrice"].Value = totalPrice;
                }

                this.Calculate(-1, 0, 0,0);

                dgvItemList.CurrentCell = null;
                
                txtSearch.Text = string.Empty;
                txtSearch.Focus();
            }
        }
        private long orderMstID;
        private void ClearForm()
        {
            txtDiscountAmount.Enabled = true;
            this.orderMstID = 0;
            this.txtInvoiceNo.Text = string.Empty;
            this.txtVATAmount.Text = string.Empty;
            this.txtSubTotal.Text = string.Empty;
            this.txtGrandTotal.Text = string.Empty;
            this.txtDiscountAmount.Text = string.Empty;
            this.dtpOrderDate.Value = DateTime.Now;
            this.lblTotDiscount.Text = "0.00";
            this.txtCashReceived.Text = string.Empty;
            this.txtCashRefund.Text = string.Empty;
            this.txtDue.Text = string.Empty;
            this.cmbCustomer.SelectedIndex = -1;
            this.cmbPaymentMethod.SelectedIndex = 0;
            this.dgvItemList.Rows.Clear();
            
            this.btnCancel.Enabled = true;
            this.btnPrint.Enabled = true;
            lblstockqty.Visible = false;
            lblStock.Visible = false;
            btnSave.Enabled = btnSave.Visible= true;
            
        }

        public void EnableDisableControl(bool isEnable)
        {
            txtSearch.ReadOnly = isEnable;
            btnSearch.Enabled = !isEnable;
            txtInvoiceNo.ReadOnly = isEnable;
            dtpOrderDate.Enabled = !isEnable;
            dgvItemList.Enabled = !isEnable;
            cmbCustomer.Enabled = !isEnable;
            btnAdd.Enabled = !isEnable;
            txtCashReceived.ReadOnly = isEnable;
            cmbPaymentMethod.Enabled = !isEnable;
        }

        public void Calculate(int rowNumber, decimal quantity, decimal discount, decimal vatcount)
        {
            decimal subTotal = 0, discAmount = 0, vatAmount = 0, totalItems = 0;
            foreach (DataGridViewRow row in dgvItemList.Rows)
            {
                if (row.Index == rowNumber)
                {
                    vatAmount = vatAmount + (Convert.ToDecimal(row.Cells["colSalePrice"].Value.ToString()) * (vatcount / 100)) * quantity;
                    discAmount = discAmount + (Convert.ToDecimal(row.Cells["colSalePrice"].Value.ToString()) * (discount / 100)) * quantity;
                    subTotal = subTotal + (Convert.ToDecimal(row.Cells["colSalePrice"].Value.ToString()) * quantity);
                    totalItems = totalItems + quantity;
                }
                else
                {
                    //vatAmount= Convert.ToDecimal(row.Cells["colSalePrice"].Value.ToString());
                   // vatAmount = Convert.ToDecimal(row.Cells["colQuantity"].Value.ToString());
                    vatAmount = vatAmount + (Convert.ToDecimal(row.Cells["colSalePrice"].Value.ToString()) * (Convert.ToDecimal(row.Cells["colTaxRate"].Value.ToString()) / 100)) * Convert.ToDecimal(row.Cells["colQuantity"].Value.ToString() == string.Empty ? "0" : row.Cells["colQuantity"].Value.ToString());
                    discAmount = discAmount + (Convert.ToDecimal(row.Cells["colSalePrice"].Value.ToString()) * (Convert.ToDecimal(row.Cells["colDiscountAmount"].Value.ToString()) / 100)) * Convert.ToDecimal(row.Cells["colQuantity"].Value.ToString() == string.Empty ? "0" : row.Cells["colQuantity"].Value.ToString());
                    subTotal = subTotal + (Convert.ToDecimal(row.Cells["colSalePrice"].Value.ToString()) * Convert.ToDecimal(row.Cells["colQuantity"].Value.ToString() == string.Empty ? "0" : row.Cells["colQuantity"].Value.ToString()));
                    totalItems = totalItems + Convert.ToDecimal(row.Cells["colQuantity"].Value.ToString());
                }
            }

            txtSubTotal.Text = subTotal.ToString("N2");
            lblTotDiscount.Text = discAmount.ToString("N2");
            //txtDiscountAmount.Text = discAmount.ToString("N2");
           // vatAmount = (((subTotal - discAmount) *Convert.ToDecimal(MessageManager.VATAMOUNT)) / 100);
            txtVATAmount.Text = vatAmount.ToString("N2");
          //  txtVATAmount.Text = "0";
          //  txtGrandTotal.Text = Math.Round(((subTotal - discAmount) + vatAmount), 0).ToString("N2");
             txtGrandTotal.Text =((subTotal - discAmount) + vatAmount).ToString("N2");
           // txtCashRefund.Text = txtGrandTotal.Text;
            txtTotalItems.Text = totalItems.ToString("N0");
            txtDue.Text = txtGrandTotal.Text;
        }

        private bool Validation()
        {
            bool returnValue = true;
            if (Convert.ToDecimal(txtGrandTotal.Text == string.Empty ? "0" : txtGrandTotal.Text) <= 0 && string.IsNullOrEmpty(txtDiscountAmount.Text))
            {
                MessageBox.Show("Total is required.", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrandTotal.Focus();
                returnValue = false;
            }
            //else if ((Convert.ToDecimal(txtCashReceived.Text == string.Empty ? "0" : txtCashReceived.Text)) <= 0)
            //{
            //    MessageBox.Show("Cash received is required.", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCashReceived.Focus();
            //    returnValue = false;
            //}
            //else if (Convert.ToDecimal(txtCashReceived.Text == string.Empty ? "0" : txtCashReceived.Text) < Convert.ToDecimal(txtGrandTotal.Text == string.Empty ? "0" : txtGrandTotal.Text))
            //{
            //    MessageBox.Show("Cash received amount cannot be less than total amount.", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCashReceived.Focus();
            //    returnValue = false;
            //}

            else if (cmbPaymentMethod.SelectedIndex == 2 || cmbPaymentMethod.SelectedIndex == 1)
            {
                if (txtDue.Text == string.Empty)
                {
                    MessageBox.Show(cmbPaymentMethod.Text + " number is required.", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDue.Focus();
                    returnValue = false;
                }
            }
            //else if (Convert.ToDouble(txtDue.Text) > 0 && cmbCustomer.Text=="")
            //{
            //    MessageBox.Show("select Customer.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            return returnValue;
        }

       
       
        //public static DateTime GetShow()
        //{
        //    DateTime localDateTime;
        //    var client = new TcpClient("time.nist.gov", 13);
        //    using (var streamReader = new StreamReader(client.GetStream()))
        //    {
        //        var response = streamReader.ReadToEnd();
        //        var utcDateTimeString = response.Substring(7, 17);
        //        localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss",
        //            CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        //    }
        //    return localDateTime;
        //}
        public static DateTime GetNistTime()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();
            string todaysDates = response.Headers["date"];
            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                       CultureInfo.InvariantCulture.DateTimeFormat,
                                       DateTimeStyles.AssumeUniversal);
        }
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool CheckNet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        public int MainBranchID;
        private void frmOrder_Load(object sender, EventArgs e)
        {
            string totalTooltip;
            using (var posContext = new Digital_AppEntities())
            {
                bool act = true;

                List<CustomerInformation> customer = posContext.CustomerInformations.ToList();
                DataTable dtcustomer = Global.LINQToDataTable(customer);
                cmbCustomer.DataSource = dtcustomer;
                cmbCustomer.SelectedIndex = -1;

                List<PaymentMethod> payment = posContext.PaymentMethods.Where(a=>a.Active==true).ToList();
                DataTable dtpayment = Global.LINQToDataTable(payment);
                cmbPaymentMethod.DataSource = dtpayment;
                cmbPaymentMethod.DisplayMember = "Name";
                cmbPaymentMethod.ValueMember = "ID";
                dtpOrderDate.Value = DateTime.Now;

                List<bank_info> Bank = posContext.bank_info.Where(id => id.Active == true).ToList();
                DataTable dtBank = Global.LINQToDataTable(Bank);
                cmbBankId.DataSource = dtBank;
                cmbBankId.DisplayMember = "BankName";
                cmbBankId.ValueMember = "ID";
                cmbBankId.Text = "";
                cmbBankId.SelectedIndex = -1;

                List<CardName> CardNames = posContext.CardNames.ToList();
                DataTable dtCardNames = Global.LINQToDataTable(CardNames);
                cmbTypeOfCard.DataSource = dtCardNames;
                cmbTypeOfCard.DisplayMember = "Name";
                cmbTypeOfCard.ValueMember = "ID";
                cmbTypeOfCard.Text = "";
                cmbTypeOfCard.SelectedIndex = -1;
            }


          
            dgvItemList.Columns["colTaxRate"].Visible = false;
                lblVATPercent.Visible = true;
                totalTooltip = lblTotal.Text + " = ((" + lblSubTotal.Text + " - " + lblDiscount.Text + ") + " + lblVATPercent.Text + ")";
            //orderToolTip.SetToolTip(txtGrandTotal, totalTooltip);
           // orderToolTip.SetToolTip(lblTotal, totalTooltip);
            lblBank.Visible = cmbBankId.Visible = lblCheckNoOrCardNo.Visible = txtCheckNO.Visible = lblDateORNameOfTheCard.Visible = txtNameOfTheCard.Visible = lblIssuOrTypeOfCard.Visible = cmbTypeOfCard.Visible = dtpChequeDate.Visible = txtNameOfIssure.Visible = false;
            
           //var items = new BindingList<KeyValuePair<string, string>>();
           // items.Add(new KeyValuePair<string, string>("", ""));
           // items.Add(new KeyValuePair<string, string>("1", "VISA"));
           // items.Add(new KeyValuePair<string, string>("2", "Master Card"));
           // items.Add(new KeyValuePair<string, string>("3", "Debit Card"));
           // cmbTypeOfCard.DataSource = items;
           // cmbTypeOfCard.ValueMember = "Key";
           // cmbTypeOfCard.DisplayMember = "Value";
            isNewClicked = true;
            this.ClearForm();

            this.EnableDisableControl(false);
            this.GenerateCode();
            txtSearch.Focus();
          
            
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.ValidateDecimalValue(sender, e);

            if (char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
            {
                string newValue = Char.ToString(e.KeyChar);
                //Get the column and row position of the selected cell
                int column = dgvItemList.CurrentCellAddress.X;
                int row = dgvItemList.CurrentCellAddress.Y;

                //Gets the value that existings in that cell
                string cellValue = dgvItemList[column, row].EditedFormattedValue.ToString();
                //combines current key press to the contents of the cell
                if (char.IsNumber(e.KeyChar))
                    cellValue = cellValue + newValue;
                else if (e.KeyChar == '\b')
                {
                    if (cellValue.Length == 0)
                        cellValue = "0";
                    else
                        cellValue = cellValue.Substring(0, cellValue.Length - 1);
                }

                if(cellValue.Length > 4)
                    cellValue = cellValue.Substring(0, cellValue.Length - 1);

                int salePriceColumn = 0, totalPriceColumn = 0;
                decimal quantity = 0, discount = 0, vatcount = 0;  

                if (column == DiscountColumnIndex)
                {
                    salePriceColumn = column + 1;
                    totalPriceColumn = column + 3;
                    quantity = dgvItemList[column + 2, row].Value == null ? 0 : Convert.ToDecimal(dgvItemList[column + 2, row].Value);
                    discount = Convert.ToDecimal(cellValue == "" ? "0" : cellValue);
                    //vatcount = Convert.ToDecimal(cellValue == "" ? "0" : cellValue);
                    vatcount = dgvItemList[column-1, row].Value == null ? 0 : Convert.ToDecimal(dgvItemList[column-1, row].Value);
                }
                else if (column == QtyColumnIndex)
                {
                    lblstockqty.Visible = false;
                    lblStock.Visible = false;
                    salePriceColumn = column - 1;
                    totalPriceColumn = column + 1;
                    quantity = Convert.ToDecimal(cellValue == "" ? "0" : cellValue);
                 
                    if (checkStoke(quantity, dgvItemList[3, row].Value.ToString()))
                    {
                        quantity = 0;
                        MessageBox.Show("stock is less then issue qty.", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        lblstockqty.Visible = true;
                        lblStock.Visible = true;
                    }
                    discount = dgvItemList[column - 2, row].Value == null ? 0 : Convert.ToDecimal(dgvItemList[column - 2, row].Value);
                    vatcount = dgvItemList[column - 3, row].Value == null ? 0 : Convert.ToDecimal(dgvItemList[column - 3, row].Value);
                    
                   // txtDiscountAmount.Enabled = false;
                }

                decimal salePrice = dgvItemList[salePriceColumn, row].Value == null ? 0 : Convert.ToDecimal(dgvItemList[salePriceColumn, row].Value);

                dgvItemList[totalPriceColumn, row].Value = salePrice * quantity;
                this.Calculate(row, quantity, discount, vatcount);
            }
        }

        private bool checkStoke(decimal a, string b)
        {
            using (var posContext = new Digital_AppEntities())
            {
                ItemWithUOM itemWithUOM = posContext.ItemWithUOMs.Where(it => it.Code == b).FirstOrDefault();
                decimal c = (decimal) itemWithUOM.UnitsInStock;
                if (a > c)
                {
                    lblstockqty.Text = c.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text.Length > 0)
            {
                this.btnSave.Enabled = true;
                this.btnCancel.Enabled = true;
            }
            else
            {
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    if (!string.IsNullOrEmpty(txtDiscountAmount.Text) && Convert.ToDouble(txtCashReceived.Text) <= 0 &&
                        cmbCustomer.SelectedValue == null)
                    {
                        MessageBox.Show("Please select Cusromer then save.!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (Convert.ToDouble(txtDue.Text) > 0)
                    {
                        MessageBox.Show("Incorrect Received Amount.!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Order order;
                        string invoiceNumber = "";
                      
                        
                        if (!string.IsNullOrEmpty(txtDiscountAmount.Text))
                        {
                            if (Convert.ToDecimal(txtDiscountAmount.Text) > 0 && cmbCustomer.SelectedValue == null)
                            {
                                throw new Exception("you already set discount but you not select Custome.\n if you want to set discount first you select Customer then save.");
                            }
                        }
                        using (var posContext = new Digital_AppEntities())
                        {
                            //double PvPrice=SP_PV_UnitPrice_Result
                            if (orderMstID == 0)
                            {
                                order = new Order();                               
                                order.OrderDate = Convert.ToDateTime(dtpOrderDate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                                order.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
                                order.TaxAmount = Convert.ToDecimal(txtVATAmount.Text);
                                order.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                                order.BranchServerID = MainBranchID;
                                if (string.IsNullOrEmpty(txtDiscountAmount.Text))
                                {
                                    order.DiscountAmount = 0;
                                }
                                else
                                {
                                    order.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                                }
                                if (cmbCustomer.SelectedIndex != -1)
                                    order.CustomerID = Convert.ToInt16(cmbCustomer.SelectedValue);

                                order.PaymentMethodID = Convert.ToInt16(cmbPaymentMethod.SelectedValue);

                                if (txtCashReceived.Text.Length > 0)
                                {
                                    order.CashReceived = Convert.ToDecimal(txtCashReceived.Text);
                                }
                                else
                                    txtCashReceived.Text = "0";

                                order.CashRefund = Convert.ToDecimal(txtCashRefund.Text);
                                order.OrderStatusID = 1;
                                order.PaymentMethodNumber = txtDue.Text;
                                order.CreatedBy = Global.LoggedInUser.ID;
                                //order.CompanyId = Global.Company.Id;
                                order.CreatedDate = DateTime.Now;
                                order.Due = Convert.ToDecimal(txtDue.Text);
                                if (cmbPaymentMethod.SelectedValue.ToString() != "1")
                                {
                                    if (cmbBankId.SelectedValue.ToString() != "")
                                    {
                                        order.BankID = Convert.ToInt32(cmbBankId.SelectedValue.ToString());
                                    }
                                    order.CheckORCardNo = txtCheckNO.Text;
                                    order.CheckDate = dtpChequeDate.Value;
                                    order.NameOfIssuer = txtNameOfIssure.Text;
                                    order.NameOnTheCard = txtNameOfTheCard.Text;
                                    if (cmbTypeOfCard.SelectedValue != null)
                                    {
                                        if (cmbTypeOfCard.SelectedValue.ToString() != "")
                                        {
                                            order.TypeOfCard = Convert.ToInt32(cmbTypeOfCard.SelectedValue);
                                        }
                                    }
                                }
                                GenerateCode();
                                order.InvoiceNo = txtInvoiceNo.Text;
                                posContext.Orders.Add(order);

                                posContext.SaveChanges();

                                long id = order.ID;

                                OrderDetail orderDetailDtl;
                                foreach (DataGridViewRow row in dgvItemList.Rows)
                                {
                                    orderDetailDtl = new OrderDetail();
                                    orderDetailDtl.OrderID = id;
                                    
                                    orderDetailDtl.ItemID = Convert.ToInt32(row.Cells["colItemID"].Value);
                                    orderDetailDtl.UnitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                                    orderDetailDtl.TaxRate = Convert.ToDecimal(row.Cells["colTaxRate"].Value); 
                                    //Convert.ToDecimal(row.Cells["colUnitPrice"].Value) * (Convert.ToDecimal(row.Cells["colTaxRate"].Value) / 100);
                                    orderDetailDtl.DiscountAmount = Convert.ToDecimal(row.Cells["colDiscountAmount"].Value); 
                                    //Convert.ToDecimal(row.Cells["colUnitPrice"].Value) * (Convert.ToDecimal(row.Cells["colDiscountAmount"].Value) / 100);
                                    orderDetailDtl.SalePrice = Convert.ToDecimal(row.Cells["colSalePrice"].Value);
                                    orderDetailDtl.Quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                                    orderDetailDtl.ReturnQuantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                                    orderDetailDtl.TotalPrice = Convert.ToDecimal(row.Cells["colTotalPrice"].Value);
                                    orderDetailDtl.CreatedBy = Global.LoggedInUser.ID;
                                    //orderDetailDtl.CompanyId = Global.Company.Id;
                                    orderDetailDtl.CreatedDate = DateTime.Now;

                                   // ObjectResult<SP_PV_UnitPrice_Result> results = posContext.SP_PV_UnitPrice(orderDetailDtl.ItemID, orderDetailDtl.Quantity);
                                    //foreach (SP_PV_UnitPrice_Result result in results)
                                    //{
                                   //     orderDetailDtl.PvUnitPrice = result.TransferPrice;
                                   // }
                                    posContext.OrderDetails.Add(orderDetailDtl);
                                }
                                posContext.SaveChanges();
                                invoiceNumber = order.InvoiceNo;
                                
                            }
                            else
                            {
                                order = posContext.Orders.Single(s => s.ID == orderMstID);
                                order.OrderDate = Convert.ToDateTime(dtpOrderDate.Value.ToShortDateString() + " " + DateTime.Now.TimeOfDay.ToString());
                                order.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
                                order.BranchServerID = MainBranchID;
                                order.TaxAmount = Convert.ToDecimal(txtVATAmount.Text);
                                order.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                                if (string.IsNullOrEmpty(txtDiscountAmount.Text))
                                {
                                    order.DiscountAmount = 0;
                                }
                                else
                                {
                                    order.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                                }

                                if (cmbCustomer.SelectedIndex != -1)
                                    order.CustomerID = Convert.ToInt16(cmbCustomer.SelectedValue);

                                order.PaymentMethodID = Convert.ToInt16(cmbPaymentMethod.SelectedValue);
                                order.CashReceived = Convert.ToDecimal(txtCashReceived.Text);
                                order.CashRefund = Convert.ToDecimal(txtCashRefund.Text);
                                order.OrderStatusID = 1;
                                order.PaymentMethodNumber = txtDue.Text;
                                order.ModifiedBy = Global.LoggedInUser.ID;
                                order.ModifiedDate = DateTime.Now;
                                order.Due = Convert.ToDecimal(txtDue.Text);
                                if (cmbPaymentMethod.SelectedValue.ToString() != "1")
                                {
                                    if (cmbBankId.SelectedValue.ToString() != "")
                                    {
                                        order.BankID = Convert.ToInt32(cmbBankId.SelectedValue.ToString());
                                    }
                                    order.CheckORCardNo = txtCheckNO.Text;
                                    order.CheckDate = dtpChequeDate.Value;
                                    order.NameOfIssuer = txtNameOfIssure.Text;
                                    order.NameOnTheCard = txtNameOfTheCard.Text;
                                    if (cmbTypeOfCard.SelectedValue != null)
                                    {
                                        if (cmbTypeOfCard.SelectedValue.ToString() != "")
                                        {
                                            order.TypeOfCard = Convert.ToInt32(cmbTypeOfCard.SelectedValue);
                                        }
                                    }
                                }
                                posContext.SaveChanges();

                                foreach (OrderDetail item in posContext.OrderDetails.Where(id => id.OrderID == orderMstID).ToList())
                                {
                                    posContext.OrderDetails.Remove(item);
                                }
                                posContext.SaveChanges();

                                OrderDetail orderDetailDtl;
                                foreach (DataGridViewRow row in dgvItemList.Rows)
                                {
                                    orderDetailDtl = new OrderDetail();
                                    orderDetailDtl.OrderID = orderMstID;
                                    orderDetailDtl.ItemID = Convert.ToInt32(row.Cells["colItemID"].Value);
                                    orderDetailDtl.UnitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                                    orderDetailDtl.TaxRate = Convert.ToDecimal(row.Cells["colTaxRate"].Value); 
                                    //Convert.ToDecimal(row.Cells["colUnitPrice"].Value) * (Convert.ToDecimal(row.Cells["colTaxRate"].Value) / 100);
                                    orderDetailDtl.DiscountAmount = Convert.ToDecimal(row.Cells["colDiscountAmount"].Value); 
                                    //Convert.ToDecimal(row.Cells["colUnitPrice"].Value) * (Convert.ToDecimal(row.Cells["colDiscountAmount"].Value) / 100);
                                    orderDetailDtl.SalePrice = Convert.ToDecimal(row.Cells["colSalePrice"].Value);
                                    orderDetailDtl.Quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                                    orderDetailDtl.ReturnQuantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);
                                    orderDetailDtl.TotalPrice = Convert.ToDecimal(row.Cells["colTotalPrice"].Value);
                                    orderDetailDtl.ModifiedBy = Global.LoggedInUser.ID;
                                    orderDetailDtl.ModifiedDate = DateTime.Now;
                                    //ObjectResult<SP_PV_UnitPrice_Result> results = posContext.SP_PV_UnitPrice(orderDetailDtl.ItemID, orderDetailDtl.Quantity);
                                    //foreach (SP_PV_UnitPrice_Result result in results)
                                    //{
                                    //    orderDetailDtl.PvUnitPrice = result.TransferPrice;
                                    //}
                                    posContext.OrderDetails.Add(orderDetailDtl);
                                }
                                posContext.SaveChanges();
                                invoiceNumber = order.InvoiceNo;

                            }
                            //this.ClearForm();
                        }


                       
                       isNewClicked = true;
                       this.ClearForm();

                       this.EnableDisableControl(false);
                       this.GenerateCode();
                       txtSearch.Focus();
                        GetOrderInfoForMoneyReceipt("OrderForMoneyreceipt", invoiceNumber,false);
                        //Reports.frmReportViewer.Instance.GetOrderInfoForMoneyReceipt("OrderForMoneyreceipt", invoiceNumber);
                        //Reports.frmReportViewer.Instance.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetOrderInfoForMoneyReceipt(string p1, string invoiceNumber, bool p2)
        {
            using (var posContext = new Digital_AppEntities())
            {
                orderForMoneyReceipt = posContext.GetOrderInfoForMoneyReceipt(invoiceNumber).ToList();
                if (orderForMoneyReceipt != null)
                {
                    PrintDialog printDialog = new PrintDialog();
                    PrintDocument printDocument = new PrintDocument();
                    PrinterSettings printerSettings = new PrinterSettings();
                    //PaperSize paperSize = new PaperSize("Custom", 820, 520);
                    PaperSize paperSize = new PaperSize();

                    printDialog.Document = printDocument;
                    printDialog.Document.DefaultPageSettings.PaperSize = paperSize;

                    printDocument.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                    printDocument.Print();
                }
            }
        }

        //******************* Get Items Information *******//

        private void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string flag = "";

            
            Graphics graphics = e.Graphics;
            Font fontSize4 = new Font("Courier New", 4);
            Font fontSize5 = new Font("Courier New", 5);
            Font fontSize5Bold = new Font("Courier New", 5, FontStyle.Bold);
            Font fontSize6 = new Font("Courier New", 6);
            Font fontSize6Bold = new Font("Courier New", 6, FontStyle.Bold);
            Font fontSize7 = new Font("Courier New", 7);
            Font fontSize8 = new Font("Courier New", 8, FontStyle.Regular);
            Font fontSize99 = new Font("Courier New", 9, FontStyle.Regular);
            Font fontSize9 = new Font("Courier New", 9, FontStyle.Bold);
            Font fontSize7Bold = new Font("Courier New", 7, FontStyle.Bold);
            Font fontSize8Bold = new Font("Courier New", 8, FontStyle.Bold);

            float fontHeight = fontSize7.GetHeight();
            int startX = 5, startY = 5, offset = 20;

            CompanyInfo company;

            using (var posContext = new Digital_AppEntities())
            {
                company = posContext.CompanyInfoes.Single(id => id.ID == Global.CompanyID);
            }

            DataTable dtorderForMoneyReceipt = Global.LINQToDataTable(orderForMoneyReceipt);

            //graphics.DrawImage(company.Name, new Font("Courier New", 14, FontStyle.Bold),
            //                    new SolidBrush(Color.Black), startX + 50, startY + offset);
            byte[] image = (byte[])company.Logo;
            MemoryStream ms = new MemoryStream(image);

            Image returnImage = Image.FromStream(ms);//Exception occurs here
            e.Graphics.DrawImage(returnImage, 90, 5, 98, 25);

            graphics.DrawString("[Vat:" + company.VatGroupNo + "]", fontSize6,
                              new SolidBrush(Color.Black), startX + 200, startY + offset);

            offset = offset + 18;


            offset = BreakAmountInWorkToNewLine(graphics, fontSize7, startX, startY, offset, company.Address1, 42);
            //graphics.DrawString(company.Address1, fontSize8,
            //                    new SolidBrush(Color.Black), startX , startY + offset);
            offset = offset + 10;

            //graphics.DrawString(company.Address2 , fontSize8,
            //                    new SolidBrush(Color.Black), startX + 40, startY + offset);
            //offset = offset + 15;

            graphics.DrawString("Phone-1 : " + company.Phone, fontSize8,
                                new SolidBrush(Color.Black), startX + 40, startY + offset);
            //offset = offset + 15;

            offset = offset + 10;

            graphics.DrawString("Phone-2 : " + company.Mobile, fontSize8,
                                new SolidBrush(Color.Black), startX + 40, startY + offset);
            offset = offset + 15;

            //graphics.DrawString("" + company.VATRegistration, fontSize7,
            //                    new SolidBrush(Color.Black), startX + 40, startY + offset);
            //offset = offset + 15;

            graphics.DrawString("VAT Registration # " + company.VATRegistration.ToString(), fontSize7,
                                new SolidBrush(Color.Black), startX + 40, startY + offset);
            offset = offset + 15;

            //graphics.DrawString("User # " + Global.LoggedInUser, fontSize7,
            //                    new SolidBrush(Color.Black), startX + 40, startY + offset);
            //offset = offset + 15;

            DateTime orderDateTime = Convert.ToDateTime(dtorderForMoneyReceipt.Rows[0]["OrderDate"]);
            graphics.DrawString("Sales Date : " + orderDateTime.ToString("dd-MMM-yyyy") + " " + dtorderForMoneyReceipt.Rows[0]["Time"].ToString(),
                     fontSize8,
                     new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 10;

            graphics.DrawString("Invoice No : " + dtorderForMoneyReceipt.Rows[0]["InvoiceNo"].ToString(),
                     fontSize9,
                     new SolidBrush(Color.Black), startX, startY + offset);

            if (!dtorderForMoneyReceipt.Rows[0]["ContactName"].ToString().Equals(string.Empty))
            {
                offset = offset + 15;
                graphics.DrawString("Customer : " + dtorderForMoneyReceipt.Rows[0]["ContactName"].ToString(),
                         fontSize8,
                         new SolidBrush(Color.Black), startX, startY + offset);
            }
            //if (!string.IsNullOrEmpty(dtorderForMoneyReceipt.Rows[0]["MobileNo"].ToString()))
            //{

            //         offset = offset + 15;
            //    graphics.DrawString("Customer Mobile: " + dtorderForMoneyReceipt.Rows[0]["MobileNo"].ToString(),
            //             fontSize8,
            //             new SolidBrush(Color.Black), startX, startY + offset);
            //}

            Pen pen = new Pen(Color.Black, Convert.ToSingle(0.5));
            pen.DashPattern = new float[] { 2f, 4f };

            offset = offset + 15;
            graphics.DrawLine(pen, startX, startY + offset, startX + 263, startY + offset);

            offset = offset + 5;
            //graphics.DrawString("Items,Code,Fabr.T   Prd.F,Design Size,Color Qty,Rate Amount ", fontSize5Bold,
            //         new SolidBrush(Color.Black), startX, startY + offset);


            graphics.DrawString("Name", fontSize6,
                 new SolidBrush(Color.Black), startX, startY + offset);

            graphics.DrawString("Code", fontSize5Bold,
              new SolidBrush(Color.Black), startX+130, startY + offset );

            //graphics.DrawString(item.ItemSize.PadLeft(5), fontSize7,
            //  new SolidBrush(Color.Black), startX + 75, startY + offset + 10);
           

            graphics.DrawString("Qty".PadLeft(4), fontSize6,
                 new SolidBrush(Color.Black), startX + 175, startY + offset);
            //totalQuantity = totalQuantity + Convert.ToInt16(item.Quantity);
            if (flag != "Y")
            {
                graphics.DrawString("Price  Amnt".PadLeft(6), fontSize6,
                         new SolidBrush(Color.Black), startX + 195, startY + offset);


            }
            //graphics.DrawString("", fontSize5Bold,
            //         new SolidBrush(Color.Black), startX + 30, startY + offset);


            //graphics.DrawString("FabricsType".PadLeft(4), fontSize5,
            //       new SolidBrush(Color.Black), startX + 45, startY + offset);

            //graphics.DrawString("Design".PadLeft(4), fontSize5,
            //        new SolidBrush(Color.Black), startX + 90, startY + offset);
            //graphics.DrawString("Product Fit".PadLeft(4), fontSize5,
            //      new SolidBrush(Color.Black), startX + 105, startY + offset);


            //graphics.DrawString("Size".PadLeft(4), fontSize5,
            //       new SolidBrush(Color.Black), startX + 150, startY + offset);

            //graphics.DrawString("Color".PadLeft(4), fontSize5,
            //       new SolidBrush(Color.Black), startX + 170, startY + offset);


            //graphics.DrawString("QTY".PadLeft(4), fontSize5,
            //         new SolidBrush(Color.Black), startX + 190, startY + offset);

            //graphics.DrawString("RATE".PadLeft(6), fontSize5,
            //         new SolidBrush(Color.Black), startX + 200, startY + offset);

            //graphics.DrawString("AMOUNT".PadLeft(8), fontSize5,
            //         new SolidBrush(Color.Black), startX + 220, startY + offset);

            offset = offset + 15;
            graphics.DrawLine(pen, startX, startY + offset, startX + 263, startY + offset);

            double totalQuantity = 0;
            decimal SubTotal = 0;
            decimal Total = 0;
            decimal discount = 0;
            decimal vat = 0;
            decimal TotalPayment = 0;

            offset = offset + 5;
            foreach (GetOrderInfoForMoneyReceipt_Result item in orderForMoneyReceipt)
            {
                graphics.DrawString(item.ItemName, fontSize6,
                  new SolidBrush(Color.Black), startX, startY + offset);

                graphics.DrawString(item.ItemCode, fontSize6,
                  new SolidBrush(Color.Black), startX+130, startY + offset);

               
                graphics.DrawString(Convert.ToDouble(item.Quantity).ToString().PadLeft(4), fontSize6,
                     new SolidBrush(Color.Black), startX + 175, startY + offset);
                totalQuantity = totalQuantity + Convert.ToDouble(item.Quantity);
                if (flag != "Y")
                {
                    graphics.DrawString((Math.Round(Convert.ToDouble(item.SalePrice), 2, MidpointRounding.AwayFromZero)).ToString().PadLeft(6), fontSize6,
                             new SolidBrush(Color.Black), startX + 195, startY + offset );

                    graphics.DrawString((Math.Round(Convert.ToDouble(item.TotalPrice), 2, MidpointRounding.AwayFromZero)).ToString().PadLeft(8), fontSize6,
                             new SolidBrush(Color.Black), startX + 210, startY + offset );
                }
                offset = offset + 25;
            }

            graphics.DrawLine(new Pen(Color.Black, Convert.ToSingle(0.5)), startX, startY + offset, startX + 262, startY + offset);

            offset = offset + 5;
            graphics.DrawString("Total Sale Quantity: ", fontSize7Bold,
                     new SolidBrush(Color.Black), startX, startY + offset);
            graphics.DrawString(totalQuantity.ToString().PadLeft(13), fontSize7,
                     new SolidBrush(Color.Black), startX + 175, startY + offset);

            offset = offset + 15;
            if (flag != "Y")
            {
                graphics.DrawString("Total Sale Price amount: ", fontSize7Bold,
                         new SolidBrush(Color.Black), startX, startY + offset);

                graphics.DrawString(Math.Round(Convert.ToDecimal(dtorderForMoneyReceipt.Rows[0]["SubTotal"]), 2, MidpointRounding.AwayFromZero).ToString().PadLeft(13), fontSize7,
                         new SolidBrush(Color.Black), startX + 180, startY + offset);

                offset = offset + 15;
                graphics.DrawString("Discount : ", fontSize7Bold,
                         new SolidBrush(Color.Black), startX, startY + offset);

                graphics.DrawString(Math.Round(Convert.ToDecimal(dtorderForMoneyReceipt.Rows[0]["DiscountAmount"]), 2, MidpointRounding.AwayFromZero).ToString().PadLeft(13), fontSize7,
                         new SolidBrush(Color.Black), startX + 180, startY + offset);

                offset = offset + 15;
                try
                {
                    graphics.DrawString("VAT (" + Convert.ToDecimal(dtorderForMoneyReceipt.Rows[0]["vatRate"]).ToString("N1") + "%): ", fontSize7Bold,
                             new SolidBrush(Color.Black), startX, startY + offset);
                }
                catch
                {
                    graphics.DrawString("VAT (" + (dtorderForMoneyReceipt.Rows[0]["vatRate"]).ToString() + "%): ", fontSize7Bold,
                            new SolidBrush(Color.Black), startX, startY + offset);
                }
                graphics.DrawString(Math.Round(Convert.ToDecimal(dtorderForMoneyReceipt.Rows[0]["TaxAmount"]), 2, MidpointRounding.AwayFromZero).ToString().PadLeft(13), fontSize7,
                         new SolidBrush(Color.Black), startX + 180, startY + offset);

                offset = offset + 15;
                graphics.DrawLine(new Pen(Color.Black, Convert.ToSingle(0.5)), startX, startY + offset, startX + 263, startY + offset);

                offset = offset + 5;
                graphics.DrawString("Net Total : ", fontSize99,
                         new SolidBrush(Color.Black), startX, startY + offset);
                graphics.DrawString(Math.Round(Convert.ToDecimal(dtorderForMoneyReceipt.Rows[0]["GrandTotal"]), 2, MidpointRounding.AwayFromZero).ToString().PadLeft(13), fontSize7Bold,
                         new SolidBrush(Color.Black), startX + 180, startY + offset);

                
                
                offset = offset + 15;
                graphics.DrawLine(new Pen(Color.Black, Convert.ToSingle(0.5)), startX, startY + offset, startX + 257, startY + offset);

                offset = offset + 5;
                graphics.DrawString("Paid (" + dtorderForMoneyReceipt.Rows[0]["PaymentMode"] + ") : ", fontSize7Bold,
                         new SolidBrush(Color.Black), startX, startY + offset);
                graphics.DrawString(Math.Round(Convert.ToDecimal(dtorderForMoneyReceipt.Rows[0]["CashReceived"]), 2, MidpointRounding.AwayFromZero).ToString().PadLeft(13), fontSize7Bold,
                         new SolidBrush(Color.Black), startX + 180, startY + offset);

                offset = offset + 15;
                graphics.DrawString("Change : ", fontSize7Bold,
                         new SolidBrush(Color.Black), startX, startY + offset);
                graphics.DrawString(Math.Round(Convert.ToDecimal(dtorderForMoneyReceipt.Rows[0]["CashRefund"]), 2, MidpointRounding.AwayFromZero).ToString().PadLeft(13), fontSize7Bold,
                         new SolidBrush(Color.Black), startX + 180, startY + offset);

                offset = offset + 15;
                graphics.DrawLine(new Pen(Color.Black, Convert.ToSingle(0.5)), startX, startY + offset, startX + 257, startY + offset);

                string amountInWord = "TAKA " + Global.ConvertNumberToWords(Convert.ToInt32(dtorderForMoneyReceipt.Rows[0]["GrandTotal"])).ToUpper() + " ONLY.";
                int maxLength = 42;
                offset = offset + 5;
                offset = BreakAmountInWorkToNewLine(graphics, fontSize7Bold, startX, startY, offset, amountInWord, maxLength);



                //////////////
            }
            offset = offset + 15;
            graphics.DrawString("Served By : " + dtorderForMoneyReceipt.Rows[0]["ServiceBy"].ToString(),
                        fontSize7,
                        new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 15;
            graphics.DrawString("We happly Exchange unused & unaltered  ", fontSize7,
                     new SolidBrush(Color.Black), startX + 5, startY + offset);

            offset = offset + 10;
            graphics.DrawString("Product Within 7 Days along with the ", fontSize7,
                     new SolidBrush(Color.Black), startX + 5, startY + offset);

            offset = offset + 10;
            graphics.DrawString("original receipt & tag or SMS. ", fontSize7,
                     new SolidBrush(Color.Black), startX + 5, startY + offset);
          

            offset = offset + 10;
            graphics.DrawString(company.Email, fontSize7Bold,
                     new SolidBrush(Color.Black), startX + 5, startY + offset);
            try
            {
                if (Convert.ToDouble(dtorderForMoneyReceipt.Rows[0]["DiscountAmount"]) > 0)
                {
                    offset = offset + 18;
                    graphics.DrawString("Discount Products Not Changeable!", fontSize7Bold,
                            new SolidBrush(Color.Blue), startX + 5, startY + offset);
                }
            }
            catch
            {
            }
            //offset = offset + 15;


            //graphics.DrawString(company.Website.ToString(), fontSize7Bold,
            //         new SolidBrush(Color.Black), startX+5, startY + offset);
            //offset = offset + 15;
            //graphics.DrawString("www.facebook.com/dorjibaribd", fontSize7Bold,
            //         new SolidBrush(Color.Black), startX, startY + offset);


            offset = offset + 17;
            offset = BreakAmountInWorkToNewLine(graphics, fontSize6Bold, startX, startY, offset, "Sales Service Point   " + Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 4) + "/Powered By " + Application.CompanyName, 42);

            offset = offset + 18;
            graphics.DrawString("Thank You For Shopping with us.. ", fontSize8Bold,
                     new SolidBrush(Color.DarkBlue), startX + 5, startY + offset);

            offset = offset + 60;

            graphics.DrawString("", fontSize7Bold,
                   new SolidBrush(Color.Black), startX + 5, startY + offset);
            offset = offset + 50;
            graphics.DrawString(".....................................................", fontSize6,
                    new SolidBrush(Color.Black), startX, startY + offset);


        }
        private static int BreakAmountInWorkToNewLine(Graphics graphics, Font fontSize7Bold, int startX, int startY, int offset, string amountInWord, int maxLength)
        {
            if (amountInWord.Length > maxLength)
            {
                graphics.DrawString(amountInWord.Substring(0, maxLength), fontSize7Bold,
                         new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 10;

                amountInWord = amountInWord.Substring(maxLength);
                offset = BreakAmountInWorkToNewLine(graphics, fontSize7Bold, startX, startY, offset, amountInWord, maxLength);
            }
            else
            {
                graphics.DrawString(amountInWord, fontSize7Bold,
                         new SolidBrush(Color.Black), startX, startY + offset);
            }
            return offset;
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isNewClicked = true;
            this.ClearForm();

            this.EnableDisableControl(false);
            this.GenerateCode();
            txtSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmItemList.Instance.CallerForm = this.Name;
            frmItemList.Instance.ShowDialog();

            txtSearch.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            isNewClicked = true;
            this.ClearForm();
            
            this.EnableDisableControl(false);
            this.GenerateCode();
            txtSearch.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //frmCustomer.Instance.CallerFrom = MessageManager.frmOrder;
            //frmCustomer.Instance.ShowDialog();
        }

        private void dgvItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 16)
            {
                if (MessageBox.Show(MessageManager.RecordDeleteConfirmationMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvItemList.Rows.RemoveAt(e.RowIndex);
                    this.Calculate(-1, 0, 0,0);
                }
            }
        }

        private void dgvItemList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void dgvItemList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == QtyColumnIndex || e.ColumnIndex == DiscountColumnIndex)
            {
                int column = dgvItemList.CurrentCellAddress.X, row = dgvItemList.CurrentCellAddress.Y;
                dgvItemList[column, row].Value = string.Empty;
            }
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCashReceived.Text != string.Empty)
                {

                    //if (!string.IsNullOrEmpty(txtCashReceived.Text))
                    //{
                    //    this.txtCashRefund.Text = (Convert.ToDouble(txtGrandTotal.Text) - Convert.ToDouble(txtCashReceived.Text)).ToString();
                    //}
                    this.txtCashRefund.Text =
                        (Convert.ToDecimal(txtCashReceived.Text) -
                         Convert.ToDecimal(txtGrandTotal.Text == string.Empty ? "0" : txtGrandTotal.Text)).ToString();
                    if (Convert.ToDouble(txtGrandTotal.Text) < Convert.ToDouble(txtCashReceived.Text))
                    {
                        txtDue.Text = "0";
                    }
                    else
                    {
                        txtDue.Text =
                            (Convert.ToDouble(txtGrandTotal.Text) - Convert.ToDouble(txtCashReceived.Text)).ToString();
                        if (txtCashReceived.Text == "")
                        {
                            txtCashReceived.Text = "";
                            txtDue.Text = txtGrandTotal.Text;
                            txtCashRefund.Text = "";
                        }
                    }
                }
                else
                {
                    txtCashReceived.Text = "";
                    txtDue.Text = txtGrandTotal.Text;
                    txtCashRefund.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message", "Null Text Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtCashReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.ValidateDecimalValue(sender, e);
            if (e.KeyChar == 13)
            {
                btnSave.Focus();
            }
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaymentMethod.SelectedIndex == 0) // Cash
                {
                    lblPaymentModeNumberRequired.Visible = false;
                    txtDue.ReadOnly = true;
                    txtDue.BackColor = System.Drawing.SystemColors.Info;
                    cmbBankId.SelectedIndex = cmbTypeOfCard.SelectedIndex = -1;
                    txtCheckNO.Text = txtNameOfTheCard.Text = txtNameOfIssure.Text = string.Empty;
                    lblBank.Visible =
                        cmbBankId.Visible =
                            lblCheckNoOrCardNo.Visible =
                                txtCheckNO.Visible =
                                    lblDateORNameOfTheCard.Visible =
                                        txtNameOfTheCard.Visible =
                                            lblIssuOrTypeOfCard.Visible =
                                                cmbTypeOfCard.Visible =
                                                    dtpChequeDate.Visible = txtNameOfIssure.Visible = false;
                }
                else
                {
                    if (cmbPaymentMethod.SelectedIndex == 1) // Cheque
                    {
                       // orderToolTip.SetToolTip(txtDue, "Check  Number is required.");
                        //orderToolTip.SetToolTip(lblPaymentModeNumberRequired, "Check  Number is required.");
                        lblCheckNoOrCardNo.Text = "Check  No./Routing No.";
                        lblDateORNameOfTheCard.Text = "Date";
                        lblIssuOrTypeOfCard.Text = "Name of Issuer";
                        cmbBankId.SelectedIndex = cmbTypeOfCard.SelectedIndex = -1;
                        txtCheckNO.Text = txtNameOfTheCard.Text = txtNameOfIssure.Text = string.Empty;
                        lblBank.Visible =
                            cmbBankId.Visible =
                                lblCheckNoOrCardNo.Visible =
                                    txtCheckNO.Visible =
                                        lblDateORNameOfTheCard.Visible =
                                            txtNameOfTheCard.Visible =
                                                lblIssuOrTypeOfCard.Visible =
                                                    cmbTypeOfCard.Visible =
                                                        dtpChequeDate.Visible = txtNameOfIssure.Visible = true;
                        txtNameOfTheCard.Visible = false;
                        cmbTypeOfCard.Visible = false;
                    }
                    else if (cmbPaymentMethod.SelectedIndex == 2) // Card
                    {
                       // orderToolTip.SetToolTip(txtDue, "Card Number is required.");
                       // orderToolTip.SetToolTip(lblPaymentModeNumberRequired, "Card Number is required.");
                        lblCheckNoOrCardNo.Text = "Card Number";
                        lblDateORNameOfTheCard.Text = "Name Of The Card";
                        lblIssuOrTypeOfCard.Text = "Type of Card";
                        cmbBankId.SelectedIndex = cmbTypeOfCard.SelectedIndex = -1;
                        txtCheckNO.Text = txtNameOfTheCard.Text = txtNameOfIssure.Text = string.Empty;
                        lblBank.Visible =
                            cmbBankId.Visible =
                                lblCheckNoOrCardNo.Visible =
                                    txtCheckNO.Visible =
                                        lblDateORNameOfTheCard.Visible =
                                            txtNameOfTheCard.Visible =
                                                lblIssuOrTypeOfCard.Visible =
                                                    cmbTypeOfCard.Visible =
                                                        dtpChequeDate.Visible = txtNameOfIssure.Visible = true;
                        dtpChequeDate.Visible = false;
                        txtNameOfIssure.Visible = false;
                    }
                    txtDue.Focus();
                    lblPaymentModeNumberRequired.Visible = true;
                    txtDue.ReadOnly = false;
                    txtDue.BackColor = System.Drawing.SystemColors.Window;
                }
            }
            catch (Exception)
            {


            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.LoadItem();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GetOrderInfoForMoneyReceipt("OrderForMoneyreceipt", txtInvoiceNo.Text.Trim(),false);
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char) Keys.Enter)
                {
                    using (var posContext = new Digital_AppEntities())
                    {
                        dgvItemList.Rows.Clear();
                        Order order = posContext.Orders.Single(id => id.InvoiceNo == txtInvoiceNo.Text.Trim().ToUpper());
                        orderMstID = order.ID;
                        dtpOrderDate.Value = Convert.ToDateTime(order.OrderDate);
                        if (order.CustomerID != null)
                        {
                            cmbCustomer.SelectedValue = order.CustomerID;
                        }
                        txtSubTotal.Text = Convert.ToDecimal(order.SubTotal).ToString("N2");
                        txtVATAmount.Text = Convert.ToDecimal(order.TaxAmount).ToString("N2");
                        txtDiscountAmount.Text = Convert.ToDecimal(order.DiscountAmount).ToString("N2");
                        txtGrandTotal.Text = Convert.ToDecimal(order.GrandTotal).ToString("N2");
                        txtCashReceived.Text = Convert.ToDecimal(order.CashReceived).ToString("N2");
                        txtCashRefund.Text = Convert.ToDecimal(order.CashRefund).ToString("N2");
                        //cmbPaymentMethod.SelectedValue = order.PaymentMethodID;
                        txtDue.Text = order.Due.ToString();
                        if (order.PaymentMethodID != null)
                        {
                            cmbPaymentMethod.SelectedValue = order.PaymentMethodID;
                            cmbPaymentMethod_SelectedIndexChanged(sender, e);
                            if (order.BankID != null)
                            {
                                if (order.BankID != 0)
                                {
                                    cmbBankId.SelectedValue = order.BankID;
                                }
                            }
                            txtCheckNO.Text = order.CheckORCardNo;
                            if (order.CheckDate != null)
                            {
                                dtpChequeDate.Value = Convert.ToDateTime(order.CheckDate);
                            }
                            txtNameOfTheCard.Text = order.NameOnTheCard;
                            if (order.TypeOfCard != null)
                            {
                                if (order.TypeOfCard != 0)
                                {
                                    cmbTypeOfCard.SelectedValue = order.TypeOfCard;
                                    //cmbTypeOfCard.SelectedValue = order.TypeOfCard;
                                }
                            }
                            txtNameOfIssure.Text = order.NameOfIssuer;
                        }
                        foreach (
                            OrderDetail orderDetail in posContext.OrderDetails.Where(id => id.OrderID == orderMstID))
                        {
                            dgvItemList.Rows.Add(0,
                                0,
                                orderDetail.ItemID,
                                orderDetail.Stock.Code,
                                 orderDetail.Stock.Code,
                                orderDetail.Stock.ItemInfo.Name,
                                "",
                                "",
                                "",
                                orderDetail.UnitPrice,
                                orderDetail.TaxRate,
                                orderDetail.DiscountAmount,
                                orderDetail.SalePrice,
                                Convert.ToDecimal(orderDetail.Quantity).ToString("N0"),
                                orderDetail.TotalPrice,
                                orderDetail.Stock.ClosingStock,
                                null
                                );
                        }
                        btnPrint.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            //Control_KeyPress(sender, null);
            double SubTotal = 0, itemsWiseDiscount = 0, Discount = 0, Vat = 0, Total = 0;
            if (!string.IsNullOrEmpty(txtSubTotal.Text))
            {
                SubTotal = Convert.ToDouble(txtSubTotal.Text);
                itemsWiseDiscount = Convert.ToDouble(lblTotDiscount.Text);
                if (!string.IsNullOrEmpty(txtDiscountAmount.Text))
                {
                    Discount = Convert.ToDouble(txtDiscountAmount.Text);
                }
                else
                {
                    Discount = 0;
                }
                Vat = Convert.ToDouble(txtVATAmount.Text);

                txtGrandTotal.Text = ((Vat + SubTotal) - (itemsWiseDiscount + Discount)).ToString("N2");
                txtDue.Text = txtGrandTotal.Text;

                //txtDiscountParcent.Enabled = false;
            }
        }

        private void txtDiscountParcent_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiscountParcent.Text))
            {
                txtDiscountParcent.Text = "0";
            }
            txtDiscountAmount.Text =
                ((Convert.ToDouble(txtSubTotal.Text) * Convert.ToDouble(txtDiscountParcent.Text)) / 100).ToString("N2");
           // txtDiscountAmount.Enabled = false;
        }

        private void txtDiscountParcent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCashReceived.Focus();
            }
        }

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCashReceived.Focus();
            }
        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnNew.Focus();
            }
        }

        private void txtVATAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubTotal.Text))
            {
                //if (string.IsNullOrEmpty(txtVatRate.Text))
                //{
                //    txtVatRate.Text = "0";
                //}

                if (string.IsNullOrEmpty(txtVATAmount.Text))
                {
                    txtVATAmount.Text = "0";
                }

                if (string.IsNullOrEmpty(txtSubTotal.Text))
                {
                    txtSubTotal.Text = "0";
                }


                if (string.IsNullOrEmpty(txtGrandTotal.Text))
                {
                    txtGrandTotal.Text = "0";
                }

                if (string.IsNullOrEmpty(lblTotDiscount.Text))
                {
                    lblTotDiscount.Text = "0";
                }

                if (string.IsNullOrEmpty(txtDiscountAmount.Text))
                {
                    txtDiscountAmount.Text = "0";
                }
                if (string.IsNullOrEmpty(txtCashReceived.Text))
                {
                    txtCashReceived.Text = "0";
                }
                if (string.IsNullOrEmpty(txtDue.Text))
                {
                    txtDue.Text = "0";
                }

                //  txtDiscountAmount.Text = (((Convert.ToDouble(txtSubTotal.Text) - Convert.ToDouble(lblTotDiscount.Text) - Convert.ToDouble(txtDiscountAmount.Text)) * Convert.ToDouble(txtVatRate.Text)) / 100).ToString("N2");
                // txtDiscountAmount.Text=
                //txtVATAmount.Text =
                //    (((Convert.ToDouble(txtSubTotal.Text) - Convert.ToDouble(lblTotDiscount.Text) - Convert.ToDouble(txtDiscountAmount.Text)) * Convert.ToDouble(txtVatRate.Text)) / 100).ToString("N2");

                txtGrandTotal.Text = Math.Round((Convert.ToDouble(txtVATAmount.Text) + (Convert.ToDouble(txtSubTotal.Text) - Convert.ToDouble(lblTotDiscount.Text) - Convert.ToDouble(txtDiscountAmount.Text))), MidpointRounding.AwayFromZero).ToString();
                txtDue.Text = (Convert.ToDouble(txtGrandTotal.Text) - Convert.ToDouble(txtCashReceived.Text)).ToString();
                txtCashRefund.Text = (Convert.ToDouble(txtCashReceived.Text) - Convert.ToDouble(txtGrandTotal.Text)).ToString("N0");
                txtGrandTotal.Text = txtGrandTotal.Text;
            }
        }

          
    }
}
