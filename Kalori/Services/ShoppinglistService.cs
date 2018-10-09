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

namespace Kalori.Services
{
    public class ShoppinglistService
    {
        private readonly IShoppinglistRepository _shoppinglistRepo;

        public ShoppinglistService()
        {
            _shoppinglistRepo = new ShoppinglistRepository();
        }
        public ShoppinglistService(IShoppinglistRepository shoppinglistRepo)
        {
            _shoppinglistRepo = shoppinglistRepo;
        }
        
        public void Dispose(bool disposing)
        {
            _shoppinglistRepo.Dispose(disposing);
        }

        public Shoppinglist Get(int id)
        {
            return _shoppinglistRepo.Get(id);
        }

        public List<Product> GetProducts(int id)
        {
            return _shoppinglistRepo.GetProducts(id).ToList();
        }

        public void Create(Shoppinglist model)
        {
            var shoppinglist = new Shoppinglist();
            shoppinglist.Name = model.Name;

            _shoppinglistRepo.Save(shoppinglist);
        }

        public void CreateProduct(NewProductShoppinglistViewModel viewModel)
        {
            var food = _shoppinglistRepo.GetFood(viewModel.Product.FoodId);
            var categoryType = _shoppinglistRepo.GetCategoryType(food.Category1);

            var product = new Product();
            product.ShoppinglistId = viewModel.Shoppinglist.Id;
            product.Food = food;
            product.FoodId = viewModel.Product.FoodId;
            product.Mass = viewModel.Product.Mass;
            product.PricePerKg = viewModel.Product.PricePerKg;
            product.PriceTotal = viewModel.Product.PricePerKg * (viewModel.Product.Mass / 1000);
            product.CategoryType = categoryType;

            _shoppinglistRepo.SaveProduct(product);
        }

        public Food GetFood(int? id)
        {
            return _shoppinglistRepo.GetFood(id);
        }

        public CategoryType GetCategoryType(int? id)
        {
            return _shoppinglistRepo.GetCategoryType(id);
        }
    }
}