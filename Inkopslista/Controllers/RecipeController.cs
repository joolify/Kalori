using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        public ViewResult New(int? id)
        {
            var recipe = new Recipe();
            if (id != null)
            {
                var products = _context.Products.Where(c => c.ShoppinglistId == id).ToList();
                for (int i = 0; i < products.Count; i++)
                {
                    var food = new Food();
                    var fid = products[i].FoodId;
                    food = _context.Foods.SingleOrDefault(c => c.Id == fid);
                    products[i].Food = food;
                }

                recipe.Products = products;
            }

            return View(recipe);
        }

        public ViewResult AddIngredient(Recipe model)
        {
            var recipe = new Recipe();
            recipe.Name = model.Name;
            recipe.CookingTimeH = model.CookingTimeH;
            recipe.CookingTimeM = model.CookingTimeM;
            recipe.Portions = model.Portions;
            var product = new Product
            {

            };
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

            var prodList = new List<Product>();
            for (int i = 0; i < model.Products.Count; i++)
            {
                var foodId = model.Products[i].Food.Id;
                var product = new Product
                {
                    Id = model.Products[i].Id,
                    Mass = model.Products[i].Mass,
                    PricePerKg = model.Products[i].PricePerKg,
                    PriceTotal = model.Products[i].PriceTotal,
                    Food = _context.Foods.SingleOrDefault(c => c.Id == foodId)
                };
                prodList.Add(product);
            }
            recipe.Products = prodList;

            if (command.Equals("AddIngredient"))
            {
                return View("New", recipe);
            }

            _context.Database.Log = s => Debug.WriteLine(s);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Recipe");

        }

    }
}