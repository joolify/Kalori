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
        [HttpPut]
        public IHttpActionResult UpdateShoppinglist(int id, ShoppinglistDto shoppinglistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

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
    }
}
