using Digital_app;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private static Login _Login;
        #region Public Properties

        public static Login Instance
        {
            get
            {
                if (_Login == null || _Login.IsDisposed)
                    _Login = new Login();
                return _Login;
            }
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (var posContext = new Digital_AppEntities())
                {
                    PasswordManager passwordManager = new PasswordManager();
                    string encryptedPassword = passwordManager.Encrypt(txtPassword.Text.Trim());

                    Global.LoggedInUser = posContext.Users.SingleOrDefault(id => id.UserName == txtUserName.Text.Trim()
                    && id.UserPassword == encryptedPassword &&
                        id.Active == true);


                    if (Global.LoggedInUser != null)
                    {
                        int grpid = (int)Global.LoggedInUser.UserGroupID;
                        Global.LoggedInUserGroup = posContext.UserGroups.SingleOrDefault(id => id.ID == grpid);

                       // int MainBranchID = IdManager.GetShowSingleValueInt("ServerID", "MainBranch", "BranchInfo", "1");
                       // Global.MainBranchID = MainBranchID;

                        int vId = Convert.ToInt32(Global.LoggedInUser.CompanyId);
                        Global.IsLoggedIn = true;
                        Global.UserLoginID = Global.LoggedInUser.ID;
                        Global.Company = posContext.CompanyInfoes.SingleOrDefault(c => c.ID == vId);

                        if (Global.LoggedInUserGroup.ID==4)
                        {
                            AgentMaster.Instance.SetLoggedInUserToStatusStrip(Global.LoggedInUser.ID.ToString(), vId.ToString(),"0", grpid.ToString());

                            AgentMaster.Instance.Show();
                        }
                        else
                        {
                            Master.Instance.SetLoggedInUserToStatusStrip(Global.LoggedInUser, vId.ToString(), "0", grpid.ToString());
                            Master.Instance.Show();
                            
                        }
                        
                        Cursor.Current = Cursors.Default;

                        this.Close();

                        // var item = posContext.View_ItemExpired.FirstOrDefault();
                        // DateTime stardDateTime = DateTime.Parse(item.ExpireDate.ToString());
                        DateTime curreDate = DateTime.Now.AddDays(5);
                        //if (curreDate > stardDateTime)
                        //   {
                        //       DateTime stardDate = Convert.ToDateTime(DateTime.Now.AddDays(5).ToShortDateString());
                        //       var searchData =
                        //           posContext.View_ItemExpired.Where(w => w.ExpireDate == stardDate).ToList();

                        //       if (searchData.Count > 0)
                        //       {
                        //           if (
                        //               MessageBox.Show("Hi User !  You have  " + item.Quantity +"  Items Expired Date. You have  15 days remained.  If you want to show Details Please Click OK Otherwise Click Cancel  ","Warning",
                        //                   MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        //           {

                        //               frmExpiredDateInfo.Instance.MdiParent = frmPOSMDI.Instance;
                        //               frmExpiredDateInfo.Instance.Show();
                        //           }
                        //       }
                        //   }

                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;

                if (ex.InnerException != null)
                {
                    if (ex.InnerException.GetType().Name == "SqlException")
                    {
                        int errorNumber = ((System.Data.SqlClient.SqlException)(ex.InnerException)).Number;
                        switch (errorNumber)
                        {
                            case 2:
                                MessageBox.Show(ex.InnerException.Message.Substring(0, 148), Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                MessageBox.Show(ex.InnerException.Message, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                }
                else
                    MessageBox.Show(MessageManager.CommonExceptionMsg, Global.ApplicationNameWithVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
           
               
                      // isApplicationClosed = true;
                        Application.Exit();
                    
                
            
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
            }
        }
    }
}
