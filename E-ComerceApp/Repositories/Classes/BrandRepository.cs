using E_ComerceApp.Entities;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;

namespace E_CommerceApp.Repositories.Classes
{
    public class BrandRepository : IBrandRepository
    {
        private readonly E_CommerceEntities _context;

        public BrandRepository(E_CommerceEntities context)
        {
            _context = context;
        }

        public List<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public Brand GetBrandById(int id)
        {
            return _context.Brands.Find(id);
        }

        public void CreateBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            var brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}

