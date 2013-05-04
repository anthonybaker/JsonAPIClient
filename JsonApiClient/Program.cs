/// Author:         Anthony Baker
/// Date:           May 4th, 2013
/// Description:    JsonAPIClient - Sample JSON API Consumption

using System;

namespace JsonApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define Location Params
            double latitude = 51.50853;
            double longitude = -0.12574;
            int stationQuantity = 10;

            // Get the weather forecaste data synchronously
            WeatherApiClient.GetWeatherForecast(latitude, longitude, stationQuantity);

            // Get the weather forecast data asynchronously
            WeatherApiClient.GetWeatherForecastAsync(latitude, longitude, stationQuantity);

            // Wait for user input - keep the program runnin
            Console.ReadLine();
        }
    }
}
