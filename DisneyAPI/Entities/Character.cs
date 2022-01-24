using System.Collections.Generic;

namespace DisneyAPI.Entities
{
    public class Character
    {
        public Character()
        {
            Id = int.MinValue;
            Name = string.Empty;
            Age = int.MinValue;
            Weight = decimal.MinValue;
            Story = string.Empty;
            ImgUrl = string.Empty;
        }

        public Character(string name, int age, decimal weight, string story, string imgUrl)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Story = story;
            ImgUrl = imgUrl;
        }

        public Character(int id,string name, int age, decimal weight, string story, string imgUrl)
        {
            Id = id;
            Name = name;
            Age = age;
            Weight = weight;
            Story = story;
            ImgUrl = imgUrl;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string Story { get; set; }
        public string ImgUrl { get; set; }
        public override string ToString() { return $"Id:{Id},Name:{Name},Age:{Age},Weight:{Weight},Story:{Story}"; }
    }
}
