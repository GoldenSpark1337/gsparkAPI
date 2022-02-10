using gspark.Domain.EntityTypeConfigurations;
using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Repository.EntityTypeConfigurations
{
    public class TagConfiguration : BaseEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Tag) + 's');
        }
    }
}
