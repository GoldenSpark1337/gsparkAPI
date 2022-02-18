namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KeyConfiguration : BaseEntityConfiguration<Key>
    {
        public override void Configure(EntityTypeBuilder<Key> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(key => key.Track_Key).IsUnique();
            builder.Property(key => key.Track_Key).HasMaxLength(3);
        }
    }
}
