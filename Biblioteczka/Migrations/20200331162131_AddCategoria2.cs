using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteczka.Migrations
{
    public partial class AddCategoria2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Ksiazkis");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Ksiazkis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazkis_CategoriaId",
                table: "Ksiazkis",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazkis_Categorias_CategoriaId",
                table: "Ksiazkis",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazkis_Categorias_CategoriaId",
                table: "Ksiazkis");

            migrationBuilder.DropIndex(
                name: "IX_Ksiazkis_CategoriaId",
                table: "Ksiazkis");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Ksiazkis");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Ksiazkis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
