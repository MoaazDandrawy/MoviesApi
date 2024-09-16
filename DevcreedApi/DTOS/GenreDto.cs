using System.ComponentModel.DataAnnotations;

namespace DevcreedApi.DTOS
{
    public class GenreDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
