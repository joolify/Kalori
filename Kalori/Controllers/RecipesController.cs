// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="RecipesController.cs" company="joolify">
//     Copyright © joolify 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Web.Mvc;
using Kalori.Models;
using Kalori.Services;
using Kalori.ViewModels;

namespace Kalori.Controllers
{

    /// <summary>
    /// Class RecipesController creates, lists and edits Recipes
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class RecipesController : Controller
    {
        /// <summary>
        /// A Recipe Service layer. 
        /// </summary>
        private readonly RecipeService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesController"/> class.
        /// Initializes a new instance of the <see cref="RecipeService"/> class.
        /// </summary>
        public RecipesController()
        {
            _service = new RecipeService();
        }
        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _service.Dispose(disposing);
        }

        /********************************************************
         **** GET
         ********************************************************/
        /// <summary>
        /// Returns a list of Recipes.
        /// </summary>
        /// <returns>ViewResult.</returns>
        public ViewResult Index()
        {
            return View(_service.GetAll());
        }

        /// <summary>
        /// Creates a new Recipe with a list of Products from Shoppinglist (if there are any)
        /// </summary>
        /// <returns>ViewResult.</returns>
        public ViewResult New()
        {
            var recipe = _service.GetTempRecipe("tempRecipe");

            if (recipe == null)
            {
                recipe = new Recipe();
                _service.SetTempRecipe("tempRecipe", recipe);
            }

            var viewModel = new NewRecipeViewModel
            {
                Recipe = recipe,
                NewProduct = new Product()
            };

            return View(viewModel);
        }

        /// <summary>
        /// A detailed recipe.
        /// </summary>
        /// <param name="id">The Recipe identifier.</param>
        /// <returns>ActionResult.</returns>
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

        /// <summary>
        /// Adds a new Recipe with saved info from a temporary Recipe.
        /// Includes Products, Instructions and Image.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Add(NewRecipeViewModel viewModel)
        {
            var recipe = _service.GetTempRecipe("tempRecipe"); 
            recipe.Name = viewModel.Recipe.Name;
            recipe.CookingTimeH = viewModel.Recipe.CookingTimeH;
            recipe.CookingTimeM = viewModel.Recipe.CookingTimeM;
            recipe.Portions = viewModel.Recipe.Portions;

            var fileName = CreateFileName(viewModel.Recipe.Image.File.FileName);
            recipe.Image = CreateImage(fileName);
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            viewModel.Recipe.Image.File.SaveAs(fileName);

            _service.AddOrUpdate(recipe);
            _service.Complete();

            var newRecipe = new Recipe();
            _service.SetTempRecipe("tempRecipe", newRecipe);
            return RedirectToAction("Index", "Recipes");

        }

        /********************************************************
         **** PRIVATE
         ********************************************************/
        /// <summary>
        /// Creates the name of the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>String.</returns>
        private String CreateFileName(String file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var extension = Path.GetExtension(file);
            fileName += DateTime.Now.ToString("yymmssfff") + extension;
            return fileName;
        }
        /// <summary>
        /// Creates the image.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Image.</returns>
        private Image CreateImage(String fileName)
        {
            var image = new Image();
            image.Path = "../../Image/" + fileName;
            return image;
        }
    }
}