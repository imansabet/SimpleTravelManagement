using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Policies.Temperature;

internal sealed class HighTemperaturePolicy : ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Temperature > 25D;


    public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Hat",1),
            new("Flip-Flops",1),
            new("Sun Lotion with UV Filter",1)
        };
}
