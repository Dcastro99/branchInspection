using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class AddCatRefId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatRefId",
                table: "ChecklistItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatRefId",
                table: "Categories",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatRefId",
                table: "ChecklistItems");

            migrationBuilder.DropColumn(
                name: "CatRefId",
                table: "Categories");
        }
    }
}
