using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace EarlyMan.Models
{
    public class SeedData

    {
        public SeedData(IConfiguration config) => Configuration = config;

        public IConfiguration Configuration { get; }

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            // context.Database.Migrate();

            if (!context.Promos.Any())
            {
                context.Promos.AddRange(

                    new Promotion
                    {
                        Name = "Castle",

                        Description = "Replacement chess piece",
                        Id = GenerateGUID(),
                        Location = "Castle"
                    },
                      new Promotion
                      {
                          Name = "Groot",
                          Id = GenerateGUID(),
                          Description = "Cutie from marvel cinematic universe",

                          Location = "Groot"
                      },
                   new Promotion
                   {
                       Name = "Hulk",
                       Id = GenerateGUID(),
                       Description = "Green, always angry, strong",

                       Location = "Hulk"
                   });
            }
            // Populate the Products table
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Covid19_Joke",
                        Price = 2500,
                        Description = "Corona virus joke poster",

                        Id = GenerateGUID(),
                        Location = "img1"
                    }, new Product
                    {
                        Name = "NigerianOrtodox",
                        Price = 20000,
                        Description = "Ancient orthodox catholic" +
                        "woman from Nigeria.",

                        Id = GenerateGUID(),
                        Location = "img2"
                    },
                   new Product
                   {
                       Name = "SpongeBob_Unmiss",
                       Price = 500,
                       Description = "\"He never misses\" joke",

                       Id = GenerateGUID(),
                       Location = "img3"
                   },
                    new Product
                    {
                        Name = "CrazyComp",
                        Price = 5000,
                        Description = "3D render of a crazy computer",

                        Id = GenerateGUID(),
                        Location = "img4"
                    },
                    new Product
                    {
                        Name = "PonziSchemeSpotter",
                        Price = 2500,
                        Description = "Educative image of how to " +
                        "spot a Ponzi scheme",

                        Id = GenerateGUID(),
                        Location = "img5"
                    },
                    new Product
                    {
                        Name = "Scooby doo vs Interfaces",
                        Price = 6000,
                        Description = "Interface joke",

                        Id = GenerateGUID(),
                        Location = "img6"
                    },
                    new Product
                    {
                        Name = "IQ Joke",
                        Price = 20000,
                        Description = "One Piece IQ joke",

                        Id = GenerateGUID(),
                        Location = "img7"
                    }
                    );
            }
            context.SaveChanges();
        }

        private static string GenerateGUID()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}