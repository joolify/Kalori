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

        public IEnumerable<Shoppinglist> GetList()
        {
            return _context.Shoppinglists.Include(m => m.Products).ToList();
        }

        public IEnumerable<Product> GetProducts(int id)
        {
            return _context.Products
                .Include(c => c.Food)
                .Include(c => c.CategoryType)
                .Where(c => c.ShoppinglistId == id).ToList();      
        }

        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public Food GetFood(int? id)
        {
            return _context.Foods.FirstOrDefault(c => c.Id == id);
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id);
        }

        public CategoryType GetCategoryType(int? id)
        {
            return _context.CategoryTypes.FirstOrDefault(c => c.Category == id);
        }

        public void Add(Shoppinglist shoppinglist)
        {
            _context.Shoppinglists.Add(shoppinglist);
            _context.SaveChanges();
        }

        public void Remove(Shoppinglist shoppinglist)
        {
            _context.Shoppinglists.Remove(shoppinglist);
            _context.SaveChanges();
        }
        public void Save()
        {
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