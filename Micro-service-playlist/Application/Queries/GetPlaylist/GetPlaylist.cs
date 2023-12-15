using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetPlaylist
{
    public record GetPlaylistQuery(GetPlaylistDto playlist) : IRequest<PlaylistDto> { }

    public class GetTrackByIdHandler : IRequestHandler<GetPlaylistQuery, PlaylistDto>
    {
        private readonly PlaylistDbContext _context;

        public GetTrackByIdHandler(PlaylistDbContext context)
        {
            this._context = context;
        }

        public async Task<PlaylistDto> Handle(GetPlaylistQuery request, CancellationToken cancellationToken)
        {
            Playlist playlist = _context.Playlists.First(p => p.PlaylistId == request.playlist.PlaylistId && p.BarId == request.playlist.BarId);
            var playlistDto = new PlaylistDto() { 
                PlaylistId = playlist.PlaylistId, 
                Name = playlist.Name, 
                PlayedSongId = playlist.PlayedSongId, 
                TotalSong = playlist.TotalSong, 
                PlaylistSongs = playlist.PlaylistSongs, 
                BarId = playlist.BarId
            };

            return playlistDto;
        }
    }
}
