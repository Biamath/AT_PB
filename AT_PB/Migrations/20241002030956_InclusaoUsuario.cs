using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT_PB.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoStatus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mensagem = table.Column<string>(type: "TEXT", nullable: true),
                    DataEnvio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoNotificacao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidosReembolso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataSubmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    StatusPedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosReembolso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosReembolso_StatusPedido_StatusPedidoId",
                        column: x => x.StatusPedidoId,
                        principalTable: "StatusPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosReembolso_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalisesPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    DataAnalise = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PedidoReembolsoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisesPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisesPedidos_PedidosReembolso_PedidoReembolsoId",
                        column: x => x.PedidoReembolsoId,
                        principalTable: "PedidosReembolso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespesasMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDespesa = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataDespesa = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PedidoReembolsoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesasMedicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DespesasMedicas_PedidosReembolso_PedidoReembolsoId",
                        column: x => x.PedidoReembolsoId,
                        principalTable: "PedidosReembolso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeArquivo = table.Column<string>(type: "TEXT", nullable: true),
                    CaminhoArquivo = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDocumento = table.Column<string>(type: "TEXT", nullable: true),
                    PedidoReembolsoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.DocumentoId);
                    table.ForeignKey(
                        name: "FK_Documentos_PedidosReembolso_PedidoReembolsoId",
                        column: x => x.PedidoReembolsoId,
                        principalTable: "PedidosReembolso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisesPedidos_PedidoReembolsoId",
                table: "AnalisesPedidos",
                column: "PedidoReembolsoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DespesasMedicas_PedidoReembolsoId",
                table: "DespesasMedicas",
                column: "PedidoReembolsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_PedidoReembolsoId",
                table: "Documentos",
                column: "PedidoReembolsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_UsuarioId",
                table: "Notificacoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosReembolso_StatusPedidoId",
                table: "PedidosReembolso",
                column: "StatusPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosReembolso_UsuarioId",
                table: "PedidosReembolso",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisesPedidos");

            migrationBuilder.DropTable(
                name: "DespesasMedicas");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "PedidosReembolso");

            migrationBuilder.DropTable(
                name: "StatusPedido");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
