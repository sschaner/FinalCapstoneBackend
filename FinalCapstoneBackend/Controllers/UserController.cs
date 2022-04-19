using FinalCapstoneBackend.DataTransferObjects.UserContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public User LogInUserByEmail(string searchTerm)
        {
            User result = null;
            using (UserContext context = new UserContext())
            {
                result = context.Users.Where(x => x.Email.Trim().ToLower() == searchTerm.Trim().ToLower()).FirstOrDefault();
                return result;
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            List<User> result = null;
            User user = null;
            using (UserContext context = new UserContext())
            {
                result = context.Users.ToList();
                user = result.Where(x => x.UserId == id).FirstOrDefault();
            }

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public User SaveUser(User user)
        {
            using (UserContext context = new UserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return user;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void RemoveUserById(int id)
        {
            User user = new User();
            using (UserContext context = new UserContext())
            {
                user = context.Users.Where(x => x.UserId == id).FirstOrDefault();
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
