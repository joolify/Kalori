// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-11-2018
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
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public FoodRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Food Get(int? id)
        {
            return _context.Foods.FirstOrDefault(c => c.Id == id);
        }

        public CategoryType GetCategoryType(int? id)
        {
            return _context.CategoryTypes.FirstOrDefault(c => c.Category == id);
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext;}
        }
    }
}