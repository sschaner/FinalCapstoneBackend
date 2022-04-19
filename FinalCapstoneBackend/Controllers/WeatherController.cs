using FinalCapstoneBackend.DataTransferObjects.WeatherApi;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeatherController : ControllerBase
    {
        //returns weather at a specified city api/<WeatherController>
        [HttpGet]
        public WeatherApiResult ReturnCurrentWeatherByCity(string searchTerm = "chicago")
        {

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var apiKey = configuration.GetValue<string>("ApiKeys:RapidApiKey");
            var apiHostWeather = configuration.GetValue<string>("ApiKeys:RapidApiHostWeather");

            string ApiUri = $"https://weatherapi-com.p.rapidapi.com/current.json?q={searchTerm}";
            var apiTask = ApiUri.WithHeaders(new
            {
                X_RapidAPI_Host = apiHostWeather,
                X_RapidAPI_Key = apiKey
            }).GetJsonAsync<WeatherApiResult>();
            apiTask.Wait();
            WeatherApiResult result = apiTask.Result;
            return result;
        }
    }
}
