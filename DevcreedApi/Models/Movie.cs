using System.ComponentModel.DataAnnotations;

namespace DevcreedApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }

        [MaxLength(2500)]
        public string Storeline { get; set; }
        public byte[] Poster { get; set; }
        //foreign Key w hoa et3ml auto mn 8er attribute [DataAnnotations]
        public byte GenreId { get; set; }
        
        //Navigation Property
        public Genre Genre { get; set; }
    }
}
