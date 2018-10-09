using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Kalori.Interfaces;
using Kalori.Models;

namespace Kalori.Repositories
{
    public class ShoppinglistRepository : IShoppinglistRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public Shoppinglist Get(int id)
        {
            return _context.Shoppinglists.Include(c => c.Products).SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Product> GetProducts(int id)
        {
            return _context.Products.Include(c => c.Food).Where(c => c.ShoppinglistId == id).ToList();      
        }
        public Food GetFood(int? id)
        {
            return _context.Foods.FirstOrDefault(c => c.Id == id);
        }

        public CategoryType GetCategoryType(int? id)
        {
            return _context.CategoryTypes.FirstOrDefault(c => c.Category == id);
        }

        public void Save(Shoppinglist shoppinglist)
        {
            _context.Shoppinglists.Add(shoppinglist);
            _context.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}