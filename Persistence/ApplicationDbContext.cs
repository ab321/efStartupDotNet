using System.Diagnostics;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApplicationDbContext : DbContext
{

    public DbSet<Car> Cars { get; set; }
    public DbSet<Tyre> Tyres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            optionsBuilder
                .LogTo(msg => Debug.WriteLine(msg),
                    LogLevel.Debug,
                    DbContextLoggerOptions.SingleLine | DbContextLoggerOptions.UtcTime)
                .UseNpgsql(configuration["ConnectionStrings:Default"]);
        }
    }
    
    public void foo(){}
}