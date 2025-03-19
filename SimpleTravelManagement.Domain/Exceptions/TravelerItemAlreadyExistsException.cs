using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Domain.Exceptions;

public class TravelerItemAlreadyExistsException : TravelerCheckListException
{
    public string ListName { get; }
    public string ItemName { get; }

    public TravelerItemAlreadyExistsException(string listName , string itemName)
        : base($"Traveler Check List:`{listName}` already defined item `{itemName}` ")
    {
        ListName = listName;
        ItemName = itemName;
    }
}
