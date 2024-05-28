using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyBaneTest.Models
{
    public class Obstacle
    {
        public int ObstacleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? SignUrl { get; set; }   
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}