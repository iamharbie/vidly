using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime ReleasedDate { get; set; }

        
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public int NumberLeftInStock { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public byte NumberAvailable { get; set; }
    }
}