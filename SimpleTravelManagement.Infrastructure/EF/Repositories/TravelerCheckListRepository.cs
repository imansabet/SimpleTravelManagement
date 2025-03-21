﻿using Microsoft.EntityFrameworkCore;
using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Domain.ValueObjects;
using SimpleTravelManagement.Infrastructure.EF.Context;

namespace SimpleTravelManagement.Infrastructure.EF.Repositories;
internal sealed class TravelerCheckListRepository : ITravelerCheckListRepository
{
    private readonly DbSet<TravelerCheckList> _travelerCheckList;
    private readonly WriteDbContext _writeDbContext;

    public TravelerCheckListRepository(WriteDbContext writeDbContext)
    {
        _travelerCheckList = writeDbContext.TravelerCheckLists;
        _writeDbContext = writeDbContext;
    }

    public Task<TravelerCheckList> GetAsync(TravelerCheckListId id)
        => _travelerCheckList.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

    public async Task AddAsync(TravelerCheckList travelerCheckList)
    {
        await _travelerCheckList.AddAsync(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TravelerCheckList travelerCheckList)
    {
        _travelerCheckList.Update(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TravelerCheckList travelerCheckList)
    {
        _travelerCheckList.Remove(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }
}