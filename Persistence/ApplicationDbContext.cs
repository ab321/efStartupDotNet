using System.Diagnostics;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApplicationDbContext : DbContext
{

    public DbSet<Car> Cars { get; set; }
    public DbSet<Tyre> Tyres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(msg => Debug.WriteLine(msg),
                LogLevel.Debug,
                DbContextLoggerOptions.SingleLine | DbContextLoggerOptions.UtcTime)
            .UseNpgsql("Host=localhost;Port=5432;Database=db;Username=app;Password=app");
    }
    
    public void foo(){}
}