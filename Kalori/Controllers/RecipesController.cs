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
        protected override void Dispose(bool disposing)
        {
            _service.Dispose(disposing);
        }

        /********************************************************
         **** GET
         ********************************************************/
        public ViewResult Index()
        {
            return View(_service.GetAll());
        }

        public ViewResult New()
        {
            var recipe = _service.GetTempRecipe("tempRecipe");

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

        /********************************************************
         **** POST
         ********************************************************/
        [HttpPost]
        public ActionResult Add(NewRecipeViewModel viewModel, string command)
        {
            var recipe = _service.GetTempRecipe("tempRecipe"); ;
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
            _service.AddOrUpdate(recipe);
            _service.Complete();

            var newRecipe = new Recipe();
            _service.SetTempRecipe("tempRecipe", newRecipe);
            return RedirectToAction("Index", "Recipes");

        }
    }
}