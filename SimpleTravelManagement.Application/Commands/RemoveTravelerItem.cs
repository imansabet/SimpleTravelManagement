using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands;

public record RemoveTravelerItem(Guid TravelerCheckListId , string Name) : ICommand;
