using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    public class MovieController : ApiController
    {
        private static List<Movie> _listItems { get; set; } = new List<Movie>();
        // GET api/values
        public IEnumerable<Movie> Get()
        {
            return _listItems;
            // Retrieve all movies from db logic
            //return new string[] { "movie1 string", "movie2 string" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            // Retrieve movie by id from db logic
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Movie value)
        {
            if(string.IsNullOrEmpty(value?.Title))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var maxId = 0;
            if(_listItems.Count>0)
            {
                maxId = _listItems.Max(x => x.Id);
            }
            value.Id = maxId + 1;
            _listItems.Add(value);
            return Request.CreateResponse(HttpStatusCode.Created, value);
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            // Update movie in db logic
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            // Delete movie from db logic
        }
    }

}
