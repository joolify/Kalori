﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inkopslista.Models;
using Inkopslista.ViewModels;

namespace Inkopslista.Controllers
{
    public class ShoppinglistController : Controller
    {
        private ApplicationDbContext _context;

        public ShoppinglistController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Shoppinglist
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult New()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Shoppinglist model)
        {
            var shoppingList = new Shoppinglist();
            shoppingList.Name = model.Name;

            _context.Shoppinglists.Add(shoppingList);
            _context.SaveChanges();

            return RedirectToAction("Index", "Shoppinglist");
        }

        public ActionResult Details(int id)
        {
            var shoppingList = _context.Shoppinglists.SingleOrDefault(c => c.Id == id);
            var products = _context.Products.Include(c => c.Food).Where(c => c.ShoppinglistId == id).ToList();
            var categoryTypes = _context.CategoryTypes.ToList();
            if (shoppingList == null)
                return HttpNotFound();

            var viewModel = new DetailsShoppinglistViewModel
            {
                Shoppinglist = shoppingList,
                Products = products,
                CategoryTypes = categoryTypes
            };
            return View(viewModel);

        }

        public ViewResult NewProduct(int id)
        {
            var foods = _context.Foods.ToList();
            var viewModel = new NewProductShoppinglistViewModel()
            {
                Shoppinglist = new Shoppinglist
                {
                    Id = id
                },
                Product = new Product(),
                Food = foods
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateProduct(NewProductShoppinglistViewModel viewModel)
        {
            var product = new Product();
            if (viewModel.Product.FoodId == null)
            {
                product.ShoppinglistId = viewModel.Shoppinglist.Id;
                product.FoodName = viewModel.Product.FoodName;
                product.Mass = viewModel.Product.Mass;
                product.PricePerKg = viewModel.Product.PricePerKg;
                product.PriceTotal = viewModel.Product.PricePerKg * (viewModel.Product.Mass / 1000);
                product.CategoryType = _context.CategoryTypes.FirstOrDefault(c => c.Category == CategoryType.OwnCategory);
            }
            else
            {
                var food = _context.Foods.FirstOrDefault(c => c.Id == viewModel.Product.FoodId);
                product.ShoppinglistId = viewModel.Shoppinglist.Id;
                product.Food = food;
                product.FoodId = viewModel.Product.FoodId;
                product.FoodName = null;
                product.Mass = viewModel.Product.Mass;
                product.PricePerKg = viewModel.Product.PricePerKg;
                product.PriceTotal = viewModel.Product.PricePerKg * (viewModel.Product.Mass / 1000);
                product.CategoryType = _context.CategoryTypes.FirstOrDefault(c => c.Category == food.Category1);
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Details", "Shoppinglist", new {id = viewModel.Shoppinglist.Id});
        }

        public ViewResult Total(int id)
        {
            var shoppingList = new Shoppinglist
            {
                Id = id
            };

            var products = _context.Products.Include(c => c.Food).Where(c => c.ShoppinglistId == id).ToList();

            var product = new Product
            {
                Mass = 0
            };
            product.Food = new Food
            {
                Alkohol = 0,
                Arakidinsyra = 0,
                Arakidonsyra = 0,
                Aska = 0,
                Avfall = 0,
                DHA = 0,
                Disackarider = 0,
                DPA = 0,
                EnergiKJ = 0,
                EnergiKcal = 0,
                EPA = 0,
                Fett = 0,
                Fettsyra = 0,
                Fibrer = 0,
                Folat = 0,
                FullkornTotalt = 0,
                Jod = 0,
                Jarn = 0,
                Kalcium = 0,
                Kalium = 0,
                Karoten = 0,
                Kolesterol = 0,
                Kolhydrater = 0,
                Koppar = 0,
                Laurinsyra = 0,
                Linolensyra = 0,
                Linolsyra = 0,
                Magnesium = 0,
                Monosackarider = 0,
                Myristinsyra = 0,
                Natrium = 0,
                Niacin = 0,
                Niacinekvivalenter = 0,
                Oljesyra = 0,
                Palmitinsyra = 0,
                Palmitoljesyra = 0,
                Protein = 0,
                Retinol = 0,
                Riboflavin = 0,
                Sackaros = 0,
                Salt = 0,
                Selen = 0,
                Sockerarter = 0,
                Stearinsyra = 0,
                Starkelse = 0,
                SummaEnkelOmattadeFettsyror = 0,
                SummaFleromattadeFettsyror = 0,
                SummaMattadeFettsyror = 0,
                Tiamin = 0,
                Vatten = 0,
                VitaminA = 0,
                VitaminB6 = 0,
                VitaminB12 = 0,
                VitaminC = 0,
                VitaminD = 0,
                VitaminE = 0,
                VitaminK = 0,
                Zink = 0
            };


            for (int i = 0; i < products.Count; i++)
            {
                var totalMass = products[i].Mass / 100;
                product.Mass += products[i].Mass;
                product.Food.Alkohol += products[i].Food.Alkohol * totalMass;
                product.Food.Arakidinsyra += products[i].Food.Arakidinsyra * totalMass;
                product.Food.Arakidonsyra += products[i].Food.Arakidonsyra * totalMass;
                product.Food.Aska += products[i].Food.Aska * totalMass;
                product.Food.Avfall += products[i].Food.Avfall * totalMass;
                product.Food.DHA += products[i].Food.DHA * totalMass;
                product.Food.Disackarider += products[i].Food.Disackarider * totalMass;
                product.Food.DPA += products[i].Food.DPA * totalMass;
                product.Food.EnergiKJ += products[i].Food.EnergiKJ * totalMass;
                product.Food.EnergiKcal += products[i].Food.EnergiKcal * totalMass;
                product.Food.EPA += products[i].Food.EPA * totalMass;
                product.Food.Fett += products[i].Food.Fett * totalMass;
                product.Food.Fettsyra += products[i].Food.Fettsyra * totalMass;
                product.Food.Fibrer += products[i].Food.Fibrer * totalMass;
                product.Food.Folat += products[i].Food.Fosfor * totalMass;
                product.Food.FullkornTotalt += products[i].Food.FullkornTotalt * totalMass;
                product.Food.Jod += products[i].Food.Jod * totalMass;
                product.Food.Jarn += products[i].Food.Jarn * totalMass;
                product.Food.Kalcium += products[i].Food.Kalcium * totalMass;
                product.Food.Kalium += products[i].Food.Kalium * totalMass;
                product.Food.Karoten += products[i].Food.Karoten * totalMass;
                product.Food.Kolesterol += products[i].Food.Kolesterol * totalMass;
                product.Food.Kolhydrater += products[i].Food.Kolhydrater * totalMass;
                product.Food.Koppar += products[i].Food.Koppar * totalMass;
                product.Food.Laurinsyra += products[i].Food.Laurinsyra * totalMass;
                product.Food.Linolensyra += products[i].Food.Linolensyra * totalMass;
                product.Food.Linolsyra += products[i].Food.Linolsyra * totalMass;
                product.Food.Magnesium += products[i].Food.Magnesium * totalMass;
                product.Food.Monosackarider += products[i].Food.Monosackarider * totalMass;
                product.Food.Myristinsyra += products[i].Food.Myristinsyra * totalMass;
                product.Food.Natrium += products[i].Food.Natrium * totalMass;
                product.Food.Niacin += products[i].Food.Niacin * totalMass;
                product.Food.Niacinekvivalenter += products[i].Food.Niacinekvivalenter * totalMass;
                product.Food.Oljesyra += products[i].Food.Oljesyra * totalMass;
                product.Food.Palmitinsyra += products[i].Food.Palmitinsyra * totalMass;
                product.Food.Palmitoljesyra += products[i].Food.Palmitoljesyra * totalMass;
                product.Food.Protein += products[i].Food.Protein * totalMass;
                product.Food.Retinol += products[i].Food.Retinol * totalMass;
                product.Food.Riboflavin += products[i].Food.Riboflavin * totalMass;
                product.Food.Sackaros += products[i].Food.Sackaros * totalMass;
                product.Food.Salt += products[i].Food.Salt * totalMass;
                product.Food.Selen += products[i].Food.Selen * totalMass;
                product.Food.Sockerarter += products[i].Food.Sockerarter * totalMass;
                product.Food.Stearinsyra += products[i].Food.Stearinsyra * totalMass;
                product.Food.Starkelse += products[i].Food.Starkelse * totalMass;
                product.Food.SummaEnkelOmattadeFettsyror += products[i].Food.SummaEnkelOmattadeFettsyror * totalMass;
                product.Food.SummaFleromattadeFettsyror += products[i].Food.SummaFleromattadeFettsyror * totalMass;
                product.Food.SummaMattadeFettsyror += products[i].Food.SummaMattadeFettsyror * totalMass;
                product.Food.Tiamin += products[i].Food.Tiamin * totalMass;
                product.Food.Vatten += products[i].Food.Vatten * totalMass;
                product.Food.VitaminA += products[i].Food.VitaminA * totalMass;
                product.Food.VitaminB6 += products[i].Food.VitaminB6 * totalMass;
                product.Food.VitaminB12 += products[i].Food.VitaminB12 * totalMass;
                product.Food.VitaminC += products[i].Food.VitaminC * totalMass;
                product.Food.VitaminD += products[i].Food.VitaminD * totalMass;
                product.Food.VitaminE += products[i].Food.VitaminE * totalMass;
                product.Food.VitaminK += products[i].Food.VitaminK * totalMass;
                product.Food.Zink += products[i].Food.Zink * totalMass;
            }

            var viewModel = new TotalShoppinglistViewModel
            {
                Shoppinglist = shoppingList,
                Product = product
            };

            return View(viewModel);
        }

        public ActionResult Recipe(int id)
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
            System.Web.Helpers.WebCache.Set("tempRecipe", recipe);
            return RedirectToAction("New", "Recipe");
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