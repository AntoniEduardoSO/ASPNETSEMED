using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace ASPNETSEMED.Migrations
{
    /// <inheritdoc />
    public partial class AddIpToEscola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anydesk",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Escola = table.Column<string>(type: "text", nullable: true),
                    Patrimonio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anydesk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Escola = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Diretor = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Ra = table.Column<string>(type: "text", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Lat = table.Column<float>(type: "real", nullable: true),
                    Lon = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Ip = table.Column<NpgsqlInet>(type: "inet", nullable: true),
                    Circuito = table.Column<string>(type: "text", nullable: true),
                    Imagem = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anydesk");

            migrationBuilder.DropTable(
                name: "Escola");
        }
    }
}
