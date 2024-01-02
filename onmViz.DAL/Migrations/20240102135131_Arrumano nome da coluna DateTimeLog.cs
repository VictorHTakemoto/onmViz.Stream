using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onmViz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ArrumanonomedacolunaDateTimeLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Logs",
                newName: "DateTimeLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeLogs",
                table: "Logs",
                newName: "DateTime");
        }
    }
}
