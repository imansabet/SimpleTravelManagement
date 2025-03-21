using SimpleTravelManagement.Application.Exceptions;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands.Handlers;

internal sealed class RemoveTravelerCheckListHandler : ICommandHandler<RemoveTravelerCheckList>
{
    private readonly ITravelerCheckListRepository _repository;

    public RemoveTravelerCheckListHandler(ITravelerCheckListRepository repository)
    {
        _repository = repository;
    }
    public async Task HandleAsync(RemoveTravelerCheckList command)
    {
        var TravelerCheckList = await _repository.GetAsync(command.Id);
        if (TravelerCheckList is null) 
        {
            throw new TravelerCheckListNotFound(command.Id);
        }
        await _repository.DeleteAsync(TravelerCheckList);
    }
}
