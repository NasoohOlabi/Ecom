using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class DBProblemsFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationValue_Specification",
                table: "SpecificationValue");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationValue_SpecificationId",
                table: "SpecificationValue");

            migrationBuilder.AddColumn<long>(
                name: "SpecificationValueId",
                table: "Specification",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Specification_SpecificationValueId",
                table: "Specification",
                column: "SpecificationValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_SpecificationValue",
                table: "Specification",
                column: "SpecificationValueId",
                principalTable: "SpecificationValue",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specification_SpecificationValue",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_Specification_SpecificationValueId",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "SpecificationValueId",
                table: "Specification");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValue_SpecificationId",
                table: "SpecificationValue",
                column: "SpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationValue_Specification",
                table: "SpecificationValue",
                column: "SpecificationId",
                principalTable: "Specification",
                principalColumn: "Id");
        }
    }
}
