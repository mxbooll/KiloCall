using KiloCall.Core.Model;
using NUnit.Framework;
using System;
using System.Linq;

namespace KiloCall.Core.Controller.Tests
{
    [TestFixture]
    public class EatingControllerTests
    {
        [Test]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.Add(food, 100);

            // Assert
            //Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.Keys.Single(x => x.Name == food.Name).ToString());
        }
    }
}