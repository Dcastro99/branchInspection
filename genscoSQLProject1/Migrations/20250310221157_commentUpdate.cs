using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace genscoSQLProject1.Migrations
{
    /// <inheritdoc />
    public partial class commentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormComments_Assets_AssetId",
                table: "FormComments");

            migrationBuilder.DropIndex(
                name: "IX_FormComments_AssetId",
                table: "FormComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
