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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public IEnumerable<Product> GetAllFromShoppingList(int id)
        {
            return _context.Products
                .Include(c => c.Food)
                .Include(c => c.CategoryType)
                .Where(c => c.ShoppinglistId == id).ToList();      
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context;  }
        }
    }
}