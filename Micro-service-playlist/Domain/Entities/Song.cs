namespace Domain.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string? Title { get; set; }
        public string? Cover { get; set; }
        public string? Author { get; set; }
        public string? AlbumTitle { get; set; }
        public string? Preview { get; set; }
        public string? Style { get; set; }
        public string? StatusPromoted { get; set; }
        public List<SongPlaylist>? PlaylistSongs { get; set; }
    }
}
