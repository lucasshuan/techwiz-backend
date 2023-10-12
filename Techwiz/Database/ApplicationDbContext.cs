using Microsoft.EntityFrameworkCore;
using Techwiz.Models;

namespace Techwiz.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.HasIndex(u => u.Name).IsUnique();

                entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
                
                entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW(6)").ValueGeneratedOnAdd();
                
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("NOW(6)").ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}