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
            return await GetConnections("Lausanne, Dranse", "Nyon");
        }

        // GET api/values/5
        [HttpGet("{origin}/{destination}")]
        public async Task<IList<SectionResult>> Get(string origin, string destination)
        {
            return await GetConnections(origin, destination);
        }

        private static async Task<IList<SectionResult>> GetConnections(string origin, string destination)
        {
            using (var Client = new System.Net.Http.HttpClient())
            {
                // ReSharper disable once InconsistentNaming
                var response =
                    await Client.GetAsync($"http://transport.opendata.ch/v1/connections?from={origin}&to={destination}&limit=6");
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
                                        DepartureTime = Section.Departure.DepartureTime,
                                        ArrivalStation = Section.Arrival.Station.Name,
                                        Arrivaltime = Section.Arrival.ArrivalTime,
                                        Duration = Section.Arrival.ArrivalTime.Subtract(Section.Departure.DepartureTime),
                                        DepartureXCoordinate = Section.Departure.Location.Coordinate.X,
                                        DepartureYCoordinate = Section.Departure.Location.Coordinate.Y,
                                        ArrivalXCoordinate = Section.Arrival.Location.Coordinate.X,
                                        ArrivalYCoordinate = Section.Arrival.Location.Coordinate.Y
                                    });
                                    SectionNumber++;
                                }
                                ConnectionNumber++;
                            }

                            return SectionResultList;
                        }
                    }
                    catch (Exception)
                    {
                        // in case an error occured, we do not return any data
                    }
                }
            }
            return new List<SectionResult>();
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
        public DateTime DepartureTime { get; set; }
        public DateTime Arrivaltime { get; set; }
        public double DepartureXCoordinate { get; set; }
        public double DepartureYCoordinate { get; set; }
        public double ArrivalXCoordinate { get; set; }
        public double ArrivalYCoordinate { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
    }
}

