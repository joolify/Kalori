using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Repositories;
using Kalori.Services;
using Kalori.UoW;
using Moq;
using NUnit.Framework;

namespace Kalori.UnitTests
{
    [TestFixture]
    class ProductUnitTests
    {
        [Test]
        public void Get_IdOne_Returns_Product()
        {
            // Arrange
            var product = new Product { Mass = 50 };
            const int ID = 1;
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.Get(ID))
                .Returns(
                    product
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ProductService service = new ProductService(mockUnitOfWork.Object);

            // Act
            var actual = service.Get(ID);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Product));
        }
        [Test]
        public void GetAllFromShoppinglist_IdOne_Returns_ThreeRows()
        {
            // Arrange
            const int ID = 1;
            IEnumerable<Product> products = new[] {
                        new Product {Id = 1},
                        new Product {Id = 2},
                        new Product {Id = 3}
            };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.GetAllFromShoppingList(ID))
                .Returns(
                    products
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ProductService service = new ProductService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetAllFromShoppinglist(ID);

            // Assert
            Assert.AreEqual(3, actual.Count());
        }

        [Test]
        public void GetAllFoods_void_Returns_ThreeRows()
        {
            // Arrange
            IEnumerable<Food> foods = new[] {
                        new Food {Id = 1, Name = "Test"},
                        new Food {Id = 2, Name = "Test2"},
                        new Food {Id = 3, Name = "Test3"}
            };
            var mockRepo = new Mock<IFoodRepository>();
            mockRepo.Setup(m => m.GetAll())
                .Returns(
                    foods
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Foods).Returns(mockRepo.Object);

            ProductService service = new ProductService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetAllFoods();

            // Assert
            Assert.AreEqual(3, actual.Count());
        }
       [Test]
        public void AddOrUpdate_Product_Returns_True()
        {
            // Arrange
            var product = new Product { Mass = 50 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.AddOrUpdate(product))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ProductService service = new ProductService(mockUnitOfWork.Object);

            // Act
            var actual = service.AddOrUpdate(product);

            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void Remove_Product_Returns_True()
        {
            // Arrange
            var product = new Product { Mass = 50 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.Remove(product))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ProductService service = new ProductService(mockUnitOfWork.Object);

            // Act
            var actual = service.Remove(product);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
