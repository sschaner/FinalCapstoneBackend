using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalCapstoneBackend.DataTransferObjects.WeatherApi;
using Flurl.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    /*
        * 
        * 
        * THIS IS THE CODE TO RETURN STRING LATITUDE AND LONGITUDE BY CITY SEARCH TERM 
        * 
        * INPUT STRING SEARCHTERM 
        * 
        *  string locationApiUri = $"https://google-maps-geocoding.p.rapidapi.com/geocode/json?address={searchTerm}&language=en";
           var locationApiTask = locationApiUri.WithHeaders(new
           {
               X_RapidAPI_Host = "google-maps-geocoding.p.rapidapi.com",
               X_RapidAPI_Key = "13937aa023msh19be5d6e39cc704p1f331cjsnc968b519867a"
           }).GetJsonAsync<LocationApiResult>();
           locationApiTask.Wait();
           string latitude = locationApiTask.Result.lat.ToString();
           string longitude = locationApiTask.Result.lon.ToString();
        * 
        * 
        * 
        * 
        * 
        * 
        */
    public class WeatherController : ControllerBase
    {
        //returns weather at a specified city api/<WeatherController>
        [HttpGet]
        public WeatherApiResult ReturnCurrentWeatherByCity(string searchTerm = "chicago")
        {
            string ApiUri = $"https://weatherapi-com.p.rapidapi.com/current.json?q={searchTerm}";
            var apiTask = ApiUri.WithHeaders(new
            {
                X_RapidAPI_Host = "weatherapi-com.p.rapidapi.com",
                X_RapidAPI_Key = "13937aa023msh19be5d6e39cc704p1f331cjsnc968b519867a"
            }).GetJsonAsync<WeatherApiResult>();
            apiTask.Wait();
            WeatherApiResult result = apiTask.Result;
            return result;
        }












        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
