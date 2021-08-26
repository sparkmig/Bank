using Microsoft.EntityFrameworkCore.Migrations;

namespace Storage.Migrations
{
    public partial class AddedPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "Customers",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
