using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureApiApp.Models
{
    public class Locations
    {

        [JsonProperty("stations")]
        public IList<Station> Stations { get; set; }
    }


}
