using EarlyMan.DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EarlyMan.DL.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promos { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Name = "Monkey Drawing",
                    CurrentPrice = 2500,
                    Description = "A black/white painting of a monkey",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Monkey.jpg",
                    AvailableUnits = 5,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Ancient Masks",
                    CurrentPrice = 20000,
                    Description = "Ancestral masks from some kingdom",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Ancient.jpg",
                    AvailableUnits = 10,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Bands",
                    CurrentPrice = 500,
                    Description = "Beads beads beads",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Fancy.jpg",
                    AvailableUnits = 3,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Fishing Equipment",
                    CurrentPrice = 5000,
                    Description = "Sketch of various fishing" +
                  "equipment",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Fishing.jpg",
                    AvailableUnits = 43,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "A whole Rock",
                    CurrentPrice = 2500,
                    Description = "Stones from somewhere in Jos",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Jos.jpg",
                    AvailableUnits = 9,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "People",
                    CurrentPrice = 6000,
                    Description = "People wearing some clothes",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Lots.jpg",
                    AvailableUnits = 3,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Hut and Man",
                    CurrentPrice = 20,
                    Description = "Sketch of a man under a hut",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "ShadyMan.jpg",
                    AvailableUnits = 1,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Mashafa",
                    CurrentPrice = 70000,
                    Description = "Picture of two people" +
                  "on a boat",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Mashafa.jpg",
                    AvailableUnits = 9,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Luxor",
                    CurrentPrice = 20000,
                    Description = "Design design design",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Design.jpg",
                    AvailableUnits = 1,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Spiral",
                    CurrentPrice = 20000,
                    Description = "Acrylic design",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Spiral.jpg",
                    AvailableUnits = 22,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Beads",
                    CurrentPrice = 20000,
                    Description = "Variety of Beadys",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "Fancy.jpg",
                    AvailableUnits = 21,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new Product
                {
                    Name = "Three Masks",
                    CurrentPrice = 20000,
                    Description = "Masks masks masks",
                    ProductId = Guid.NewGuid(),
                    ImageLocation = "three.jpg",
                    AvailableUnits = 29,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                });

            modelBuilder.Entity<Promotion>().HasData(
                new Promotion
                {
                    Name = "50Percent off",
                    Description = "Announce 50% off all items",
                    PromotionId = Guid.NewGuid(),
                    ImageLocation = "assets/promotions/Availability.png"
                });
        }
    }
}