using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APISmartCity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commerce",
                columns: table => new
                {
                    IdCommerce = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomCommerce = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Rue = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ProduitPhare = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ParcoursProduitPhare = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    NumeroGsm = table.Column<int>(nullable: true),
                    NumeroFixe = table.Column<int>(nullable: true),
                    AdresseMail = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UrlPageFacebook = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    IdCategorie = table.Column<int>(nullable: true),
                    IdUser = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commerce", x => x.IdCommerce);
                    table.ForeignKey(
                        name: "FK__Commerce__IdCate__42E1EEFE",
                        column: x => x.IdCategorie,
                        principalTable: "Categorie",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Commerce__IdPers__41EDCAC5",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    IdRole = table.Column<string>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.IdRole, x.IdUser });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actualite",
                columns: table => new
                {
                    IdActualite = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Texte = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    IdCommerce = table.Column<int>(nullable: true),
                    IdSiteTouristique = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actualite", x => x.IdActualite);
                    table.ForeignKey(
                        name: "FK__Actualite__IdCom__4B7734FF",
                        column: x => x.IdCommerce,
                        principalTable: "Commerce",
                        principalColumn: "IdCommerce",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageCommerce",
                columns: table => new
                {
                    idImageCommerce = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdCommerce = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCommerce", x => x.idImageCommerce);
                    table.ForeignKey(
                        name: "FK__ImageComm__IdCom__45BE5BA9",
                        column: x => x.IdCommerce,
                        principalTable: "Commerce",
                        principalColumn: "IdCommerce",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpeningPeriod",
                columns: table => new
                {
                    IdHoraire = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoraireDebut = table.Column<TimeSpan>(nullable: false),
                    HoraireFin = table.Column<TimeSpan>(nullable: false),
                    Jour = table.Column<int>(nullable: false),
                    idCommerce = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningPeriod", x => x.IdHoraire);
                    table.ForeignKey(
                        name: "FK__OpeningPe__idCom__489AC854",
                        column: x => x.idCommerce,
                        principalTable: "Commerce",
                        principalColumn: "IdCommerce",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actualite_IdCommerce",
                table: "Actualite",
                column: "IdCommerce");

            migrationBuilder.CreateIndex(
                name: "IX_Commerce_IdCategorie",
                table: "Commerce",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Commerce_IdUser",
                table: "Commerce",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCommerce_IdCommerce",
                table: "ImageCommerce",
                column: "IdCommerce");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningPeriod_idCommerce",
                table: "OpeningPeriod",
                column: "idCommerce");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_IdUser",
                table: "UserRole",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actualite");

            migrationBuilder.DropTable(
                name: "ImageCommerce");

            migrationBuilder.DropTable(
                name: "OpeningPeriod");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Commerce");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
