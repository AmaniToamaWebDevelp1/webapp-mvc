using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_mvc.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateSuoer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pwd",
                table: "SuperAdmin",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "SuperAdmin",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pwd",
                table: "SuperAdmin");

            migrationBuilder.DropColumn(
                name: "username",
                table: "SuperAdmin");
        }
    }
}
