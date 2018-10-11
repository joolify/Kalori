using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    public interface IShoppinglistRepository : IRepository<Shoppinglist>
    {
        Shoppinglist GetWithProducts(int id);
        IEnumerable<Shoppinglist> GetAllWithProducts(); 
    }
}