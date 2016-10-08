using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureApiApp.Controllers
{
    [Route("api/[controller]")]
    public class ConnectionsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IList<SectionResult>> Get()
        {
            using (var Client = new System.Net.Http.HttpClient())
            {
                // ReSharper disable once InconsistentNaming
                var response =
                    await Client.GetAsync(@"http://transport.opendata.ch/v1/connections?from=Lausanne, Dranse&to=Nyon");
                if (response != null && response.IsSuccessStatusCode)
                {
                    var ResponseBody = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var ObjResponse = JsonConvert.DeserializeObject<Connections>(ResponseBody);
                        if (ObjResponse != null)
                        {
                            var ConnectionList = ObjResponse.ConnectionsList;

                            var SectionResultList = new List<SectionResult>();

                            var ConnectionNumber = 1;
                            foreach (var Connection in ConnectionList)
                            {
                                var SectionNumber = 1;
                                foreach (var Section in Connection.Sections)
                                {
                                    SectionResultList.Add(new SectionResult
                                    {
                                        ConnectionNumber = ConnectionNumber,
                                        SectionNumer = SectionNumber,
                                        JourneyName = Section.Journey != null ? Section.Journey.Name : "Walk",
                                        DepartureStation = Section.Departure.Station.Name,
                                        ArrivalStation = Section.Arrival.Station.Name,
                                        Duration = Section.Arrival.ArrivalTime.Subtract(Section.Departure.DepartureTime)
                                    });
                                    SectionNumber++;
                                }
                                ConnectionNumber++;
                            }

                            return SectionResultList;
                        }
                    }
                    catch (Exception ex)
                    {
                        // in case an error occured, we do not return any data
                    }
                }
            }
            return new List<SectionResult>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

    public class SectionResult
    {
        public int ConnectionNumber { get; set; }
        public int SectionNumer { get; set; }
        public string JourneyName { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

