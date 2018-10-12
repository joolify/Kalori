// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-03-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="ProductsController.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Kalori.Models;
using Kalori.Services;

namespace Kalori.Controllers.Api
{
    /// <summary>
    /// Class ProductsController creates Products.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ProductsController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>

        private readonly ProductService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        public ProductsController()
        {
            _service = new ProductService();
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _service.Dispose(disposing);
        }

        // GET /api/products
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        public IHttpActionResult Get(int id)
        {
            var productDtos = _service.GetAllFromShoppinglist(id)
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        /// <summary>
        /// Gets the food.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet]
        public IHttpActionResult GetFood(string term)
        {
            var foodDtos = Match(term);

            return Ok(foodDtos);
        }

        /// <summary>
        /// Matches the specified term.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>IEnumerable&lt;FoodDto&gt;.</returns>
        private IEnumerable<FoodDto> Match(string term)
        {

            var foods = _service.GetTempFoods("foods");
            if (foods == null)
            {
                foods = _service.GetAllFoods();
                _service.SetTempFoods("foods", foods);
            }

            var match = foods.Where(c => c.Name.Contains(term))
                .OrderBy(c => c.Name.StartsWith(term) ? (c.Name == term ? 0 : 1) : 2)
                .Select(Mapper.Map<Food, FoodDto>)
                .Take(25);

            return match;
        }        // POST /api/products

        /// <summary>
        /// Creates the specified product dto.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);

            _service.AddOrUpdate(product);
            _service.Complete();

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        // PUT /api/products/1
        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="productDto">The product dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPut]
        public IHttpActionResult Update(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _service.Get(id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);

            _service.AddOrUpdate(productInDb);
            _service.Complete();

            return Ok();
        }

        //DELETE /api/products/1
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var productInDb = _service.Get(id);

            if (productInDb == null)
                return NotFound();

            _service.Remove(productInDb);
            _service.Complete();

            return Ok();
        }
    }
}
