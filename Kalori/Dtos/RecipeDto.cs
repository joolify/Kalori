﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kalori.Models
{
    public class RecipeDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public List<Instruction> Instructions { get; set; }
        public List<String> Images { get; set; }
        public int CookingTimeH { get; set; }
        public int CookingTimeM { get; set; }
        public int Portions { get; set; }
        public Image Image { get; set; }

    }
}