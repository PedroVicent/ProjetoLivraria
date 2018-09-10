using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoLivraria.Migrations
{
    public partial class ProjetoLivraria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "livro",
                schema: "dbo",
                columns: table => new
                {
                    cd_livro = table.Column<Guid>(nullable: false),
                    lv_nome = table.Column<string>(nullable: true),
                    lv_descricao = table.Column<string>(nullable: true),
                    lv_situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro", x => x.cd_livro);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                schema: "dbo",
                columns: table => new
                {
                    cd_pessoa = table.Column<Guid>(nullable: false),
                    pe_nome = table.Column<string>(nullable: true),
                    pe_endereco = table.Column<string>(nullable: true),
                    pe_telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.cd_pessoa);
                });

            migrationBuilder.CreateTable(
                name: "emprestimo",
                schema: "dbo",
                columns: table => new
                {
                    cd_emprestimo = table.Column<Guid>(nullable: false),
                    cd_livro = table.Column<Guid>(nullable: false),
                    cd_pessoa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimo", x => x.cd_emprestimo);
                    table.ForeignKey(
                        name: "FK_emprestimo_livro_cd_livro",
                        column: x => x.cd_livro,
                        principalSchema: "dbo",
                        principalTable: "livro",
                        principalColumn: "cd_livro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emprestimo_pessoa_cd_pessoa",
                        column: x => x.cd_pessoa,
                        principalSchema: "dbo",
                        principalTable: "pessoa",
                        principalColumn: "cd_pessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_cd_livro",
                schema: "dbo",
                table: "emprestimo",
                column: "cd_livro");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_cd_pessoa",
                schema: "dbo",
                table: "emprestimo",
                column: "cd_pessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "livro",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "dbo");
        }
    }
}
