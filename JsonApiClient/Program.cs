using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the weather forecaste data synchronously
            WeatherApiClient.GetWeatherForecast();

            // Get the weather forecast data asynchronously
            WeatherApiClient.GetWeatherForecastAsync();

            // Wait for user input - keep the program runnin
            Console.ReadLine();
        }
    }
}
