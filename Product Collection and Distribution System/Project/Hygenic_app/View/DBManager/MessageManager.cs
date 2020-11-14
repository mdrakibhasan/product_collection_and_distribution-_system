using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.DBManager
{
    class MessageManager
    {

        public static string CompanySaved = "Company information saved successfully.";
        public static string ItemTransferSaved = "Item Transfer saved successfully.";

        public static string ApplicationCloseConfirmationMsg = "Are you sure you want to close this application?";
        public static string CommonExceptionMsg = "An unexpected exception has occurred. Please try again.";

        public static string RecordDeleteConfirmationMsg = "Are you sure you want to delete this record?";

        public static string CategoryRequired = "Category is required.";

        public static string BackUpFilePathRequired = "Please select a backup file path.";
        public static string BackUpFailed = "Backup failed for " + Global.ApplicationNameWithVersion + ".";
        public static string BackUpSucceeded = "The backup of database " + Global.ApplicationNameWithVersion + " completed successfully.";

        public static string PasswordMatchRequired = "New Password and Confirm Password do not exactly match.";
        public static string PasswordChanged = "Password changed successfully.";
        public static string GroupPrivilegeSaved = "Group privilege saved successfully.";

        public static string GetDuplicateErrorMsg(string recordType)
        {
            return "Cannot insert duplicate " + recordType + ".";
        }

        #region FormName

        public static string frmOrder = "frmOrder";
        public static string frmOrderReturn = "frmOrderReturn";
        public static string frmItemPurchase = "frmItemPurchase";
        public static string frmItemPurchaseReturn = "frmItemPurchaseReturn";
        public static string frmBarcode = "frmBarcode";

        #endregion

        #region KeyValue

       // public static string VATAMOUNT = ConfigurationManager.AppSettings["VAT"].ToString();
        public static string VATTYPE = "VATTYPE";
        public static string DISCOUNTTYPE = "DISCOUNTTYPE";
        public static string VALUEGLOBAL = "GLOBAL";
        public static string DISPLAYSTYLE = "DISPLAYSTYLE";
        public static string YES = "YES";
        public static string NO = "NO";

        #endregion
    }
}
