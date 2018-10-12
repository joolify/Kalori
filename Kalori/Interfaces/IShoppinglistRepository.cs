// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-11-2018
// ***********************************************************************
// <copyright file="IShoppinglistRepository.cs" company="joolify">
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
    /// Interface IShoppinglistRepository
    /// </summary>
    /// <seealso cref="Kalori.Interfaces.IRepository{Kalori.Models.Shoppinglist}" />
    public interface IShoppinglistRepository : IRepository<Shoppinglist>
    {
        /// <summary>
        /// Gets Shoppinglist with belonging Products.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>Shoppinglist.</returns>
        Shoppinglist GetWithProducts(int id);
        /// <summary>
        /// Gets a list of all Shoppinglist with respective Products.
        /// </summary>
        /// <returns>IEnumerable&lt;Shoppinglist&gt;.</returns>
        IEnumerable<Shoppinglist> GetAllWithProducts(); 
    }
}