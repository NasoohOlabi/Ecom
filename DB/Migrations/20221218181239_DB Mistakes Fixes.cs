using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class DBMistakesFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Attribute_AttributeId",
                table: "Specification");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Product_ProductId",
                table: "Specification");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationValue_Attribute_AttributeId",
                table: "SpecificationValue");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationValue_Product_ProductId",
                table: "SpecificationValue");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationValue_Specification_SpecificationId",
                table: "SpecificationValue");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationValue_AttributeId",
                table: "SpecificationValue");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationValue_ProductId",
                table: "SpecificationValue");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "SpecificationValue");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SpecificationValue");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "SpecificationValue",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "SpecificationValue",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecificationValue",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Specification",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specification",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Attribute",
                table: "Specification",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Product",
                table: "Specification",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationValue_Specification",
                table: "SpecificationValue",
                column: "SpecificationId",
                principalTable: "Specification",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Attribute",
                table: "Specification");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Product",
                table: "Specification");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationValue_Specification",
                table: "SpecificationValue");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "SpecificationValue",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "SpecificationValue",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecificationValue",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<long>(
                name: "AttributeId",
                table: "SpecificationValue",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "SpecificationValue",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                table: "Specification",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specification",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValue_AttributeId",
                table: "SpecificationValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValue_ProductId",
                table: "SpecificationValue",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Attribute_AttributeId",
                table: "Specification",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_Product_ProductId",
                table: "Specification",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationValue_Attribute_AttributeId",
                table: "SpecificationValue",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationValue_Product_ProductId",
                table: "SpecificationValue",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationValue_Specification_SpecificationId",
                table: "SpecificationValue",
                column: "SpecificationId",
                principalTable: "Specification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
