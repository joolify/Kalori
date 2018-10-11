using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipe(int id);
        void RemoveRange(IEnumerable<Instruction> instructions);
        void AttachRange(IEnumerable<Instruction> instructions);
    }
}