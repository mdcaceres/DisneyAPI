namespace DisneyAPI.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public override string ToString() { return $"Id:{Id},{Name}"; }
    }
}
