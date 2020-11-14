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
    public partial class frmPurhaseAprovedInfo : Form
    {
        public frmPurhaseAprovedInfo()
        {
            InitializeComponent();
        }

        private void dgPurchaseInformation_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmPurhaseAprovedInfo_Load(object sender, EventArgs e)
        {
            using (var posContext = new Digital_AppEntities())
            {
                dgPurchaseInformation.Rows.Clear();
                foreach (View_PurchaseInformation aView_PurchaseInformation in posContext.View_PurchaseInformation.ToList().OrderByDescending(a => a.ID))
                {
                    dgPurchaseInformation.Rows.Add(aView_PurchaseInformation.ID, aView_PurchaseInformation.PODate, aView_PurchaseInformation.PoCode, aView_PurchaseInformation.FarmerName, aView_PurchaseInformation.SupplierMobileNo, aView_PurchaseInformation.ItemQuantity, aView_PurchaseInformation.Total, aView_PurchaseInformation.Satt);
                }

            }
        }
    }
}
