﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediiProgProiect.Migrations
{
    public partial class TipMasina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeTip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipMasina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasinaID = table.Column<int>(type: "int", nullable: false),
                    MasinaCID = table.Column<int>(type: "int", nullable: false),
                    TipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipMasina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TipMasina_MasinaC_MasinaCID",
                        column: x => x.MasinaCID,
                        principalTable: "MasinaC",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipMasina_Tip_TipID",
                        column: x => x.TipID,
                        principalTable: "Tip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipMasina_MasinaCID",
                table: "TipMasina",
                column: "MasinaCID");

            migrationBuilder.CreateIndex(
                name: "IX_TipMasina_TipID",
                table: "TipMasina",
                column: "TipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipMasina");

            migrationBuilder.DropTable(
                name: "Tip");
        }
    }
}
