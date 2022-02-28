namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrackConfiguration : BaseEntityConfiguration<Track>
    {
        public override void Configure(EntityTypeBuilder<Track> builder)
        {

            builder.HasKey(x => x.Id);
            // builder.Property(track => track.Title).HasMaxLength(250).IsRequired();
            builder.Property(track => track.Bpm).HasMaxLength(4).IsRequired();
            builder.Property(track => track.SubGenreId).IsRequired(false);
            // builder.Property(track => track.ReleaseDate).IsRequired();
            // builder
            //     .HasOne(track => track.User)
            //     .WithMany(user => user.Tracks)
            //      .HasForeignKey(track => track.UserId)
            //     .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(track => track.Genre)
                .WithMany(genre => genre.Tracks)
                .HasForeignKey(track => track.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(track => track.Key)
                .WithMany(key => key.Tracks)
                .HasForeignKey(track => track.TrackKey_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
