using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inkopslista.Models;

namespace Inkopslista.ViewModels
{
    public class NewFoodViewModel
    {
        public IEnumerable<Food> Food { get; set; }
        public Product Product { get; set; }
    }
}