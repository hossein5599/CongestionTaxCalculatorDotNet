using CongestionTaxCalculatorDotNet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CongestionTaxCalculatorDotNet.Contexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
            
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    //{

    //    optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=CongestionTaxCalculatorDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {

        modelBuilder.Entity<TaxRule>(entity =>
        {

            entity.ToTable("TaxRules");
            entity.HasKey(p => p.Id).HasName("Id");

            entity.Property(p => p.Id)

            .HasColumnName("Id");

            entity.Property(p => p.StartTime)
           .HasColumnName("StartTime")
           .HasColumnType("datetime");

            entity.Property(p => p.EndTime)
           .HasColumnName("EndTime")
           .HasColumnType("datetime");

        });

    }

    public DbSet<TaxRule> TaxRules { get; set; }
}

