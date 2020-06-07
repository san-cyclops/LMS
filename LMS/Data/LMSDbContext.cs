using LMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext()
        {
        }
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseMySql(config.GetConnectionString("LMSDatabase"));
        }

        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserPrivileges> UserPrivileges { get; set; }
        public DbSet<CourseType> courseTypes { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /* modelBuilder.Entity<Products>(entity =>
             {
                 entity.HasKey(e => e.ProductId)
                     .HasName("PK__Products__B40CC6CD2734EEA5");

                 entity.Property(e => e.Category)
                     .HasMaxLength(100)
                     .IsUnicode(false);

                 entity.Property(e => e.Color)
                     .HasMaxLength(20)
                     .IsUnicode(false);

                 entity.Property(e => e.CratedDate)
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("(getdate())");

                 entity.Property(e => e.Name)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(false);

                 entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
             });*/


        }

       
    }
}
