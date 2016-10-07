using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureApiApp.Models
{
    public class Coordinate
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public class Station
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("distance")]
        public object Distance { get; set; }
    }

    public class Prognosis
    {

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("arrival")]
        public object Arrival { get; set; }

        [JsonProperty("departure")]
        public object Departure { get; set; }

        [JsonProperty("capacity1st")]
        public int Capacity1st { get; set; }

        [JsonProperty("capacity2nd")]
        public int Capacity2nd { get; set; }
    }

    public class Location
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public object Score { get; set; }

        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("distance")]
        public object Distance { get; set; }
    }

    public class Stop
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("arrival")]
        public object Arrival { get; set; }

        [JsonProperty("arrivalTimestamp")]
        public object ArrivalTimestamp { get; set; }

        [JsonProperty("departure")]
        public DateTime Departure { get; set; }

        [JsonProperty("departureTimestamp")]
        public int DepartureTimestamp { get; set; }

        [JsonProperty("delay")]
        public object Delay { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prognosis")]
        public Prognosis Prognosis { get; set; }

        [JsonProperty("realtimeAvailability")]
        public object RealtimeAvailability { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class PassList
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("arrival")]
        public DateTime Arrival { get; set; }

        [JsonProperty("arrivalTimestamp")]
        public int ArrivalTimestamp { get; set; }

        [JsonProperty("departure")]
        public object Departure { get; set; }

        [JsonProperty("departureTimestamp")]
        public object DepartureTimestamp { get; set; }

        [JsonProperty("delay")]
        public object Delay { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prognosis")]
        public Prognosis Prognosis { get; set; }

        [JsonProperty("realtimeAvailability")]
        public object RealtimeAvailability { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Stationboard
    {

        [JsonProperty("stop")]
        public Stop Stop { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("subcategory")]
        public string Subcategory { get; set; }

        [JsonProperty("categoryCode")]
        public int CategoryCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("passList")]
        public IList<PassList> PassList { get; set; }

        [JsonProperty("capacity1st")]
        public object Capacity1st { get; set; }

        [JsonProperty("capacity2nd")]
        public object Capacity2nd { get; set; }
    }

    public class StationboardResult
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("stationboard")]
        public IList<Stationboard> Stationboard { get; set; }
    }

}