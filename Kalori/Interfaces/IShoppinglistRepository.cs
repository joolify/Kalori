using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kalori.Models;

namespace Kalori.Interfaces
{
    public interface IShoppinglistRepository
    {
        Shoppinglist Get(int id);
        IEnumerable<Product> GetProducts(int id);
        void Save(Shoppinglist shoppinglist);
        void SaveProduct(Product product);
        Food GetFood(int? id);
        CategoryType GetCategoryType(int? id);
        void Dispose(bool disposing);
    }
}