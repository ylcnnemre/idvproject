using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Persistence.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rating_film_FilmId",
                table: "rating");

            migrationBuilder.DropForeignKey(
                name: "FK_review_film_FilmId",
                table: "review");

            migrationBuilder.DropTable(
                name: "FilmUser");

            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    filmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.UsersId, x.filmsId });
                    table.ForeignKey(
                        name: "FK_MovieUser_movie_filmsId",
                        column: x => x.filmsId,
                        principalTable: "movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_user_UsersId",
                        column: x => x.UsersId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_filmsId",
                table: "MovieUser",
                column: "filmsId");

            migrationBuilder.AddForeignKey(
                name: "FK_rating_movie_FilmId",
                table: "rating",
                column: "FilmId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_movie_FilmId",
                table: "review",
                column: "FilmId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rating_movie_FilmId",
                table: "rating");

            migrationBuilder.DropForeignKey(
                name: "FK_review_movie_FilmId",
                table: "review");

            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmUser",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    filmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmUser", x => new { x.UsersId, x.filmsId });
                    table.ForeignKey(
                        name: "FK_FilmUser_film_filmsId",
                        column: x => x.filmsId,
                        principalTable: "film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmUser_user_UsersId",
                        column: x => x.UsersId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmUser_filmsId",
                table: "FilmUser",
                column: "filmsId");

            migrationBuilder.AddForeignKey(
                name: "FK_rating_film_FilmId",
                table: "rating",
                column: "FilmId",
                principalTable: "film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_film_FilmId",
                table: "review",
                column: "FilmId",
                principalTable: "film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
