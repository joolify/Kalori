using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.ViewModels
{
    public class DetailsFoodViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<CategoryType> CategoryTypes { get; set; }
    }
}