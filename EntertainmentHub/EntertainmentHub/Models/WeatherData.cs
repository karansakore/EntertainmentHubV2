using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntertainmentHub.Models
{
    public class WeatherData
    {

        public string City { get; set; }
        public string Country { get; set; }
        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }
    }
}
