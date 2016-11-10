using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization; 
using System.IO;

namespace bet365_Notifier
{
    public class WhatsAppNotifier
    {
        private static string CLIENT_ID = "FREE_TRIAL_ACCOUNT";
        private static string CLIENT_SECRET = "PUBLIC_SECRET";

        private static string API_URL = "http://api.whatsmate.net/v1/whatsapp/queue/Message";

        ////private WhatsAppApi.WhatsApp whatpsApp;
        private string from;
        private string to;
        private string message;

        public bool SendMessage(string message)
        {
            ////this.from = "15125609681";
            ////this.to = "15125609681";
            ////this.message = message;

            ////whatpsApp = new WhatsAppApi.WhatsApp(from, "355688071145299", "bet365", false, false);

            ////whatpsApp.OnConnectSuccess += WhatsAppConnectSuccess;

            ////whatpsApp.OnConnectFailed += WhatsAppConnectFailure;

            ////whatpsApp.Connect();

            ////WaMessageSender msgSender = new WaMessageSender();
            ////msgSender.sendMessage("12025550108", "Isn't this excting?");
            ////Console.WriteLine("Press Enter to exit.");
            ////Console.ReadLine();
            return false;
        }

        ////private void WhatsAppConnectSuccess()
        ////{
        ////    Console.WriteLine("SUCCESS CONNECT");

        ////    whatpsApp.OnLoginSuccess += WhatsAppLoginSuccess;

        ////    whatpsApp.OnLoginFailed += WhatsAppLoginFail;

        ////    whatpsApp.Login();
        ////}

        ////private void WhatsAppConnectFailure(Exception ex)
        ////{
        ////    Console.WriteLine("FAIL CONNECT ");
        ////}

        ////private void WhatsAppLoginSuccess(string pn, byte[] data)
        ////{
        ////    whatpsApp.SendMessage(to, message);

        ////    Console.WriteLine("SUCCESS SEND");
        ////}

        ////private void WhatsAppLoginFail(string data)
        ////{
        ////    Console.WriteLine("FAIL LOGIN");
        ////}

        public bool sendMessage(string number, string message)
        {
            bool success = true;

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers["X-WM-CLIENT-ID"] = CLIENT_ID;
                    client.Headers["X-WM-CLIENT-SECRET"] = CLIENT_SECRET;

                    Payload payloadObj = new Payload() { Number = number, Message = message };
                    string postData = (new JavaScriptSerializer()).Serialize(payloadObj);

                    string response = client.UploadString(API_URL, postData);
                    Console.WriteLine(response);
                }
            }
            catch (WebException webEx)
            {
                Console.WriteLine(((HttpWebResponse)webEx.Response).StatusCode);
                Stream stream = ((HttpWebResponse)webEx.Response).GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                String body = reader.ReadToEnd();
                Console.WriteLine(body);
                success = false;
            }

            return success;
        }

        public class Payload
        {
            public string Number { get; set; }
            public string Message { get; set; }
        }

    }
}
