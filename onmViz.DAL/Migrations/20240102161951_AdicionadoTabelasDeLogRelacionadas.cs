using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onmViz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoTabelasDeLogRelacionadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JustificationLogs",
                columns: table => new
                {
                    JustificationLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JustificationMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleBridge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JustificarionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JustificationLogs", x => x.JustificationLogId);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationLogs",
                columns: table => new
                {
                    IntregrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntegrationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JustificationLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationLogs", x => x.IntregrationId);
                    table.ForeignKey(
                        name: "FK_IntegrationLogs_JustificationLogs_JustificationLogId",
                        column: x => x.JustificationLogId,
                        principalTable: "JustificationLogs",
                        principalColumn: "JustificationLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationLogs_JustificationLogId",
                table: "IntegrationLogs",
                column: "JustificationLogId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationLogs");

            migrationBuilder.DropTable(
                name: "JustificationLogs");
        }
    }
}
