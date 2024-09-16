using DevcreedApi.Models;

namespace DevcreedApi.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<IEnumerable<Movie>> GetByGenreId(byte GenreId);
        Task<Movie> GetById(int id);

        //Task<IEnumerable<Movie>> GetByGenreId(byte id);
        Task<Movie> Create(Movie movie);
        Movie Update(Movie movie);
        Movie Delete(Movie movie);
    }
}
