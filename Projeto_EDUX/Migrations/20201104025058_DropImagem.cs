using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_EDUX.Migrations
{
    public partial class DropImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
