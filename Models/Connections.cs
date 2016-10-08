using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureApiApp.Models
{
    public class Coordinate
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public class Station
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }

        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("distance")]
        public object Distance { get; set; }
    }

    public class Prognosis
    {

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("arrival")]
        public object Arrival { get; set; }

        [JsonProperty("departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty("capacity1st")]
        public int? Capacity1St { get; set; }

        [JsonProperty("capacity2nd")]
        public int? Capacity2Nd { get; set; }
    }

    public class Location
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }

        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("distance")]
        public object Distance { get; set; }
    }

    public partial class From
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("arrival")]
        public object Arrival { get; set; }

        [JsonProperty("arrivalTimestamp")]
        public int? ArrivalTimestamp { get; set; }

        [JsonProperty("departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty("departureTimestamp")]
        public int DepartureTimestamp { get; set; }

        [JsonProperty("delay")]
        public int? Delay { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prognosis")]
        public Prognosis Prognosis { get; set; }

        [JsonProperty("realtimeAvailability")]
        public string RealtimeAvailability { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public partial class From
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }

        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("distance")]
        public object Distance { get; set; }
    }

    public partial class To
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("arrival")]
        public DateTime Arrival { get; set; }

        [JsonProperty("arrivalTimestamp")]
        public int? ArrivalTimestamp { get; set; }

        [JsonProperty("departure")]
        public object Departure { get; set; }

        [JsonProperty("departureTimestamp")]
        public object DepartureTimestamp { get; set; }

        [JsonProperty("delay")]
        public int? Delay { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prognosis")]
        public Prognosis Prognosis { get; set; }

        [JsonProperty("realtimeAvailability")]
        public string RealtimeAvailability { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Service
    {

        [JsonProperty("regular")]
        public string Regular { get; set; }

        [JsonProperty("irregular")]
        public string Irregular { get; set; }
    }

    public class PassList
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty("arrivalTimestamp")]
        public int? ArrivalTimestamp { get; set; }

        [JsonProperty("departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty("departureTimestamp")]
        public int? DepartureTimestamp { get; set; }

        [JsonProperty("delay")]
        public int? Delay { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prognosis")]
        public Prognosis Prognosis { get; set; }

        [JsonProperty("realtimeAvailability")]
        public string RealtimeAvailability { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Journey
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("subcategory")]
        public object Subcategory { get; set; }

        [JsonProperty("categoryCode")]
        public int CategoryCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("passList")]
        public IList<PassList> PassList { get; set; }

        [JsonProperty("capacity1st")]
        public int? Capacity1St { get; set; }

        [JsonProperty("capacity2nd")]
        public int? Capacity2Nd { get; set; }
    }

    public class Departure
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("arrivalTimestamp")]
        public int? ArrivalTimestamp { get; set; }

        [JsonProperty("departure")]
        public DateTime DepartureTime { get; set; }

        [JsonProperty("departureTimestamp")]
        public int DepartureTimestamp { get; set; }

        [JsonProperty("delay")]
        public int? Delay { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prognosis")]
        public Prognosis Prognosis { get; set; }

        [JsonProperty("realtimeAvailability")]
        public string RealtimeAvailability { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Arrival
    {

        [JsonProperty("station")]
        public Station Station { get; set; }

        [JsonProperty("arrival")]
        public DateTime ArrivalTime { get; set; }

        [JsonProperty("arrivalTimestamp")]
        public int? ArrivalTimestamp { get; set; }

        [JsonProperty("departure")]
        public object Departure { get; set; }

        [JsonProperty("departureTimestamp")]
        public object DepartureTimestamp { get; set; }

        [JsonProperty("delay")]
        public int? Delay { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("prognosis")]
        public Prognosis Prognosis { get; set; }

        [JsonProperty("realtimeAvailability")]
        public string RealtimeAvailability { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Section
    {

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

        [JsonProperty("walk")]
        public object Walk { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }
    }

    public class Connection
    {

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("to")]
        public To To { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("transfers")]
        public int Transfers { get; set; }

        [JsonProperty("service")]
        public Service Service { get; set; }

        [JsonProperty("products")]
        public IList<string> Products { get; set; }

        [JsonProperty("capacity1st")]
        public int? Capacity1St { get; set; }

        [JsonProperty("capacity2nd")]
        public int? Capacity2Nd { get; set; }

        [JsonProperty("sections")]
        public IList<Section> Sections { get; set; }
    }

    public partial class To
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }

        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        [JsonProperty("distance")]
        public object Distance { get; set; }
    }

    public class Stations
    {

        [JsonProperty("from")]
        public IList<From> From { get; set; }

        [JsonProperty("to")]
        public IList<To> To { get; set; }
    }

    public class Connections
    {

        [JsonProperty("connections")]
        public IList<Connection> ConnectionsList { get; set; }

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("to")]
        public To To { get; set; }

        [JsonProperty("stations")]
        public Stations Stations { get; set; }
    }


}
