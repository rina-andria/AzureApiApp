using System.Collections.Generic;
using System.Threading.Tasks;
using AzureApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AzureApiApp.Controllers
{
    [Route("api/[controller]")]
    public class StationboardController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IList<Stationboard>> Get()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://transport.opendata.ch/v1/stationboard?station=Lausanne&limit=10");
                if(response != null && response.IsSuccessStatusCode) {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    
                    var objResponse = JsonConvert.DeserializeObject<StationboardResult>(responseBody);
                    return objResponse.Stationboard;
                }
            }
            return new List<Stationboard>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IList<Stationboard>> Get(string id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync("http://transport.opendata.ch/v1/stationboard?station=Lausanne&limit=10");
                if(response != null && response.IsSuccessStatusCode) {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    
                    var objResponse = JsonConvert.DeserializeObject<StationboardResult>(responseBody);
                    return objResponse.Stationboard;
                }
            }
            return new List<Stationboard>();
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
