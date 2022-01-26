namespace DisneyAPI.DTOs
{
    public class CharacterDto
    {
        public CharacterDto(string name, string imgUrl) 
        {
            Name = name;
            ImgUrl = imgUrl;
        }
        public CharacterDto()
        {
            Name = string.Empty;
            ImgUrl = string.Empty;
        }
        public string Name { get; set; }
        public string ImgUrl { get; set; }

    }
}
