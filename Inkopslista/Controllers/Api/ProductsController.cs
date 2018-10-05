using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Inkopslista.Dtos;
using Inkopslista.Models;

namespace Inkopslista.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/products
        public IHttpActionResult Get(int id)
        {
            var productDtos = _context.Products
                .Include(m => m.Food)
                .Include(m => m.CategoryType)
                .ToList()
                .Where(m => m.ShoppinglistId == id)
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        [HttpGet]
        public IHttpActionResult GetFood(string term)
        {
            var foodDtos = Match(term);

            return Ok(foodDtos);
        }

        private IEnumerable<FoodDto> Match(string term)
        {

            var foods = System.Web.Helpers.WebCache.Get("foods") as DbSet<Food>;
            if (foods == null)
            {
                foods = _context.Foods;
                System.Web.Helpers.WebCache.Set("foods", foods);
            }

            var match = foods.Where(c => c.Name.Contains(term))
                .OrderBy(c => c.Name.StartsWith(term) ? (c.Name == term ? 0 : 1) : 2)
                .Select(Mapper.Map<Food, FoodDto>)
                .Take(25);

            return match;
        }
        // GET /api/products/1
        /*
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }
        */

        // POST /api/products
        [HttpPost]
        public IHttpActionResult Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;

            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        // PUT /api/products/1
        [HttpPut]
        public IHttpActionResult Update(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/products/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            _context.Products.Remove(productInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
