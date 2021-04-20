using System;
using Microsoft.EntityFrameworkCore;
using DeveloperTest.Database.Models;

namespace DeveloperTest.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasKey(x => x.JobId);

            modelBuilder.Entity<Job>()
                .Property(x => x.JobId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Job>()
                .HasData(new Job
                {
                    JobId = 1,
                    Engineer = "Test",
                    When = DateTime.Now
                });

            modelBuilder.Entity<Customer>()
                .HasData(new Customer
                {
                    CustomerId = 1,
                    Name = "Small customer",
                    TypeId = 0
                });

            modelBuilder.Entity<Customer>()
                .HasData(new Customer
                {
                    CustomerId = 2,
                    Name = "Large customer",
                    TypeId = 1
                });

            modelBuilder.Entity<Job>()
                .HasData(new Job
                {
                    JobId = 2,
                    Engineer = "Test",
                    When = DateTime.Now,
                    CustomerId = 2
                });

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .Property(x => x.Name)
                .HasMaxLength(512);

            modelBuilder.Entity<Customer>()
               .Property(x => x.TypeId)
               .IsRequired();

            modelBuilder.Entity<Job>()
                .HasOne(e => e.Customer)
                .WithMany(c => c.Jobs)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
