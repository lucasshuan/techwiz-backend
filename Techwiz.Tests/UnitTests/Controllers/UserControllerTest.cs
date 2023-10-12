using Moq;
using Microsoft.AspNetCore.Mvc;
using Techwiz.Controllers;
using Techwiz.Services;
using Techwiz.Models;

namespace Techwiz.Tests.ControllerTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUser_ReturnsOkResult_WhenUserExists()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(repo => repo.GetUserByIdAsync(It.IsAny<uint>())).ReturnsAsync(new User());

            var controller = new UserController(userServiceMock.Object);

            var result = await controller.GetUser(1);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}