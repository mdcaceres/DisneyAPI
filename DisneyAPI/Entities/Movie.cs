using System;
using System.Collections.Generic;

namespace DisneyAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string ImgUrl { get; set; }
        public List<Character> Characters { get; set;}
        public List<Gender> Genders { get; set; }

        public override string ToString() { return $"Id:{Id},Title:{Title},Date:{Date},Rating:{Rating}";}

    }
}
