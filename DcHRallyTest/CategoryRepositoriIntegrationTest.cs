
using DcHRally.Models;
using Microsoft.EntityFrameworkCore;

namespace DcHRallyTest
{
    public class CategoryRepositoriIntegrationTest
    {
        private RallyDbContext GetDbContext() // Method to create and configure an in-memory database context
        {
            var options = new DbContextOptionsBuilder<RallyDbContext>() // Configures the DbContext options
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Specifies an in-memory database for testing
                .Options;

            var context = new RallyDbContext(options); // Creates a new database context with the specified options

            // Clear existing data and ensure database creation
            context.Database.EnsureDeleted(); // Ensures the in-memory database is deleted
            context.Database.EnsureCreated(); // Ensures the in-memory database is created

            // Seed Categories
            context.Categories.AddRange(TestData.GetCategories()); // Adds initial categories to the database
            context.SaveChanges(); // Saves changes to the database

            return context; // Returns the configured database context
        }

        [Fact] // Indicates that this method is a test method
        public void GetAllCategories_ReturnsAllCategories() // Test method to check if all categories are returned
        {
            // Arrange
            using var context = GetDbContext(); // Creates a new database context
            var repository = new CategoryRepository(context); // Creates a new repository with the context

            // Act
            var categories = repository.AllCategories.ToList(); // Retrieves all categories from the repository

            // Assert
            Assert.Equal(5, categories.Count); // Ensures there are 5 categories
            Assert.Contains(categories, c => c.Name == "Diverse"); // Checks if the "Diverse" category is in the list
            Assert.Contains(categories, c => c.Name == "Begynder"); // Checks if the "Begynder" category is in the list
            Assert.Contains(categories, c => c.Name == "Øvet"); // Checks if the "Øvet" category is in the list
            Assert.Contains(categories, c => c.Name == "Ekspert"); // Checks if the "Ekspert" category is in the list
            Assert.Contains(categories, c => c.Name == "Champion"); // Checks if the "Champion" category is in the list
        }
    }
}