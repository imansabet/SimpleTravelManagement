using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Domain.Exceptions;

public class TravelerItemNameException : TravelerCheckListException

{
    public TravelerItemNameException() : base("Traveler Item Name Cant Be Empty . ")
    {
    }
}
