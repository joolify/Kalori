using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Dtos
{
    public class ShoppinglistDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}