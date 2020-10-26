using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_EDUX.Migrations
{
    public partial class CorrecaoTurma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTurma",
                table: "Turmas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTurma",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
