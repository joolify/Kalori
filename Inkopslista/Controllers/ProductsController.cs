using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Inkopslista.Models;

namespace Inkopslista.Controllers
{
    public class ProductsController : Controller
    {
        public ViewResult Index()
        {
            var products = GetProducts();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = GetProducts().SingleOrDefault(c => c.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Price = 30 },
                new Product { Id = 2, Price = 20 }
            };
        }
    }
}