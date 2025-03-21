using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands;

public record RemoveTravelerCheckList(Guid Id) 
    : ICommand;

