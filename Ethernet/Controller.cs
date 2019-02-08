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

        private const int PORT = 54143;

        private Action<dynamic> update;

        private volatile object locker;

        public string Url { get; private set; } = "http://{0}:{1}/{2}";

        public void AddUpdater(Action<dynamic> updater)
        {
            update = updater;
            GetUpdatesFromServer();
        }

        public Controller(string url, string servicePath)
        {
            this.Url = string.Format(this.Url, url, PORT, servicePath);
            locker = new object();
        }

        private Task GetUpdatesFromServer()
        {
            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        var response = SendRequest("GET");

                        dynamic d = JsonConvert.DeserializeObject(response);
                        dynamic a = JsonConvert.DeserializeObject(d);

                        update.Invoke(a);
                    }
                    catch
                    {
                    }

                    Thread.Sleep(DELAY);
                }
            });

            return task;
        }

        private class Hello
        {
            public string Message { get; set; } = "hello";
            public string Name { get; private set; }

            public Hello(string name)
            {
                Name = name;
            }
        }

        private class GoodBye
        {
            public string Message { get; set; } = "goodbye";
            public string Name { get; private set; }

            public GoodBye(string name)
            {
                Name = name;
            }
        }

        public string SendHello(string name = "")
        {
            return SendRequest("POST", JsonConvert.SerializeObject(new Hello(name)));
        }

        public void SendGoodBye(string name)
        {
            SendRequest("POST", JsonConvert.SerializeObject(new GoodBye(name)));
        }

        public string SendRequest(string methodType, string data = null)
        {
            var req = (HttpWebRequest)WebRequest.Create(Url);
            req.Method = methodType;
            req.Timeout = TIMEOUT;
            req.ContentType = JSON_DATA_TYPE;

            /*
            var a = new WebProxy("192.168.10.2", 8080);
            a.Credentials = new NetworkCredential("aqua_phoenix", "Oltain");

            req.Proxy = a;
            */

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            if (data != null)
            {
                byte[] byteData = Encoding.UTF8.GetBytes(data);
                req.ContentLength = byteData.Length;
                using (System.IO.Stream sendStream = req.GetRequestStream())
                {
                    sendStream.Write(byteData, 0, byteData.Length);
                }
            }

            var response = req.GetResponse();

            var result = ExtractString(response);

            response.Close();

            return result;
        }

        private string ExtractString(WebResponse webRespons)
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