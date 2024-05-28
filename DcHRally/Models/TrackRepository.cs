using Microsoft.EntityFrameworkCore;
using RallyBaneTest.Models;

namespace DcHRally.Models
{
    public class TrackRepository : ITrackRepository
    {
        private readonly RallyDbContext _dbContext;
        public TrackRepository(RallyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Track> AllTracks
        {
            get
            {
                return _dbContext.Tracks.Include(t => t.UserId);
            }
        }

        public Track? GetTrackById(int trackId)
        {
            return _dbContext.Tracks.FirstOrDefault(t => t.TrackId == trackId);
        }
    }
}
