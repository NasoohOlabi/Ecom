using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class ValueTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Attribute",
                table: "Specification");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Product",
                table: "Specification");

            migrationBuilder.DropTable(
                name: "BoolValue");

            migrationBuilder.DropTable(
                name: "FloatValue");

            migrationBuilder.DropTable(
                name: "IntValue");

            migrationBuilder.DropTable(
                name: "StringValue");

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

            migrationBuilder.CreateTable(
                name: "SpecificationValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationValue_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecificationValue_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecificationValue_Specification_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValue_AttributeId",
                table: "SpecificationValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValue_ProductId",
                table: "SpecificationValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValue_SpecificationId",
                table: "SpecificationValue",
                column: "SpecificationId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Attribute_AttributeId",
                table: "Specification");

            migrationBuilder.DropForeignKey(
                name: "FK_Specification_Product_ProductId",
                table: "Specification");

            migrationBuilder.DropTable(
                name: "SpecificationValue");

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

            migrationBuilder.CreateTable(
                name: "BoolValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoolValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoolValue_Specification",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FloatValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloatValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloatValue_Specification",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IntValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntValue_Specification",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StringValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringValue_Specification",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoolValue_SpecificationId",
                table: "BoolValue",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_FloatValue_SpecificationId",
                table: "FloatValue",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntValue_SpecificationId",
                table: "IntValue",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_StringValue_SpecificationId",
                table: "StringValue",
                column: "SpecificationId");

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
        }
    }
}
