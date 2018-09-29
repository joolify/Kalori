
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Pris:")]
        public float? PriceTotal { get; set; }
        public float? PricePerKg { get; set; }
        [Display(Name = "Vara:")]

        [ForeignKey("Food")]
        public int? FoodId { get; set; }
        public Food Food { get; set; }
        public string FoodName { get; set; }
        public float? Mass { get; set; }

        public int? ShoppinglistId { get; set; }
        public int? RecipeId { get; set; }
    }
}