using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDadosCompletosEscola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Escolas",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(18)",
                oldMaxLength: 18);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Escolas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Escolas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Escolas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Escolas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Escolas",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Escolas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Escolas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Escolas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Escolas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Escolas_Cnpj",
                table: "Escolas",
                column: "Cnpj",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Escolas_Cnpj",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Escolas");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Escolas");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Escolas",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);
        }
    }
}
