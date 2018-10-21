// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="ProductRepository.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Kalori.Interfaces;
using Kalori.Models;

namespace Kalori.Repositories
{
    /// <summary>
    /// Class ProductRepository.
    /// </summary>
    /// <seealso cref="Kalori.Repositories.Repository{Kalori.Models.Product}" />
    /// <seealso cref="Kalori.Interfaces.IProductRepository" />
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context = new ApplicationDbContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        /// <summary>
        /// Gets all Products belonging to a specific Shoppinglist.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>IEnumerable&lt;Product&gt;.</returns>
        public IEnumerable<Product> GetAllFromShoppingList(int id)
        {
            return _context.Products
                .Include(c => c.Food)
                .Include(c => c.CategoryType)
                .Where(c => c.ShoppinglistId == id).ToList();      
        }

        /// <summary>
        /// Gets the application database context.
        /// </summary>
        /// <value>The application database context.</value>
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context;  }
        }
    }
}