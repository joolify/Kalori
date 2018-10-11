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
        private RecipeService _service;

        public RecipesController()
        {
            _service = new RecipeService();
        }

        /********************************************************
         **** GET
         ********************************************************/

        // GET /api/recipes/Get
        public IHttpActionResult Get()
        {
            var recipeDtos = _service.GetAll()
                .Select(Mapper.Map<Recipe, RecipeDto>);

            return Ok(recipeDtos);
        }

        // GET /api/recipes/Get/1
        public IHttpActionResult Get(int id)
        {
            var recipe = _service.Get(id);

            if (recipe == null)
                return NotFound();

            return Ok(Mapper.Map<Recipe, RecipeDto>(recipe));
        }

        // GET /api/recipes/GetProducts
        public IHttpActionResult GetProducts()
        {
            var recipe = _service.GetTempRecipe("tempRecipe");

            if (recipe == null)
                return NotFound();

            var productDtos = recipe.Products.Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        // GET /api/recipes/GetInstructions
        public IHttpActionResult GetInstructions()
        {

            var recipe = _service.GetTempRecipe("tempRecipe");

            if (recipe == null)
                return NotFound();

            var instructionDtos = recipe.Instructions.Select(Mapper.Map<Instruction, InstructionDto>);

            return Ok(instructionDtos);
        }

        /********************************************************
         **** POST
         ********************************************************/

        // POST /api/recipes/AddRecipe
        [HttpPost]
        public IHttpActionResult AddRecipe(RecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = Mapper.Map<RecipeDto, Recipe>(recipeDto);
            _service.AddOrUpdate(recipe);
            _service.Complete();

            recipeDto.Id = recipe.Id;

            return Created(new Uri(Request.RequestUri + "/" + recipe.Id), recipeDto);
        }

        // POST /api/recipes/AddIngredient
        [HttpPost]
        public IHttpActionResult AddIngredient(ProductDto productDto)
        {
            var recipe = _service.GetTempRecipe("tempRecipe");

            var product = new Product();
            var food = _service.GetFood(productDto.FoodId);
            product.Food = food;
            product.Mass = productDto.Mass;
            product.PricePerKg = productDto.PricePerKg;
            product.PriceTotal = productDto.Mass * (productDto.PricePerKg / 1000);
            product.CategoryType = _service.GetCategoryType(food.Category1);
            product.Id = recipe.Products.Count + 1;

            recipe.Products.Add(product);

            _service.SetTempRecipe("tempRecipe", recipe);

            return Ok();
        }

        // POST /api/recipes/AddInstruction
        [HttpPost]
        public IHttpActionResult AddInstruction(InstructionDto instructionDto)
        {
            var recipe = _service.GetTempRecipe("tempRecipe");

            var instruction = new Instruction();
            instruction.Number = recipe.Instructions.Count + 1;
            instruction.Name = instructionDto.Name;
            instruction.Id = recipe.Instructions.Count + 1;

            recipe.Instructions.Add(instruction);

            _service.SetTempRecipe("tempRecipe", recipe);

            return Ok();
        }

        // POST /api/recipes/Updateproduct
        [HttpPost]
        public IHttpActionResult UpdateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = _service.GetTempRecipe("tempRecipe");

            if (recipe == null)
                return BadRequest();

            var product = recipe.Products.FirstOrDefault(c => c.Id == productDto.Id);

            if (product == null)
                return BadRequest();

            product.Mass = productDto.Mass;
            product.PricePerKg = productDto.PricePerKg;
            product.PriceTotal = productDto.Mass * (productDto.PricePerKg / 1000);

            productDto = Mapper.Map<Product, ProductDto>(product);

            _service.SetTempRecipe("tempRecipe", recipe);

            return Ok(productDto);

        }
        // POST /api/recipes/UpdateInstruction
        [HttpPost]
        public IHttpActionResult UpdateInstruction(InstructionDto instructionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = _service.GetTempRecipe("tempRecipe");

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

            _service.SetTempRecipe("tempRecipe", recipe);

            return Ok(instructionDto);

        }
        // POST /api/recipes/UpdateInstructions
        [HttpPost]
        public IHttpActionResult UpdateInstructions(List<InstructionDto> instructionDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = _service.GetTempRecipe("tempRecipe");

            var instructions = new List<Instruction>();

            for (int i = 0; i < instructionDtos.Count; i++)
            {
               var instruction = Mapper.Map<InstructionDto, Instruction>(instructionDtos[i]);
                instructions.Add(instruction);
            }

            recipe.Instructions = instructions;

            _service.SetTempRecipe("tempRecipe", recipe);

            return Ok();

        }
        /********************************************************
         **** PUT
         ********************************************************/

        // POST /api/recipes/UpdateRecipe
        [HttpPut]
        public IHttpActionResult UpdateRecipe(int id, RecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipeInDb = _service.Get(id);

            if (recipeInDb == null)
                return NotFound();

            Mapper.Map(recipeDto, recipeInDb);

            _service.AddOrUpdate(recipeInDb);
            _service.Complete();

            return Ok();
        }

        /********************************************************
         **** DELETE
         ********************************************************/

        //DELETE /api/recipes/Delete/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var recipeInDb = _service.Get(id);

            if (recipeInDb == null)
                return NotFound();

            _service.Remove(recipeInDb);
            _service.Complete();

            return Ok();
        }

        //DELETE /api/recipes/DeleteIngredient/1
        [HttpDelete]
        public IHttpActionResult DeleteIngredient(int id)
        {
            var recipe = _service.GetTempRecipe("tempRecipe");

            var product = recipe.Products.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return NotFound();

            recipe.Products.Remove(product);

            _service.SetTempRecipe("tempRecipe", recipe);

            return Ok();
        }
        //DELETE /api/recipes/DeleteInstruction/1
       public IHttpActionResult DeleteInstruction(int id)
        {
            var recipe = _service.GetTempRecipe("tempRecipe");

            var instruction = recipe.Instructions.SingleOrDefault(c => c.Id == id);
            if (instruction == null)
                return NotFound();

            recipe.Instructions.Remove(instruction);

            _service.SetTempRecipe("tempRecipe", recipe);

            return Ok();
        }

        
    }
}
