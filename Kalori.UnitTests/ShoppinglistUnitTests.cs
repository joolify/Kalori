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
        public void CreateProduct_Returns_FoodElement()
        {
            // Arrange
            Mock<IShoppinglistRepository> mockRepo = new Mock<IShoppinglistRepository>();
            mockRepo.Setup(m => m.Get(1)).Returns(new Shoppinglist());
            // Arrange
            ShoppinglistService service = new ShoppinglistService(mockRepo.Object);

            // Act
            var actual = service.GetFood(1);

            // Assert
            Assert.IsNotNull(actual);
        }
    }
}
