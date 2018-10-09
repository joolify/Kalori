using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.ViewModels
{
    public class NewProductShoppinglistViewModel
    {
        public Shoppinglist Shoppinglist { get; set; }
        public Product Product { get; set; }
    }
}