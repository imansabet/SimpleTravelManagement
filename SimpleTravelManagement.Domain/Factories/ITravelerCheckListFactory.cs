using SimpleTravelManagement.Domain.Consts;
using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Factories;

public interface ITravelerCheckListFactory
{
    TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, Destination destination);
    TravelerCheckList CreateWithDefaultItems
        (TravelerCheckListId id
        , TravelerCheckListName travelerCheckListName
        , TravelDays days
        , Gender gender
        , Temperature temperature
        , Destination destination
        );
}
 