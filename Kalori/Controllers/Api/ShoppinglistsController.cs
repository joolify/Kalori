using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Kalori.Dtos;
using Kalori.Models;
using Kalori.Services;

namespace Kalori.Controllers.Api
{
    public class ShoppinglistsController : ApiController
    {
        private ShoppinglistService _service;

        public ShoppinglistsController()
        {
            _service = new ShoppinglistService();
        }


        /********************************************************
         **** GET
         ********************************************************/

        // GET /api/shoppinglists/Get/1
        public IHttpActionResult Get(int id)
        {
            var shoppinglist = _service.Get(id);

            if (shoppinglist == null)
                return NotFound();

            return Ok(Mapper.Map<Shoppinglist, ShoppinglistDto>(shoppinglist));
        }

        // GET /api/shoppinglists/GetAll
        public IHttpActionResult GetAll()
        {
            var shoppinglistDtos = _service.GetAll()
                .Select(Mapper.Map<Shoppinglist, ShoppinglistDto>);

            return Ok(shoppinglistDtos);
        }

        // GET /api/shoppinglists/GetAllProducts
        public IHttpActionResult GetAllProducts(int id)
        {
            var productDtos = _service.GetAllProducts(id)
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }
        /********************************************************
         **** POST
         ********************************************************/

        // POST /api/shoppinglists/Add
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

        // POST /api/shoppinglists/Update
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

        // POST /api/shoppinglists/UpdateProduct
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

        //DELETE /api/shoppinglists/Delete
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



        //DELETE /api/shoppinglists/DeleteIngredient
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
