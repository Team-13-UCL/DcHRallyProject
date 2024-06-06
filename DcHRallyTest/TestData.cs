
using DcHRally.Models;

namespace DcHRallyTest
{
    public static class TestData // Static class to provide test data for integration tests
    {
        // Returns a list of Category objects for testing
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { CategoryId = 1, Name = "Diverse" },
                new Category { CategoryId = 2, Name = "Begynder" },
                new Category { CategoryId = 3, Name = "Øvet" },
                new Category { CategoryId = 4, Name = "Ekspert" },
                new Category { CategoryId = 5, Name = "Champion" }
            };
        }

        // Returns a list of Obstacle objects for testing
        public static List<Obstacle> GetObstacles()
        {
            return new List<Obstacle>
            {
                new Obstacle
                {
                    ObstacleId = 1,
                    Name = "Start",
                    Description = "Her starter banen! Hunden behøver ikke at sidde inden start, og skal være i venstrepositionen - kan være i højreposition i Ekpert- og Championklassen. Tidtagningen starter på dommerens kommando f.eks. ”Fremad”.",
                    CategoryId = 1,
                    SignUrl = "1.png"
                },
                new Obstacle
                {
                    ObstacleId = 2,
                    Name = "Mål",
                    Description = "Banen er slut. Tidtagningen stoppes, når teamet passerer skiltet. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.",
                    CategoryId = 1,
                    SignUrl = "2.png"
                },
                new Obstacle
                {
                    ObstacleId = 3,
                    Name = "Højre sving",
                    Description = "Teamet drejer 90° skarpt til højre. Drejningen udføres med en lille bue og foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.",
                    CategoryId = 2,
                    SignUrl = "3.png"
                },
                new Obstacle
                {
                    ObstacleId = 4,
                    Name = "Venstre sving",
                    Description = "Teamet drejer 90° skarpt til venstre. Drejningen udføres med en lille bue og foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.",
                    CategoryId = 2,
                    SignUrl = "4.png"
                },
                new Obstacle
                {
                    ObstacleId = 5,
                    Name = "270º Højre rundt",
                    Description = "Teamet drejer 270° højre rundt til førerens højre side. Drejningen udføres med en lille bue foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.",
                    CategoryId = 2,
                    SignUrl = "5.png"
                }
            };
        }

        // Returns a list of ObstacleElement objects for testing
        public static List<ObstacleElement> GetObstacleElements()
        {
            return new List<ObstacleElement>
            {
                new ObstacleElement { ObstacleElementId = 1, Name = "Bom" },
                new ObstacleElement { ObstacleElementId = 2, Name = "H" },
                new ObstacleElement { ObstacleElementId = 3, Name = "Kegle" },
                new ObstacleElement { ObstacleElementId = 4, Name = "Spand" },
                new ObstacleElement { ObstacleElementId = 5, Name = "Tunnel" }
            };
        }
    }
}