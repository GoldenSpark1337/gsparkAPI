using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Domain.EntityTypeConfigurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(product => product.Title).HasMaxLength(100).IsRequired();
            builder.Property(product => product.Description).HasMaxLength(500).IsRequired(false);

            builder
                .HasOne(product => product.User)
                .WithMany(user => user.Products)
                .HasForeignKey(product => product.UserId);
        }
    }
}
