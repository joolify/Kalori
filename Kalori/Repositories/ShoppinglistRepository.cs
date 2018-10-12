// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-11-2018
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
    public class ShoppinglistRepository : Repository<Shoppinglist>, IShoppinglistRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ShoppinglistRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Shoppinglist GetWithProducts(int id)
        {
            return _context.Shoppinglists.Include(c => c.Products).SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Shoppinglist> GetAllWithProducts()
        {
            return _context.Shoppinglists.Include(m => m.Products).ToList();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext;}
        }
    }
}