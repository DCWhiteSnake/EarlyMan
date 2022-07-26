//using EarlyMan.DL.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

//namespace EarlyMan.DL
//{
//    public class AppDbContextFactory
//    {
//        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//        {
//            public ApplicationDbContextFactory()
//            {

//            }

//            private readonly IConfiguration Configuration;
//            public ApplicationDbContextFactory(IConfiguration configuration)
//            {
//                Configuration = configuration;
//            }
//            public ApplicationDbContext CreateDbContext(string[] args)
//            {

//                string filePath = @"C:\Users\Administrator\source\repos\CheckPoint\NullMVC\appsettings.json";

//                IConfiguration Configuration = new ConfigurationBuilder()
//                   .SetBasePath(Path.GetDirectoryName(filePath))
//                   .AddJsonFile("appSettings.json")
//                   .Build();


//                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
               
//                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("EarlyManIdentity"));
//                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("EarlyManDatabase"));

//                return new ApplicationDbContext(optionsBuilder.Options);
//            }
//        }
//    }
//}
