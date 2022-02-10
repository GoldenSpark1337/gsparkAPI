using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Domain.EntityTypeConfigurations
{
    public class GenreConfiguration : BaseEntityConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Genre));

            
        }
    }
}
