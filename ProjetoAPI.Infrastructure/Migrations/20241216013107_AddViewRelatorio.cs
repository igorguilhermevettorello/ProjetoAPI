using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAPI.Infrastructure.Migrations
{
    public partial class AddViewRelatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW view_relatorio AS
                SELECT l.Id AS LivroId,
                       l.Titulo AS Titulo,
                       l.Editora AS Editora,
                       l.Edicao AS Edicao,
                       l.AnoPublicacao AS AnoPublicacao,
                       l.Valor AS Valor,
                       STRING_AGG(a.Nome, ', ') AS Autor,
                       STRING_AGG(ast.Descricao, ', ') AS Assunto
                  FROM Livro l
                 INNER JOIN LivroAssunto la 
                         ON la.LivrosId = l.Id
                 INNER JOIN LivroAutor lau  
                         ON lau.LivrosId = l.Id
                 INNER JOIN Autor a 
                         ON a.Id = lau.AutoresId
                 INNER JOIN Assunto ast 
                         ON ast.Id = la.AssuntosId
                 GROUP BY l.Id, l.Titulo, l.Editora, l.Edicao, l.AnoPublicacao, l.Valor;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
