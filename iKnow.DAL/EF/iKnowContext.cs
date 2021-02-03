using System.IO;
using iKnow.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace iKnow.DAL.EF
{
    public class IKnowContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EmailEntity> Emails { get; set; }
        public DbSet<ExcerciseEntity> Excercises { get; set; }

        public IKnowContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            string dbConnectionInfo = builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            optionsBuilder.UseSqlServer(dbConnectionInfo);
        }
    }
}
