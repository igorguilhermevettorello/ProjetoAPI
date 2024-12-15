using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAPI.Infrastructure.Migrations
{
    public partial class AddTablesLivroRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Editora = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Edicao = table.Column<int>(type: "int", nullable: false),
                    AnoPublicao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LivroAssunto",
                columns: table => new
                {
                    AssuntosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivrosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAssunto", x => new { x.AssuntosId, x.LivrosId });
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Assunto_AssuntosId",
                        column: x => x.AssuntosId,
                        principalTable: "Assunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Livro_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAutor",
                columns: table => new
                {
                    AutoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivrosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAutor", x => new { x.AutoresId, x.LivrosId });
                    table.ForeignKey(
                        name: "FK_LivroAutor_Autor_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAutor_Livro_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_LivrosId",
                table: "LivroAssunto",
                column: "LivrosId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAutor_LivrosId",
                table: "LivroAutor",
                column: "LivrosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAssunto");

            migrationBuilder.DropTable(
                name: "LivroAutor");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
