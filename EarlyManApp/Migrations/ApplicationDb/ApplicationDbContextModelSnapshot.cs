﻿// <auto-generated />
using System;
using EarlyMan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EarlyManApp.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EarlyMan.Entities.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("EarlyMan.Entities.CartItem", b =>
                {
                    b.Property<Guid>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CartId")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("PurchasePrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PurchaseQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Valid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CartItemId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("EarlyMan.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AvailableUnits")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("CurrentPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("double");

                    b.Property<string>("ImageLocation")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("409582f3-5bc9-465e-b6a6-cb1845c1d025"),
                            AvailableUnits = 5,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7206), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 2500m,
                            Description = "A black/white painting of a monkey",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Monkey.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7304), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Monkey Drawing"
                        },
                        new
                        {
                            ProductId = new Guid("c1ae2d0b-cf20-480e-8ea8-d9a78e4c4fd4"),
                            AvailableUnits = 10,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7353), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Ancestral masks from some kingdom",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Ancient.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7363), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Ancient Masks"
                        },
                        new
                        {
                            ProductId = new Guid("d2fc0cf3-3630-45ce-b1d4-5ddf6af44b49"),
                            AvailableUnits = 3,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 500m,
                            Description = "Beads beads beads",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Fancy.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7478), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Bands"
                        },
                        new
                        {
                            ProductId = new Guid("230d3c60-68e0-467d-ae53-bf0edf49fb6d"),
                            AvailableUnits = 43,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7516), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 5000m,
                            Description = "Sketch of various fishingequipment",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Fishing.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7523), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Fishing Equipment"
                        },
                        new
                        {
                            ProductId = new Guid("021abd14-54f3-4885-b4dc-c6bb2f808df0"),
                            AvailableUnits = 9,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7545), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 2500m,
                            Description = "Stones from somewhere in Jos",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Jos.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7553), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "A whole Rock"
                        },
                        new
                        {
                            ProductId = new Guid("fb26190e-1da6-4529-9680-b3735fe293ce"),
                            AvailableUnits = 3,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7576), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 6000m,
                            Description = "People wearing some clothes",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Lots.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7582), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "People"
                        },
                        new
                        {
                            ProductId = new Guid("656ba007-917d-4635-93bc-e1bc8295758e"),
                            AvailableUnits = 1,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7603), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20m,
                            Description = "Sketch of a man under a hut",
                            DiscountPercentage = 0.0,
                            ImageLocation = "ShadyMan.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7613), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Hut and Man"
                        },
                        new
                        {
                            ProductId = new Guid("048e58cb-3515-4aa9-89aa-0d1f8c1dd75d"),
                            AvailableUnits = 9,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7634), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 70000m,
                            Description = "Picture of two peopleon a boat",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Mashafa.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7644), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Mashafa"
                        },
                        new
                        {
                            ProductId = new Guid("467f1214-d93d-4de1-b99d-b225b56b590c"),
                            AvailableUnits = 1,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7666), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Design design design",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Design.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7673), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Luxor"
                        },
                        new
                        {
                            ProductId = new Guid("1b2aa8ba-1810-4fee-a9ec-a3e49fc68c7f"),
                            AvailableUnits = 22,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7695), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Acrylic design",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Spiral.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7702), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Spiral"
                        },
                        new
                        {
                            ProductId = new Guid("ee2ca912-b5c3-4b16-b693-fadb34f87294"),
                            AvailableUnits = 21,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7724), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Variety of Beadys",
                            DiscountPercentage = 0.0,
                            ImageLocation = "Fancy.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7731), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Beads"
                        },
                        new
                        {
                            ProductId = new Guid("2a451e37-b21b-4884-9b4c-185b68d7bb2e"),
                            AvailableUnits = 29,
                            CreationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7750), new TimeSpan(0, 1, 0, 0, 0)),
                            CurrentPrice = 20000m,
                            Description = "Masks masks masks",
                            DiscountPercentage = 0.0,
                            ImageLocation = "three.jpg",
                            IsAvailable = false,
                            ModificationDate = new DateTimeOffset(new DateTime(2023, 8, 5, 23, 16, 46, 532, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 1, 0, 0, 0)),
                            Name = "Three Masks"
                        });
                });

            modelBuilder.Entity("EarlyMan.Entities.Promotion", b =>
                {
                    b.Property<Guid>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ImageLocation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("PromotionId");

                    b.ToTable("Promos");

                    b.HasData(
                        new
                        {
                            PromotionId = new Guid("a9766f75-ef68-4233-ab9c-a10e4307b37c"),
                            Description = "Announce 50% off all items",
                            ImageLocation = "assets/promotions/Availability.png",
                            Name = "50Percent off"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}