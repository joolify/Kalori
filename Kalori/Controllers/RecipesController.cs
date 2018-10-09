using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalori.Models;
using Kalori.Services;
using Kalori.ViewModels;

namespace Kalori.Controllers
{
    public class RecipesController : Controller
    {
        private RecipeService _service;

        public RecipesController()
        {
            _service = new RecipeService();
        }

        // GET: Recipe
        public ViewResult Index()
        {
            return View(_service.Get());
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
            var recipe = _service.Get(id);
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

            var image = new Image();
            var fileName = Path.GetFileNameWithoutExtension(viewModel.Recipe.Image.File.FileName);
            var extension = Path.GetExtension(viewModel.Recipe.Image.File.FileName);
            fileName += DateTime.Now.ToString("yymmssfff") + extension;
            image.Path = "../../Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            recipe.Image = image;

            viewModel.Recipe.Image.File.SaveAs(fileName);
            _service.Add(recipe);

            var newRecipe = new Recipe();
            System.Web.Helpers.WebCache.Set("tempRecipe", newRecipe);
            return RedirectToAction("Index", "Recipes");

        }
    }
}