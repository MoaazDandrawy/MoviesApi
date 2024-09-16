using DevcreedApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DevcreedApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.OrderByDescending(m => m.Rate).Include(m => m.Genre).ToListAsync();
        }
        public async Task<IEnumerable<Movie>> GetByGenreId(byte GenreId)
        {
            return await _context.Movies.Where(m => m.GenreId == GenreId).OrderByDescending(m => m.Rate).Include(m => m.Genre).ToListAsync();
        }
        public async Task<Movie> GetById(int id)
        {
            return await _context.Movies.Include(m => m.Genre).SingleOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Movie> Create(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }
        public Movie Update(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }
        public Movie Delete(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
            return movie;
        }

        
    }
}
