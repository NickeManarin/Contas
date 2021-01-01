using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contas.Simples.Migrations
{
    public partial class Version0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "Nome", "Pagamento", "Valor", "Vencimento" },
                values: new object[,]
                {
                    { 1L, "Computadores", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3500.67m, new DateTime(2020, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Alimentos", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.10m, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "Equipamentos de segurança", new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1560.90m, new DateTime(2020, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "Equipamentos de limpeza", new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 234.20m, new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Contas");
        }
    }
}