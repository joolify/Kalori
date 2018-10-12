// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-11-2018
// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kalori.Interfaces
{
    /// <summary>
    /// Interface IUnitOfWork
    /// Maintains a list of objects affected by a business
    /// transaction and coordinates the writing out of changes
    /// and the resolution of concurrency problems.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets a IFoodRepository
        /// </summary>
        /// <value>The Food repository.</value>
        IFoodRepository Foods { get; }
        /// <summary>
        /// Gets a IProductRepository
        /// </summary>
        /// <value>The Product repository.</value>
        IProductRepository Products { get; }
        /// <summary>
        /// Gets a IRecipeRepository
        /// </summary>
        /// <value>The Recipe repository.</value>
        IRecipeRepository Recipes { get; }
        /// <summary>
        /// Gets a IShoppinglistRepository
        /// </summary>
        /// <value>The Shoppinglist repository.</value>
        IShoppinglistRepository Shoppinglists { get; }
        /// <summary>
        /// Saves the changes to the DbContext.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int Complete();
    }
}