namespace DisneyAPI.Entities
{
    public class Gender
    {
        public Gender(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Gender()
        {
            Id = int.MinValue;
            Name = string.Empty;
            ImgUrl = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public override string ToString() { return $"Id:{Id},{Name}"; }
    }
}
