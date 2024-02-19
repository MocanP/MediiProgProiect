using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiProgProiect.Migrations
{
    public partial class MembruCumparari2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CumparareID",
                table: "MasinaC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Membru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cumparare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruID = table.Column<int>(type: "int", nullable: true),
                    MasinaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cumparare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cumparare_Membru_MembruID",
                        column: x => x.MembruID,
                        principalTable: "Membru",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasinaC_CumparareID",
                table: "MasinaC",
                column: "CumparareID",
                unique: true,
                filter: "[CumparareID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cumparare_MembruID",
                table: "Cumparare",
                column: "MembruID");

            migrationBuilder.AddForeignKey(
                name: "FK_MasinaC_Cumparare_CumparareID",
                table: "MasinaC",
                column: "CumparareID",
                principalTable: "Cumparare",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasinaC_Cumparare_CumparareID",
                table: "MasinaC");

            migrationBuilder.DropTable(
                name: "Cumparare");

            migrationBuilder.DropTable(
                name: "Membru");

            migrationBuilder.DropIndex(
                name: "IX_MasinaC_CumparareID",
                table: "MasinaC");

            migrationBuilder.DropColumn(
                name: "CumparareID",
                table: "MasinaC");
        }
    }
}
