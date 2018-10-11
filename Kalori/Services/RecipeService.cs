using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Repositories;
using Kalori.UoW;
using Kalori.ViewModels;
using Microsoft.Ajax.Utilities;

namespace Kalori.Services
{
    public class RecipeService
    {

        private readonly IUnitOfWork _unitOfWork;

        public RecipeService()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }

        public void Complete()
        {
            _unitOfWork.Complete();
        }
        /********************************************************
         **** GETTERS
         ********************************************************/
        public Recipe Get(int id)
        {
            return _unitOfWork.Recipes.GetRecipe(id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _unitOfWork.Recipes.GetAllRecipes();
        }
        
        public Product GetProduct(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public Food GetFood(int? id)
        {
            return _unitOfWork.Foods.Get(id);
        }
        public CategoryType GetCategoryType(int? id)
        {
            return _unitOfWork.Foods.GetCategoryType(id);
        }

        public Recipe GetTempRecipe(string key)
        {
            return System.Web.Helpers.WebCache.Get(key) as Recipe;
        }


        /********************************************************
         **** ADDERS
         ********************************************************/

        public void AddOrUpdate(Recipe recipe)
        {
            _unitOfWork.Recipes.AddOrUpdate(recipe);
        }

        public void SetTempRecipe(string key, Recipe value)
        {
            System.Web.Helpers.WebCache.Set(key, value);
        }

         /********************************************************
         **** REMOVERS
         ********************************************************/
        public void Remove(Recipe recipe)
        {
            _unitOfWork.Recipes.Attach(recipe);
            _unitOfWork.Recipes.Remove(recipe);
        }

        public void RemoveRange(IEnumerable<Product> products)
        {
            _unitOfWork.Products.AttachRange(products);
            _unitOfWork.Products.RemoveRange(products);
        }
        public void RemoveRange(IEnumerable<Instruction> instructions)
        {
            _unitOfWork.Recipes.AttachRange(instructions);
            _unitOfWork.Recipes.RemoveRange(instructions);
        }
    }
}