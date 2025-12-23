using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEcho.Migrations
{
    /// <inheritdoc />
    public partial class TblPurchasedPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchasedPart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<long>(type: "bigint", nullable: false),
                    UnitsId = table.Column<long>(type: "bigint", nullable: false),
                    ManufacturerPartNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrawingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    ManufacturerDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedPart", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedParts");
        }
    }
}
