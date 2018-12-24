using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace TestServer.Controllers
{
    public class ChatController : ApiController
    {

        private class Test
        {
            public int id = 12;
            public string str = "123123";
            private string ip = "ipipipip";
        }

        // GET: api/Chat
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Chat/5
        public string Get(int id)
        {
            string str = JsonConvert.SerializeObject(new Test());
            return str;
        }

        // POST: api/Chat
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Chat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Chat/5
        public void Delete(int id)
        {
        }
    }
}
