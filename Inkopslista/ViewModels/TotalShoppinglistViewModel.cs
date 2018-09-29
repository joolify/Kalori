using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inkopslista.Models;

namespace Inkopslista.ViewModels
{
    public class TotalShoppinglistViewModel
    {
        public Shoppinglist Shoppinglist { get; set; }
        public Product Product { get; set; }
    }
}