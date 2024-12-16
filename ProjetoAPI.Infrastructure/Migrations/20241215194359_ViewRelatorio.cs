using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAPI.Infrastructure.Migrations
{
    public partial class ViewRelatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW view_relatorio AS
                select l.Id as LivroId,
                       l.Titulo as Titulo,
	                   l.Editora as Editora,
	                   l.Edicao as Edicao,
	                   l.AnoPublicacao as AnoPublicacao,
	                   l.Valor as Valor,
	                   a.Nome as Autor,
	                   ast.Descricao as Assunto
                  from Livro l 
                 inner join LivroAssunto la 
                         on la.LivrosId = l.Id 
                 inner join LivroAutor lau  
                         on lau.LivrosId = l.Id 
                 inner join Autor a 
                         on a.Id = lau.AutoresId 
                 inner join Assunto ast 
                         on ast.Id = la.AssuntosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS view_relatorio;");
        }
    }
}
