using SimpleTravelManagement.Application.DTO;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Shared.Abstractions.Queries;

namespace SimpleTravelManagement.Application.Queries.Handlers;

public class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
{
    private readonly ITravelerCheckListRepository _repository;

    public GetTravelerCheckListHandler(ITravelerCheckListRepository repository)
    {
        _repository = repository;
    }
    public async Task<TravelerCheckListDto> HandleAsync(GetTravelerCheckList query)
    {
        var travelerCheckList = await _repository.GetAsync(query.Id);

        return null;
    }
}
