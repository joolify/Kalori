using System;
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

            var intList = new List<Instruction>();
            for (int i = 0; i < 4; i++)
            {
                var instruction = new Instruction
                {
                    Id = i + 1,
                    Number = i + 1,
                    Name = "t" + (i+1)
                };
                intList.Add(instruction);
            }

            recipe.Instructions = intList;
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
            var recipe = new Recipe();
            recipe.Name = viewModel.Recipe.Name;
            recipe.CookingTimeH = viewModel.Recipe.CookingTimeH;
            recipe.CookingTimeM = viewModel.Recipe.CookingTimeM;
            recipe.Portions = viewModel.Recipe.Portions;

            var prodList = new List<Product>();

            if (viewModel.Recipe.Products != null)
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

            var instructionList = new List<Instruction>();

            if (viewModel.Recipe.Instructions != null)
            {
                for (int i = 0; i < viewModel.Recipe.Instructions.Count; i++)
                {
                    var instruction = new Instruction
                    {
                        Id = viewModel.Recipe.Instructions[i].Id,
                        Name = viewModel.Recipe.Instructions[i].Name,
                        Number = viewModel.Recipe.Instructions[i].Number

                    };
                    instructionList.Add(instruction);
                }
                instructionList.Sort((s1, s2) => s1.Number.CompareTo(s2.Number));
            }

            recipe.Products = prodList;
            recipe.Instructions = instructionList;
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
                                
                return View("New", viewModel);
            }

            if (command.Equals("AddInstruction"))
            {
                var instruction = new Instruction
                {
                    Id = viewModel.Recipe.Instructions.Count + 1,
                    Name = viewModel.NewInstruction.Name,
                    Number = viewModel.Recipe.Instructions.Count + 1
                };

                recipe.Instructions.Add(instruction);
                viewModel.Recipe = recipe;

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