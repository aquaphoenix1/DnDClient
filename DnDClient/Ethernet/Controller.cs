using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DnDClient.Ethernet
{
    class Controller
    {
        private readonly int DELAY = 100;
        private string URL;

        public event Action<object> SendUpdate;

        public Controller(Action<object> update, string URL)
        {
            this.URL = URL;
            SendUpdate += update;
        }

        public async Task GetUpdatesFromServer()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    using (var http = new HttpClient())
                    {
                        var json = await http.GetStringAsync(URL);

                        dynamic updates = JsonConvert.SerializeObject(json);

                        if (updates.Updates.Count > 0)
                        {
                            await SendUpdate.Invoke(updates.Updates);
                        }
                    }

                    Thread.Sleep(DELAY);
                }
            });
        }
    }
}
