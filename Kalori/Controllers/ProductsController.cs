using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Kalori.Models;
using Kalori.ViewModels;

namespace Kalori.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {

            return View();
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