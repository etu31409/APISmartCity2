using Microsoft.EntityFrameworkCore.Migrations;

namespace APISmartCity.Migrations
{
    public partial class AjoutFavoris : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    IdFavoris = table.Column<int>(nullable: false),
                    IdCommerce = table.Column<int>(nullable: false),
                    idUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.IdFavoris);
                    table.ForeignKey(
                        name: "FK_Favoris_Commerce_IdFavoris",
                        column: x => x.IdFavoris,
                        principalTable: "Commerce",
                        principalColumn: "IdCommerce",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoris_User_idUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_idUser",
                table: "Favoris",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoris");
        }
    }
}
