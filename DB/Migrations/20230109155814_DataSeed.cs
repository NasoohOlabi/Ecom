using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "ModifiedAt", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "b115ecb3-104e-476b-b16e-10dfbfb4dafe", new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7275), new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7286), "Admin", null },
                    { 2L, "cab319d8-8615-46e0-907c-5bc6e264d7d2", new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7307), new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7308), "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsVerified", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedAt", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1L, 0, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "7a43a7e5-6a4d-4c07-b07a-baebcab002cb", new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7814), "admin@mail.com", true, "Site", false, "Owner", false, null, new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7815), "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEKqo6pGcun+Iom4imdik7fIraSDXlD8miSGuAxgMcA+VZJOonGtFWZRLCMB2izZqOA==", "0987654321", false, null, "f881964d-c32f-498c-9a15-7702b9ec52a9", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "AttachmentType",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7538), new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7539), "Product Thumbnail" },
                    { 2L, new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7542), new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7543), "Product Image" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[] { 1L, new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7641), new DateTime(2023, 1, 9, 18, 58, 13, 667, DateTimeKind.Local).AddTicks(7642), "DB Category" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Discount", "ModifiedAt", "Name", "OrderCount", "Price", "RatingCount", "RatingSum", "SellerId" },
                values: new object[] { 1L, 1L, new DateTime(2023, 1, 9, 18, 58, 13, 677, DateTimeKind.Local).AddTicks(8661), "Sample DB Product", 0m, new DateTime(2023, 1, 9, 18, 58, 13, 677, DateTimeKind.Local).AddTicks(8662), "DB Product", 0L, 100m, 0L, 0L, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
