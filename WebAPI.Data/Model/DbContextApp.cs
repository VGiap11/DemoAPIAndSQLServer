using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data.Model
{
    public class DbContextApp : DbContext
    {
        public DbContextApp()
        {
        }
        public DbContextApp(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VGiap;Initial Catalog=DemoC5;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Student> Students { get; set; }
    }
}
