using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlaylist
{
    public class GetPlaylistDto
    {
        public int PlaylistId { get; set; }
        public int BarId { get; set; }
    }
}
