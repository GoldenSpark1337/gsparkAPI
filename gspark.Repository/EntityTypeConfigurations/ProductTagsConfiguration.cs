using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Repository.EntityTypeConfigurations;

public class ProductTagsConfiguration : IEntityTypeConfiguration<ProductTags>
{
    public void Configure(EntityTypeBuilder<ProductTags> builder)
    {
        builder.HasKey(pt => new {pt.ProductId, pt.TagId});
        builder
            .HasOne(pt => pt.Product)
            .WithMany(p => p.ProductTags)
            .HasForeignKey(pt => pt.ProductId);
        builder
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.ProductTags)
            .HasForeignKey(pt => pt.TagId);
    }
}