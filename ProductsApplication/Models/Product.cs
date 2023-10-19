namespace ProductsApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Vailidity { get; set; } 

        public Product(int id, string name, int validity) {
            Id = id;
            Name = name;
            Vailidity = validity;
        }
    }
}
