using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AzureApiApp.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IList<Stationboard>> Get()
        {
            using (var Client = new System.Net.Http.HttpClient())
            {
                // ReSharper disable once InconsistentNaming
                var response = await Client.GetAsync("http://transport.opendata.ch/v1/stationboard?station=Lausanne&limit=10");
                if(response != null && response.IsSuccessStatusCode) {
                    var ResponseBody = await response.Content.ReadAsStringAsync();
                    
                    var ObjResponse = JsonConvert.DeserializeObject<StationboardResult>(ResponseBody);
                    if(ObjResponse != null)
                        return ObjResponse.Stationboard;
                }
            }
            return new List<Stationboard>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IList<Stationboard>> Get(string id)
        {
            using (var Client = new System.Net.Http.HttpClient())
            {
                // ReSharper disable once InconsistentNaming
                var response = await Client.GetAsync($"http://transport.opendata.ch/v1/stationboard?station={id}&limit=10");
                if(response != null && response.IsSuccessStatusCode) {
                    var ResponseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var ObjResponse = JsonConvert.DeserializeObject<StationboardResult>(ResponseBody);
                        if (ObjResponse != null)
                            return ObjResponse.Stationboard;
                    }
                    // ReSharper disable once EmptyGeneralCatchClause
                    catch (Exception)
                    {
                        
                    }
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
