using DisneyAPI.Abstract_Factory;
using DisneyAPI.DTOs;
using DisneyAPI.Entities;
using DisneyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DisneyAPI.Controllers
{
    [Route("DisneyAPI/[Controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IApp app;

        public MoviesController()
        {
            app = new App(new Factory());
        }

        [HttpGet]
        public ActionResult GetMovies()
        {
            var lst = app.ListAllMovies().Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(lst);
        }

        [HttpGet("Details")]
        public ActionResult GetMoviesDet()
        {
            List<MovieDetailsDto> moviesDet = new List<MovieDetailsDto>();  
            var lst = app.ListAllMovies();
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
                var characters = app.GetCharactersByMovie(item.Id);
                var genders = app.GetMovieGenders(item.Id);
                foreach (var cter in characters) 
                {
                    CharacterDto cd = new CharacterDto();
                    cd.Name = cter.Name;
                    cd.ImgUrl = cter.ImgUrl;
                    movie.Characters.Add(cd);
                }
                foreach (var gender in genders)
                {
                    GenderDto genderDto = new GenderDto(gender.Id,gender.Name);
                    movie.Genders.Add(genderDto);

                }
                moviesDet.Add(movie);
            }
            return Ok(moviesDet);
        }

        [HttpGet("title={title}")]
        public ActionResult GetByName(string title)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("@title", title);
            var lst = app.FilterMovies(filter).Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(lst);
        }

        [HttpGet("gender={idGender}")]
        public ActionResult GetByGender(int idGender)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("@gender", idGender);
            var lst = app.FilterMovies(filter).Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(lst);
        }

        [HttpGet("orderBy={order}")]
        public ActionResult GetByOrder(string order)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("@order", order);
            var lst = app.FilterMovies(filter).Select(item => new MovieDto
            {
                Title = item.Title,
                Date = item.Date,
                ImgUrl = item.ImgUrl,
            });
            return Ok(lst);
        }

        [HttpPost("Create")]
        public ActionResult CreateMovie(CreateMovieDto movieDto)
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

            app.CreateMovie(m);
            return CreatedAtAction(nameof(GetMovies),movieDto); 
        }

        [HttpPut("Update")]
        public IActionResult UpdateMovie(int id, UpdateMovieDto updatedMovie)
        {
            Movie m = new Movie(); 
            m.Title = updatedMovie.Title;
            m.Date = updatedMovie.Date;
            m.Rating = updatedMovie.Rating;
            m.ImgUrl = updatedMovie.ImgUrl;
            app.UpdateMovie(id, m);
            return Ok("successful update");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteMovie(int id) 
        {
            app.DeleteMovie(id);
            return Ok("deleted movie");
        }
    }
}
