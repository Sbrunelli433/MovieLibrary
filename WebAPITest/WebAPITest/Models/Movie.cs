using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPITest.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string Genre { get; set; }
    }
}