using DcHRally.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DcHRallyTest
{
    public class ObstacleElementRepositoryIntegrationTest
    {
        private RallyDbContext GetDbContext() // Method to create and configure an in-memory database context
        {
            var options = new DbContextOptionsBuilder<RallyDbContext>() // Configures the DbContext options
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid()) // Specifies a unique in-memory database for testing
                .Options;

            var context = new RallyDbContext(options); // Creates a new database context with the specified options
            SeedData(context); // Seeds the database with initial data
            return context; // Returns the configured database context
        }

        private void SeedData(RallyDbContext context) // Method to seed the database with initial data
        {
            // Ensure the database is clean before seeding
            context.ObstacleElements.RemoveRange(context.ObstacleElements); // Removes existing obstacle elements from the database
            context.SaveChanges(); // Saves changes to the database
            context.ChangeTracker.Clear(); // Clear change tracker to avoid tracking issues

            // Defines a list of obstacle elements to seed the database
            var obstacleElements = new List<ObstacleElement>
            {
                new ObstacleElement { ObstacleElementId = 1, Name = "Bom" },
                new ObstacleElement { ObstacleElementId = 2, Name = "H" },
                new ObstacleElement { ObstacleElementId = 3, Name = "Kegle" },
                new ObstacleElement { ObstacleElementId = 4, Name = "Spand" },
                new ObstacleElement { ObstacleElementId = 5, Name = "Tunnel" }
            };

            context.ObstacleElements.AddRange(obstacleElements); // Adds the obstacle elements to the database
            context.SaveChanges(); // Saves changes to the database
        }

        [Fact] // Indicates that this method is a test method
        public void GetObstacleElementById_ReturnsObstacleElementWithCorrectId() // Test method to check if an obstacle element is returned by its ID
        {
            // Arrange
            using var context = GetDbContext(); // Creates a new database context
            var repository = new ObstacleElementRepository(context); // Creates a new repository with the context
            var obstacleElementId = 1; // Example obstacle element ID to fetch

            // Act
            var obstacleElement = repository.GetObstacleElementById(obstacleElementId); // Retrieves the obstacle element by its ID

            // Assert
            Assert.NotNull(obstacleElement); // Ensures the obstacle element is found
            Assert.Equal("Bom", obstacleElement!.Name); // Verifies the correct obstacle element is fetched
        }
    }
}
