using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var playlistDto = await _context.Playlists
                .Where(p => p.PlaylistId == request.playlist.PlaylistId && p.BarId == request.playlist.BarId)  
                .Include(p => p.PlaylistSongs)
                    .ThenInclude(ps => ps.Song)
                .Select(p => new PlaylistDto
                {
                    PlaylistId = p.PlaylistId,
                    Name = p.Name,
                    PlayedSongId = p.PlayedSongId,
                    TotalSong = p.TotalSong,
                    PlaylistSongs = p.PlaylistSongs.Select(ps => new SongPlaylist
                    {
                        PlaylistId = ps.PlaylistId,
                        Playlist = ps.Playlist,  
                        SongId = ps.SongId,
                        Song = new Song
                        {
                            SongId = ps.Song.SongId,
                            Title = ps.Song.Title,
                            Cover = ps.Song.Cover,
                            Author = ps.Song.Author,
                            AlbumTitle = ps.Song.AlbumTitle,
                            Preview = ps.Song.Preview,
                            Style = ps.Song.Style,
                            Link = ps.Song.Link,
                            Duration = ps.Song.Duration,
                            StatusPromoted = ps.Song.StatusPromoted
                        },
                        PlaylistOrder = ps.PlaylistOrder
                    }).ToList(),
                    BarId = p.BarId
                })
                .FirstOrDefaultAsync();

            return playlistDto;
        }
    }
}
