using Digital_app;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.DataModel;
using View.DBManager;

namespace View.Reports
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

      
        DataTable dtItemsTransferReceivedForReport = null;
        public DataTable dtItemDetailsReport = null;
        DataTable dtItemSalesSummery = new DataTable();
        DataTable dtView_GiftItemInformationForReport = null;

        private List<CompanyInfo> vrCompanyInfo;
        public DataTable dtOrderInfoForMoneyReceipt = null;
       
        private static frmReportViewer _frmReportViewer;
        public DataTable dtTotalSalesHistory = null;
        public DataTable dtvrOrderForReport = null;
        public DataTable dtTotalSalesReturn = null;
        public DataTable dtTotalExchangeDtls = null;
        public DataTable ExchangeInfoForMoneyReceiptMst = null;
       private DataTable ExchangeDetailsInfoForReport = new DataTable();

       
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.View_GetItemPurchaseMst' table. You can move, or remove it, as needed.
           // this.View_GetItemPurchaseMstTableAdapter.Fill(this.DataSet1.View_GetItemPurchaseMst);
            rdbPurchaseInfo.Checked = true;
            pnlSearch.Visible = true;
            grbStocksearch.Visible = false;
           // this.rptOthersreportviewer.RefreshReport();
        }
        public void GetOrderInfoForMoneyReceipt(string reportType, string invoiceNo, bool GiftInvoice)
        {
            //using (var posContext = new Digital_AppEntities())
            //{
            //    if (ConfigurationManager.AppSettings["MR"].ToString() == "1")
            //    {
            //        orderInfoForMoneyReceipt = posContext.OrderInfoForMoneyReceipts.Where(id => id.InvoiceNo == invoiceNo).ToList();
            //    }
            //    else
            //    {
            //        orderForMoneyReceipt = posContext.GetOrderInfoForMoneyReceipt(invoiceNo).ToList();
            //    }
            //}
            //GiftInvoiceNo = GiftInvoice;
            //this.GenerateReport(reportType);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbPurchaseInfo.Checked)
            {
                using (var posContext = new Digital_AppEntities())
                {
                    DataTable dt = IdManager.GetShowDataTable("Select  * from dbo.View_GetItemPurchaseDetails where  Convert(date,PODate,103) between Convert(date,'" + dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + "',103) and Convert(date,'" + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy") + "',103)");
                    List<CompanyInfo> ACompany = posContext.CompanyInfoes.ToList();
                    DataTable dtCompany = Global.LINQToDataTable(ACompany);
                    rptOthersreportviewer.ProcessingMode = ProcessingMode.Local;

                    string exeFolder = Application.StartupPath;
                    //string reportPath = Path.Combine(exeFolder, @"Reports\PurchaseInfo.rdlc");
                    rptOthersreportviewer.LocalReport.ReportEmbeddedResource = "View.Reports.rptPurchaseInformation.rdlc";

                    ReportDataSource rds = new ReportDataSource("View_GetItemPurchaseDetails", dt);
                    rptOthersreportviewer.LocalReport.DataSources.Clear();
                    rptOthersreportviewer.LocalReport.DataSources.Add(rds);

                    rptOthersreportviewer.LocalReport.SetParameters(new ReportParameter("ReportDate", dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy")));
                    rptOthersreportviewer.LocalReport.DataSources.Add(new ReportDataSource("Company", dtCompany));

                    rptOthersreportviewer.LocalReport.Refresh();
                    rptOthersreportviewer.RefreshReport();
                }
            }
            else if(rdbPurchaseStaus.Checked)
            {
                using (var posContext = new Digital_AppEntities())
                {
                    DataTable dt = IdManager.GetShowDataTable("Select  * from dbo.View_ItemStatusDetails where  Convert(date,PODate,103) between Convert(date,'" + dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + "',103) and Convert(date,'" + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy") + "',103)");
                    List<CompanyInfo> ACompany = posContext.CompanyInfoes.ToList();
                    DataTable dtCompany = Global.LINQToDataTable(ACompany);
                    rptOthersreportviewer.ProcessingMode = ProcessingMode.Local;

                    string exeFolder = Application.StartupPath;
                    //string reportPath = Path.Combine(exeFolder, @"Reports\PurchaseInfo.rdlc");
                    rptOthersreportviewer.LocalReport.ReportEmbeddedResource = "View.Reports.rptPurchaseStatusDetyails.rdlc";

                    ReportDataSource rds = new ReportDataSource("View_ItemStatusDetails", dt);
                    rptOthersreportviewer.LocalReport.DataSources.Clear();
                    rptOthersreportviewer.LocalReport.DataSources.Add(rds);

                    rptOthersreportviewer.LocalReport.SetParameters(new ReportParameter("ReportDate", dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy")));
                    rptOthersreportviewer.LocalReport.DataSources.Add(new ReportDataSource("Company", dtCompany));

                    rptOthersreportviewer.LocalReport.Refresh();
                    rptOthersreportviewer.RefreshReport();
                }
            }

            else if (rdbReceivedInfo.Checked)
            {
                using (var posContext = new Digital_AppEntities())
                {
                    DataTable dt = IdManager.GetShowDataTable("Select  * from dbo.View_ProductReceiveDetailsForReport where  Convert(date,PODate,103) between Convert(date,'" + dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + "',103) and Convert(date,'" + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy") + "',103)  and Satatus='R'");
                    List<CompanyInfo> ACompany = posContext.CompanyInfoes.ToList();
                    DataTable dtCompany = Global.LINQToDataTable(ACompany);
                    rptOthersreportviewer.ProcessingMode = ProcessingMode.Local;

                    string exeFolder = Application.StartupPath;
                    //string reportPath = Path.Combine(exeFolder, @"Reports\PurchaseInfo.rdlc");
                    rptOthersreportviewer.LocalReport.ReportEmbeddedResource = "View.Reports.rptProductReceivedInformation.rdlc";

                    ReportDataSource rds = new ReportDataSource("View_ProductReceiveDetailsForReport", dt);
                    rptOthersreportviewer.LocalReport.DataSources.Clear();
                    rptOthersreportviewer.LocalReport.DataSources.Add(rds);

                    rptOthersreportviewer.LocalReport.SetParameters(new ReportParameter("ReportDate", dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy")));
                    rptOthersreportviewer.LocalReport.DataSources.Add(new ReportDataSource("Company", dtCompany));

                    rptOthersreportviewer.LocalReport.Refresh();
                    rptOthersreportviewer.RefreshReport();
                }
            }

            else if (rdbSalesInfo.Checked)
            {
                using (var posContext = new Digital_AppEntities())
                {
                    DataTable dt = IdManager.GetShowDataTable("Select  * from dbo.View_SalesDetailsReport where  Convert(date,OrderDate,103) between Convert(date,'" + dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + "',103) and Convert(date,'" + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy") + "',103)");
                    List<CompanyInfo> ACompany = posContext.CompanyInfoes.ToList();
                    DataTable dtCompany = Global.LINQToDataTable(ACompany);
                    rptOthersreportviewer.ProcessingMode = ProcessingMode.Local;

                    string exeFolder = Application.StartupPath;
                    //string reportPath = Path.Combine(exeFolder, @"Reports\PurchaseInfo.rdlc");
                    rptOthersreportviewer.LocalReport.ReportEmbeddedResource = "View.Reports.rptSalesReport.rdlc";

                    ReportDataSource rds = new ReportDataSource("View_SalesDetailsReport", dt);
                    rptOthersreportviewer.LocalReport.DataSources.Clear();
                    rptOthersreportviewer.LocalReport.DataSources.Add(rds);

                    rptOthersreportviewer.LocalReport.SetParameters(new ReportParameter("ReportDate", dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy")));
                    rptOthersreportviewer.LocalReport.DataSources.Add(new ReportDataSource("Company", dtCompany));

                    rptOthersreportviewer.LocalReport.Refresh();
                    rptOthersreportviewer.RefreshReport();
                }
            }
            else if (rdbprofitLoss.Checked)
            {
                using (var posContext = new Digital_AppEntities())
                {
                    DataTable dt = IdManager.GetShowDataTable("Select  * from dbo.DailyStatus where  Convert(date,Date,103) between Convert(date,'" + dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + "',103) and Convert(date,'" + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy") + "',103)");
                    List<CompanyInfo> ACompany = posContext.CompanyInfoes.ToList();
                    DataTable dtCompany = Global.LINQToDataTable(ACompany);
                    rptOthersreportviewer.ProcessingMode = ProcessingMode.Local;
                    DataTable dt2 = IdManager.GetShowDataTable("SELECT     SUM(Expanse) AS Expanse, SUM(Revenue) AS Revenue, SUM(Profit) AS Profit FROM dbo.DailyStatus where  Convert(date,Date,103) between Convert(date,'" + dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + "',103) and Convert(date,'" + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy") + "',103)");
                   
                    string exeFolder = Application.StartupPath;
                    //string reportPath = Path.Combine(exeFolder, @"Reports\PurchaseInfo.rdlc");
                    rptOthersreportviewer.LocalReport.ReportEmbeddedResource = "View.Reports.rptprofitandloss.rdlc";

                    ReportDataSource rds = new ReportDataSource("ProfitLoss", dt);
                    rptOthersreportviewer.LocalReport.DataSources.Clear();
                    rptOthersreportviewer.LocalReport.DataSources.Add(rds);

                    rptOthersreportviewer.LocalReport.SetParameters(new ReportParameter("ReportDate", dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy")));
                    rptOthersreportviewer.LocalReport.DataSources.Add(new ReportDataSource("Company", dtCompany));
                    rptOthersreportviewer.LocalReport.DataSources.Add(new ReportDataSource("Status", dt2));

                    rptOthersreportviewer.LocalReport.Refresh();
                    rptOthersreportviewer.RefreshReport();
                }
            }
           
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchItem.TextLength > 0)
            {
                using (var posContext = new Digital_AppEntities())
                {

                    LBSearchItem.Location = new System.Drawing.Point(128, 362);
                    LBSearchItem.Width = 186;
                    LBSearchItem.Height = 150;
                    
                    //vrEmployee=posContext.View_Employee.ToList();
                   // var aItemInformations = posContext.ItemInfoes.Where(a => a.Active == true && (a.Name+a.Code).ToUpper().Contains(txtSearchItem.Text.ToUpper())).ToList();
                    List<ItemInfo> aItemInformations = posContext.ItemInfoes.Where(a => a.Active == true && (a.Name + a.Code).ToUpper().Contains(txtSearchItem.Text.ToUpper())).ToList();
                    if (aItemInformations.Count > 0)
                    {


                        DataTable dtCompany = Global.LINQToDataTable(aItemInformations);
                        LBSearchItem.DataSource = dtCompany;
                        LBSearchItem.DisplayMember = "Name";
                        LBSearchItem.ValueMember = "ID";
                        LBSearchItem.Visible = true;
                    }
                    else
                    {
                        LBSearchItem.Visible = false;
                    }
                   
                    //btnSave.Focus();
                }
            }
            else
            {
                lblItemID.Text = "";
                LBSearchItem.Visible = false;
            }
        }

        private void txtSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LBSearchItem.Focus();
            }

            
        }

        private void LBSearchItem_MouseClick(object sender, MouseEventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {

                ItemInfo aItemInfo = posContext.ItemInfoes.SingleOrDefault(a => a.ID == (int)LBSearchItem.SelectedValue);
                if (aItemInfo != null)
                {
                    txtSearchItem.Text = aItemInfo.Name;
                    lblItemID.Text = aItemInfo.ID.ToString();
                    LBSearchItem.Visible = false;
                }
                else
                {
                    txtSearchItem.Text = lblItemID.Text = "";
                    LBSearchItem.Visible = false;
                }
            }
        }

        private void LBSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {

                ItemInfo aItemInfo = posContext.ItemInfoes.SingleOrDefault(a => a.ID == (int)LBSearchItem.SelectedValue);

                if (aItemInfo != null)
                {
                    txtSearchItem.Text = aItemInfo.Name;
                    lblItemID.Text = aItemInfo.ID.ToString();
                    LBSearchItem.Visible = false;
                }
                else
                {
                    txtSearchItem.Text = lblItemID.Text = "";
                    LBSearchItem.Visible = false;
                }
            }
        }

        private void rdbStock_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbStock.Checked)
            {
                rdbAll.Checked = true;
                grbStocksearch.Visible = true;
                pnlSearch.Visible = false;

            }
            else
            {
                pnlSearch.Visible = true;
                grbStocksearch.Visible = false;                

            }
        }

        private void btnStockShow_Click(object sender, EventArgs e)
        {
              if (rdbStock.Checked)
            {
                using (var posContext = new Digital_AppEntities())
                {
                    List<ItemWithUOM> astock =null;
                    int ItemID = 0;
                    if (lblItemID.Text != "")
                    {
                        ItemID=Convert.ToInt32(lblItemID.Text);
                    }
                    if (rdbAll.Checked)
                    {
                        if(lblItemID.Text!="")
                            astock = posContext.ItemWithUOMs.Where(a => a.UOMID == ItemID).ToList();
                        else
                            astock = posContext.ItemWithUOMs.ToList();
                    }
                    else if (rdbAvailable.Checked)
                    {
                        if (lblItemID.Text != "")
                            astock = posContext.ItemWithUOMs.Where(a => a.UOMID == ItemID && a.UnitsInStock > 0).ToList();
                        else
                        astock = posContext.ItemWithUOMs.Where(a => a.UnitsInStock > 0).ToList();
                    }
                    else if (rdbAvailable.Checked)
                    {
                        if (lblItemID.Text != "")
                            astock = posContext.ItemWithUOMs.Where(a => a.UOMID == ItemID && a.UnitsInStock <= 0).ToList();
                        else
                        astock = posContext.ItemWithUOMs.Where(a => a.UnitsInStock <=0).ToList();
                    }

                    DataTable dtStock = Global.LINQToDataTable(astock);
                    List<CompanyInfo> ACompany = posContext.CompanyInfoes.ToList();
                    DataTable dtCompany = Global.LINQToDataTable(ACompany);
                    rptOthersreportviewer.ProcessingMode = ProcessingMode.Local;

                    string exeFolder = Application.StartupPath;
                    //string reportPath = Path.Combine(exeFolder, @"Reports\PurchaseInfo.rdlc");
                    rptOthersreportviewer.LocalReport.ReportEmbeddedResource = "View.Reports.rptStockInfo.rdlc";

                    ReportDataSource rds = new ReportDataSource("StockInfo", dtStock);
                    rptOthersreportviewer.LocalReport.DataSources.Clear();
                    rptOthersreportviewer.LocalReport.DataSources.Add(rds);

                    //ptOthersreportviewer.LocalReport.SetParameters(new ReportParameter("ReportDate", dtpStartDate.Value.Date.ToString("dd/MM/yyyy") + " To " + dtpEmdDate.Value.Date.ToString("dd/MM/yyyy")));
                    rptOthersreportviewer.LocalReport.DataSources.Add(new ReportDataSource("Company", dtCompany));

                    rptOthersreportviewer.LocalReport.Refresh();
                    rptOthersreportviewer.RefreshReport();
                }
            }
        }
    }
}
