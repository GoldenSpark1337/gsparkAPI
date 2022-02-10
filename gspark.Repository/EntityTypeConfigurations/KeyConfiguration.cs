namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KeyConfiguration : BaseEntityConfiguration<Key>
    {
        public override void Configure(EntityTypeBuilder<Key> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Key));
            builder.Property(key => key.TrackKey).IsRequired().HasMaxLength(3);
        }
    }
}
