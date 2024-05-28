using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DcHRally.Models
{
    public interface IObstacleRepository
    {
        IEnumerable<Obstacle> AllObstacles { get; }
        Obstacle? GetObstacleById(int obstacleId);
    }
}