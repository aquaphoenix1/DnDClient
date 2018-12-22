using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethernet
{
    public class Controller
    {
        private const int TIMEOUT = 4000;
        private const string JSON_DATA_TYPE = "application/json; charset=utf-8";
        private const int DELAY = 100;

        private Action<dynamic> update;
        private string url = "http://{0}:{1}/{2}";

        public void AddUpdater(Action<dynamic> updater)
        {
            update = updater;
            GetUpdatesFromServer();
        }

        public Controller(string url, int port, string servicePath)
        {
            this.url = string.Format(this.url, url, port, servicePath);
        }

        private Task GetUpdatesFromServer()
        {
            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var response = SendRequest("GET");
                    update.Invoke(extractString(response));
                    Thread.Sleep(DELAY);
                }
            });

            return task;
        }

        public WebResponse SendRequest(string methodType, string data = null)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = methodType;
            req.Timeout = TIMEOUT;
            req.ContentType = JSON_DATA_TYPE;

            /*var a = new WebProxy("192.168.10.2", 8080);
            a.Credentials = new NetworkCredential("aqua_phoenix", "Oltain");

            req.Proxy = a;*/

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            if (data != null)
            {
                byte[] byteData = Encoding.UTF8.GetBytes(data);
                req.ContentLength = byteData.Length;
                using (System.IO.Stream sendStream = req.GetRequestStream())
                    sendStream.Write(byteData, 0, byteData.Length);
            }

            return req.GetResponse();
        }

        internal string extractString(WebResponse webRespons)
        {
            var resStr = string.Empty;
            using (System.IO.Stream responceStream = webRespons.GetResponseStream())
            using (System.IO.StreamReader streamReader = new System.IO.StreamReader(responceStream, Encoding.UTF8))
            {
                resStr = streamReader.ReadToEnd();
            }
            return resStr;
        }

    }
}