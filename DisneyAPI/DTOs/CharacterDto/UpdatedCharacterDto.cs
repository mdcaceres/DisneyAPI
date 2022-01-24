using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.DTOs
{
    public class UpdatedCharacDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "weight is required")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "story is required")]
        public string Story { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string ImgUrl { get; set; }
    }
}
