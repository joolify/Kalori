
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public float Price { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }
    }
}