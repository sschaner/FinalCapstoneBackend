using FinalCapstoneBackend.DataTransferObjects;
using FinalCapstoneBackend.DataTransferObjects.TrailApi;
using FinalCapstoneBackend.DataTransferObjects.UserContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
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


            foreach (var trail in favoriteTrails)
            {
                //using given id with string interpolation to make uri for trail api call 
                string trailApiUri = $"https://trailapi-trailapi.p.rapidapi.com/trails/{trail.TrailId}";

                //calling trail api 
                var trailApiTask = trailApiUri.WithHeaders(new
                {
                    X_RapidAPI_Host = "trailapi-trailapi.p.rapidapi.com",
                    X_RapidAPI_Key = "13937aa023msh19be5d6e39cc704p1f331cjsnc968b519867a"
                }).GetJsonAsync<TrailApiResult>();
                trailApiTask.Wait();

                //Get a list of a returned trail from api result and convert to a list
                //The api for getting bike trail info returns a list, even though it's one trail
                List<Trail> apiResult = trailApiTask.Result.data.ToList();
                Trail singleResult = apiResult[0];
                results.Add(singleResult);
            }

            return results;
        }

        // GET api/<UserTrailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
