using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Persistence.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmUser");
        }
    }
}
