using Microsoft.EntityFrameworkCore;
using SimpleTravelManagement.Application.DTO;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Infrastructure.EF.Context;
using SimpleTravelManagement.Infrastructure.EF.Models;
using SimpleTravelManagement.Infrastructure.EF.Queries;
using SimpleTravelManagement.Shared.Abstractions.Queries;

namespace SimpleTravelManagement.Application.Queries.Handlers;

internal sealed class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
{
    private readonly DbSet<TravelerCheckListReadModel> _TravelerCheckLists;

    public GetTravelerCheckListHandler(ReadDbContext context)
        => _TravelerCheckLists = context.TravelerCheckList;

    public Task<TravelerCheckListDto> HandleAsync(GetTravelerCheckList query)
        => _TravelerCheckLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}