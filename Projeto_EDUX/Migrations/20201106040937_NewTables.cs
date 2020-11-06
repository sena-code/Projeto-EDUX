using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_EDUX.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "ObjetivosAlunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nota = table.Column<float>(nullable: false),
                    DataAlcancada = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: false),
                    IdObjetivo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetivosAlunos_Objetivo_IdObjetivo",
                        column: x => x.IdObjetivo,
                        principalTable: "Objetivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetivosAlunos_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           


            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosAlunos_IdObjetivo",
                table: "ObjetivosAlunos",
                column: "IdObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosAlunos_IdUsuario",
                table: "ObjetivosAlunos",
                column: "IdUsuario");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosTurmas");

            migrationBuilder.DropTable(
                name: "Curtidas");

            migrationBuilder.DropTable(
                name: "Dicas");

            migrationBuilder.DropTable(
                name: "ObjetivosAlunos");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ProfessoresTurmas");

            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Perfils");

            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
