using Domain.Entities;

namespace infrastructure.Data
{
    public class PlaylistDbContext : DbContext
    {
        public DbSet<Playlist>? Playlists { get; set; }
        public DbSet<SongHistory>? SongHistorys { get; set; }
        public DbSet<SongPlaylist>? SongPlaylists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public PlaylistDbContext(DbContextOptions<PlaylistDbContext> options) : base(options) { }

        public PlaylistDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }

    }

}

