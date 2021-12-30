using Microsoft.EntityFrameworkCore;
using Phones.Domain.Entities;
using Phones.Infrastrructure.Configurations;

namespace Phones.Infrastrructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Brand> Brands { get; set; }
        
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}