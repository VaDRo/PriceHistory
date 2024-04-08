using Microsoft.EntityFrameworkCore;
using PriceHistory.Model.Common;

namespace PriceHistory.Data
{
    public class PriceHistoryContext : DbContext
    {
        public DbSet<Producer> Producer { get; set; }

        public DbSet<ConcreteModel> ConcreteModel {  get; set; }

        public DbSet<ProductProperty> Property { get; set; }

        public DbSet<PropertyValue> PropertyValue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=PriceHistory;user=dbuser;password=mysqldb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<ConcreteModel>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.HasOne(m => m.Producer)
                        .WithMany(p => p.Models);
            });

            modelBuilder.Entity<ProductProperty>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<PropertyValue>(entity =>
            {
                entity.HasKey(pv => pv.Id);
                //entity.Property(pv => pv.Property).IsRequired();
                entity.Property(pv => pv.Value).IsRequired();
                entity.HasOne(m => m.ConcreteModel)
                        .WithMany(p => p.PropertyValues);
                entity.HasOne(m => m.Property)
                        .WithMany(p => p.PropertyValues);
            });
        }
    }
}
