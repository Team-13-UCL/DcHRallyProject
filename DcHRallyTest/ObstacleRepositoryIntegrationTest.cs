
using DcHRally.Models;
using Microsoft.EntityFrameworkCore;

namespace DcHRallyTest
{
    public class ObstacleRepositoryIntegrationTest
    {
        private RallyDbContext GetDbContext() // Method to create and configure an in-memory database context
        {
            var options = new DbContextOptionsBuilder<RallyDbContext>() // Configures the DbContext options
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Specifies an in-memory database for testing
                .Options;

            var context = new RallyDbContext(options); // Creates a new database context with the specified options
            SeedData(context); // Seeds the database with initial data
            return context; // Returns the configured database context
        }

        private void SeedData(RallyDbContext context) // Method to seed the database with initial data
        {
            // Ensure the database is clean before seeding
            context.Obstacles.RemoveRange(context.Obstacles); // Removes existing obstacles from the database
            context.Categories.RemoveRange(context.Categories); // Removes existing categories from the database
            context.SaveChanges(); // Saves changes to the database

            // Defines a list of categories to seed the database
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Diverse" },
                new Category { CategoryId = 2, Name = "Begynder" },
                new Category { CategoryId = 3, Name = "Øvet" },
                new Category { CategoryId = 4, Name = "Ekspert" },
                new Category { CategoryId = 5, Name = "Champion" }
            };

            // Defines a list of obstacles to seed the database
            var obstacles = new List<Obstacle>
            {
                new Obstacle { ObstacleId = 1, Name = "Start", Description = "Her starter banen! Hunden behøver ikke at sidde inden start, og skal være i venstrepositionen - kan være i højreposition i Ekpert- og Championklassen. Tidtagningen starter på dommerens kommando f.eks. ”Fremad”.", CategoryId = 1 },
                new Obstacle { ObstacleId = 2, Name = "Mål", Description = "Banen er slut. Tidtagningen stoppes, når teamet passerer skiltet. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", CategoryId = 2 },
                new Obstacle { ObstacleId = 3, Name = "Højre sving", Description = "Teamet drejer 90° skarpt til højre. Drejningen udføres med en lille bue og foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", CategoryId = 3 },
                new Obstacle { ObstacleId = 4, Name = "Venstre sving", Description = "Teamet drejer 90° skarpt til venstre. Drejningen udføres med en lille bue og foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", CategoryId = 4 },
                new Obstacle { ObstacleId = 5, Name = "270º Højre rundt", Description = "Teamet drejer 270° højre rundt til førerens højre side. Drejningen udføres med en lille bue foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", CategoryId = 5 }
            };

            context.Categories.AddRange(categories); // Adds the categories to the database
            context.Obstacles.AddRange(obstacles); // Adds the obstacles to the database
            context.SaveChanges(); // Saves changes to the database
        }

        [Fact] // Indicates that this method is a test method
        public void GetAllObstacles_ReturnsAllObstacles() // Test method to check if all obstacles are returned
        {
            // Arrange
            using var context = GetDbContext(); // Creates a new database context
            var repository = new ObstacleRepository(context); // Creates a new repository with the context

            // Act
            var obstacles = repository.AllObstacles.ToList(); // Retrieves all obstacles from the repository

            // Assert
            Assert.Equal(5, obstacles.Count); // Ensures there are 5 obstacles
            Assert.Contains(obstacles, o => o.Name == "Start"); // Checks if the "Start" obstacle is in the list
            Assert.Contains(obstacles, o => o.Name == "Mål"); // Checks if the "Mål" obstacle is in the list
            Assert.Contains(obstacles, o => o.Name == "Højre sving"); // Checks if the "Højre sving" obstacle is in the list
            Assert.Contains(obstacles, o => o.Name == "Venstre sving"); // Checks if the "Venstre sving" obstacle is in the list
            Assert.Contains(obstacles, o => o.Name == "270º Højre rundt"); // Checks if the "270º Højre rundt" obstacle is in the list
        }
    }
}