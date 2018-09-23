using System.Collections.Generic;
using System.Web.Mvc;
using Inkopslista.Models;
using Inkopslista.ViewModels;


namespace Inkopslista.Controllers
{
    public class FoodsController : Controller
    {
        // GET: Foods
        public ViewResult Index()
        {
            var movies = GetFoods();

            return View(movies);
        }

        private IEnumerable<Food> GetFoods()
        {
            return new List<Food>
            {
                new Food { Id = 1, Name = "Apelsin" },
                new Food { Id = 2, Name = "Banan" }
            };
        }

        // GET: Foods/Random
        public ActionResult Random()
        {
            var food = new Food() { Name = "Choklad" };
            var products = new List<Product>
            {
                new Product { Price = 30 },
                new Product { Price = 20 }
            };

            var viewModel = new RandomFoodViewModel
            {
                Food = food,
                Products = products
            };

            return View(viewModel);
        }
    }
}