//using EarlyMan.DL.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System.IO;

//namespace EarlyMan.DL
//{
//    public static class ISserviceCollectionExtension
//    {
//        public static IServiceCollection configureservice(this IServiceCollection service, IConfiguration Configuration)
//        {
//            //access the appsetting json file in your WebApplication File

//            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"../EarlyMan.PL", "appsettings.json");

//            Configuration = new ConfigurationBuilder()
//               .SetBasePath(Path.GetDirectoryName(filePath))
//               .AddJsonFile("appSettings.json")
//               .Build();

//            service.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("EarlyManIdentity")));

//            service.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("EarlyManDatabase")));
//            return service;
//        }
//    }
//}
