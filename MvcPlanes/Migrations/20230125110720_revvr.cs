using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPlanes.Migrations
{
    /// <inheritdoc />
    public partial class revvr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Planes",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Planes",
                newName: "Genre");
        }
    }
}
