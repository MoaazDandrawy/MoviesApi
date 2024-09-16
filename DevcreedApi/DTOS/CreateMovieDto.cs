namespace DevcreedApi.DTOS
{
    public class CreateMovieDto : MovieDto
    {
        public IFormFile Poster { get; set; }

    }
}
