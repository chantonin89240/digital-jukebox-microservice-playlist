using MediatR;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.AddTrack
{
    public class AddTrackCommand : IRequest<int>
    {
        public Playlist Playlist { get; }
        public Song Song { get; }

        public AddTrackCommand(Playlist playlist, Song song)
        {
            Playlist = playlist;
            Song = song;
        }

        //public int PlaylistId { get; }
        //public int SongId { get; }

        //public AddTrackCommand(int playlistId, int songId)
        //{
        //    PlaylistId = playlistId;
        //    PlaylistId = songId;
        //}
    }

    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, int>
    {
        private readonly PlaylistDbContext _context;

        public AddTrackCommandHandler(PlaylistDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            var playlist = request.Playlist;
            var song = request.Song;

            var entity = await _context.Playlists.FirstOrDefaultAsync(p => p.PlaylistId == request.Playlist.PlaylistId, cancellationToken);

            if (entity != null)
            {
                var newSong = new SongPlaylist
                {
                    PlaylistId = playlist.PlaylistId,
                    Playlist = playlist,
                    SongId = song.SongId,
                    Song = song,
                    PlaylistOrder = entity.TotalSong
                };

                entity.PlaylistId = request.Playlist.PlaylistId;
                entity.Name = request.Playlist.Name;
                entity.PlayedSongId = request.Playlist.PlayedSongId;
                entity.TotalSong = request.Playlist.TotalSong++;
                entity.PlaylistSongs = request.Playlist.PlaylistSongs;

                entity.PlaylistSongs.Add(newSong);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity.PlaylistId;
        }
    }


}
