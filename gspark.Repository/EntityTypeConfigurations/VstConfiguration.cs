using gspark.Domain.EntityTypeConfigurations;
using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Repository.EntityTypeConfigurations
{
    public class VstConfiguration : BaseEntityConfiguration<Vst>
    {
        public override void Configure(EntityTypeBuilder<Vst> builder)
        {
            base.Configure(builder);
        }
    }
}
