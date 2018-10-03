using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;
using AutoMapper;
using Inkopslista.Dtos;
using Inkopslista.Models;

namespace Inkopslista.Controllers.Api
{
    public class RecipesController : ApiController
    {
        private ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/shoppinglists
        public IHttpActionResult Get()
        {
            var recipeDtos = _context.Recipes
                .Include(m => m.Products)
                .ToList()
                .Select(Mapper.Map<Recipe, RecipeDto>);

            return Ok(recipeDtos);
        }

        // GET /api/recipes/1
        public IHttpActionResult Get(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
                return NotFound();

            return Ok(Mapper.Map<Recipe, RecipeDto>(recipe));
        }
        public IHttpActionResult GetProducts()
        {
            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            if (recipe == null)
                return NotFound();

            var productDtos = recipe.Products.Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }
        public IHttpActionResult GetInstructions(int id)
        {

            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            if (recipe == null)
                return NotFound();

            var instructionDtos = recipe.Instructions.Select(Mapper.Map<Instruction, InstructionDto>);

            return Ok(instructionDtos);
        }

        // POST /api/recipes
        [HttpPost]
        public IHttpActionResult CreateRecipe(RecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = Mapper.Map<RecipeDto, Recipe>(recipeDto);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            recipeDto.Id = recipe.Id;

            return Created(new Uri(Request.RequestUri + "/" + recipe.Id), recipeDto);
        }

        // PUT /api/recipes/1
        [HttpPut]
        public IHttpActionResult UpdateRecipe(int id, RecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipeInDb = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if(recipeInDb == null)
                return NotFound();

            Mapper.Map(recipeDto, recipeInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/recipes/1
        [HttpDelete]
        public IHttpActionResult DeleteRecipe(int id)
        {
            var recipeInDb = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipeInDb == null)
                return NotFound();

            _context.Recipes.Remove(recipeInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteIngredient(int id)
        {
            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            var product = recipe.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return NotFound();

            recipe.Products.Remove(product);

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            return Ok();
        }
    }
}
