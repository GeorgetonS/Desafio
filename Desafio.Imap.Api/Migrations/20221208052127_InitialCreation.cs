using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Imap.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_endereco_candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_endereco_CandidatoId",
                table: "endereco",
                column: "CandidatoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "candidato");
        }
    }
}
