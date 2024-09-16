using AutoMapper;
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
    public class MoviesController : ControllerBase
    {

        #region di 3lshan ast2bl f el poster extensions mo3ina w b size mo3ain
        private List<string> _alllowedExtensions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576; //1048576 = 1 Mb
        #endregion

        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IGenreService genreService, IMapper mapper)
        {
            _movieService = movieService;
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Movies = await _movieService.GetAll();
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(Movies);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var movie = await _movieService.GetById(id);
            if (movie == null) { return NotFound($"Movie with ID:{id} Not Found"); }
            var data = _mapper.Map<MovieDetailsDto>(movie);
            return Ok(data);
        }

        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetByGenreIdAsync(byte GenreId)
        {
            var movies = await _movieService.GetByGenreId(GenreId);
            bool IsGenre = await _genreService.IsValidGenre(GenreId);
            if (!IsGenre) return NotFound($"No Genre With ID:{GenreId}");
            if (movies.Count() == 0) return NotFound("No Movies in this Genre");
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movies);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateMovieDto movieDto)
        {
            if (!_alllowedExtensions.Contains(Path.GetExtension(movieDto.Poster.FileName).ToLower()))
            {
                return BadRequest("Only .png and .jpg are Allowed");
            }
            if (movieDto.Poster.Length > _maxAllowedPosterSize)
            {
                return BadRequest("Max allowed Size is 1MB");
            }

            #region da 3lshan el end user mib3tsh genre id msh mawgood aslan
            bool isValidGenre = await _genreService.IsValidGenre(movieDto.GenreId);
            if (!isValidGenre) { return BadRequest("Invalid Genre ID"); }
            #endregion

            #region di 3lshan a7awl mn el IformFile(gaya mn el user aw el frontend) l arrayOfBytes[] elly ha3mlha store f DB
            var dataStream = new MemoryStream();
            await movieDto.Poster.CopyToAsync(dataStream);
            #endregion

            var data = _mapper.Map<Movie>(movieDto);
            data.Poster = dataStream.ToArray();

            await _movieService.Create(data);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateMovieDto movieDto)
        {
            var movieOld = await _movieService.GetById(id);
            if (movieOld == null) { return NotFound($"No Movie with ID:{id}"); }

            if (movieDto.Poster != null)// di m3naha en el user 3awz y3ml update 3la el poster 
            {
                if (!_alllowedExtensions.Contains(Path.GetExtension(movieDto.Poster.FileName).ToLower()))
                {
                    return BadRequest("Only .png and .jpg are Allowed");
                }
                if (movieDto.Poster.Length > _maxAllowedPosterSize)
                {
                    return BadRequest("Max allowed Size is 1MB");
                }
                var dataStream = new MemoryStream();
                await movieDto.Poster.CopyToAsync(dataStream);
                movieOld.Poster = dataStream.ToArray();
            }
            #region da 3lshan el end user mib3tsh genre id msh mawgood aslan
            bool isValidGenre = await _genreService.IsValidGenre(movieDto.GenreId);
            if (!isValidGenre) { return BadRequest("Invalid Genre ID"); }
            #endregion

            _mapper.Map(movieDto,movieOld);

            _movieService.Update(movieOld);
            return Ok(movieOld);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie = await _movieService.GetById(id);
            if (movie == null) { return NotFound("No Movie With this ID Found"); }
            _movieService.Delete(movie);
            return Ok(movie);
        }
    }
}
