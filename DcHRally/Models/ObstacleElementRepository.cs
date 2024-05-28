

namespace DcHRally.Models
{
    public class ObstacleElementRepository : IObstacleElementRepository
    {
        private readonly RallyDbContext _rallyDbContext;
        public ObstacleElementRepository(RallyDbContext rallyDbContext)
        {
            _rallyDbContext = rallyDbContext;
        }

        public IEnumerable<ObstacleElement> AllObstacleElements
        {
            get
            {
                return _rallyDbContext.ObstacleElements;
            }
        }

        public ObstacleElement? GetObstacleElementById(int obstacleElementId)
        {
            return _rallyDbContext.ObstacleElements.FirstOrDefault(o => o.ObstacleElementId == obstacleElementId);
        }
    }
}
