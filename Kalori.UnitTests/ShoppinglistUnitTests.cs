using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Services;
using Moq;
using NUnit.Framework;

namespace Kalori.UnitTests
{
    [TestFixture]
    class ShoppinglistUnitTests
    {
        [Test]
        public void Details_Returns_Shoppinglist()
        {
            // Arrange
            Mock<IShoppinglistRepository> mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetWithProducts(1))
                .Returns(
                    new Shoppinglist {Id = 1, Name = "Test"}
                    );
            ShoppinglistService service = new ShoppinglistService(mockRepo.Object);

            // Act
            var actual = service.Get(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Shoppinglist));
        }

        [Test]
        public void CreateProduct_Returns_Food()
        {
            // Arrange
            Mock<IShoppinglistRepository> mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetFood(1))
                .Returns(
                    new Food { Id = 1, Name = "Test" }
                );
            ShoppinglistService service = new ShoppinglistService(mockRepo.Object);

            // Act
            var actual = service.GetFood(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Food));
        }

        [Test]
        public void CreateProduct_Returns_CategoryType()
        {
            // Arrange
            Mock<IShoppinglistRepository> mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetCategoryType(1))
                .Returns(
                    new CategoryType { Id = 1, Name = "Test" }
                );
            ShoppinglistService service = new ShoppinglistService(mockRepo.Object);

            // Act
            var actual = service.GetCategoryType(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(CategoryType));
        }

        [Test]
        public void Total_Returns_ThreeRows()
        {
            // Arrange
            Mock<IShoppinglistRepository> mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetProducts(1))
                .Returns(
                    new Product[] { new Product { Id = 1}, new Product { Id = 2}, new Product { Id = 3 } }.AsQueryable()
                );
            ShoppinglistService service = new ShoppinglistService(mockRepo.Object);

            // Act
            var actual = service.GetProducts(1);

            // Assert
            Assert.AreEqual(3, actual.Count);
        }
    }
}
