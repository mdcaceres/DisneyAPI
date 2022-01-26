using DisneyAPI.Abstract_Factory;
using DisneyAPI.DTOs;
using DisneyAPI.Entities;
using DisneyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyAPI.Controllers
{
    [Route("DisneyAPI/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private IApp<Character> app;
        private MoviesService movieService;
        private Dictionary<string, object> filter;
        public CharactersController()
        {
            app = new CharactersService(new Factory());
            filter = new Dictionary<string, object>();
        }

        [HttpGet]
        public async Task<ActionResult> GetCharacters()
        {
            var lst = await app.GetAllAsync();
            var CharacterDtoLst = lst.Select(item => new CharacterDto
            {
                Name = item.Name,
                ImgUrl = item.ImgUrl
            });
            return Ok(CharacterDtoLst);
        }

        [HttpGet("Details")]
        public async Task<ActionResult> GetCharactersDet()
        {
            var lst = await app.GetAllAsync();
            movieService = new MoviesService(new Factory());
            List<CharacterDetailsDto> characters = new List<CharacterDetailsDto>();

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
                var movieLst = await movieService.GetByCharacterIdAsync(cdet.Id);
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
        public async Task<ActionResult> GetByName(string name)
        {
            filter.Clear();
            filter.Add("@name", name);
            var lst = await app.FilterAsync(filter);
            var characters = lst.Select(item => new CharacterDto { Name = item.Name , ImgUrl = item.ImgUrl});
            return Ok(characters);
        }

        [HttpGet("age={age}")]
        public async Task<ActionResult> GetByAge(int age)
        {
            filter.Clear();
            filter.Add("@age", age);
            var lst = await app.FilterAsync(filter);
            var characters = lst.Select(item => new CharacterDto { Name = item.Name, ImgUrl = item.ImgUrl });
            return Ok(characters);
        }

        [HttpGet("weight={weight}")]
        public async Task<ActionResult> GetByWeight(decimal weight)
        {
            filter.Clear();
            filter.Add("@weight", weight);
            var lst = await app.FilterAsync(filter);
            var characters = lst.Select(item => new CharacterDto { Name = item.Name, ImgUrl = item.ImgUrl });
            return Ok(characters);
        }

        [HttpGet("Movie={idMovie}")]
        public async Task<ActionResult> GetByMovieId(int idMovie)
        {
            filter.Clear();
            filter.Add("@idMovie", idMovie);
            var lst = await app.FilterAsync(filter);
            var characters = lst.Select(item => new CharacterDto { Name = item.Name, ImgUrl = item.ImgUrl });
            return Ok(characters);
        }

        [HttpPost("Create")]
        public ActionResult Create(CreateCharacDto cc)
        {
            Character c = new Character(cc.Name, cc.Age, cc.Weight, cc.Story, cc.ImgUrl);
            app.CreateAsync(c);
            return CreatedAtAction(nameof(GetCharacters), cc);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(int id, UpdatedCharacDto updated)
        {
            Character c = new Character(id, updated.Name, updated.Age, updated.Weight, updated.Story, updated.ImgUrl);
            await app.UpdateAsync(c);
            return Ok("Character Updated");
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await app.DeleteAsync(id);
            return Ok("Character Deleted");
        }
    }
}
