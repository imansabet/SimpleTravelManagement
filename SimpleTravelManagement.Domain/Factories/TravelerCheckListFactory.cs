using SimpleTravelManagement.Domain.Consts;
using SimpleTravelManagement.Domain.Entities;
using SimpleTravelManagement.Domain.Policies;
using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Factories;

public class TravelerCheckListFactory : ITravelerCheckListFactory
{
    private readonly IEnumerable<ITravelerItemsPolicy> _policies;

    public TravelerCheckListFactory(IEnumerable<ITravelerItemsPolicy> policies)
    {
        _policies = policies;
    }
    public TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, Destination destination)
        => new(id, name, destination);

    public TravelerCheckList CreateWithDefaultItems
        (TravelerCheckListId id
        , TravelerCheckListName name
        , TravelDays days, Gender gender, Temperature temperature, Destination destination)
    {

        var data = new PolicyData(days, gender, temperature, destination);
        var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

        var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));

        var travelerCheckingList = Create(id, name, destination);

        travelerCheckingList.AddItems(items);
        return travelerCheckingList;

    }
}
