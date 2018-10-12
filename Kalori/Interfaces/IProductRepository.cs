// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="IProductRepository.cs" company="joolify">
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
    /// Interface IProductRepository
    /// </summary>
    /// <seealso cref="Kalori.Interfaces.IRepository{Kalori.Models.Product}" />
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Gets all Products belonging to a specific Shoppinglist.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>IEnumerable&lt;Product&gt;.</returns>
        IEnumerable<Product> GetAllFromShoppingList(int id);
    }
}