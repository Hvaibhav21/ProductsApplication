using System.ComponentModel.DataAnnotations;
namespace ProductsApplication.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? genre { get; set; }
        [Required (ErrorMessage ="Please add the price")]
        public decimal Price { get; set; }
    }
}
