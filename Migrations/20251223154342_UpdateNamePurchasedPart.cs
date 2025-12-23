using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEcho.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamePurchasedPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedParts",
                table: "PurchasedParts");

            migrationBuilder.RenameTable(
                name: "PurchasedParts",
                newName: "PurchasedPart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedPart",
                table: "PurchasedPart",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedPart",
                table: "PurchasedPart");

            migrationBuilder.RenameTable(
                name: "PurchasedPart",
                newName: "PurchasedParts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedParts",
                table: "PurchasedParts",
                column: "Id");
        }
    }
}
