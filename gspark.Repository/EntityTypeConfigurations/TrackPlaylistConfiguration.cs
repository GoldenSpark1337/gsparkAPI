namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrackPlaylistConfiguration : IEntityTypeConfiguration<TrackPlaylist>
    {
        public void Configure(EntityTypeBuilder<TrackPlaylist> builder)
        {
            builder.HasKey(x => new { x.PlaylistId, x.TrackId });
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);

            builder
                .HasOne<Playlist>(tp => tp.Playlist)
                .WithMany(p => p.TrackPlaylists)
                .HasForeignKey(tp => tp.PlaylistId);
            builder
                .HasOne<Track>(tp => tp.Track)
                .WithMany(p => p.TrackPlaylists)
                .HasForeignKey(tp => tp.TrackId);
        }
    }
}
