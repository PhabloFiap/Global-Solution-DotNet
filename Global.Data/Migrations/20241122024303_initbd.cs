using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Global.Data.Migrations
{
    /// <inheritdoc />
    public partial class initbd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GS_MORADOR",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_MORADOR", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GS_MEDIDOR",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_medida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    valor_corrente = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    valor_tensao = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    valor_consumo = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    id_morador = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_MEDIDOR", x => x.id);
                    table.ForeignKey(
                        name: "FK_GS_MEDIDOR_GS_MORADOR_id_morador",
                        column: x => x.id_morador,
                        principalTable: "GS_MORADOR",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GS_MEDIDOR_id_morador",
                table: "GS_MEDIDOR",
                column: "id_morador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GS_MEDIDOR");

            migrationBuilder.DropTable(
                name: "GS_MORADOR");
        }
    }
}
