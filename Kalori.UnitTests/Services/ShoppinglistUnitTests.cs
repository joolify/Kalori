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
            IEnumerable<Shoppinglist> shoppinglists = new[] {
                        new Shoppinglist {Id = 1, Name = "Test"},
                        new Shoppinglist {Id = 2, Name = "Test2"},
                        new Shoppinglist {Id = 3, Name = "Test3"}
            };
            var mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetAllWithProducts())
                .Returns(
                    shoppinglists
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
            var ID = 1;
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.Get(ID))
                .Returns(
                    new Product { Id = ID }
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetProduct(ID);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Product));
        }

        [Test]
        public void GetAllProducts_IdOne_Returns_ThreeRows()
        {
            // Arrange
            IEnumerable<Product> products = new[] {
                new Product {Id = 1},
                new Product {Id = 2},
                new Product {Id = 3}
            };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.GetAllFromShoppingList(1))
                .Returns(
                     products
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
            var ID = 1;
            var mockRepo = new Mock<IFoodRepository>();
            mockRepo.Setup(m => m.Get(ID))
                .Returns(
                    new Food { Id = ID, Name = "Test" }
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Foods).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetFood(ID);

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
        [Test]
        public void AddOrUpdate_Shoppinglist_Returns_True()
        {
            // Arrange
            var shoppinglist = new Shoppinglist { Name = "test" };
            var mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.AddOrUpdate(shoppinglist))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Shoppinglists).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.AddOrUpdate(shoppinglist);

            // Assert
            Assert.IsTrue(actual);
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

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

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

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.Remove(product);

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void Remove_Shoppinglist_Returns_True()
        {
            // Arrange
            var shoppinglist = new Shoppinglist { Name = "test" };
            var mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.Remove(shoppinglist))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Shoppinglists).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.Remove(shoppinglist);

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void RemoveRange_Products_Returns_True()
        {
            // Arrange
            IEnumerable<Product> products = new[] {
                new Product {Id = 1},
                new Product {Id = 2},
                new Product {Id = 3}
            };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(m => m.RemoveRange(products))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Products).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService(mockUnitOfWork.Object);

            // Act
            var actual = service.RemoveRange(products);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
