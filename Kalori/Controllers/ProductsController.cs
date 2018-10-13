// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 09-24-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-08-2018
// ***********************************************************************
// <copyright file="ProductsController.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Kalori.Models;
using Kalori.ViewModels;

namespace Kalori.Controllers
{
    /// <summary>
    /// Lists, updates and edits Products.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ProductsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ViewResult.</returns>
        public ViewResult Index()
        {

            return View();
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
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