
using Microsoft.EntityFrameworkCore;

namespace DcHRally.Models
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