﻿using FinalCapstoneBackend.DataTransferObjects;
using FinalCapstoneBackend.DataTransferObjects.UserContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public List<User> GetAllUsers()
        {
            List<User> result = null;
            using (FinalCapstoneBackendContext context = new FinalCapstoneBackendContext())
            {
                result = context.Users.ToList();
            }

            return result;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            List<User> result = null;
            User user = null;
            using (FinalCapstoneBackendContext context = new FinalCapstoneBackendContext())
            {
                result = context.Users.ToList();
                user = result[id - 1];
            }

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public User SaveUser(User user)
        {
            using (FinalCapstoneBackendContext context = new FinalCapstoneBackendContext())
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
        public User RemoveUserById(int id)
        {
            User user = new User();
            using (FinalCapstoneBackendContext context = new FinalCapstoneBackendContext())
            {
                user = context.Users.Where(x => x.UserId == id).FirstOrDefault();
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }
    }
}
