using DcHRally.Models;
using RallyBaneTest.Models;

namespace RallyBaneTest.ViewModels
{
    public class TrackViewModel
    {


        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Track>? Tracks { get; }
        public Track? Track { get; set; }

        public TrackViewModel(IEnumerable<Category>? categories, IEnumerable<Track>? tracks, Track? track)
        {
            Categories = categories;
            Tracks = tracks;
            if (track != null)
            {
                Track = track;
            }
        }
    }
}
