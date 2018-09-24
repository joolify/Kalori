using System.Collections.Generic;
using System.Linq;
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
            var movies = _context.Food.ToList();
            movies = movies.OrderBy(o => o.Name).ToList();

            return View();
        }

        public ActionResult GetFood(string term)
        {
            return Json(_context.Food.Where(c => c.Name.StartsWith(term)).Select(a => new { label = a.Name, id = a.Id }), JsonRequestBehavior.AllowGet);
        }
        /*
        public ActionResult Details(int id)
        {
            var customer = _context.Food.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            //return View(customer);
        }
        */
    }
}