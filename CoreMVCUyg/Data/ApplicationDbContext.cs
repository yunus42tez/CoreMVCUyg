using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCUyg.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
        public DbSet<CoreMVCUyg.Models.Home> Home { get; set; }
        public DbSet<CoreMVCUyg.Models.About> About { get; set; }
        public DbSet<CoreMVCUyg.Models.Service> Service { get; set; }
        public DbSet<CoreMVCUyg.Models.Email> Email { get; set; }
        public DbSet<CoreMVCUyg.Models.Message> Message { get; set; }
        public DbSet<CoreMVCUyg.Models.Slider> Slider { get; set; }
        public DbSet<CoreMVCUyg.Models.WebsiteInfo> WebsiteInfo { get; set; }
        public DbSet<CoreMVCUyg.Models.ProductMainCategory> ProductMainCategory { get; set; }
        public DbSet<CoreMVCUyg.Models.ProductCategory> ProductCategory { get; set; }
        public DbSet<CoreMVCUyg.Models.ProductSubCategory> ProductSubCategory { get; set; }
        public DbSet<CoreMVCUyg.Models.Product> Product { get; set; }
    }
}