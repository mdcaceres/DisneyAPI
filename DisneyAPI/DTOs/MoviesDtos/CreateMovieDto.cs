using DisneyAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.DTOs
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Url is required")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "List of Characters Ids are required")]
        public List<int> CharactersIds { get; set; }

        [Required(ErrorMessage = "List of Genders Ids are required")]
        public List<int> GendersIds { get; set; }

    }
}
