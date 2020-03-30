using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Weekend.DAL.Models;

namespace Weekend.DAL.Context
{
    public partial class WeekendContext : DbContext
    {
        private readonly string connection;

        public WeekendContext(string connection)
        {
            this.connection = connection;
        }

        public WeekendContext(DbContextOptions<WeekendContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserLoginForm> UserLoginForm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Language).HasDefaultValueSql("(N'None')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
