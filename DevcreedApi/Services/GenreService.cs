using DevcreedApi.DTOS;
using DevcreedApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DevcreedApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;
        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.OrderBy(g => g.Name).ToListAsync();
        }

        public async Task<Genre> Create(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            _context.SaveChanges();
            return genre;
        }
        public Task<Genre> GetById(byte id)
        {
            return _context.Genres.SingleOrDefaultAsync(g => g.Id == id);
        }
        public Genre Update(Genre genre)
        {
            _context.Update(genre);
            _context.SaveChanges();
            return genre;
        }
        public Genre Delete(Genre genre)
        {
            _context.Remove(genre);
            _context.SaveChanges();
            return genre;
        }

        public Task<bool> IsValidGenre(byte id)
        {
            return _context.Genres.AnyAsync(g => g.Id == id);
        }
    }
}
