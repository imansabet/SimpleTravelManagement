﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Infrastructure.EF.Config;
internal sealed class WriteConfiguration : IEntityTypeConfiguration<TravelerCheckList>, IEntityTypeConfiguration<TravelerItem>
{
    public void Configure(EntityTypeBuilder<TravelerCheckList> builder)
    {
        builder.HasKey(pl => pl.Id);

        var destinationConverter = new ValueConverter<Destination, string>(l => l.ToString(),
            l => Destination.Create(l));

        var packingListNameConverter = new ValueConverter<TravelerCheckListName, string>(pln => pln.Value,
            pln => new TravelerCheckListName(pln));

        builder
            .Property(pl => pl.Id)
            .HasConversion(id => id.Value, id => new TravelerCheckListId(id));

        builder
            .Property(typeof(Destination), "_destination")
            .HasConversion(destinationConverter)
            .HasColumnName("Destination");

        builder
            .Property(typeof(TravelerCheckListName), "_name")
            .HasConversion(packingListNameConverter)
            .HasColumnName("Name");

        builder.HasMany(typeof(TravelerItem), "_items");

        builder.ToTable("TravelerCheckList");
    }

    public void Configure(EntityTypeBuilder<TravelerItem> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(pi => pi.Name);
        builder.Property(pi => pi.Quantity);
        builder.Property(pi => pi.IsTaken);
        builder.ToTable("TravelerItems");
    }
}