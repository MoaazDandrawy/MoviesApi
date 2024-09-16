namespace DevcreedApi.DTOS
{
    public class UpdateMovieDto : MovieDto
    {
        public IFormFile? Poster { get; set; }

    }
}
