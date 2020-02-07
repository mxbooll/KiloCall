using KiloCall.Core.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using KiloCall.Core.Model;
using System.Linq;

namespace KiloCall.Core.Controller.Tests
{
    [TestFixture]
    public class ExerciseControllerTests
    {
        [Test]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            //Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
            Assert.AreEqual(activity.Name, exerciseController.Activities.Find(x => x.Name == activity.Name).Name);
        }
    }
}