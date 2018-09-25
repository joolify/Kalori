
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
        public float Price { get; set; }
        [Display(Name = "Vara:")]

        [ForeignKey("Food")]
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}