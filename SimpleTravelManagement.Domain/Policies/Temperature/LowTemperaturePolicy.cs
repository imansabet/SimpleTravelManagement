using SimpleTravelManagement.Domain.ValueObjects;

namespace SimpleTravelManagement.Domain.Policies.Temperature;

internal sealed class LowTemperaturePolicy
{
    public bool IsApplicable(PolicyData data) => data.Temperature < 10D;


    public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Trapper Hat",1),
            new("Scarf",1),
            new("Gloves",1),
            new("Loom jacket",1)
        };
}
