// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-02-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="ShoppinglistsController.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Kalori.Dtos;
using Kalori.Models;
using Kalori.Services;

namespace Kalori.Controllers.Api
{
    /// <summary>
    /// Class ShoppinglistsController creates lists and edits Shoppinglists.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ShoppinglistsController : ApiController
    {
        /// <summary>
        /// A Shoppinglist Service layer.
        /// </summary>
        private ShoppinglistService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppinglistsController"/> class.
        /// Initializes a new instance of the <see cref="ShoppinglistService"/> class.
        /// </summary>
        public ShoppinglistsController()
        {
            _service = new ShoppinglistService();
        }


        /********************************************************
         **** GET
         ********************************************************/

        /// <summary>
        /// Gets a specified ShoppinglistDto.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult Get(int id)
        {
            var shoppinglist = _service.Get(id);

            if (shoppinglist == null)
                return NotFound();

            return Ok(Mapper.Map<Shoppinglist, ShoppinglistDto>(shoppinglist));
        }

        /// <summary>
        /// Gets all ShoppinglistDtos.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetAll()
        {
            var shoppinglistDtos = _service.GetAll()
                .Select(Mapper.Map<Shoppinglist, ShoppinglistDto>);

            return Ok(shoppinglistDtos);
        }

        /// <summary>
        /// Gets all Products belonging to a specified Shoppinglist.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult GetAllProducts(int id)
        {
            var productDtos = _service.GetAllProducts(id)
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }
        /********************************************************
         **** POST
         ********************************************************/

        /// <summary>
        /// Adds the specified ShoppinglistDto.
        /// </summary>
        /// <param name="shoppinglistDto">The ShoppinglistDto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Add(ShoppinglistDto shoppinglistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var shoppinglist = Mapper.Map<ShoppinglistDto, Shoppinglist>(shoppinglistDto);
            _service.AddOrUpdate(shoppinglist);

            shoppinglistDto.Id = shoppinglist.Id;
            _service.Complete();

            return Created(new Uri(Request.RequestUri + "/" + shoppinglist.Id), shoppinglistDto);
        }

        /// <summary>
        /// Updates the specified ShoppinglistDto.
        /// </summary>
        /// <param name="shoppinglistDto">The ShoppinglistDto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Update(ShoppinglistDto shoppinglistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var id = shoppinglistDto.Id;
            var shoppinglistInDb = _service.Get(id);

            if (shoppinglistInDb == null)
                return NotFound();

            Mapper.Map(shoppinglistDto, shoppinglistInDb);

            _service.AddOrUpdate(shoppinglistInDb);

            _service.Complete();

            return Ok();
        }

        /// <summary>
        /// Updates the product, includes Food and CategoryType.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult UpdateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = _service.GetProduct(productDto.Id);

            if (product == null)
                return BadRequest();

            product.Mass = productDto.Mass;
            product.PricePerKg = productDto.PricePerKg;
            product.PriceTotal = productDto.Mass * (productDto.PricePerKg / 1000);
            var food = _service.GetFood(product.FoodId);
            var category = _service.GetCategoryType(food.Category1);
            product.Food = food;
            product.CategoryType = category;

            productDto = Mapper.Map<Product, ProductDto>(product);

            _service.Complete();

            return Ok(productDto);

        }

        /********************************************************
         **** DELETE
         ********************************************************/

        /// <summary>
        /// Deletes the specified Shoppinglist and also its Products.
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var shoppinglistInDb = _service.Get(id);

            if (shoppinglistInDb == null)
                return NotFound();
            var products = _service.GetAllProducts(shoppinglistInDb.Id);

            _service.RemoveRange(products);

            shoppinglistInDb.Products = null;

            _service.Remove(shoppinglistInDb);

            _service.Complete();

            return Ok();
        }

        //FIXME Dublicate?
        /// <summary>
        /// Deletes the ingredient.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpDelete]
        public IHttpActionResult DeleteIngredient(int id)
        {
            var productInDb = _service.GetProduct(id);
            if (productInDb == null)
                return NotFound();

            _service.Remove(productInDb);

            return Ok();
        }

    }
}
