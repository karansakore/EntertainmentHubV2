using EntertainmentHub.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EntertainmentHub.Controllers
{
    public class WeatherService
    {
        private const string ApiKey = "bd021c267fd29d3673c51dd6ab1d90ce";
        private const string ApiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherData> GetWeatherDataAsync(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{ApiUrl}?q={city}&appid={ApiKey}&units=metric");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<WeatherData>(json);
                        return data;
                    }
                    else
                    {
                        throw new Exception($"Failed to retrieve weather data in code. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception("Failed to retrieve weather data. Network error.", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve weather data.", ex);
                }
            }
        }
    }
}