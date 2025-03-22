using Microsoft.EntityFrameworkCore;
using SimpleTravelManagement.Application.Services;
using SimpleTravelManagement.Infrastructure.EF.Context;
using SimpleTravelManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravelManagement.Infrastructure.EF.Services;
internal sealed class TravelerCheckListReadService : ITravelerCheckListReadService
{
    private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

    public TravelerCheckListReadService(ReadDbContext context)
        => _travelerCheckList = context.TravelerCheckList;

    public Task<bool> ExistsByNameAsync(string name)
        => _travelerCheckList.AnyAsync(pl => pl.Name == name);
}