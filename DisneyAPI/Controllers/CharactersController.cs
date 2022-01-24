using DisneyAPI.Abstract_Factory;
using DisneyAPI.DTOs;
using DisneyAPI.Entities;
using DisneyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DisneyAPI.Controllers
{
    [Route("DisneyAPI/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private IApp app;
        private Dictionary<string, object> filter;
        public CharactersController()
        {
            app = new App(new Factory());
            filter = new Dictionary<string, object>();
        }

        [HttpGet]
        public ActionResult GetCharacters()
        {
            var lst = app.ListAllCharacters().Select(item => new CharacterDto
            {
                Name = item.Name,
                ImgUrl = item.ImgUrl
            });

            return Ok(lst);
        }

        [HttpGet("Details")]
        public ActionResult GetCharactersDet()
        {
            List<CharacterDetailsDto> characters = new List<CharacterDetailsDto>();
            var lst = app.ListAllCharacters();
            foreach (var item in lst)
            {
                CharacterDetailsDto cdet = new CharacterDetailsDto();
                cdet.Id = item.Id;
                cdet.Name = item.Name;
                cdet.Age = item.Age;
                cdet.Weight = item.Weight;
                cdet.Story = item.Story;
                cdet.ImgUrl = item.ImgUrl;
                cdet.Movies = new List<MovieDto>();
                var movieLst = app.GetMoviesByCharacter(cdet.Id);
                foreach (var movie in movieLst)
                {
                    MovieDto movieDto = new MovieDto();
                    movieDto.Title = movie.Title;
                    movieDto.Date = movie.Date;
                    movieDto.ImgUrl = movie.ImgUrl;
                    cdet.Movies.Add(movieDto);
                }
                characters.Add(cdet);
            }

            return Ok(characters);
        }

        [HttpGet("name={name}")]
        public ActionResult GetByName(string name)
        {
            filter.Clear();
            filter.Add("@name", name);
            var lst = app.FilterCharacter(filter).Select(item => new CharacterDto
            {
                Name = item.Name,
                ImgUrl = item.ImgUrl
            });
            return Ok(lst);
        }

        [HttpGet("age={age}")]
        public ActionResult GetByAge(int age)
        {
            filter.Clear();
            filter.Add("@age", age);
            var lst = app.FilterCharacter(filter).Select(item => new CharacterDto
            {
                Name = item.Name,
                ImgUrl = item.ImgUrl
            });
            return Ok(lst);
        }

        [HttpGet("weight={weight}")]
        public ActionResult GetByWeight(decimal weight)
        {
            filter.Clear();
            filter.Add("@weight", weight);
            var lst = app.FilterCharacter(filter).Select(item => new CharacterDto
            {
                Name = item.Name,
                ImgUrl = item.ImgUrl
            });
            return Ok(lst);
        }

        [HttpGet("Movie={idMovie}")]
        public ActionResult GetByMovieId(int idMovie)
        {
            filter.Clear();
            filter.Add("@idMovie", idMovie);
            var lst = app.FilterCharacter(filter).Select(item => new CharacterDto
            {
                Name = item.Name,
                ImgUrl = item.ImgUrl
            });
            return Ok(lst);
        }

        [HttpPost("Create")]
        public ActionResult Create(CreateCharacDto cc) 
        {
            Character c = new Character(cc.Name,cc.Age,cc.Weight,cc.Story,cc.ImgUrl);
            app.CreateCharacter(c);
            return CreatedAtAction(nameof(GetCharacters), cc); 
        }

        [HttpPut("Update")]
        public ActionResult Update(int id,UpdatedCharacDto updated)
        {
            Character c = new Character(id,updated.Name, updated.Age, updated.Weight, updated.Story, updated.ImgUrl);
            app.UpdateCharacter(c);
            return Ok("Character Updated");
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            app.DeleteCharacter(id);
            return Ok("Character Deleted");
        }
    }
}
