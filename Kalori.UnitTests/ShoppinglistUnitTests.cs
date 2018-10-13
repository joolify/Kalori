using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalori.Interfaces;
using Kalori.Models;
using Kalori.Services;
using Kalori.UoW;
using Moq;
using NUnit.Framework;

namespace Kalori.UnitTests
{
    [TestFixture]
    class ShoppinglistUnitTests
    {

        //FIXME Change method name
        [Test]
        public void GetWithProducts_IdOne_ReturnsShoppinglist()
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
        public void GetAllWithProducts_IdOne_ReturnThreeRows()
        {
            // Arrange
            var mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.GetAllWithProducts())
                .Returns(
                     new Shoppinglist[]
                    {
                        new Shoppinglist {Id = 1, Name = "Test"},
                        new Shoppinglist {Id = 2, Name = "Test2"},
                        new Shoppinglist {Id = 3, Name = "Test3"}
                    }.AsQueryable()
                    
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Shoppinglists).Returns(mockRepo.Object);

            ShoppinglistService service = new ShoppinglistService();

            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreEqual(3, actual.Count());
        }

    }
}
