
using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands;

public record TakeItem(Guid TravelerCheckListId , string Name ): ICommand;
