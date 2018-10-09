using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using Kalori.Interfaces;
using Kalori.Models;

namespace Kalori.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext _context;

        public RecipeRepository()
        {
            _context = new ApplicationDbContext();
        }
        public List<Recipe> Get()
        {
            return _context.Recipes.Include(c => c.Products).ToList();
        }

        public Recipe Get(int id)
        {
            return _context.Recipes
                .Include(c => c.Image)
                .Include(c => c.Products.Select(o => o.Food))
                .Include(c => c.Instructions)
                .SingleOrDefault(c => c.Id == id);
        }

        public Food GetFood(int? id)
        {
            return _context.Foods.SingleOrDefault(c => c.Id == id);
        }
        public CategoryType GetCategoryType(int? id)
        {
            return _context.CategoryTypes.SingleOrDefault(c => c.Id == id);
        }

        public void Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Remove(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }
        public void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}