using gspark.Domain.EntityTypeConfigurations;
using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Repository.EntityTypeConfigurations
{
    public class SubgenreConfiguration : BaseEntityConfiguration<Subgenre>
    {
        public override void Configure(EntityTypeBuilder<Subgenre> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(subgenre => subgenre.Genre)
                .WithMany(genre => genre.Subgenres)
                .HasForeignKey(subgenre => subgenre.GenreId);
        }
    }
}
