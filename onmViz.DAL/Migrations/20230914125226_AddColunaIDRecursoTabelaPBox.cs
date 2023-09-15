using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onmViz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddColunaIDRecursoTabelaPBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDRecurso",
                table: "PictureBoxes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDRecurso",
                table: "PictureBoxes");
        }
    }
}
