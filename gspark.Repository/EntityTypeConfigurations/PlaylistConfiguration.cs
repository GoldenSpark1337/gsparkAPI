﻿using gspark.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gspark.Domain.EntityTypeConfigurations
{
    public class PlaylistConfiguration : BaseEntityConfiguration<Playlist>
    {
        public override void Configure(EntityTypeBuilder<Playlist> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Playlist));

            builder.Property(playlist => playlist.Name).IsRequired().HasMaxLength(100);
            builder.Property(playlist => playlist.Artwork).IsRequired();
            builder.Property(playlist => playlist.Description).IsRequired().HasColumnType("varchar(MAX)");
            builder
                .HasOne(playlist => playlist.User)
                .WithMany(user => user.Playlists)
                .HasForeignKey(playlist => playlist.UserId);
        }
    }
}
