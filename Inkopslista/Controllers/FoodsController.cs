using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Inkopslista.Models;
using Inkopslista.ViewModels;


namespace Inkopslista.Controllers
{
    public class FoodsController : Controller
    {
        private ApplicationDbContext _context;
        public FoodsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var products = _context.Products.Include(c => c.Food).ToList();
            var categoryTypes = _context.CategoryTypes.ToList();

            var viewModel = new IndexFoodViewModel()
            {
                Products = products,
                CategoryTypes = categoryTypes
            };

            return View(viewModel);
        }


        public ViewResult New()
        {
            var foods = _context.Foods.ToList();
            var viewModel = new NewFoodViewModel()
            {
                Product = new Product(),
                Food = foods
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(NewFoodViewModel viewModel)
        {
            var product = new Product
            {
                Food = _context.Foods.FirstOrDefault(c => c.Id == viewModel.Product.FoodId),
                FoodId = viewModel.Product.FoodId,
                Price = viewModel.Product.Price
            };
            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Foods");
        }

        public ActionResult GetFood(string term)
        {
            var food = _context.Foods.Where(c => c.Name.Contains(term)).OrderBy(c => c.Name)
                .Select(a => new {label = a.Name, id = a.Id}).Take(20);
            return Json(food, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFoodList(string input)
        {
            if (input == null)
                input = "1";
            var id = int.Parse(input);
            var food = _context.Foods.FirstOrDefault(c => c.Id == id);
            System.Diagnostics.Debug.WriteLine("food: " + food.Name);
            return Json(food, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(c => c.Food).SingleOrDefault(c => c.Id == id);

            if (product == null)
                return HttpNotFound();

            var categoryTypes = _context.CategoryTypes.ToList();

            var viewModel = new DetailsFoodViewModel()
            {
                Product = product,
                CategoryTypes = categoryTypes
            };

            return View(viewModel);

        }
    }
}