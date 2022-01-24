using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.DTOs
{
    public class CreateCharacDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "Story is required")]
        public string Story { get; set; }
        [Required(ErrorMessage = "ImgUrl is required")]
        public string ImgUrl { get; set; }


    }
}
