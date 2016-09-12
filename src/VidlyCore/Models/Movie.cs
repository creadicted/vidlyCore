using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VidlyCore.Models
{
    public class Movie
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Title")]
        public string Name { get; set; }
        
        public Genres Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Added")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 10)]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }
    }
}
