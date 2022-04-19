using FinalCapstoneBackend.DataTransferObjects.TrailApi;
using FinalCapstoneBackend.DataTransferObjects.WeatherApi;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;


namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailController : ControllerBase
    {

        // GET: api/<TrailController>
        [HttpGet]
        public IEnumerable<Trail> ReturnTrailsByCity(string searchTerm = "chicago")
        {
            //api uri to call weather api to retrieve latitude and longitude by using a city name as a search term 
            string ApiUri = $"https://weatherapi-com.p.rapidapi.com/current.json?q={searchTerm}";

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var apiKey = configuration.GetValue<string>("ApiKeys:RapidApiKey");
            var apiHostWeather = configuration.GetValue<string>("ApiKeys:RapidApiHostWeather");
            var apiHostTrail = configuration.GetValue<string>("ApiKeys:RapidApiHostTrail");


            //calling the weather api
            var apiTask = ApiUri.WithHeaders(new
            {
                X_RapidAPI_Host = apiHostWeather,
                X_RapidAPI_Key = apiKey
            }).GetJsonAsync<WeatherApiResult>();
            apiTask.Wait();

            //retireving latitude and longitude for the search term city from the weather api results 
            string latitude = apiTask.Result.location.lat.ToString();
            string longitude = apiTask.Result.location.lon.ToString();

            //using lat and long with string interpolation to make uri for trail api call 
            string trailApiUri = $"https://trailapi-trailapi.p.rapidapi.com/trails/explore/?lat={latitude}&lon={longitude}";

            //calling trail api 
            var trailApiTask = trailApiUri.WithHeaders(new
            {
                X_RapidAPI_Host = apiHostTrail,
                X_RapidAPI_Key = apiKey
            }).GetJsonAsync<TrailApiResult>();
            trailApiTask.Wait();

            //collecting list of returned trails from api result into a list 
            List<Trail> results = trailApiTask.Result.data.ToList();

            //returning the list of trail results 
            return results;
        }

        // GET api/<TrailController>/5
        [HttpGet("{id}")]
        public IEnumerable<Trail> Get(int id)
        {

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var apiKey = configuration.GetValue<string>("ApiKeys:RapidApiKey");
            var apiHostWeather = configuration.GetValue<string>("ApiKeys:RapidApiHostWeather");
            var apiHostTrail = configuration.GetValue<string>("ApiKeys:RapidApiHostTrail");

            //using given id with string interpolation to make uri for trail api call 
            string trailApiUri = $"https://trailapi-trailapi.p.rapidapi.com/trails/{id}";

            //calling trail api 
            var trailApiTask = trailApiUri.WithHeaders(new
            {
                X_RapidAPI_Host = apiHostTrail,
                X_RapidAPI_Key = apiKey
            }).GetJsonAsync<TrailApiResult>();
            trailApiTask.Wait();

            //Get a list of a returned trail from api result and convert to a list
            //The api for getting bike trail info returns a list, even though it's one trail
            List<Trail> results = trailApiTask.Result.data.ToList();

            return results;
        }
    }
}
