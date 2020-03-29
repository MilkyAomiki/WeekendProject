using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Weekend.DAL.Models;

namespace Weekend.DAL.Context
{
    public partial class WeekendContext : DbContext
    {
        public WeekendContext()
        {
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=ec2-176-34-97-213.eu-west-1.compute.amazonaws.com; Port=5432;Database=d84j362jdh5186;Username=eidqnyaouhsayz;Password=6dea5f0774da28b73d828e605fa0294e6d446938f851c532e7702bf79b304dd7; Pooling=true; SSL Mode=Require; TrustServerCertificate=True");
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-BBTQSDD5\\SQLEXPRESS;Integrated Security=True; Database=Weekend; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
