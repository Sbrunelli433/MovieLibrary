﻿using System;
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
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            var moviesList = db.Movies.ToList();
            ret= Ok(moviesList);
            return ret;
        }


        // GET api/values/5
        //[Route("movies/all")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            // Retrieve movie by id from db logic
            var moviesId = db.Movies.Where(i => i.Id == id).FirstOrDefault();
            if (moviesId != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, moviesId);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie with Id " + moviesId.ToString() + " not found");
            }
            //return Ok(moviesId);
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Movie value)
        {
            try
            {
                db.Movies.Add(value);
                db.SaveChanges();

                var response = Request.CreateResponse<Movie>(HttpStatusCode.Created, value);
                response.Headers.Location = new Uri(Request.RequestUri + value.Id.ToString());
                return response;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        //private bool Add(Movie movie)
        //{
        //    int newId = 0;
        //    List<Movie> list = new List<Movie>();

        //    newId = list.Max(p => p.Id);
        //    list.Add(movie);
        //    return true;
        //}


        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Movie value)
        {
            var movie = db.Movies.FirstOrDefault(e => e.Id == id);
            if (movie == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie with Id " + id.ToString() + " not found");
            }
            else
            {
                movie.Title = value.Title;
                movie.DirectorName = value.DirectorName;
                movie.Genre= value.Genre;

                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, movie);
            }
            // Update movie in db logic
        }

        [HttpDelete]
        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var moviesId = db.Movies.Where(i => i.Id == id).FirstOrDefault();
            if (moviesId == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie with Id " + moviesId.ToString() + " not found");
            }
            else
            {
                db.Movies.Remove(moviesId);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            // Delete movie from db logic
        }
    }

}
