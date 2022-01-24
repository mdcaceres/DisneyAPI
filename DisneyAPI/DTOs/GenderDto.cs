namespace DisneyAPI.DTOs
{
    public class GenderDto
    {
        public GenderDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
