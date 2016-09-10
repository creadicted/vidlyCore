﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VidlyCore.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public Genres Genre { get; set; }

        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }
    }
}
