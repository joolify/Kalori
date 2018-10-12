// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-08-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-08-2018
// ***********************************************************************
// <copyright file="Product.cs" company="joolify">
//     Copyright (c) joolify. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kalori.Models
{
    /// <summary>
    /// Class Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the price total.
        /// </summary>
        /// <value>The price total.</value>
        [Display(Name = "Pris:")]
        public float? PriceTotal { get; set; }
        /// <summary>
        /// Gets or sets the price per kg.
        /// </summary>
        /// <value>The price per kg.</value>
        public float? PricePerKg { get; set; }
        /// <summary>
        /// Gets or sets the food identifier.
        /// </summary>
        /// <value>The food identifier.</value>
        [Display(Name = "Vara:")]

        [ForeignKey("Food")]
        public int? FoodId { get; set; }
        /// <summary>
        /// Gets or sets the food.
        /// </summary>
        /// <value>The food.</value>
        public Food Food { get; set; }
        /// <summary>
        /// Gets or sets the category type identifier.
        /// </summary>
        /// <value>The category type identifier.</value>
        public int CategoryTypeId { get; set; }
        /// <summary>
        /// Gets or sets the type of the category.
        /// </summary>
        /// <value>The type of the category.</value>
        public CategoryType CategoryType { get; set; }
        /// <summary>
        /// Gets or sets the name of the food.
        /// </summary>
        /// <value>The name of the food.</value>
        public string FoodName { get; set; }
        /// <summary>
        /// Gets or sets the mass.
        /// </summary>
        /// <value>The mass.</value>
        public float? Mass { get; set; }

        /// <summary>
        /// Gets or sets the shoppinglist identifier.
        /// </summary>
        /// <value>The shoppinglist identifier.</value>
        public int? ShoppinglistId { get; set; }
        /// <summary>
        /// Gets or sets the recipe identifier.
        /// </summary>
        /// <value>The recipe identifier.</value>
        public int? RecipeId { get; set; }
    }
}