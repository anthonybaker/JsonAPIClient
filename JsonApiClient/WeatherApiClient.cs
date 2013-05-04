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

        public static void GetWeatherForecastAsync()
        {
            // format the Url according to parameters and service endpoint
            var url = "http://api.openweathermap.org/data/2.1/find/city?lat=51.50853&lon=-0.12574&cnt=10";

            // Async Consumption
            var asyncClient = new WebClient();
            asyncClient.DownloadStringCompleted += asyncClient_DownloadStringCompleted;
            asyncClient.DownloadStringAsync(new Uri(url));

            // Do something else...
        }

        static void asyncClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Create the Json serializer and parse the response
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherData));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result)))
            {
                var weatherData = (WeatherData)serializer.ReadObject(ms);
            }
        }
    }
}
