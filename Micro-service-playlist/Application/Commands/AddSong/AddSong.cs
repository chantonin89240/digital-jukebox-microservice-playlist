using Application.Commands.AddPlaylist;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.AddSong;

public record class AddSongCommand : IRequest<int>
{
    public int IdPlaylist { get; set; }
    public string? Title { get; set; }
    public string? Cover { get; set; }
    public string? Author { get; set; }
    public string? AlbumTitle { get; set; }
    public string? Preview { get; set; }
    public string? Link { get; set; }
    public int Duration { get; set; }
    public string? Style { get; set; }
}

public class AddSongCommandHandler : IRequestHandler<AddSongCommand, int>
{
    private readonly PlaylistDbContext _context;

    public AddSongCommandHandler(PlaylistDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddSongCommand request, CancellationToken cancellationToken)
    {
        var song = new Song
        {
            Title = request.Title,
            Cover = request.Cover,
            Author = request.Author,
            AlbumTitle = request.AlbumTitle,
            Preview = request.Preview,
            Link = request.Link,
            Duration = request.Duration,
            Style = request.Style
        };

        _context.Songs.Add(song);
        await _context.SaveChangesAsync(cancellationToken);

        int orderValue;
        var order = _context.SongPlaylists.Where(e => e.PlaylistId == request.IdPlaylist);
        if (order.Count() == 0)
        {
            orderValue = 1;
        }
        else
        {
            orderValue = order.Max(e => e.PlaylistOrder) + 1;
        }

        var songPlaylist = new SongPlaylist
        {
            PlaylistId = request.IdPlaylist,
            SongId = song.SongId,
            PlaylistOrder = orderValue
        };

        _context.SongPlaylists.Add(songPlaylist);
        await _context.SaveChangesAsync(cancellationToken);

        return song.SongId;
    }
}
