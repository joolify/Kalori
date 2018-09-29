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
            var productList = new List<Product>();
            recipe.Products = productList;
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

            var viewModel = new NewRecipeViewModel
            {
                Recipe = recipe,
                NewProduct = new Product()
            };

            return View(viewModel);
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
                Food = _context.Foods.SingleOrDefault(c => c.Id == model.Id)
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
        public ActionResult Create(NewRecipeViewModel viewModel, string command)
        {
            var recipe = new Recipe();
            recipe.Name = viewModel.Recipe.Name;
            recipe.CookingTimeH = viewModel.Recipe.CookingTimeH;
            recipe.CookingTimeM = viewModel.Recipe.CookingTimeM;
            recipe.Portions = viewModel.Recipe.Portions;

            var prodList = new List<Product>();

            if (viewModel.Recipe.Products.Any())
            {
                for (int i = 0; i < viewModel.Recipe.Products.Count; i++)
                {
                    var foodId = viewModel.Recipe.Products[i].Food.Id;
                    var product = new Product
                    {
                        Id = viewModel.Recipe.Products[i].Id,
                        Mass = viewModel.Recipe.Products[i].Mass,
                        PricePerKg = viewModel.Recipe.Products[i].PricePerKg,
                        PriceTotal = viewModel.Recipe.Products[i].PriceTotal,
                        Food = _context.Foods.SingleOrDefault(c => c.Id == foodId)
                    };
                    prodList.Add(product);
                }
            }

            recipe.Products = prodList;
            if (command.Equals("AddIngredient"))
            {
                var product = new Product
                {
                    Food = _context.Foods.SingleOrDefault(c => c.Id == viewModel.NewProduct.FoodId)
                };

                recipe.Products.Add(product);
                viewModel.Recipe = recipe;
                                
                return View("New", viewModel);
            }

            _context.Database.Log = s => Debug.WriteLine(s);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Recipe");

        }

    }
}