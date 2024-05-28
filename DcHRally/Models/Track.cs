namespace DcHRally.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public required int CategoryId { get; set; }
        public string? Name { get; set; }
        public virtual required string UserId { get; set; }
        public required string TrackData { get; set; }
    }
}
