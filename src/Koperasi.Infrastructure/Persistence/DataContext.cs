using Microsoft.EntityFrameworkCore;
using Koperasi.Domain.Configurations;
using Koperasi.Domain.Entities;

namespace Koperasi.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        public DataContext(
            DbContextOptions<DataContext> options, 
            IConnectionStringProvider connectionStringProvider) : base(options)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public DbSet<UserEntity> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionStringProvider.GetConnectionString());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}
