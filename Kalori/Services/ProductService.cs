// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-12-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="ProductService.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.UoW;

namespace Kalori.Services
{
    /// <summary>
    /// Class ProductService.
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public ProductService()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();
        }

        /// <summary>
        /// Saves the changes to the DbContext.
        /// </summary>
        public void Complete()
        {
            _unitOfWork.Complete();
        }
        /********************************************************
         **** GETTERS
         ********************************************************/

        /// <summary>
        /// Gets the specified Product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product.</returns>
        public Product Get(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        /// <summary>
        /// Gets all Shoppinglists.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>IEnumerable&lt;Product&gt;.</returns>
        public IEnumerable<Product> GetAllFromShoppinglist(int id)
        {
            return _unitOfWork.Products.GetAllFromShoppingList(id);
        }

        /// <summary>
        /// Gets all foods.
        /// </summary>
        /// <returns>IEnumerable&lt;Food&gt;.</returns>
        public IEnumerable<Food> GetAllFoods()
        {
            return _unitOfWork.Foods.GetAll();
        }

        /// <summary>
        /// Gets the temporary foods.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>IEnumerable&lt;Food&gt;.</returns>
        public IEnumerable<Food> GetTempFoods(string key)
        {
            return _unitOfWork.Recipes.GetTempObj(key) as IEnumerable<Food>;
        }


        /********************************************************
         **** ADDERS
         ********************************************************/

        /// <summary>
        /// Adds or updates a Product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void AddOrUpdate(Product product)
        {
            _unitOfWork.Products.AddOrUpdate(product);
        }

        /// <summary>
        /// Sets the temporary foods.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetTempFoods(string key, IEnumerable<Food> value)
        {
            _unitOfWork.Products.SetTempObj(key, value);
        }

        /********************************************************
        **** REMOVERS
        ********************************************************/
        /// <summary>
        /// Removes the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Remove(Product product)
        {
            _unitOfWork.Products.Attach(product);
            _unitOfWork.Products.Remove(product);
        }

    }
}