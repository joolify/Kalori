﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.ViewModels
{
    public class NewRecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public Product NewProduct { get; set; }
        public Instruction NewInstruction { get; set; }
    }
}