﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inkopslista.Models;

namespace Inkopslista.ViewModels
{
    public class IndexFoodViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CategoryType> CategoryTypes { get; set; }
    }
}