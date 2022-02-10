namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KitConfiguration : BaseEntityConfiguration<Kit>
    {
        public override void Configure(EntityTypeBuilder<Kit> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Kit));

            builder.Property(kit => kit.Title).HasMaxLength(100).IsRequired();
            builder
                .HasOne(kit => kit.User)
                .WithMany(user => user.Kits)
                .HasForeignKey(key => key.UserId);
        }
    }
}
