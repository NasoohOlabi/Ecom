using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class AddedDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "ModifiedAt", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "0c43557b-eab6-4d87-be43-b677ba212430", new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3555), new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3566), "Admin", null },
                    { 2L, "47dbd829-ed6b-4499-bf36-3ac4ddc2338d", new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3586), new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3587), "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsVerified", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedAt", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1L, 0, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "6fe4e637-c895-4eae-aa4f-d07199286e2d", new DateTime(2023, 1, 9, 21, 18, 11, 900, DateTimeKind.Local).AddTicks(951), "admin@mail.com", true, "Site", false, "Owner", false, null, new DateTime(2023, 1, 9, 21, 18, 11, 900, DateTimeKind.Local).AddTicks(955), "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEDH8Ps1EL0j6LiqJXZ2v3W2NG1mOuY5tJdH/xMD4xGXXtpZhevoZ0M6gMmDdh2nDrg==", "0987654321", false, null, "1c7bfaec-5460-4a0b-8b38-668ea528c403", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "AttachmentType",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3838), new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3839), "Product Thumbnail" },
                    { 2L, new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3841), new DateTime(2023, 1, 9, 21, 18, 11, 899, DateTimeKind.Local).AddTicks(3842), "Product Image" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(3970), new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(4466), "Smartphones" },
                    { 2L, new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6067), new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6071), "Laptops" },
                    { 3L, new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6085), new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6086), "Fragrances" },
                    { 4L, new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6089), new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6090), "Skincare" },
                    { 5L, new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6094), new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6094), "Groceries" },
                    { 6L, new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6104), new DateTime(2023, 1, 9, 21, 18, 11, 278, DateTimeKind.Local).AddTicks(6104), "Home-decoration" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Discount", "ModifiedAt", "Name", "OrderCount", "Price", "RatingCount", "RatingSum", "SellerId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(7920), "An apple mobile which is nothing like apple", 12.96m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(7931), "iPhone 9", 0L, 549m, 0L, 0L, 1L },
                    { 2L, 1L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(7942), "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...", 17.94m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(7942), "iPhone X", 0L, 899m, 0L, 0L, 1L },
                    { 3L, 1L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8018), "Samsung's new variant which goes beyond Galaxy to the Universe", 15.46m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8019), "Samsung Universe 9", 0L, 1249m, 0L, 0L, 1L },
                    { 4L, 1L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8025), "OPPO F19 is officially announced on April 2021.", 17.91m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8025), "OPPOF19", 0L, 280m, 0L, 0L, 1L },
                    { 5L, 1L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8031), "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.", 10.58m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8031), "Huawei P30", 0L, 499m, 0L, 0L, 1L },
                    { 6L, 2L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8042), "MacBook Pro 2021 with mini-LED display may launch between September, November", 11.02m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8043), "MacBook Pro", 0L, 1749m, 0L, 0L, 1L },
                    { 7L, 2L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8049), "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched", 4.15m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8050), "Samsung Galaxy Book", 0L, 1499m, 0L, 0L, 1L },
                    { 8L, 2L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8056), "Style and speed. Stand out on HD vIdeo calls backed by Studio Mics. Capture Ideas on the vibrant touchscreen.", 10.23m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8057), "Microsoft Surface Laptop 4", 0L, 1499m, 0L, 0L, 1L },
                    { 9L, 2L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8062), "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty", 11.83m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8063), "Infinix INBOOK", 0L, 1099m, 0L, 0L, 1L },
                    { 10L, 2L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8070), "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10", 6.18m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8071), "HP Pavilion 15-DK1056WM", 0L, 1099m, 0L, 0L, 1L },
                    { 11L, 3L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8079), "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil", 8.4m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8080), "perfume Oil", 0L, 13m, 0L, 0L, 1L },
                    { 12L, 3L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8157), "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml", 15.66m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8157), "Brown Perfume", 0L, 40m, 0L, 0L, 1L },
                    { 13L, 3L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8165), "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men", 8.14m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8165), "Fog Scent Xpressio Perfume", 0L, 13m, 0L, 0L, 1L },
                    { 14L, 3L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8171), "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil", 15.6m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8172), "Non-Alcoholic Concentrated Perfume Oil", 0L, 120m, 0L, 0L, 1L },
                    { 15L, 3L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8178), "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality", 10.99m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8179), "Eau De Perfume Spray", 0L, 30m, 0L, 0L, 1L },
                    { 16L, 4L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8187), "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic AcId", 13.31m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8187), "Hyaluronic AcId Serum", 0L, 19m, 0L, 0L, 1L },
                    { 17L, 4L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8194), "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria,", 4.09m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8194), "Tree Oil 30ml", 0L, 12m, 0L, 0L, 1L },
                    { 18L, 4L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8202), "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramIdes, hyaluronic acId & sunscreen.", 13.1m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8203), "Oil Free Moisturizer 100ml", 0L, 40m, 0L, 0L, 1L },
                    { 19L, 4L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8209), "Product name: rorec collagen hyaluronic acId white face serum riceNet weight: 15 m", 10.68m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8210), "Skin Beauty Serum.", 0L, 46m, 0L, 0L, 1L },
                    { 20L, 4L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8216), "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no sIde effects.", 16.99m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8217), "Freckle Treatment Cream- 15gm", 0L, 70m, 0L, 0L, 1L },
                    { 21L, 5L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8225), "Fine quality Branded Product Keep in a cool and dry place", 4.81m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8225), "- Daal Masoor 500 grams", 0L, 20m, 0L, 0L, 1L },
                    { 22L, 5L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8301), "Product details of Bake Parlor Big Elbow Macaroni - 400 gm", 15.58m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8301), "Elbow Macaroni - 400 gm", 0L, 14m, 0L, 0L, 1L },
                    { 23L, 5L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8309), "Specifications of Orange Essence Food Flavour For Cakes and Baking Food Item", 8.04m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8310), "Orange Essence Food Flavou", 0L, 14m, 0L, 0L, 1L },
                    { 24L, 5L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8317), "Original fauji cereal muesli 250gm box pack original fauji cereals muesli fruit nuts flakes breakfast cereal break fast faujicereals cerels cerel foji fouji", 16.8m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8318), "Cereals Muesli Fruit Nuts", 0L, 46m, 0L, 0L, 1L },
                    { 25L, 5L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8325), "Dry Rose Flower Powder Gulab Powder 50 Gram • Treats Wounds", 13.58m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8326), "Gulab Powder 50 Gram", 0L, 70m, 0L, 0L, 1L },
                    { 26L, 6L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8334), "Boho Decor Plant Hanger For Home Wall Decoration Macrame Wall Hanging Shelf", 17.86m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8334), "Plant Hanger For Home", 0L, 41m, 0L, 0L, 1L },
                    { 27L, 6L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8342), "Package Include 6 Birds with Adhesive Tape Shape: 3D Shaped Wooden Birds Material: Wooden MDF, Laminated 3.5mm", 15.58m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8342), "Flying Wooden Bird", 0L, 51m, 0L, 0L, 1L },
                    { 28L, 6L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8349), "3D led lamp sticker Wall sticker 3d wall art light on/off button  cell operated (included)", 16.49m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8350), "3D Embellishment Art Lamp", 0L, 20m, 0L, 0L, 1L },
                    { 29L, 6L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8358), "Handcraft Chinese style art luxury palace hotel villa mansion home decor ceramic vase with brass fruit plate", 15.34m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8358), "Handcraft Chinese style", 0L, 60m, 0L, 0L, 1L },
                    { 30L, 6L, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8366), "Attractive DesignMetallic materialFour key hooksReliable & DurablePremium Quality", 2.92m, new DateTime(2023, 1, 9, 21, 18, 11, 910, DateTimeKind.Local).AddTicks(8366), "Key Holder", 0L, 30m, 0L, 0L, 1L }
                });
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
                table: "Product",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 30L);

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

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
