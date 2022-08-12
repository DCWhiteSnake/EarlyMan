﻿// <auto-generated />
using System;
using EarlyMan.DL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EarlyMan.DL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220725223648_AddCartLine")]
    partial class AddCartLine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EarlyMan.DL.Entities.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("EarlyMan.DL.Entities.CartItem", b =>
                {
                    b.Property<Guid>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PurchasePrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PurchaseQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("valid")
                        .HasColumnType("bit");

                    b.HasKey("CartItemId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("EarlyMan.DL.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableUnits")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("CurrentPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("float");

                    b.Property<string>("ImageLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("b6a0ac97-d7b5-4bcd-9c25-5da1d1f98db6"),
                            AvailableUnits = 5,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3724), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 2500m,
                            Description = "A black/white painting of a monkey",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Monkey.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3815), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Monkey Drawing"
                        },
                        new
                        {
                            ProductId = new Guid("a61543e1-52f6-4141-8833-045dc77911da"),
                            AvailableUnits = 10,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3819), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Ancestral masks from some kingdom",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Ancient.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3820), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Ancient Masks"
                        },
                        new
                        {
                            ProductId = new Guid("3d9a1c95-3a32-4d18-8222-aa4644ae94dd"),
                            AvailableUnits = 3,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3826), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 500m,
                            Description = "Beads beads beads",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Fancy.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3827), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Bands"
                        },
                        new
                        {
                            ProductId = new Guid("8d06c2a2-ade0-48f9-9ba3-4bcdba6ea38f"),
                            AvailableUnits = 43,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3829), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 5000m,
                            Description = "Sketch of various fishingequipment",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Fishing.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3830), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Fishing Equipment"
                        },
                        new
                        {
                            ProductId = new Guid("b2101e72-6268-479e-8dba-4ac8e03a764c"),
                            AvailableUnits = 9,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3831), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 2500m,
                            Description = "Stones from somewhere in Jos",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Jos.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3832), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "A whole Rock"
                        },
                        new
                        {
                            ProductId = new Guid("df4fe3fd-35f9-4c23-9950-218f8149057d"),
                            AvailableUnits = 3,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3836), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 6000m,
                            Description = "People wearing some clothes",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Lots.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3837), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "People"
                        },
                        new
                        {
                            ProductId = new Guid("3bcac08b-0865-4c8b-85cc-012d61313591"),
                            AvailableUnits = 1,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20m,
                            Description = "Sketch of a man under a hut",
                            DiscountPercentage = 0.0,
                            ImageLocation = "ShadyMan.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3839), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Hut and Man"
                        },
                        new
                        {
                            ProductId = new Guid("8cd355e6-7a52-400b-bc76-06b6fac27233"),
                            AvailableUnits = 9,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3841), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 70000m,
                            Description = "Picture of two peopleon a boat",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Mashafa.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3842), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Mashafa"
                        },
                        new
                        {
                            ProductId = new Guid("3a0e5798-9cd0-44fc-aaed-289d59bc77d4"),
                            AvailableUnits = 1,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3846), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Design design design",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Design.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3847), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Luxor"
                        },
                        new
                        {
                            ProductId = new Guid("b83b5bd3-635c-4024-a76f-ee9d48a19695"),
                            AvailableUnits = 22,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3849), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Acrylic design",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Spiral.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3850), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Spiral"
                        },
                        new
                        {
                            ProductId = new Guid("4f4d0604-95f2-42e3-a7b6-e2cb5e0f9666"),
                            AvailableUnits = 21,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3852), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Variety of Beadys",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Fancy.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3852), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Beads"
                        },
                        new
                        {
                            ProductId = new Guid("98e32a53-00fc-4bee-86a9-d510ab92f9b3"),
                            AvailableUnits = 29,
                            CreationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3854), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Masks masks masks",
                            DiscountPercentage = 0.0,
                            ImageLocation = "three.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2022, 7, 25, 23, 36, 48, 644, DateTimeKind.Unspecified).AddTicks(3855), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Three Masks"
                        });
                });

            modelBuilder.Entity("EarlyMan.DL.Entities.Promotion", b =>
                {
                    b.Property<Guid>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageLocation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PromotionId");

                    b.ToTable("Promos");

                    b.HasData(
                        new
                        {
                            PromotionId = new Guid("e5a2f19e-57e6-4440-a780-ef103dbaf5e4"),
                            Description = "Announce 50% off all items",
                            ImageLocation = "assets/promotions/Availability.png",
                            Name = "50Percent off"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}