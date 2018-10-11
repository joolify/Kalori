using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Kalori.Interfaces;
using Kalori.Models;

namespace Kalori.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        //FIXME => IProductRepository
        public IEnumerable<Product> GetProductsWithFoodAndCategoryTypeOfShoppingList(int id)
        {
            return _context.Products
                .Include(c => c.Food)
                .Include(c => c.CategoryType)
                .Where(c => c.ShoppinglistId == id).ToList();      
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext;}
        }
    }
}