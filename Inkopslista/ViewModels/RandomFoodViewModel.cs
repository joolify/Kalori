using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inkopslista.Models;

namespace Inkopslista.ViewModels
{
    public class RandomFoodViewModel
    {
        public Food Food { get; set; }
        public List<Product> Products { get; set; }
    }
}