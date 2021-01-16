using iKnow.BLL.Interfaces;
using iKnow.BLL.Models;
using iKnow.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace iKnow.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var mock = new Mock<IUserService>();
            mock.Setup(s => s.GetAllUsers()).Returns(GetTestUsers());
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserModel>>(result);
            Assert.Equal(5, 8);

        }

        private IList<UserModel> GetTestUsers()
        {
            IList<UserModel> users = new List<UserModel>
            {
                new UserModel { Login = "1",Password="1",Email="1@mail.com",RoleId = 1,Checked = true},
                new UserModel { Login = "2",Password="2",Email="2@mail.com",RoleId = 1,Checked = true},
                new UserModel { Login = "3",Password="3",Email="3@mail.com",RoleId = 1,Checked = true},
                new UserModel { Login = "4",Password="4",Email="4@mail.com",RoleId = 1,Checked = true},
                new UserModel { Login = "5",Password="5",Email="5@mail.com",RoleId = 1,Checked = true},
            };
            return users;
        }
    }
}
