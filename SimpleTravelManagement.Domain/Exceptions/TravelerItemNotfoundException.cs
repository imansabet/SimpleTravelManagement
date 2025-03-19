using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Domain.Exceptions;

public class TravelerItemNotFoundException : TravelerCheckListException
{

    public string ItemName { get; }

    public TravelerItemNotFoundException(string itemName) : base($"Traveler item `{itemName}` Not Found") 
        => ItemName = itemName;
    
}