using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Domain.EntityTypeConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(nameof(Comment));

            builder.HasKey(x => new { x.UserId, x.TrackId });

            builder.Property(comment => comment.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder
                .HasOne<User>(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            builder
                .HasOne<Track>(c => c.Track)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TrackId);
        }
    }
}
