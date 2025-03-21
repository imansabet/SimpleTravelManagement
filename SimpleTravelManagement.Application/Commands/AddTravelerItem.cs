using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands;

public record AddTravelerItem
    (Guid TravelerCheckListId
    ,string Name
    , uint Quantity
    ):  ICommand;
