// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Repositories;

namespace Kalori.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Foods = new FoodRepository(_context);
            Products = new ProductRepository(_context);
            Recipes = new RecipeRepository(_context);
            Shoppinglists = new ShoppinglistRepository(_context);
        }

        public IFoodRepository Foods { get; private set; }
        public IProductRepository Products { get; private set; }
        public IRecipeRepository Recipes { get; private set; }
        public IShoppinglistRepository Shoppinglists { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}