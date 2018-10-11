using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Repositories;
using Kalori.ViewModels;
using Kalori.UoW;

namespace Kalori.Services
{
    public class ShoppinglistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppinglistService()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }

        public void Complete()
        {
            _unitOfWork.Complete();
        }

        /********************************************************
         **** GETTERS
         ********************************************************/

        public Shoppinglist Get(int id)
        {
            return _unitOfWork.Shoppinglists.GetWithProducts(id);
        }

        public IEnumerable<Shoppinglist> GetAll()
        {
            return _unitOfWork.Shoppinglists.GetAllWithProducts();
        }

        public Product GetProduct(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public IEnumerable<Product> GetProducts(int id)
        {
            return _unitOfWork.Products.GetProductsWithFoodAndCategoryTypeOfShoppingList(id);
        }
        public Food GetFood(int? id)
        {
            return _unitOfWork.Foods.Get(id);
        }

        public CategoryType GetCategoryType(int? id)
        {
            return _unitOfWork.Foods.GetCategoryType(id);
        }

        /********************************************************
         **** ADDERS
         ********************************************************/

        public void Add(Shoppinglist shoppinglist)
        {
            _unitOfWork.Shoppinglists.Add(shoppinglist);
            _unitOfWork.Complete();
        }
        public void AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
        }

        /********************************************************
         **** REMOVERS
         ********************************************************/
        public void Remove(Shoppinglist shoppinglist)
        {
            _unitOfWork.Shoppinglists.Remove(shoppinglist);
            _unitOfWork.Complete();
        }
        public void RemoveProduct(Product product)
        {
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Complete();
        }

    }
}
