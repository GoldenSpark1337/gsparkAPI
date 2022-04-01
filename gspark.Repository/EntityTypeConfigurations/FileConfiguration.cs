namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UploadedFileConfiguration : BaseEntityConfiguration<File>
    {
        public override void Configure(EntityTypeBuilder<File> builder)
        {
            base.Configure(builder);
            builder.Property(file => file.CreatedAt).IsRequired();

            builder
                .HasOne(file => file.User)
                .WithMany(user => user.Files)
                .HasForeignKey(file => file.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
