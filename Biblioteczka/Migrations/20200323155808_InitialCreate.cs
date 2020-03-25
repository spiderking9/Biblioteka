using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteczka.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ksiazkis",
                columns: table => new
                {
                    KsiazkaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    CzyDostepna = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazkis", x => x.KsiazkaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ksiazkis");
        }
    }
}
