using Microsoft.EntityFrameworkCore;
using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.ValueObjects;
using SimpleTravelManagement.Infrastructure.EF.Config;
using SimpleTravelManagement.Infrastructure.EF.Models;

namespace SimpleTravelManagement.Infrastructure.EF.Context;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<TravelerCheckList> TravelerCheckLists { get; set; }
    public WriteDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TravelerCheckList");

        var configuration = new WriteConfiguration();

        modelBuilder.ApplyConfiguration<TravelerCheckList>(configuration);
        modelBuilder.ApplyConfiguration<TravelerItem>(configuration);
    }
}
