using E_ComerceApp.Entities;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;

namespace E_CommerceApp.Repositories.Classes
{
    public class ProductRepository:IProductRepository
    {
        private readonly E_CommerceEntities _context;

        public ProductRepository(E_CommerceEntities context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
