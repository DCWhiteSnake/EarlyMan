using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EarlyMan.PL.Migrations
{
    public partial class AddCartLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseQuantity = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    valid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    AvailableUnits = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Promos",
                columns: table => new
                {
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.PromotionId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AvailableUnits", "CreationDate", "CurrentPrice", "Description", "DiscountPercentage", "ImageLocation", "IsAvailable", "ModificationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("3a0e5798-9cd0-44fc-aaed-289d59bc77d4"), 1, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3846), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Design design design", 0.0, "Design.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 1, 0, 0, 0)), "Luxor" },
                    { new Guid("3bcac08b-0865-4c8b-85cc-012d61313591"), 1, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 1, 0, 0, 0)), 20m, "Sketch of a man under a hut", 0.0, "ShadyMan.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 1, 0, 0, 0)), "Hut and Man" },
                    { new Guid("3d9a1c95-3a32-4d18-8222-aa4644ae94dd"), 3, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3826), new TimeSpan(0, 1, 0, 0, 0)), 500m, "Beads beads beads", 0.0, "Fancy.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3827), new TimeSpan(0, 1, 0, 0, 0)), "Bands" },
                    { new Guid("4f4d0604-95f2-42e3-a7b6-e2cb5e0f9666"), 21, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3852), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Variety of Beadys", 0.0, "Fancy.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3852), new TimeSpan(0, 1, 0, 0, 0)), "Beads" },
                    { new Guid("8cd355e6-7a52-400b-bc76-06b6fac27233"), 9, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3841), new TimeSpan(0, 1, 0, 0, 0)), 70000m, "Picture of two peopleon a boat", 0.0, "Mashafa.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3842), new TimeSpan(0, 1, 0, 0, 0)), "Mashafa" },
                    { new Guid("8d06c2a2-ade0-48f9-9ba3-4bcdba6ea38f"), 43, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3829), new TimeSpan(0, 1, 0, 0, 0)), 5000m, "Sketch of various fishingequipment", 0.0, "Fishing.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3830), new TimeSpan(0, 1, 0, 0, 0)), "Fishing Equipment" },
                    { new Guid("98e32a53-00fc-4bee-86a9-d510ab92f9b3"), 29, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Masks masks masks", 0.0, "three.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3855), new TimeSpan(0, 1, 0, 0, 0)), "Three Masks" },
                    { new Guid("a61543e1-52f6-4141-8833-045dc77911da"), 10, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Ancestral masks from some kingdom", 0.0, "Ancient.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3820), new TimeSpan(0, 1, 0, 0, 0)), "Ancient Masks" },
                    { new Guid("b2101e72-6268-479e-8dba-4ac8e03a764c"), 9, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3831), new TimeSpan(0, 1, 0, 0, 0)), 2500m, "Stones from somewhere in Jos", 0.0, "Jos.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3832), new TimeSpan(0, 1, 0, 0, 0)), "A whole Rock" },
                    { new Guid("b6a0ac97-d7b5-4bcd-9c25-5da1d1f98db6"), 5, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 1, 0, 0, 0)), 2500m, "A black/white painting of a monkey", 0.0, "Monkey.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3815), new TimeSpan(0, 1, 0, 0, 0)), "Monkey Drawing" },
                    { new Guid("b83b5bd3-635c-4024-a76f-ee9d48a19695"), 22, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3849), new TimeSpan(0, 1, 0, 0, 0)), 20000m, "Acrylic design", 0.0, "Spiral.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3850), new TimeSpan(0, 1, 0, 0, 0)), "Spiral" },
                    { new Guid("df4fe3fd-35f9-4c23-9950-218f8149057d"), 3, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3836), new TimeSpan(0, 1, 0, 0, 0)), 6000m, "People wearing some clothes", 0.0, "Lots.jpg", false, new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3837), new TimeSpan(0, 1, 0, 0, 0)), "People" }
                });

            migrationBuilder.InsertData(
                table: "Promos",
                columns: new[] { "PromotionId", "Description", "ImageLocation", "Name" },
                values: new object[] { new Guid("e5a2f19e-57e6-4440-a780-ef103dbaf5e4"), "Announce 50% off all items", "assets/promotions/Availability.png", "50Percent off" });
        }

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
