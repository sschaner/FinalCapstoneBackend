using FinalCapstoneBackend.DataTransferObjects.TrailApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using FinalCapstoneBackend.DataTransferObjects.WeatherApi;
using FinalCapstoneBackend.DataTransferObjects.TrailApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

            //calling the weather api
            var apiTask = ApiUri.WithHeaders(new
            {
                X_RapidAPI_Host = "weatherapi-com.p.rapidapi.com",
                X_RapidAPI_Key = "13937aa023msh19be5d6e39cc704p1f331cjsnc968b519867a"
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
                X_RapidAPI_Host = "trailapi-trailapi.p.rapidapi.com",
                X_RapidAPI_Key = "13937aa023msh19be5d6e39cc704p1f331cjsnc968b519867a"
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
            //using given id with string interpolation to make uri for trail api call 
            string trailApiUri = $"https://trailapi-trailapi.p.rapidapi.com/trails/{id}";

            //calling trail api 
            var trailApiTask = trailApiUri.WithHeaders(new
            {
                X_RapidAPI_Host = "trailapi-trailapi.p.rapidapi.com",
                X_RapidAPI_Key = "13937aa023msh19be5d6e39cc704p1f331cjsnc968b519867a"
            }).GetJsonAsync<TrailApiResult>();
            trailApiTask.Wait();

            //Get a list of a returned trail from api result and convert to a list
            //The api for getting bike trail info returns a list, even though it's one trail
            List<Trail>results = trailApiTask.Result.data.ToList();

            return results;
        }
    }
}
