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
        IEnumerable<Shoppinglist> GetList();
        void Add(Shoppinglist shoppinglist);
        void Remove(Shoppinglist shoppinglist);
        void Save();
        IEnumerable<Product> GetProducts(int id);
        void SaveProduct(Product product);
        void RemoveProduct(Product product);
        Product GetProduct(int id);
        Food GetFood(int? id);
        CategoryType GetCategoryType(int? id);
        void Dispose(bool disposing);
    }
}