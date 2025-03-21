using SimpleTravelManagement.Domain.Consts;
using SimpleTravelManagement.Shared.Abstractions.Commands;

namespace SimpleTravelManagement.Application.Commands;

public record CreateTravelerCheckListWithItems
    (Guid Id
    ,string Name 
    , ushort Days 
    , Gender Gender
    , DestinationWrtieModel Destination
    ) : ICommand;

public record DestinationWrtieModel(string City,string Country);

