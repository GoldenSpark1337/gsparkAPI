namespace gspark.Domain.EntityTypeConfigurations
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfigurations : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(User) + 's');

            
            builder.HasIndex(user => new { user.Id, user.Email }).IsUnique();
            builder.Property(user => user.Username).HasMaxLength(100).IsRequired();
            builder.Property(user => user.Email).HasMaxLength(150).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.FirstName).HasMaxLength(100);
            builder
                .HasOne(user => user.RecordLabel)
                .WithMany(recordLabel => recordLabel.Users)
                .HasForeignKey(user => user.RecordLabelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
