using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Repository.EntityTypeConfigurations;

public class UserProductLikesConfiguration : IEntityTypeConfiguration<UserProductLike>
{
    public void Configure(EntityTypeBuilder<UserProductLike> builder)
    {
        builder.HasKey(x => new {x.UserId, x.ProductId});
        builder
            .HasOne(up => up.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(up => up.Product)
            .WithMany(p => p.Likes)
            .HasForeignKey(up => up.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}