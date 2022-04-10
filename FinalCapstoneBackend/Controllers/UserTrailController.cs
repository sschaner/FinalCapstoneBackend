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
        public ActionResult<IEnumerable<Trail>> GetUserFavoriteTrails( int userId )
        {
            List<FavoriteTrails> userFavorites = new List<FavoriteTrails>();
            List<Trail> favoriteTrails = new List<Trail>();
            using (UserContext context = new UserContext())
            {
                userFavorites = context.FavoriteTrails.Where(x => x.UserId == userId).ToList();
            }

            return userFvorites
        }

        // GET api/<UserTrailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserTrailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
