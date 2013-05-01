using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace JsonApiClient
{
    public static class WeatherApiClient
    {
        public static void GetWeatherForecast() 
        {
            var url = "http://api.openweathermap.org/data/2.1/find/city?lat=51.50853&lon=-0.12574&cnt=10";

            // Syncronious Consumption
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);

            // Create the Json serializer and parse the response
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherData));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                var weatherData = (WeatherData)serializer.ReadObject(ms);
            }
        }
    }
}
