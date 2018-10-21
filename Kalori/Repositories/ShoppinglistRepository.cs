// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="ShoppinglistRepository.cs" company="joolify">
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
    /// Class ShoppinglistRepository.
    /// </summary>
    /// <seealso cref="Kalori.Repositories.Repository{Kalori.Models.Shoppinglist}" />
    /// <seealso cref="Kalori.Interfaces.IShoppinglistRepository" />
    public class ShoppinglistRepository : Repository<Shoppinglist>, IShoppinglistRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context = new ApplicationDbContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppinglistRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ShoppinglistRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Gets Shoppinglist with belonging Products.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>Shoppinglist.</returns>
        public Shoppinglist GetWithProducts(int id)
        {
            return _context.Shoppinglists.Include(c => c.Products).SingleOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Gets a list of all Shoppinglist with respective Products.
        /// </summary>
        /// <returns>IEnumerable&lt;Shoppinglist&gt;.</returns>
        public IEnumerable<Shoppinglist> GetAllWithProducts()
        {
            return _context.Shoppinglists.Include(m => m.Products).ToList();
        }

        /// <summary>
        /// Gets the application database context.
        /// </summary>
        /// <value>The application database context.</value>
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext;}
        }
    }
}