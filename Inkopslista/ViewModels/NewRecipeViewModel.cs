using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inkopslista.Models;

namespace Inkopslista.ViewModels
{
    public class NewRecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public Product NewProduct { get; set; }
    }
}