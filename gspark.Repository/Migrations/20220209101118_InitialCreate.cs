using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gspark.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Key",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TrackKey = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Key_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecordLabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 9, 16, 11, 18, 671, DateTimeKind.Local).AddTicks(5987)),
                    Founder = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordLabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordLabel_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subgenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subgenres_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subgenres_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordLabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_RecordLabel_RecordLabelId",
                        column: x => x.RecordLabelId,
                        principalTable: "RecordLabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Artwork = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kit_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kit_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Artwork = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Playlist_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Artwork = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Artwork = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bpm = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    KeyId = table.Column<int>(type: "int", nullable: false),
                    Collaborator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    SubGenre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Plays = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tracks_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tracks_Key_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Key",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tracks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedFiles_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadedFiles_Users_UploadedBy",
                        column: x => x.UploadedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artwork = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vst_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vst_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    CommentDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => new { x.UserId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_Comment_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackPlaylist",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 9, 16, 11, 18, 672, DateTimeKind.Local).AddTicks(3544))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackPlaylist", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_TrackPlaylist_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackPlaylist_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Id",
                table: "BaseEntity",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TrackId",
                table: "Comment",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Id",
                table: "Genre",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Key_Id",
                table: "Key",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kit_Id",
                table: "Kit",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kit_UserId",
                table: "Kit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_Id",
                table: "Playlist",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UserId",
                table: "Playlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecordLabel_Id",
                table: "RecordLabel",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_Id",
                table: "Services",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                table: "Services",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subgenres_GenreId",
                table: "Subgenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Subgenres_Id",
                table: "Subgenres",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Id",
                table: "Tags",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackPlaylist_TrackId",
                table: "TrackPlaylist",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_GenreId",
                table: "Tracks",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_Id",
                table: "Tracks",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_KeyId",
                table: "Tracks",
                column: "KeyId",
                unique: true,
                filter: "[KeyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_UserId",
                table: "Tracks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_Id",
                table: "UploadedFiles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UploadedBy",
                table: "UploadedFiles",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Email",
                table: "Users",
                columns: new[] { "Id", "Email" },
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecordLabelId",
                table: "Users",
                column: "RecordLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vst_Id",
                table: "Vst",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vst_UserId",
                table: "Vst",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Kit");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Subgenres");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TrackPlaylist");

            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "Vst");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Key");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RecordLabel");

            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}
