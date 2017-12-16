using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        
        public IEnumerable<Genre> Genre { get; set; }

        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleasedDate { get; set; }


        

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberLeftInStock { get; set; }
        

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";
                return "New Movie";
                
            }
         }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberLeftInStock = movie.NumberLeftInStock;
            GenreId = movie.GenreId;
        }


    }
}