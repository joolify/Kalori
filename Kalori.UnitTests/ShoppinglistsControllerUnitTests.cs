using System;
using System.Web.Mvc;
using Kalori.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Kalori.UnitTests
{
    [TestFixture]
    public class ShoppinglistsControllerUnitTests
    {
        [Test]
        public void Index_Returns_ActionResult()
        {
            //Arrange
            ShoppinglistsController controller = new ShoppinglistsController(); ;

            //Act
            var actual = controller.Index();

            //Assert
        Assert.IsInstanceOfType(actual, typeof(ActionResult));
        }
    }
}
