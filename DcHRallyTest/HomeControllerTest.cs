using DcHRally.Areas.Identity.Data;
using DcHRally.Controllers;
using DcHRally.Models;
using DcHRally.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace DcHRallyTest
{
    public class HomeControllerTest
    {
        private readonly Mock<ILogger<HomeController>> _mockLogger;
        private readonly Mock<UserManager<ApplicationUser>> _userManager;
        private readonly HomeController _controller;
        private readonly RallyDbContext _context;

        private RallyDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RallyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new RallyDbContext(options);
            SeedData(context);
            return context;
        }

        private void SeedData(RallyDbContext context)
        {
            context.ObstacleElements.RemoveRange(context.ObstacleElements);
            context.SaveChanges();

            var obstacleElements = new List<ObstacleElement>
            {
                new ObstacleElement { ObstacleElementId = 1, Name = "Bom" },
                new ObstacleElement { ObstacleElementId = 2, Name = "H" },
                new ObstacleElement { ObstacleElementId = 3, Name = "Kegle" },
                new ObstacleElement { ObstacleElementId = 4, Name = "Spand" },
                new ObstacleElement { ObstacleElementId = 5, Name = "Tunnel" }
            };

            context.ObstacleElements.AddRange(obstacleElements);
            context.SaveChanges();
        }

        public HomeControllerTest()
        {
            _context = GetDbContext();
            _mockLogger = new Mock<ILogger<HomeController>>();

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManager = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            _controller = new HomeController(_mockLogger.Object, _context, _userManager.Object);
        }

        [Fact]
        public async Task IndexNotLoggedIn_ReturnsViewResult()
        {
            // Arrange
            var httpContextMock = new Mock<HttpContext>();
            var claimsPrincipalMock = new Mock<ClaimsPrincipal>();
            claimsPrincipalMock.Setup(cp => cp.Identity.IsAuthenticated).Returns(false);
            httpContextMock.Setup(ctx => ctx.User).Returns(claimsPrincipalMock.Object);
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContextMock.Object
            };

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("IndexNotLoggedIn", viewResult.ViewName);
        }

        [Fact]
        public async Task IndexLoggedIn_ReturnsViewResult()
        {
            // Arrange
            var httpContextMock = new Mock<HttpContext>();
            var claimsPrincipalMock = new Mock<ClaimsPrincipal>();
            claimsPrincipalMock.Setup(cp => cp.Identity.IsAuthenticated).Returns(true);
            claimsPrincipalMock.Setup(cp => cp.FindFirst(It.IsAny<string>()))
                .Returns(new Claim(ClaimTypes.NameIdentifier, "testUserId"));
            httpContextMock.Setup(ctx => ctx.User).Returns(claimsPrincipalMock.Object);
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContextMock.Object
            };

            var testUser = new ApplicationUser { Id = "testUserId", UserName = "testUser" };
            _userManager.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(testUser);
            _context.Tracks.AddRange(new List<Track>
            {
                new Track { TrackId = 1, UserId = "testUserId", Name = "Track1", CategoryId = 1, TrackData = "Data1" },
                new Track { TrackId = 2, UserId = "testUserId", Name = "Track2", CategoryId = 2, TrackData = "Data2" }
            });
            _context.SaveChanges();

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("IndexLoggedIn", viewResult.ViewName);

            var model = Assert.IsType<TrackViewModel>(viewResult.Model);
            Assert.Equal(2, model.Tracks.Count());
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Act
            var result = _controller.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_ReturnsViewResult_WithErrorViewModel()
        {
            // Arrange
            var expectedRequestId = "testRequestId";

            var httpContext = new DefaultHttpContext();
            httpContext.TraceIdentifier = expectedRequestId;
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            // Act
            var result = _controller.Error();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.ViewData.Model);
            Assert.Equal(expectedRequestId, model.RequestId);
        }
    }
}
