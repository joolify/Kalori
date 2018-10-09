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
using Kalori.Dtos;
using Kalori.Models;
using Kalori.Services;

namespace Kalori.Controllers.Api
{
    public class RecipesController : ApiController
    {
        private ApplicationDbContext _context;
        private RecipeService _service;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
            _service = new RecipeService();
        }

        // GET /api/shoppinglists
        public IHttpActionResult Get()
        {
            var recipeDtos = _service.Get()
                .Select(Mapper.Map<Recipe, RecipeDto>);

            return Ok(recipeDtos);
        }

        // GET /api/recipes/1
        public IHttpActionResult Get(int id)
        {
            var recipe = _service.Get(id);

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

        public IHttpActionResult GetInstructions()
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
            _service.Add(recipe);

            recipeDto.Id = recipe.Id;

            return Created(new Uri(Request.RequestUri + "/" + recipe.Id), recipeDto);
        }

        // PUT /api/recipes/1
        [HttpPut]
        public IHttpActionResult UpdateRecipe(int id, RecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipeInDb = _service.Get(id);

            if (recipeInDb == null)
                return NotFound();

            Mapper.Map(recipeDto, recipeInDb);

            _service.Save();

            return Ok();
        }

        //DELETE /api/recipes/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var recipeInDb = _service.Get(id);

            if (recipeInDb == null)
                return NotFound();

            _service.Remove(recipeInDb);
            _service.Save();

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

        public IHttpActionResult AddIngredient(ProductDto productDto)
        {
            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            var product = new Product();
            var food = _service.GetFood(productDto.FoodId);
            product.Food = food;
            product.Mass = productDto.Mass;
            product.PricePerKg = productDto.PricePerKg;
            product.PriceTotal = productDto.Mass * (productDto.PricePerKg / 1000);
            product.CategoryType = _service.GetCategoryType(food.Category1);
            product.Id = recipe.Products.Count + 1;

            recipe.Products.Add(product);

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            return Ok();
        }

        public IHttpActionResult AddInstruction(InstructionDto instructionDto)
        {
            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            var instruction = new Instruction();
            instruction.Number = recipe.Instructions.Count + 1;
            instruction.Name = instructionDto.Name;
            instruction.Id = recipe.Instructions.Count + 1;

            recipe.Instructions.Add(instruction);

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            return Ok();
        }
        public IHttpActionResult DeleteInstruction(int id)
        {
            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            var instruction = recipe.Instructions.SingleOrDefault(c => c.Id == id);
            if (instruction == null)
                return NotFound();

            recipe.Instructions.Remove(instruction);

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            if (recipe == null)
                return BadRequest();

            var product = recipe.Products.FirstOrDefault(c => c.Id == productDto.Id);

            if (product == null)
                return BadRequest();

            product.Mass = productDto.Mass;
            product.PricePerKg = productDto.PricePerKg;
            product.PriceTotal = productDto.Mass * (productDto.PricePerKg / 1000);

            productDto = Mapper.Map<Product, ProductDto>(product);

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            return Ok(productDto);

        }
        [HttpPost]
        public IHttpActionResult UpdateInstruction(InstructionDto instructionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            var instruction = recipe.Instructions.FirstOrDefault(c => c.Id == instructionDto.Id);
            if (instruction != null)
            {
                instruction.Name = instructionDto.Name;
            }
            else
            {
                return BadRequest();
            }

            instructionDto = Mapper.Map<Instruction, InstructionDto>(instruction);

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            return Ok(instruction);

        }
        // PUT /api/recipes/1
        [HttpPost]
        public IHttpActionResult UpdateInstructions(List<InstructionDto> instructionDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            var instructions = new List<Instruction>();

            for (int i = 0; i < instructionDtos.Count; i++)
            {
               var instruction = Mapper.Map<InstructionDto, Instruction>(instructionDtos[i]);
                instructions.Add(instruction);
            }

            recipe.Instructions = instructions;

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            return Ok();

        }
    }
}
