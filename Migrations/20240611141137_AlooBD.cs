using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace ASPNETSEMED.Migrations
{
    /// <inheritdoc />
    public partial class AlooBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                table: "Impressora",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aloo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Escola = table.Column<string>(type: "text", nullable: false),
                    Ip = table.Column<NpgsqlInet>(type: "inet", nullable: false),
                    Circuito = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aloo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aloo");

            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Impressora");
        }
    }
}
