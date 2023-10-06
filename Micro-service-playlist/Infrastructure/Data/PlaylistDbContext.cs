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
            modelBuilder.Entity<Playlist>()
                .HasKey(sh => sh.PlaylistId);

            modelBuilder.Entity<Song>()
                .HasKey(sh => sh.SongId);

            modelBuilder.Entity<SongHistory>()
                .HasKey(sh => sh.HistoryId);

            modelBuilder.Entity<SongPlaylist>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId });

            modelBuilder.Entity<SongPlaylist>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<SongPlaylist>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }

}

