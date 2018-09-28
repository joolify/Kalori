using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var recipe = new Recipe();
            recipe.Products = TempData["products"] as List<Product>;
            return View(recipe);
        }

        public ViewResult AddIngredient(Recipe model)
        {
            var recipe = new Recipe();
            recipe.Name = model.Name;
            recipe.CookingTimeH = model.CookingTimeH;
            recipe.CookingTimeM = model.CookingTimeM;
            recipe.Portions = model.Portions;
            recipe.Products = model.Products;

            return View("New", recipe);
        }

        public ActionResult Details(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
                return HttpNotFound();

            return View(recipe);
        }


        [HttpPost]
        public ActionResult Create(Recipe model, string command)
        {
            var recipe = new Recipe();
            recipe.Name = model.Name;
            recipe.CookingTimeH = model.CookingTimeH;
            recipe.CookingTimeM = model.CookingTimeM;
            recipe.Portions = model.Portions;
            recipe.Products = model.Products;

            if (command.Equals("AddIngredient"))
            {
                return View("New", recipe);
            }
            else
            {
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Recipe");

        }
    }
}