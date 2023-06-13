using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_mvc.Migrations
{
    /// <inheritdoc />
    public partial class newColToORder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WayOfPayment",
                table: "OrderInfos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WayOfPayment",
                table: "OrderInfos");
        }
    }
}
