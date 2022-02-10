namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UploadedFileConfiguration : BaseEntityConfiguration<UploadedFile>
    {
        public override void Configure(EntityTypeBuilder<UploadedFile> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(UploadedFile) + 's');
            builder.Property(file => file.FileName).HasMaxLength(150).IsRequired();
            builder.Property(file => file.FileSize).IsRequired();
            builder.Property(file => file.UploadedDate).IsRequired();
            builder.HasOne(file => file.User)
                .WithMany(user => user.UploadedFiles)
                .HasForeignKey(file => file.UploadedBy)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
