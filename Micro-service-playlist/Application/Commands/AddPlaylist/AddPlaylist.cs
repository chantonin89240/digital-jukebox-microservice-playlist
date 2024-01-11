using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddPlaylist;

public record class AddPlaylistCommand : IRequest<int>
{
    public string? Name { get; set; }
    public int BarId { get; set; }
}

public class AddPlaylistCommandHandler : IRequestHandler<AddPlaylistCommand, int>
{
    private readonly PlaylistDbContext _context;

    public AddPlaylistCommandHandler(PlaylistDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddPlaylistCommand request, CancellationToken cancellationToken)
    {
        var entity = new Playlist
        {
            Name = request.Name,
            PlayedSongId = 0,
            TotalSong = 0,
            BarId = request.BarId,
        };

        _context.Playlists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.PlaylistId;
    }
}
