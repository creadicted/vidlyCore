using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;

namespace VidlyCore.ViewModel
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public IEnumerable<Genres> Genres  { get; set; }

        [HiddenInput]
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name = "Number In Stock")]
        public byte? NumberInStock { get; set; }

        public string Title
         {
             get
             {
                 return Id == 0 ? "New Movie" : "Edit Movie";
             }
         }
        
    }
}
