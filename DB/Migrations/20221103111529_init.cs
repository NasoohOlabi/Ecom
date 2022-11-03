using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AttachmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_AttachmentType",
                        column: x => x.AttachmentTypeId,
                        principalTable: "AttachmentType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryHasAttribute",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryHasAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryHasAttribute_Attribute",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryHasAttribute_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleHasPermission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleHasPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleHasPermission_Permission",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleHasPermission_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BirthDate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePicture = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    NotificationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_NotificationType",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notification_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SellerId = table.Column<long>(type: "bigint", nullable: false),
                    RatingSum = table.Column<long>(type: "bigint", nullable: false),
                    RatingCount = table.Column<long>(type: "bigint", nullable: false),
                    OrderCount = table.Column<long>(type: "bigint", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_User",
                        column: x => x.SellerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DeliveredAt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OrderStatusId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ShippingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Shipping",
                        column: x => x.ShippingId,
                        principalTable: "Shipping",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductHasAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    AttachmentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHasAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductHasAttachment_Attachment",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductHasAttachment_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductHasCoupon",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CouponId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHasCoupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductHasCoupon_Coupon",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductHasCoupon_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ValueType = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specification_Attribute",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specification_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishList_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WishList_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderHasProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHasProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHasProduct_Order",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderHasProduct_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BoolValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_AttachmentTypeId",
                table: "Attachment",
                column: "AttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute",
                table: "Attribute",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoolValue_SpecificationId",
                table: "BoolValue",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryHasAttribute_AttributeId",
                table: "CategoryHasAttribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryHasAttribute_CategoryId",
                table: "CategoryHasAttribute",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon",
                table: "Coupon",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FloatValue_SpecificationId",
                table: "FloatValue",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntValue_SpecificationId",
                table: "IntValue",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationTypeId",
                table: "Notification",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingId",
                table: "Order",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_OrderId",
                table: "OrderHasProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_ProductId",
                table: "OrderHasProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission",
                table: "Permission",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerId",
                table: "Product",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHasAttachment_AttachmentId",
                table: "ProductHasAttachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHasAttachment_ProductId",
                table: "ProductHasAttachment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHasCoupon_CouponId",
                table: "ProductHasCoupon",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHasCoupon_ProductId",
                table: "ProductHasCoupon",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProductId",
                table: "Rating",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleHasPermission_PermissionId",
                table: "RoleHasPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleHasPermission_RoleId",
                table: "RoleHasPermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_AttributeId",
                table: "Specification",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_ProductId",
                table: "Specification",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StringValue_SpecificationId",
                table: "StringValue",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ProductId",
                table: "WishList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoolValue");

            migrationBuilder.DropTable(
                name: "CategoryHasAttribute");

            migrationBuilder.DropTable(
                name: "FloatValue");

            migrationBuilder.DropTable(
                name: "IntValue");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OrderHasProduct");

            migrationBuilder.DropTable(
                name: "ProductHasAttachment");

            migrationBuilder.DropTable(
                name: "ProductHasCoupon");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "RoleHasPermission");

            migrationBuilder.DropTable(
                name: "StringValue");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "AttachmentType");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
