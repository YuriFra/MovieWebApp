using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Theater
    {
        public int TheaterId { get; set; }
        [Display(Name = "Theater")]
        public string Name { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}