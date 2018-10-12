// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="ShoppinglistService.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Repositories;
using Kalori.ViewModels;
using Kalori.UoW;

namespace Kalori.Services
{
    /// <summary>
    /// Class ShoppinglistService.
    /// </summary>
    public class ShoppinglistService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppinglistService"/> class.
        /// </summary>
        public ShoppinglistService()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool disposing)
        {
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
        /// Gets the specified Shoppinglist with Products
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>Shoppinglist.</returns>
        public Shoppinglist Get(int id)
        {
            return _unitOfWork.Shoppinglists.GetWithProducts(id);
        }

        /// <summary>
        /// Gets all Shoppinglists with respective Products
        /// </summary>
        /// <returns>IEnumerable&lt;Shoppinglist&gt;.</returns>
        public IEnumerable<Shoppinglist> GetAll()
        {
            return _unitOfWork.Shoppinglists.GetAllWithProducts();
        }

        /// <summary>
        /// Gets the specific product.
        /// </summary>
        /// <param name="id">The Product identifier.</param>
        /// <returns>Product.</returns>
        public Product GetProduct(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        /// <summary>
        /// Gets all products from a specific Shoppinglist.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>IEnumerable&lt;Product&gt;.</returns>
        public IEnumerable<Product> GetAllProducts(int id)
        {
            return _unitOfWork.Products.GetAllFromShoppingList(id);
        }
        /// <summary>
        /// Gets a specified Food.
        /// </summary>
        /// <param name="id">The Food identifier.</param>
        /// <returns>Food.</returns>
        public Food GetFood(int? id)
        {
            return _unitOfWork.Foods.Get(id);
        }

        /// <summary>
        /// Gets a specified CategoryType.
        /// </summary>
        /// <param name="id">The Category identifier.</param>
        /// <returns>CategoryType.</returns>
        public CategoryType GetCategoryType(int? id)
        {
            return _unitOfWork.Foods.GetCategoryType(id);
        }

        /********************************************************
         **** ADDERS
         ********************************************************/

        /// <summary>
        /// Adds or updates a Shoppinglist.
        /// </summary>
        /// <param name="shoppinglist">The shoppinglist.</param>
        public void AddOrUpdate(Shoppinglist shoppinglist)
        {
            _unitOfWork.Shoppinglists.AddOrUpdate(shoppinglist);
        }
        /// <summary>
        /// Adds or updates a Product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void AddOrUpdate(Product product)
        {
            _unitOfWork.Products.AddOrUpdate(product);
        }
        /// <summary>
        /// Sets the temporary Recipe.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetTempRecipe(string key, Recipe value)
        {
            _unitOfWork.Recipes.SetTempObj(key, value);
        }
        /********************************************************
         **** REMOVERS
         ********************************************************/
        /// <summary>
        /// Removes the specified Shoppinglist.
        /// </summary>
        /// <param name="shoppinglist">The shoppinglist.</param>
        public void Remove(Shoppinglist shoppinglist)
        {
            _unitOfWork.Shoppinglists.Attach(shoppinglist);
            _unitOfWork.Shoppinglists.Remove(shoppinglist);
        }
        /// <summary>
        /// Removes the specified Product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Remove(Product product)
        {
            _unitOfWork.Products.Attach(product);
            _unitOfWork.Products.Remove(product);
        }

        /// <summary>
        /// Removes a list of Products. 
        /// </summary>
        /// <param name="products">The products.</param>
        public void RemoveRange(IEnumerable<Product> products)
        {
            _unitOfWork.Products.AttachRange(products);
            _unitOfWork.Products.RemoveRange(products);
        }
    }
}
