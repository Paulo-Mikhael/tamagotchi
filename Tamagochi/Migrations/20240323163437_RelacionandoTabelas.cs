using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamagochi.Migrations
{
    /// <inheritdoc />
    public partial class RelacionandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_PokemonsUsuarios_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Habilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotes_PokemonsUsuarios_PokemonsUsuarioMascoteId_PokemonsUsuarioHabilidadeId",
                table: "Mascotes");

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

            migrationBuilder.CreateIndex(
                name: "IX_PokemonsUsuarios_HabilidadeId",
                table: "PokemonsUsuarios",
                column: "HabilidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonsUsuarios_Habilidades_HabilidadeId",
                table: "PokemonsUsuarios",
                column: "HabilidadeId",
                principalTable: "Habilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonsUsuarios_Mascotes_MascoteId",
                table: "PokemonsUsuarios",
                column: "MascoteId",
                principalTable: "Mascotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonsUsuarios_Habilidades_HabilidadeId",
                table: "PokemonsUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonsUsuarios_Mascotes_MascoteId",
                table: "PokemonsUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_PokemonsUsuarios_HabilidadeId",
                table: "PokemonsUsuarios");

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
    }
}
