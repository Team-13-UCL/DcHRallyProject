using DcHRally.Models;
using RallyBaneTest.Models;

namespace RallyBaneTest.ViewModels
{
    public class ObstacleViewModel
    {
        public IEnumerable<Obstacle> Obstacles { get; }
        public IEnumerable<ObstacleElement> ObstacleElements { get; }
        public string? CurrentCategory { get; }
        public Track? LoadedTrack { get; }

        public ObstacleViewModel(IEnumerable<Obstacle> obstacles, string? currentCategory, IEnumerable<ObstacleElement> obstacleElements, Track? track = null)
        {
            Obstacles = obstacles;
            CurrentCategory = currentCategory;
            ObstacleElements = obstacleElements;
            LoadedTrack = track;
        }
    }
}