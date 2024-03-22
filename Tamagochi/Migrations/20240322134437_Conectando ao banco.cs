using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamagochi.Migrations
{
    /// <inheritdoc />
    public partial class Conectandoaobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mascotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConjuntoHabildades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConjuntoHabildades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConjuntoHabildades_Mascotes_MascoteId",
                        column: x => x.MascoteId,
                        principalTable: "Mascotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConjuntoHabilidadesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habilidades_ConjuntoHabildades_ConjuntoHabilidadesId",
                        column: x => x.ConjuntoHabilidadesId,
                        principalTable: "ConjuntoHabildades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConjuntoHabildades_MascoteId",
                table: "ConjuntoHabildades",
                column: "MascoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_ConjuntoHabilidadesId",
                table: "Habilidades",
                column: "ConjuntoHabilidadesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "ConjuntoHabildades");

            migrationBuilder.DropTable(
                name: "Mascotes");
        }
    }
}
