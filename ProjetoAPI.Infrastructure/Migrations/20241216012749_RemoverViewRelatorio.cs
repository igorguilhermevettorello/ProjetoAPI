using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAPI.Infrastructure.Migrations
{
    public partial class RemoverViewRelatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS view_relatorio;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
