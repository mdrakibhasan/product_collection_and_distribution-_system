using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace UYSYS.POS.App_Code
{
    class SMSGEtwayCode
    {
        public void SampleTestHttpApi(string Number, string SMSText, string userID, string password)
        {
            var url = "your sms Api link here"; // your powersms site url; register the ip first
            var request = HttpWebRequest.Create(url);
            //var userId = "your_user_id_here";
            //var password = "your_password";
            //var smsText = "This is a sample sms text.";
            var receiverList = new[] { "01600000000", "01710000000", "01900000000" };
            var receiversParam = string.Join(",", receiverList); // If you want to send only to a single receiver, skip string.Join()
            var dataFormat = "userId={0}&password={1}&smsText={2}&commaSeperatedReceiverNumbers={3}";
            var urlEncodedData = Uri.EscapeUriString(string.Format(dataFormat, userID, password, SMSText, Number));
            var data = Encoding.ASCII.GetBytes(urlEncodedData);
            request.Method = "post";
            request.Proxy = null;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }

            //try
            //{
            //    using (var response = (HttpWebResponse)request.GetResponse())
            //    {
            //        dynamic responseObject = ParseResponse(response);

            //        if (responseObject.isError == "true")
            //        {
            //            throw new Exception(string.Format("Sms Sending was failed. Because: {0}", responseObject.message));
            //        }
            //    }
            //}
            //catch (WebException e)
            //{
            //    dynamic responseObject = ParseResponse(e.Response);

            //    if (responseObject.isError == "true")
            //    {
            //        throw new Exception("Sms Sending was failed. Because: " + responseObject.message);
            //    }
            //}
        }

        private static object ParseResponse(WebResponse r)
        {
            var response = (HttpWebResponse)r;

            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                using (var responseReader = new StreamReader(responseStream))
                {
                    string errorResponse = responseReader.ReadToEnd();

                    try
                    {
                        return JsonConvert.DeserializeObject(errorResponse);
                    }
                    catch
                    {
                        throw new Exception(string.Format("The sms service calling was unsuccessful with code:{0}[{1}]", (int)response.StatusCode, response.StatusCode));
                    }
                }
            }

            throw new Exception("Response stream found null.");
        }
    }
}
