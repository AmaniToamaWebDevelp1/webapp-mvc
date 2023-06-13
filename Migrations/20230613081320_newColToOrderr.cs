using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_mvc.Migrations
{
    /// <inheritdoc />
    public partial class newColToOrderr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "OrderInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productId",
                table: "OrderInfos");
        }
    }
}
