using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EarlyManApp.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CartId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PurchaseQuantity = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    Valid = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsValid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageLocation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiscountPercentage = table.Column<double>(type: "double", nullable: false),
                    AvailableUnits = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Promos",
                columns: table => new
                {
                    PromotionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageLocation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.PromotionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AvailableUnits", "CreationDate", "CurrentPrice", "Description", "DiscountPercentage", "ImageLocation", "IsAvailable", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("021abd14-54f3-4885-b4dc-c6bb2f808df0"), 9, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7545), new TimeSpan(0, 1, 0, 0, 0)), 2500m, "Stones from somewhere in Jos", 0.0, "Jos.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7553), new TimeSpan(0, 1, 0, 0, 0)), "A whole Rock" },
                    { new Guid("048e58cb-3515-4aa9-89aa-0d1f8c1dd75d"), 9, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7634), new TimeSpan(0, 1, 0, 0, 0)), 70000m, "Picture of two peopleon a boat", 0.0, "Mashafa.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7644), new TimeSpan(0, 1, 0, 0, 0)), "Mashafa" },
                    { new Guid("1b2aa8ba-1810-4fee-a9ec-a3e49fc68c7f"), 22, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7695), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Acrylic design", 0.0, "Spiral.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7702), new TimeSpan(0, 1, 0, 0, 0)), "Spiral" },
                    { new Guid("230d3c60-68e0-467d-ae53-bf0edf49fb6d"), 43, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7516), new TimeSpan(0, 1, 0, 0, 0)), 5000m, "Sketch of various fishingequipment", 0.0, "Fishing.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7523), new TimeSpan(0, 1, 0, 0, 0)), "Fishing Equipment" },
                    { new Guid("2a451e37-b21b-4884-9b4c-185b68d7bb2e"), 29, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7750), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Masks masks masks", 0.0, "three.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 1, 0, 0, 0)), "Three Masks" },
                    { new Guid("409582f3-5bc9-465e-b6a6-cb1845c1d025"), 5, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7206), new TimeSpan(0, 1, 0, 0, 0)), 2500m, "A black/white painting of a monkey", 0.0, "Monkey.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7304), new TimeSpan(0, 1, 0, 0, 0)), "Monkey Drawing" },
                    { new Guid("467f1214-d93d-4de1-b99d-b225b56b590c"), 1, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7666), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Design design design", 0.0, "Design.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7673), new TimeSpan(0, 1, 0, 0, 0)), "Luxor" },
                    { new Guid("656ba007-917d-4635-93bc-e1bc8295758e"), 1, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7603), new TimeSpan(0, 1, 0, 0, 0)), 20m, "Sketch of a man under a hut", 0.0, "ShadyMan.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7613), new TimeSpan(0, 1, 0, 0, 0)), "Hut and Man" },
                    { new Guid("c1ae2d0b-cf20-480e-8ea8-d9a78e4c4fd4"), 10, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7353), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Ancestral masks from some kingdom", 0.0, "Ancient.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7363), new TimeSpan(0, 1, 0, 0, 0)), "Ancient Masks" },
                    { new Guid("d2fc0cf3-3630-45ce-b1d4-5ddf6af44b49"), 3, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 1, 0, 0, 0)), 500m, "Beads beads beads", 0.0, "Fancy.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7478), new TimeSpan(0, 1, 0, 0, 0)), "Bands" },
                    { new Guid("ee2ca912-b5c3-4b16-b693-fadb34f87294"), 21, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7724), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Variety of Beadys", 0.0, "Fancy.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7731), new TimeSpan(0, 1, 0, 0, 0)), "Beads" },
                    { new Guid("fb26190e-1da6-4529-9680-b3735fe293ce"), 3, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7576), new TimeSpan(0, 1, 0, 0, 0)), 6000m, "People wearing some clothes", 0.0, "Lots.jpg", false, new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7582), new TimeSpan(0, 1, 0, 0, 0)), "People" }
                });

            migrationBuilder.InsertData(
                table: "Promos",
                columns: new[] { "PromotionId", "Description", "ImageLocation", "Name" },
                values: new object[] { new Guid("a9766f75-ef68-4233-ab9c-a10e4307b37c"), "Announce 50% off all items", "assets/promotions/Availability.png", "50Percent off" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Promos");
        }
    }
}
