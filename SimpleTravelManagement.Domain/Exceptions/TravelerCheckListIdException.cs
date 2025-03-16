using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Domain.Exceptions;

public class TravelerCheckListIdException : TravelerCheckListException
{
    public TravelerCheckListIdException() : base("Traveler CheckList Id Cant be Null")
    {
    }
}
