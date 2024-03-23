using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamagochi.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPokemonsUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_ConjuntoHabildades_ConjuntoHabilidadesId",
                table: "Habilidades");

            migrationBuilder.DropTable(
                name: "ConjuntoHabildades");

            migrationBuilder.DropIndex(
                name: "IX_Habilidades_ConjuntoHabilidadesId",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "ConjuntoHabilidadesId",
                table: "Habilidades");

            migrationBuilder.AddColumn<int>(
                name: "PokemonsUsuarioHabilidadeId",
                table: "Mascotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonsUsuarioMascoteId",
                table: "Mascotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonsUsuarioHabilidadeId",
                table: "Habilidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonsUsuarioMascoteId",
                table: "Habilidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PokemonsUsuarios",
                columns: table => new
                {
                    MascoteId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonsUsuarios", x => new { x.MascoteId, x.HabilidadeId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotes_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Mascotes",
                columns: new[] { "PokemonsUsuarioMascoteId", "PokemonsUsuarioHabilidadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Habilidades",
                columns: new[] { "PokemonsUsuarioMascoteId", "PokemonsUsuarioHabilidadeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_PokemonsUsuarios_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Habilidades",
                columns: new[] { "PokemonsUsuarioMascoteId", "PokemonsUsuarioHabilidadeId" },
                principalTable: "PokemonsUsuarios",
                principalColumns: new[] { "MascoteId", "HabilidadeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotes_PokemonsUsuarios_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Mascotes",
                columns: new[] { "PokemonsUsuarioMascoteId", "PokemonsUsuarioHabilidadeId" },
                principalTable: "PokemonsUsuarios",
                principalColumns: new[] { "MascoteId", "HabilidadeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_PokemonsUsuarios_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Habilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotes_PokemonsUsuarios_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Mascotes");

            migrationBuilder.DropTable(
                name: "PokemonsUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Mascotes_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Mascotes");

            migrationBuilder.DropIndex(
                name: "IX_Habilidades_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "PokemonsUsuarioHabilidadeId",
                table: "Mascotes");

            migrationBuilder.DropColumn(
                name: "PokemonsUsuarioMascoteId",
                table: "Mascotes");

            migrationBuilder.DropColumn(
                name: "PokemonsUsuarioHabilidadeId",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "PokemonsUsuarioMascoteId",
                table: "Habilidades");

            migrationBuilder.AddColumn<int>(
                name: "ConjuntoHabilidadesId",
                table: "Habilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_ConjuntoHabilidadesId",
                table: "Habilidades",
                column: "ConjuntoHabilidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_ConjuntoHabildades_MascoteId",
                table: "ConjuntoHabildades",
                column: "MascoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_ConjuntoHabildades_ConjuntoHabilidadesId",
                table: "Habilidades",
                column: "ConjuntoHabilidadesId",
                principalTable: "ConjuntoHabildades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
