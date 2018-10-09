using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Repositories;
using Kalori.ViewModels;

namespace Kalori.Services
{
    public class RecipeService
    {
        private IRecipeRepository _recipeRepo;

        public RecipeService()
        {
            _recipeRepo = new RecipeRepository();
        }

        public RecipeService(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        public void Dispose(bool disposing)
        {
            _recipeRepo.Dispose(disposing);
        }

        public List<Recipe> Get()
        {
            return _recipeRepo.Get();
        }

        public Recipe Get(int id)
        {
            return _recipeRepo.Get(id);
        }

        public void Add(Recipe recipe)
        {
            _recipeRepo.Add(recipe);
        }
    }
}