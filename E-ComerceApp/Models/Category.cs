namespace E_CommerceApp.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}