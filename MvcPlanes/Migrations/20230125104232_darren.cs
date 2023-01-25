using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPlanes.Migrations
{
    /// <inheritdoc />
    public partial class darren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Planes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Planes",
                newName: "Safety");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Planes",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Planes");

            migrationBuilder.RenameColumn(
                name: "Safety",
                table: "Planes",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Planes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
