﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inkopslista.Models;
using Inkopslista.ViewModels;

namespace Inkopslista.Controllers
{
    public class RecipeController : Controller
    {
        public ApplicationDbContext _context;

        public RecipeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Recipe
        public ViewResult Index()
        {
            var recipes = _context.Recipes.ToList();

            return View(recipes);

        }

        public ViewResult New()
        {
            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe;

            if(recipe == null)
                recipe = new Recipe();

            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

            var viewModel = new NewRecipeViewModel
            {
                Recipe = recipe,
                NewProduct = new Product()
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var recipe = _context.Recipes.Include(c => c.Image).SingleOrDefault(c => c.Id == id);

            if (recipe == null)
                return HttpNotFound();

            return View(recipe);
        }


        [HttpPost]
        public ActionResult Create(NewRecipeViewModel viewModel, string command)
        {
            var recipe = System.Web.Helpers.WebCache.Get("tempRecipe") as Recipe; ;
            recipe.Name = viewModel.Recipe.Name;
            recipe.CookingTimeH = viewModel.Recipe.CookingTimeH;
            recipe.CookingTimeM = viewModel.Recipe.CookingTimeM;
            recipe.Portions = viewModel.Recipe.Portions;

            if (command.Equals("AddIngredient"))
            {
                var product = new Product
                {
                    Food = _context.Foods.SingleOrDefault(c => c.Id == viewModel.NewProduct.FoodId),
                    Mass = viewModel.NewProduct.Mass,
                    PricePerKg = viewModel.NewProduct.PricePerKg,
                    PriceTotal = viewModel.NewProduct.Mass * (viewModel.NewProduct.PricePerKg / 1000)
                };

                recipe.Products.Add(product);
                viewModel.Recipe = recipe;
                viewModel.NewProduct = new Product();

                System.Web.Helpers.WebCache.Set("tempRecipe", recipe);
                                
                return View("New", viewModel);
            }

            if (command.Contains("DelIngredient"))
            {
                int id = int.Parse(command.Replace("DelIngredient=", ""));
                var product = recipe.Products.SingleOrDefault(c => c.Id == id);


                if (product == null)
                    return View("New", viewModel);

                recipe.Products.Remove(product);
                System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

                viewModel.Recipe = recipe;

                return View("New", viewModel);
            }

            if (command.Equals("AddInstruction"))
            {
                var instruction = new Instruction
                {
                    Id = recipe.Instructions.Count + 1,
                    Name = viewModel.NewInstruction.Name,
                    Number = recipe.Instructions.Count + 1
                };

                recipe.Instructions.Add(instruction);
                viewModel.Recipe = recipe;

                System.Web.Helpers.WebCache.Set("tempRecipe", recipe);

                return View("New", viewModel);
            }

            var image = new Image();
            var fileName = Path.GetFileNameWithoutExtension(viewModel.Recipe.Image.File.FileName);
            var extension = Path.GetExtension(viewModel.Recipe.Image.File.FileName);
            fileName += DateTime.Now.ToString("yymmssfff") + extension;
            image.Path = "../../Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            recipe.Image = image;

            viewModel.Recipe.Image.File.SaveAs(fileName);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Recipe");

        }

                [HttpGet]
        public ActionResult GetFood(string term)
        {
            var food = Match(term);

            return Json(food, JsonRequestBehavior.AllowGet);
        }

        private IQueryable Match(string term)
        {
            var match = _context.Foods.Where(c => c.Name.Contains(term))
                .OrderBy(c => c.Name.StartsWith(term) ? (c.Name == term ? 0 : 1) : 2)
                .Select(a => new { label = a.Name, id = a.Id })
                .Take(25);

            return match;
        }

    }
}