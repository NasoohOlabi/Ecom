using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class MoveValueTypetoAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueType",
                table: "Specification");

            migrationBuilder.AddColumn<int>(
                name: "ValueType",
                table: "Attribute",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueType",
                table: "Attribute");

            migrationBuilder.AddColumn<long>(
                name: "ValueType",
                table: "Specification",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
