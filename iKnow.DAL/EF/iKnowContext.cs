using iKnow.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace iKnow.DAL.EF
{
    public class iKnowContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PhoneEntity> Phones { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public iKnowContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            string dbConnectionInfo = builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            optionsBuilder.UseSqlServer(dbConnectionInfo);
        }
    }
}
