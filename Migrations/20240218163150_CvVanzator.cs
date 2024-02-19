using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiProgProiect.Migrations
{
    public partial class CvVanzator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VanzatorID",
                table: "MasinaC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vanzator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeVanzator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanzator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasinaC_VanzatorID",
                table: "MasinaC",
                column: "VanzatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_MasinaC_Vanzator_VanzatorID",
                table: "MasinaC",
                column: "VanzatorID",
                principalTable: "Vanzator",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasinaC_Vanzator_VanzatorID",
                table: "MasinaC");

            migrationBuilder.DropTable(
                name: "Vanzator");

            migrationBuilder.DropIndex(
                name: "IX_MasinaC_VanzatorID",
                table: "MasinaC");

            migrationBuilder.DropColumn(
                name: "VanzatorID",
                table: "MasinaC");
        }
    }
}
