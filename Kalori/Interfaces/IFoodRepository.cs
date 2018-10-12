// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-11-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-11-2018
// ***********************************************************************
// <copyright file="IFoodRepository.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    /// <summary>
    /// Interface IFoodRepository
    /// </summary>
    /// <seealso cref="Kalori.Interfaces.IRepository{Kalori.Models.Food}" />
    public interface IFoodRepository : IRepository<Food>
    {
        /// <summary>
        /// Gets the specified Food.
        /// </summary>
        /// <param name="id">The Food identifier.</param>
        /// <returns>Food.</returns>
        Food Get(int? id);
        /// <summary>
        /// Gets the specifiend CategoryType.
        /// </summary>
        /// <param name="id">The CategoryType identifier.</param>
        /// <returns>CategoryType.</returns>
        CategoryType GetCategoryType(int? id);
    }
}