using SimpleTravelManagement.Application.Exceptions;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands.Handlers;

internal sealed class TakeItemHandler : ICommandHandler<TakeItem>
{
    private readonly ITravelerCheckListRepository _repository;

    public TakeItemHandler(ITravelerCheckListRepository repository)
    {
       _repository = repository;
    }
    public async Task HandleAsync(TakeItem command)
    {
        var travelerCheckingList = await _repository.GetAsync(command.TravelerCheckListId);
        if (travelerCheckingList is null)
        {
            throw new TravelerCheckListNotFound(command.TravelerCheckListId);
        }
        travelerCheckingList.TakeItem(command.Name);
         
        await _repository.UpdateAsync(travelerCheckingList);
    }
}
