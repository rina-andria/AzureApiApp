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
            using (var client = new System.Net.Http.HttpClient())
            {
                // ReSharper disable once InconsistentNaming
                var response =
                    await client.GetAsync($"http://transport.opendata.ch/v1/connections?from={origin}&to={destination}&limit=6");
                if (response != null && response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var objResponse = JsonConvert.DeserializeObject<Connections>(responseBody);
                        if (objResponse != null)
                        {
                            var connectionList = objResponse.ConnectionsList;

                            var sectionResultList = new List<SectionResult>();

                            var connectionNumber = 1;
                            foreach (var connection in connectionList)
                            {
                                var sectionNumber = 1;
                                foreach (var section in connection.Sections)
                                {
                                    sectionResultList.Add(new SectionResult
                                    {
                                        ConnectionNumber = connectionNumber,
                                        SectionNumer = sectionNumber,
                                        JourneyName = section.Journey != null ? section.Journey.Name : "Walk",
                                        DepartureStation = section.Departure.Station.Name,
                                        DepartureTime = section.Departure.DepartureTime,
                                        ArrivalStation = section.Arrival.Station.Name,
                                        Arrivaltime = section.Arrival.ArrivalTime,
                                        Duration = section.Arrival.ArrivalTime.Subtract(section.Departure.DepartureTime),
                                        DepartureXCoordinate = section.Departure.Location.Coordinate.X,
                                        DepartureYCoordinate = section.Departure.Location.Coordinate.Y,
                                        DepartureLocation = $"{section.Departure.Location.Coordinate.X},{section.Departure.Location.Coordinate.Y}",
                                        ArrivalXCoordinate = section.Arrival.Location.Coordinate.X,
                                        ArrivalYCoordinate = section.Arrival.Location.Coordinate.Y,
                                        ArrivalLocation = $"{section.Arrival.Location.Coordinate.X},{section.Arrival.Location.Coordinate.Y}"
                                    });
                                    sectionNumber++;
                                }
                                connectionNumber++;
                            }

                            return sectionResultList;
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

