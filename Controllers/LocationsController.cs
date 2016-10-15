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
    public class LocationsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IList<StationResult>> Get()
        {
            return await GetLocations("Lausanne, Dranse");
        }

        // GET api/values/5
        [HttpGet("{location}")]
        public async Task<IList<StationResult>> Get(string location)
        {
            return await GetLocations(location);
        }

        private static async Task<IList<StationResult>> GetLocations(string location)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                // ReSharper disable once InconsistentNaming
                var response =
                    await client.GetAsync($"http://transport.opendata.ch/v1/locations?query={location}");
                if (response != null && response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var objResponse = JsonConvert.DeserializeObject<Locations>(responseBody);
                        if (objResponse != null)
                        {
                            var stationList = objResponse.Stations;

                            var stationResultList = new List<StationResult>();

                            foreach (var station in stationList)
                            {
                                stationResultList.Add(new StationResult
                                {
                                    Name = station.Name,
                                    CoordinateX = station.Coordinate.X,
                                    CoordinateY = station.Coordinate.Y,
                                    Location = $"{station.Coordinate.X}, {station.Coordinate.Y}",
                                    Distance = station.Distance,
                                    Id = station.Id,
                                    Score = station.Score
                                });
                            }

                            return stationResultList;
                        }
                    }
                    catch (Exception)
                    {
                        // in case an error occured, we do not return any data
                    }
                }
            }
            return new List<StationResult>();
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

public class StationResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int? Score { get; set; }
    public double CoordinateX { get; set; }
    public double CoordinateY { get; set; }
    public object Distance { get; set; }
    public string Location { get; set; }
}
