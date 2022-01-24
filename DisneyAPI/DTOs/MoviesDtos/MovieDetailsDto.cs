using DisneyAPI.Entities;
using System;
using System.Collections.Generic;

namespace DisneyAPI.DTOs
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string ImgUrl { get; set; }
        public List<CharacterDto> Characters { get; set; }
        public List<GenderDto> Genders { get; set; }
    }
}
