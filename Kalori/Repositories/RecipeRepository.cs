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
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public RecipeRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.Include(c => c.Products).ToList();
        }

        public Recipe GetRecipe(int id)
        {
            return _context.Recipes
                .Include(c => c.Image)
                .Include(c => c.Products.Select(o => o.Food))
                .Include(c => c.Instructions)
                .SingleOrDefault(c => c.Id == id);
        }

        public void RemoveRange(IEnumerable<Instruction> instructions)
        {
            _context.Instructions.RemoveRange(instructions);
        }

        public void AttachRange(IEnumerable<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (!_context.Instructions.Local.Contains(instruction))
                    _context.Instructions.Attach(instruction);
            }
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

    }
}