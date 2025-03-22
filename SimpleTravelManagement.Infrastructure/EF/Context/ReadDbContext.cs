using Microsoft.EntityFrameworkCore;
using SimpleTravelManagement.Infrastructure.EF.Config;
using SimpleTravelManagement.Infrastructure.EF.Models;

namespace SimpleTravelManagement.Infrastructure.EF.Context;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<TravelerCheckListReadModel> TravelerCheckList { get; set; }
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TravelerCheckList");

        var configuration = new ReadConfiguration();

        modelBuilder.ApplyConfiguration<TravelerCheckListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<TravelerItemReadModel>(configuration);
    }
}
