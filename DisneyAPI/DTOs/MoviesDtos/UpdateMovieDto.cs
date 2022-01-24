using DisneyAPI.Data;
using DisneyAPI.Entities;
using DisneyAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DisneyAPI.DTOs
{
    public class UpdateMovieDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Image Url is required")]
        public string ImgUrl { get; set; }
    }
}
