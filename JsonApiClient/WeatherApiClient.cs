/// Author:         Anthony Baker
/// Date:           May 4th, 2013
/// Description:    JsonAPIClient - Sample JSON API Consumption

using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JsonApiClient
{
    public static class WeatherApiClient
    {
        #region fields

        /// <summary>
        /// Base URL for the Weather Endpoint URL
        /// </summary>
        private const string baseUrl = "http://api.openweathermap.org/data/2.1/find/city?lat={0}&lon={1}&cnt={2}";

        #endregion

        #region methods

        /// <summary>
        /// Retrieves the Weather Forecast data synchronously.
        /// </summary>
        /// <param name="latitude">latitude of the geolocation</param>
        /// <param name="longitude">longitud of the geolocation</param>
        /// <param name="stationQuantity">number of weather stations to be included</param>
        public static void GetWeatherForecast(double latitude, double longitude, int stationQuantity) 
        {
            // Customize URL according to geo location parameters
            var url = string.Format(baseUrl, latitude, longitude, stationQuantity);

            // Syncronious Consumption
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);

            // Create the Json serializer and parse the response
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherData));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            {
                // deserialize the JSON object using the WeatherData type.
                var weatherData = (WeatherData)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Retrieves the Weather Forecast data asynchronously.
        /// </summary>
        /// <param name="latitude">latitude of the geolocation</param>
        /// <param name="longitude">longitud of the geolocation</param>
        /// <param name="stationQuantity">number of weather stations to be included</param>
        public static void GetWeatherForecastAsync(double latitude, double longitude, int stationQuantity)
        {
            // Customize URL according to geo location parameters
            var url = string.Format(baseUrl, latitude, longitude, stationQuantity);

            // Async Consumption
            var asyncClient = new WebClient();
            asyncClient.DownloadStringCompleted += asyncClient_DownloadStringCompleted;
            asyncClient.DownloadStringAsync(new Uri(url));

            // Do something else...
        }

        /// <summary>
        /// Parses the weather data once the response download is completed.
        /// </summary>
        /// <param name="sender">object that originated the event</param>
        /// <param name="e">event arguments</param>
        static void asyncClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Create the Json serializer and parse the response
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherData));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result)))
            {
                // deserialize the JSON object using the WeatherData type.
                var weatherData = (WeatherData)serializer.ReadObject(ms);
            }
        }

        #endregion
    }
}
