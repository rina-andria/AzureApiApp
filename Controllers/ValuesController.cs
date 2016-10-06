using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzureApiApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://transport.opendata.ch/v1/stationboard?station=Nyon&limit=10");
                if(response != null && response.IsSuccessStatusCode) {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    
                    var objResponse = Newtonsoft.Json.Linq.JObject.Parse(responseBody);
                    return objResponse["stationboard"].ToString();
                }
            }
            return string.Empty;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return string.Empty;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
