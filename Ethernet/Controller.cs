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

        private volatile object locker;

        public string Url { get; private set; } = "http://{0}:{1}/{2}";

        public void AddUpdater(Action<dynamic> updater)
        {
            update = updater;
            GetUpdatesFromServer();
        }

        public Controller(string url, int port, string servicePath)
        {
            this.Url = string.Format(this.Url, url, port, servicePath);
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

                        string str = ExtractString(response);

                        dynamic d = JsonConvert.DeserializeObject(str);
                        dynamic a = JsonConvert.DeserializeObject(d);

                        update.Invoke(a);
                    }
                    catch
                    {
                        update.Invoke("Ошибка подключения к серверу");
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

        public WebResponse SendHello(string name = "")
        {
            return SendRequest("POST", JsonConvert.SerializeObject(new Hello(name)));
        }

        public void SendGoodBye(string name)
        {
            SendRequest("POST", JsonConvert.SerializeObject(new GoodBye(name)));
        }

        public WebResponse SendRequest(string methodType, string data = null)
        {
            lock (locker)
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

                return req.GetResponse();
            }
        }

        public string ExtractString(WebResponse webRespons)
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