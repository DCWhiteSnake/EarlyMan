using System.Collections.Generic;
using System.Linq;

namespace EarlyMan.Models
{
    public class MockRepo : Promotion
    {
        public IQueryable<Product> Prints => new List<Product>
        {
            new Product{Name = "Einstein", Price = 5000M,
                Description = "Albert Einstein was a German-born theoretical physicist who developed " +
                "the theory of relativity, one of the two pillars of modern physics " +
                "(alongside quantum mechanics).: " +
                "His work is also known for its influence on the philosophy of science",
                Location = ""},
             new Product{Name = "Sealing Wand", Price = 5000M,
                 Description = "The Sealing Wand also simply referred to as the Staff," +
                 " is a dark pink magical staff or wand about a meter in length.",
                Location = ""},
              new Product{Name = "Groot", Price = 3000M,
                  Description = "I am Groot",
                Location = ""},
               new Product{Name = "Hulk", Price = 15000M, Description = "Smash",
                Location = ""},
            new Product{Name = "Castle", Price = 8000M, Description = "",
                Location = ""}
        }.AsQueryable();
    }
}