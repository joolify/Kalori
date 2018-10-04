
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        public float? PriceTotal { get; set; }
        public float? PricePerKg { get; set; }

        [ForeignKey("Food")]
        public FoodDto Food { get; set; }
        public CategoryType CategoryType { get; set; }
        public float? Mass { get; set; }
        public int? FoodId { get; set; }

        public int? ShoppinglistId { get; set; }
        public int? RecipeId { get; set; }
    }
}