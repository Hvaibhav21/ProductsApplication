
using System.ComponentModel.DataAnnotations;

namespace ProductsApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? genre { get; set; }
        public decimal Price { get; set; }
    }
}
