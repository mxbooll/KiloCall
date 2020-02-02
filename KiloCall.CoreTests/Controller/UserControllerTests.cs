using NUnit.Framework;
using System;

namespace KiloCall.Core.Controller.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        [Test]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthDate = DateTime.Now.AddYears(- 18);
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);
            
            // Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controllerAfterSaving = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controllerAfterSaving.CurrentUser.Name);
            Assert.AreEqual(gender, controllerAfterSaving.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controllerAfterSaving.CurrentUser.BirthDay);
            Assert.AreEqual(weight, controllerAfterSaving.CurrentUser.Weight);
            Assert.AreEqual(height, controllerAfterSaving.CurrentUser.Height);
        }

        [Test]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}