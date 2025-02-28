using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class userModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Users",
                newName: "Contact_id");

            migrationBuilder.RenameColumn(
                name: "DefaultLocationId",
                table: "Users",
                newName: "Default_Branch");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Users",
                newName: "Default_Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Default_Branch",
                table: "Users",
                newName: "DefaultLocationId");

            migrationBuilder.RenameColumn(
                name: "Default_Company",
                table: "Users",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Contact_id",
                table: "Users",
                newName: "EmployeeId");
        }
    }
}
