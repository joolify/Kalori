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
            return _context.Recipes.ToList();
        }

        public Recipe Get(int id)
        {
            return _context.Recipes
                .Include(c => c.Image)
                .Include(c => c.Products.Select(o => o.Food))
                .Include(c => c.Instructions)
                .SingleOrDefault(c => c.Id == id);
        }

        public void Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }


    }
}