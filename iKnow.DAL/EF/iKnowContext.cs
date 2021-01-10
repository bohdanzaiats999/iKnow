using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace iKnow.DAL.EF
{
    class iKnowContext : DbContext
    {
        public iKnowContext(DbContextOptions<iKnowContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            string dbConnectionInfo = builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            optionsBuilder.UseSqlServer(dbConnectionInfo);
        }
    }
}
