using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class roleChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleDescription",
                table: "Roles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "DeleteFlag",
                table: "Roles",
                newName: "Delete_Flag");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Roles",
                newName: "RoleDescription");

            migrationBuilder.RenameColumn(
                name: "Delete_Flag",
                table: "Roles",
                newName: "DeleteFlag");
        }
    }
}
