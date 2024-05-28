namespace DcHRally.Models
{
    public interface ITrackRepository
    {
        IEnumerable<Track> AllTracks { get; }
        Track? GetTrackById(int trackId);
    }
}
