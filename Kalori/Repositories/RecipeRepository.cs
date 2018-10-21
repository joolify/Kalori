// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="RecipeRepository.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class RecipeRepository.
    /// </summary>
    /// <seealso cref="Kalori.Repositories.Repository{Kalori.Models.Recipe}" />
    /// <seealso cref="Kalori.Interfaces.IRecipeRepository" />
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context = new ApplicationDbContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RecipeRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        /// <summary>
        /// Gets all Recipes and respective Products.
        /// </summary>
        /// <returns>IEnumerable&lt;Recipe&gt;.</returns>
        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.Include(c => c.Products).ToList();
        }

        /// <summary>
        /// Gets the recipe and belonging Image, Instructions and Products.
        /// </summary>
        /// <param name="id">The Recipe identifier.</param>
        /// <returns>Recipe.</returns>
        public Recipe GetRecipe(int id)
        {
            return _context.Recipes
                .Include(c => c.Image)
                .Include(c => c.Products.Select(o => o.Food))
                .Include(c => c.Instructions)
                .SingleOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Removes a list of Instructions.
        /// </summary>
        /// <param name="instructions">The instructions.</param>
        public bool RemoveRange(IEnumerable<Instruction> instructions)
        {
            _context.Instructions.RemoveRange(instructions);
            foreach (var instruction in instructions)
            {
                if (Exists(instruction))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Attaches a list of Instructions.
        /// </summary>
        /// <param name="instructions">The instructions.</param>
        public void AttachRange(IEnumerable<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (!_context.Instructions.Local.Contains(instruction))
                    _context.Instructions.Attach(instruction);
            }
        }
        /// <summary>
        /// Gets the application database context.
        /// </summary>
        /// <value>The application database context.</value>
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

    }
}