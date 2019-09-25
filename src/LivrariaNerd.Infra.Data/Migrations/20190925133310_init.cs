using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaNerd.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    login = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    nome_completo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    id_categoria = table.Column<int>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    preco = table.Column<int>(nullable: false),
                    peso = table.Column<int>(nullable: false),
                    cor = table.Column<string>(nullable: true),
                    imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_produtos_categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    id_estado = table.Column<int>(nullable: false),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidades", x => x.id);
                    table.ForeignKey(
                        name: "FK_cidades_estados_id_estado",
                        column: x => x.id_estado,
                        principalTable: "estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedidos_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estoques",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    id_produto = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoques", x => x.id);
                    table.ForeignKey(
                        name: "FK_estoques_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    id_cidade = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    cep = table.Column<string>(nullable: true),
                    logradouro = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    numero = table.Column<string>(nullable: true),
                    complemento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "FK_enderecos_cidades_id_cidade",
                        column: x => x.id_cidade,
                        principalTable: "cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enderecos_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos_produtos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    data_exclusao = table.Column<DateTime>(nullable: true),
                    registro_ativo = table.Column<bool>(nullable: false),
                    id_produto = table.Column<int>(nullable: false),
                    id_pedido = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedidos_produtos_pedidos_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedidos_produtos_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "data_criacao", "data_exclusao", "data_ultima_atualizacao", "login", "nome_completo", "registro_ativo", "senha" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "guilherme", "Guilherme", true, "123" });

            migrationBuilder.CreateIndex(
                name: "IX_cidades_id_estado",
                table: "cidades",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_id_cidade",
                table: "enderecos",
                column: "id_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_id_usuario",
                table: "enderecos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_estoques_id_produto",
                table: "estoques",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_id_usuario",
                table: "pedidos",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_produtos_id_pedido",
                table: "pedidos_produtos",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_produtos_id_produto",
                table: "pedidos_produtos",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_id_categoria",
                table: "produtos",
                column: "id_categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "estoques");

            migrationBuilder.DropTable(
                name: "pedidos_produtos");

            migrationBuilder.DropTable(
                name: "cidades");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
