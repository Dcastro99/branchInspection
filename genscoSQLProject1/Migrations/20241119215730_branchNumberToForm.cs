using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class branchNumberToForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchNumber",
                table: "BranchInspections",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchNumber",
                table: "BranchInspections");
        }
    }
}
