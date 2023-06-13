using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_mvc.Migrations
{
    /// <inheritdoc />
    public partial class newUpdattttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meidas_Products_ProductId",
                table: "Meidas");

            migrationBuilder.DropIndex(
                name: "IX_Meidas_ProductId",
                table: "Meidas");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Meidas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Meidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meidas_ProductId",
                table: "Meidas",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meidas_Products_ProductId",
                table: "Meidas",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
