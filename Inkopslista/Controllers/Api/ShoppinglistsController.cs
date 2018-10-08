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
    public class ShoppinglistsController : ApiController
    {
        private ApplicationDbContext _context;

        public ShoppinglistsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/shoppinglists
        public IHttpActionResult Get()
        {
            var shoppinglistDtos = _context.Shoppinglists
                .Include(m => m.Products)
                .ToList()
                .Select(Mapper.Map<Shoppinglist, ShoppinglistDto>);

            return Ok(shoppinglistDtos);
        }

        public IHttpActionResult GetProducts(int id)
        {
            var productDtos = _context.Products
                .Include(m => m.Food)
                .Include(m => m.CategoryType)
                .ToList()
                .Where(m => m.ShoppinglistId == id)
                .Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }


        // GET /api/shoppinglists/1
        public IHttpActionResult Get(int id)
        {
            var shoppinglist = _context.Shoppinglists.SingleOrDefault(c => c.Id == id);

            if (shoppinglist == null)
                return NotFound();

            return Ok(Mapper.Map<Shoppinglist, ShoppinglistDto>(shoppinglist));
        }

        // POST /api/shoppinglists
        [HttpPost]
        public IHttpActionResult CreateShoppinglist(ShoppinglistDto shoppinglistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var shoppinglist = Mapper.Map<ShoppinglistDto, Shoppinglist>(shoppinglistDto);
            _context.Shoppinglists.Add(shoppinglist);
            _context.SaveChanges();

            shoppinglistDto.Id = shoppinglist.Id;

            return Created(new Uri(Request.RequestUri + "/" + shoppinglist.Id), shoppinglistDto);
        }

        // PUT /api/shoppinglists/1
        [HttpPost]
        public IHttpActionResult Update(ShoppinglistDto shoppinglistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var id = shoppinglistDto.Id;
            var shoppinglistInDb = _context.Shoppinglists.SingleOrDefault(c => c.Id == id);

            if(shoppinglistInDb == null)
                return NotFound();

            Mapper.Map(shoppinglistDto, shoppinglistInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/shoppinglists/1
        [HttpDelete]
        public IHttpActionResult DeleteShoppinglist(int id)
        {
            var shoppinglistInDb = _context.Shoppinglists.SingleOrDefault(c => c.Id == id);

            if (shoppinglistInDb == null)
                return NotFound();

            _context.Shoppinglists.Remove(shoppinglistInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = _context.Products.FirstOrDefault(c => c.Id == productDto.Id);

            if (product == null)
                return BadRequest();

            product.Mass = productDto.Mass;
            product.PricePerKg = productDto.PricePerKg;
            product.PriceTotal = productDto.Mass * (productDto.PricePerKg / 1000);
            var foodId = product.FoodId;
            var food = _context.Foods.FirstOrDefault(c => c.Id == foodId);
            var catId = food.Category1;
            var category = _context.CategoryTypes.FirstOrDefault(c => c.Id == catId);
            product.Food = food;
            product.CategoryType = category;
        
            productDto = Mapper.Map<Product, ProductDto>(product);

            _context.SaveChanges();

            return Ok(productDto);

        }

        [HttpDelete]
        public IHttpActionResult DeleteIngredient(int id)
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
