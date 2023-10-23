using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class SongPlaylistConfiguration : IEntityTypeConfiguration<SongPlaylist>
{
    public void Configure(EntityTypeBuilder<SongPlaylist> builder)
    {
        builder.HasKey(ps => new { ps.PlaylistId, ps.SongId });

        builder
            .HasOne(ps => ps.Playlist)
            .WithMany(p => p.PlaylistSongs)
            .HasForeignKey(ps => ps.PlaylistId);

        builder
            .HasOne(ps => ps.Song)
            .WithMany(s => s.PlaylistSongs)
            .HasForeignKey(ps => ps.SongId);

        //builder.OwnsOne(ps => ps.Song)
    }
}
