﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using gspark.Repository;

#nullable disable

namespace gspark.Repository.Migrations
{
    [DbContext(typeof(MarketPlaceContext))]
    [Migration("20220218160111_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("gspark.Domain.Models.Comment", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer")
                        .HasColumnName("track_id");

                    b.Property<string>("CommentDetail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment_detail");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.HasKey("UserId", "TrackId")
                        .HasName("pk_comments");

                    b.HasIndex("TrackId")
                        .HasDatabaseName("ix_comments_track_id");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_genres");

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Key", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Track_Key")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("track_key");

                    b.HasKey("Id")
                        .HasName("pk_keys");

                    b.HasIndex("Track_Key")
                        .IsUnique()
                        .HasDatabaseName("ix_keys_track_key");

                    b.ToTable("keys", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Kit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Artwork")
                        .HasColumnType("bytea")
                        .HasColumnName("artwork");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_kits");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_kits_user_id");

                    b.ToTable("kits", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Artwork")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("artwork");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_playlists");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_playlists_user_id");

                    b.ToTable("playlists", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.RecordLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 2, 18, 16, 1, 11, 624, DateTimeKind.Utc).AddTicks(1748))
                        .HasColumnName("created_at");

                    b.Property<string>("Founder")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("founder");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_record_labels");

                    b.ToTable("record_labels", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Artwork")
                        .HasColumnType("bytea")
                        .HasColumnName("artwork");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_services");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_services_user_id");

                    b.ToTable("services", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Subgenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_subgenres");

                    b.HasIndex("GenreId")
                        .HasDatabaseName("ix_subgenres_genre_id");

                    b.ToTable("subgenres", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tag_name");

                    b.HasKey("Id")
                        .HasName("pk_tags");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Artwork")
                        .HasColumnType("bytea")
                        .HasColumnName("artwork");

                    b.Property<string>("Bpm")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("bpm");

                    b.Property<string>("Collaborator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("collaborator");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<int>("Likes")
                        .HasColumnType("integer")
                        .HasColumnName("likes");

                    b.Property<int>("Plays")
                        .HasColumnType("integer")
                        .HasColumnName("plays");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("release_date");

                    b.Property<string>("SubGenre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("sub_genre");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("title");

                    b.Property<int>("TrackKey_Id")
                        .HasColumnType("integer")
                        .HasColumnName("track_key_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_tracks");

                    b.HasIndex("GenreId")
                        .HasDatabaseName("ix_tracks_genre_id");

                    b.HasIndex("TrackKey_Id")
                        .IsUnique()
                        .HasDatabaseName("ix_tracks_track_key_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_tracks_user_id");

                    b.ToTable("tracks", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.TrackPlaylist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("integer")
                        .HasColumnName("playlist_id");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer")
                        .HasColumnName("track_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 2, 18, 16, 1, 11, 625, DateTimeKind.Utc).AddTicks(5537))
                        .HasColumnName("created_at");

                    b.HasKey("PlaylistId", "TrackId")
                        .HasName("pk_track_playlist");

                    b.HasIndex("TrackId")
                        .HasDatabaseName("ix_track_playlist_track_id");

                    b.ToTable("track_playlist", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.UploadedFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("file_name");

                    b.Property<double>("FileSize")
                        .HasColumnType("double precision")
                        .HasColumnName("file_size");

                    b.Property<int>("UploadedBy")
                        .HasColumnType("integer")
                        .HasColumnName("uploaded_by");

                    b.Property<DateTime>("UploadedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("uploaded_date");

                    b.HasKey("Id")
                        .HasName("pk_uploaded_files");

                    b.HasIndex("UploadedBy")
                        .HasDatabaseName("ix_uploaded_files_uploaded_by");

                    b.ToTable("uploaded_files", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("biography");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea")
                        .HasColumnName("image");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int?>("RecordLabelId")
                        .HasColumnType("integer")
                        .HasColumnName("record_label_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("RecordLabelId")
                        .HasDatabaseName("ix_users_record_label_id");

                    b.HasIndex("Id", "Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_id_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Vst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Artwork")
                        .HasColumnType("bytea")
                        .HasColumnName("artwork");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("publisher");

                    b.Property<DateTime>("Release")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("release");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_vsts");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_vsts_user_id");

                    b.ToTable("vsts", (string)null);
                });

            modelBuilder.Entity("gspark.Domain.Models.Comment", b =>
                {
                    b.HasOne("gspark.Domain.Models.Track", "Track")
                        .WithMany("Comments")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_tracks_track_id");

                    b.HasOne("gspark.Domain.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_users_user_id");

                    b.Navigation("Track");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gspark.Domain.Models.Kit", b =>
                {
                    b.HasOne("gspark.Domain.Models.User", "User")
                        .WithMany("Kits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_kits_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gspark.Domain.Models.Playlist", b =>
                {
                    b.HasOne("gspark.Domain.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_playlists_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gspark.Domain.Models.Service", b =>
                {
                    b.HasOne("gspark.Domain.Models.User", "User")
                        .WithMany("Services")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_services_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gspark.Domain.Models.Subgenre", b =>
                {
                    b.HasOne("gspark.Domain.Models.Genre", "Genre")
                        .WithMany("Subgenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_subgenres_genres_genre_id");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("gspark.Domain.Models.Track", b =>
                {
                    b.HasOne("gspark.Domain.Models.Genre", "Genre")
                        .WithMany("Tracks")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tracks_genres_genre_id");

                    b.HasOne("gspark.Domain.Models.Key", "Key")
                        .WithOne("Track")
                        .HasForeignKey("gspark.Domain.Models.Track", "TrackKey_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tracks_keys_track_key_id");

                    b.HasOne("gspark.Domain.Models.User", "User")
                        .WithMany("Tracks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_tracks_users_user_id");

                    b.Navigation("Genre");

                    b.Navigation("Key");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gspark.Domain.Models.TrackPlaylist", b =>
                {
                    b.HasOne("gspark.Domain.Models.Playlist", "Playlist")
                        .WithMany("TrackPlaylists")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_track_playlist_playlists_playlist_id");

                    b.HasOne("gspark.Domain.Models.Track", "Track")
                        .WithMany("TrackPlaylists")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_track_playlist_tracks_track_id");

                    b.Navigation("Playlist");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("gspark.Domain.Models.UploadedFile", b =>
                {
                    b.HasOne("gspark.Domain.Models.User", "User")
                        .WithMany("UploadedFiles")
                        .HasForeignKey("UploadedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_uploaded_files_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gspark.Domain.Models.User", b =>
                {
                    b.HasOne("gspark.Domain.Models.RecordLabel", "RecordLabel")
                        .WithMany("Users")
                        .HasForeignKey("RecordLabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_users_record_labels_record_label_id");

                    b.Navigation("RecordLabel");
                });

            modelBuilder.Entity("gspark.Domain.Models.Vst", b =>
                {
                    b.HasOne("gspark.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vsts_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gspark.Domain.Models.Genre", b =>
                {
                    b.Navigation("Subgenres");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("gspark.Domain.Models.Key", b =>
                {
                    b.Navigation("Track")
                        .IsRequired();
                });

            modelBuilder.Entity("gspark.Domain.Models.Playlist", b =>
                {
                    b.Navigation("TrackPlaylists");
                });

            modelBuilder.Entity("gspark.Domain.Models.RecordLabel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("gspark.Domain.Models.Track", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TrackPlaylists");
                });

            modelBuilder.Entity("gspark.Domain.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Kits");

                    b.Navigation("Playlists");

                    b.Navigation("Services");

                    b.Navigation("Tracks");

                    b.Navigation("UploadedFiles");
                });
#pragma warning restore 612, 618
        }
    }
}