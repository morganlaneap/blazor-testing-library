using System;
using System.Collections.Generic;
using BlazorProject.Pages;

namespace BlazorProject.UnitTests.TestUtils
{
    public static class TestData
    {
        public static readonly List<FetchData.WeatherForecast> ValidWeatherForecastData = new()
        {
            new FetchData.WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 35,
                Summary = "It's hot"
            }
        };
    }
}