using DcHRally.Models;
using Microsoft.EntityFrameworkCore;

namespace RallyBaneTest.Models
{
    public class RallyDbContext : DbContext
    {
        public RallyDbContext(DbContextOptions<RallyDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Obstacle> Obstacles { get; set; }
        public DbSet<ObstacleElement> ObstacleElements { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}