// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-09-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-13-2018
// ***********************************************************************
// <copyright file="ShoppinglistsController.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalori.Models;
using Kalori.Services;
using Kalori.ViewModels;

namespace Kalori.Controllers
{
    /// <summary>
    /// Class ShoppinglistsController creates lists and edits Shoppinglists
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ShoppinglistsController : Controller
    {
        /// <summary>
        /// A Shoppinglist Service layer. 
        /// </summary>
        private ShoppinglistService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppinglistsController"/> class.
        /// Initializes a new instance of the <see cref="ShoppinglistService"/> class.
        /// </summary>
        public ShoppinglistsController()
        {
            _service = new ShoppinglistService();
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
        /// Returns a list of Shoppinglists
        /// </summary>
        /// <returns>ViewResult.</returns>
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns a new Shoppinglist
        /// </summary>
        /// <returns>ViewResult.</returns>
        public ViewResult New()
        {
            return View();

        }
        /// <summary>
        ///A detailed Shoppinglist
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int id)
        {
            return View(_service.Get(id));

        }
        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>ViewResult.</returns>
        public ViewResult NewProduct(int id)
        {
            var viewModel = new NewProductShoppinglistViewModel()
            {
                Shoppinglist = new Shoppinglist
                {
                    Id = id
                },
                Product = new Product(),
            };
            return View(viewModel);
        }
        /// <summary>
        /// Lists all nutrient contents of a list of Products.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ViewResult.</returns>
        public ViewResult Total(int id)
        {
            var shoppingList = new Shoppinglist
            {
                Id = id
            };

            var products = _service.GetAllProducts(id).ToList();

            var productTotal = new Product
            {
                Mass = 0
            };
            productTotal.Food = new Food();


            for (int i = 0; i < products.Count; i++)
            {
                var totalMass = products[i].Mass / 100;
                productTotal.Mass += products[i].Mass;
                productTotal.Food.Alkohol += products[i].Food.Alkohol * totalMass;
                productTotal.Food.Arakidinsyra += products[i].Food.Arakidinsyra * totalMass;
                productTotal.Food.Arakidonsyra += products[i].Food.Arakidonsyra * totalMass;
                productTotal.Food.Aska += products[i].Food.Aska * totalMass;
                productTotal.Food.Avfall += products[i].Food.Avfall * totalMass;
                productTotal.Food.DHA += products[i].Food.DHA * totalMass;
                productTotal.Food.Disackarider += products[i].Food.Disackarider * totalMass;
                productTotal.Food.DPA += products[i].Food.DPA * totalMass;
                productTotal.Food.EnergiKJ += products[i].Food.EnergiKJ * totalMass;
                productTotal.Food.EnergiKcal += products[i].Food.EnergiKcal * totalMass;
                productTotal.Food.EPA += products[i].Food.EPA * totalMass;
                productTotal.Food.Fett += products[i].Food.Fett * totalMass;
                productTotal.Food.Fettsyra += products[i].Food.Fettsyra * totalMass;
                productTotal.Food.Fibrer += products[i].Food.Fibrer * totalMass;
                productTotal.Food.Folat += products[i].Food.Fosfor * totalMass;
                productTotal.Food.FullkornTotalt += products[i].Food.FullkornTotalt * totalMass;
                productTotal.Food.Jod += products[i].Food.Jod * totalMass;
                productTotal.Food.Jarn += products[i].Food.Jarn * totalMass;
                productTotal.Food.Kalcium += products[i].Food.Kalcium * totalMass;
                productTotal.Food.Kalium += products[i].Food.Kalium * totalMass;
                productTotal.Food.Karoten += products[i].Food.Karoten * totalMass;
                productTotal.Food.Kolesterol += products[i].Food.Kolesterol * totalMass;
                productTotal.Food.Kolhydrater += products[i].Food.Kolhydrater * totalMass;
                productTotal.Food.Koppar += products[i].Food.Koppar * totalMass;
                productTotal.Food.Laurinsyra += products[i].Food.Laurinsyra * totalMass;
                productTotal.Food.Linolensyra += products[i].Food.Linolensyra * totalMass;
                productTotal.Food.Linolsyra += products[i].Food.Linolsyra * totalMass;
                productTotal.Food.Magnesium += products[i].Food.Magnesium * totalMass;
                productTotal.Food.Monosackarider += products[i].Food.Monosackarider * totalMass;
                productTotal.Food.Myristinsyra += products[i].Food.Myristinsyra * totalMass;
                productTotal.Food.Natrium += products[i].Food.Natrium * totalMass;
                productTotal.Food.Niacin += products[i].Food.Niacin * totalMass;
                productTotal.Food.Niacinekvivalenter += products[i].Food.Niacinekvivalenter * totalMass;
                productTotal.Food.Oljesyra += products[i].Food.Oljesyra * totalMass;
                productTotal.Food.Palmitinsyra += products[i].Food.Palmitinsyra * totalMass;
                productTotal.Food.Palmitoljesyra += products[i].Food.Palmitoljesyra * totalMass;
                productTotal.Food.Protein += products[i].Food.Protein * totalMass;
                productTotal.Food.Retinol += products[i].Food.Retinol * totalMass;
                productTotal.Food.Riboflavin += products[i].Food.Riboflavin * totalMass;
                productTotal.Food.Sackaros += products[i].Food.Sackaros * totalMass;
                productTotal.Food.Salt += products[i].Food.Salt * totalMass;
                productTotal.Food.Selen += products[i].Food.Selen * totalMass;
                productTotal.Food.Sockerarter += products[i].Food.Sockerarter * totalMass;
                productTotal.Food.Stearinsyra += products[i].Food.Stearinsyra * totalMass;
                productTotal.Food.Starkelse += products[i].Food.Starkelse * totalMass;
                productTotal.Food.SummaEnkelOmattadeFettsyror += products[i].Food.SummaEnkelOmattadeFettsyror * totalMass;
                productTotal.Food.SummaFleromattadeFettsyror += products[i].Food.SummaFleromattadeFettsyror * totalMass;
                productTotal.Food.SummaMattadeFettsyror += products[i].Food.SummaMattadeFettsyror * totalMass;
                productTotal.Food.Tiamin += products[i].Food.Tiamin * totalMass;
                productTotal.Food.Vatten += products[i].Food.Vatten * totalMass;
                productTotal.Food.VitaminA += products[i].Food.VitaminA * totalMass;
                productTotal.Food.VitaminB6 += products[i].Food.VitaminB6 * totalMass;
                productTotal.Food.VitaminB12 += products[i].Food.VitaminB12 * totalMass;
                productTotal.Food.VitaminC += products[i].Food.VitaminC * totalMass;
                productTotal.Food.VitaminD += products[i].Food.VitaminD * totalMass;
                productTotal.Food.VitaminE += products[i].Food.VitaminE * totalMass;
                productTotal.Food.VitaminK += products[i].Food.VitaminK * totalMass;
                productTotal.Food.Zink += products[i].Food.Zink * totalMass;
            }

            var viewModel = new TotalShoppinglistViewModel
            {
                Shoppinglist = shoppingList,
                Product = productTotal
            };

            return View(viewModel);
        }

        /********************************************************
         **** POST
         ********************************************************/

        /// <summary>
        /// Adds a new Shoppinglist
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Add(Shoppinglist model)
        {
            var shoppinglist = new Shoppinglist();
            shoppinglist.Name = model.Name;
            _service.AddOrUpdate(shoppinglist);
            _service.Complete();
            
            return RedirectToAction("Index", "Shoppinglists");
        }

        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult CreateProduct(NewProductShoppinglistViewModel viewModel)
        {
            var food = _service.GetFood(viewModel.Product.FoodId);
            var categoryType = _service.GetCategoryType(food.Category1);

             var product = new Product();
            product.ShoppinglistId = viewModel.Shoppinglist.Id;
            product.Food = food;
            product.FoodId = viewModel.Product.FoodId;
            product.Mass = viewModel.Product.Mass;
            product.PricePerKg = viewModel.Product.PricePerKg;
            product.PriceTotal = viewModel.Product.PricePerKg * (viewModel.Product.Mass / 1000);
            product.CategoryType = categoryType;

            _service.AddOrUpdate(product);
            _service.Complete();

            return RedirectToAction("Details", "Shoppinglists", new {id = viewModel.Shoppinglist.Id});
        }

        /// <summary>
        /// Creates a temporary Recipe for the Recipe View
        /// </summary>
        /// <param name="id">The Shoppinglist identifier.</param>
        /// <returns>ActionResult.</returns>
        //TODO Remove
        public ActionResult Recipe(int id)
        {
            var recipe = new Recipe();
            var products = _service.GetAllProducts(id).ToList();
            for (int i = 0; i < products.Count; i++)
            {
                var food = new Food();
                var fid = products[i].FoodId;
                food = _service.GetFood(fid);
                products[i].Food = food;
                products[i].CategoryType = _service.GetCategoryType(food.Category1);
            }

            recipe.Products = products;
            _service.SetTempRecipe("tempRecipe", recipe);
            return RedirectToAction("New", "Recipes");
        }
    }
}