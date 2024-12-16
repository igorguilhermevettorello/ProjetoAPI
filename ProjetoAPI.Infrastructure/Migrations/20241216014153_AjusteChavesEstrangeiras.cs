using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAPI.Infrastructure.Migrations
{
    public partial class AjusteChavesEstrangeiras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE LivroAutor
                DROP CONSTRAINT IF EXISTS FK_LivroAutor_Autor_AutoresId;
                ALTER TABLE LivroAutor
                ADD CONSTRAINT FK_LivroAutor_Autor_AutoresId
                FOREIGN KEY (AutoresId) REFERENCES Autor(Id)
                ON DELETE CASCADE;   

                ALTER TABLE LivroAssunto
                DROP CONSTRAINT IF EXISTS FK_LivroAssunto_Assunto_AssuntosId;
                ALTER TABLE LivroAssunto
                ADD CONSTRAINT FK_LivroAssunto_Assunto_AssuntosId
                FOREIGN KEY (AssuntosId) REFERENCES Assunto(Id)
                ON DELETE CASCADE;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
