using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contas.Extenso.Data.Migrations
{
    public partial class Version0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(nullable: false),
                    Pagamento = table.Column<DateTime>(nullable: false),
                    DiasDeAtraso = table.Column<int>(nullable: true),
                    ValorAjustado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regras",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Superior = table.Column<bool>(nullable: false),
                    Dias = table.Column<int>(nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JurosAoDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regras", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DiasDeAtraso", "Nome", "Pagamento", "Valor", "ValorAjustado", "Vencimento" },
                values: new object[,]
                {
                    { 1L, 16, "Computadores", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3500.67m, 3843.73566m, new DateTime(2020, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, -10, "Alimentos", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.10m, 60.1m, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, -1, "Equipamentos de segurança", new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1560.90m, 1560.9m, new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 0, "Equipamentos de limpeza", new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 234.20m, 234.20m, new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Regras",
                columns: new[] { "Id", "Dias", "JurosAoDia", "Multa", "Superior" },
                values: new object[,]
                {
                    { 1L, 3, 0.001m, 0.02m, false },
                    { 2L, 3, 0.002m, 0.03m, true },
                    { 3L, 5, 0.003m, 0.05m, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Regras");
        }
    }
}
