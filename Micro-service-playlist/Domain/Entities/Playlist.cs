using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string? Name { get; set; }
        public int PlayedSongId { get; set; }
        public int TotalSong { get; set; }
        public List<SongPlaylist>? PlaylistSongs { get; set; }
    }
}
