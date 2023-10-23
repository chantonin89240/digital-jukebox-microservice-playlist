using Domain.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PlaylistDbContext : DbContext
    {
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<SongHistory> SongHistorys => Set<SongHistory>();
        public DbSet<SongPlaylist> SongPlaylists => Set<SongPlaylist>();
        public DbSet<Song> Songs => Set<Song>();

        public PlaylistDbContext(DbContextOptions<PlaylistDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

