using SimpleTravelManagement.Shared.Abstractions.Exceptions;

namespace SimpleTravelManagement.Application.Exceptions;

public class TravelerCheckListNotFound : TravelerCheckListException
{
    public Guid Id { get; }
    public TravelerCheckListNotFound(Guid id) : base($"Traveler checklist with Id `{id}` was not found ")
     => Id = id;
}
