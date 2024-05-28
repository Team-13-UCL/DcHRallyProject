using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RallyBaneTest.Models
{
    public class ObstacleRepository : IObstacleRepository
    {
        private readonly RallyDbContext _rallyDbContext;
        public ObstacleRepository(RallyDbContext rallyDbContext)
        {
            _rallyDbContext = rallyDbContext;
        }

        public IEnumerable<Obstacle> AllObstacles
        {
            get
            {
                return _rallyDbContext.Obstacles.Include(c => c.Category);
            }
        }

        public Obstacle? GetObstacleById(int obstacleId)
        {
            return _rallyDbContext.Obstacles.FirstOrDefault(o => o.ObstacleId == obstacleId);
        }
    }
}