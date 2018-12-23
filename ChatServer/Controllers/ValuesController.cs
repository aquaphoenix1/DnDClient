using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatServer.Controllers
{
    [Route("chat")]
    public class ValuesController : Controller
    {
        private Dictionary<DateTime, string> chatHistory;
        private int CHAT_HISTORY_MAX_VALUES = 20;

        // GET chat/values
        [HttpGet]
        public string Get()
        {
            var json = JsonConvert.SerializeObject(chatHistory);
            return json;
        }

        // POST chat/values
        [HttpPost]
        public void Post([FromBody]dynamic value)
        {
            if(chatHistory.Count > CHAT_HISTORY_MAX_VALUES)
            {
                chatHistory.Remove(chatHistory.ElementAt(0).Key);
            }

            chatHistory.Add(DateTime.Now, value);
        }
    }
}
