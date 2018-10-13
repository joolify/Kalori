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
    class ShoppinglistUnitTests
    {

        [Test]
        public void Get_IdOne_Returns_Shoppinglist()
        {
            // Arrange
            var mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetWithProducts(1))
                .Returns(
                    new Shoppinglist { Id = 1, Name = "Test" }
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Shoppinglists).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.Get(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Shoppinglist));
        }

        [Test]
        public void GetAll_IdOne_Returns_ThreeRows()
        {
            // Arrange
            var mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetAllWithProducts())
                .Returns(
                     new[]
                    {
                        new Shoppinglist {Id = 1, Name = "Test"},
                        new Shoppinglist {Id = 2, Name = "Test2"},
                        new Shoppinglist {Id = 3, Name = "Test3"}
                    }.AsQueryable()

                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Shoppinglists).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreEqual(3, actual.Count());
        }

        [Test]
        public void GetProduct_IdOne_Returns_Product()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.Get(1))
                .Returns(
                    new Product { Id = 1 }
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetProduct(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Product));
        }

        [Test]
        public void GetAllProducts_IdOne_Returns_ThreeRows()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.GetAllFromShoppingList(1))
                .Returns(
                     new[]
                    {
                        new Product {Id = 1},
                        new Product {Id = 2},
                        new Product {Id = 3}
                    }.AsQueryable()
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetAllProducts(1);

            // Assert
            Assert.AreEqual(3, actual.Count());
        }
        [Test]
        public void GetFood_IdOne_Returns_Food()
        {
            // Arrange
            var mockRepo = new Mock<IFoodRepository>();
            mockRepo.Setup(m => m.Get(1))
                .Returns(
                    new Food { Id = 1, Name = "Test" }
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Foods).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetFood(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Food));
        }

        [Test]
        public void GetCategoryType_IdOne_Returns_CategoryType()
        {
            // Arrange
            var mockRepo = new Mock<IFoodRepository>();
            mockRepo.Setup(m => m.GetCategoryType(1))
                .Returns(
                    new CategoryType { Id = 1, Name = "Test" }
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Foods).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetCategoryType(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(CategoryType));
        }
    }
}
