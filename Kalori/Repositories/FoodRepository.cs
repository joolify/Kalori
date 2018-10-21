// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-12-2018
// ***********************************************************************
// <copyright file="FoodRepository.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Kalori.Interfaces;
using Kalori.Models;

namespace Kalori.Repositories
{
    /// <summary>
    /// Class FoodRepository.
    /// </summary>
    /// <seealso cref="Kalori.Repositories.Repository{Kalori.Models.Food}" />
    /// <seealso cref="Kalori.Interfaces.IFoodRepository" />
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context = new ApplicationDbContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public FoodRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Gets the specified Food.
        /// </summary>
        /// <param name="id">The Food identifier.</param>
        /// <returns>Food.</returns>
        public Food Get(int? id)
        {
            return _context.Foods.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Gets the specified CategoryType.
        /// </summary>
        /// <param name="id">The CategoryType identifier.</param>
        /// <returns>CategoryType.</returns>
        public CategoryType GetCategoryType(int? id)
        {
            return _context.CategoryTypes.FirstOrDefault(c => c.Category == id);
        }
        /// <summary>
        /// Gets the application database context.
        /// </summary>
        /// <value>The application database context.</value>
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context;}
        }
    }
}