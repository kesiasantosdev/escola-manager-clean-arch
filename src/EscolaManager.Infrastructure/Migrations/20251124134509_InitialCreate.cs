using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEscola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomePermissao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomePessoa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TiposPerguntas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPerguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposPerguntas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposRespostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposRespostas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargoPermissoes",
                columns: table => new
                {
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoPermissoes", x => new { x.CargoId, x.PermissoesId });
                    table.ForeignKey(
                        name: "FK_CargoPermissoes_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoPermissoes_Permissoes_PermissoesId",
                        column: x => x.PermissoesId,
                        principalTable: "Permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuperiorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_SuperiorId",
                        column: x => x.SuperiorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TextoPergunta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPerguntaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoRespostaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perguntas_TiposPerguntas_TipoPerguntaId",
                        column: x => x.TipoPerguntaId,
                        principalTable: "TiposPerguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perguntas_TiposRespostas_TipoRespostaId",
                        column: x => x.TipoRespostaId,
                        principalTable: "TiposRespostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bimestres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioGestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MostrarResultadosAoAvaliado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bimestres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bimestres_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bimestres_Usuarios_UsuarioGestorId",
                        column: x => x.UsuarioGestorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioCriadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provas_Usuarios_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvaPerguntas",
                columns: table => new
                {
                    ProvaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerguntaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvaPerguntas", x => new { x.ProvaId, x.PerguntaId });
                    table.ForeignKey(
                        name: "FK_ProvaPerguntas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvaPerguntas_Provas_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "Provas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealizacoesProvas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BimestreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvaliadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvaliadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoRelacao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizacoesProvas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealizacoesProvas_Bimestres_BimestreId",
                        column: x => x.BimestreId,
                        principalTable: "Bimestres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealizacoesProvas_Provas_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "Provas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealizacoesProvas_Usuarios_AvaliadoId",
                        column: x => x.AvaliadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealizacoesProvas_Usuarios_AvaliadorId",
                        column: x => x.AvaliadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealizacaoProvaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerguntaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RespostaTexto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespostaNota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respostas_RealizacoesProvas_RealizacaoProvaId",
                        column: x => x.RealizacaoProvaId,
                        principalTable: "RealizacoesProvas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bimestres_EscolaId",
                table: "Bimestres",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bimestres_UsuarioGestorId",
                table: "Bimestres",
                column: "UsuarioGestorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoPermissoes_PermissoesId",
                table: "CargoPermissoes",
                column: "PermissoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_EscolaId",
                table: "Cargos",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_EscolaId",
                table: "Perguntas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_TipoPerguntaId",
                table: "Perguntas",
                column: "TipoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_TipoRespostaId",
                table: "Perguntas",
                column: "TipoRespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Email",
                table: "Pessoas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProvaPerguntas_PerguntaId",
                table: "ProvaPerguntas",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_EscolaId",
                table: "Provas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_UsuarioCriadorId",
                table: "Provas",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizacoesProvas_AvaliadoId",
                table: "RealizacoesProvas",
                column: "AvaliadoId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizacoesProvas_AvaliadorId",
                table: "RealizacoesProvas",
                column: "AvaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizacoesProvas_BimestreId",
                table: "RealizacoesProvas",
                column: "BimestreId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizacoesProvas_ProvaId",
                table: "RealizacoesProvas",
                column: "ProvaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_RealizacaoProvaId",
                table: "Respostas",
                column: "RealizacaoProvaId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposPerguntas_EscolaId",
                table: "TiposPerguntas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposRespostas_EscolaId",
                table: "TiposRespostas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EscolaId",
                table: "Usuarios",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaId",
                table: "Usuarios",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SuperiorId",
                table: "Usuarios",
                column: "SuperiorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoPermissoes");

            migrationBuilder.DropTable(
                name: "ProvaPerguntas");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "RealizacoesProvas");

            migrationBuilder.DropTable(
                name: "TiposPerguntas");

            migrationBuilder.DropTable(
                name: "TiposRespostas");

            migrationBuilder.DropTable(
                name: "Bimestres");

            migrationBuilder.DropTable(
                name: "Provas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Escolas");
        }
    }
}
