using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.ViewModels
{
    public class DetailsShoppinglistViewModel
    {
        public Shoppinglist Shoppinglist { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CategoryType> CategoryTypes { get; set; }
    }
}