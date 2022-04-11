using FinalCapstoneBackend.DataTransferObjects;
using FinalCapstoneBackend.DataTransferObjects.TrailApi;
using FinalCapstoneBackend.DataTransferObjects.UserContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTrailController : ControllerBase
    {
        // GET: api/<UserTrailController>
        [HttpGet]
        public ActionResult<IEnumerable<FavoriteTrails>> GetUserFavoriteTrails(int userId)
        {
            List<FavoriteTrails> favoriteTrails = new List<FavoriteTrails>();
            using (FinalCapstoneBackendContext context = new FinalCapstoneBackendContext())
            {

                favoriteTrails = context.FavoriteTrails.Where(x => x.UserId == userId).ToList();
                //var userFavorites = context.Users
                //    .Include(t => t.FavoriteTrails)
                //    .ThenInclude(x => x.Trail)
                //    .First(x => x.UserId = userId);
                //favoriteTrails = userFavorites.FavoriteTrails(x => x.Trail).ToList();

                //userFavorites = context.FavoriteTrails.Where(x => x.UserId == userId).ToList();
            }

            return favoriteTrails;
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
            // User user = new User();
            //Trail trail = new Trail();
            FavoriteTrails result = new FavoriteTrails();
            using (FinalCapstoneBackendContext context = new FinalCapstoneBackendContext())
            {
                // user = context.Users.Where(x => x.UserId == userId).FirstOrDefault();
                // trail = context.Trails.Where(x => x.id == trailId).FirstOrDefault();
                result.UserId = userId;
                result.TrailId = trailId;

                context.FavoriteTrails.Add(result);
                context.SaveChanges();

            }
        }

        // PUT api/<UserTrailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserTrailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
