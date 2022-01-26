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
            var characters = lst.Select(item => new CharacterDetailsDto
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Weight = item.Weight,
                Story = item.Story,
                ImgUrl = item.ImgUrl,
                //Movies = new List<MovieDto>() { }
            }); 

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
