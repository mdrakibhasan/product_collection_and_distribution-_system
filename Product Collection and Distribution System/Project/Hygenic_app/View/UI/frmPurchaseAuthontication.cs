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
    public partial class frmPurchaseAuthontication : Form
    {
        public frmPurchaseAuthontication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            for(int i =0; i<= dgPurchaseInformation.Rows.Count-1;i++)
            {
                ItemPurchaseMst aItemPurchaseMst;
                using (var posContext = new Digital_AppEntities())
                {
                    try
                    {
                        string Cmb = dgPurchaseInformation.Rows[i].Cells["Recommended"].Value.ToString();
                        DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dgPurchaseInformation.Rows[i].Cells["Recommended"];
                        string SIndex = comboCell.Items.IndexOf(comboCell.Value).ToString();
                        int ids = (int)dgPurchaseInformation.Rows[i].Cells[0].Value;

                        aItemPurchaseMst = posContext.ItemPurchaseMsts.SingleOrDefault(s => s.ID == ids);

                        if (SIndex == "0")
                        {
                            aItemPurchaseMst.Satatus = "A";
                            
                        }
                        else if (SIndex == "1")
                        {
                            aItemPurchaseMst.Satatus = "C";
                            
                        }
                        else if (SIndex == "2")
                        {
                            aItemPurchaseMst.Satatus = "S";
                            ProductReceivedMst aProductReceivedMst;
                            {
                                aProductReceivedMst = new ProductReceivedMst();
                                aProductReceivedMst.ReceivedAmount = 0;
                                aProductReceivedMst.LaberCost = 0;
                                aProductReceivedMst.ShippingCost = 0;
                                aProductReceivedMst.CollectedMstID = aItemPurchaseMst.ID;
                                aProductReceivedMst.CollectedCode = aItemPurchaseMst.PO;
                                aProductReceivedMst.AddBy = Global.UserLoginID;
                                aProductReceivedMst.AddDate = DateTime.Now;
                                aProductReceivedMst.AgentID = aItemPurchaseMst.CreatedBy;

                                posContext.ProductReceivedMsts.Add(aProductReceivedMst);
                                posContext.SaveChanges();
                                foreach (DataGridViewRow dr in dgvItemPurchaseDetail.Rows)
                                {
                                    ProductReceivedDtl aProductCollectedDtl;
                                    aProductCollectedDtl = new ProductReceivedDtl();
                                    aProductCollectedDtl.MstID = aProductReceivedMst.ID;
                                    aProductCollectedDtl.ProductID = Convert.ToInt32(dr.Cells["colItemID"].Value);
                                    aProductCollectedDtl.PurchasePrice = Convert.ToDecimal(dr.Cells["colUnitPrice"].Value);
                                    aProductCollectedDtl.Quantity = Convert.ToDecimal(dr.Cells["colQuantity"].Value);
                                    aProductCollectedDtl.Total = Convert.ToDecimal(dr.Cells["colTotal"].Value);
                                    aProductCollectedDtl.SalePrice = Convert.ToDecimal(dr.Cells["ColSalesPrice"].Value);
                                    aProductCollectedDtl.ProductCode = dr.Cells["colItemCode"].Value.ToString();
                                    posContext.ProductReceivedDtls.Add(aProductCollectedDtl);
                                    posContext.SaveChanges();
                                }
                               

                                
                            }


                        }
                        if (SIndex != "3")
                        {
                            PurchaseHistory aPurchaseHistory;
                            aPurchaseHistory = new PurchaseHistory();
                            aPurchaseHistory.PurchaseID = aItemPurchaseMst.ID;
                            aPurchaseHistory.StatusType = aItemPurchaseMst.Satatus;
                            aPurchaseHistory.AddDate = DateTime.Now;
                            aPurchaseHistory.AddBy = Global.UserLoginID;
                            aPurchaseHistory.StatusDescription = Cmb;
                            posContext.PurchaseHistories.Add(aPurchaseHistory);
                            posContext.SaveChanges();


                        }
                        

                        

                    }
                    catch
                    {

                    }
                }
               
               
            }
            MessageBox.Show("Record are Save Successfully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cleardata();
        }
        private void Cleardata()
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgPurchaseInformation.Rows.Clear();
                foreach (View_PurchaseInformation aView_PurchaseInformation in posContext.View_PurchaseInformation.Where(a => a.Satatus != "S" && a.Satatus != "R" && a.Satatus != null).ToList().OrderByDescending(a => a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, aView_PurchaseInformation.PODate, aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total, aView_PurchaseInformation.Satt, "Panding");
                }

            }
        }

        private void frmPurchaseAuthontication_Load(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void dgPurchaseInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                short itemPurchaseMstID = Convert.ToInt16(dgPurchaseInformation.Rows[e.RowIndex].Cells[0].Value);
                int index = 0;
                dgvItemPurchaseDetail.Rows.Clear();
                foreach (View_GetItemPurchaseDetails result in posContext.View_GetItemPurchaseDetails.Where(c => c.ItemPurchaseMstID == itemPurchaseMstID).ToList())
                {
                    dgvItemPurchaseDetail.Rows.Add();
                    dgvItemPurchaseDetail.Rows[index].Cells["colID"].Value = result.ID;
                    dgvItemPurchaseDetail.Rows[index].Cells["colItemID"].Value = result.ItemID;
                    dgvItemPurchaseDetail.Rows[index].Cells["colItemCode"].Value = result.ItemCode;

                    //dgvItemPurchaseDetail.Rows[index].Cells["BatchNo"].Value = result.i;
                    // dgvItemPurchaseDetail.Rows[index].Cells["colItemCode"].Value = result.ItemCode;
                    dgvItemPurchaseDetail.Rows[index].Cells["ColSalesPrice"].Value = result.SalePrice;
                    dgvItemPurchaseDetail.Rows[index].Cells["colItemName"].Value = result.ItemName;
                    dgvItemPurchaseDetail.Rows[index].Cells["colItemPurchaseMstID"].Value = result.ItemPurchaseMstID;
                    dgvItemPurchaseDetail.Rows[index].Cells["colUnitPrice"].Value = result.UnitPrice;
                    dgvItemPurchaseDetail.Rows[index].Cells["colQuantity"].Value = result.Quantity;
                    dgvItemPurchaseDetail.Rows[index].Cells["colTotal"].Value = result.Total;
                    //dgPurchaseInformation.Rows[index].Cells["Expairedate"].Value = result.ExpireDate;
                    index++;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgPurchaseInformation.Rows.Clear();
                foreach (View_PurchaseInformation aView_PurchaseInformation in posContext.View_PurchaseInformation.Where(a => a.Satatus != "S" && a.Satatus != "R" && a.Satatus != null && (a.PoCode+a.Satt+a.SupplierMobileNo+a.FarmerName).Contains(textBox1.Text)).ToList().OrderByDescending(a => a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, aView_PurchaseInformation.PODate, aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total, aView_PurchaseInformation.Satt, "Panding");
                }

            }
        }
    }
}
