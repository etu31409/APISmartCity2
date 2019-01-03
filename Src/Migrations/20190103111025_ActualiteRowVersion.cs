using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APISmartCity.Migrations
{
    public partial class ActualiteRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoris_User_idUser",
                table: "Favoris");

            migrationBuilder.RenameColumn(
                name: "idUser",
                table: "Favoris",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Favoris_idUser",
                table: "Favoris",
                newName: "IX_Favoris_IdUser");

            migrationBuilder.AlterColumn<string>(
                name: "Texte",
                table: "Actualite",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Actualite",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddForeignKey(
                name: "FK_Favoris_User_IdUser",
                table: "Favoris",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoris_User_IdUser",
                table: "Favoris");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Actualite");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Favoris",
                newName: "idUser");

            migrationBuilder.RenameIndex(
                name: "IX_Favoris_IdUser",
                table: "Favoris",
                newName: "IX_Favoris_idUser");

            migrationBuilder.AlterColumn<string>(
                name: "Texte",
                table: "Actualite",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Favoris_User_idUser",
                table: "Favoris",
                column: "idUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
