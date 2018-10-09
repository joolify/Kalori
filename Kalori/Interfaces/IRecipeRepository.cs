using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> Get();
        Recipe Get(int id);
        Food GetFood(int? id);
        CategoryType GetCategoryType(int? id);
        void Add(Recipe recipe);
        void Save();
        void Remove(Recipe recipe);
        void Dispose(bool disposing);
    }
}