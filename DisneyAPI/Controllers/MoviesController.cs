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
   [Route("DisneyAPI/[Controller]")]
   [ApiController]
    public class MoviesController : ControllerBase
    {
        private IApp<Movie> app;
        //private IApp<Character> characterService;
        private CharactersService characterService; 
        private GendersService genderService;

        public MoviesController()
        {
            app = new MoviesService(new Factory());
        }

        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            var lst = await app.GetAllAsync();
            var movies = lst.Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(movies);
        }

        [HttpGet("Details")]
        public async Task<ActionResult> GetMoviesDet()
        {
            List<MovieDetailsDto> moviesDet = new List<MovieDetailsDto>();
            var lst = await app.GetAllAsync();
            foreach (var item in lst)
            {
                var movie = new MovieDetailsDto();
                movie.Id = item.Id;
                movie.Title = item.Title;
                movie.Date = item.Date;
                movie.Rating = item.Rating;
                movie.ImgUrl = item.ImgUrl;
                movie.Date = item.Date;
                movie.Characters = new List<CharacterDto>();
                movie.Genders = new List<GenderDto>();
                characterService = new CharactersService(new Factory()); 
                var characters = await characterService.GetByMovieIdAsync(movie.Id);
                genderService = new GendersService(new Factory()); 
                var genders = await genderService.GetByMovieIdAsync(item.Id);
                foreach (var cter in characters)
                {
                    CharacterDto cd = new CharacterDto();
                    cd.Name = cter.Name;
                    cd.ImgUrl = cter.ImgUrl;
                    movie.Characters.Add(cd);
                }
                foreach (var gender in genders)
                {
                    GenderDto genderDto = new GenderDto(gender.Id, gender.Name);
                    movie.Genders.Add(genderDto);
                }
                moviesDet.Add(movie);
            }
            return Ok(moviesDet);
        }

        [HttpGet("title={title}")]
        public async Task<ActionResult> GetByName(string title)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("@title", title);
            var lst = await app.FilterAsync(filter);
            var movies = lst.Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(movies);
        }

        [HttpGet("gender={idGender}")]
        public async Task<ActionResult> GetByGender(int idGender)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("@gender", idGender);
            var lst = await app.FilterAsync(filter);
            var movies = lst.Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(movies);
        }

        [HttpGet("orderBy={order}")]
        public async Task<ActionResult> GetByOrder(string order)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("@order", order);
            var lst = await app.FilterAsync(filter);
            var movies = lst.Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(movies);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateMovie(CreateMovieDto movieDto)
        {
            Movie m = new Movie();
            m.Title = movieDto.Title;
            m.Date = movieDto.Date;
            m.Rating = movieDto.Rating;
            m.ImgUrl = movieDto.ImgUrl;
            m.Characters = new List<Character>();
            m.Genders = new List<Gender>();
            foreach (int id in movieDto.CharactersIds)
            {
                Character c = new Character();
                c.Id = id;
                m.Characters.Add(c);
            }
            foreach (int id in movieDto.GendersIds)
            {
                Gender g = new Gender();
                g.Id = id;
                m.Genders.Add(g);
            }

            await app.CreateAsync(m);
            return CreatedAtAction(nameof(GetMovies), movieDto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updatedMovie)
        {
            Movie m = new Movie();
            m.Id = id;
            m.Title = updatedMovie.Title;
            m.Date = updatedMovie.Date;
            m.Rating = updatedMovie.Rating;
            m.ImgUrl = updatedMovie.ImgUrl;
            await app.UpdateAsync(m);
            return Ok("successful update");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await app.DeleteAsync(id);
            return Ok("deleted movie");
        }
    }
}
