// ***********************************************************************
// Assembly         : Kalori
// Author           : Joel Wiklund
// Created          : 10-08-2018
//
// Last Modified By : Joel Wiklund
// Last Modified On : 10-08-2018
// ***********************************************************************
// <copyright file="Recipe.cs" company="joolify">
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
    /// Class Recipe.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public List<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>The instructions.</value>
        public List<Instruction> Instructions { get; set; }
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public List<String> Images { get; set; }
        /// <summary>
        /// Gets or sets the cooking time h.
        /// </summary>
        /// <value>The cooking time h.</value>
        public int CookingTimeH { get; set; }
        /// <summary>
        /// Gets or sets the cooking time m.
        /// </summary>
        /// <value>The cooking time m.</value>
        public int CookingTimeM { get; set; }
        /// <summary>
        /// Gets or sets the portions.
        /// </summary>
        /// <value>The portions.</value>
        public int Portions { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class.
        /// </summary>
        public Recipe()
        {
            Products = new List<Product>();
            Instructions = new List<Instruction>();
            Image = new Image();
        }
    }
}