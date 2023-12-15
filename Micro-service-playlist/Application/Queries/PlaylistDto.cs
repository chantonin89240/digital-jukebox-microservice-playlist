using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class PlaylistDto
    {
        public int PlaylistId { get; set; }
        public string? Name { get; set; }
        public int PlayedSongId { get; set; }
        public int TotalSong { get; set; }
        public List<SongPlaylist>? PlaylistSongs { get; set; }
        public int BarId { get; set; }
    }
}
