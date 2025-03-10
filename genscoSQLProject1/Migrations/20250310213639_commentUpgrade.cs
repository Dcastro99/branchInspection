using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class commentUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "EmployeeId",
            //    table: "Users",
            //    newName: "Contact_id");

            //migrationBuilder.RenameColumn(
            //    name: "DefaultLocationId",
            //    table: "Users",
            //    newName: "Default_company");

            //migrationBuilder.RenameColumn(
            //    name: "CompanyId",
            //    table: "Users",
            //    newName: "Default_branch");

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "FormComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormComments_AssetId",
                table: "FormComments",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormComments_Assets_AssetId",
                table: "FormComments",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormComments_Assets_AssetId",
                table: "FormComments");

            migrationBuilder.DropIndex(
                name: "IX_FormComments_AssetId",
                table: "FormComments");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "FormComments");

            //migrationBuilder.RenameColumn(
            //    name: "Default_company",
            //    table: "Users",
            //    newName: "DefaultLocationId");

            //migrationBuilder.RenameColumn(
            //    name: "Default_branch",
            //    table: "Users",
            //    newName: "CompanyId");

            //migrationBuilder.RenameColumn(
            //    name: "Contact_id",
            //    table: "Users",
            //    newName: "EmployeeId");
        }
    }
}
