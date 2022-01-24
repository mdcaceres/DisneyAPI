using DisneyAPI.Entities;
using System.Collections.Generic;

namespace DisneyAPI.DTOs
{
    public class CharacterDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string Story { get; set; }
        public string ImgUrl { get; set; }
        public List<MovieDto> Movies { get; set; }
    }
}
