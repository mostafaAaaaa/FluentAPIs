using FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPI.Contexts
{
    public class ConvectionContext : DbContext
    {
        public ConvectionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vendor> vendors { get; set; }

        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vendor>().ToTable("VendorFluentApi");

            modelBuilder.Entity<Vendor>().Property(v=> v.PhoneNumber).HasColumnName("Phone");
            modelBuilder.Entity<Vendor>().Property(v => v.PhoneNumber).HasMaxLength(11);
            modelBuilder.Entity<Tag>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);

            modelBuilder.Entity<Vendor>()
           .HasMany(t => t.Tags)
           .WithOne(v => v.vendor);

            // modelBuilder.Entity<Vendor>().HasForeignKey(p => p.AuthorFK);

            //   modelBuilder.Entity<Tag>().Ignore(t =>t.Id);
            //  modelBuilder.Ignore<Tag>();





        }

    }
}
