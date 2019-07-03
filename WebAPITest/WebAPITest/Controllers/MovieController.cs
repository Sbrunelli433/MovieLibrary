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
        ApplicationDbContext db;
        public MovieController()
        {
            db = new ApplicationDbContext();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {


            //List<string> listOfMovies = db.Movies.AsEnumerable();
            //var moviesList = db.Movies.ToList().AsEnumerable();

            var list = db.Movies.AsEnumerable().ToList();
            var moviesList = list.ToString();
            yield return moviesList;


            //var moviesList = db.Movies.ToList();
            //return moviesList;
            //List<Movie> moviesList = new List<Movie>();

            //HttpResponseMessage response;
            //response = Request.CreateResponse(HttpStatusCode.OK, moviesList);
            //return response;
            //List<string> moviesList = new List<string>();





            //return new string[] { "movie1 string", "movie2 string" };
        }


        // GET api/values/5

        [Route("movies/all")]
        [HttpGet]
        public IHttpActionResult All()
        {

            // Retrieve movie by id from db logic
            var allMovies = All();
            var moviesId = db.Movies.Select(i => i.Id);
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Movie value)
        {

            //create movie in db logic

        }



        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            // Update movie in db logic
        }

        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int id)
        {
            // Delete movie from db logic
        }
    }

}
