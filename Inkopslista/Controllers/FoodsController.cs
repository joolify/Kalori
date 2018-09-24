using System;
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
            return View();
        }

        public ActionResult GetFood(string term)
        {
            var food = _context.Food.Where(c => c.Name.Contains(term)).OrderBy(c => c.Name)
                .Select(a => new {label = a.Name, id = a.Id}).Take(20);
            return Json(food, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFoodList(string input)
        {
            if (input == null)
                input = "1";
            var id = int.Parse(input);
            var food = _context.Food.FirstOrDefault(c => c.Id == id);
            System.Diagnostics.Debug.WriteLine("food: " + food.Name);
            return Json(food, JsonRequestBehavior.AllowGet);
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