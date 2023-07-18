using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Persistence.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_movie_FilmId",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_user_UserId1",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_user_movie_MovieId",
                table: "user");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropIndex(
                name: "IX_user_MovieId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_review_UserId1",
                table: "review");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "review");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "review",
                newName: "movieId");

            migrationBuilder.RenameIndex(
                name: "IX_review_FilmId",
                table: "review",
                newName: "IX_review_movieId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "review",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    FavoriteMoviesId = table.Column<int>(type: "int", nullable: false),
                    fansId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.FavoriteMoviesId, x.fansId });
                    table.ForeignKey(
                        name: "FK_MovieUser_movie_FavoriteMoviesId",
                        column: x => x.FavoriteMoviesId,
                        principalTable: "movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_user_fansId",
                        column: x => x.fansId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_review_UserId",
                table: "review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_fansId",
                table: "MovieUser",
                column: "fansId");

            migrationBuilder.AddForeignKey(
                name: "FK_review_movie_movieId",
                table: "review",
                column: "movieId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_user_UserId",
                table: "review",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_movie_movieId",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_user_UserId",
                table: "review");

            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.DropIndex(
                name: "IX_review_UserId",
                table: "review");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "review",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_review_movieId",
                table: "review",
                newName: "IX_review_FilmId");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "review",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "review",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rating_movie_FilmId",
                        column: x => x.FilmId,
                        principalTable: "movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_user_UserId1",
                        column: x => x.UserId1,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_MovieId",
                table: "user",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_review_UserId1",
                table: "review",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_rating_FilmId",
                table: "rating",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_rating_UserId1",
                table: "rating",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_review_movie_FilmId",
                table: "review",
                column: "FilmId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_user_UserId1",
                table: "review",
                column: "UserId1",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_movie_MovieId",
                table: "user",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "Id");
        }
    }
}
