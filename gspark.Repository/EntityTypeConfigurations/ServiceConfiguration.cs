namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ServiceConfiguration : BaseEntityConfiguration<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder);
            builder.ToTable("Services");

            builder.Property(service => service.Title).HasMaxLength(250).IsRequired();
            builder.Property(service => service.Description).IsRequired();
            builder.Property(service => service.Price).IsRequired();
            builder.HasOne(service => service.User)
                .WithMany(user => user.Services)
                .HasForeignKey(service => service.UserId);


        }
    }
}
