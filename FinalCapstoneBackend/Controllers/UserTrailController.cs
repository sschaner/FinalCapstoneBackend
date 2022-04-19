using FinalCapstoneBackend.DataTransferObjects.TrailApi;
using FinalCapstoneBackend.DataTransferObjects.UserContext;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTrailController : ControllerBase
    {
        // GET: api/<UserTrailController>
        [HttpGet]
        public ActionResult<List<Trail>> GetUserFavoriteTrails(int userId)
        {
            List<FavoriteTrail> favoriteTrails = new List<FavoriteTrail>();
            using (UserContext context = new UserContext())
            {
                favoriteTrails = context.FavoriteTrails.Where(x => x.UserId == userId).ToList();
            }
            List<Trail> results = new List<Trail>();

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var apiKey = configuration.GetValue<string>("ApiKeys:RapidApiKey");
            var apiHostTrail = configuration.GetValue<string>("ApiKeys:RapidApiHostTrail");


            foreach (var trail in favoriteTrails)
            {
                string trailApiUri = $"https://trailapi-trailapi.p.rapidapi.com/trails/{trail.TrailId}";

                var trailApiTask = trailApiUri.WithHeaders(new
                {
                    X_RapidAPI_Host = apiHostTrail,
                    X_RapidAPI_Key = apiKey
                }).GetJsonAsync<TrailApiResult>();
                trailApiTask.Wait();

                List<Trail> apiResult = trailApiTask.Result.data.ToList();
                Trail singleResult = apiResult[0];
                results.Add(singleResult);
            }

            return results;
        }

        // GET api/<UserTrailController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
        }

        // POST api/<UserTrailController>
        [HttpPost]
        public void UserFavoriteTrails(int userId, int trailId)
        {
            FavoriteTrail trail = new FavoriteTrail();
            using (UserContext context = new UserContext())
            {
                trail.UserId = userId;
                trail.TrailId = trailId.ToString();
                context.FavoriteTrails.Add(trail);
                context.SaveChanges();
            }
        }


        // PUT api/<UserTrailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserTrailController>/5
        [HttpDelete]
        public void Delete(int userId, int trailId)
        {
            FavoriteTrail result = null;

            using (UserContext context = new UserContext())
            {
                result = context.FavoriteTrails.Where(x => x.UserId == userId && x.TrailId == trailId.ToString()).First();
                context.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
