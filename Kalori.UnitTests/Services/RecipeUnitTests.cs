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
    class RecipeUnitTests
    {

        [Test]
        public void Get_IdOne_Returns_Recipe()
        {
            // Arrange
            var recipe = new Recipe {Name = "test"};
            var ID = 1;
            var mockRepo = new Mock<IRecipeRepository>();
            mockRepo.Setup(m => m.GetRecipe(ID))
                .Returns(
                    recipe
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Recipes).Returns(mockRepo.Object);

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

            // Act
            var actual = service.Get(ID);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Recipe));
        }

        [Test]
        public void GetAll_IdOne_Returns_ThreeRows()
        {
            // Arrange
            IEnumerable<Recipe> recipes = new[] {
                        new Recipe {Id = 1, Name = "Test"},
                        new Recipe {Id = 2, Name = "Test2"},
                        new Recipe {Id = 3, Name = "Test3"}
            };
            var mockRepo = new Mock<IRecipeRepository>();
            mockRepo.Setup(m => m.GetAllRecipes())
                .Returns(
                    recipes
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Recipes).Returns(mockRepo.Object);

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

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

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetProduct(ID);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(Product));
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

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

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

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

            // Act
            var actual = service.GetCategoryType(1);

            // Assert
            Assert.IsTrue(actual.GetType() == typeof(CategoryType));
        }
        [Test]
        public void AddOrUpdate_Recipe_Returns_True()
        {
            // Arrange
            var recipe = new Recipe { Name = "test" };
            var mockRepo = new Mock<IRecipeRepository>();
            mockRepo.Setup(m => m.AddOrUpdate(recipe))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Recipes).Returns(mockRepo.Object);

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

            // Act
            var actual = service.AddOrUpdate(recipe);

            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void Remove_Recipe_Returns_True()
        {
            // Arrange
            var product = new Recipe { Name = "Test" };
            var mockRepo = new Mock<IRecipeRepository>();
            mockRepo.Setup(m => m.Remove(product))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Recipes).Returns(mockRepo.Object);

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

            // Act
            var actual = service.Remove(product);

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

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

            // Act
            var actual = service.RemoveRange(products);

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void RemoveRange_Instructions_Returns_True()
        {
            // Arrange
            IEnumerable<Instruction> instructions = new[] {
                new Instruction {Id = 1},
                new Instruction {Id = 2},
                new Instruction {Id = 3}
            };

            var mockRepo = new Mock<IRecipeRepository>();
            mockRepo.Setup(m => m.RemoveRange(instructions))
                .Returns(
                    true
                );
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Recipes).Returns(mockRepo.Object);

            RecipeService service = new RecipeService(mockUnitOfWork.Object);

            // Act
            var actual = service.RemoveRange(instructions);

            // Assert
            Assert.IsTrue(actual);
        }
 
    }
}
