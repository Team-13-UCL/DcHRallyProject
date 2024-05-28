namespace DcHRally.Models
{
    public interface IObstacleElementRepository
    {
        IEnumerable<ObstacleElement> AllObstacleElements { get; }
        ObstacleElement? GetObstacleElementById(int obstacleElementId);
    }
}
