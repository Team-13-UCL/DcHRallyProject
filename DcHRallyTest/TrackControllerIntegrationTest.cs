using DcHRally.Controllers;
using DcHRally.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DcHRally.ViewModels;
using Moq;
using Microsoft.AspNetCore.Identity;
using DcHRally.Areas.Identity.Data;
using System.Security.Claims;
using Xunit;

namespace DcHRallyTest
{
    public class TrackControllerIntegrationTest
    {
        private readonly DbContextOptions<RallyDbContext> _dbContextOptions;
        private readonly Mock<UserManager<ApplicationUser>> _userManager;

        public TrackControllerIntegrationTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<RallyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestRallyDb")
                .Options;

            using (var context = new RallyDbContext(_dbContextOptions))
            {
                SeedTestData(context);
            }

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManager = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        [Fact]
        public void Index_NoCategory_ReturnsAllObstacles()
        {
            using (var context = new RallyDbContext(_dbContextOptions))
            {
                var obstacleRepo = new ObstacleRepository(context);
                var categoryRepo = new CategoryRepository(context);
                var obstacleElementRepo = new ObstacleElementRepository(context);
                var trackRepository = new TrackRepository(context);

                var controller = new TrackController(obstacleRepo, categoryRepo, obstacleElementRepo,
                         trackRepository, _userManager.Object, context);

                var result = controller.Index(null) as ViewResult;
                var viewModel = result?.Model as ObstacleViewModel;

                Assert.NotNull(result);
                Assert.NotNull(viewModel);
                Assert.Equal("All obstacles", viewModel.CurrentCategory);
                Assert.Equal(TestData.GetObstacles().Count, viewModel.Obstacles.Count());
                Assert.Equal(TestData.GetObstacleElements().Count, viewModel.ObstacleElements.Count());
            }
        }


        private void SeedTestData(RallyDbContext context)
        {
            context.Categories.RemoveRange(context.Categories);
            context.Obstacles.RemoveRange(context.Obstacles);
            context.ObstacleElements.RemoveRange(context.ObstacleElements);
            context.SaveChanges();

            var categories = TestData.GetCategories();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var obstacles = TestData.GetObstacles();
            foreach (var obstacle in obstacles)
            {
                obstacle.Category = context.Categories.Single(c => c.CategoryId == obstacle.CategoryId);
                context.Obstacles.Add(obstacle);
            }
            context.SaveChanges();

            var obstacleElements = TestData.GetObstacleElements();
            context.ObstacleElements.AddRange(obstacleElements);
            context.SaveChanges();
        }
    }
}