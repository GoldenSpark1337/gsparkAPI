namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RecordLabelConfiguration : BaseEntityConfiguration<RecordLabel>
    {
        public override void Configure(EntityTypeBuilder<RecordLabel> builder)
        {
            base.Configure(builder);
            builder.ToTable("RecordLabel");

            builder.Property(label => label.Name).HasMaxLength(128).IsRequired();
            builder.Property(label => label.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(label => label.Founder).IsRequired().HasMaxLength(50);
        }
    }
}
