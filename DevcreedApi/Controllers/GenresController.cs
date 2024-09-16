using DevcreedApi.DTOS;
using DevcreedApi.Models;
using DevcreedApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevcreedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Genres = await _genreService.GetAll();
            return Ok(Genres);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(GenreDto dto)
        {
            Genre genre = new Genre();
            genre.Name = dto.Name;
            await _genreService.Create(genre);
            return Ok(genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] GenreDto dto)
        {
            var genre = await _genreService.GetById(id);
            if (genre == null) { return NotFound($"No Genre Found With ID:{id}"); }
            genre.Name = dto.Name;
            _genreService.Update(genre);
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genreService.GetById(id);
            if (genre == null) { return NotFound($"No Genre Found With ID:{id}"); }
            _genreService.Delete(genre);
            return Ok($"Genre with ID:{genre.Id} Name:\"{genre.Name}\" was Deleted successfully");
        }
    }
}