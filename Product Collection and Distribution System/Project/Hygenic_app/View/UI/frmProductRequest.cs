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
    public partial class frmProductRequest : Form
    {
        public frmProductRequest()
        {
            InitializeComponent();
        }

        private void frmProductRequest_Load(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void Cleardata()
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgPurchaseInformation.Rows.Clear();
                foreach (View_PurchaseInformation aView_PurchaseInformation in posContext.View_PurchaseInformation.Where(i=>  i.CreatedBy==Global.UserLoginID).ToList().OrderByDescending(a=>a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, aView_PurchaseInformation.PODate, aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total, aView_PurchaseInformation.Satt, "Click Request");
                }

            }
        }

        private void dgPurchaseInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==8)
            {
                ItemPurchaseMst aItemPurchaseMst;
                using (var posContext = new Digital_AppEntities())
                {
                   
                    int ids=(int)dgPurchaseInformation.Rows[e.RowIndex].Cells[0].Value;

                     aItemPurchaseMst = posContext.ItemPurchaseMsts.SingleOrDefault(s=> s.ID==ids);

                     if (aItemPurchaseMst.Satatus == "" || aItemPurchaseMst.Satatus == null)
                     {
                         aItemPurchaseMst.Satatus = "P";
                         posContext.SaveChanges();
                     }
                     else
                     {
                         MessageBox.Show("Already Request Sent", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         return;
                     }

                     PurchaseHistory aPurchaseHistory;
                    aPurchaseHistory = new PurchaseHistory(); 
                    aPurchaseHistory.PurchaseID = aItemPurchaseMst.ID;
                    aPurchaseHistory.StatusType = "P";
                    aPurchaseHistory.AddDate = DateTime.Now;
                    aPurchaseHistory.AddBy = Global.UserLoginID;
                    aPurchaseHistory.StatusDescription = "Purchase Sent Request";
                    aPurchaseHistory.ChallanNo = aItemPurchaseMst.ChallanNo;
                    aPurchaseHistory.PoDate = aItemPurchaseMst.PODate;
                    aPurchaseHistory.PurchaseCode = aItemPurchaseMst.PO;
                    aPurchaseHistory.Total = aItemPurchaseMst.Total;
                    posContext.PurchaseHistories.Add(aPurchaseHistory);
                    posContext.SaveChanges();
                    MessageBox.Show("Request Sent Successfully", Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cleardata();

                }

            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgPurchaseInformation.Rows.Clear();
                foreach (View_PurchaseInformation aView_PurchaseInformation in posContext.View_PurchaseInformation.Where(i=>(i.PoCode+i.SupplierMobileNo+i.FarmerName).Contains(textBox1.Text) && i.CreatedBy==Global.UserLoginID).ToList().OrderByDescending(a => a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, aView_PurchaseInformation.PODate, aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total, aView_PurchaseInformation.Satt, "Click Request");
                }

            }
        }
    }
}
