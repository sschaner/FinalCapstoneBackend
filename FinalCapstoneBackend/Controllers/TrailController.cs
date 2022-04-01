using FinalCapstoneBackend.DataTransferObjects.TrailApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalCapstoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailController : ControllerBase
    {
        List<TrailApiResult> _trailCollection;

        public TrailController()
        {
            string apiUri = "https://trailapi-trailapi.p.rapidapi.com/trails/explore/?lat=51.5128&lon=-0.0918";
        }

        // GET: api/<TrailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TrailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TrailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TrailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
