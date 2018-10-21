// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-11-2018
// ***********************************************************************
// <copyright file="IRecipeRepository.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    /// <summary>
    /// Interface IRecipeRepository
    /// </summary>
    /// <seealso cref="Kalori.Interfaces.IRepository{Kalori.Models.Recipe}" />
    public interface IRecipeRepository : IRepository<Recipe>
    {
        /// <summary>
        /// Gets all Recipes and respective Products.
        /// </summary>
        /// <returns>IEnumerable&lt;Recipe&gt;.</returns>
        IEnumerable<Recipe> GetAllRecipes();
        /// <summary>
        /// Gets the recipe and belonging Immage, Instructions and Products.
        /// </summary>
        /// <param name="id">The Recipe identifier.</param>
        /// <returns>Recipe.</returns>
        Recipe GetRecipe(int id);
        /// <summary>
        /// Removes a list of Instructions.
        /// </summary>
        /// <param name="instructions">The instructions.</param>
        bool RemoveRange(IEnumerable<Instruction> instructions);
        /// <summary>
        /// Attaches a list of Instructions.
        /// </summary>
        /// <param name="instructions">The instructions.</param>
        void AttachRange(IEnumerable<Instruction> instructions);
    }
}