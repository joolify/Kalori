// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="RecipeService.cs" company="joolify">
//     Copyright © joolify 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.UoW;

namespace Kalori.Services
{
    /// <summary>
    /// Class RecipeService.
    /// </summary>
    public class RecipeService : Service<Recipe>
    {
        public RecipeService() : base()
        {
            
        }

        public RecipeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        /********************************************************
         **** GETTERS
         ********************************************************/

        /// <summary>
        /// Gets the specified Recipe.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Recipe.</returns>
        public Recipe Get(int id)
        {
            return _unitOfWork.Recipes.GetRecipe(id);
        }

        /// <summary>
        /// Gets all Recipes.
        /// </summary>
        /// <returns>IEnumerable&lt;Recipe&gt;.</returns>
        public IEnumerable<Recipe> GetAll()
        {
            return _unitOfWork.Recipes.GetAllRecipes();
        }

        /// <summary>
        /// Gets a specified Product.
        /// </summary>
        /// <param name="id">The Product identifier.</param>
        /// <returns>Product.</returns>
        public Product GetProduct(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        /// <summary>
        /// Gets a specified Food.
        /// </summary>
        /// <param name="id">The Food identifier.</param>
        /// <returns>Food.</returns>
        public Food GetFood(int? id)
        {
            return _unitOfWork.Foods.Get(id);
        }

        /// <summary>
        /// Gets a specified CategoryType.
        /// </summary>
        /// <param name="id">The Category identifier.</param>
        /// <returns>CategoryType.</returns>
        public CategoryType GetCategoryType(int? id)
        {
            return _unitOfWork.Foods.GetCategoryType(id);
        }

        /// <summary>
        /// Gets the temporary recipe.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Recipe.</returns>
        public Recipe GetTempRecipe(string key)
        {
            return _unitOfWork.Recipes.GetTempObj(key) as Recipe;
        }


        /********************************************************
         **** ADDERS
         ********************************************************/

        /// <summary>
        /// Adds or updates a Recipe.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        public void AddOrUpdate(Recipe recipe)
        {
            _unitOfWork.Recipes.AddOrUpdate(recipe);
        }

        /// <summary>
        /// Sets the temporary Recipe.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetTempRecipe(string key, Recipe value)
        {
            _unitOfWork.Recipes.SetTempObj(key, value);
        }

        /********************************************************
        **** REMOVERS
        ********************************************************/
        /// <summary>
        /// Removes the specified recipe.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        public void Remove(Recipe recipe)
        {
            _unitOfWork.Recipes.Attach(recipe);
            _unitOfWork.Recipes.Remove(recipe);
        }

        /// <summary>
        /// Removes a list of Products.
        /// </summary>
        /// <param name="products">The products.</param>
        public void RemoveRange(IEnumerable<Product> products)
        {
            _unitOfWork.Products.AttachRange(products);
            _unitOfWork.Products.RemoveRange(products);
        }

        /// <summary>
        /// Removes a list of Instructions.
        /// </summary>
        /// <param name="instructions">The instructions.</param>
        public void RemoveRange(IEnumerable<Instruction> instructions)
        {
            _unitOfWork.Recipes.AttachRange(instructions);
            _unitOfWork.Recipes.RemoveRange(instructions);
        }
    }
}