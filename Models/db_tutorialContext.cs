using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace tutorial1.Models
{
    public partial class db_tutorialContext : DbContext
    {
        public db_tutorialContext()
        {
        }

        public db_tutorialContext(DbContextOptions<db_tutorialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<role_info> role_infos { get; set; }
        public virtual DbSet<user_info> user_infos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=db_tutorial;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.20-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_unicode_ci");

            modelBuilder.Entity<user_info>(entity =>
            {
                entity.HasOne(d => d.role)
                    .WithMany(p => p.user_infos)
                    .HasForeignKey(d => d.role_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_role_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
