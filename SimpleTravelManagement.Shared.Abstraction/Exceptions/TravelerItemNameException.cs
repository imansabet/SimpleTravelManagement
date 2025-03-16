namespace SimpleTravelManagement.Shared.Abstractions.Exceptions;

public class TravelerItemNameException : TravelerCheckListException

{
    public TravelerItemNameException() : base("Traveler Item Name Cant Be Empty . ")
    {
    }
}
