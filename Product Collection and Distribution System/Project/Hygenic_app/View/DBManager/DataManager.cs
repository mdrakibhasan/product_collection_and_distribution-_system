using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace Digital_app
{
    public class DataManager
    {
        public static string OraConnString()
        {
           
            return String.Format("Server=.;Database=Digital_App;User ID=sa;Password=123; Pooling=False;Trusted_Connection=False;");

        }
        internal void ShowChildFromOnMasterUI(Form f)
        {
            bool isFormOpen = false;
            foreach (Form a in Application.OpenForms)
            {
                if (f.Name == a.Name)
                {
                    isFormOpen = true;
                    break;
                }
            }
            if (isFormOpen == false)
            {
                f.Show();
            }

        }
        public static string OraConnStringServer()
        {
            return String.Format("Server=.;Database=Digital_app;User ID=sa;Password=123; Pooling=False;Trusted_Connection=False;");
        }
        public static void ExecuteNonQuery(string ConnectionString, string query)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        internal static string ExecuteScalar(string connectionString, string query)
        {
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myConnection.Open();
                    return myCommand.ExecuteScalar().ToString();
                }
            }
        }

     
        public static DataTable ExecuteQuery(string ConnectionString, string query, string tableName)
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
            using (SqlDataAdapter myAdapter = new SqlDataAdapter(query, myConnection))
                {
                    DataSet ds = new DataSet();
                    myAdapter.Fill(ds, tableName);
                    ds.Tables[0].TableName = tableName;
                    return ds.Tables[0];
                }
            }
        }
        public static string DateDecode(DateTime dt)
        {
            
            string dd = dt.Day.ToString();
            string mm = dt.Month.ToString();
            string yyyy = dt.Year.ToString();
            string d2 = dd + "/" + mm + "/" + yyyy;                 
            
            return d2;
           
        }

        public static DateTime DateEncode(string dt)
        {
            string dt1="";
            string dt2="";
            string dt3="";
            string dtf = "";
            if (dt != "")
            {
                dt1 = dt.ToString().Trim().Substring(0, 2); //day
                dt2 = dt.ToString().Trim().Substring(3, 2); //month
                dt3 = dt.ToString().Trim().Substring(6); //year
                if (dt3.Length == 2)
                {
                    dt3 = "20" + dt3;
                }
                dtf = dt2 + "/" + dt1 + "/" + dt3;
            }

            //DateTime d = DateTime.ParseExact(dtf, "dd/MM/yyyy", null);
            DateTime d = DateTime.ParseExact(dtf, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //DateTime d = DateTime.Parse(dtf);
            return d;
        }

        public static string DateEncodestring(string dt)
        {
            string dt1 = "";
            string dt2 = "";
            string dt3 = "";
            string dtf = "";
            if (dt != "")
            {
                dt1 = dt.ToString().Trim().Substring(0, 2); //day
                dt2 = dt.ToString().Trim().Substring(3, 2); //month
                dt3 = dt.ToString().Trim().Substring(6); //year
                if (dt3.Length == 2)
                {
                    dt3 = "20" + dt3;
                }
                dtf = dt2 + "/" + dt1 + "/" + dt3;
            }
            DateTime d = DateTime.Parse(dtf);
            return d.ToString();
        }

        public static DateTime DateEncode2(string dt)
        {
            string dt1 = "";
            string dt2 = "";
            string dt3 = "";
            string dtf = "";
            if (dt != "")
            {
                dt3 = dt.ToString().Trim().Substring(0,4); //year
               
                dt2 = dt.ToString().Trim().Substring(5, 2); //month
                dt1 = dt.ToString().Trim().Substring(8, 2); //day
                
                if (dt3.Length == 2)
                {
                    dt3 = "20" + dt3;
                }
                dtf = dt2 + "/" + dt1 + "/" + dt3;
            }

            //DateTime d = DateTime.ParseExact(dtf, "dd/MM/yyyy", null);
            DateTime d = DateTime.ParseExact(dtf, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //DateTime d = DateTime.Parse(dtf);
            return d;


        }

        public static string DateEncodeDMY(string YMD)
        {
            string dt1 = "";
            string dt2 = "";
            string dt3 = "";
            string dtf = "";
            if (YMD != "")
            {
                dt3 = YMD.ToString().Trim().Substring(0, 4); //year

                dt2 = YMD.ToString().Trim().Substring(5, 2); //month
                dt1 = YMD.ToString().Trim().Substring(8, 2); //day

                if (dt3.Length == 2)
                {
                    dt3 = "20" + dt3;
                }
                dtf = dt1 + "/" + dt2 + "/" + dt3;
            }

            //string d = DateTime.ParseExact(dtf, "dd/MM/yyyy", null);
            //DateTime d = DateTime.ParseExact(dtf, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //DateTime d = DateTime.Parse(dtf);
            return dtf;
        }
        public static string StringDateEncode(string dt)
        {
            string dt1 = "";
            string dt2 = "";
            string dt3 = "";
            string dtf = "";
            if (dt != "")
            {
                dt1 = dt.ToString().Trim().Substring(0, 2); //day
                dt2 = dt.ToString().Trim().Substring(3, 2); //month
                dt3 = dt.ToString().Trim().Substring(6); //year
                if (dt3.Length == 2)
                {
                    dt3 = "20" + dt3;
                }
                dtf = dt2 + "/" + dt1 + "/" + dt3+" 12:00:00 AM";
            }         
            
            return dtf;
        }
        public static string GetLiteralAmt(string amt)
        {
            String ConnectionString = DataManager.OraConnString();
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            string Query = "select dbo.initcap(dbo.in_words('"+amt+"')) ";
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(Query, myConnection);
            object maxValue = myCommand.ExecuteScalar();
            myConnection.Close();
            return maxValue.ToString();
        }

        //public string OraConnString(string host, string port, string service, string user, string pass)
        //{
        //    return String.Format(
        //        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST+{0})" +
        //    " (PORT={1})) (CONNECT_DATA=(SERVICE_NAME={2}))); User Id={3};Password{4};",
        //    host,
        //    service,
        //    user,
        //    pass);
        //}


      
        public static string GetCurrentPageName()
        {
           //// string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
           // System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
           // string sRet = oInfo.Name.Replace(".aspx","");
            return "";
        }
        public static byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }
       
        public static System.Drawing.Bitmap ResizeImage(System.Drawing.Bitmap image, int width, int height, ResizeOptions resizeOptions)
        {
            float f_width;
            float f_height;
            float dim;
            switch (resizeOptions)
            {
                case ResizeOptions.ExactWidthAndHeight:
                    return DoResize(image, width, height);

                case ResizeOptions.MaxHeight:
                    f_width = image.Width;
                    f_height = image.Height;

                    if (f_height <= height)
                        return DoResize(image, (int)f_width, (int)f_height);

                    dim = f_width / f_height;
                    width = (int)((float)(height) * dim);
                    return DoResize(image, width, height);

                case ResizeOptions.MaxWidth:
                    f_width = image.Width;
                    f_height = image.Height;

                    if (f_width <= width)
                        return DoResize(image, (int)f_width, (int)f_height);

                    dim = f_width / f_height;
                    height = (int)((float)(width) / dim);
                    return DoResize(image, width, height);

                case ResizeOptions.MaxWidthAndHeight:
                    int tmpHeight = height;
                    int tmpWidth = width;
                    f_width = image.Width;
                    f_height = image.Height;

                    if (f_width <= width && f_height <= height)
                        return DoResize(image, (int)f_width, (int)f_height);

                    dim = f_width / f_height;

                    // Check if the width is ok
                    if (f_width < width)
                        width = (int)f_width;
                    height = (int)((float)(width) / dim);
                    // The width is too width
                    if (height > tmpHeight)
                    {
                        if (f_height < tmpHeight)
                            height = (int)f_height;
                        else
                            height = tmpHeight;
                        width = (int)((float)(height) * dim);
                    }
                    return DoResize(image, width, height);
                default:
                    return image;
            }
        }
        public enum ResizeOptions
        {
            // Use fixed width & height without keeping the proportions
            ExactWidthAndHeight,

            // Use maximum width (as defined) and keeping the proportions
            MaxWidth,

            // Use maximum height (as defined) and keeping the proportions
            MaxHeight,

            // Use maximum width or height (the biggest) and keeping the proportions
            MaxWidthAndHeight
        }
        public static System.Drawing.Bitmap DoResize(System.Drawing.Bitmap originalImg, int widthInPixels, int heightInPixels)
        {
            System.Drawing.Bitmap bitmap;
            try
            {
                bitmap = new System.Drawing.Bitmap(widthInPixels, heightInPixels);
                using (System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bitmap))
                {
                    // Quality properties
                    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                    graphic.DrawImage(originalImg, 0, 0, widthInPixels, heightInPixels);
                    return bitmap;
                }
            }
            finally
            {
                if (originalImg != null)
                {
                    originalImg.Dispose();
                }
            }
        }
        public static DataTable getLogo(string book)
        {
            String connectionString = DataManager.OraConnString();
            string query = "select logo from gl_set_of_books where book_name= " + book + "";
            DataTable dt = DataManager.ExecuteQuery(connectionString, query, "Logo");
            return dt;
        }

        
    }

}